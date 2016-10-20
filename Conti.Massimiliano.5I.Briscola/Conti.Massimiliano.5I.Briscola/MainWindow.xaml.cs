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

        private void AggiornaImmagini(int nCarta)
        {
            btnCarta1.Source = Brscl.Ut1.MieCarte[0].percorso;
            btnCarta2.Source = Brscl.Ut1.MieCarte[1].percorso;
            btnCarta3.Source = Brscl.Ut1.MieCarte[2].percorso;

            btnBriscola.Source = Brscl.CardBriscola.percorso;

            //switch (nCarta)
            //{
            //    case 1:
            //        break;
            //    case 2:
            //        break;
            //    case 3:
            //        break;
            //    case 7:
            //        break;
            //    case 8:
            //        break;
            //    case 9:
            //        break;
            //    default:
            //        break;
            //}
        }

        private void btnCarta1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Brscl.UsaCarta(1);
            AggiornaImmagini(0);
        }

        private void btnCarta2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Brscl.UsaCarta(2);
            AggiornaImmagini(0);
        }

        private void btnCarta3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Brscl.UsaCarta(3);
            AggiornaImmagini(0);
        }
    }
}
