using System.Collections.Generic;
using System.Drawing;

public abstract class yilanYilan
{
    public List<Point> Parcalar = new List<Point>();
    public Direction Yonu = Direction.Sag;
    public int Hiz { get; protected set; }

    public yilanYilan()
    {
        Parcalar.Add(new Point(10, 10));
    }

    public virtual void HareketEt()
    {
        for (int i = Parcalar.Count - 1; i > 0; i--)
            Parcalar[i] = Parcalar[i - 1];

        Point bas = Parcalar[0];
        switch (Yonu)
        {
            case Direction.Sag: bas.X += 1; break;
            case Direction.Sol: bas.X -= 1; break;
            case Direction.Yukari: bas.Y -= 1; break;
            case Direction.Asagi: bas.Y += 1; break;
        }
        Parcalar[0] = bas;
    }

    public virtual void Buyu()
    {
        Parcalar.Add(Parcalar[Parcalar.Count - 1]);
    }
}

public class YavasYilan : yilanYilan
{
    public YavasYilan() { Hiz = 200; }
}

public class OrtaYilan : yilanYilan
{
    public OrtaYilan() { Hiz = 150; }
}

public class HizliYilan : yilanYilan
{
    public HizliYilan() { Hiz = 100; }
}
