using System.Drawing;
using System.Windows.Forms;

public class LabirentOyuncu
{
    public Rectangle Konum { get; private set; }
    private int Hiz;

    public LabirentOyuncu(int x, int y, int boyut)
    {
        Konum = new Rectangle(x, y, boyut, boyut);
        Hiz = boyut;
    }

    public void HareketEt(Keys tus)
    {
        switch (tus)
        {
            case Keys.Up:
                Konum = new Rectangle(Konum.X, Konum.Y - Hiz, Konum.Width, Konum.Height);
                break;
            case Keys.Down:
                Konum = new Rectangle(Konum.X, Konum.Y + Hiz, Konum.Width, Konum.Height);
                break;
            case Keys.Left:
                Konum = new Rectangle(Konum.X - Hiz, Konum.Y, Konum.Width, Konum.Height);
                break;
            case Keys.Right:
                Konum = new Rectangle(Konum.X + Hiz, Konum.Y, Konum.Width, Konum.Height);
                break;
        }
    }
}
