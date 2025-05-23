using System.Drawing;

public class yilanOyunAlani
{
    public int Genislik;
    public int Yukseklik;
    public yilanYilan yilan;
    public yilanYemek yemek;

    public yilanOyunAlani(int genislik, int yukseklik, yilanYilan yilanTuru)
    {
        Genislik = genislik;
        Yukseklik = yukseklik;
        yilan = yilanTuru;
        yemek = new yilanYemek();
        yemek.YeniYemek(genislik, yukseklik);
    }

    public bool CarpismaVarMi()
    {
        Point bas = yilan.Parcalar[0];

        if (bas.X < 0 || bas.X >= Genislik || bas.Y < 0 || bas.Y >= Yukseklik)
            return true;

        for (int i = 1; i < yilan.Parcalar.Count; i++)
        {
            if (yilan.Parcalar[i] == bas)
                return true;
        }

        return false;
    }

    public bool YemekYendiMi()
    {
        return yilan.Parcalar[0] == yemek.Konum;
    }
}
