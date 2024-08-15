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