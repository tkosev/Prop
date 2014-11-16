using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarApp.cs
{
    class Drink : Product
    {
       

        public Drink(int productId, string name, int quantity, double price, bool isItSnack, string pathstring)
            :base(productId,name,quantity,price,isItSnack)
        {
            
        }

        

    }
}
