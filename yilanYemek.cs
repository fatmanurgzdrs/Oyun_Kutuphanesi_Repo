using System.Drawing;
using System;

public class yilanYemek
{
    public Point Konum;
    private Random rnd = new Random();

    public void YeniYemek(int genislik, int yukseklik)
    {
        Konum = new Point(rnd.Next(0, genislik), rnd.Next(0, yukseklik));
    }
}
