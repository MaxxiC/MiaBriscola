using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.ComponentModel;

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

        private Briscola Brscl;
        public BackgroundWorker bw;
        static public Random rnd = new Random();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IniziaPartita();
            //bw = new BackgroundWorker();
            //bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            //bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AggiornaImmagini);
        }

        private void IniziaPartita()
        {
            Brscl = new Briscola();
            AggiornaImmagini();
        }

        public void AggiornaImmagini(object sender = null, RunWorkerCompletedEventArgs e = null)
        {
            //Carte nel mazzo
            lblNcarte.Content = "                        " + Brscl.Mazzo1.NCarteRimaste.ToString();

            //Le 3 carte del giocatore
            btnCarta1.Source = Brscl.Ut1.MieCarte[0].percorso;
            btnCarta2.Source = Brscl.Ut1.MieCarte[1].percorso;
            btnCarta3.Source = Brscl.Ut1.MieCarte[2].percorso;

            //2 Carte centrali
            btnCentro1.Source = Brscl.C1.percorso;
            btnCentro2.Source = Brscl.C2.percorso;

            //3 Carte CPU
            btnCPU1.Source = Brscl.CPU.MieCarte[0].percorso;
            btnCPU2.Source = Brscl.CPU.MieCarte[1].percorso;
            btnCPU3.Source = Brscl.CPU.MieCarte[2].percorso;

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

        private void SelCarta(int nCarta, int nAzioni = 0)
        {
            //bw.RunWorkerAsync();
            Brscl.SetCentro1(nCarta);
            AggiornaImmagini();

            //si potrebbe aspettare 1 secondo
            Brscl.Continua();
            AggiornaImmagini();

            int qw = Brscl.DopoConfronto();

            if (qw == 1)
                MessageBox.Show("Vince Giocatore");
            if (qw == 2)
                MessageBox.Show("Vince CPU");
            if (qw == 3)
                MessageBox.Show("Ultimo Turno vinto da Giocatore");
            if (qw == 4)
                MessageBox.Show("Ultimo Turno vinto da CPU");

            Brscl.Continua();
            AggiornaImmagini();

            ////////////////////////////////

            int punti = Brscl.Ut1.Punteggio + Brscl.CPU.Punteggio;
            string fine = "tot. punti = " + punti.ToString();
            if (qw > 2)
            {
                if (Brscl.Ut1.Punteggio > Brscl.CPU.Punteggio)
                    MessageBox.Show("Partita vinta da Giocatore" + fine);
                else
                    MessageBox.Show("Partita vinta da CPU" + fine);


            }

            //bw.RunWorkerAsync();
        }

        //private void bw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    BackgroundWorker worker = sender as BackgroundWorker;
        //    Thread.Sleep(2000);
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TabInizio.Visibility = Visibility.Hidden;
            //IniziaPartita();
            //TabPartita.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
            Random rnd = new Random();
            for (int i = 0; i < 17; i++)
            {
                SelCarta(rnd.Next(0, 2));
            }

        }
    }
}