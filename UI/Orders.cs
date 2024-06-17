using Service;
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
using UI.UserControls;

namespace UI
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            ShowButtons();
            MenuItemService menuItemService = new MenuItemService();
            List<MenuItem> menuItems = menuItemService.GetAllMenuItems();
            foreach (MenuItem item in menuItems)
            {
                MenuItemUserControl menuItemUserControl = new MenuItemUserControl(item);
                switch ((int)menuItemUserControl.menuItem.Type)
                {
                    case 1:
                        this.flowPanelLunch.Controls.Add(menuItemUserControl); break;
                    case 2:
                        this.flowPanelDinner.Controls.Add(menuItemUserControl); break;
                    case 3:
                        this.flowPanelDrinks.Controls.Add(menuItemUserControl); break;
                }
            }
        }
        private void btnShowLunch_Click(object sender, EventArgs e)
        {
            HideButtons();
            flowPanelLunch.Show();
        }

        private void btnShowDinner_Click(object sender, EventArgs e)
        {
            HideButtons();
            flowPanelDinner.Show();
        }

        private void btnShowDrinks_Click(object sender, EventArgs e)
        {
            HideButtons();
            flowPanelDrinks.Show();
        }
        private void HideButtons()
        {
            btnShowLunch.Hide();
            btnShowDinner.Hide();
            btnShowDrinks.Hide();
            btnBackToOrders.Show();
        }
        private void ShowButtons()
        {
            flowPanelDinner.Hide();
            flowPanelDrinks.Hide();
            flowPanelLunch.Hide();
            btnBackToOrders.Hide();
            btnShowLunch.Show();
            btnShowDinner.Show();
            btnShowDrinks.Show();
        }

        private void btnBackToOrders_Click(object sender, EventArgs e)
        {
            ShowButtons();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order(DateTime.Now, new Employee() { Id = 1}, new Table(1, 1, true), (decimal)0);
            AddOrderItemsFromPanel(flowPanelLunch, order);
            AddOrderItemsFromPanel(flowPanelDinner, order);
            AddOrderItemsFromPanel(flowPanelDrinks, order);

            order.Total = 0;
            foreach (OrderItem item in order.OrderItems)
            {
                order.Total += item.MenuItem.Price * item.Quantity;
            }

            OrderService orderService = new OrderService();
            orderService.SaveOrder(order);
            MessageBox.Show("You ordered stuff!");
        }
        private void AddOrderItemsFromPanel(FlowLayoutPanel flowPanel, Order order)
        {
            foreach (MenuItemUserControl control in flowPanel.Controls)
            {
                if (control.orderItem.Quantity > 0)
                {
                    order.AddOrderItem(control.orderItem);
                }
            }
        }
    }
}
