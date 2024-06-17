using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Model.Enums;
using Service;

namespace UI
{
    public partial class AdjustStock : Form
    {
        private MenuTypes menuTypes;
        private MenuItemService service;

        public AdjustStock(MenuTypes menuTypes)
        {
            InitializeComponent();
            this.menuTypes = menuTypes;
            this.service = new MenuItemService();
            LoadMenuItems();
            menuItemsCombo.SelectedIndexChanged += new EventHandler(FillInStockBox);
        }
        private void LoadMenuItems()
        {

            menuItemsCombo.DisplayMember = "Name";
            List<MenuItem> menuItems = service.RefreshItemsByCategory(menuTypes);
            menuItemsCombo.Items.Clear();
            foreach (MenuItem item in menuItems)
            {
                menuItemsCombo.Items.Add(item);
            }
        }
        private void FillInStockBox(object sender, EventArgs e)
        {
            if (menuItemsCombo.SelectedIndex != null)
            {
                MenuItem menuItem = (MenuItem)menuItemsCombo.SelectedItem;
                if (menuItem != null)
                {
                    stockBox.Text = menuItem.Stock.ToString();
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void adjustButton_Click(object sender, EventArgs e)
        {
            if (menuItemsCombo.SelectedItem != null)
            {
                int stock = int.Parse(stockBox.Text);
                MenuItem menuItem = menuItemsCombo.SelectedItem as MenuItem;

                try
                {
                    service.UpdateStock(menuItem, stock);
                    MessageBox.Show("Stock adjusted successfully");
                    this.Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid number for stock.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error happened adjusting stock" + ex.Message);
                }
                
            }
        }
    }
}
