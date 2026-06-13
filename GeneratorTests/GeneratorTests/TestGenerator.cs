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
                string currentTopic = "";
                string currentText = "";
                string currentCorrect = "";
                string currentDifficulty = "";
                string currentType = "одиночный";
                List<string> currentOptions = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];

                    string cleanedLine = "";
                    int startIndex = 0;
                    int endIndex = line.Length - 1;

                    for (int k = 0; k < line.Length; k++)
                    {
                        if (line[k] != ' ')
                        {
                            startIndex = k;
                            break;
                        }
                    }
                    for (int k = line.Length - 1; k >= 0; k--)
                    {
                        if (line[k] != ' ')
                        {
                            endIndex = k;
                            break;
                        }
                    }
                    for (int k = startIndex; k <= endIndex; k++)
                    {
                        cleanedLine = cleanedLine + line[k];
                    }
                }


            }
        }
    }
}

