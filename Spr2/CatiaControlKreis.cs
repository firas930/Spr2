using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Spr2
{
   public class CatiaControlKreis
    {
      
            public CatiaControlKreis()
            {
                try
                {

                    Catia_ConnectionKreis cc = new Catia_ConnectionKreis();
                    // Finde Catia Prozess
                    if (cc.laeuftCatia())
                    {
                        Console.WriteLine("0");

                        // Öffne ein neues Part
                        cc.ErzeugePart();
                        Console.WriteLine("1");

                        // Erstelle eine Skizze
                        cc.erstelleLeereSkizze();
                        Console.WriteLine("2");

                        // Generiere ein Profil
                        cc.setMittelpunkt( 20);
                        Console.WriteLine("");

                        // Extrudiere Balken
                        cc.ErzeugeBalkenkreis(300);
                        Console.WriteLine("4");
                    }
                    else
                    {
                        Console.WriteLine("Laufende Catia Application nicht gefunden");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception aufgetreten");
                }
                // Console.WriteLine("Fertig - Taste drücken.");
                //  Console.ReadKey();

            }


        
    }
}
