using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Conti.Massimiliano._5I.Briscola
{
    class Carta
    {
        public string Seme { get; set; }
        public int Valore { get; set; }
        public bool Usata { get; set; }

        public int punti { get; set; }

        public BitmapImage percorso { get; set; }


        public Carta()
        {
            Seme = "";
            Valore = 0;
            punti = 0;
            percorso = null;
        }
        public Carta(string sm, int vl)
        {
            Seme = sm;
            Valore = vl;

            if (vl == 1)
                punti = 11;
            else
            {
                if (vl == 3)
                    punti = 10;
                else
                {
                    if (vl == 10)
                        punti = 4;
                    else
                    {
                        if (vl == 9)
                            punti = 3;
                        else
                        {
                            if (vl == 8)
                                punti = 2;
                            else
                                punti = 0;
                        }
                    }
                }
            }

            string imgCard = "/Immagini/" + Seme + " (" + Valore.ToString() + ").png";
            //pack://siteoforigin:,,,
            percorso = new BitmapImage(new Uri(imgCard, UriKind.Relative));
        }
    }
}
