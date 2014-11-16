using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaStand.cs
{
    class StorageDevice : Material
    {
        private int size;

        public int Size { get { return size; } set { size = value; } }

        public StorageDevice(int material_id, string name, double price, DateTime dateWhenBorrowed, DateTime dateWhenReturned,string description, int size)
            :base(material_id,name,price,dateWhenBorrowed,dateWhenReturned,description)
        {
            this.size = size;

        }

    }
}
