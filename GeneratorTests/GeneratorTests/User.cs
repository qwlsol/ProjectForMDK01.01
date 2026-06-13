using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorTests
{
    public enum UserRole
    {
        Teacher,
        Student
    }

    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }

        public List<TestResult> TestResults { get; set; }

        public User(int id, string login, string passwordHash, UserRole role)
        {
            Id = id;
            Login = login;
            PasswordHash = passwordHash;
            Role = role;
            TestResults = new List<TestResult>();
        }
        public void AddTestResult(TestResult result)
        {
            TestResults.Add(result);
        }
    }
}
