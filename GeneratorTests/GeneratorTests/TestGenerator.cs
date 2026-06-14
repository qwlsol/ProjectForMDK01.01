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
                    else if (isQuestion)
                    {
                        currentText = "";
                        for (int k = 7; k < cleanedLine.Length; k++)
                        {
                            currentText = currentText + cleanedLine[k];
                        }
                        if (currentText.Length > 0 && currentText[0] == ' ')
                        {
                            string temp = "";
                            for (int k = 1; k < currentText.Length; k++)
                            {
                                temp = temp + currentText[k];
                            }
                            currentText = temp;
                        }
                    }
                    else if (isOptions)
                    {
                        string optsText = "";
                        for (int k = 9; k < cleanedLine.Length; k++)
                        {
                            optsText = optsText + cleanedLine[k];
                        }
                        if (optsText.Length > 0 && optsText[0] == ' ')
                        {
                            string temp = "";
                            for (int k = 1; k < optsText.Length; k++)
                            {
                                temp = temp + optsText[k];
                            }
                            optsText = temp;
                        }
                        currentOptions = new List<string>();
                        if (optsText != "")
                        {
                            string currentOption = "";
                            for (int k = 0; k < optsText.Length; k++)
                            {
                                if (optsText[k] == ';')
                                {
                                    if (currentOption != "")
                                    {
                                        string cleanOpt = "";
                                        int optStart = 0;
                                        int optEnd = currentOption.Length - 1;
                                        for (int m = 0; m < currentOption.Length; m++)
                                        {
                                            if (currentOption[m] != ' ')
                                            {
                                                optStart = m;
                                                break;
                                            }
                                        }
                                        for (int m = currentOption.Length - 1; m >= 0; m--)
                                        {
                                            if (currentOption[m] != ' ')
                                            {
                                                optEnd = m;
                                                break;
                                            }
                                        }
                                        for (int m = optStart; m <= optEnd; m++)
                                        {
                                            cleanOpt = cleanOpt + currentOption[m];
                                        }
                                        currentOptions.Add(cleanOpt);
                                        currentOption = "";
                                    }
                                }
                                else
                                {
                                    currentOption = currentOption + optsText[k];
                                }
                            }
                            if (currentOption != "")
                            {
                                string cleanOpt = "";
                                int optStart = 0;
                                int optEnd = currentOption.Length - 1;
                                for (int m = 0; m < currentOption.Length; m++)
                                {
                                    if (currentOption[m] != ' ')
                                    {
                                        optStart = m;
                                        break;
                                    }
                                }
                                for (int m = currentOption.Length - 1; m >= 0; m--)
                                {
                                    if (currentOption[m] != ' ')
                                    {
                                        optEnd = m;
                                        break;
                                    }
                                }
                                for (int m = optStart; m <= optEnd; m++)
                                {
                                    cleanOpt = cleanOpt + currentOption[m];
                                }
                                currentOptions.Add(cleanOpt);
                            }
                        }
                    }
                    else if (isCorrect)
                    {
                        currentCorrect = "";
                        for (int k = 18; k < cleanedLine.Length; k++)
                        {
                            currentCorrect = currentCorrect + cleanedLine[k];
                        }
                        if (currentCorrect.Length > 0 && currentCorrect[0] == ' ')
                        {
                            string temp = "";
                            for (int k = 1; k < currentCorrect.Length; k++)
                            {
                                temp = temp + currentCorrect[k];
                            }
                            currentCorrect = temp;
                        }
                    }
                    else if (isType)
                    {
                        currentType = "";
                        for (int k = 4; k < cleanedLine.Length; k++)
                        {
                            currentType = currentType + cleanedLine[k];
                        }
                        if (currentType.Length > 0 && currentType[0] == ' ')
                        {
                            string temp = "";
                            for (int k = 1; k < currentType.Length; k++)
                            {
                                temp = temp + currentType[k];
                            }
                            currentType = temp;
                        }
                    }
                    else if (isDifficulty)
                    {
                        currentDifficulty = "";
                        for (int k = 10; k < cleanedLine.Length; k++)
                        {
                            currentDifficulty = currentDifficulty + cleanedLine[k];
                        }
                        if (currentDifficulty.Length > 0 && currentDifficulty[0] == ' ')
                        {
                            string temp = "";
                            for (int k = 1; k < currentDifficulty.Length; k++)
                            {
                                temp = temp + currentDifficulty[k];
                            }
                            currentDifficulty = temp;
                        }
                    }
                }
                if (currentText != "")
                {
                    SaveQuestion(currentTopic, currentText, currentCorrect,
                        currentDifficulty, currentType, currentOptions);
                }

                MessageBox.Show("Загружено " + _allQuestions.Count + " вопросов");
                return _allQuestions.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                return false;
            }
        }
        private void SaveQuestion(string topic, string text, string correct,
           string difficulty, string type, List<string> options)
        {
            QuestionType qt = QuestionType.Single;
            if (type == "множественный")
                qt = QuestionType.Multiple;
            else if (type == "текстовый")
                qt = QuestionType.Text;

            Question q = new Question(_nextId, text, topic, difficulty, correct, options, qt);
            _allQuestions.Add(q);
            _nextId++;
        }
        public List<string> GetTopics()
        {
            List<string> topics = new List<string>();
            for (int i = 0; i < _allQuestions.Count; i++)
            {
                Question q = _allQuestions[i];
                bool found = false;
                for (int j = 0; j < topics.Count; j++)
                {
                    if (topics[j] == q.Topic)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    topics.Add(q.Topic);
                }
            }
            return topics;
        }
        public List<Question> GetQuestionsByTopic(string topic)
        {
            List<Question> result = new List<Question>();
            for (int i = 0; i < _allQuestions.Count; i++)
            {
                if (_allQuestions[i].Topic == topic)
                {
                    result.Add(_allQuestions[i]);
                }
            }
            return result;
        }
        public List<Test> GenerateVariants(string tema, int kolichestvoVariants, int voprosovVVariante)
        {
            List<Question> available = GetQuestionsByTopic(tema);
            int totalNeeded = kolichestvoVariants * voprosovVVariante;

            if (available.Count < totalNeeded)
            {
                MessageBox.Show("Ошибка! Для создания " + kolichestvoVariants + " вариантов по " + voprosovVVariante +
                               " вопросов требуется " + totalNeeded + " уникальных вопросов. " +
                               "В теме \"" + tema + "\" доступно только " + available.Count + ". Создание невозможно.");
                return new List<Test>();
            }

            List<Question> tempPool = new List<Question>();
            for (int i = 0; i < available.Count; i++)
            {
                tempPool.Add(available[i]);
            }

            List<Test> variants = new List<Test>();

            for (int v = 0; v < kolichestvoVariants; v++)
            {
                List<Question> variantQuestions = new List<Question>();

                for (int q = 0; q < voprosovVVariante; q++)
                {
                    int idx = _random.Next(0, tempPool.Count);
                    variantQuestions.Add(tempPool[idx]);
                    tempPool.RemoveAt(idx);
                }

                variants.Add(new Test(v + 1, "Вариант " + (v + 1), variantQuestions));
            }

            return variants;
        }
    }
}
