using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erronka_Interfazak
{
    public class Erabiltzailea
    {
        private string izena, rola, emaila, pasahitza;

        public string Izena { get => izena; set => izena = value; }
        public string Rola { get => rola; set => rola = value; }
        public string Emaila { get => emaila; set => emaila = value; }
        public string Pasahitza { get => pasahitza; set => pasahitza = value; }

        public Erabiltzailea(string i, string r, string e, string p)
        {
            izena = i;
            rola = r;
            emaila = e;
            pasahitza = p;
        }
        public Erabiltzailea() { }
    }
}
