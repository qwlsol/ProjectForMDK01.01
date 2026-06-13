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
    
    }
}
