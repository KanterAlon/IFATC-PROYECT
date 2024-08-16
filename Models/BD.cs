using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

public class BD
{
    private static string _connectionString = @"Server=186.19.182.109\SQLEXPRESS,1433;Database=JJOO;User Id=sa;Password=barpetalon10";

    //public static string _connectionString = @"Server=localhost;Database=JJOO;Trusted_Connection=True;";

    public BD(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<User> GetAllUsers()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return connection.Query<User>("SELECT * FROM Users");
        }
    }

    public IEnumerable<Session> GetAllSessions()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return connection.Query<Session>("SELECT * FROM Sessions");
        }
    }

    public IEnumerable<Feedback> GetAllFeedback()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return connection.Query<Feedback>("SELECT * FROM Feedback");
        }
    }
}