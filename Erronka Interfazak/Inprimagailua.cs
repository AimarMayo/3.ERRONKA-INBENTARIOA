using Erronka_Interfazak;

/// <summary>
/// Inprimagailu baten eredua. Gailua klasearen azpiklasea da eta koloretako inprimaketa-gaitasuna gehitzen du.
/// </summary>
public class Inprimagailua : Gailua
{
    private bool koloretakoa;

    /// <summary>Inprimagailuak koloretako inprimaketa egiten duen adierazten du.</summary>
    public bool Koloretakoa { get => koloretakoa; set => koloretakoa = value; }

    /// <summary>
    /// Inprimagailua sortzen du oinarrizko gailuaren datuak eta kolore-gaitasunarekin.
    /// </summary>
    /// <param name="m">Marka.</param>
    /// <param name="k">Kokalekua.</param>
    /// <param name="e">Egoera.</param>
    /// <param name="ed">Eroste data.</param>
    /// <param name="koloretakoa"><c>true</c> koloretakoa bada; <c>false</c> zuri-beltzekoa bada.</param>
    public Inprimagailua(string m, string k, string e, DateTime ed, bool koloretakoa)
        : base(m, k, e, ed)
    {
        this.koloretakoa = koloretakoa;
    }
}
