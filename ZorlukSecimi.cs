using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oyunKutuphanesi047
{
    public partial class ZorlukSecimi : Form
    {
        public string SecilenZorluk { get; private set; }

        public ZorlukSecimi()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void kolayBTN_Click(object sender, EventArgs e)
        {
            SecilenZorluk = "Kolay";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ortaBTN_Click(object sender, EventArgs e)
        {
            SecilenZorluk = "Orta";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void zorBTN_Click(object sender, EventArgs e)
        {
            SecilenZorluk = "Zor";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
