using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BoscComa.ADO
{
    public class UserADO
    {
        private readonly SqlConnection _connection;

        public UserADO(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(User user)
        {
            string query = "INSERT INTO Users (Uuid, Name, Email, DateOfBirth, PasswordHash, Salt) VALUES (@Uuid, @Name, @Email, @DateOfBirth, @PasswordHash, @Salt)";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Uuid", user.Uuid);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@DateOfBirth", (object?)user.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PasswordHash", user.GetHashPassword()); // Mètode que retorna byte[]
                cmd.Parameters.AddWithValue("@Salt", user.GetSalt()); // Mètode que retorna byte[]

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public User? GetByEmail(string email)
        {
            string query = "SELECT * FROM Users WHERE Email = @Email";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                _connection.Open();
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
                        user.SetHashPassword((byte[])reader["PasswordHash"]);
                        user.SetSalt((byte[])reader["Salt"]);
                        _connection.Close();
                        return user;
                    }
                }
                _connection.Close();
            }
            return null;
        }

        public void Update(User user)
        {
            string query = "UPDATE Users SET Name = @Name, DateOfBirth = @DateOfBirth WHERE Email = @Email";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", (object?)user.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Delete(string email)
        {
            string query = "DELETE FROM Users WHERE Email = @Email";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Email", email);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
