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
    public partial class OrderItemUserControl : UserControl
    {
        Orders ordersForm;
        public OrderItemUserControl(OrderItem item, Orders ordersForm)
        {
            InitializeComponent();
            this.Tag = item;
            this.ordersForm = ordersForm;
            LoadData();
        }
        private void LoadData()
        {
            OrderItem item = (OrderItem)Tag;
            lblDishName.Text = item.MenuItem.Name;
            lblAmount.Text = item.Quantity.ToString();
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            ordersForm.OpenComment(this);
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            lblAmount.Text = (int.Parse(lblAmount.Text) + 1).ToString();
            ordersForm.ChangeMenuControlQuantity(((OrderItem)Tag).MenuItem, int.Parse(lblAmount.Text));
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            lblAmount.Text = (int.Parse(lblAmount.Text) - 1).ToString();
            ordersForm.ChangeMenuControlQuantity(((OrderItem)Tag).MenuItem, int.Parse(lblAmount.Text));
            if (int.Parse(lblAmount.Text) == 0)
            {
                //last item removed, delete from flOrder
                ordersForm.RemoveItemFromOrder(((OrderItem)this.Tag).MenuItem);
            }
        }
        public void ChangeQuantity(int quantity)
        {
            lblAmount.Text = quantity.ToString();
        }
    }
}
