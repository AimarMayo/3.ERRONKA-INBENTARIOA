namespace Erronka_Interfazak
{
    public class Gailua
    {
        private int id;
        private string marka, kokalekua, egoera;
        private DateTime erosteData;

        public int Id { get => id; set => id = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Kokalekua { get => kokalekua; set => kokalekua = value; }
        public string Egoera { get => egoera; set => egoera = value; }
        public DateTime ErosteData1 { get => erosteData; set => erosteData = value; }

        public Gailua(int id, string marka, string kokalekua, string egoera, DateTime erosteData)
        {
            this.id = id;
            this.marka = marka;
            this.kokalekua = kokalekua;
            this.egoera = egoera;
            this.erosteData = erosteData;
        }

        public Gailua(string marka, string kokalekua, string egoera, DateTime erosteData)
        {
            id = 0;
            this.marka = marka;
            this.kokalekua = kokalekua;
            this.egoera = egoera;
            this.erosteData = erosteData;
        }
    }
}
