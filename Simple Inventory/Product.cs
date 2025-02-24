using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory
{
    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, int price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
     
    

    }
}
