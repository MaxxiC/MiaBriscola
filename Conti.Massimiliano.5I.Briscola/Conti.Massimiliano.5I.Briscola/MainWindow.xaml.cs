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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IniziaPartita();
        }

        private void IniziaPartita()
        {
            Brscl = new Briscola();
            AggiornaImmagini(0);
            //btnCarta1.Source = "Immagini/Bastoni (1).png";
            //btnCarta1.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Immagini/Denari (1).png")));
            //btnCarta1.Background = U1.MieCarte[0].percorso;
        }

        public void AggiornaImmagini(int nCarta)
        {
            btnCarta1.Source = Brscl.Ut1.MieCarte[0].percorso;
            btnCarta2.Source = Brscl.Ut1.MieCarte[1].percorso;
            btnCarta3.Source = Brscl.Ut1.MieCarte[2].percorso;

            btnBriscola.Source = Brscl.CardBriscola.percorso;
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

        private void SelCarta(int nCarta)
        {
            switch (nCarta)
            {
                case 0:
                    btnCentro1.Source = btnCarta1.Source;
                    btnCarta1.Source = null;
                    break;
                case 1:
                    btnCentro1.Source = btnCarta2.Source;
                    btnCarta2.Source = null;
                    break;
                case 2:
                    btnCentro1.Source = btnCarta3.Source;
                    btnCarta3.Source = null;
                    break;
                default:
                    break;
            }
            
            Brscl.UsaCarta(nCarta);
            AggiornaImmagini(0);
        }
    }
}
