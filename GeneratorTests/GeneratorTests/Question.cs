using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorTests
{
    public enum QuestionType
    {
        Single,
        Multiple,
        Text
    }
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Topic { get; set; }
        public string Difficulty { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> Options { get; set; }
        public QuestionType Type { get; set; }
    }
}
