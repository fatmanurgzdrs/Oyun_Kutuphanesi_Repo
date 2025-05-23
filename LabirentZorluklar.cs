using oyunKutuphanesi047;
using System.Collections.Generic;
using System.Drawing;

public enum Zorluk
{
    Kolay,
    Orta,
    Zor
}

public class LabirentKolay : LabirentAbstract
{
    public override void Baslat()
    {
        LabirentDuvarlar = new List<LabirentDuvar>();
        LabirentOyuncu = new LabirentOyuncu(20, 20, 20);
        Cikis = new Rectangle(500, 400, 20, 20);


        DuvarlariResimdenYukle("Resources/kolayLabirent.png","Kolay");
    }
}

public class LabirentOrta : LabirentAbstract
{
    public override void Baslat()
    {
        LabirentDuvarlar = new List<LabirentDuvar>();
        LabirentOyuncu = new LabirentOyuncu(20, 20, 20);
        Cikis = new Rectangle(500, 400, 20, 20);

        DuvarlariResimdenYukle("Resources/ortaLabirent.png","Orta");
    }
}

public class LabirentZor : LabirentAbstract
{
    public override void Baslat()
    {
        LabirentDuvarlar = new List<LabirentDuvar>();
        LabirentOyuncu = new LabirentOyuncu(20, 20, 20);
        Cikis = new Rectangle(500, 400, 20, 20);

        DuvarlariResimdenYukle("Resources/zorLabirent.png","Zor");
    }
}

