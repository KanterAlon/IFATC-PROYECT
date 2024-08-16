using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

public class BD
{
    private readonly string _connectionString;

    public BD(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddUser(User user)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "INSERT INTO Users (UserName, UserRole, Email, PasswordHash) VALUES (@UserName, @UserRole, @Email, @PasswordHash)";
            connection.Execute(sql, user);
        }
    }

    public IEnumerable<User> GetAllUsers()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return connection.Query<User>("SELECT * FROM Users");
        }
    }
}
