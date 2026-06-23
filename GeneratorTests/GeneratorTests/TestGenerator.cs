using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeneratorTests
{
    public class TestGenerator
    {
        private List<Question> _allQuestions = new List<Question>();
        private Random _random = new Random();
        private int _nextId = 1;

        public void SetQuestions(List<Question> questions)
        {
            _allQuestions = questions;
            if (_allQuestions.Count > 0)
                _nextId = _allQuestions[_allQuestions.Count - 1].Id + 1;
        }

        public List<string> GetTopics()
        {
            List<string> topics = new List<string>();
            foreach (Question q in _allQuestions)
            {
                if (!topics.Contains(q.Topic))
                    topics.Add(q.Topic);
            }
            return topics;
        }

        public List<Question> GetQuestionsByTopic(string topic)
        {
            List<Question> result = new List<Question>();
            foreach (Question q in _allQuestions)
            {
                if (q.Topic == topic)
                    result.Add(q);
            }
            return result;
        }

        public List<Test> GenerateVariants(string tema, int kolichestvoVariants, int voprosovVVariante)
        {
            List<Question> available = GetQuestionsByTopic(tema);
            int totalNeeded = kolichestvoVariants * voprosovVVariante;

            if (available.Count < totalNeeded)
            {
                MessageBox.Show($"Ошибка! Для создания {kolichestvoVariants} вариантов по {voprosovVVariante} " +
                               $"вопросов требуется {totalNeeded} уникальных вопросов. " +
                               $"В теме \"{tema}\" доступно только {available.Count}. Создание невозможно.");
                return new List<Test>();
            }

            List<Question> tempPool = new List<Question>(available);
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
                variants.Add(new Test(v + 1, $"Вариант {v + 1}", variantQuestions));
            }

            return variants;
        }
    }
}
