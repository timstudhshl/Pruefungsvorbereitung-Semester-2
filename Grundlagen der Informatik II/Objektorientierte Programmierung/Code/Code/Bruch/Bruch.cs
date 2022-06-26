using System;

namespace Code.Bruch
{
    /// <summary>
    /// Diese Klasse bildet einen Bruch mit hilfe von zwei Integern ab.
    /// </summary>
    internal class Bruch : Ausfuehrbar
    {
        private int _zaehler;
        private int _nenner;

        public override void Ausfuehren()
        {
            var bruch1 = new Bruch(5, 10);
            Console.WriteLine("Bruch 1:");
            bruch1.Ausgeben();
            var kehrwert = bruch1.BildeKehrwert();
            Console.WriteLine("Kehrwert von Bruch 1:");
            kehrwert.Ausgeben();
            Console.WriteLine();

            var bruch2 = new Bruch(10, 5);
            Console.WriteLine("Bruch 2:");
            bruch2.Ausgeben();
            Console.WriteLine("Bruch 2 als Dezimalzahl:");
            Console.WriteLine(bruch2.Dezimal);
            Console.WriteLine();

            Console.WriteLine("Bruch 1 multipliziert mit 4:");
            bruch1.Multiplizieren(4).Ausgeben();
            Console.WriteLine("Bruch 1 multipliziert mit Bruch 2:");
            bruch1.Multiplizieren(bruch2).Ausgeben();
            Console.WriteLine();

            Console.WriteLine("Bruch 1 dividiert mit 9:");
            bruch1.Dividieren(9).Ausgeben();
            Console.WriteLine("Bruch 2 dividiert mit Bruch 1:");
            bruch2.Dividieren(bruch1).Ausgeben();
            Console.WriteLine();
        }

        public Bruch()
        {

        }

        public Bruch(int zaehler, int nenner)
        {
            _zaehler = zaehler;
            _nenner = nenner;
        }

        public int GetZaehler()
        {
            return _zaehler;
        }
        public void SetZaehler(int zaehler)
        {
            _zaehler = zaehler;
        }

        public int GetNenner()
        {
            return _nenner;
        }
        public void SetNenner(int nenner)
        {
            if (nenner != 0)
                _nenner = nenner;
        }

        public int Zaehler
        {
            get => _zaehler;
            set => _zaehler = value;
        }

        public int Nenner
        {
            get => _nenner;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Nenner darf nicht 0 sein!");
                _nenner = value;
            }
        }

        public double Dezimal => (double)Zaehler / Nenner;

        public Bruch BildeKehrwert()
        {
            return new Bruch(Nenner, Zaehler);
        }

        public Bruch Multiplizieren(int zahl)
        {
            return new Bruch(Zaehler * zahl, Nenner);
        }

        public Bruch Multiplizieren(Bruch bruch)
        {
            return new Bruch(Zaehler * bruch.Zaehler, Nenner * bruch.Nenner);
        }

        public Bruch Dividieren(int zahl)
        {
            return new Bruch(Zaehler, Nenner * zahl);
        }

        public Bruch Dividieren(Bruch bruch)
        {
            var kehrwert = bruch.BildeKehrwert();
            var zaehler = Zaehler * kehrwert.Zaehler;
            var nenner = Nenner * kehrwert.Nenner;

            return new Bruch(zaehler, nenner);
        }

        public void Ausgeben()
        {
            Console.WriteLine($"{Zaehler}/{Nenner}");
        }
    }
}
