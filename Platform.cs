using System.Drawing;
using System.Windows.Forms;

namespace oyunKutuphanesi047
{
    public class Platform
    {
        private PictureBox pbPlatform;

        public Platform(PictureBox pb)
        {
            pbPlatform = pb;
        }

        public void HareketEt(int yeniPozisyonX, int formGenisligi)
        {
            int yeniSol = yeniPozisyonX - pbPlatform.Width / 2;
            if (yeniSol < 0) yeniSol = 0;
            if (yeniSol > formGenisligi - pbPlatform.Width) yeniSol = formGenisligi - pbPlatform.Width;
            pbPlatform.Left = yeniSol;
        }

        public Rectangle Alan => pbPlatform.Bounds;
    }
}
