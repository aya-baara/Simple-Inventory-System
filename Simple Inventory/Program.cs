// See https://aka.ms/new-console-template for more information
using Simple_Inventory;


class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        Product product = new Product("Laptop", 1000, 5);

        Console.WriteLine(product.Name); 
        product.Name = "Desktop";
        Inventory inventory = new Inventory();
        inventory.addProduct(product);

        // Displaying updated product details
        product.productDetails();  // Product: Desktop, Price: 1000, Quantity: 5
    }
}