using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class CoffeShop : Form
    {
        //List Declaration
        List<string> names = new List<string> { };
        List<string> contacts = new List<string> { };
        List<string> addresses = new List<string> { };
        List<string> orders = new List<string> { };
        List<int> quantities = new List<int> { };
        List<int> prices = new List<int> { };

        //Variable Declaration
        string CustomerName = "";
        string CustomerContact = "";
        string CustomerAddress = "";
        string CustomerOrder = "";
        int CustomerQuantity;
        int CustomerPrice = 0;

        public CoffeShop()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CustomerName = nameTextBox.Text;
            CustomerContact = contactTextBox.Text;
            CustomerAddress = addressTextBox.Text;
            CustomerOrder = itemComboBox.Text;
            //CustomerQuantity = int.Parse(quantityTextBox.Text);

            OrderPrice();
            ClearData();
        }

        //Price Generation
        private void OrderPrice()
        {

            if (!String.IsNullOrEmpty(itemComboBox.Text) && !String.IsNullOrEmpty(quantityTextBox.Text))
            {
                if (itemComboBox.Text == "Black-120")
                {
                    CustomerPrice = int.Parse(quantityTextBox.Text) * 120;
                }
                else if (itemComboBox.Text == "Cold-100")
                {
                    CustomerPrice = int.Parse(quantityTextBox.Text) * 100;
                }
                else if (itemComboBox.Text == "Hot-90")
                {
                    CustomerPrice = int.Parse(quantityTextBox.Text) * 90;
                }
                else if (itemComboBox.Text == "Regular-80")
                {
                    CustomerPrice = int.Parse(quantityTextBox.Text) * 80;
                }


                AddIntoList();
            }
            else
            {
                MessageBox.Show("Select 1 item and quantity!!");
                return;
            }
            OneCustomerDetailsShow();
        }

        //Remove Data from input field
        private void ClearData()
        {
            nameTextBox.Clear();
            contactTextBox.Clear();
            addressTextBox.Clear();
            itemComboBox.SelectedIndex = -1;
            quantityTextBox.Clear();
        }

        //Show One Customer's Detail
        private void OneCustomerDetailsShow()
        {
            displayRichTextBox.AppendText("\n------------\nName: " + CustomerName + "\nContact: " + CustomerContact + "\nAdress: " + CustomerAddress +
                "\nItem: " + CustomerOrder + "\nQuantity: " + int.Parse(quantityTextBox.Text)
                + "\nPrice: " + Convert.ToString(CustomerPrice) + "\n\n------------------");

        }

        //Add Data into List
        private void AddIntoList()
        {
            names.Add(CustomerName);
            contacts.Add(CustomerContact);
            addresses.Add(CustomerAddress);
            orders.Add(CustomerOrder);
            quantities.Add(int.Parse(quantityTextBox.Text));
            prices.Add(CustomerPrice);
        }

        //Show All Customers Detail
        private void ShowAll()
        {
            displayRichTextBox.Clear();
            string AllCustomer = "";
            for (int i = 0; i < names.Count(); i++)
            {
                AllCustomer += "\n------------\nName: " + names[i] + "\nContact: " + contacts[i] + "\nAdress: " + addresses[i] +
                "\nItem: " + orders[i] + "\nQuantity: " + quantities[i]
                + "\nPrice: " + Convert.ToString(prices[i]) + "\n\n------------------";
            }

            displayRichTextBox.AppendText(AllCustomer);
        }
    }
}
