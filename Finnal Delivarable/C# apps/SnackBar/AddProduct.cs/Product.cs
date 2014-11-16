using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarApp.cs
{
    class Product
    {
        private int productId;
        private string name;
        private int quantity;
        private double price;
        private double totprice;
        private string pathstring;

        
        
       // private bool isItSnack; // not needed since we can chack every object from which type it is (is)
        
        
        public int ProductId  { get { return productId; } set { productId = value; } }
        public string Name    { get { return name; } set { name = value; } }
        public int Quantity   { get { return quantity ; } set { quantity = value; } }
        public double Price   { get { return price; } set { price = value; } }
        public string Pathstring { get { return pathstring; } set { pathstring = value; } }

       // public bool IsItSnack    { get { return isItSnack; } set { isItSnack = value; } }

        public Product(int productId, string name, int quantity,double price,bool isItSnack)
        {
            this.productId = productId;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
           
           // this.isItSnack = isItSnack;
        }
        public override string ToString()
        {
            return "ProductId : " + productId + "," + " Name :" + name + ", " + "Price :" + price+ "pathstring: "+ pathstring;
        }
        public Double TotalPrice(int quanlity)
        {
            this.totprice += Convert.ToDouble(this.price * quanlity);
            return this.totprice;
        }

    }
}
