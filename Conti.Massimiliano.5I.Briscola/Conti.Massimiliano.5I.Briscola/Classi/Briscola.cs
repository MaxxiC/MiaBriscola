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



        public Carta C1 { get; set; }
        public Carta C2 { get; set; }
        public Carta CardBriscola { get; set; }



        public Briscola()
        {
            Mazzo1 = new Mazzo();
            Ut1 = new Utente(Mazzo1.GetCartaIniziale());
            CPU = new Utente(Mazzo1.GetCartaIniziale());

            GetBriscola();
        }

        public void GetBriscola()
        {
            CardBriscola = Mazzo1.GetCarta();
            return;
        }

        public void UsaCarta(int nCarta)
        {
            C1 = Ut1.MieCarte[nCarta];

            List<Carta> nBrisc = new List<Carta>();
            if (Ut1.MieCarte[nCarta].Seme == CardBriscola.Seme)
            {
                if (CPU.MieCarte[0].Seme == CardBriscola.Seme)
                    nBrisc.Add(CPU.MieCarte[0]);
                if(CPU.MieCarte[1].Seme == CardBriscola.Seme)
                    nBrisc.Add(CPU.MieCarte[1]);
                if (CPU.MieCarte[2].Seme == CardBriscola.Seme)
                    nBrisc.Add(CPU.MieCarte[2]);


                if (nBrisc.Count == 0)
                {
                }


            }
            else
            { }
        }

        public void Continua(int nnCarta)
        {

        }
    }
}
