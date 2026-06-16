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
    }
}
