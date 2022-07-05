namespace Code.Rekursiv
{
    public static class Zahlen
    {
        public static int Summe(int n)
        {
            if (n == 0) // Rekursionsanker
                return 0;

            return n + Summe(n - 1); // Rekursionsschritt
        }

        public static int Fakultaet(int n)
        {
            if (n == 0) // Rekursionsanker
                return 1;

            return n * Fakultaet(n - 1); // Rekursionsschritt
        }

        public static int Fibonacci(int n)
        {
            if (n < 3) // Rekursionsanker
                return 1;

            return Fibonacci(n - 2) + Fibonacci(n - 1); // Rekursionsschritt
        }

        public static int Quersumme(int n)
        {
            if (n < 10) // Rekursionsanker
                return n;

            return n % 10 + Quersumme(n / 10); // Rekursionsschritt
        }
    }
}
