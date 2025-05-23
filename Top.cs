using System.Drawing;
using System.Windows.Forms;

public class Top
{
    private int hizX;
    private int hizY;
    private PictureBox pbTop;

    public Top(PictureBox pb, int baslangicHizi)
    {
        pbTop = pb;
        hizX = baslangicHizi;
        hizY = -baslangicHizi;
    }

    public void HareketEt()
    {
        pbTop.Left += hizX;
        pbTop.Top += hizY;
    }

    public void TersYondeGitX()
    {
        hizX = -hizX;
    }

    public void TersYondeGitY()
    {
        hizY = -hizY;
    }

    public void Hizlan(int artis)
    {
        hizX += (hizX > 0) ? artis : -artis;
        hizY += (hizY > 0) ? artis : -artis;
    }

    public Rectangle Alan => pbTop.Bounds;
}