using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erronka_Interfazak
{
    public class Gailua
    {
        private string marka, kokalekua, egoera;
        private DateTime ErosteData;

        public string Marka { get => marka; set => marka = value; }
        public string Kokalekua { get => kokalekua; set => kokalekua = value; }
        public string Egoera { get => egoera; set => egoera = value; }
        public DateTime ErosteData1 { get => ErosteData; set => ErosteData = value; }

        public Gailua(string m, string k, string e, DateTime ed)
        {
            marka = m;
            kokalekua = k;
            egoera = e;
            ErosteData = ed;
        }
        Gailua() { }
    }
}
