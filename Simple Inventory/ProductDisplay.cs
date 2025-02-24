using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleInventory
{
    class ProductDisplay
    {
        public static String GetProductDetails(Product product) {
            return $"ID = {product.ID} Name = {product.Name} , Price = {product.Price} , Quantity={product.Quantity} .";
        }
    }
}
