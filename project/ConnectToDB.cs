using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 

namespace CocktailMix
{
    // DAO pattern implementation
    // DAO stands for Data Access Object
    // DAO incapsulates all operations with database and it 
    //     is only object in app which can get access to database,
    //     other classes call DAO to get some information
    //     from database, or to update information in database
    class ConnectToDB
    {
        // MySQL connection string
        // server - always localhost
        // userid - username, usually root
        // password - password to your local instance of MySQL
        // database - cocktails is a database we use
        private string cs = @"server=localhost;userid=root;password=1995;database=cocktails";
        // Methods to work with database
        public int SignIn(string login, string pass)
        {
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string text = "SELECT type FROM account WHERE login='" + login + "' AND password='" + pass + "'";

                MySqlCommand cmd = new MySqlCommand(text, conn);
         
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    return rdr.GetInt32(0);
                }
                else
                {
                    return 0;
                }
            }
            catch (MySqlException)
            {
                return 0;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void AddRecipe(string name, string liq, string ice, string dec, int price)
        {
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string text = "INSERT INTO recipes (name, liquid, ice, decoration, price) VALUES ('" + name + "', '" + liq + "', '" + ice + "', '" + dec + "', " + price.ToString() + ")";

                MySqlCommand cmd = new MySqlCommand(text, conn);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            { }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public List<string> GetCocktailContent(string name)
        {
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            try
            {
                List<string> result = new List<string>();
                conn = new MySqlConnection(cs);
                conn.Open();

                string text = "SELECT * FROM recipes WHERE name='" + name + "'";

                MySqlCommand cmd = new MySqlCommand(text, conn);

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    result.Add(rdr.GetString("liquid"));
                    result.Add(rdr.GetString("ice"));
                    result.Add(rdr.GetString("decoration"));
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException)
            {
                return null;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public int GetCocktailPrice(string name)
        {
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string text = "SELECT * FROM recipes WHERE name='" + name + "'";

                MySqlCommand cmd = new MySqlCommand(text, conn);

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    return rdr.GetInt32("price");
                }
                else
                {
                    return 0;
                }
            }
            catch (MySqlException)
            {
                return 0;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public List<string> GetMenuStrings()
        {
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            try
            {
                List<string> result = new List<string>();
                conn = new MySqlConnection(cs);
                conn.Open();

                string text = "SELECT name FROM recipes";

                MySqlCommand cmd = new MySqlCommand(text, conn);

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(rdr.GetString(0));
                }
                return result;
            }
            catch (MySqlException)
            {
                return null;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public List<int> GetMenuPrices()
        {
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            try
            {
                List<int> result = new List<int>();
                conn = new MySqlConnection(cs);
                conn.Open();

                string text = "SELECT price FROM recipes";

                MySqlCommand cmd = new MySqlCommand(text, conn);

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(rdr.GetInt32(0));
                }
                return result;
            }
            catch (MySqlException)
            {
                return null;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void AddItemToWarehouse(string item, int quantity)
        {
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string text = "SELECT portions FROM warehouse WHERE name='" + item + "'";

                MySqlCommand cmd = new MySqlCommand(text, conn);

                rdr = cmd.ExecuteReader();
                int p = quantity;
                if (rdr.Read())
                {
                    p += rdr.GetInt32(0);
                    rdr.Close();
                    string text2 = "UPDATE warehouse SET portions=" + p/*.ToString()*/ + " WHERE name='" + item + "'";
                    MySqlCommand cmd2 = new MySqlCommand(text2, conn);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    p = 0;
                }
            }
            catch (MySqlException)
            { }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public bool RemoveItemFromWarehouse(string item, int quantity)
        {
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            bool res = false;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string text = "SELECT portions FROM warehouse WHERE name='" + item + "'";

                MySqlCommand cmd = new MySqlCommand(text, conn);

                rdr = cmd.ExecuteReader();
                int p = -quantity;
                if (rdr.Read())
                {
                    p += rdr.GetInt32(0);
                    rdr.Close();
                    if (p < 0)
                        p = 0;
                    else
                        res = true;
                    string text2 = "UPDATE warehouse SET portions=" + p/*.ToString()*/ + " WHERE name='" + item + "'";
                    MySqlCommand cmd2 = new MySqlCommand(text2, conn);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    p = 0;
                }
                return res;
            }
            catch (MySqlException)
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public List<string> GetWarehouseStrings()
        {
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;

            try
            {
                List<string> result = new List<string>();
                conn = new MySqlConnection(cs);
                conn.Open();

                string text = "SELECT name FROM warehouse";

                MySqlCommand cmd = new MySqlCommand(text, conn);

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(rdr.GetString(0));
                }
                return result;
            }
            catch (MySqlException)
            {
                return null;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
