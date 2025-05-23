using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oyunKutuphanesi047
{
    public partial class GirisYap: Form
    {
        public GirisYap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void girisYapBTN_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kAdiTxtBox.Text)&& !string.IsNullOrEmpty(sifreTxtBox.Text))
            {
                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanicilar WHERE kullaniciAdi=@kAdi AND sifre=@sifre", conn);
                    cmd.Parameters.AddWithValue("@kAdi", kAdiTxtBox.Text);
                    cmd.Parameters.AddWithValue("@sifre", sifreTxtBox.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        int kullaniciId = Convert.ToInt32(dr["kullaniciId"]);
                        string kullaniciAd = dr["kullaniciAdi"].ToString();
                        if (kullaniciAd == "admin")
                        {
                            

                        }
                        else
                        {
                            OyunSecimi oyunSecimi = new OyunSecimi(kullaniciId, kullaniciAd);
                            oyunSecimi.Show();
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı kullanıcı adı veya şifre.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Hata: Kullanıcı adı veya şifre boş olamaz.");
            }
        }

        private void kaydolBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            KayitYap kayitYap = new KayitYap();
            kayitYap.Show();
        }

        private void cikisBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
