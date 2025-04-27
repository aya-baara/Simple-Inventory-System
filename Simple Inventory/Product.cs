
namespace SimpleInventory
{
    public class Product
    {
        public int ID  { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product(int id,string name, int price, int quantity)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
           
        }
    }
}
