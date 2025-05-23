using System;
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
    public partial class YilanOyunu : Form
    {
        private yilanOyunAlani oyun;
        private Timer timer = new Timer();
        private int puan = 0;
        private int puanArtisi = 0;
        private int kullaniciId;
        private string zorlukSecim1;

        public YilanOyunu(int KullaniciId, string zorlukSecim)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(600, 400);
            this.Size = new Size(620, 440);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.KeyDown += YilanOyunu_KeyDown;
            this.kullaniciId = KullaniciId;
            this.zorlukSecim1 = zorlukSecim;

            yilanYilan yilanTuru = new YavasYilan();
            
            switch (zorlukSecim)
            {
                case "Kolay":

                    yilanTuru = new YavasYilan();
                    puanArtisi = 3;
                    break;
                case "Orta":

                    yilanTuru = new OrtaYilan();
                    puanArtisi = 5;
                    break;
                case "Zor":

                    yilanTuru = new HizliYilan();
                    puanArtisi = 10;
                    break;
                default:
                    MessageBox.Show("Hata");

                    return;
            }

            oyun = new yilanOyunAlani(30, 20, yilanTuru);
            timer.Interval = yilanTuru.Hiz;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            oyun.yilan.HareketEt();

            if (oyun.CarpismaVarMi())
            {
                timer.Stop();
                MessageBox.Show($"Oyun Bitti!\nToplam Puan: {puan}");
                PuanKaydet();
            }

            if (oyun.YemekYendiMi())
            {
                oyun.yilan.Buyu();
                puan += puanArtisi;
                oyun.yemek.YeniYemek(oyun.Genislik, oyun.Yukseklik);
            }

            Invalidate();
        }

        private void YilanOyunu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    oyun.yilan.Yonu = Direction.Yukari;
                    break;

                case Keys.Down:
                case Keys.S:
                    oyun.yilan.Yonu = Direction.Asagi;
                    break;

                case Keys.Left:
                case Keys.A:
                    oyun.yilan.Yonu = Direction.Sol;
                    break;

                case Keys.Right:
                case Keys.D:
                    oyun.yilan.Yonu = Direction.Sag;
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var parca in oyun.yilan.Parcalar)
                g.FillRectangle(Brushes.Purple, parca.X * 20, parca.Y * 20, 20, 20);

            g.FillEllipse(Brushes.HotPink, oyun.yemek.Konum.X * 20, oyun.yemek.Konum.Y * 20, 20, 20);
        }

        
        private void PuanKaydet()
        {
            try
            {
                string query = @"
            IF EXISTS (SELECT * FROM Puanlar WHERE kullaniciId = @kullaniciId)
                UPDATE Puanlar SET yilanOyunu = yilanOyunu + @puan WHERE kullaniciId = @kullaniciId
            ELSE
                INSERT INTO Puanlar (kullaniciId, yilanOyunu) VALUES (@kullaniciId, @puan)";

                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@puan", puan);
                    cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Puan kaydedildi. Eklenilen puan: "+puan);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Puan kaydedilemedi: " + ex.Message);
            }
            this.Close();
            
        }

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timer.Stop();
            base.OnFormClosing(e);
        }

    }

}


