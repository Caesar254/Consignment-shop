
using ConsignmentShop_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ConsignmentShop_UI
{
    public partial class ConsignmentShop : Form
    {

        private Store store = new Store();
        //private Vendor vendor = new Vendor();
        //list for shopping cart
        private List<Item> shoppingCartData = new List<Item>(); //empty list

        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorBinding = new BindingSource();

        private decimal storeProfit = 0;



        public ConsignmentShop()
        {
            InitializeComponent();
            SetUpData();

            itemsBinding.DataSource = store.Items.Where(x=> x.Sold == false).ToList();// links items to our items
            itemsListBox.DataSource = itemsBinding;

            itemsListBox.DisplayMember = "Display"; // from the display function
            itemsListBox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartData;
            shoppingCartListBox.DataSource = cartBinding;

            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";

            vendorBinding.DataSource = store.Vendors;
            vendorListBoxLabel.DataSource = vendorBinding;

            vendorListBoxLabel.DisplayMember = "Display";
            vendorListBoxLabel.ValueMember = "Display";

        }
        private void SetUpData()
        {
            //Vendor demoVendor = new Vendor();
            //demoVendor.FirstName = "Bray";
            //demoVendor.LastName = "Wyat";
            //demoVendor.Commission = .5;

            //store.Vendor.Add(demoVendor);// add it to the list

            // demoVendor = new Vendor(); // re instantiate to create a new person
            //demoVendor.FirstName = "Sue";
            //demoVendor.lastName = "Murpphy";
            //demoVendor.Commision = .6;

            //store.Vendors.Add(demoVendor);
            store.Vendors.Add(new Vendor { FirstName = "Gerald", LastName = "Smith", Commission = .4 });
            store.Vendors.Add(new Vendor { FirstName = "Mary", LastName = "Linn" });

            store.Items.Add(new Item
            {
                Title = "Moby Dick",
                Description = "Book about Whales",
                Price = 1000.50M,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "A Tale of Two Cities",
                Description = "Book about Revelotion",
                Price = 2100.60M,
                Owner = store.Vendors[1]
            });
            store.Items.Add(new Item
            {
                Title = "The River and the Source ",
                Description = "Book about Family tree",
                Price = 900.80M,
                Owner = store.Vendors[1]
            });
            store.Items.Add(new Item
            {
                Title = "Caucasian Chalk Circle",
                Description = "Book about Conflict",
                Price = 4050.40M,
                Owner = store.Vendors[0]
            });
            store.Name = "Seasons Galaxies";
        }

        private void ConsignmentShop_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void itemsListBoxLabel_Click(object sender, EventArgs e)
        {

        }

        private void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            //figure out what is selectd from the item list
            // copy that item to the shoppping cart
            // do we remove the item from the item list? - no.
            Item selectedItem = (Item)itemsListBox.SelectedItem;

            shoppingCartData.Add(selectedItem);
            cartBinding.ResetBindings(false);
        }

        private void shoppingCartListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            // Mark each item in the list as sold
            // clear the cart

            foreach(Item item in shoppingCartData)
            {
                item.Sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.Commission * item.Price;
                storeProfit += (1 - (decimal)item.Owner.Commission) * item.Price;
            }
            shoppingCartData.Clear();

            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();

            storeProfitValue.Text = string.Format("Ksh {0}", storeProfit);

            cartBinding.ResetBindings(false);
            itemsBinding.ResetBindings(false);
            vendorBinding.ResetBindings(false);
        }
    }
}
