using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorTests
{
    public class DatabaseManager
    {
        private string _connectionString =
            "Host=localhost;Username=postgres;Password=123;Database=generator_tests";

        private void CreateTables()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"
                    CREATE TABLE IF NOT EXISTS Questions (
                        Id SERIAL PRIMARY KEY,
                        Text TEXT NOT NULL,
                        Topic TEXT NOT NULL,
                        Difficulty TEXT NOT NULL,
                        CorrectAnswer TEXT NOT NULL,
                        Options TEXT,
                        Type INTEGER NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS Users (
                        Id SERIAL PRIMARY KEY,
                        Login TEXT NOT NULL UNIQUE,
                        PasswordHash TEXT NOT NULL,
                        Role INTEGER NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS TestResults (
                        Id SERIAL PRIMARY KEY,
                        UserId INTEGER NOT NULL,
                        TestId INTEGER NOT NULL,
                        Score INTEGER NOT NULL,
                        MaxScore INTEGER NOT NULL,
                        Timestamp TIMESTAMP NOT NULL
                    );
                ";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
