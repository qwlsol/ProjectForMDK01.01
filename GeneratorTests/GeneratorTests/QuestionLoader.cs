using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorTests
{
    public class QuestionLoader
    {
        private int _nextId = 1;

        private void SaveQuestion(LoadingResult result, string topic, string text, string correct,
            string difficulty, string type, List<string> options, int startLine)
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(topic))
            {
                result.Errors.Add($"Строка {startLine}: отсутствует поле 'Тема:'. Вопрос пропущен.");
                hasError = true;
            }

            if (string.IsNullOrEmpty(text))
            {
                result.Errors.Add($"Строка {startLine}: отсутствует поле 'Вопрос:'. Вопрос пропущен.");
                hasError = true;
            }

            if (type != "текстовый")
            {
                if (options.Count == 0)
                {
                    result.Errors.Add($"Строка {startLine}: нет вариантов ответов. Вопрос пропущен.");
                    hasError = true;
                }
                if (string.IsNullOrEmpty(correct))
                {
                    result.Errors.Add($"Строка {startLine}: нет правильного ответа. Вопрос пропущен.");
                    hasError = true;
                }
            }

            if (hasError)
            {
                result.SkippedCount++;
                return;
            }

            if (string.IsNullOrEmpty(difficulty)) difficulty = "средний";

            QuestionType qt = QuestionType.Single;
            if (type == "множественный") qt = QuestionType.Multiple;
            else if (type == "текстовый") qt = QuestionType.Text;

            Question q = new Question(_nextId, text, topic, difficulty, correct, options, qt);
            result.LoadedQuestions.Add(q);
            _nextId++;
            result.TotalProcessed++;
        }
        public LoadingResult LoadFromFile(string path)
        {
            LoadingResult result = new LoadingResult();
            _nextId = 1;

            try
            {
                if (!File.Exists(path))
                {
                    result.Errors.Add("Файл не найден по указанному пути.");
                    result.Success = false;
                    return result;
                }

                string[] lines = File.ReadAllLines(path, System.Text.Encoding.UTF8);

                if (lines.Length == 0)
                {
                    result.Errors.Add("Файл пуст.");
                    result.Success = false;
                    return result;
                }

                string currentTopic = "";
                string currentText = "";
                string currentCorrect = "";
                string currentDifficulty = "";
                string currentType = "одиночный";
                List<string> currentOptions = new List<string>();
                int questionStartLine = 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int lineNumber = i + 1;
                    string cleanedLine = lines[i].Trim();

                    if (cleanedLine == "")
                    {
                        if (currentText != "")
                        {
                            SaveQuestion(result, currentTopic, currentText, currentCorrect,
                                currentDifficulty, currentType, currentOptions, questionStartLine);
                            currentText = "";
                            currentTopic = "";
                            currentCorrect = "";
                            currentDifficulty = "";
                            currentType = "одиночный";
                            currentOptions = new List<string>();
                        }
                        continue;
                    }

                    if (questionStartLine == 0) questionStartLine = lineNumber;

                    if (cleanedLine.StartsWith("Тема:"))
                        currentTopic = cleanedLine.Substring(4).Trim();
                    else if (cleanedLine.StartsWith("Вопрос:"))
                        currentText = cleanedLine.Substring(7).Trim();
                    else if (cleanedLine.StartsWith("Варианты:"))
                    {
                        string optsText = cleanedLine.Substring(9).Trim();
                        string[] parts = optsText.Split(';');
                        foreach (string part in parts)
                            if (!string.IsNullOrEmpty(part.Trim()))
                                currentOptions.Add(part.Trim());
                    }
                    else if (cleanedLine.StartsWith("Правильный ответ:"))
                        currentCorrect = cleanedLine.Substring(17).Trim();
                    else if (cleanedLine.StartsWith("Тип:"))
                    {
                        currentType = cleanedLine.Substring(4).Trim();
                        if (currentType != "одиночный" && currentType != "множественный" && currentType != "текстовый")
                        {
                            result.Errors.Add($"В вопросе со строки {questionStartLine} некорректный тип. Установлен 'одиночный'.");
                            currentType = "одиночный";
                        }
                    }
                    else if (cleanedLine.StartsWith("Сложность:"))
                        currentDifficulty = cleanedLine.Substring(10).Trim();
                }

                if (currentText != "")
                {
                    SaveQuestion(result, currentTopic, currentText, currentCorrect,
                        currentDifficulty, currentType, currentOptions, questionStartLine);
                }

                result.Success = result.LoadedQuestions.Count > 0;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors.Add($"Ошибка: {ex.Message}");
                result.Success = false;
                return result;
            }
        }
    }
}
   

