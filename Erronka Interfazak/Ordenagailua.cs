using Erronka_Interfazak;

/// <summary>
/// Ordenagailu baten eredua. Gailua klasearen azpiklasea da eta RAM, ROM eta CPU datuak gehitzen ditu.
/// </summary>
public class Ordenagailua : Gailua
{
    private int ram, rom;
    private string cpu;

    /// <summary>Ordenagailuaren RAM memoria MB-tan.</summary>
    public int Ram { get => ram; set => ram = value; }

    /// <summary>Ordenagailuaren ROM memoria MB-tan.</summary>
    public int Rom { get => rom; set => rom = value; }

    /// <summary>Ordenagailuaren prozesadorearen modeloa.</summary>
    public string Cpu { get => cpu; set => cpu = value; }

    /// <summary>
    /// Ordenagailua sortzen du oinarrizko gailuaren datuak eta datu espezifikoekin.
    /// </summary>
    /// <param name="m">Marka.</param>
    /// <param name="k">Kokalekua.</param>
    /// <param name="e">Egoera.</param>
    /// <param name="ed">Eroste data.</param>
    /// <param name="ram">RAM memoria MB-tan.</param>
    /// <param name="rom">ROM memoria MB-tan.</param>
    /// <param name="cpu">Prozesadorearen modeloa.</param>
    public Ordenagailua(string m, string k, string e, DateTime ed, int ram, int rom, string cpu)
        : base(m, k, e, ed)
    {
        this.ram = ram;
        this.rom = rom;
        this.cpu = cpu;
    }
}