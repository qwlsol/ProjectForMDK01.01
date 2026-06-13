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
    }
}
