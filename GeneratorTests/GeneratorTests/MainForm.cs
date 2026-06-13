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

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != UserRole.Teacher)
            {
                MessageBox.Show("Только преподаватель может редактировать вопросы");
                return;
            }
            MessageBox.Show("Редактирование вопроса");
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != UserRole.Student)
            {
                MessageBox.Show("Только студент может проходить тесты. Войдите как студент");
                return;
            }

            if (_currentTest == null)
            {
                MessageBox.Show("Сначала преподаватель должен создать тест");
                return;
            }

            _activeResult = new TestResult(_currentTest.Id, _currentUser.Id, _currentTest.Questions.Count);
            currentQuestionIndex = 0;
            MessageBox.Show("Тест начат. Отвечайте на вопросы");

            if (_currentTest.Questions.Count > 0)
            {
                ShowQuestion(0);
            }
        }
        private void ShowQuestion(int index)
        {
            Question q = _currentTest.Questions[index];
            listBoxQuestions.Items.Clear();
            listBoxQuestions.Items.Add("Вопрос " + (index + 1) + " из " + _currentTest.Questions.Count);
            listBoxQuestions.Items.Add("");
            listBoxQuestions.Items.Add(q.Text);
            listBoxQuestions.Items.Add("");
            listBoxQuestions.Items.Add("Тип вопроса: " + GetTypeName(q.Type));

            if (q.Type == QuestionType.Single || q.Type == QuestionType.Multiple)
            {
                listBoxQuestions.Items.Add("");
                listBoxQuestions.Items.Add("Варианты ответов:");
                for (int j = 0; j < q.Options.Count; j++)
                {
                    char letter = (char)(65 + j);
                    listBoxQuestions.Items.Add("   " + letter + ") " + q.Options[j]);
                }

                if (q.Type == QuestionType.Single)
                {
                    listBoxQuestions.Items.Add("");
                    listBoxQuestions.Items.Add("Введите букву правильного ответа (например: a)");
                }
                else
                {
                    listBoxQuestions.Items.Add("");
                    listBoxQuestions.Items.Add("Введите буквы правильных ответов через запятую (например: a,b)");
                }
            }
            else
            {
                listBoxQuestions.Items.Add("");
                listBoxQuestions.Items.Add("Введите текстовый ответ:");
            }

            txtAnswer.Text = "";
            txtAnswer.Focus();
        }

        private void btnSubmitAnswer_Click(object sender, EventArgs e)
        {
           
                if (_activeResult == null)
                {
                    MessageBox.Show("Сначала начните тест");
                    return;
                }

                if (currentQuestionIndex < _currentTest.Questions.Count)
                {
                    Question q = _currentTest.Questions[currentQuestionIndex];

                    string userAnswer = txtAnswer.Text;
                    string cleanedAnswer = "";
                    int startIdx = 0;
                    int endIdx = userAnswer.Length - 1;

                    for (int k = 0; k < userAnswer.Length; k++)
                    {
                        if (userAnswer[k] != ' ')
                        {
                            startIdx = k;
                            break;
                        }
                    }
                    for (int k = userAnswer.Length - 1; k >= 0; k--)
                    {
                        if (userAnswer[k] != ' ')
                        {
                            endIdx = k;
                            break;
                        }
                    }
                    for (int k = startIdx; k <= endIdx; k++)
                    {
                        cleanedAnswer = cleanedAnswer + userAnswer[k];
                    }

                    string lowerAnswer = "";
                    for (int k = 0; k < cleanedAnswer.Length; k++)
                    {
                        char c = cleanedAnswer[k];
                        if (c >= 'A' && c <= 'Z')
                        {
                            lowerAnswer = lowerAnswer + (char)(c + 32);
                        }
                        else
                        {
                            lowerAnswer = lowerAnswer + c;
                        }
                    }

                    userAnswer = lowerAnswer;

                    if (userAnswer == "")
                    {
                        MessageBox.Show("Введите ответ");
                        return;
                    }

                    string finalAnswer = userAnswer;

                    if (q.Type == QuestionType.Single)
                    {
                        finalAnswer = ConvertLetterToAnswer(q, userAnswer);
                    }
                    else if (q.Type == QuestionType.Multiple)
                    {
                        finalAnswer = ConvertLettersToAnswer(q, userAnswer);
                    }

                    _activeResult.SetAnswer(q.Id, finalAnswer);
                    currentQuestionIndex++;

                    if (currentQuestionIndex < _currentTest.Questions.Count)
                    {
                        ShowQuestion(currentQuestionIndex);
                    }
                    else
                    {
                        MessageBox.Show("Все вопросы пройдены! Нажмите 'Завершить'");
                    }
                }
        }
        

        private void btnFinishTest_Click(object sender, EventArgs e)
        {

        }
        private string ConvertLetterToAnswer(Question q, string letter)
        {
            letter = letter.Trim().ToLower();

            if (letter == "a" && q.Options.Count > 0) return q.Options[0];
            if (letter == "b" && q.Options.Count > 1) return q.Options[1];
            if (letter == "c" && q.Options.Count > 2) return q.Options[2];
            if (letter == "d" && q.Options.Count > 3) return q.Options[3];

            return letter;
        }
        private string ConvertLettersToAnswer(Question q, string letters)
        {
            List<string> answerLetters = new List<string>();
            string currentLetter = "";
            for (int k = 0; k < letters.Length; k++)
            {
                if (letters[k] == ',')
                {
                    if (currentLetter != "")
                    {
                        answerLetters.Add(currentLetter);
                        currentLetter = "";
                    }
                }
                else
                {
                    currentLetter = currentLetter + letters[k];
                }
            }
            if (currentLetter != "")
            {
                answerLetters.Add(currentLetter);
            }

            List<string> answers = new List<string>();
            for (int i = 0; i < answerLetters.Count; i++)
            {
                string letter = answerLetters[i];
                if (letter == "a" && q.Options.Count > 0) answers.Add(q.Options[0]);
                else if (letter == "b" && q.Options.Count > 1) answers.Add(q.Options[1]);
                else if (letter == "c" && q.Options.Count > 2) answers.Add(q.Options[2]);
                else if (letter == "d" && q.Options.Count > 3) answers.Add(q.Options[3]);
                else answers.Add(letter);
            }

            string result = "";
            for (int i = 0; i < answers.Count; i++)
            {
                result = result + answers[i];
                if (i < answers.Count - 1)
                {
                    result = result + ",";
                }
            }
            return result;
        }
    }
}
