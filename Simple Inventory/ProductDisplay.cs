
namespace SimpleInventory
{
    class ProductDisplay
    {
        public static String GetProductDetails(Product product) {
            return $"ID = {product.ID} Name = {product.Name} , Price = {product.Price} , Quantity={product.Quantity} .";
        }
    }
}
