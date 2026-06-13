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
    public partial class MainForm : Form
    {
        private TestGenerator _generator;
        private WordExporter _exporter;
        private User _currentUser;
        private Test _currentTest;
        private TestResult _activeResult;
        private int currentQuestionIndex = 0;
        public MainForm()
        {
            InitializeComponent();
            _generator = new TestGenerator();
            _exporter = new WordExporter();

            _currentUser = new User(1, "teacher", "123", UserRole.Teacher);
            UpdateUiByRole();
        }
        private void UpdateUiByRole()
        {
            if (_currentUser.Role == UserRole.Teacher)
            {
                btnEditQuestion.Enabled = true;
                btnLoad.Enabled = true;
                btnGenerateVariants.Enabled = true;
                btnSaveWord.Enabled = true;
                lableInput.Enabled = false;
                txtAnswer.Enabled = false;
                lblStatus.Text = "Режим: Преподаватель";

            }
            else
            {
                btnEditQuestion.Enabled = false;
                btnLoad.Enabled = false;
                btnGenerateVariants.Enabled = false;
                btnSaveWord.Enabled = false;
                lableInput.Enabled = true;
                lblStatus.Text = "Режим: Студент";
                txtAnswer.Enabled = true;
            }
        }

        private void btnLoginTeacher_Click(object sender, EventArgs e)
        {
            _currentUser = new User(1, "teacher", "123", UserRole.Teacher);
            UpdateUiByRole();
            MessageBox.Show("Вы вошли как ПРЕПОДАВАТЕЛЬ");
        }
        private void btnLoginStudent_Click(object sender, EventArgs e)
        {
            _currentUser = new User(2, "student", "123", UserRole.Student);
            UpdateUiByRole();
            MessageBox.Show("Вы вошли как СТУДЕНТ");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != UserRole.Teacher)
            {
                MessageBox.Show("Только преподаватель может загружать вопросы");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовые файлы|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (_generator.LoadFromFile(ofd.FileName))
                {
                    List<string> topics = _generator.GetTopics();
                    cmbTopics.Items.Clear();
                    foreach (string topic in topics)
                    {
                        cmbTopics.Items.Add(topic);
                    }
                    if (cmbTopics.Items.Count > 0)
                        cmbTopics.SelectedIndex = 0;
                }
            }
        }
        private string GetTypeName(QuestionType type)
        {
            if (type == QuestionType.Single) return "одиночный выбор";
            if (type == QuestionType.Multiple) return "множественный выбор";
            return "текстовый ввод";
        }

        private void btnGenerateVariants_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != UserRole.Teacher)
            {
                MessageBox.Show("Только преподаватель может создавать варианты");
                return;
            }

            if (cmbTopics.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала загрузите файл с вопросами");
                return;
            }

            string topic = cmbTopics.SelectedItem.ToString();
            int variantCount = (int)numVariants.Value;
            int questionsCount = (int)numQuestions.Value;

            List<Test> variants = _generator.GenerateVariants(topic, variantCount, questionsCount);

            if (variants.Count > 0)
            {
                _currentTest = variants[0];
                listBoxQuestions.Items.Clear();

                for (int v = 0; v < variants.Count; v++)
                {
                    listBoxQuestions.Items.Add("--" + variants[v].Title + "--");
                    listBoxQuestions.Items.Add("");
                    for (int i = 0; i < variants[v].Questions.Count; i++)
                    {
                        Question q = variants[v].Questions[i];
                        listBoxQuestions.Items.Add((i + 1) + ". " + q.Text);
                        listBoxQuestions.Items.Add("   [Тип: " + GetTypeName(q.Type) + "]");
                        listBoxQuestions.Items.Add("   [Сложность: " + q.Difficulty + "]");
                        listBoxQuestions.Items.Add("");
                    }
                    listBoxQuestions.Items.Add("");
                }

                MessageBox.Show("Создано " + variants.Count + " вариантов");
            }
        }

        private void btnSaveWord_Click(object sender, EventArgs e)
        {
                if (_currentTest == null)
                {
                    MessageBox.Show("Сначала создайте тест");
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Word документы|*.docx";
                sfd.FileName = "Тест";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string path = sfd.FileName.Replace(".docx", "");
                    _exporter.SaveVariantsToWord(path, new List<Test> { _currentTest });
                }
        }
    }
}
