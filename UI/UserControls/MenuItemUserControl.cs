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

namespace UI.UserControls
{
    public partial class MenuItemUserControl : UserControl
    {
        public OrderItem orderItem;
        public MenuItem menuItem;
        public MenuItemUserControl(MenuItem menuItem)
        {
            InitializeComponent();
            this.menuItem = menuItem;
            orderItem = new OrderItem(menuItem, 0, Model.Enums.Status.Ordered, "", new TimeSpan(0, 0, 0));
        }

        private void MenuItemUserControl_Load(object sender, EventArgs e)
        {
            UpdateLabels();
        }
        private void UpdateLabels()
        {
            lblDishName.Text = menuItem.Name;
            lblAmount.Text = 0.ToString();
        }

        private void btnAmountIncrease_Click(object sender, EventArgs e)
        {
            orderItem.Quantity += 1;
            lblAmount.Text = orderItem.Quantity.ToString();
        }

        private void btnAmountDecrease_Click(object sender, EventArgs e)
        {
            if (orderItem.Quantity > 0)
            {
                orderItem.Quantity -= 1;
                lblAmount.Text = orderItem.Quantity.ToString();
            }
        }
    }
}
