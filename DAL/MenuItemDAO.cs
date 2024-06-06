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

        private List<MenuItem> ReadTables(DataTable dataTable)
        {
            List<MenuItem> list = new List<MenuItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                MenuItem menuItem = new MenuItem()
                {
                    MenuItemId = int.Parse(dr["MenuitemID"].ToString()),
                    Name = dr["Name"].ToString(),
                    Category = (Categories)Enum.Parse(typeof(Categories), dr["Category"].ToString()),
                    Price = decimal.Parse(dr["Price"].ToString()),
                    Tax = decimal.Parse(dr["Tax"].ToString()),
                    Stock = int.Parse(dr["Stock"].ToString()),
                    Type = (MenuTypes)Enum.Parse(typeof (MenuTypes), dr["Type"].ToString()),
                    IsAlchoholic = Convert.ToBoolean(int.Parse(dr["IsAlchoholic"].ToString()))


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

            string query = "insert into menuItem values(@ID, @Name, @Category, @Price, @Tax, @Stock, @Type, @Alchoholic)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", SqlDbType.Int) {Value = id},
                new SqlParameter("@Name", SqlDbType.VarChar) {Value = name},
                new SqlParameter("@Category", SqlDbType.Int) {Value = ((int)categories)},
                new SqlParameter("@Price", SqlDbType.Decimal) {Value = price},
                new SqlParameter("@Tax", SqlDbType.Decimal) {Value = tax},
                new SqlParameter("@Stock", SqlDbType.Int) {Value = stock},
                new SqlParameter("@Type", SqlDbType.Int) {Value = (int)types},
                new SqlParameter("@Alchoholic", SqlDbType.Bit) { Value = alchohoic ? 1 : 0 }

            };
            ExecuteDeleteQuery(query, parameters);
            

        }

        public void DeleteMenuITem(MenuItem menuItem)
        {
            if (menuItem == null) throw new ArgumentNullException("Drink object cannot be null");

            string query = "Delete from menuItem where id = @ID";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ID", SqlDbType.Int) {Value = menuItem.MenuItemId}
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

            string query = "update menuItem set Name = @Name, Category = @Category, Price = @Price, Tax = @Tax = Stock = @Stock = Type = @Type, IsAlchoholic = @IsAlchoholic where MenuitemID = @MenuitemID";

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
