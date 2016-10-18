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
        
        public string imgCard { get; set; }

        public BitmapImage percorso { get; set; }
        

        public Carta(string sm, int vl)
        {
            Seme = sm;
            Valore = vl;

            imgCard = "/Immagini/" + Seme + " (" + Valore.ToString() + ").png";
            //pack://siteoforigin:,,,
            percorso = new BitmapImage(new Uri(imgCard, UriKind.Relative));
        }
    }
}
