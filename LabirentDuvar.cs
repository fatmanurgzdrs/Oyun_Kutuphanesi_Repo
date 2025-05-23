using System.Drawing;

public class LabirentDuvar
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Genislik { get; set; }
    public int Yukseklik { get; set; }

    public Rectangle Konum
    {
        get
        {
            return new Rectangle(X, Y, Genislik, Yukseklik);
        }
    }

    public LabirentDuvar(int x, int y, int genislik, int yukseklik)
    {
        X = x;
        Y = y;
        Genislik = genislik;
        Yukseklik = yukseklik;
    }
}
