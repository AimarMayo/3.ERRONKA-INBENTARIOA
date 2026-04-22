namespace Erronka_Interfazak
{
    public class Erabiltzailea
    {
        private string izena, rola, emaila, pasahitza;
        private Mintegia mintegia;

        public string Izena { get => izena; set => izena = value; }
        public string Rola { get => rola; set => rola = value; }
        public string Emaila { get => emaila; set => emaila = value; }
        public string Pasahitza { get => pasahitza; set => pasahitza = value; }
        public Mintegia Mintegia { get => mintegia; set => mintegia = value; }

        public Erabiltzailea(string izena, string rola, string emaila, string pasahitza, Mintegia mintegia)
        {
            this.izena = izena;
            this.rola = rola;
            this.emaila = emaila;
            this.pasahitza = pasahitza;
            this.mintegia = mintegia;
        }

        public Erabiltzailea(string izena, string rola, string emaila, string pasahitza)
        {
            this.izena = izena;
            this.rola = rola;
            this.emaila = emaila;
            this.pasahitza = pasahitza;
            this.mintegia = new Mintegia();
        }

    }
}
