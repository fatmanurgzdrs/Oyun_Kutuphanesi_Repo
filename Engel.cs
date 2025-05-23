using System;
using System.Drawing;
using System.Windows.Forms;

namespace oyunKutuphanesi047
{
    public abstract class Engel
    {
        protected PictureBox pbEngel;

        public Engel(PictureBox pb)
        {
            pbEngel = pb;
        }

        public Rectangle Alan => pbEngel.Bounds;

        public abstract void CarpmaDavranisi(Top top);


    }

    public class SertEngel : Engel
    {
        private readonly Action zorlukTepkisi;

        public SertEngel(PictureBox pb, Action zorlukTepkisi) : base(pb)
        {
            this.zorlukTepkisi = zorlukTepkisi;
        }

        public override void CarpmaDavranisi(Top top)
        {
            top.TersYondeGitY();
            zorlukTepkisi?.Invoke();
        }
    }
}
