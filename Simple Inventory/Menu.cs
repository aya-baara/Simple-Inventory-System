

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
                        AddProduct();
                        break;
                    case "2":
                        ViewAllProducts();
                        break;
                    case "3":
                        EditProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        SearchProduct();
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

        private void AddProduct()
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

        private void ViewAllProducts()
        {
            Console.WriteLine("\n=== Inventory List ===");
            InventoryDisplay.DisplayAllProducts(productService.Inventory);
        }

        private void EditProduct()
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

            bool updated = productService.editProduct(ID, newName, newPrice, newQuantity);

            if (updated)
            {
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product update failed!");
            }
        }


        private void DeleteProduct()
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

        private void SearchProduct()
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
