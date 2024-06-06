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
                        flowPanelLunch.Controls.Add(menuItemUserControl); break;
                    case 2:
                        flowPanelDinner.Controls.Add(menuItemUserControl); break;
                    case 3:
                        flowPanelDrinks.Controls.Add(menuItemUserControl); break;
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
            listviewItems.Hide();
            btnComment.Hide();
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
            listviewItems.Show();
            btnComment.Hide();
            pnlComment.Hide();
        }

        private void btnBackToOrders_Click(object sender, EventArgs e)
        {
            ShowButtons();
            //Add currently ordered items to listview:
            //Clear listview items
            listviewItems.Items.Clear();
            //Get currently ordered items and add them
            AddItemsToListViewFromPanel(flowPanelLunch);
            AddItemsToListViewFromPanel(flowPanelDinner);
            AddItemsToListViewFromPanel(flowPanelDrinks);

            //If comment was just placed:
            //Get orderItem from the tag
            try
            {
                OrderItem orderItem = (OrderItem)listviewItems.SelectedItems[0].Tag;
            }
            catch 
            { 
            }

            if (txtComment.Text != string.Empty)
            {
                //MenuItemUserControl
            }
        }
        private void AddItemsToListViewFromPanel(FlowLayoutPanel flowPanel)
        {
            //lvItems for ListViewItems
            List<ListViewItem> lvItems = new List<ListViewItem>();
            foreach (OrderItem item in GetOrderItemsFromPanel(flowPanel)) //Get all items
            {
                //Make listviewitems with the item name and quantity and add them to the list
                ListViewItem li = new ListViewItem(new string[2] { item.MenuItem.Name.ToString(), item.Quantity.ToString() + "x" });
                //Add tag to get item later
                li.Tag = item;
                lvItems.Add(li);
            }
            foreach (ListViewItem item in lvItems)
            {
                //add the items to the listview
                listviewItems.Items.Add(item);
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order(DateTime.Now, new Employee() { Id = 1 }, new Table(1, 1, true), (decimal)0);
            AddOrderItemsFromList(GetOrderItemsFromPanel(flowPanelLunch), order);
            AddOrderItemsFromList(GetOrderItemsFromPanel(flowPanelDinner), order);
            AddOrderItemsFromList(GetOrderItemsFromPanel(flowPanelDrinks), order);

            order.Total = 0;
            foreach (OrderItem item in order.OrderItems)
            {
                order.Total += item.MenuItem.Price * item.Quantity;
            }

            OrderService orderService = new OrderService();
            orderService.SaveOrder(order);
            MessageBox.Show("You ordered stuff!");
        }
        private List<OrderItem> GetOrderItemsFromPanel(FlowLayoutPanel flowPanel)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (MenuItemUserControl control in flowPanel.Controls)
            {
                if (control.orderItem.Quantity > 0)
                {
                    OrderItem orderItem = new OrderItem(control.menuItem, control.orderItem.Quantity, Model.Enums.Status.Ordered, "", new TimeSpan(0, 0, 0));
                    orderItems.Add(orderItem);
                }
            }
            return orderItems;
        }
        private void AddOrderItemsFromList(List<OrderItem> orderItems, Order order)
        {
            foreach (OrderItem item in orderItems)
            {
                order.OrderItems.Add(item);
            }
        }

        private void listviewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnComment.Show();
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            HideButtons();
            pnlComment.Show();
            //btnOrder.Hide();
            //Get orderItem from the tag
            OrderItem orderItem = (OrderItem)listviewItems.SelectedItems[0].Tag;
            //adding a tag to the comment box to connect it with the item the comment will be for
            txtComment.Tag = orderItem;
            txtComment.Text = ((OrderItem)txtComment.Tag).Comment;
        }
    }
}
