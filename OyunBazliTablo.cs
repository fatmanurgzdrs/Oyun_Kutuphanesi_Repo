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
    public partial class OyunBazliTablo : Form
    {
        private int kulId;
        public OyunBazliTablo(int kullaniciId)
        {
            InitializeComponent();
            this.kulId = kullaniciId;
            goster(kulId);
        }

        private void goster(int KullaniciId)
        {

            try
            {
                using (SqlConnection conn = DbHelper.Baglanti())
                {
                    string query = "SELECT yilanOyunu, adamAsmaca, labirent, hafizaOyunu, ziplayanTop FROM Puanlar WHERE kullaniciId=@kId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kId", KullaniciId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].HeaderText = "Yılan Oyunu";
                    dataGridView1.Columns[1].HeaderText = "Adam Asmaca";
                    dataGridView1.Columns[2].HeaderText = "Labirent";
                    dataGridView1.Columns[3].HeaderText = "Hafıza Oyunu";
                    dataGridView1.Columns[4].HeaderText = "Zıplayan Top";
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex);
            }
        }
    }
}
