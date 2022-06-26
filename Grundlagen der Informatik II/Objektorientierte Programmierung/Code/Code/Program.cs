using System;
using System.Collections.Generic;

namespace Code
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var uebungen = new List<Ausfuehrbar>
            {
                // new Primzahl.Primzahl(),
                // new TicTacToe.TicTacToe(),
                // new Projekt_Euler.ProjektEuler(),
                // new Bruch.Bruch(),
                // new Rechteck.Rechteck(),
                new Bigint.Bigint()
            };

            foreach (var uebung in uebungen)
                uebung.Ausfuehren();
            // Nur damit die Konsole nach dem Ausführen geöffnet bleibt um die Ergebnisse zu sehen
            Console.Read();
        }
    }
}
