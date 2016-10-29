using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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
        public BitmapImage PercorsoVuoto { get; set; }

        public bool GiocaGiocatore { get; set; }



        public Briscola()
        {
            Mazzo1 = new Mazzo();
            Ut1 = new Utente(Mazzo1.GetCartaIniziale());
            CPU = new Utente(Mazzo1.GetCartaIniziale());

            C1 = new Carta();
            C2 = new Carta();

            GetBriscola();

            PercorsoVuoto = new BitmapImage(new Uri("/Immagini/retro.png", UriKind.Relative));

            GiocaGiocatore = true;
            return;
        }

        public void GetBriscola()
        {
            CardBriscola = Mazzo1.GetCarta();
            return;
        }

        public void SetCentro1(int nCarta)
        {
            BitmapImage perc = Ut1.MieCarte[nCarta].percorso;

            C1 = Ut1.MieCarte[nCarta];

            Ut1.MieCarte.RemoveAt(nCarta);
            Ut1.MieCarte.Add(new Carta());

            C1.percorso = perc;

            //switch (nCarta)
            //{
            //    case 0:
            //        Ut1.MieCarte.RemoveAt(nCarta);
            //        C1.percorso = perc;
            //        break;
            //    case 1:
            //        Ut1.MieCarte[1].percorso = null;
            //        C1.percorso = perc;
            //        break;
            //    case 2:
            //        Ut1.MieCarte[2].percorso = null;
            //        C1.percorso = perc;
            //        break;
            //    default:
            //        break;
            //}
        }

        public Carta GetCentro2()
        {
            Carta ret = null;

            Random rnd = new Random();
            int n = rnd.Next(0, 2);
            ret = CPU.MieCarte[n];
            CPU.MieCarte.RemoveAt(n);
            CPU.MieCarte.Add(new Carta());


            return ret;
        }

        public void Continua()
        {
            if (GiocaGiocatore && C1.Seme == "")
                return;

            if (GiocaGiocatore && C1.Seme != "")
            {
                C2 = GetCentro2();
                return;
            }

            if (C2.Seme == "")
            {
                C2 = GetCentro2();
                return;
            }
            if (C2.Seme != "" && C1.Seme != "")
            {
                return;
            }

            return;
        }

        private bool Confronto()
        {
            if (C1.Seme == CardBriscola.Seme && C2.Seme != CardBriscola.Seme) //io butto briscola
                return true;

            if (C1.Seme != CardBriscola.Seme && C2.Seme == CardBriscola.Seme) //cpu butta briscola
                return false;

            if (C1.Seme == CardBriscola.Seme && C2.Seme == CardBriscola.Seme) //Entrambi Briscole
                return CartaVSCarta();

            if (C1.Seme != CardBriscola.Seme && C2.Seme != CardBriscola.Seme) //No Briscole
                return CartaVSCarta();



            return false;

        }
        public int DopoConfronto()
        {
            bool iovinco = Confronto();
            C1 = new Carta();
            C2 = new Carta();

            Ut1.MieCarte[2]=Mazzo1.GetCarta();
            CPU.MieCarte[2]=Mazzo1.GetCarta();

            if (iovinco)
            {
                GiocaGiocatore = true;
                Ut1.Punteggio += C1.punti + C2.punti;
                return 1;
            }
            else
            {
                GiocaGiocatore = false;
                CPU.Punteggio += C1.punti + C2.punti;
                return 2;
            }
        }

        private bool CartaVSCarta()
        {
            if (C1.punti == C2.punti)
                if (GiocaGiocatore)
                    return true;

            if (C1.punti > C2.punti)
                return true;

            return false;
        }
    }
}
