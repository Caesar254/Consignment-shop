using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShop_Library
{
    public class Item
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } // decimal data type is associated with currency
        public bool Sold { get; set; }
        public bool PaymentDistributed { get; set; }
        public Vendor Owner { get; set; }  // to associate each item to vendor
                                           // type vendor
    }
}
