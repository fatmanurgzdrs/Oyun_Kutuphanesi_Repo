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
    public partial class KayitYap : Form
    {
        public KayitYap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void kaydolBTN_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kAdiTxtBox.Text) && !string.IsNullOrEmpty(sifreTxtBox.Text))
            {
                try
                {
                    if (sifreTTxtBox.Text == sifreTxtBox.Text)
                    {
                        using (SqlConnection conn = DbHelper.Baglanti())
                        {
                            SqlCommand cmd = new SqlCommand(
                                "INSERT INTO Kullanicilar (kullaniciAdi, sifre) VALUES (@kAdi, @sifre); SELECT SCOPE_IDENTITY();", conn);
                            cmd.Parameters.AddWithValue("@kAdi", kAdiTxtBox.Text);
                            cmd.Parameters.AddWithValue("@sifre", sifreTxtBox.Text);

                            object result = cmd.ExecuteScalar();
                            int kulId = 0;
                            if (result != null)
                                kulId = Convert.ToInt32(result);

                            if (kulId > 0)
                            {
                                SqlCommand cmd2 = new SqlCommand(
                                    "INSERT INTO Puanlar (kullaniciId, yilanOyunu, adamAsmaca, labirent, hafizaOyunu, ziplayanTop, toplamPuan) VALUES (@kId,0,0,0,0,0,0)", conn);
                                cmd2.Parameters.AddWithValue("@kId", kulId);
                                cmd2.ExecuteNonQuery();

                                DialogResult dialogResult = MessageBox.Show("Kayıt başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (dialogResult == DialogResult.OK)
                                {
                                    this.Hide();
                                    GirisYap girisYap = new GirisYap();
                                    girisYap.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kayıt başarısız oldu.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hata: Şifreler eşleşmiyor.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                        MessageBox.Show("Hata: Kullanıcı zaten mevcut.");
                    else
                        MessageBox.Show("Hata:"+ex);
                }
            }
            else
            {
                MessageBox.Show("Hata: Kullanıcı adı veya şifre boş olamaz.");
            }
        }


        private void cikisBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
