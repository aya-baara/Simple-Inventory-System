using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventory
{
    class ProductService
    {

        public Inventory Inventory { get; set; }
        public ProductService()
        {
            Inventory = new Inventory();
        }
        public bool CheckProdutDuplication(int ID)
        {
            return Inventory.searchProduct(ID)!=null;
           
        }

        public void AddProduct(int ID,String name,int price,int quantity)
        {
            Product product = new Product(ID, name, price, quantity);
            Inventory.AddProduct(product);
        }

        public void DeleteProduct(int ID)
        {
            Inventory.deleteProduct(ID);
        }

        public String SearchProduct(int ID)
        {
            Product product = Inventory.searchProduct(ID);
            if (product != null)
            {
                return $"product found {ProductDisplay.GetProductDetails(product)}";
            }
            else
            {
                return "Product not found";
            }
        }

        internal bool editProduct(int ID, String newName, int newPrice, int newQuantity)
        {
            Product modifiedProduct = new Product(ID, newName, newPrice, newQuantity);
            return Inventory.editProduct(modifiedProduct, ID);
        }
    }
}
