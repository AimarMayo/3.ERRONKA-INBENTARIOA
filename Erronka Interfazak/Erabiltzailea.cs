namespace Erronka_Interfazak
{
    /// <summary>
    /// Sistemako erabiltzaile baten eredua. Langileak eta administratzaileak biltzen ditu.
    /// </summary>
    public class Erabiltzailea
    {
        private string izena, rola, emaila, pasahitza;
        private Mintegia mintegia;

        /// <summary>Erabiltzailearen izen osoa.</summary>
        public string Izena { get => izena; set => izena = value; }

        /// <summary>Erabiltzailearen rola (Administratzailea, Mintegiburua, Irakaslea...).</summary>
        public string Rola { get => rola; set => rola = value; }

        /// <summary>Erabiltzailearen helbide elektronikoa. Saioa hasteko erabiltzen da.</summary>
        public string Emaila { get => emaila; set => emaila = value; }

        /// <summary>Erabiltzailearen pasahitza.</summary>
        public string Pasahitza { get => pasahitza; set => pasahitza = value; }

        /// <summary>Erabiltzailea lotuta dagoen mintegia.</summary>
        public Mintegia Mintegia { get => mintegia; set => mintegia = value; }

        /// <summary>
        /// Erabiltzailea sortzen du mintegiarekin.
        /// </summary>
        /// <param name="izena">Erabiltzailearen izena.</param>
        /// <param name="rola">Erabiltzailearen rola.</param>
        /// <param name="emaila">Helbide elektronikoa.</param>
        /// <param name="pasahitza">Pasahitza.</param>
        /// <param name="mintegia">Lotutako mintegia.</param>
        public Erabiltzailea(string izena, string rola, string emaila, string pasahitza, Mintegia mintegia)
        {
            this.izena = izena;
            this.rola = rola;
            this.emaila = emaila;
            this.pasahitza = pasahitza;
            this.mintegia = mintegia;
        }

        /// <summary>
        /// Erabiltzailea sortzen du mintegirik gabe (mintegia hutsarekin hasieratzen da).
        /// </summary>
        /// <param name="izena">Erabiltzailearen izena.</param>
        /// <param name="rola">Erabiltzailearen rola.</param>
        /// <param name="emaila">Helbide elektronikoa.</param>
        /// <param name="pasahitza">Pasahitza.</param>
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
