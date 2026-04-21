using Erronka_Interfazak;

public class Ordenagailua : Gailua
{
    private int ram, rom;
    private string cpu;

    public int Ram { get => ram; set => ram = value; }
    public int Rom { get => rom; set => rom = value; }
    public string Cpu { get => cpu; set => cpu = value; }

    public Ordenagailua(string m, string k, string e, DateTime ed, int ram, int rom, string cpu)
        : base(m, k, e, ed)
    {
        this.ram = ram;
        this.rom = rom;
        this.cpu = cpu;
    }
}