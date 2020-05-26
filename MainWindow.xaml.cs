using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
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

        private void TextBox_Textchanged(object sender, TextChangedEventArgs e)
        { 

        }



        // Rechteck
       // public void buttonrechteckprofil_Click(object sender, RoutedEventArgs e) nach unten verschoben
        

        public double berechnungvolumen_rechteckprofil(double Länge, double Breite, double höhe)
        {

            double Volumen_rechteckprofil = Math.Round(Länge * Breite * höhe,3);
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
        public double berechnungmasse_rechteckprofil(double Länge, double Breite, double Höhe, double dichte)
        {
            double berechnungmasse_rechteckprofil = dichte * (Länge * Breite * Höhe) ;
            return berechnungmasse_rechteckprofil;
        }

        public double berechgnungschwerpunkt_x_rechteckprofil(double Länge, double Breite, double Höhe)
        {
            double berechgnungschwerpunkt_x_rechteckprofil = (Breite / 2);
            return berechgnungschwerpunkt_x_rechteckprofil;
        }
         
        //Rundprofil
        public void buttonrundprofil_Click_1(object sender, RoutedEventArgs e)
        {

            double Durchmesser = double.Parse(txtDurchmesser_rundprofil.Text);
            double Länge = double.Parse(txtLänge_rundprofil.Text);
            double Dichte = double.Parse(txtdichte_rundprofil.Text);


            txtvolume.Text = (berechnungvolume_rundprofil(Durchmesser, Länge) + "mm³");
            txtFTM_X.Text = (berechnungFTM_X_rundprofil(Durchmesser) + "mm^4");
            txtFTM_Y.Text = (berechnungFTM_Y_rundprofil(Durchmesser) + "mm^4");
            txtmasse.Text = (berechnungmasse_rundprofil(Durchmesser, Länge, Dichte) + "g");
            txtschwerpunkt_x.Text = (berechnungschwerpunkt_x_rundprofil(Durchmesser) + "mm");



        }
        public double berechnungvolume_rundprofil(double Durchmesser, double Länge)
        {
            double Volumen_Rundprofil = (((Math.PI * Math.Pow(Durchmesser, 2)) / 4) * Länge);


            return Volumen_Rundprofil;
        }

        public double berechnungFTM_X_rundprofil(double Durchmesser)
        {
            double FTM_X_rundprofil = ((Math.PI * Math.Pow(Durchmesser, 4)) / 64);

            return FTM_X_rundprofil;
        }

        public double berechnungFTM_Y_rundprofil(double Durchmesser)
        {
            double FTM_Y_rundprofil = ((Math.PI * Math.Pow(Durchmesser, 3)) / 32);

            return FTM_Y_rundprofil;
        }

        public double berechnungmasse_rundprofil(double Durchmesser, double Länge, double Dichte)
        {
            double masse = ((((Math.PI * Math.Pow(Durchmesser, 2)) / 4) * Länge) * Dichte);

            return masse;
        }

        public double berechnungschwerpunkt_x_rundprofil(double Durchmesser)
        {
            double berechnungschwerpunkt_x = Durchmesser / 2;

            return berechnungschwerpunkt_x;
        }
        //Viereck
        public void buttonviereckprofil_Click_1(object sender, RoutedEventArgs e)

        {

           
        }

        public double berechnungvolume_viereckprofil(double Länge)
        {

            double Volume_viereckprofil = Länge * Länge * Länge;
            return Volume_viereckprofil;

        }

        public double berechnungFTM_X_viereckprofil (double Länge)
        {

            double FTM_X_viereckprofil = Math.Pow(Länge, 4) / 12;
            return FTM_X_viereckprofil;

        }

        public double berechnungFTM_Y_viereckprofil(double Länge)
        {

            double FTM_Y_viereckprofil = Math.Pow(Länge, 3) / 6;
            return FTM_Y_viereckprofil;

        }

        public double berechnungmasse_viereckprofil(double Länge, double Dichte)
        {
            double masse_viereckprofil = Math.Pow(Länge, 3) * Dichte;
            return masse_viereckprofil;
            
        }

        public double berechgnungschwerpunkt_x_viereckprofil(double Länge)
        {
            double schwerpunkt_x_viereckprofil = Länge / 2;
            return schwerpunkt_x_viereckprofil;

        }
        //dreieckprofil
        
        

        public double berechnungvolume_dreieckprofil(double Breite, double Höhe)
        {

            double Volume_dreieckprofil = Breite * Höhe;
            return Volume_dreieckprofil;

        }

        public double berechnungFTM_X_dreieckprofil(double Breite, double Höhe)
        {

            double FTM_X_dreieckprofil = Breite * Math.Pow(Höhe, 3) / 36;
            return FTM_X_dreieckprofil;

        }
        public double berechnungFTM_Y_dreieckprofil(double Breite, double Höhe)
        {

            double FTM_Y_dreieckprofil = Höhe * Math.Pow(Breite, 3) / 48;
            return FTM_Y_dreieckprofil;

        }
        public double berechnungmasse_dreieckprofil(double Breite, double Höhe, double Dichte )
        {
            double masse_dreieckprofil = Breite * Höhe * Dichte;
            return masse_dreieckprofil;

        }

        public double berechnungschwerpunkt_x_dreieckprofil(double Breite)
        {
            double schwerpunkt_x_dreieckprofil = (1 / 3) * Breite;
            return schwerpunkt_x_dreieckprofil;


        }
            //OvalProfil
          

        public double berechnungvolumen_ovalprofil(double Durchmesser_a,  double Durchmesser_b)
        {
            double Volume_ovalprofil = 4 * (Math.PI) * (Durchmesser_a * Durchmesser_b);
            return Volume_ovalprofil;

        }
        public double berechnungFTM_X_ovalprofil(double Durchmesser_b, double Durchmesser_a)
        {
            double FTM_X_ovalprofil = (Math.PI * Math.Pow(Durchmesser_a, 3) * Durchmesser_b) / 4;
            return FTM_X_ovalprofil;

        }
        public double berechnungFTM_Y_ovalprofil(double Durchmesser_b, double Durchmesser_a)
        {
            double FTM_Y_ovalprofil = (Math.PI * Math.Pow(Durchmesser_b, 3) * Durchmesser_a) / 4;
            return FTM_Y_ovalprofil;


        }
        public double berechnungmasse_ovalprofil(double Durchmesser_a, double Durchmesser_b, double Dichte)
        {
            double masse_ovalprofil = (4 * (Math.PI) * (Durchmesser_b * Durchmesser_a)) * Dichte;
            return masse_ovalprofil;
        }

        public double berechgnungschwerpunkt_x_ovalprofil(double Durchmesser_a)
        {
            double schwerpunkt_x_ovalprofil = Durchmesser_a / 2 ;
            return schwerpunkt_x_ovalprofil;


        }

        private void buttonrechteckprofil_Click_1(object sender, RoutedEventArgs e)
        {
            bool checkmate = false;
            do
            {
                double Länge = double.Parse(txtlänge_rechteckprofil.Text);
                double Breite = double.Parse(txtbreite_rechteckprofil.Text);
                double Höhe = double.Parse(txthöhe_rechteckprofil.Text);
                double dichte = double.Parse(txtdichte_rechteckprofil.Text);

                txtvolume.Text = (berechnungvolumen_rechteckprofil(Länge, Breite, Höhe) + "mm³");
                txtFTM_X.Text = (berechnungFTM_X_rechteckprofil(Breite, Höhe) + "mm^4");
                txtFTM_Y.Text = (berechnungFTM_Y_rechteckprofil(Breite, Höhe) + "mm^4");
                txtmasse.Text = (berechnungmasse_rechteckprofil(Länge, Breite, Höhe, dichte) + "g");
                txtschwerpunkt_x.Text = (berechgnungschwerpunkt_x_rechteckprofil(Länge, Breite, Höhe) + "mm");

            }
            while (checkmate);

        }

        private void buttonviereckprofil_Click(object sender, RoutedEventArgs e)
        {
            double Länge = double.Parse(txtLänge_viereckprofil.Text);
            double Dichte = double.Parse(txtdichte_viereckprofil.Text);


            txtvolume.Text = (berechnungvolume_viereckprofil(Länge) + "mm³");
            txtFTM_X.Text = (berechnungFTM_X_viereckprofil(Länge) + "mm^4");
            txtFTM_Y.Text = (berechnungFTM_Y_viereckprofil(Länge) + "mm^4");
            txtmasse.Text = (berechnungmasse_viereckprofil(Länge, Dichte) + "g");
            txtschwerpunkt_x.Text = (berechgnungschwerpunkt_x_viereckprofil(Länge) + "mm");

        }

        private void buttondreieckprofil_Click_1(object sender, RoutedEventArgs e)
        {
            double Breite = double.Parse(txtBreite_dreieckprofil.Text);
            double Höhe = double.Parse(txtHöhe_dreieckprofil.Text);
            double Dichte = double.Parse(txtdichte_dreieckprofil.Text);

            txtvolume.Text = (berechnungvolume_dreieckprofil(Breite, Höhe) + "mm³");
            txtFTM_X.Text = (berechnungFTM_X_dreieckprofil(Breite, Höhe) + "mm^4");
            txtFTM_Y.Text = (berechnungFTM_Y_dreieckprofil(Breite, Höhe) + "mm^4");
            txtmasse.Text = (berechnungmasse_dreieckprofil(Breite, Höhe, Dichte) + "g");
            txtschwerpunkt_x.Text = (berechnungschwerpunkt_x_dreieckprofil(Breite) + "mm");
        }

        private void buttonovalprofil_Click(object sender, RoutedEventArgs e)
        {

            double Durchmesser_a = double.Parse(txtDurchmesser_a_ovalprofil.Text);
            double Durchmesser_b = double.Parse(txtDurchmesser_b_ovalprofil.Text);
            double Dichte = double.Parse(txtdichte_ovalprofil.Text);

            txtvolume.Text = (berechnungvolumen_ovalprofil(Durchmesser_a, Durchmesser_b) + "mm³");
            txtFTM_X.Text = (berechnungFTM_X_ovalprofil(Durchmesser_a, Durchmesser_b) + "mm^4");
            txtFTM_Y.Text = (berechnungFTM_Y_ovalprofil(Durchmesser_a, Durchmesser_b) + "mm^4");
            txtmasse.Text = (berechnungmasse_ovalprofil(Durchmesser_a, Durchmesser_b, Dichte) + "g");
            txtschwerpunkt_x.Text = (berechgnungschwerpunkt_x_ovalprofil(Durchmesser_a) + "mm");
        }
    }
}
