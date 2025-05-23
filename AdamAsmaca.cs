using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace oyunKutuphanesi047
{
    public partial class AdamAsmaca : Form
    {
        private string kullaniciAdi;
        private int kullaniciId;
        private string zorlukSecim;
        private int RandomId;
        private string ArananKelime;
        static Random random = new Random();
        private int hataSayisi = 0;
        private int dogruTahminSayisi = 0;
        private int toplamHarfSayisi = 0;

        OyunSecimi oyunSecimi = new OyunSecimi();

        public AdamAsmaca(int KullaniciId, string KullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
            this.kullaniciId = KullaniciId;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.KeyPress += AdamAsmaca_KeyPress;

        }

        private void AdamAsmaca_Load(object sender, EventArgs e)
        {
            kelimeyiSec(randomIdAl());
            harfButonlariniOlustur();
            txtBoxlariGoster(ArananKelime.Length);
            toplamHarfSayisi = ArananKelime.Length;
        }

        void txtBoxlariGoster(int harfSayisi)
        {
            for (int i = 0; i < harfSayisi; i++)
            {
                Control[] txtlar = this.Controls.Find("harfTxtBox" + i, true);
                if (txtlar.Length > 0 && txtlar[0] is TextBox)
                {
                    txtlar[0].Visible = true;
                }
            }
        }

        void harfButonlariniOlustur()
        {
            string[] harfler = {
                "A", "B", "C", "Ç", "D", "E", "F", "G", "Ğ", "H",
                "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P",
                "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z"};

            int butonGenislik = 40;
            int butonYukseklik = 40;
            int bosluk = 5;
            int x = 26;
            int y = 80;

            for (int i = 0; i < harfler.Length; i++)
            {
                Button btn = new Button();
                btn.Width = butonGenislik;
                btn.Height = butonYukseklik;
                btn.Text = harfler[i];
                btn.Left = x + (i % 10) * (butonGenislik + bosluk);
                btn.Top = y + (i / 10) * (butonYukseklik + bosluk);
                btn.Name = "btn" + harfler[i];
                btn.Click += harfTiklandi;
                this.Controls.Add(btn);
            }
        }
        void puaniKaydet(int puan)
        {
            try
            {
                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT adamAsmaca FROM Puanlar WHERE kullaniciId = @id", conn);
                    cmd1.Parameters.AddWithValue("@id", kullaniciId);
                    object mevcutPuanObj = cmd1.ExecuteScalar();

                    int mevcutPuan = mevcutPuanObj != DBNull.Value ? Convert.ToInt32(mevcutPuanObj) : 0;
                    int yeniPuan = mevcutPuan + puan;

                    SqlCommand cmd2 = new SqlCommand(
                        "UPDATE Puanlar SET adamAsmaca = @puan WHERE kullaniciId = @id", conn);
                    cmd2.Parameters.AddWithValue("@puan", yeniPuan);
                    cmd2.Parameters.AddWithValue("@id", kullaniciId);
                    cmd2.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puan kaydedilirken hata oluştu: " + ex.Message);
            }
        }

        void harfTiklandi(object sender, EventArgs e)
        {
            Button tiklanan = sender as Button;
            tiklanan.Enabled = false;
            string harf = tiklanan.Text;
            bool dogruTahmin = false;

            for (int i = 0; i < ArananKelime.Length; i++)
            {
                if (ArananKelime[i].ToString().ToUpper() == harf.ToUpper())
                {
                    Control[] txtlar = this.Controls.Find("harfTxtBox" + i, true);
                    if (txtlar.Length > 0 && txtlar[0] is TextBox)
                    {
                        ((TextBox)txtlar[0]).Text = harf;
                        dogruTahmin = true;
                        dogruTahminSayisi++;
                    }
                }
            }

            if (!dogruTahmin)
            {
                hataSayisi++;
                Control[] pictureBoxlar = this.Controls.Find("hataYapti" + hataSayisi, true);
                if (pictureBoxlar.Length > 0 && pictureBoxlar[0] is PictureBox)
                {
                    ((PictureBox)pictureBoxlar[0]).Visible = false;
                }

                if (hataSayisi == 8)
                {
                    MessageBox.Show("Oyun bitti! Kaybettiniz.\n Kelime: "+ArananKelime);
                    puaniKaydet(0);
                    this.Close();
                }
            }
            else
            {
                if (dogruTahminSayisi == toplamHarfSayisi)
                {
                    int carpani = 0;
                    switch (zorlukSecim)
                    {
                        case "Kolay": carpani = 5; break;
                        case "Orta": carpani = 7; break;
                        case "Zor": carpani = 10; break;
                    }

                    int puanCarpani = 8 - hataSayisi;
                    int puan = puanCarpani * carpani;
                    MessageBox.Show($"Tebrikler! Kelimeyi bildiniz.\nPuanınız: {puan}");
                    puaniKaydet(puan);
                    this.Close();
                }
            }
        }

        public int randomIdAl()
        {
            
            int harfSayisi = zorlukAyarla();
            int randomId=0;
            switch (harfSayisi)
            {
                case 5:
                    randomId = random.Next(1, 21);
                    this.RandomId = randomId;
                    return randomId;
                case 7:
                    randomId = random.Next(21, 41);
                    this.RandomId = randomId;
                    return randomId;
                case 10:
                    randomId = random.Next(41, 61);
                    this.RandomId = randomId;
                    return randomId;
                default:
                    return 0;
            }

            
            
        }

        public int zorlukAyarla()
        {
            ZorlukSecimi zorlukSecimi = new ZorlukSecimi();
            var sonuc = zorlukSecimi.ShowDialog();

            if (sonuc != DialogResult.OK)
            {
                MessageBox.Show("Zorluk seçilmeden oyun başlatılamaz.");
                this.Close();
                return 0;
            }

            zorlukSecim = zorlukSecimi.SecilenZorluk;

            switch (zorlukSecim)
            {
                case "Kolay": return 5;
                case "Orta": return 7;
                case "Zor": return 10;
                default: return 5;
            }

        }

        public string kelimeyiSec(int kelimeId)
        {
            string arananKelime="";

            try
            {
                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand("SELECT kelime FROM asmacaKelimeler WHERE kelimeId=@kId", conn);
                    cmd.Parameters.AddWithValue("@kId", kelimeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        arananKelime = reader["kelime"].ToString();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: "+ex);
            }

            this.ArananKelime=arananKelime;
            return arananKelime;
        }

        private void AdamAsmaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            string basilanHarf = e.KeyChar.ToString().ToUpper();

            Control[] bulunanButon = this.Controls.Find("btn" + basilanHarf, true);
            if (bulunanButon.Length > 0 && bulunanButon[0] is Button)
            {
                Button hedefButon = (Button)bulunanButon[0];
                if (hedefButon.Enabled)
                {
                    hedefButon.PerformClick();
                }
            }
        }

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
