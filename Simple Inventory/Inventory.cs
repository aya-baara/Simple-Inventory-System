using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory
{
    class Inventory
    {
        private LinkedList<Product> products;
        public Inventory()
        {
            products = new LinkedList<Product>();
        }
        public LinkedList<Product> GetProducts { get { return products; } }
        public void addProduct(Product product)
        {
            products.AddLast(product);
        }
    }
}
