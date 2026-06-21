using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorTests
{
    public class LoadingResult
    {
        public bool Success { get; set; }
        public List<Question> LoadedQuestions { get; set; } = new List<Question>();
        public List<string> Errors { get; set; } = new List<string>();
        public int TotalProcessed { get; set; }
        public int SkippedCount { get; set; }
    }
}
