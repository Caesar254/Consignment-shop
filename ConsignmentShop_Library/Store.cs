using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShop_Library
{
    public class Store
    {
        public string Name { get; set; }
        public List<Vendor> Vendors { get; set; }  // we are going to have more than 1 vendor
        public List<Item> Items { get; set; }// more than 1 item
                                             // the store is associated with list of vendors and list of items 
    }
}
