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
        public BitmapImage PercorsoMazzo { get; set; }



        private bool GiocaGiocatore { get; set; }
        private bool UltimoTurno { get; set; }
        private int NUltimoTurno { get; set; }



        public Briscola()
        {
            Mazzo1 = new Mazzo();
            Ut1 = new Utente(Mazzo1.GetCartaIniziale());
            CPU = new Utente(Mazzo1.GetCartaIniziale());

            C1 = new Carta();
            C2 = new Carta();

            GetBriscola();

            PercorsoVuoto = new BitmapImage(new Uri("/Immagini/retro.png", UriKind.Relative));
            PercorsoMazzo = PercorsoVuoto;

            GiocaGiocatore = true;

            //AzzeraSfondoCPU();
            return;
        }

        public void GetBriscola()
        {
            CardBriscola = Mazzo1.GetCarta();
            return;
        }

        //private void AzzeraSfondoCPU()
        //{
        //    if (CPU.MieCarte[0].percorso != null)
        //        CPU.MieCarte[0].percorso = PercorsoVuoto;

        //    if (CPU.MieCarte[1].percorso != null)
        //        CPU.MieCarte[1].percorso = PercorsoVuoto;

        //    if (CPU.MieCarte[2].percorso != null)
        //        CPU.MieCarte[2].percorso = PercorsoVuoto;
        //}

        public void SetCentro1(int nCarta)
        {
            BitmapImage perc = Ut1.MieCarte[nCarta].percorso;

            C1 = Ut1.MieCarte[nCarta];

            Ut1.MieCarte.RemoveAt(nCarta);
            Ut1.addCarta(new Carta());

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
            CPU.addCarta(new Carta());


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
            int PuntiTurno = C1.Valore + C2.Valore;
            int ret = 0;

            C1 = new Carta();
            C2 = new Carta();

            //Controlla quando si arriva al turno in cui si pesca la briscola e l'ultima carta
            if (Mazzo1.NCarteRimaste > 1)
            {
                Ut1.MieCarte[2] = Mazzo1.GetCarta();
                CPU.MieCarte[2] = Mazzo1.GetCarta();
            }
            else
            {
                UltimoTurno = true;
                NUltimoTurno++;
            }

            //assegna la briscola al vincitore della precedente mano
            if (NUltimoTurno == 1)
            {
                if (iovinco)
                {
                    Ut1.MieCarte[2] = new Carta(CardBriscola.Seme, CardBriscola.Numero);
                    CPU.MieCarte[2] = Mazzo1.GetCarta();
                }
                else
                {
                    CPU.MieCarte[2] = new Carta(CardBriscola.Seme, CardBriscola.Numero);
                    Ut1.MieCarte[2] = Mazzo1.GetCarta();
                }
                CardBriscola.percorso = null;
                PercorsoMazzo = null;

                
            }

            //fa si di fare gli ultimi 3 turni senza errori
            if (NUltimoTurno > 2)
            {
                for (int i = 0; i < 2; i++)
                    if (CPU.MieCarte[i].Seme == "")
                    {
                        CPU.MieCarte.RemoveAt(i);
                        CPU.addCarta(new Carta());
                    }

                for (int i = 0; i < 2; i++)
                    if (Ut1.MieCarte[i].Seme == "")
                    {
                        Ut1.MieCarte.RemoveAt(i);
                        Ut1.addCarta(new Carta());
                    }

                //if (iovinco)
                //    Ut1.MieCarte[2].percorso = perc;
                //else
                //    CPU.MieCarte[2].percorso = perc;
            }

            //AzzeraSfondoCPU();

            if (iovinco)
            {
                GiocaGiocatore = true;
                Ut1.Punteggio += PuntiTurno;
                ret = 1;
            }
            else
            {
                GiocaGiocatore = false;
                CPU.Punteggio += PuntiTurno;
                ret = 2;
            }

            if (NUltimoTurno > 3)
            {
                ret += 2;
            }

            return ret;
        }

        private bool CartaVSCarta()
        {
            string semeTemp = "";

            if (GiocaGiocatore)
                semeTemp = C1.Seme;
            else
                semeTemp = C2.Seme;

            if (GiocaGiocatore && C2.Seme != semeTemp)
                return true;

            if (C1.Valore == C2.Valore)
                if (GiocaGiocatore)
                    return true;

            if (C1.Valore > C2.Valore)
                return true;

            return false;
        }
    }
}
