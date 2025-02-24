using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventory
{
    class Product
    {
        public int ID  { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product(int Id,string name, int price, int quantity)
        {
            ID = Id;
            Name = name;
            Price = price;
            Quantity = quantity;
           
        }
        public Product(int Id)
        {
            ID = Id;
        }





    }
}
