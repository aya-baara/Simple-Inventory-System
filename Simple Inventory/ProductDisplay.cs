
namespace SimpleInventory
{
    class ProductDisplay
    {
        public static string GetProductDetails(Product product) {
            return $"ID = {product.ID} Name = {product.Name} , Price = {product.Price} , Quantity={product.Quantity} .";
        }
    }
}
