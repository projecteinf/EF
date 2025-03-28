using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BoscComa.ADO
{
    public class ItemADO
    {
        private readonly IConnection<SqlConnection> _connection;

        public ItemADO(IConnection<SqlConnection> connection)
        {
            _connection = connection;
        }

        public bool Create(Item item)
        {
            string query = "INSERT INTO Items (Uuid, Name, Price, UserOwner) VALUES (@Uuid, @Name, @Price, @UserOwner)";

            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Uuid", item.Uuid);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@UserOwner", item.UserOwner);
                _connection.GetConnection().Open();
                cmd.ExecuteNonQuery();
                _connection.GetConnection().Close();
            }
            return true;
        }

        public Item? GetByName(string name)
        {
            string query = "SELECT * FROM Items WHERE Name = @Name";

            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                _connection.GetConnection().Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Item item = new Item
                        {
                            Uuid = reader["Uuid"].ToString(),
                            Name = reader["Name"].ToString(),
                            Price = reader["Price"] == DBNull.Value ? null : Convert.ToDecimal(reader["Price"])
                        };
                        _connection.GetConnection().Close();
                        return item;
                    }
                }
                _connection.GetConnection().Close();
            }
            return null;
        }

        public List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>();
            string query = "SELECT * FROM Items";
        
            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                _connection.GetConnection().Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Item item = new Item
                        {
                            Uuid = reader["Uuid"].ToString(),
                            Name = reader["Name"].ToString(),
                            Price = reader["Price"] == DBNull.Value ? null : Convert.ToDecimal(reader["Price"])
                        };
                        items.Add(item);
                    }
                }
                _connection.GetConnection().Close();
            }
            return items;
        }       
        public bool Update(Item item)
        {
            string query = "UPDATE Items SET Name = @Name, Price = @Price, UserOwner = @UserOwner WHERE Uuid = @Uuid";

            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Uuid", item.Uuid);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@UserOwner", item.UserOwner);

                _connection.GetConnection().Open();
                cmd.ExecuteNonQuery();
                _connection.GetConnection().Close();
            }
            return true;
        }
        public void Delete(string uuid)
        {
            string query = "DELETE FROM Items WHERE UUID = @Uuid";

            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Uuid", uuid);

                _connection.GetConnection().Open();
                cmd.ExecuteNonQuery();
                _connection.GetConnection().Close();
            }
        }
    }
}
