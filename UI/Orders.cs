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
        private Employee employee;
        private Table table;
        public Orders(Employee employee, Table table)
        {
            InitializeComponent();
            this.employee = employee;
            this.table = table;
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            ReloadOrders();
        }
        private void ClearPanels()
        {
            flowPanelLunch.Controls.Clear();
            flowPanelDinner.Controls.Clear();
            flowPanelDrinks.Controls.Clear();
            ShowButtons();
        }
        private void ReloadOrders()
        {
            ClearPanels();
            MenuItemService menuItemService = new MenuItemService();
            List<MenuItem> menuItems = menuItemService.GetAllMenuItems();

            //code for sorting taken from internet
            menuItems.Sort((x, y) => x.Category.CompareTo(y.Category));

            foreach (MenuItem item in menuItems)
            {
                //Got each menu item now, sorted
                MenuItemUserControl menuItemUserControl = new MenuItemUserControl(item);
                AddToFlowPanel(menuItemUserControl);

            }
            listviewItems.Items.Clear();
        }
        private void AddLabel(MenuItemUserControl control, FlowLayoutPanel flowPanel)
        {
            Label label = new Label();
            label.Text = control.menuItem.Category.ToString().Replace("_", " ");
            label.Font = new Font(label.Font.FontFamily, 18f);
            label.AutoSize = true;
            flowPanel.Controls.Add(label);
        }
        private void AddToFlowPanel(MenuItemUserControl menuItemUserControl)
        {
            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            switch ((int)menuItemUserControl.menuItem.Type)
            {
                case 1:
                    flowPanel = flowPanelLunch; break;
                case 2:
                    flowPanel = flowPanelDinner; break;
                case 3:
                    flowPanel = flowPanelDrinks; break;
            }

            if (flowPanel.Controls.Count == 0)
            {
                //1st item, so new catagory
                AddLabel(menuItemUserControl, flowPanel);
            }
            else if (((MenuItemUserControl)flowPanel.Controls[flowPanel.Controls.Count - 1]).menuItem.Category != menuItemUserControl.menuItem.Category)
            {
                //if it is a new category
                AddLabel(menuItemUserControl, flowPanel);
            }
            flowPanel.Controls.Add(menuItemUserControl);
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
            //If comment was just placed:
            //Get orderItem from the tag
            if (txtComment.Tag != null)
            {
                MenuItemUserControl control = (MenuItemUserControl)txtComment.Tag;
                if (txtComment.Text != string.Empty || txtComment.Text != null)
                {
                    control.orderItem.Comment = txtComment.Text;
                }
            }
            ShowButtons();
            //Add currently ordered items to listview:
            //Clear listview items
            listviewItems.Items.Clear();
            //Get currently ordered items and add them
            AddItemsToListViewFromPanel(flowPanelLunch);
            AddItemsToListViewFromPanel(flowPanelDinner);
            AddItemsToListViewFromPanel(flowPanelDrinks);
        }
        private void AddItemsToListViewFromPanel(FlowLayoutPanel flowPanel)
        {
            //lvItems for ListViewItems
            List<ListViewItem> lvItems = new List<ListViewItem>();
            foreach (MenuItemUserControl control in GetOrderItemsFromPanel(flowPanel)) //Get all items
            {
                //Make listviewitems with the item name and quantity and add them to the list
                ListViewItem li = new ListViewItem(new string[2] { control.orderItem.MenuItem.Name.ToString(), control.orderItem.Quantity.ToString() + "x" });
                //Add tag to get item later
                li.Tag = control;
                lvItems.Add(li);
            }
            foreach (ListViewItem item in lvItems)
            {
                //add the items to the listview
                listviewItems.Items.Add(item);
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = GetOrder();
                OrderService orderService = new OrderService();
                orderService.SaveOrder(order);
                ReloadOrders();
            }
            catch
            {
                MessageBox.Show("Something went wrong, please try again");
            }
            
        }
        private Order GetOrder()
        {
            //forcing the back to orders button to be clicked in case of a comment being made
            btnBackToOrders_Click(null, null);
            Order order = new Order(DateTime.Now, employee, table);
            AddOrderItemsFromList(GetOrderItemsFromPanel(flowPanelLunch), order);
            AddOrderItemsFromList(GetOrderItemsFromPanel(flowPanelDinner), order);
            AddOrderItemsFromList(GetOrderItemsFromPanel(flowPanelDrinks), order);
            return order;
        }
        private List<MenuItemUserControl> GetOrderItemsFromPanel(FlowLayoutPanel flowPanel)
        {
            List<MenuItemUserControl> controls = new List<MenuItemUserControl>();
            foreach (object control in flowPanel.Controls)
            {
                try
                {
                    MenuItemUserControl menuItemUserControl = (MenuItemUserControl)control;
                    if (menuItemUserControl.orderItem.Quantity > 0)
                    {
                        controls.Add(menuItemUserControl);
                    }
                }
                catch
                {
                    //item was just a label
                }
            }
            return controls;
        }
        private void AddOrderItemsFromList(List<MenuItemUserControl> controls, Order order)
        {
            foreach (MenuItemUserControl control in controls)
            {
                order.OrderItems.Add(control.orderItem);
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
            MenuItemUserControl control = (MenuItemUserControl)listviewItems.SelectedItems[0].Tag;
            //adding a tag to the comment box to connect it with the item the comment will be for
            txtComment.Tag = control;
            txtComment.Text = control.orderItem.Comment;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            Order order = GetOrder();
            OrderService orderService = new OrderService();
            bool result = orderService.AddToExistingOrder(order);
            if (result)
            {
                //order has been added to
                ReloadOrders();
            }
            else
            {
                //no order has been added to
                MessageBox.Show("Sorry, no previous orders for table " + order.Table.TableNumber + " to add to have been found.");
            }
        }
    }
}
