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
    }
}
