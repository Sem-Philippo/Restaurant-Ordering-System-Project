using Model;
using Model.Enums;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class UpdateMenuItem : Form
    {
        private MenuItemService service;
        private MenuTypes menuTypes;

        public UpdateMenuItem(MenuTypes menuTypes)
        {
            InitializeComponent();
            service = new MenuItemService();
            this.menuTypes = menuTypes;
            categoryComboBox.DataSource = Enum.GetValues(typeof(Categories));
            typeComboBox.DataSource = Enum.GetValues(typeof(MenuTypes));
            alchoholicComboBox.Items.Add("Alcoholic");
            alchoholicComboBox.Items.Add("Alcoholic free");
            RefreshMenuItems();
            stockcomboBox.SelectedIndexChanged += new EventHandler(FillInItemDetails);
        }

        void RefreshMenuItems()
        {
            stockcomboBox.Items.Clear();
            stockcomboBox.ResetText();
            List<MenuItem> menuItems = service.RefreshItemsByCategory(menuTypes);
            foreach (MenuItem item in menuItems)
            {
                stockcomboBox.Items.Add(item);
            }
            stockcomboBox.DisplayMember = "Name";
        }

        private void UpdateMenuItem_Load(object sender, EventArgs e)
        {

        }

        private void updateItemButton_Click(object sender, EventArgs e)
        {
            if (stockcomboBox.SelectedIndex == null) 
            {
                MessageBox.Show("Please select menu item to update");
                return;
            }

            int id = int.Parse(iDTextbox.Text);
            string name = nameTextBox.Text;
            Categories selectedCategory = (Categories)categoryComboBox.SelectedItem;
            int stock = int.Parse(stockTextBox.Text);
            decimal price = decimal.Parse(priceTextBox.Text);
            decimal tax = decimal.Parse(taxTextBox.Text);
            MenuTypes menuTypes = (MenuTypes)typeComboBox.SelectedItem;
            MenuItem selectedItem = stockcomboBox.SelectedItem as MenuItem;
            bool alcoholic = alchoholicComboBox.SelectedItem.ToString() == "Alcoholic";

            int oldID = selectedItem.MenuItemId;

            try
            {
                MenuItem updatedItem = new MenuItem(id, name, selectedCategory, price, tax, stock, menuTypes, alcoholic);
                service.UpdateMenuItem(updatedItem, oldID);
                MessageBox.Show("Menu item has been updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FillInItemDetails(object sender, EventArgs e)
        {
            if (stockcomboBox.SelectedIndex != null)
            {
                MenuItem menuItem = (MenuItem)stockcomboBox.SelectedItem;
                if (menuItem != null)
                {
                    iDTextbox.Text = menuItem.MenuItemId.ToString();
                    nameTextBox.Text = menuItem.Name.ToString();
                    priceTextBox.Text = menuItem.Price.ToString();
                    taxTextBox.Text = menuItem.Tax.ToString();
                    stockTextBox.Text = menuItem.Stock.ToString();
                    typeComboBox.SelectedIndex = ((int)menuItem.Type) - 1;
                    categoryComboBox.SelectedIndex = ((int)menuItem.Category) - 1;



                    if (menuItem.IsAlchoholic)
                    {
                        alchoholicComboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        alchoholicComboBox.SelectedIndex = 1;
                    }
                   
                }
            }
        }
    }
}
