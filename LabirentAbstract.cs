using oyunKutuphanesi047;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public abstract class LabirentAbstract 
{
    public List<LabirentDuvar> LabirentDuvarlar { get; protected set; } = new List<LabirentDuvar>();
    public LabirentOyuncu LabirentOyuncu { get; protected set; }
    public Rectangle Cikis { get; protected set; }
    public Size LabirentBoyutu { get; protected set; }

    public abstract void Baslat();

    public void DuvarlariResimdenYukle(string dosyaYolu, string Derecesi)
    {
        try
        {
            Bitmap bmp = new Bitmap(dosyaYolu);
            LabirentBoyutu = new Size(bmp.Width, bmp.Height);

            List<Color> duvarRenkleri = new List<Color>
            {
            Color.FromArgb(0x00, 0x00, 0x00),
            };

            Color oyuncuRenk = Color.Blue;
            Color cikisRenk = Color.Lime;

            LabirentDuvarlar.Clear();
            LabirentOyuncu = null;
            Cikis = Rectangle.Empty;

            int duvarBoyut, taramaAlani;
            zorlugaGoreAyarla(Derecesi, out duvarBoyut, out taramaAlani);

            bool RenkEsit(Color a, Color b, int tolerance = 10)
            {
                return Math.Abs(a.R - b.R) <= tolerance &&
                       Math.Abs(a.G - b.G) <= tolerance &&
                       Math.Abs(a.B - b.B) <= tolerance;
            }

            if (Derecesi == "Kolay")
            {

                for (int y = 0; y < bmp.Height; y += duvarBoyut)
                {
                    for (int x = 0; x < bmp.Width; x += duvarBoyut)
                    {
                        bool duvarVar = false, oyuncuVar = false, cikisVar = false;

                        for (int yy = y; yy < y + taramaAlani && yy < bmp.Height; yy++)
                        {
                            for (int xx = x; xx < x + taramaAlani && xx < bmp.Width; xx++)
                            {
                                Color piksel = bmp.GetPixel(xx, yy);

                                if (duvarRenkleri.Any(r => RenkEsit(piksel, r)))
                                    duvarVar = true;
                                else if (RenkEsit(piksel, oyuncuRenk))
                                    oyuncuVar = true;
                                else if (RenkEsit(piksel, cikisRenk))
                                    cikisVar = true;

                                if (duvarVar || oyuncuVar || cikisVar)
                                    break;
                            }
                            if (duvarVar || oyuncuVar || cikisVar)
                                break;
                        }

                        if (duvarVar && !LabirentDuvarlar.Any(d => d.Konum.X == x && d.Konum.Y == y))
                        {
                            LabirentDuvarlar.Add(new LabirentDuvar(x, y, duvarBoyut, duvarBoyut));
                        }
                        else if (oyuncuVar)
                        {
                            LabirentOyuncu = new LabirentOyuncu(x, y, duvarBoyut);
                        }
                        else if (cikisVar)
                        {
                            Cikis = new Rectangle(x - 10, y - 10, duvarBoyut, duvarBoyut);
                        }
                    }
                }
            }
            else
            {
                for (int y = 0; y < bmp.Height; y += duvarBoyut)
                {
                    for (int x = 0; x < bmp.Width; x += duvarBoyut)
                    {
                        int px = Math.Min(x + duvarBoyut / 2, bmp.Width - 1);
                        int py = Math.Min(y + duvarBoyut / 2, bmp.Height - 1);
                        Color piksel = bmp.GetPixel(px, py);

                        if (duvarRenkleri.Any(r => RenkEsit(piksel, r)))
                        {
                            LabirentDuvarlar.Add(new LabirentDuvar(x, y, duvarBoyut, duvarBoyut));
                        }
                        else if (RenkEsit(piksel, oyuncuRenk))
                        {
                            var (dx, dy, oyuncuBoyut) = oyuncuBoyutunuAyarla(Derecesi);
                            LabirentOyuncu = new LabirentOyuncu(x + dx, y + dy, oyuncuBoyut-2);
                        }
                        else if (RenkEsit(piksel, cikisRenk))
                        {
                            var (cx, cy, cgen) = cikisYeriniAyarla(x, y, Derecesi);
                            Cikis = new Rectangle(cx, cy, cgen, cgen);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }
    }

    private void zorlugaGoreAyarla(string Derecesi, out int duvarBoyut, out int taramaAlani)
    {
        switch (Derecesi)
        {
            case "Kolay":
                duvarBoyut = 11;
                taramaAlani = 6;
                break;
            case "Orta":
                duvarBoyut = 5;
                taramaAlani = 4;
                break;
            case "Zor":
                duvarBoyut = 5;
                taramaAlani = 0;
                break;
            default:
                duvarBoyut = 10;
                taramaAlani = 0;
                break;
        }
    }

    private (int dx, int dy, int oyuncuBoyut) oyuncuBoyutunuAyarla(string Derecesi)
    {
        switch (Derecesi)
        {
            case "Kolay": return (0, 0, 7);
            case "Orta": return (-15, -5, 7);
            case "Zor": return (-5, -5, 7);
            default: return (0, 0, 7);
        }
    }

    private (int cx, int cy, int cgen) cikisYeriniAyarla(int x, int y, string Derecesi)
    {
        switch (Derecesi)
        {
            case "Kolay": return (x - 2, y - 2, 15);
            case "Orta": return (x - 13, y - 15, 15);
            case "Zor": return (x - 5, y - 10, 11);
            default: return (x, y, 10);
        }
    }

}
