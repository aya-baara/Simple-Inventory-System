

namespace SimpleInventory
{
    class InventoryDisplay
    {
        public static void DisplayAllProducts(Inventory inventory)
        {
            foreach (var item in inventory.Products)
            {
                System.Console.WriteLine(ProductDisplay.GetProductDetails(item.Value));
            }
        }
    }
}
