using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oyunKutuphanesi047
{
    public partial class OyunSecimi : Form
    {
        private static int kulId;
        private static string kulAd;

        public OyunSecimi() 
        {
            InitializeComponent();                 
        }

        public OyunSecimi(int KullaniciId, string KullaniciAdi)
        {
            InitializeComponent();
            kulId = KullaniciId;
            kulAd = KullaniciAdi;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            
        }

        private void yilanBTN_Click(object sender, EventArgs e)
        {
            ZorlukSecimi zorlukSecimi = new ZorlukSecimi();
            if (zorlukSecimi.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Zorluk seçilmeden oyun başlatılamaz.");
                return;
            }

            string secilenZorluk = zorlukSecimi.SecilenZorluk;

            this.Hide();
            YilanOyunu yilanOyunu = new YilanOyunu(kulId, secilenZorluk);
            yilanOyunu.ShowDialog();
            this.Show();
        }


        private void adamAsmacaBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdamAsmaca adamAsmaca = new AdamAsmaca(kulId, kulAd);
            adamAsmaca.ShowDialog();
            this.Show();
        }

        private void labirentBTN_Click(object sender, EventArgs e)
        {
            var zorlukSecimFormu = new ZorlukSecimi();
            if (zorlukSecimFormu.ShowDialog() == DialogResult.OK)
            {
                Zorluk zorluk = Zorluk.Kolay; 

                switch (zorlukSecimFormu.SecilenZorluk)
                {
                    case "Orta":
                        zorluk = Zorluk.Orta;
                        break;
                    case "Zor":
                        zorluk = Zorluk.Zor;
                        break;
                    case "Kolay":
                    default:
                        zorluk = Zorluk.Kolay;
                        break;
                }

                this.Hide();
                LabirentOyunu labirentOyunu = new LabirentOyunu(kulId, kulAd,zorluk);
                labirentOyunu.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Zorluk seçilmedi. Oyun kapatılıyor.");
            }
            
        }

        private void hafizaOyunuBTN_Click(object sender, EventArgs e)
        {
            var zorlukSecimFormu = new ZorlukSecimi();
            if (zorlukSecimFormu.ShowDialog() == DialogResult.OK)
            {
                OyunSeviye seviye;

                switch (zorlukSecimFormu.SecilenZorluk)
                {
                    case "Orta":
                        seviye = new OrtaSeviye();
                        break;
                    case "Zor":
                        seviye = new ZorSeviye();
                        break;
                    case "Kolay":
                    default:
                        seviye = new KolaySeviye();
                        break;
                }

                this.Hide();
                HafizaOyunu hafizaOyunu = new HafizaOyunu(kulId,kulAd,seviye);
                hafizaOyunu.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Zorluk seçilmedi. Oyun kapatılıyor.");
            }
        }

        private void ziplayanTopBTN_Click(object sender, EventArgs e)
        {
            var zorlukSecimFormu = new ZorlukSecimi();
            if (zorlukSecimFormu.ShowDialog() == DialogResult.OK)
            {
                OyunSeviye seviye;

                switch (zorlukSecimFormu.SecilenZorluk)
                {
                    case "Orta":
                        seviye = new OrtaSeviye();
                        break;
                    case "Zor":
                        seviye = new ZorSeviye();
                        break;
                    case "Kolay":
                    default:
                        seviye = new KolaySeviye();
                        break;
                }

                this.Hide();

                ZiplayanTop ziplayanTop = new ZiplayanTop(kulId,kulAd, zorlukSecimFormu.SecilenZorluk);
                ziplayanTop.ShowDialog();

                this.Show();
            }
            else
            {
                MessageBox.Show("Zorluk seçilmedi. Oyun kapatılıyor.");
            }
        }
        private void puanimiGor_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand("SELECT toplamPuan FROM Puanlar WHERE kullaniciId=@kId", conn);
                    cmd.Parameters.AddWithValue("@kId", kulId);

                    object result = cmd.ExecuteScalar();
                    int toplamPuan = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    MessageBox.Show($"{kulAd} kullanıcısına ait toplam puan: {toplamPuan}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex);
            }
        }

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void liderlikBTN_Click(object sender, EventArgs e)
        {
            LiderlikTablosu liderlikTablosu = new LiderlikTablosu();
            liderlikTablosu.Show();
        }

        private void oyunBazliBTN_Click(object sender, EventArgs e)
        {
            OyunBazliTablo oyunBazliTablo = new OyunBazliTablo(kulId);
            oyunBazliTablo.Show();
        }
    }
}
