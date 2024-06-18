using Model;
using Model.Enums;
using Service;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class AddMenuItem : Form
    {
        private MenuItemService menuItemService;

        public AddMenuItem()
        {
            InitializeComponent();
            menuItemService = new MenuItemService();

            
            categoryComboBox.DataSource = Enum.GetValues(typeof(Categories));
            typeComboBox.DataSource = Enum.GetValues(typeof(MenuTypes));
            alchoholicComboBox.Items.Add("Alcoholic");
            alchoholicComboBox.Items.Add("Alcohol-free");
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            try
            {

                int id = int.Parse(iDTextbox.Text);
                string name = nameTextBox.Text;
                Categories selectedCategory = (Categories)categoryComboBox.SelectedItem;
                int stock = int.Parse(stockTextBox.Text);
                decimal price = decimal.Parse(priceTextBox.Text);
                decimal tax = decimal.Parse(taxTextBox.Text);
                MenuTypes menuTypes = (MenuTypes)typeComboBox.SelectedItem;

                bool alcoholic;
                if (alchoholicComboBox.SelectedItem.ToString() == "Alcoholic")
                {
                    alcoholic = true;
                }
                else
                {
                    alcoholic = false;
                }

                MenuItem menuItem = new MenuItem(id, name, selectedCategory, price, tax, stock, menuTypes, alcoholic);
                menuItemService.AddMenuItem(menuItem);


                MessageBox.Show("Menu item added successfully.");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for ID, Stock, Price, and Tax.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while adding menu item: " + ex.Message);
            }
        }
    }
}
