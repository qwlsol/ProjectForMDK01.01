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

    }
}
