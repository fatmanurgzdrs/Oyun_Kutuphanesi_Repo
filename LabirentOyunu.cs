using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace oyunKutuphanesi047
{
    public partial class LabirentOyunu : Form
    {
        private int kullaniciId;
        private string kullaniciAd;
        private LabirentAbstract aktifLabirent;
        private int puan = 0;

        public LabirentOyunu(int kullaniciId, string kullaniciAd, Zorluk secilenZorluk)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.kullaniciId = kullaniciId;
            this.kullaniciAd = kullaniciAd;
            DoubleBuffered = true;
            this.KeyPreview = true;
            this.ActiveControl = null;

            aktifLabirent = ZorlugaGoreLabirentOlustur(secilenZorluk);
            aktifLabirent.Baslat();
            this.ClientSize = new Size(aktifLabirent.LabirentBoyutu.Width + 20, aktifLabirent.LabirentBoyutu.Height + 20);

            this.KeyDown += LabirentOyunu_KeyDown;
            this.Paint += LabirentOyunu_Paint;
        }

        private LabirentAbstract ZorlugaGoreLabirentOlustur(Zorluk zorluk)
        {
            switch (zorluk)
            {
                case Zorluk.Kolay:
                    return new LabirentKolay();
                case Zorluk.Orta:
                    return new LabirentOrta();
                case Zorluk.Zor:
                    return new LabirentZor();
                default:
                    return new LabirentKolay();
            }
        }

        private void LabirentOyunu_KeyDown(object sender, KeyEventArgs e)
        {
            aktifLabirent.LabirentOyuncu.HareketEt(e.KeyCode);

            foreach (var duvar in aktifLabirent.LabirentDuvarlar)
            {
                if (aktifLabirent.LabirentOyuncu.Konum.IntersectsWith(duvar.Konum))
                {
                    aktifLabirent.LabirentOyuncu.HareketEt(GeriTersTus(e.KeyCode));
                    break;
                }
            }

            if (aktifLabirent.LabirentOyuncu.Konum.IntersectsWith(aktifLabirent.Cikis))
            {
                if (aktifLabirent is LabirentKolay)
                    puan = 50;
                else if (aktifLabirent is LabirentOrta)
                    puan = 150;
                else if (aktifLabirent is LabirentZor)
                    puan = 250;

                MessageBox.Show("Tebrikler! Çıkışı buldunuz.");
                PuanKaydet();
            }

            Invalidate();
        }

        private Keys GeriTersTus(Keys tus)
        {
            switch (tus)
            {
                case Keys.Up:
                    return Keys.Down;
                case Keys.Down:
                    return Keys.Up;
                case Keys.Left:
                    return Keys.Right;
                case Keys.Right:
                    return Keys.Left;
                default:
                    return tus;
            }
        }

        private void PuanKaydet()
        {
            try
            {
                string query = @"
                IF EXISTS (SELECT * FROM Puanlar WHERE kullaniciId = @kullaniciId)
                    UPDATE Puanlar SET labirent = labirent + @puan WHERE kullaniciId = @kullaniciId
                ELSE
                    INSERT INTO Puanlar (kullaniciId, labirent) VALUES (@kullaniciId, @puan)";

                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@puan", puan);
                    cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Puan kaydedildi. Eklenilen puan: " + puan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puan kaydedilemedi: " + ex.Message);
            }

            this.Close();
        }

        private void LabirentOyunu_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            int duvarBoyut = 11;
            int width = aktifLabirent.LabirentBoyutu.Width;
            int height = aktifLabirent.LabirentBoyutu.Height;

            foreach (var duvar in aktifLabirent.LabirentDuvarlar)
            {
                g.FillRectangle(Brushes.Black, duvar.Konum);
            }

            g.FillEllipse(Brushes.Blue, aktifLabirent.LabirentOyuncu.Konum);
            g.FillRectangle(Brushes.Lime, aktifLabirent.Cikis);

            int kalanGenislik = width % duvarBoyut;
            if (kalanGenislik > 0)
            {
                g.FillRectangle(Brushes.Black, new Rectangle(width - kalanGenislik, 0, kalanGenislik, height));
            }

            int kalanYukseklik = height % duvarBoyut;
            if (kalanYukseklik > 0)
            {
                g.FillRectangle(Brushes.Black, new Rectangle(0, height - kalanYukseklik, width, kalanYukseklik));
            }
        }

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            LabirentOyunu_KeyDown(this, new KeyEventArgs(keyData));
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
