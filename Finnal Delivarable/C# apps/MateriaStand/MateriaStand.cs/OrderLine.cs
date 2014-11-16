using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaStand.cs
{
    class OrderLine
    {

        private int order_line_id;
        private string name;
        private Material material;
        private int product_id;
        private double price;
        private int quantity;
        private int materialID;
        private MaterialStand stand = new MaterialStand();

        public int Order_id { get { return order_line_id; } set { order_line_id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public double Price { get { return price; } set { price = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public Material Material { get { return material; } set { material = value; } }
        public int Product_id { get { return product_id; } set { product_id = value; } }
        public int MaterialID { get { return materialID; } set { materialID = value; } }
       
        public OrderLine(string nm, double price, Material mater)
        {
            this.order_line_id = stand.GetOrderID();
            this.name = nm;
            this.price = price;
            this.material = mater;


        }
        public OrderLine(string nm, double price)
        {
            this.order_line_id = stand.GetOrderID();
            this.name = nm;
            this.price = price;
            


        }
        public string AsString()
        {
            return "ID: " + order_line_id + " Name: " + name + " Price: " + price; 

        }
        
    }
}
