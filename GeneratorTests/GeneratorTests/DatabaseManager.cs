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

        public DatabaseManager()
        {
            CreateTables();
            CreateDefaultUsers();
        }
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
        public List<Question> LoadQuestions()
        {
            List<Question> questions = new List<Question>();
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Questions ORDER BY Id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string optionsStr = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        List<string> options = new List<string>();
                        if (!string.IsNullOrEmpty(optionsStr))
                            options.AddRange(optionsStr.Split('|'));

                        questions.Add(new Question(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            options,
                            (QuestionType)reader.GetInt32(6)
                        ));
                    }
                }
            }
            return questions;
        }
        public void SaveQuestion(Question q)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string optionsStr = q.Options != null ? string.Join("|", q.Options) : "";
                string sql = @"
                    INSERT INTO Questions (Text, Topic, Difficulty, CorrectAnswer, Options, Type)
                    VALUES (@Text, @Topic, @Difficulty, @CorrectAnswer, @Options, @Type)
                    RETURNING Id;
                ";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Text", q.Text);
                    cmd.Parameters.AddWithValue("@Topic", q.Topic);
                    cmd.Parameters.AddWithValue("@Difficulty", q.Difficulty);
                    cmd.Parameters.AddWithValue("@CorrectAnswer", q.CorrectAnswer ?? "");
                    cmd.Parameters.AddWithValue("@Options", optionsStr);
                    cmd.Parameters.AddWithValue("@Type", (int)q.Type);
                    q.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public void UpdateQuestion(Question q)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string optionsStr = q.Options != null ? string.Join("|", q.Options) : "";
                string sql = @"
                    UPDATE Questions SET Text=@Text, Topic=@Topic, Difficulty=@Difficulty,
                        CorrectAnswer=@CorrectAnswer, Options=@Options, Type=@Type
                    WHERE Id=@Id
                ";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", q.Id);
                    cmd.Parameters.AddWithValue("@Text", q.Text);
                    cmd.Parameters.AddWithValue("@Topic", q.Topic);
                    cmd.Parameters.AddWithValue("@Difficulty", q.Difficulty);
                    cmd.Parameters.AddWithValue("@CorrectAnswer", q.CorrectAnswer ?? "");
                    cmd.Parameters.AddWithValue("@Options", optionsStr);
                    cmd.Parameters.AddWithValue("@Type", (int)q.Type);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteQuestion(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Questions WHERE Id=@Id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private string GetHash(string password)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hash = md5.ComputeHash(bytes);
                return Convert.ToHexString(hash);
            }
        }
        public List<TestResult> GetUserResults(int userId)
        {
            List<TestResult> results = new List<TestResult>();
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM TestResults WHERE UserId=@UserId ORDER BY Timestamp DESC";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TestResult tr = new TestResult(
                                reader.GetInt32(2),
                                reader.GetInt32(1),
                                reader.GetInt32(4)
                            );
                            tr.Score = reader.GetInt32(3);
                            tr.Timestamp = reader.GetDateTime(5);
                            results.Add(tr);
                        }
                    }
                }
            }
            return results;
        }
        public void SaveTestResult(TestResult result)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"
                    INSERT INTO TestResults (UserId, TestId, Score, MaxScore, Timestamp)
                    VALUES (@UserId, @TestId, @Score, @MaxScore, @Timestamp)
                ";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", result.UserId);
                    cmd.Parameters.AddWithValue("@TestId", result.TestId);
                    cmd.Parameters.AddWithValue("@Score", result.Score);
                    cmd.Parameters.AddWithValue("@MaxScore", result.MaxScore);
                    cmd.Parameters.AddWithValue("@Timestamp", result.Timestamp);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public bool ValidateUser(string login, string password, out UserRole role)
        {
            role = UserRole.Student;
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT Role, PasswordHash FROM Users WHERE Login=@Login";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Login", login);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hash = reader.GetString(1);
                            if (hash == GetHash(password))
                            {
                                role = (UserRole)reader.GetInt32(0);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void AddUser(string login, string password, UserRole role)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Users (Login, PasswordHash, Role) VALUES (@Login, @Password, @Role)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@Password", GetHash(password));
                    cmd.Parameters.AddWithValue("@Role", (int)role);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void CreateDefaultUsers()
        {
            if (!ValidateUser("teacher", "123", out _))
                AddUser("teacher", "123", UserRole.Teacher);
            if (!ValidateUser("student", "123", out _))
                AddUser("student", "123", UserRole.Student);
        }
    }
}
    

