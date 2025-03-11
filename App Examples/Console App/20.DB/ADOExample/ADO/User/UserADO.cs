using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BoscComa.ADO
{
    public class UserADO
    {
        private readonly IConnection _connection;

        public UserADO(IConnection connection)
        {
            _connection = connection;
        }

        public bool Create(User user)
        {
            string query = "INSERT INTO Users (Uuid, Name, Email, DateOfBirth, HashPassword, SaltPassword) VALUES (@Uuid, @Name, @Email, @DateOfBirth, @PasswordHash, @Salt)";

            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Uuid", user.Uuid);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@DateOfBirth", (object?)user.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PasswordHash", user.GetHashPassword()); // Mètode que retorna byte[]
                cmd.Parameters.AddWithValue("@Salt", user.GetSalt()); // Mètode que retorna byte[]

                _connection.GetConnection().Open();
                cmd.ExecuteNonQuery();
                _connection.GetConnection().Close();
            }
            return true;
        }

        public User? GetByEmail(string email)
        {
            string query = "SELECT * FROM Users WHERE Email = @Email";

            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                _connection.GetConnection().Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User user = new User
                        {
                            Uuid = reader["Uuid"].ToString(),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            DateOfBirth = reader["DateOfBirth"] as DateTime?
                        };
                        user.SetHashPassword((byte[])reader["HashPassword"]);
                        user.SetSalt((byte[])reader["SaltPassword"]);
                        _connection.GetConnection().Close();
                        return user;
                    }
                }
                _connection.GetConnection().Close();
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM Users";
        
            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                _connection.GetConnection().Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User
                        {
                            Uuid = reader["Uuid"].ToString(),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            DateOfBirth = reader["DateOfBirth"] as DateTime?
                        };
                        user.SetHashPassword((byte[])reader["HashPassword"]);
                        user.SetSalt((byte[])reader["SaltPassword"]);
                        users.Add(user);
                    }
                }
                _connection.GetConnection().Close();
            }
            return users;
        }


        
        public void Update(User user)
        {
            string query = "UPDATE Users SET Name = @Name, DateOfBirth = @DateOfBirth WHERE Email = @Email";

            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", (object?)user.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                _connection.GetConnection().Open();
                cmd.ExecuteNonQuery();
                _connection.GetConnection().Close();
            }
        }

        public void Delete(string email)
        {
            string query = "DELETE FROM Users WHERE Email = @Email";

            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Email", email);

                _connection.GetConnection().Open();
                cmd.ExecuteNonQuery();
                _connection.GetConnection().Close();
            }
        }
    }
}
