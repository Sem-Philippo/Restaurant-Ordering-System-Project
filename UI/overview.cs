using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    public partial class overview : Form
    {
        public overview()
        {
            InitializeComponent();
            ConfigureListView();
            ConfigureOrderListView();
            LoadTableOverview();
        }

        private void ConfigureListView()
        {
            this.Tables.View = View.Details;
            this.Tables.FullRowSelect = true;
            this.Tables.GridLines = true;

            // Clear any existing columns
            this.Tables.Columns.Clear();

            // Adds columns to the ListView 
            this.Tables.Columns.Add("Table Id", 100, HorizontalAlignment.Left);
            this.Tables.Columns.Add("Status", 200, HorizontalAlignment.Left);
            this.Tables.Columns.Add("Table Number", 200, HorizontalAlignment.Left);

            // Handle the SelectedIndexChanged event
            this.Tables.SelectedIndexChanged += new EventHandler(Tables_SelectedIndexChanged);
        }

        private void ConfigureOrderListView()
        {
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;

            // Clear any existing columns
            this.listView1.Columns.Clear();

            // Adds columns to the ListView 
            this.listView1.Columns.Add("Order ID", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Employee", 170, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Time", 150, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Total", 100, HorizontalAlignment.Left);
        }

        private void LoadTableOverview()
        {
            try
            {
                TableService tableService = new TableService();
                List<Table> tables = tableService.GetAllTables();
                Tables.Items.Clear();

                foreach (var table in tables)
                {
                    string status = table.IsOccupied ? "Occupied" : "Free";
                    ListViewItem item = new ListViewItem(table.TableId.ToString())
                    {
                        SubItems = { status, table.TableNumber.ToString() },
                        Tag = table // Store the Table object in the Tag property
                    };
                    Tables.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading table overview: {ex.Message}");
            }
        }

        private void Tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tables.SelectedItems.Count > 0)
            {
                var selectedItem = Tables.SelectedItems[0];
                var table = selectedItem.Tag as Table; // Retrieve the Table object from the Tag property

                if (table != null)
                {
                    // Load orders for the selected table
                    LoadOrdersForTable(table.TableId);
                }
            }
        }

        private void LoadOrdersForTable(int tableId)
        {
            try
            {
                OrderService orderService = new OrderService();
                List<Order> orders = orderService.GetOrdersByTableId(tableId);
                listView1.Items.Clear();

                foreach (var order in orders)
                {
                    ListViewItem item = new ListViewItem(order.Id.ToString())
                    {
                        SubItems =
                        {
                            order.Employee.FirstName + " " + order.Employee.LastName,
                            order.Time.ToString(),
                            order.Total.ToString("C") // Format as currency
                        }
                    };
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}");
            }
        }

        private void ChangeStatus_Click(object sender, EventArgs e)
        {
            if (Tables.SelectedItems.Count > 0)
            {
                var selectedItem = Tables.SelectedItems[0];
                var table = selectedItem.Tag as Table; // Retrieve the Table object from the Tag property

                if (table != null)
                {
                    // Toggle the IsOccupied status
                    table.IsOccupied = !table.IsOccupied;

                    // Update the status in the ListView
                    selectedItem.SubItems[1].Text = table.IsOccupied ? "Occupied" : "Free";

                    // Update the status in the database
                    TableService tableService = new TableService();
                    tableService.ChangeTableStatus(table);
                }
            }
        }
    }
}
