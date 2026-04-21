using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erronka_Interfazak
{
    public class Mintegia
    {
        private string izena;
        public string Izena { get => izena; set => izena = value; }
        public Mintegia(string i)
        {
            izena = i;
        }
        public Mintegia() { }
    }
}
