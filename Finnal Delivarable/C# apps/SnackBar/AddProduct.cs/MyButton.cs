
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarApp.cs
{
    class MyButton : Button
    {
        private double price;
        public double Price { get { return price; } set { price = value; } }

        private int ProductId;
        public int ProductId1{get { return ProductId; }set { ProductId = value; }}

    }
}
