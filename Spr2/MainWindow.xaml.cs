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

namespace Spr2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }




        private void RechteckProfil_selected(object sender, RoutedEventArgs e)
        {
            rechteckprofil_grid.Visibility = Visibility.Visible;
            rundprofil_grid.Visibility = Visibility.Hidden;
            viereckprofil_grid.Visibility = Visibility.Hidden;
            dreieckprofil_grid.Visibility = Visibility.Hidden;
            ovalprofil_grid.Visibility = Visibility.Hidden;
            buttonrechteckprofil.Visibility = Visibility.Visible;
            buttonrundprofil.Visibility = Visibility.Hidden;
            buttonviereckprofil.Visibility = Visibility.Hidden;
            buttondreieckprofil.Visibility = Visibility.Hidden;
            buttonovalprofil.Visibility = Visibility.Hidden;



        }

        private void RundProfil_selected(object sender, RoutedEventArgs e)
        {
            rechteckprofil_grid.Visibility = Visibility.Hidden;
            rundprofil_grid.Visibility = Visibility.Visible;
            viereckprofil_grid.Visibility = Visibility.Hidden;
            dreieckprofil_grid.Visibility = Visibility.Hidden;
            ovalprofil_grid.Visibility = Visibility.Hidden;
            buttonrechteckprofil.Visibility = Visibility.Hidden;
            buttonrundprofil.Visibility = Visibility.Visible;
            buttonviereckprofil.Visibility = Visibility.Hidden;
            buttondreieckprofil.Visibility = Visibility.Hidden;
            buttonovalprofil.Visibility = Visibility.Hidden;

        }

        private void viereckProfil_selected(object sender, RoutedEventArgs e)
        {
            rechteckprofil_grid.Visibility = Visibility.Hidden;
            rundprofil_grid.Visibility = Visibility.Hidden;
            viereckprofil_grid.Visibility = Visibility.Visible;
            dreieckprofil_grid.Visibility = Visibility.Hidden;
            ovalprofil_grid.Visibility = Visibility.Hidden;
            buttonrechteckprofil.Visibility = Visibility.Hidden;
            buttonrundprofil.Visibility = Visibility.Hidden;
            buttonviereckprofil.Visibility = Visibility.Visible;
            buttondreieckprofil.Visibility = Visibility.Hidden;
            buttonovalprofil.Visibility = Visibility.Hidden;

        }

        private void DreieckProfil_selected(object sender, RoutedEventArgs e)
        {
            rechteckprofil_grid.Visibility = Visibility.Hidden;
            rundprofil_grid.Visibility = Visibility.Hidden;
            viereckprofil_grid.Visibility = Visibility.Hidden;
            dreieckprofil_grid.Visibility = Visibility.Visible;
            ovalprofil_grid.Visibility = Visibility.Hidden;
            buttonrechteckprofil.Visibility = Visibility.Hidden;
            buttonrundprofil.Visibility = Visibility.Hidden;
            buttonviereckprofil.Visibility = Visibility.Hidden;
            buttondreieckprofil.Visibility = Visibility.Visible;
            buttonovalprofil.Visibility = Visibility.Hidden;
        }

        private void OvalProfil_selected(object sender, RoutedEventArgs e)
        {
            rechteckprofil_grid.Visibility = Visibility.Hidden;
            rundprofil_grid.Visibility = Visibility.Hidden;
            viereckprofil_grid.Visibility = Visibility.Hidden;
            dreieckprofil_grid.Visibility = Visibility.Hidden;
            ovalprofil_grid.Visibility = Visibility.Visible;
            buttonrechteckprofil.Visibility = Visibility.Hidden;
            buttonrundprofil.Visibility = Visibility.Hidden;
            buttonviereckprofil.Visibility = Visibility.Hidden;
            buttondreieckprofil.Visibility = Visibility.Hidden;
            buttonovalprofil.Visibility = Visibility.Visible;
        }

        private void buttonrechteckprofil_Click(object sender, RoutedEventArgs e)
        {

            double Länge = double.Parse(txtlänge.Text);
            double Breite = double.Parse(txtbreite.Text);
            double Höhe = double.Parse(txthöhe.Text);

            txtvolume.Text = (berechnungvolumen_rechteckprofil(Länge, Breite, Höhe) + "mm³");
            txtFTM_X.Text = (berechnungFTM_X_rechteckprofil(Breite, Höhe) + "mm^4");
            txtFTM_Y.Text = (berechnungFTM_Y_rechteckprofil(Breite, Höhe) + "mm^4");
            txtmasse.Text = (berechnungmasse_rechteckprofil(Länge, Breite, Höhe) + "mm^4");
            txtschwerpunkt_x.Text = (berechgnungschwerpunkt_x_rechteckprofil(Länge, Breite, Höhe) + "g");




        }

        public double berechnungvolumen_rechteckprofil(double Länge, double Breite, double höhe)
        {

            double Volumen_rechteckprofil = Länge * Breite * höhe;
            return Volumen_rechteckprofil;

        }
        public double berechnungFTM_X_rechteckprofil(double Breite, double Höhe)
        {
            double berechnungFTM_X_rechteckprofil = (Breite * (Math.Pow(Höhe, 3)) / 12);
            return berechnungFTM_X_rechteckprofil;
        }
        public double berechnungFTM_Y_rechteckprofil(double Breite, double Höhe)
        {
            double berechnungFTM_Y_rechteckprofil = (Höhe * (Math.Pow(Breite, 3)) / 12);
            return berechnungFTM_Y_rechteckprofil;

        }
        public double berechnungmasse_rechteckprofil(double Länge, double Breite, double Höhe)
        {
            double berechnungmasse_rechteckprofil = (Länge * Breite * Höhe) ;
            return berechnungmasse_rechteckprofil;
        }

        public double berechgnungschwerpunkt_x_rechteckprofil(double Länge, double Breite, double Höhe)
        {
            double berechgnungschwerpunkt_x_rechteckprofil = (Breite / 2);
            return berechgnungschwerpunkt_x_rechteckprofil;
        }


    }
}
