using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaStand.cs
{
    class Laptop : Material
    {
        private string brand;

        public string Brand{get { return brand; } set { brand = value; }}


        public Laptop(int material_id, string name, double price, DateTime dateWhenBorrowed, DateTime dateWhenReturned,string description, string brand)
            : base(material_id, name, price, dateWhenBorrowed, dateWhenReturned,description)
        {
            this.brand = brand;
        }
    }
}
