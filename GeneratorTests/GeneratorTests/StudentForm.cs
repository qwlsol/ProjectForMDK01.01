using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorTests
{
    public partial class StudentForm : Form
    {
        private DatabaseManager _db;
        private User _user;
        private Test _currentTest;
        private TestResult _currentResult;
        private int _currentIndex = 0;
        public StudentForm(DatabaseManager db)
        {
            InitializeComponent();
            _db = db;
            _user = new User(2, "student", "", UserRole.Student);
            _user.TestResults = _db.GetUserResults(2);
        }
        private void UpdateStatus()
        {
            lblStatus.Text = $"Студент. Пройдено: {_user.TestResults.Count}";
        }
        private string GetTypeName(QuestionType type)
        {
            if (type == QuestionType.Single) return "одиночный";
            if (type == QuestionType.Multiple) return "множественный";
            return "текстовый";
        }
    }
}
