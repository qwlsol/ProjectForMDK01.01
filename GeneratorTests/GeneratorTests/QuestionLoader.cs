using System;
using System.Collections.Generic;
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
    }
}
   

