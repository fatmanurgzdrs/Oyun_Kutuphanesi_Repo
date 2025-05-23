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
    public partial class LiderlikTablosu : Form
    {
        public LiderlikTablosu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LiderlikTablosu_Load(object sender, EventArgs e)
        {
            try
            {
                string query = @"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY p.toplamPuan DESC) AS Sıra,
                        k.kullaniciAdi, 
                        p.toplamPuan AS Puan
                    FROM Puanlar p
                    INNER JOIN Kullanicilar k ON k.kullaniciId = p.kullaniciId";

                using (var connection = DbHelper.Baglanti())
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                dataGridView1.Columns[0].HeaderText = "Sıra";
                dataGridView1.Columns[1].HeaderText = "Kullanıcı Adı";
                dataGridView1.Columns[2].HeaderText = "Puan";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liderlik tablosu yüklenemedi: " + ex.Message);
            }
        }
    }
}
