using System;

namespace Code.Primzahl
{
    /// <summary>
    /// In dieser Klasse wird eine beliebige Ganzzahl geprüft,
    /// ob diese eine Primzahl ist.
    /// </summary>
    internal class Primzahl : Ausfuehrbar
    {
        public override void Ausfuehren()
        {
            Console.WriteLine($"Ist 0 eine Primzahl? {IstPrimzahl(0)}");
            Console.WriteLine($"Ist 6 eine Primzahl? {IstPrimzahl(6)}");
            Console.WriteLine($"Ist 22 eine Primzahl? {IstPrimzahl(22)}");
            Console.WriteLine($"Ist 17 eine Primzahl? {IstPrimzahl(17)}");
            Console.WriteLine($"Ist 187 eine Primzahl? {IstPrimzahl(187)}");
        }

        private static bool IstPrimzahl(int zahl)
        {
            // Zahlen kleiner gleich 1 sind keine Primzahlen
            if (zahl <= 1)
                return false;
            // Die Zahlen 2 und 3 sind eine Primzahl
            else if (zahl == 2 || zahl == 3)
                return true;

            // Alle größeren Zahlen werden hier geprüft
            // Damit der durchlauf schneller geht kann man die Zahl durch 2 Teilen und dies als Grenze nehmen
            for (var hilfe = 2; hilfe <= zahl / 2; hilfe++)
                if (zahl % hilfe != 0)
                    return true;

            return false;
        }
    }
}
