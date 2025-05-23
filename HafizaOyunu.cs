using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace oyunKutuphanesi047
{
    public partial class HafizaOyunu : Form
    {
        OyunSeviye seviye;
        List<Kart> kartlar;
        Kart secili1 = null;
        Kart secili2 = null;
        Timer eslestirmeZamanlayici;
        private int kullaniciId;
        private string kullaniciAd;

        public HafizaOyunu(int KullaniciId, string KullaniciAd, OyunSeviye zorluk)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.seviye = zorluk;
            this.Load += HafizaOyunu_Load;
            this.Text = "Kart Eslestirme Oyunu";
            this.kullaniciAd = KullaniciAd;
            this.kullaniciId = KullaniciId;
        }

        private void HafizaOyunu_Load(object sender, EventArgs e)
        {
            kartlariOlustur();
            int kartGenisligi = 70;
            int kartYuksekligi = 70;
            int bosluk = 10;
            int yatayBosluk = 40;

            int genislik = (seviye.sutunSayisi() * (kartGenisligi + bosluk)) - bosluk + 2 * yatayBosluk;
            int yukseklik = (seviye.satirSayisi() * (kartYuksekligi + bosluk)) - bosluk + 2 * yatayBosluk;

            this.ClientSize = new Size(genislik, yukseklik);
        }

        void kartlariOlustur()
        {
            kartlar = new List<Kart>();
            List<string> simgeler = seviye.simgeListesi();
            int satir = seviye.satirSayisi();
            int sutun = seviye.sutunSayisi();
            int index = 0;

            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    if (index >= simgeler.Count) break;
                    Kart kart = new Kart(simgeler[index]);
                    kart.Location = new Point(40 + j * 80, 40 + i * 80);
                    kart.Click += kart_Click;
                    this.Controls.Add(kart);
                    kartlar.Add(kart);
                    index++;
                }
            }

            int kartGenisligi = 70;
            int kartYuksekligi = 70;
            int bosluk = 10;
            int yatayBosluk = 40;

            int genislik = (sutun * (kartGenisligi + bosluk)) - bosluk + 2 * yatayBosluk;
            int yukseklik = (satir * (kartYuksekligi + bosluk)) - bosluk + 2 * yatayBosluk;

            this.ClientSize = new Size(genislik, yukseklik);

            eslestirmeZamanlayici = new Timer();
            eslestirmeZamanlayici.Interval = 1000;
            eslestirmeZamanlayici.Tick += eslestirmeZamanlayici_Tick;
        }

        void kart_Click(object sender, EventArgs e)
        {
            Kart tiklanan = sender as Kart;
            if (tiklanan.Acik || eslestirmeZamanlayici.Enabled) return;

            tiklanan.kartiAc();

            if (secili1 == null)
            {
                secili1 = tiklanan;
            }
            else if (secili2 == null)
            {
                secili2 = tiklanan;

                if (secili1.Simge == secili2.Simge)
                {
                    secili1.Enabled = false;
                    secili2.Enabled = false;
                    secili1 = null;
                    secili2 = null;

                    if (kartlar.All(k => !k.Enabled))
                    {
                        MessageBox.Show("Tebrikler! Tum kartlari eslestirdin.");
                        PuanKaydet();
                    }
                }
                else
                {
                    eslestirmeZamanlayici.Start();
                }
            }
        }

        void eslestirmeZamanlayici_Tick(object sender, EventArgs e)
        {
            eslestirmeZamanlayici.Stop();
            secili1.kartiKapat();
            secili2.kartiKapat();
            secili1 = null;
            secili2 = null;
        }

        private void PuanKaydet()
        {
            try
            {
                int eklenenPuan = 0;
                // seviye nesnen varsa onun türüne göre puan belirle
                if (seviye is KolaySeviye)
                    eklenenPuan = 50;
                else if (seviye is OrtaSeviye)
                    eklenenPuan = 100;
                else if (seviye is ZorSeviye)
                    eklenenPuan = 150;
                else
                    eklenenPuan = 50; // varsayılan kolay

                string query = @"
                    IF EXISTS (SELECT * FROM Puanlar WHERE kullaniciId = @kullaniciId)
                    UPDATE Puanlar SET hafizaOyunu = hafizaOyunu + @puan WHERE kullaniciId = @kullaniciId
                    ELSE
                    INSERT INTO Puanlar (kullaniciId, hafizaOyunu) VALUES (@kullaniciId, @puan)";

                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@puan", eklenenPuan);
                    cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Puan kaydedildi. Eklenen puan: " + eklenenPuan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puan kaydedilemedi: " + ex.Message);
            }
            this.Close();
        }

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }



    public class Kart : Button
    {
        public string Simge { get; private set; }
        public bool Acik { get; private set; } = false;

        public Kart(string simge)
        {
            this.Simge = simge;
            this.Text = "";
            this.Size = new Size(70, 70);
            this.Font = new Font("Arial", 16, FontStyle.Bold);
        }

        public void kartiAc()
        {
            this.Text = Simge;
            Acik = true;
        }

        public void kartiKapat()
        {
            this.Text = "";
            Acik = false;
        }
    }

    public abstract class OyunSeviye
    {
        public abstract List<string> simgeListesi();
        public abstract int satirSayisi();
        public abstract int sutunSayisi();
    }

    public class KolaySeviye : OyunSeviye
    {
        public override List<string> simgeListesi()
        {
            List<string> simgeler = new List<string> { "1", "2", "3", "4", "5", "6" };
            simgeler.AddRange(simgeler);
            return karistir(simgeler);
        }

        public override int satirSayisi() => 3;
        public override int sutunSayisi() => 4;

        List<string> karistir(List<string> liste)
        {
            Random r = new Random();
            return liste.OrderBy(x => r.Next()).ToList();
        }
    }

    public class OrtaSeviye : OyunSeviye
    {
        public override List<string> simgeListesi()
        {
            List<string> simgeler = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8" };
            simgeler.AddRange(simgeler);
            return karistir(simgeler);
        }

        public override int satirSayisi() => 4;
        public override int sutunSayisi() => 4;

        List<string> karistir(List<string> liste)
        {
            Random r = new Random();
            return liste.OrderBy(x => r.Next()).ToList();
        }
    }

    public class ZorSeviye : OyunSeviye
    {
        public override List<string> simgeListesi()
        {
            List<string> simgeler = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            simgeler.AddRange(simgeler);
            return karistir(simgeler);
        }

        public override int satirSayisi() => 5;
        public override int sutunSayisi() => 4;

        List<string> karistir(List<string> liste)
        {
            Random r = new Random();
            return liste.OrderBy(x => r.Next()).ToList();
        }
    }
}
