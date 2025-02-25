

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
            return Inventory.SearchProduct(ID)!=null;
           
        }

        public void AddProduct(int ID,String name,int price,int quantity)
        {
            Product product = new Product(ID, name, price, quantity);
            Inventory.AddProduct(product);
        }

        public void DeleteProduct(int ID)
        {
            Inventory.DeleteProduct(ID);
        }

        public String SearchProduct(int ID)
        {
            Product product = Inventory.SearchProduct(ID);
            if (product != null)
            {
                return $"product found {ProductDisplay.GetProductDetails(product)}";
            }
            else
            {
                return "Product not found";
            }
        }

        internal bool EditProduct(int id, String newName, int newPrice, int newQuantity)
        {
            Product modifiedProduct = new Product(id, newName, newPrice, newQuantity);
            return Inventory.EditProduct(modifiedProduct, id);
        }
    }
}
