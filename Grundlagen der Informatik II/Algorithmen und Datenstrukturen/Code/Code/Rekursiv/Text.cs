using System;

namespace Code.Rekursiv
{
    public static class Text
    {
        public static int BuchstabenZaehlen(string text, char b)
        {
            if (text == string.Empty) // Rekursionsanker
                return 0;

            var c = text[0];
            if (c == b) // Rekursionsschritt
                return 1 + BuchstabenZaehlen(text.Substring(1), b);
            else
                return BuchstabenZaehlen(text.Substring(1), b);
        }
    }
}
