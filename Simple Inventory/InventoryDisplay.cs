using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
