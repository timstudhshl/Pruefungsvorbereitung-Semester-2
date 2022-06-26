using System;
using System.Linq;

namespace Code.Bigint
{
    internal class Bigint : Ausfuehrbar
    {
        private int[] _nummer = Array.Empty<int>();

        public override void Ausfuehren()
        {
            var int1 = new Bigint("1000000000000000000000000000000");
            var int2 = new Bigint("2000000000000000000000000000000");

            Console.WriteLine($"Int1: {int1.Nummer}");
            Console.WriteLine($"Int2: {int2.Nummer}");
            Console.WriteLine();

            var int3 = int1.Addieren(int2);
            Console.WriteLine($"Int3 = Int1 + Int2 = {int3.Nummer}");

            Console.ReadLine();
        }

        public string Nummer
        {
            get
            {
                return _nummer.Aggregate("", (current, i) => current + i.ToString());
            }
            set
            {
                if (value.Any(x => !char.IsNumber(x)))
                    throw new ArgumentException("Eine Ganzzahl darf keine Zeichen oder Buchstaben enthalten!");

                foreach (var c in value)
                    _nummer = _nummer.Concat(new int[] { c - '0' }).ToArray();
            }
        }

        public Bigint()
        {

        }

        public Bigint(string nummer)
        {
            Nummer = nummer;
        }

        public Bigint Addieren(Bigint big)
        {
            var output = "";
            // Größere und kleinere Zahl herausfinden und diese Rückwärts in einem string speichern
            var groeßer = Laenge() <= big.Laenge() ? Umdrehen(big.Nummer) : Umdrehen(Nummer);
            var kleiner = Laenge() <= big.Laenge() ? Umdrehen(Nummer) : Umdrehen(big.Nummer);

            var index = 0;
            var rest = 0;
            while (index < groeßer.Length)
            {
                (int zusatz, int zahl) ergerbnis = index < kleiner.Length ?
                    AdditionMitRest(10, kleiner[index] - '0', groeßer[index] - '0', rest) :
                    AdditionMitRest(10, groeßer[index] - '0', rest);

                rest = ergerbnis.zusatz;
                output += ergerbnis.zahl;

                index++;
            }

            if (rest != 0)
            {
                output += rest;
            }

            return new Bigint(Umdrehen(output));
        }

        public int Laenge()
        {
            return _nummer.Length;
        }

        private (int rest, int zahl) AdditionMitRest(int basis, params int[] zahlen)
        {
            // Nimmt eine Zahl als Basis entgegen und beliebig viele andere Ganzzahlen und addiert diese
            int summe = 0, rest = 0, zahl = 0;
            summe += zahlen.Sum();

            // Summe der Addition ist größer als die Basis => Rest Summe / Basis und die eigentlich Zahl Summe % Basis
            if (summe >= basis)
            {
                rest = summe / basis;
                zahl = summe % basis;
            }
            else
            {
                rest = 0;
                zahl = summe;
            }

            return (rest, zahl);
        }

        private string Umdrehen(string s)
        {
            // Konvertiert string zu einem char Array um dieses Array Rückwärts als string zurück zu geben
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
