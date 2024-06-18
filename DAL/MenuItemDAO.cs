using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Enums;
using System.Data.SqlClient;
=======
>>>>>>> 3116a052fb3deac49d79f7dbf944f18bbef924d6
using System.Data;
using System.Data.SqlClient;
using Model;
using Model.Enums;

namespace DAL
{
    public class MenuItemDAO : BaseDao
    {
        public List<MenuItem> GetAllMenuItems()
        {
            string query = "SELECT * FROM menuItem";
            try
            {
                return ReadMenuItems(ExecuteSelectQuery(query, new SqlParameter[0]));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving menu items: {ex.Message}");
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }
<<<<<<< HEAD
        public MenuItem GetMenuItemByID(int id)
        {
            string query = "SELECT * FROM MenuItem WHERE ID = @MenuitemID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MenuitemID", id);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
        }
        private List<MenuItem> ReadTables(DataTable dataTable)
=======

        private List<MenuItem> ReadMenuItems(DataTable dataTable)
>>>>>>> 3116a052fb3deac49d79f7dbf944f18bbef924d6
        {
            List<MenuItem> list = new List<MenuItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                MenuItem menuItem = new MenuItem()
                {
<<<<<<< HEAD
                    MenuItemId = Convert.ToInt32(dr["MenuitemID"]),
=======
                    MenuItemId = Convert.ToInt32(dr["MenuItemID"]),
>>>>>>> 3116a052fb3deac49d79f7dbf944f18bbef924d6
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
<<<<<<< HEAD
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
            
=======
            string query = "INSERT INTO menuItem VALUES (@ID, @Name, @Category, @Price, @Tax, @Stock, @Type, @Alcoholic)";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", SqlDbType.Int) {Value = menuItem.MenuItemId},
                    new SqlParameter("@Name", SqlDbType.VarChar) {Value = menuItem.Name},
                    new SqlParameter("@Category", SqlDbType.Int) {Value = (int)menuItem.Category},
                    new SqlParameter("@Price", SqlDbType.Decimal) {Value = menuItem.Price},
                    new SqlParameter("@Tax", SqlDbType.Decimal) {Value = menuItem.Tax},
                    new SqlParameter("@Stock", SqlDbType.Int) {Value = menuItem.Stock},
                    new SqlParameter("@Type", SqlDbType.Int) {Value = (int)menuItem.Type},
                    new SqlParameter("@Alcoholic", SqlDbType.Bit) {Value = menuItem.IsAlchoholic}
                };
>>>>>>> 3116a052fb3deac49d79f7dbf944f18bbef924d6

                ExecuteEditQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding menu item: {ex.Message}");
                throw;
            }
        }

        public void DeleteMenuItem(MenuItem menuItem)
        {
            if (menuItem == null)
                throw new ArgumentNullException(nameof(menuItem), "Menu item cannot be null.");

<<<<<<< HEAD
            string query = "Delete from menuItem where id = @MenuitemID";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MenuitemID", SqlDbType.Int) {Value = menuItem.MenuItemId}
            };
            ExecuteDeleteQuery(query, sqlParameters);
=======
            try
            {
                string query = "DELETE FROM menuItem WHERE MenuItemID = @ID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", SqlDbType.Int) {Value = menuItem.MenuItemId}
                };

                ExecuteDeleteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting menu item: {ex.Message}");
                throw; // Re-throw the exception to propagate it up the call stack
            }
>>>>>>> 3116a052fb3deac49d79f7dbf944f18bbef924d6
        }

        public void UpdateMenuItem(MenuItem menuItem, int id)
        {
            if (menuItem == null)
                throw new ArgumentNullException(nameof(menuItem), "Menu item cannot be null.");

<<<<<<< HEAD
            string query = "update menuItem set Name = @Name, Category = @Category, Price = @Price, Tax = @Tax,  Stock = @Stock, Type = @Type, IsAlchoholic = @IsAlchoholic where MenuitemID = @MenuitemID";

            SqlParameter[] parameters = new SqlParameter[]
=======
            try
>>>>>>> 3116a052fb3deac49d79f7dbf944f18bbef924d6
            {
                string name = menuItem.Name;
                Categories categories = menuItem.Category;
                decimal price = menuItem.Price;
                decimal tax = menuItem.Tax;
                int stock = menuItem.Stock;
                MenuTypes types = menuItem.Type;
                bool alchohoic = menuItem.IsAlchoholic;

                string query = "UPDATE menuItem\r\nSET Name = @Name,\r\n    Category = @Category,\r\n    Price = @Price,\r\n    Tax = @Tax,\r\n    Stock = @Stock,\r\n    Type = @Type,\r\n    IsAlcoholic = @IsAlcoholic\r\nWHERE MenuitemID = @MenuitemID;";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MenuitemID", SqlDbType.Int) {Value = id},
                    new SqlParameter("@Name", SqlDbType.VarChar) {Value = name},
                    new SqlParameter("@Category", SqlDbType.Int) {Value = ((int)categories)},
                    new SqlParameter("@Price", SqlDbType.Decimal) {Value = price},
                    new SqlParameter("@Tax", SqlDbType.Decimal) {Value = tax},
                    new SqlParameter("@Stock", SqlDbType.Int) {Value = stock},
                    new SqlParameter("@Type", SqlDbType.Int) {Value = (int)types},
                    new SqlParameter("@IsAlcoholic", SqlDbType.Bit) { Value = alchohoic ? 1 : 0 },


                };
                ExecuteDeleteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating menu item: {ex.Message}");
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }

        public void UpdateStock(MenuItem menuItem, int stock)
        {
            try
            {
                string query = "UPDATE menuItem SET Stock = @Stock WHERE MenuItemID = @ID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", SqlDbType.Int) {Value = menuItem.MenuItemId},
                    new SqlParameter("@Stock", SqlDbType.Int) {Value = stock},
                };

                ExecuteEditQuery
                    (query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating stock for menu item: {ex.Message}");
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }


        public List<MenuItem> GetAllLowStockItems()
        {
            string query = "SELECT * FROM menuItem WHERE Stock <= 10";
            try
            {
                return ReadMenuItems(ExecuteSelectQuery(query, new SqlParameter[0]));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving low stock menu items: {ex.Message}");
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }

        internal MenuItem GetMenuItemByID(int id)
        {
            try
            {
                string query = "SELECT * FROM menuItem WHERE ID = @ID";
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@ID", id);
                return ReadMenuItems(ExecuteSelectQuery(query, sqlParameters))[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Getting menu item: {ex.Message}");
                throw; // Re-throw the exception to propagate it up the call stack
            }

        }

        

    }
}
