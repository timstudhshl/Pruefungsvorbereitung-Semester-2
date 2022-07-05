# Vorbereitung Algorithmen und Datensturkturen

## Algorithmen:
- besteht aus: endlich vielen, wohldefinierten Handlungsschritten
- Terminierung => Algorithmus benötigt endlich viele Schritte
- Determinismus => Gleiche eingabe führt zu gleichem Ergebnis (Zufallszahl ist nicht deterministisch)

## Halteproblem:
- Kein Alorithmus kann dieses Problem lösen
- Hält das Programm nach endlicher Zeit für Eingabe an?

## Testen:
- Unit-Test (Blackbox-Test) liefert funktion passende Werte
- Brown-Code kann nicht getestet werden
- Debug Later Programming => Erst nach der Entwicklung werden die Test geschrieben, unabschätzbar lang da immer wieder Bugs auftauchen können
- Test Driven Development => Kurz aber oft Testen, Test schreiben bevor eigentlicher Code vorhanden

## Komlexität eines Problems:
- Wie viel Zeit und/oder Speicherplatz wird benötigt
- Effiziez eines Algorithmus => wie sparsam mit Ressourcen
- Komplexitätsklassen (O-Notation)
- Laufzeiteffizienz => wie lange dauert es bis Ergebnis gibt
    - worst case => schlechtester Fall
    - average case => durchschnittlicher Fall
    - best case => bester Fall
- Eingabegrößte => Variable ***n***
- Zeitkomplexität ***T(n)*** => größte Anzahl der elementaren Ausführungsschritte
- Abarbeitungszeit unabhängig von Eingabegröße n => konstanter Faktor (***if***)
- Abarbeitungszeit abhängig von Eingabegröße n => alle Schleifen

## O-Notation:
- ermitteln oberer Schranke
- Rechenregeln:
    - O(c) = 1
    - O(log^b(n)) = O(log n)
    - O(f(n) + g(n)) = O(max(f(n), g(n)))
    - O(f(n) * g(n)) = O(f(n)) * O(g(n))

## Rekursion:
- Funktion bezieht sich auf sich selbst
- kann nicht unendlich sein
- Beispiel:
    - Summe Zahlen von 1 - 100 => sum(n) = sum(n-1) + n für n > 1
        ```c#
        public static int Summe(int n) 
        {
            if (n == 0) // Rekursionsanker
                return 0; 
            
            return n + Summe(n - 1); // Rekursionsschritt
        }
        ```
    - Fakultät (Lineare-Rekursion):
        ```c#
        public static int Fakultaet(int n)
        {
            if (n == 0) // Rekursionsanker
                return 1; 

            return n * Fakultaet(n - 1); // Rekursionsschritt
        }
        ```
    - Buchstaben zählen (Lineare-Rekursion):
        ```c#
        public static int BuchstabenZaehlen(string text, char b)
        {
            if (text == String.Empty) // Rekursionsanker
                return 0; 

            var c = text[0];
            if (c == b) // Rekursionsschritt
                return 1 + BuchstabenZaehlen(text.Substring(1), b);
            else
                return BuchstabenZaehlen(text.Substring(1), b);
        }
        ```
    - Fibonacci (Baum-Rekursion):
        ```c#
        public static int Fibonacci(int n)
        {
            if (n < 3) // Rekursionsanker
                return 1;
            
            return Fibonacci(n - 2) + Fibonacci(n - 1); // Rekursionsschritt
        }
        ```
    - Quersumme (Lineare-Rekursion):
        ```c#
        public static int Quersumme(int n)
        {
            if (n < 10) // Rekursionsanker
                return n;

            return n % 10 + Quersumme(n / 10); // Rekursionsschritt
        }
        ```
    - Turm von Hanoi (Baum-Rekursion):
        ```c#
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
        ```

## Stack / Verkettete Liste:
- First in First out (ToDo-Liste)
    - vorne dran hängen
    - von vorne weg nehmen

![FIFO](https://www.prologistik.com/fileadmin/user_upload/36_FIFO_Logistik-Lexikon.jpg)

- Last in First out (Kasseschlange)
    - hinten dran hängen
    - von vorne weg nehmen

![LIFO](https://www.prologistik.com/fileadmin/user_upload/37_LIFO_Logistik-Lexikon.jpg)

## Suche (linear):
- Günstigster Fall
    - gesuchte Element ist am Anfang => 1 Vergleich
- Ungünstigster Fall
    - gesuchte Element ist am Ende => n Vergleiche
    - lineare Suche => O(n)
- Durchschnittlicher Fall
    - gesuchte Element ist in der Mitte => ca n/2 Vergleiche
- Selbstorganisierende List
    - Element wird nach erfolgreicher Suche nach vorne verschoben 
    - bei nächster Suche nach gleichem Element wird es direkt gefunden
- Einfügen/Löschen im Fokus nicht Suche

## Suche (binär):
- Liste muss aufstreigend oder absteigend sortiert sein
- Liste in 2 gleich große Teile aufteilen
    - in den Teillisten wird genau so weitergesucht
    - mit dem mittleren Element vergleichen um zu wissen auf welcher Seite gesucht werden muss
- Algorithmus von Typ **Teile-und-Herrsche** (divide and conquer)
- T(n) = log(n + 1) = ln n+1 / ln 2
- Algorithmus der Klasse O(ln n)
- besser als Lineare Liste (linked list)

## Binärer Baum (binary tree)
![Binary Tree](https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Binary_search_tree.svg/1200px-Binary_search_tree.svg.png)
- besteht aus einer Wurzel
- Knoten (außer Wurzel) hat genau ein Vater-Knoten
- Knoten hat höchstens 2 Kindknoten
- Wurzel <-> weiterster Nachfahre => **Höhe des Baums ***h*****
- linkes Kind Wert kleiner/gleich Vater
- rechtes Kind Wert größer Vater
- möglichkeiten der Anordnung des Baumes => n!
- Zeitkomplexität => O(h)
- minimale Höhe des Suchbaums => c * log n
    - **höhenbalanciert** => AVL-Baum

## AVL-Baum
- Kompelxität:
    - Suche: O(log n)
    - Min, Max: O(log n)
    - Einfügen: O(log n)
    - Löschen: O(log n)
- Suche im Fokus nicht Einfügen/Löschen