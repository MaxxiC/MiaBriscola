using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Threading;
using System.Windows.Threading;

namespace Conti.Massimiliano._5I.Briscola
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private BriscolaCS Brscl;
        //public BackgroundWorker bw;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IniziaPartita();
            //bw = new BackgroundWorker();
            //bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            //bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AggiornaImmagini);
        }

        private void IniziaPartita()
        {
            Brscl = new BriscolaCS();
            lblSemeBriscola.Content = "Briscola: \n" + Brscl.CardBriscola.Seme;
            AggiornaImmagini();
            //string a = txtNomeGiocatore.Text;
        }

        public void AggiornaImmagini(int n = 0)
        {
            //object sender = null, RunWorkerCompletedEventArgs e = null

            //if (n > 0)
            //    await Task.Delay((n * 500));

            //Carte nel mazzo
            lblNcarte.Content = Brscl.Mazzo1.NCarteRimaste.ToString() + " carte nel mazzo";

            //Le 3 carte del giocatore
            btnCarta1.Source = Brscl.Ut1.MieCarte[0].percorso;
            btnCarta2.Source = Brscl.Ut1.MieCarte[1].percorso;
            btnCarta3.Source = Brscl.Ut1.MieCarte[2].percorso;

            //2 Carte centrali
            btnCentro1.Source = Brscl.C1.percorso;
            btnCentro2.Source = Brscl.C2.percorso;

            //3 Carte CPU
            //btnCPU1.Source = Brscl.CPU.MieCarte[0].percorso;
            //btnCPU2.Source = Brscl.CPU.MieCarte[1].percorso;
            //btnCPU3.Source = Brscl.CPU.MieCarte[2].percorso;
            btnCPU1.Source = Brscl.VttCarteCPU[0];
            btnCPU2.Source = Brscl.VttCarteCPU[1];
            btnCPU3.Source = Brscl.VttCarteCPU[2];

            //Briscola e Mazzo
            btnBriscola.Source = Brscl.CardBriscola.percorso;
            btnMazzo.Source = Brscl.PercorsoMazzo;

            //Punteggi
            txtPuntiGiocatore.Text = Brscl.Ut1.Punteggio.ToString();
            txtPuntiCPU.Text = Brscl.CPU.Punteggio.ToString();

            return;
        }

        private void btnCarta1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelCarta(0);
        }

        private void btnCarta2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelCarta(1);
        }

        private void btnCarta3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelCarta(2);
        }

        private async void SelCarta(int nCarta, int nAzioni = 0)
        {
            btnCarta1.IsEnabled = false;
            btnCarta2.IsEnabled = false;
            btnCarta3.IsEnabled = false;

            Brscl.SetCentro1(nCarta);
            AggiornaImmagini();

            //si potrebbe aspettare 1 secondo
            Brscl.Continua();

            if (nAzioni == 0)
                await Task.Delay(500);

            AggiornaImmagini();

            int qw = Brscl.DopoConfronto();

            //Stampa il nome del vincitore
            if (qw == 1)
                lblVinto.Content = "Vince Giocatore";
            if (qw == 2)
                lblVinto.Content = "Vince CPU";
            if (qw == 3)
                MessageBox.Show("Ultimo Turno vinto da Giocatore");
            if (qw == 4)
                MessageBox.Show("Ultimo Turno vinto da CPU");

            if (nAzioni == 0)
                await Task.Delay(500);

            AggiornaImmagini();
            Brscl.Continua();

            if (nAzioni == 0)
                await Task.Delay(500);

            AggiornaImmagini();

            ////////////////////////////////

            if (Brscl.Mazzo1.NCarteRimaste < 25)
                bbbtn.IsEnabled = false;

            if (qw > 2)
            {
                int punti = Brscl.Ut1.Punteggio + Brscl.CPU.Punteggio;
                string fine = "tot. punti = " + punti.ToString();

                if (Brscl.Ut1.Punteggio > Brscl.CPU.Punteggio)
                    MessageBox.Show("Partita vinta da Giocatore" + fine);
                else
                    MessageBox.Show("Partita vinta da CPU" + fine);

                //Chiude la finestra e termina il programma
                this.Close();
            }

            btnCarta1.IsEnabled = true;
            btnCarta2.IsEnabled = true;
            btnCarta3.IsEnabled = true;

            //bw.RunWorkerAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bbbtn.IsEnabled = false;
            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                SelCarta(rnd.Next(0, 2), 1);
            }
        }
    }
}