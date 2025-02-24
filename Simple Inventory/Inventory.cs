using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory
{
       class Inventory
       {
        Dictionary<int, Product> products;
        public Inventory()
        {
            products = new Dictionary<int, Product>();
        }

        public Dictionary<int, Product> GetProducts { get { return products; } }

        public bool AddProduct(Product product)
        {
            if (products.ContainsKey(product.ID))
            {
                Console.WriteLine($"Product '{product.ID}' already exists. Not added.");
                return false;
            }
            else
            {
                products.Add(product.ID, product);
                return true;
            }
        }

        public void ViewAllProduct()
        {
            foreach (var item in products)
            {
                System.Console.WriteLine(ProductDisplay.GetProductDetails(item.Value));
            }
        }

        public Product searchProduct(int ID)
        {
            if (products.ContainsKey(ID))
            {
                return products[ID]; 
            }
            return null; 
        }

        //public bool editProduct(Product modifiedProduct,String productName)
        //{
        //    LinkedListNode<Product> product = searchProduct(productName);
        //    if (product != null)
        //    {
        //        modifiedProduct.Name=
        //    }


        //}

        public bool deleteProduct (int ID)
        {
            if (products.ContainsKey(ID)) {
                products.Remove(ID);
                return true;
            }
            return false;
        }
    }

}
