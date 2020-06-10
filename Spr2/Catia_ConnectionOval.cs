using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFITF;
using MECMOD;
using PARTITF;
using System.Windows.Input;
using System.Windows;

namespace Spr2
{
    class Catia_ConnectionEllipse
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPart;
        MECMOD.Sketch hsp_catiaProfil;



        // Abfrage Catia läuft?
        public bool laeuftCatia()
        {
            try
            {
                object co =
               System.Runtime.InteropServices.Marshal.GetActiveObject("CATIA.Application");
                hsp_catiaApp = (INFITF.Application)co;
                return true;

            }
            catch
            {

                //MessageBox.Show("");
                return false;

                //return true;
            }
        }
        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;
            return true;
        }

        // Erstellung einer Leeren Skizze
        internal void erstelleLeereSkizze()
        {
            HybridBodies catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");

            catHybridBody1.set_Name("Profile"); // Erstelle eine Skizze mit dem Namen Profile
            Sketches catSketches1 = catHybridBody1.HybridSketches; // Mit den genannten die Umrisse erstellen

            Reference catReference1 = (Reference)hsp_catiaPart.Part.OriginElements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            //Part aktualisieren
            hsp_catiaPart.Part.Update();
        }


        public void erzeugePart()
        {
            //erzeuge Part
            Document partdoc = hsp_catiaApp.Documents.Add("Part");

            hsp_catiaPart = (PartDocument)partdoc;
        }
        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaProfil.SetAbsoluteAxisData(arr);
        }



        public void setMittelpunkt(double r)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Oval");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Kreis erzeugen
            // erst die Punkte


            Ellipse2D Ellipse2D = catFactory2D1.CreateEllipse(0, 0, r, 0, 71, 800, 5, 500);



            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }





        public void ErzeugebalkenEllipse(double d)
        {
            // Hauptkoerper in Bearbeitung definieren
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, d);


            // Block umbenennen
            catPad1.set_Name("Stange");


            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
        //}

        //}
    }
}

