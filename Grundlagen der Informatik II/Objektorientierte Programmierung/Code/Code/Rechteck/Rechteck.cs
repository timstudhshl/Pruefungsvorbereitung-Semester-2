using System;

namespace Code.Rechteck
{
    internal class Rechteck : Ausfuehrbar, IComparable
    {
        private double _seite1;
        private double _seite2;

        public override void Ausfuehren()
        {
            var rechteck1 = new Rechteck(88, 187);
            Console.WriteLine($"Rechteck 1 hat eine die Maße {rechteck1.Seite1}x{rechteck1.Seite2}.");
            Console.WriteLine($"Damit beträgt der Flächeninhalt {rechteck1.Flaeche}.");
            Console.WriteLine($"Und der Umfang beträgt {rechteck1.Umfang}.");

            var rechteck2 = new Rechteck(5, 10);
        }

        public Rechteck(double seite1, double seite2)
        {
            Seite1 = seite1;
            Seite2 = seite2;
        }

        public double GetSeite1()
        {
            return _seite1;
        }
        public void SetSeite1(double wert)
        {
            if (wert <= 0)
                throw new ArgumentException("Eine Seitenlänge kann nicht kleiner gleich 0 sein!");

            _seite1 = wert;
        }

        public double GetSeite2()
        {
            return _seite2;
        }
        public void SetSeite2(double wert)
        {
            if (wert <= 0)
                throw new ArgumentException("Eine Seitenlänge kann nicht kleiner gleich 0 sein!");

            _seite2 = wert;
        }

        public double Seite1
        {
            get => _seite1;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Eine Seitenlänge kann nicht kleiner gleich 0 sein!");

                _seite1 = value;
            }
        }
        public double Seite2
        {
            get => _seite2;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Eine Seitenlänge kann nicht kleiner gleich 0 sein!");

                _seite2 = value;
            }
        }

        public double Flaeche => Seite1 * Seite2;
        public double Umfang => 2 * Seite1 + 2 * Seite2;

        public override bool Equals(object obj)
        {
            if (!(obj is Rechteck r))
                return false;

            return r.Seite1 == Seite1 && r.Seite2 == Seite2;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return -1;

            if (!(obj is Rechteck r))
                throw new ArgumentException("Übergebene Objekt ist kein Rechteck und kann somit nicht vergleichen werden");

            if (r.Flaeche > Flaeche)
                return 1;
            if (r.Flaeche < Flaeche)
                return -1;

            return 0;
        }
    }
}
