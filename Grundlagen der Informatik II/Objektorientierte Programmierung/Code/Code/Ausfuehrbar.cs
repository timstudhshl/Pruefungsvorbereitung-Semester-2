namespace Code
{

    /// <summary>
    /// Abstrakte Klasse, welche von den einzelnen Aufgaben implementiert werden können.
    /// Dadurch kann man einfacher in der "Program.cs" die einzelnen Übungen ausführen
    /// und hat einen organisierten Code.
    /// </summary>
    internal abstract class Ausfuehrbar
    {
        public abstract void Ausfuehren();
    }
}
