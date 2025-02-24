﻿
namespace SimpleInventory
{
       class Inventory
       {
        public Dictionary<int, Product> Products { get; }
        public Inventory()
        {
            Products = new Dictionary<int, Product>();
        }

        public bool AddProduct(Product product)
        {
            if (Products.ContainsKey(product.ID))
            {
                Console.WriteLine($"Product '{product.ID}' already exists. Not added.");
                return false;
            }
            else
            {
                Products.Add(product.ID, product);
                return true;
            }
        }


        public Product searchProduct(int ID)
        {
            if (Products.ContainsKey(ID))
            {
                return Products[ID]; 
            }
            return null; 
        }

        public bool editProduct(Product modifiedProduct,int ID)
        {
           Product product = searchProduct(ID);
            if (product != null)
            {
                if (modifiedProduct.Name != null)
                {
                    product.Name = modifiedProduct.Name;
                }
                if (modifiedProduct.Price != -1)
                {
                    product.Price = modifiedProduct.Price;
                }
                if (modifiedProduct.Quantity != -1)
                {
                    product.Quantity = modifiedProduct.Quantity;
                }
                return true;

            }
            return false;


        }

        public bool deleteProduct (int ID)
        {
            if (Products.ContainsKey(ID)) {
                Products.Remove(ID);
                return true;
            }
            return false;
        }
    }

}
