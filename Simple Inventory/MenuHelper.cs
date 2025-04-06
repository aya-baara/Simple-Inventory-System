using SimpleInventory;


namespace SimpleInventory
{
    class MenuHelper
    {
        public static ProductService productService = new ProductService();
        public static void AddProduct()
        {
            Console.Write("Enter product ID (number): ");
            if (!int.TryParse(Console.ReadLine(), out int ID))
            {
                Console.WriteLine("Invalid ID! Product not added.");
                return;
            }
            if (productService.CheckProdutDuplication(ID))
            {
                Console.WriteLine($"Product {ID} already exist.");
                return;
            }
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product price(number): ");
            if (!int.TryParse(Console.ReadLine(), out int price))
            {
                Console.WriteLine("Invalid price! Product not added.");
                return;
            }

            Console.Write("Enter product quantity(number): ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Invalid quantity! Product not added.");
                return;
            }

            productService.AddProduct(ID, name, price, quantity);
            Console.WriteLine("Product added successfully!");
        }

        public static void ViewAllProducts()
        {
            Console.WriteLine("\n=== Inventory List ===");
            InventoryDisplay.DisplayAllProducts(productService.Inventory);
        }

        public static void EditProduct()
        {
            Console.Write("Enter product ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int ID))
            {
                Console.WriteLine("Invalid ID! Enter number.");
                return;
            }
            if (!productService.CheckProdutDuplication(ID))
            {
                Console.WriteLine("Product doesn't exist.");
                return;
            }

            Console.WriteLine("Enter the new name (or enter 0 to skip): ");
            string newName = Console.ReadLine();
            if (newName == "0") newName = null;

            Console.WriteLine("Enter the new price (or enter 0 to skip): ");
            if (!int.TryParse(Console.ReadLine(), out int newPrice) || newPrice == 0)
            {
                newPrice = -1;
            }

            Console.WriteLine("Enter the new quantity (or enter 0 to skip): ");
            if (!int.TryParse(Console.ReadLine(), out int newQuantity) || newQuantity == 0)
            {
                newQuantity = -1;
            }

            bool updated = productService.EditProduct(ID, newName, newPrice, newQuantity);

            if (updated)
            {
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product update failed!");
            }
        }


        public static void DeleteProduct()
        {
            Console.Write("Enter product ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int ID))
            {
                Console.WriteLine("Invalid ID! enter number.");
                return;
            }
            if (!productService.CheckProdutDuplication(ID))
            {
                Console.WriteLine("product doesn't exist.");
                return;
            }
            productService.DeleteProduct(ID);
        }

        public static void SearchProduct()
        {
            Console.Write("Enter product ID to search: ");
            if (!int.TryParse(Console.ReadLine(), out int ID))
            {
                Console.WriteLine("Invalid ID! enter number.");
                return;
            }
            if (!productService.CheckProdutDuplication(ID))
            {
                Console.WriteLine("product doesn't exist.");
                return;
            }

            Console.WriteLine(productService.SearchProduct(ID));
        }
    }
}
