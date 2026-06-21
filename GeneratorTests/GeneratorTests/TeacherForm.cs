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
    public partial class TeacherForm : Form
    {
        private DatabaseManager _db;
        private TestGenerator _generator = new TestGenerator();
        private WordExporter _exporter = new WordExporter();
        private Test _currentTest;
        public TeacherForm(DatabaseManager db)
        {
            InitializeComponent();
            _db = db;

        }
        private void LoadQuestions()
        {
            var questions = _db.LoadQuestions();
            _generator.SetQuestions(questions);

            cmbTopics.Items.Clear();
            foreach (string topic in _generator.GetTopics())
                cmbTopics.Items.Add(topic);
            if (cmbTopics.Items.Count > 0)
                cmbTopics.SelectedIndex = 0;
        }
        private string GetTypeName(QuestionType type)
        {
            if (type == QuestionType.Single) return "одиночный";
            if (type == QuestionType.Multiple) return "множественный";
            return "текстовый";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовые файлы|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                QuestionLoader loader = new QuestionLoader();
                LoadingResult result = loader.LoadFromFile(ofd.FileName);

                if (result.Errors.Count > 0)
                    new ErrorReportForm(result.Errors).ShowDialog();

                if (result.LoadedQuestions.Count > 0)
                {
                    foreach (Question q in result.LoadedQuestions)
                        _db.SaveQuestion(q);

                    LoadQuestions();
                    MessageBox.Show($"Загружено: {result.LoadedQuestions.Count}, Пропущено: {result.SkippedCount}");
                }
                else
                {
                    MessageBox.Show("Не загружено ни одного вопроса");
                }
            }   
        }

        private void btnGenerateVariants_Click(object sender, EventArgs e)
        {
            if (cmbTopics.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тему");
                return;
            }

            string topic = cmbTopics.SelectedItem.ToString();
            int variants = (int)numVariants.Value;
            int questions = (int)numQuestions.Value;

            List<Test> tests = _generator.GenerateVariants(topic, variants, questions);

            if (tests.Count > 0)
            {
                _currentTest = tests[0];
                listBoxQuestions.Items.Clear();

                foreach (Test test in tests)
                {
                    listBoxQuestions.Items.Add($"-- {test.Title} --");
                    listBoxQuestions.Items.Add("");
                    for (int i = 0; i < test.Questions.Count; i++)
                    {
                        Question q = test.Questions[i];
                        listBoxQuestions.Items.Add($"{i + 1}. {q.Text}");
                        listBoxQuestions.Items.Add($"   [Тип: {GetTypeName(q.Type)}]");
                        listBoxQuestions.Items.Add($"   [Сложность: {q.Difficulty}]");
                        listBoxQuestions.Items.Add("");
                    }
                    listBoxQuestions.Items.Add("");
                }

                MessageBox.Show($"Создано {tests.Count} вариантов");
            }
        }
    }
}
