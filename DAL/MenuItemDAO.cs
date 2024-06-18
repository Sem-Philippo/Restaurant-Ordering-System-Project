using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Enums;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class MenuItemDAO : BaseDao
    {
        public List<MenuItem> GetAllMenuItems()
        {
            string query = "Select * from menuItem";
            SqlParameter[] param = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, param));

        }
        public MenuItem GetMenuItemByID(int id)
        {
            string query = "SELECT * FROM MenuItem WHERE ID = @MenuitemID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MenuitemID", id);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
        }
        private List<MenuItem> ReadTables(DataTable dataTable)
        {
            List<MenuItem> list = new List<MenuItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                MenuItem menuItem = new MenuItem()
                {
                    MenuItemId = Convert.ToInt32(dr["MenuitemID"]),
                    Name = dr["Name"].ToString(),
                    Category = (Categories)Enum.Parse(typeof(Categories), dr["Category"].ToString()),
                    Price = Convert.ToDecimal(dr["Price"]),
                    Tax = Convert.ToDecimal(dr["Tax"]),
                    Stock = Convert.ToInt32(dr["Stock"]),
                    Type = (MenuTypes)Enum.Parse(typeof(MenuTypes), dr["Type"].ToString()),
                    IsAlchoholic = Convert.ToBoolean(dr["IsAlcoholic"])
                };

                list.Add(menuItem);
            }
            return list;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            int id = menuItem.MenuItemId;
            string name = menuItem.Name;
            Categories categories = menuItem.Category;
            decimal price = menuItem.Price;
            decimal tax = menuItem.Tax;
            int stock = menuItem.Stock;
            MenuTypes types = menuItem.Type;
            bool alchohoic = menuItem.IsAlchoholic;

            string query = "insert into menuItem values(@MenuitemID, @Name, @Category, @Price, @Tax, @Stock, @Type, @IsAlchoholic)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MenuitemID", SqlDbType.Int) {Value = id},
                new SqlParameter("@Name", SqlDbType.VarChar) {Value = name},
                new SqlParameter("@Category", SqlDbType.Int) {Value = ((int)categories)},
                new SqlParameter("@Price", SqlDbType.Decimal) {Value = price},
                new SqlParameter("@Tax", SqlDbType.Decimal) {Value = tax},
                new SqlParameter("@Stock", SqlDbType.Int) {Value = stock},
                new SqlParameter("@Type", SqlDbType.Int) {Value = (int)types},
                new SqlParameter("@IsAlchoholic", SqlDbType.Bit) { Value = alchohoic ? 1 : 0 }

            };
            ExecuteDeleteQuery(query, parameters);
            

        }

        public void DeleteMenuITem(MenuItem menuItem)
        {
            if (menuItem == null) throw new ArgumentNullException("Drink object cannot be null");

            string query = "Delete from menuItem where id = @MenuitemID";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MenuitemID", SqlDbType.Int) {Value = menuItem.MenuItemId}
            };
            ExecuteDeleteQuery(query, sqlParameters);
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            if (menuItem == null) throw new ArgumentNullException("Menu item cannot be null");
            int id = menuItem.MenuItemId;
            string name = menuItem.Name;
            Categories categories = menuItem.Category;
            decimal price = menuItem.Price;
            decimal tax = menuItem.Tax;
            int stock = menuItem.Stock;
            MenuTypes types = menuItem.Type;
            bool alchohoic = menuItem.IsAlchoholic;

            string query = "update menuItem set Name = @Name, Category = @Category, Price = @Price, Tax = @Tax,  Stock = @Stock, Type = @Type, IsAlchoholic = @IsAlchoholic where MenuitemID = @MenuitemID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MenuitemID", SqlDbType.Int) {Value = id},
                new SqlParameter("@Name", SqlDbType.VarChar) {Value = name},
                new SqlParameter("@Category", SqlDbType.Int) {Value = ((int)categories)},
                new SqlParameter("@Price", SqlDbType.Decimal) {Value = price},
                new SqlParameter("@Tax", SqlDbType.Decimal) {Value = tax},
                new SqlParameter("@Stock", SqlDbType.Int) {Value = stock},
                new SqlParameter("@Type", SqlDbType.Int) {Value = (int)types},
                new SqlParameter("@IsAlchoholic", SqlDbType.Bit) { Value = alchohoic ? 1 : 0 }

            };
            ExecuteDeleteQuery(query, parameters);

        }

        public void UpdateStock(MenuItem menuItem, int stock)
        {
            string query = "Update menuItem set Stock = @Stock where MenuitemID = @MeniitemID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MenuitemID", SqlDbType.Int) {Value = menuItem.MenuItemId},
                new SqlParameter("@Stock", SqlDbType.Int) {Value = stock},
            };

            ExecuteEditQuery(query, parameters);
        }

    }
}
