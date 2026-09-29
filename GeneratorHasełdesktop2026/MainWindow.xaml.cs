using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeneratorHasełdesktop2026
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txtIloscZnakow.Text = "12";
            WielkieLitery.IsChecked = true;
            Cyfry.IsChecked = true;
            ZnakiSpecjalne.IsChecked = true;

            btnGeneruj.Click += btnGeneruj_Click;
        }

        private void btnGeneruj_Click(object sender, RoutedEventArgs e)
        {
            int dlugosc;

            if (!int.TryParse(txtIloscZnakow.Text, out dlugosc) || dlugosc < 1)
            {
                MessageBox.Show("Podaj prawidłową długość hasła.");
                return;
            }

            bool wielkieLitery = WielkieLitery.IsChecked == true;
            bool cyfry = Cyfry.IsChecked == true;
            bool znakiSpecjalne = ZnakiSpecjalne.IsChecked == true;

            PasswordGenerator generator = new PasswordGenerator(
                dlugosc,
                znakiSpecjalne,
                wielkieLitery,
                cyfry
            );

            string haslo = generator.GenerujHaslo();
            string sila = PasswordGenerator.OcenSileHasla(haslo);

            txtHaslo.Text = haslo;
            txtSilaHasla.Text = sila;

            if (sila == "Słabe")
                txtSilaHasla.Foreground = Brushes.Red;
            else if (sila == "Średnie")
                txtSilaHasla.Foreground = Brushes.Orange;
            else
                txtSilaHasla.Foreground = Brushes.Green;

            lstHistoria.Items.Add(haslo);
        }
    }
}