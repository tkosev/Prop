using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaStand.cs
{
    class Material
    {
        private int material_id;
        private string name;
        private double price;
        private DateTime dateWhenBorrowed;
        private DateTime ?dateWhenReturned;
        private string description;

        
        public int Material_id { get { return material_id; } set { material_id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public double Price { get { return price; } set { price = value; } }
        public DateTime DateWhenBorrowed { get { return dateWhenBorrowed; } set { dateWhenBorrowed = value; } }
        public DateTime ?DateWhenReturned { get { return dateWhenReturned; } set { dateWhenReturned = value; } }
        public string Description{get { return description; }set { description = value; }}

        public Material(int material_id, string name, double price, DateTime dateWhenBorrowed, DateTime ?dateWhenReturned, string description)
        {
            this.material_id = material_id;
            this.name = name;
            this.price = price;
            this.dateWhenBorrowed = dateWhenBorrowed;
            this.dateWhenReturned = dateWhenReturned;
            this.description = description;
        }

        public double totalMaterialPrice()
        {

            return 0;
        }


        public override string ToString()
        {
            return "Id: " + material_id + ", Description: " + description + ", Price: " + price + ", Taken on " + dateWhenBorrowed + ", Return " + dateWhenReturned;
        }
        
    }
}
