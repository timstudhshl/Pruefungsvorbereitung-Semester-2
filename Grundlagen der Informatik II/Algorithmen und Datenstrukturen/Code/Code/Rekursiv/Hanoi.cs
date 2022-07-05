using System;

namespace Code.Rekursiv
{
    public static class Hanoi
    {
        public static int Anzahl = 0;

        public static void Bewege(int n, char start, char ziel, char hilfe)
        {
            if (n == 1)
            {
                Anzahl++;
                Console.WriteLine(Anzahl + ": Bewege eine Scheibe von " + start + " nach " + ziel);
            }
            else
            {
                Bewege(n - 1, start, hilfe, ziel);
                Bewege(1, start, ziel, hilfe);
                Bewege(n - 1, hilfe, ziel, start);
            }
        }
    }
}
