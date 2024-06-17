using Model;
using Model.Enums;
using Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    public partial class DeleteMenuItem : Form
    {
        private MenuItemService service;
        private MenuTypes menuTypes;

        public DeleteMenuItem(MenuTypes type)
        {
            InitializeComponent();
            service = new MenuItemService();
            this.menuTypes = type;
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            menuItemBox.DisplayMember = "Name";
            List<MenuItem> menuItems = service.RefreshItemsByCategory(menuTypes);
            menuItemBox.Items.Clear();
            foreach (MenuItem item in menuItems)
            {
                menuItemBox.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (menuItemBox.SelectedItem != null)
            {
                MenuItem selectedMenuItem = menuItemBox.SelectedItem as MenuItem;

                
                var confirmMessage = MessageBox.Show($"Are you sure you want to delete '{selectedMenuItem.Name}'?",
                                             "Confirm Deletion",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (confirmMessage == DialogResult.Yes)
                {
                    try
                    {
                        service.DeleteMenuItem(selectedMenuItem);
                        MessageBox.Show("Menu item deleted successfully!");
                        
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error occurred deleting menu item: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a menu item to delete.");
            }
        }
    }
}
