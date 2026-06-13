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

                    // Убираем пробелы вручную (вместо Trim)
                    string cleanedLine = "";
                    int startIndex = 0;
                    int endIndex = line.Length - 1;

                    // Убираем пробелы в начале
                    for (int k = 0; k < line.Length; k++)
                    {
                        if (line[k] != ' ')
                        {
                            startIndex = k;
                            break;
                        }
                    }
                    // Убираем пробелы в конце
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

                    if (cleanedLine == "")
                    {
                        if (currentText != "")
                        {
                            SaveQuestion(currentTopic, currentText, currentCorrect,
                                currentDifficulty, currentType, currentOptions);
                            currentText = "";
                            currentTopic = "";
                            currentCorrect = "";
                            currentDifficulty = "";
                            currentType = "одиночный";
                            currentOptions = new List<string>();
                        }
                        continue;
                    }

                    bool isTopic = false;
                    bool isQuestion = false;
                    bool isOptions = false;
                    bool isCorrect = false;
                    bool isType = false;
                    bool isDifficulty = false;

                    if (cleanedLine.Length >= 5 &&
                        cleanedLine[0] == 'Т' &&
                        cleanedLine[1] == 'е' &&
                        cleanedLine[2] == 'м' &&
                        cleanedLine[3] == 'а' &&
                        cleanedLine[4] == ':')
                    {
                        isTopic = true;
                    }
                    if (cleanedLine.Length >= 7 &&
                        cleanedLine[0] == 'В' &&
                        cleanedLine[1] == 'о' &&
                        cleanedLine[2] == 'п' &&
                        cleanedLine[3] == 'р' &&
                        cleanedLine[4] == 'о' &&
                        cleanedLine[5] == 'с' &&
                        cleanedLine[6] == ':')
                    {
                        isQuestion = true;
                    }
                    if (cleanedLine.Length >= 9 &&
                        cleanedLine[0] == 'В' &&
                        cleanedLine[1] == 'а' &&
                        cleanedLine[2] == 'р' &&
                        cleanedLine[3] == 'и' &&
                        cleanedLine[4] == 'а' &&
                        cleanedLine[5] == 'н' &&
                        cleanedLine[6] == 'т' &&
                        cleanedLine[7] == 'ы' &&
                        cleanedLine[8] == ':')
                    {
                        isOptions = true;
                    }
                    if (cleanedLine.Length >= 18 &&
                        cleanedLine[0] == 'П' &&
                        cleanedLine[1] == 'р' &&
                        cleanedLine[2] == 'а' &&
                        cleanedLine[3] == 'в' &&
                        cleanedLine[4] == 'и' &&
                        cleanedLine[5] == 'л' &&
                        cleanedLine[6] == 'ь' &&
                        cleanedLine[7] == 'н' &&
                        cleanedLine[8] == 'ы' &&
                        cleanedLine[9] == 'й' &&
                        cleanedLine[10] == ' ' &&
                        cleanedLine[11] == 'о' &&
                        cleanedLine[12] == 'т' &&
                        cleanedLine[13] == 'в' &&
                        cleanedLine[14] == 'е' &&
                        cleanedLine[15] == 'т' &&
                        cleanedLine[16] == ':' &&
                        cleanedLine[17] == ' ')
                    {
                        isCorrect = true;
                    }
                    if (cleanedLine.Length >= 4 &&
                        cleanedLine[0] == 'Т' &&
                        cleanedLine[1] == 'и' &&
                        cleanedLine[2] == 'п' &&
                        cleanedLine[3] == ':')
                    {
                        isType = true;
                    }
                    if (cleanedLine.Length >= 10 &&
                        cleanedLine[0] == 'С' &&
                        cleanedLine[1] == 'л' &&
                        cleanedLine[2] == 'о' &&
                        cleanedLine[3] == 'ж' &&
                        cleanedLine[4] == 'н' &&
                        cleanedLine[5] == 'о' &&
                        cleanedLine[6] == 'с' &&
                        cleanedLine[7] == 'т' &&
                        cleanedLine[8] == 'ь' &&
                        cleanedLine[9] == ':')
                    {
                        isDifficulty = true;
                    }
                    if (isTopic)
                    {
                        currentTopic = "";
                        for (int k = 5; k < cleanedLine.Length; k++)
                        {
                            currentTopic = currentTopic + cleanedLine[k];
                        }
                        if (currentTopic.Length > 0 && currentTopic[0] == ' ')
                        {
                            string temp = "";
                            for (int k = 1; k < currentTopic.Length; k++)
                            {
                                temp = temp + currentTopic[k];
                            }
                            currentTopic = temp;
                        }
                    }

                }
        }
    }
}

