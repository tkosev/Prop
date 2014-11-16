
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System;
using System.Threading.Tasks;

namespace MateriaStand.cs
{
    class MyButton : Button
    {
        private double price;
        public double Price{get { return price; }set { price = value; }}

        private int material_id;
        public int Material_id{get { return material_id; }set { material_id = value; }}

        private string description;
        public string Description{get { return description; }set { description = value; }}

        private DateTime dateWhenBorrowed;
        private DateTime dateWhenReturned;

        public DateTime DateWhenBorrowed { get { return dateWhenBorrowed; } set { dateWhenBorrowed = value; } }
        public DateTime DateWhenReturned { get { return dateWhenReturned; } set { dateWhenReturned = value; } }
    }
}
