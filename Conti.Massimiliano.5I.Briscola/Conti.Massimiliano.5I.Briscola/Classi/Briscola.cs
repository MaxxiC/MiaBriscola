using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conti.Massimiliano._5I.Briscola
{
    class Briscola
    {
        public Mazzo Mazzo1 { get; }
        public Utente Ut1 { get; }
        public Utente CPU { get; }
        public Utente Centro { get; }
        public Carta CardBriscola { get; }
        


        public Briscola()
        {
            Mazzo1 = new Mazzo();
            Ut1 = new Utente(Mazzo1.GetCartaIniziale());
            CPU = new Utente(Mazzo1.GetCartaIniziale());
            Centro = new Utente();

            CardBriscola = Mazzo1.GetCarta();
        }

        //public void GetBriscola()
        //{
        //    Random rand = new Random();

        //    Briscola = ListMazzo[rand.Next(0, 39)];

        //    while (Briscola.Usata == true)
        //    {
        //        Briscola = ListMazzo[rand.Next(0, 39)];

        //    }
        //    Briscola.Usata = true;
        //    return;
        //}
    }
}
