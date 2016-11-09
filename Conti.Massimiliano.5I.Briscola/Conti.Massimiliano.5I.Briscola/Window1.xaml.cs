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
            string[] vtt = { "Piacentine", "Napoletane" };
            cmb.ItemsSource = vtt;
            cmb.SelectedIndex = 0;
        }

        public string nome { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Inserire un nome");
                txtNome.Text = "ciao";
                return;
            }

            Window Finestra = new Conti.Massimiliano._5I.Briscola.MainWindow(txtNome.Text, cmb.SelectedItem.ToString());
            Hide();
            Finestra.ShowDialog();
            Close();
        }
    }
}
