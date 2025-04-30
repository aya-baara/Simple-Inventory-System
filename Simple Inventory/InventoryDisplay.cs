using Simple_Inventory.Interfaces;

namespace SimpleInventory
{
    class InventoryDisplay
    {
        public static void DisplayAllProducts(Inventory inventory)
        {
            foreach (var item in inventory.GetAllProducts())
            {
                System.Console.WriteLine(ProductDisplay.GetProductDetails(item));
            }
        }
    }
}
