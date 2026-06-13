using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorTests
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }

        public Test(int id, string title, List<Question> questions)
        {
            Id = id;
            Title = title;
            Questions = questions;
        }
        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }
        public bool RemoveQuestion(int questionId)
        {
            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i].Id == questionId)
                {
                    Questions.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public Question GetQuestionById(int id)
        {
            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i].Id == id)
                {
                    return Questions[i];
                }
            }
            return null;
        }
    }
}
