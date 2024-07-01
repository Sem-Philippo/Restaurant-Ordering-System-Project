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
using Microsoft.VisualBasic;

namespace UI
{
    public partial class Orders : Form
    {
        private Employee employee;
        private Table table;
        MenuItemService menuItemService = new MenuItemService();
        OrderService orderService = new OrderService();

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
            List<MenuItem> menuItems = menuItemService.GetAllMenuItems();

            //code for sorting taken from internet
            menuItems.Sort((x, y) => x.Category.CompareTo(y.Category));

            foreach (MenuItem item in menuItems)
            {
                //Got each menu item now, sorted
                MenuItemUserControl menuItemUserControl = new MenuItemUserControl(item, this);
                AddToFlowPanel(menuItemUserControl);

            }
        }
        private void AddLabel(MenuItemUserControl control, FlowLayoutPanel flowPanel)
        {
            Label label = new Label();
            label.Text = ((MenuItem)control.Tag).Category.ToString().Replace("_", " ");
            label.Font = new Font(label.Font.FontFamily, 18f);
            label.AutoSize = true;
            flowPanel.Controls.Add(label);
        }
        private void AddToFlowPanel(MenuItemUserControl menuItemUserControl)
        {
            MenuItem menuItem = (MenuItem)menuItemUserControl.Tag;
            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            switch ((int)menuItem.Type)
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
                //1st item, so new category
                AddLabel(menuItemUserControl, flowPanel);
            }
            else
            {
                MenuItem menuItem2 = (MenuItem)((MenuItemUserControl)flowPanel.Controls[flowPanel.Controls.Count - 1]).Tag;
                if (menuItem2.Category != menuItem.Category)
                {
                    //if it is a new category
                    AddLabel(menuItemUserControl, flowPanel);
                }
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
            btnBackToOverview.Show();
            flOrder.Hide();
        }
        private void ShowButtons()
        {
            flowPanelDinner.Hide();
            flowPanelDrinks.Hide();
            flowPanelLunch.Hide();
            btnBackToOverview.Hide();
            btnShowLunch.Show();
            btnShowDinner.Show();
            btnShowDrinks.Show();
            pnlComment.Hide();
            flOrder.Show();
        }
        private void btnBackToOverview_Click(object sender, EventArgs e)
        {
            //If comment was just placed:
            if (pnlComment.Visible)
            {
                pnlComment.Hide();
                //clear the text
                OrderItemUserControl control = (OrderItemUserControl)pnlComment.Tag;
                ((OrderItem)control.Tag).Comment = txtComment.Text;
                txtComment.Text = string.Empty;
            }
            //Get orderItem from the tag
            ShowButtons();
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
            //if someone is making a comment while clicking the button, the comment saves
            if (pnlComment.Visible)
            {
                pnlComment.Hide();
                //clear the text
                OrderItemUserControl control = (OrderItemUserControl)pnlComment.Tag;
                ((OrderItem)control.Tag).Comment = txtComment.Text;
                txtComment.Text = string.Empty;
            }
            Order order = new Order(DateTime.Now, employee, table);
            AddOrderItemsToOrder(order);
            //clear the panel since this method only gets called right before 
            //storing the orders in the database, so it doesn't need it filled anymore
            flOrder.Controls.Clear();
            return order;
        }
        private void AddOrderItemsToOrder(Order order)
        {
            foreach (OrderItemUserControl control in flOrder.Controls)
            {
                order.AddOrderItem((OrderItem)control.Tag);
            }
        }
        public void OpenComment(OrderItemUserControl control)
        {
            HideButtons();
            pnlComment.Show();
            //store control in the tag so it can access it later
            pnlComment.Tag = control;
            txtComment.Text = ((OrderItem)control.Tag).Comment;
        }
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            Order order = GetOrder();

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
        public void AddItemToOrder(OrderItem item)
        {
            flOrder.Controls.Add(new OrderItemUserControl(item, this));
        }
        public void RemoveItemFromOrder(MenuItem item)
        {
            //can't use an order item since it might have changed by getting a comment or something else
            foreach (OrderItemUserControl control in flOrder.Controls)
            {
                if (((OrderItem)control.Tag).MenuItem == item)
                {
                    flOrder.Controls.Remove(control);
                    //item already found, no need to look further
                    break;
                }
            }
        }
        public void ChangeMenuControlQuantity(MenuItem item, int quantity)
        {
            //when changing the quantity from the OrderItemControl,
            //the MenuControl won't change which causes inconsistencies
            FlowLayoutPanel panel;
            //lunch, dinner, drinks
            switch (item.Type)
            {
                case Model.Enums.MenuTypes.Lunch:
                    panel = flowPanelLunch; break;
                case Model.Enums.MenuTypes.Dinner:
                    panel = flowPanelDinner; break;
                case Model.Enums.MenuTypes.Drinks:
                    panel = flowPanelDrinks; break;
                default:
                    throw new Exception("Item does not belong to a valid type");
            }
            foreach (object menuItemControl in panel.Controls)
            {
                try
                {
                    MenuItemUserControl control = (MenuItemUserControl)menuItemControl;
                    if (control.Tag == item)
                    {
                        control.ChangeQuantity(quantity);
                    }
                }
                catch
                {
                    //the item was just a label, nothing to worry about
                }
            }
        }
        public void ChangeOrderControlQuantity(MenuItem item, int quantity)
        {
            foreach (object orderItemControl in flOrder.Controls)
            {
                OrderItemUserControl control = (OrderItemUserControl)orderItemControl;
                if (((OrderItem)control.Tag).MenuItem == item)
                {
                    control.ChangeQuantity(quantity);
                }
            }
        }
    }
}
