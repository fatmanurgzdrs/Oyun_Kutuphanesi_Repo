using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace oyunKutuphanesi047
{
    public partial class ZiplayanTop : Form
    {
        private PictureBox pbTop;
        private PictureBox pbPlatform;
        private Timer timer;
        private Top top;
        private Platform platform;
        private int kullaniciId;
        private string kullaniciAdi;
        private string zorlukSeviye;
        private int puan = 0;
        private int puanArtisi = 0;
        private int artis = 0;
        private int kacTaneTik = 0;

        public ZiplayanTop(int KullaniciId, string KullaniciAdi, string zorluk)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(400, 400);
            this.Text = "Ziplayan Top Oyunu";
            this.BackColor = Color.MistyRose;
            this.FormBorderStyle = FormBorderStyle.None;
            this.zorlukSeviye = zorluk.ToString();
            this.kullaniciAdi = KullaniciAdi;
            this.kullaniciId = KullaniciId;

            pbTop = new PictureBox();
            pbTop.BackColor = Color.SaddleBrown;
            pbTop.Size = new Size(20, 20);
            pbTop.Location = new Point(100, 100);
            this.Controls.Add(pbTop);

            pbPlatform = new PictureBox();
            pbPlatform.BackColor = Color.BurlyWood;
            pbPlatform.Size = new Size(120, 20);
            pbPlatform.Location = new Point(90, 350);
            this.Controls.Add(pbPlatform);

            platform = new Platform(pbPlatform);
            switch (zorlukSeviye)
            {
                case "Kolay":
                    top = new Top(pbTop, 5);
                    break;
                case "Orta":
                    top = new Top(pbTop, 6);
                    break;
                case "Zor":
                    top = new Top(pbTop, 7);
                    break;
            }

            timer = new Timer();
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();

            this.MouseMove += ZiplayanTop_MouseMove;
        }

        private void ZiplayanTop_MouseMove(object sender, MouseEventArgs e)
        {
            platform.HareketEt(e.X, this.ClientSize.Width);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {           
            top.HareketEt();

            if (top.Alan.Left <= 0 || top.Alan.Right >= this.ClientSize.Width)
                top.TersYondeGitX();

            if (top.Alan.Top <= 0)
                top.TersYondeGitY();

            if (top.Alan.IntersectsWith(platform.Alan))
            {
                top.TersYondeGitY();

                switch (zorlukSeviye)
                {
                    case "Kolay":
                        artis = 1;
                        puanArtisi = 10;
                        kacTaneTik += 1;
                        break;
                    case "Orta":
                        artis = 2;
                        puanArtisi = 20;
                        kacTaneTik += 1;
                        break;
                    case "Zor":
                        artis = 3;
                        puanArtisi = 30;
                        kacTaneTik += 1;
                        break;
                }
                top.Hizlan(artis);
            }

            if (top.Alan.Top > this.ClientSize.Height)
            {
                timer.Stop();
                MessageBox.Show("Oyun bitti!");
                PuanKaydet();
                this.Close();
            }
        }

        private void PuanKaydet()
        {
            puan = puanArtisi*kacTaneTik;
            try
            {
                string query = @"
            IF EXISTS (SELECT * FROM Puanlar WHERE kullaniciId = @kullaniciId)
                UPDATE Puanlar SET ziplayanTop = ziplayanTop + @puan WHERE kullaniciId = @kullaniciId
            ELSE
                INSERT INTO Puanlar (kullaniciId, ziplayanTop) VALUES (@kullaniciId, @puan)";

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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timer.Stop();
            base.OnFormClosing(e);
        }

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }
    }
}