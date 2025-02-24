using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory
{
    class Menu
    {
        public  Inventory inventory = new Inventory();
        public  void showMenu()
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
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product price: ");
            if (!int.TryParse(Console.ReadLine(), out int price))
            {
                Console.WriteLine("Invalid price! Product not added.");
                return;
            }

            Console.Write("Enter product quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Invalid quantity! Product not added.");
                return;
            }

            Product newProduct = new Product ( name,price,quantity );
            inventory.AddProduct(newProduct);
            Console.WriteLine("Product added successfully!");
        }

        private void ViewAllProducts()
        {
            Console.WriteLine("\n=== Inventory List ===");
            inventory.ViewAllProduct();
        }

        private void EditProduct()
        {
            Console.Write("Enter product name to edit: ");
            string name = Console.ReadLine();
            if (inventory.searchProduct(name) == null)
            {
                Console.Write("product not found ");
                return;
            }

            Console.WriteLine("Select property to edit:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Price");
            Console.WriteLine("3. Quantity");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();
           

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new name: ");
                    String newName = Console.ReadLine();
                    inventory.editProduct(name, ProductProperties.Name, newName, 0);
                    break;
                case "2":
                    Console.Write("Enter new price: ");
                    if (int.TryParse(Console.ReadLine(), out int newPrice))
                        inventory.editProduct(name, ProductProperties.Price, "", newPrice);
                    else
                        Console.WriteLine("Invalid price!");
                    break;
                case "3":
                    Console.Write("Enter new quantity: ");
                    if (int.TryParse(Console.ReadLine(), out int newQuantity))
                        inventory.editProduct(name, ProductProperties.Quantity, "", newQuantity);
                    else
                        Console.WriteLine("Invalid quantity!");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    return;
            }

            Console.WriteLine("Product updated successfully!");
        }

        private void DeleteProduct()
        {
            Console.Write("Enter product name to delete: ");
            string name = Console.ReadLine();

           
            if (inventory.deleteProduct(name)!=-1)
            {
              
                Console.WriteLine("Product deleted successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void SearchProduct()
        {
            Console.Write("Enter product name to search: ");
            string name = Console.ReadLine();

            LinkedListNode<Product> productNode = inventory.searchProduct(name);
            if (productNode != null)
            {
                Console.WriteLine($"\nProduct Found:\n{ProductDisplay.GetProductDetails(productNode.Value)}");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
    }
}
