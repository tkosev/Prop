using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaStand.cs
{
    class Cables : Material
    {
        private double lenght;

        public double Lenght{get { return lenght; }set { lenght = value; }}

        public Cables(int material_id, string name, double price, DateTime dateWhenBorrowed, DateTime dateWhenReturned, string description, double lenght)
            : base(material_id, name, price, dateWhenBorrowed, dateWhenReturned,description)
        {
            this.lenght = lenght;
        }
    }
}
