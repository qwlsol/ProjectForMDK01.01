using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorTests
{
    public class TestGenerator
    {
        private List<Question> _allQuestions = new List<Question>();
        private Random _random = new Random();
        private int _nextId = 1;

        public bool LoadFromFile(string path)
        {
            try
            {
                _allQuestions.Clear();
                _nextId = 1;

                string[] lines = File.ReadAllLines(path);

                if (lines.Length == 0)
                {
                    MessageBox.Show("Файл пуст. Добавьте вопросы.");
                    return false;
                }

            }
    }
}
