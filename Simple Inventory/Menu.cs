
using SimpleInventory;

namespace SimpleInventory
{
    class Menu
    {
        public Inventory inventory = new Inventory();
        public ProductService productService = new ProductService();
        public void showMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Simple Inventory Management System ===");
                Console.WriteLine("1. Add a Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Edit a Product");
                Console.WriteLine("4. Delete a Product");
                Console.WriteLine("5. Search for a Product");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option (1-6): ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        MenuHelper.AddProduct();
                        break;
                    case "2":
                        MenuHelper.ViewAllProducts();
                        break;
                    case "3":
                        MenuHelper.EditProduct();
                        break;
                    case "4":
                        MenuHelper.DeleteProduct();
                        break;
                    case "5":
                        MenuHelper.SearchProduct();
                        break;
                    case "6":
                        Console.WriteLine("Exiting... Thank you!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 6.");
                        break;
                }
            }
        }

       

    }
}
