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
        private void ShowQuestion()
        {
            Question q = _currentTest.Questions[_currentIndex];
            listBoxQuestions.Items.Clear();
            listBoxQuestions.Items.Add($"Вопрос {_currentIndex + 1} из {_currentTest.Questions.Count}");
            listBoxQuestions.Items.Add("");
            listBoxQuestions.Items.Add(q.Text);
            listBoxQuestions.Items.Add("");
            listBoxQuestions.Items.Add($"Тип: {GetTypeName(q.Type)}");
            listBoxQuestions.Items.Add($"Сложность: {q.Difficulty}");

            if (q.Type == QuestionType.Single || q.Type == QuestionType.Multiple)
            {
                listBoxQuestions.Items.Add("");
                listBoxQuestions.Items.Add("Варианты:");
                for (int j = 0; j < q.Options.Count; j++)
                    listBoxQuestions.Items.Add($"   {(char)(65 + j)}) {q.Options[j]}");
                listBoxQuestions.Items.Add("");
                listBoxQuestions.Items.Add(q.Type == QuestionType.Single ? "Введите букву (a, b, c...)" : "Введите буквы (a,b,c...)");
            }
            else
            {
                listBoxQuestions.Items.Add("");
                listBoxQuestions.Items.Add("Введите ответ:");
            }

            txtAnswer.Text = "";
            txtAnswer.Focus();
        }
    }
}
