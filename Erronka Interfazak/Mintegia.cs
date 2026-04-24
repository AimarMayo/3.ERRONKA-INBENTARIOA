using System;

namespace Erronka_Interfazak
{
    public class Mintegia
    {
        private int id;
        private string izena;
        public int Id { get => id; set => id = value; }
        public string Izena { get => izena; set => izena = value; }
        public Mintegia(int id, string i)
        {
            this.id = id;
            izena = i;
        }
        public Mintegia() { }
        public override string ToString() => izena;
    }
}
