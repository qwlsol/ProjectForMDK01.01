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
        }
    }
}
