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
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AggiornaImmagini);
        }

        private void IniziaPartita()
        {
            Brscl = new Briscola();
            AggiornaImmagini();
            txtPuntiGiocatore.Text = Brscl.Ut1.Punteggio.ToString();
        }

        public void AggiornaImmagini(object sender = null, RunWorkerCompletedEventArgs e = null)
        {
            btnCarta1.Source = Brscl.Ut1.MieCarte[0].percorso;
            btnCarta2.Source = Brscl.Ut1.MieCarte[1].percorso;
            btnCarta3.Source = Brscl.Ut1.MieCarte[2].percorso;
            
            btnCentro1.Source = Brscl.C1.percorso;
            btnCentro2.Source = Brscl.C2.percorso;

            btnBriscola.Source = Brscl.CardBriscola.percorso;

            txtPuntiGiocatore.Text = Brscl.Ut1.Punteggio.ToString();
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

            AggiornaImmagini();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            Thread.Sleep(2000);
        }

        //public async void Aspetta(int mlSec)
        //{
        //    await Task.Delay(mlSec);
        //}
    }
}
