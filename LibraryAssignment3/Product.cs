using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAssignment3
{
    public class Product
    {
        public Product(int productID, string productName, float unitPrice, int quantity)
        {
            ProductID = productID;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
        public Product()
        {

        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float GetSubTotal()
        {
            return this.UnitPrice * this.Quantity;
        }
    }
}
