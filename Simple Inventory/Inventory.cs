using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory
{
    public enum ProductProparities
    {
        Name,
        Price,
        Quantity
    }
    class Inventory
    {
        private LinkedList<Product> products;
        public Inventory()
        {
            products = new LinkedList<Product>();
        }
        public LinkedList<Product> GetProducts { get { return products; } }
        public void AddProduct(Product product)
        {
            products.AddLast(product);
        }
        public void ViewAllProduct()
        {
            foreach (Product product in products)
            {
                System.Console.WriteLine(product.ProductDetails());
            }
        }
        public LinkedListNode<Product> searchProduct(String name)
        {
            LinkedListNode<Product> current = products.First;
            while (current != null)
            {
                if (current.Value.Name.Equals(name))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
        public Product editProduct(String name, ProductProparities proparities, String s, int num)
        {
            LinkedListNode<Product> product = searchProduct(name);
            if (product != null)
            {
                switch (proparities)
                {
                    case ProductProparities.Name:
                        product.Value.Name = s;
                        break;
                    case ProductProparities.Price:
                        product.Value.Price = num;
                        break;
                    case ProductProparities.Quantity:
                        product.Value.Quantity = num;
                        break;

                }
                return product.Value;


            }
            else
            {
                Console.WriteLine($"Product name {name} not found ");
                return null;
            }
        }

        public int deleteProduct (String name)
        {
            LinkedListNode<Product> product = searchProduct(name);
            if (product != null)
            {
                products.Remove(product);
                return 0;
            }
            return -1;
        }
    }

}
