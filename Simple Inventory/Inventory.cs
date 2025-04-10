﻿
namespace SimpleInventory
{
       class Inventory
       {
            private Dictionary<int, Product> products = new Dictionary<int, Product>();
            public IReadOnlyDictionary<int, Product> Products => products;

            public Inventory()
                {
                    products = new Dictionary<int, Product>();
                }

            public bool AddProduct(Product product)
            {
                if (products.ContainsKey(product.ID))
                {
                    return false;
                }
                else
                {
                    products.Add(product.ID, product);
                    return true;
                }
            }


            public Product? SearchProduct(int id)
            {
                return products.GetValueOrDefault(id, null);
            }

            public bool EditProduct(Product modifiedProduct,int id)
            {
               Product product = SearchProduct(id);
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

            public bool DeleteProduct (int id)
            {
                
                return products.Remove(id); ;
            }
        }

}
