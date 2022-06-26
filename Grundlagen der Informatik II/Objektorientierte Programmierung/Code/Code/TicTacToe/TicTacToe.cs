using System;
using System.Runtime.CompilerServices;

namespace Code.TicTacToe
{
    /// <summary>
    /// Erstellt ein Spielfeld, welches zufällig belegt wird.
    /// Falls möglich (keiner Gewonnen und noch Feld frei) wird der Nutzer nach einer Eingabe gefragt.
    /// </summary>
    internal class TicTacToe : Ausfuehrbar
    {
        public override void Ausfuehren()
        {
            var feld = ZufallsfeldErzeugen();
            Ausgeben(feld);
            Console.WriteLine($"Hat Speiler X gewonnen? {Gewonnen(feld, 'X')}");
            Console.WriteLine($"Hat Speiler O gewonnen? {Gewonnen(feld, 'O')}");
            Console.WriteLine($"Ist es ein Unentschieden? {!Gewonnen(feld, 'X') && !Gewonnen(feld, 'O')}");
            Console.WriteLine($"Ist ein weiterer Zug möglich? {WeitereZuegeMoeglich(feld)}\n");
            if (WeitereZuegeMoeglich(feld))
                NutzerEingabe(feld);
        }

        private static char[,] ZufallsfeldErzeugen()
        {
            var feld = new char[3, 3];
            var rnd = new Random();

            for (var y = 0; y < 3; y++)
            {
                for (var x = 0; x < 3; x++)
                {
                    switch (rnd.Next(0, 3))
                    {
                        case 1:
                            feld[y, x] = 'X';
                            break;
                        case 2:
                            feld[y, x] = 'O';
                            break;
                        default:
                            feld[y, x] = ' ';
                            break;
                    }
                }
            }

            return feld;
        }

        private static void Ausgeben(char[,] feld)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   0  1  2");
            Console.ResetColor();
            for (var zeile = 0; zeile < 3; zeile++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{zeile} ");
                Console.ResetColor();
                for (var spalte = 0; spalte < 3; spalte++)
                {
                    Console.Write($"[{feld[zeile, spalte]}]");
                }

                Console.Write("\n"); // Neue Zeile anfangen
            }
        }

        private static bool Gewonnen(char[,] feld, char spielerZeichen)
        {
            for (var index = 0; index < 3; index++)
            {
                // Vertikal
                if (feld[0, index] == spielerZeichen &&
                    feld[1, index] == spielerZeichen &&
                    feld[2, index] == spielerZeichen)
                    return true;

                // Horizontal
                if (feld[index, 0] == spielerZeichen &&
                    feld[index, 1] == spielerZeichen &&
                    feld[index, 2] == spielerZeichen)
                    return true;
            }

            // Diagonal: oben Links => unten Rechts
            if (feld[0, 0] == spielerZeichen &&
                feld[1, 1] == spielerZeichen &&
                feld[2, 2] == spielerZeichen)
                return true;

            // Diagonal: unten Links => oben Rechts
            if (feld[0, 2] == spielerZeichen &&
                feld[1, 1] == spielerZeichen &&
                feld[2, 0] == spielerZeichen)
                return true;

            return false;
        }

        private static bool WeitereZuegeMoeglich(char[,] feld)
        {
            if (Gewonnen(feld, 'X') || Gewonnen(feld, 'O'))
                return false;

            for (var spalte = 0; spalte < 3; spalte++)
            {
                for (var zeile = 0; zeile < 3; zeile++)
                {
                    if (feld[spalte, zeile] == ' ')
                        return true;
                }
            }

            return false;
        }

        private static void NutzerEingabe(char[,] feld)
        {
            var korrekteEingabe = false;
            do
            {
                Console.WriteLine("Dein Spielstein ist das 'X'");
                Console.Write("Bitte geben Sie eine Zeile ein: ");
                var zeile = Convert.ToInt32(Console.ReadLine());
                Console.Write("Bitte geben Sie eine Spalte ein: ");
                var spalte = Convert.ToInt32(Console.ReadLine());
                if (feld[spalte, zeile] == ' ')
                {
                    feld[zeile, spalte] = 'X';
                    korrekteEingabe = true;
                }
            } while (!korrekteEingabe);

            Ausgeben(feld);
        }
    }
}
