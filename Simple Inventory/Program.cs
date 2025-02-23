// See https://aka.ms/new-console-template for more information
using Simple_Inventory;


class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        Product product = new Product("Laptop", 1000, 5);
        Product product2 = new Product("Desktop", 1000, 5);

        Console.WriteLine(product.Name); 

        Inventory inventory = new Inventory();
        inventory.AddProduct(product);
        inventory.AddProduct(product2);

        inventory.ViewAllProduct();
    }
}