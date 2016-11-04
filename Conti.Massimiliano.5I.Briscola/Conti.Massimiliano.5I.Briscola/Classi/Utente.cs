using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Conti.Massimiliano._5I.Briscola
{
    class Utente
    {
        public int Punteggio { get; set; }
        public List<Carta> MieCarte = new List<Carta>();

        public Utente()
        { }

        public Utente(List<Carta> list1)
        {
            MieCarte = list1;
        }

        public void addCarta(Carta cc)
        {
            MieCarte.Add(cc);
        }
    }
}
