using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorTests
{
    public class TestResult
    {
        public int TestId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public Dictionary<int, string> Answers { get; set; }
        public DateTime Timestamp { get; set; }

        public TestResult(int testId, int userId, int maxScore)
        {
            TestId = testId;
            UserId = userId;
            MaxScore = maxScore;
            Score = 0;
            Answers = new Dictionary<int, string>();
            Timestamp = DateTime.Now;
        }
        public void SetAnswer(int questionId, string answer)
        {
            if (Answers.ContainsKey(questionId))
            {
                Answers[questionId] = answer;
            }
            else
            {
                Answers.Add(questionId, answer);
            }
        }
        public void CalculateScore(Test test)
        {
            int correct = 0;

            foreach (KeyValuePair<int, string> item in Answers)
            {
                Question q = test.GetQuestionById(item.Key);
                if (q != null && q.CorrectAnswer == item.Value)
                {
                    correct++;
                }
            }

            Score = correct;
        }
        public string ConvertLetterToAnswer(Question q, string letter)
        {
            letter = letter.Trim().ToLower();

            if (letter == "a" && q.Options.Count > 0) return q.Options[0];
            if (letter == "b" && q.Options.Count > 1) return q.Options[1];
            if (letter == "c" && q.Options.Count > 2) return q.Options[2];
            if (letter == "d" && q.Options.Count > 3) return q.Options[3];

            return letter;
        }

        public string ConvertLettersToAnswer(Question q, string letters)
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
    

