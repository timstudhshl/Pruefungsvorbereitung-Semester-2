using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Projekt_Euler
{
    /// <summary>
    /// Lösungen zu den Aufgaben 1 bis 4 von Projekt Euler
    /// Aufgabenstellungen etc. https://projecteuler.net/archives
    /// </summary>
    internal class ProjektEuler : Ausfuehrbar
    {
        public override void Ausfuehren()
        {
            Aufgabe1();
            Aufgabe2();
            Aufgabe3();
            Aufgabe4();
        }

        private static void Aufgabe1()
        {
            Console.WriteLine("Aufgabe 1:");
            var zahlen = new List<int>();
            for (var i = 0; i < 1000; i++) zahlen.Add(i);

            var summe = zahlen.Where(zahl => zahl % 3 == 0 || zahl % 5 == 0).Sum();
            Console.WriteLine("Summe der Zahlen von 0 bis 1000 die ein Mehrfaches von 3 oder 5 sind:");
            Console.WriteLine($"{summe}\n");
        }

        private static void Aufgabe2()
        {
            Console.WriteLine("Aufgabe 2:");
            var fibonacci = new List<int>
            {
                1, 2
            };
            while (fibonacci[fibonacci.Count - 2] + fibonacci[fibonacci.Count - 1] < 4000000)
                fibonacci.Add(fibonacci[fibonacci.Count - 2] + fibonacci[fibonacci.Count - 1]);

            var summe = fibonacci.Where(zahl => zahl % 2 == 0).Sum();
            Console.WriteLine("Die Summe der gereaden Zahlen der Fibonacci Folge ist:");
            Console.WriteLine($"{summe}\n");
        }

        private static void Aufgabe3()
        {
            Console.WriteLine("Aufgabe 3:");
            var zahl = 600851475143;
            while (true)
            {
                var prim = KleinsterPrimfaktor(zahl);
                if (prim < zahl)
                    zahl /= prim;
                else
                {
                    Console.WriteLine("Die größte Primzahl der Zerlegung von 600.851.475.143 ist:");
                    Console.WriteLine($"{zahl}\n");
                    return;
                }
            }
        }

        private static long KleinsterPrimfaktor(long zahl)
        {
            if (zahl <= 1)
                throw new ArgumentException(
                    "Zahl ist kleiner gleich 1. Dafür kann man keine Primfaktorzerlegung durchführen");
            var ende = Math.Sqrt(zahl);
            for (var anfang = 2; anfang < ende; anfang++)
            {
                if (zahl % anfang == 0)
                    return anfang;
            }

            return zahl;
        }

        private static void Aufgabe4()
        {
            Console.WriteLine("Aufgabe 4:");
            var groeßte = 0;
            for (var zahl1 = 100; zahl1 < 1000; zahl1++)
            {
                for (var zahl2 = 100; zahl2 < 1000; zahl2++)
                {
                    var ergebnis = zahl1 * zahl2;
                    if (groeßte < ergebnis)
                    {
                        var array = ergebnis.ToString().ToCharArray();
                        Array.Reverse(array);
                        var rueckwaerts = new string(array);
                        if (ergebnis.ToString() == rueckwaerts)
                            groeßte = ergebnis;
                    }
                }
            }

            Console.WriteLine("Das größte Palindrom eines Produktes von 3 stelligen Zahlen:");
            Console.WriteLine($"{groeßte}\n");
        }
    }
}
