using System;
using System.Windows;

namespace Conti.Massimiliano._5I.Briscola
{
    /// <summary>
    /// Logica di interazione per Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window Finestra = new Conti.Massimiliano._5I.Briscola.MainWindow();
            Hide();
            Finestra.ShowDialog();
            Close();
        }
    }
}
