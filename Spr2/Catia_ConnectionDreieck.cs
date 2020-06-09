using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFITF;
using MECMOD;
using PARTITF;

namespace Spr2
{
    class Catia_ConnectionDreieck
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPart;
        MECMOD.Sketch hsp_catiaProfil;


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


        //public void erzeugePart()
        //{
        //    //erzeuge Part
        //    Document partdoc = hsp_catiaApp.Documents.Add("Part");

        //    hsp_catiaPart = (PartDocument)partdoc;
        //}
        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaProfil.SetAbsoluteAxisData(arr);
        }



        public void ErzeugeProfil(double breitedreieck, double hoehedreieck)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Dreieck");

            // Dreieck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Dreieck erzeugen
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, hoehedreieck);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(0, hoehedreieck);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(breitedreieck / 2, 0);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-breitedreieck / 2, 0);

            Line2D catLine2D1 = catFactory2D1.CreateLine(0, hoehedreieck, 0, hoehedreieck);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(0, Math.Sqrt(Math.Pow(hoehedreieck,2)), breitedreieck / 2, 0);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(breitedreieck / 2, 0, -breitedreieck / 2, 0);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-breitedreieck / 2, 0, 0, Math.Sqrt(Math.Pow(hoehedreieck, 2)));
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
        public void ErzeugeBalken(Double l)
        {
            // Hauptkoerper in Bearbeitung definieren
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, l);

            // Block umbenennen
            catPad1.set_Name("Balken");

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }
    }
}
