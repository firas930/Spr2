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
    class Catia_ConnectionQuadrat
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
          
        }



        public void ErzeugeProfil(double längequadrat)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Quadrat");

            // quadrat in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            // Quadrat erzeugen
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-längequadrat / 2, längequadrat / 2);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(längequadrat / 2, längequadrat / 2);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(längequadrat / 2, -längequadrat / 2);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-längequadrat / 2, -längequadrat / 2);

            Line2D catLine2D1 = catFactory2D1.CreateLine(-längequadrat / 2, längequadrat / 2, längequadrat / 2, längequadrat / 2);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(längequadrat / 2, längequadrat / 2, längequadrat / 2, -längequadrat / 2);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(längequadrat / 2, -längequadrat / 2, -längequadrat / 2, -längequadrat / 2);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-längequadrat / 2, -längequadrat / 2, -längequadrat / 2, längequadrat / 2);
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
