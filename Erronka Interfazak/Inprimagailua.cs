using Erronka_Interfazak;

public class Inprimagailua : Gailua
{
    private bool koloretakoa;

    public bool Koloretakoa { get => koloretakoa; set => koloretakoa = value; }

    public Inprimagailua(string m, string k, string e, DateTime ed, bool koloretakoa)
        : base(m, k, e, ed)
    {
        this.koloretakoa = koloretakoa;
    }
}
