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
        Orders ordersForm;
        public MenuItemUserControl(MenuItem menuItem, Orders ordersForm)
        {
            InitializeComponent();
            //store menuItem in the tag instead of an actual variable
            this.Tag = menuItem;
            //save the orders form so I can have access to it later
            this.ordersForm = ordersForm;
        }

        private void MenuItemUserControl_Load(object sender, EventArgs e)
        {
            UpdateLabels();
        }
        private void UpdateLabels()
        {
            lblDishName.Text = ((MenuItem)Tag).Name;
            lblAmount.Text = 0.ToString();
        }

        private void btnAmountIncrease_Click(object sender, EventArgs e)
        {
            lblAmount.Text = (int.Parse(lblAmount.Text)+1).ToString();
            if (int.Parse(lblAmount.Text) == 1)
            {
                //item has just been ordered, so add to panel
                ordersForm.AddItemToOrder(new OrderItem((MenuItem)Tag, int.Parse(lblAmount.Text), Model.Enums.Status.Ordered, string.Empty, new TimeSpan(0,0,0)));
            }
            else
            {
                ordersForm.ChangeOrderControlQuantity((MenuItem)this.Tag, int.Parse(lblAmount.Text));
            }
        }

        private void btnAmountDecrease_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblAmount.Text) > 0)
            {
                lblAmount.Text = (int.Parse(lblAmount.Text)-1).ToString();
                ordersForm.ChangeOrderControlQuantity((MenuItem)this.Tag, int.Parse(lblAmount.Text));
            }
            if (int.Parse(lblAmount.Text) == 0)
            {
                //if it has now been ordered 0 times in the current order
                ordersForm.RemoveItemFromOrder((MenuItem)Tag);
            }

        }
        public void ChangeQuantity(int quantity)
        {
            lblAmount.Text = quantity.ToString();
        }
    }
}
