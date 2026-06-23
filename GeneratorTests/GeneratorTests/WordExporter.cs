using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorTests
{
    public class WordExporter
    {
        public bool SaveToWord(string fileName, Test test)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName + ".docx");

                sw.WriteLine(test.Title);
                sw.WriteLine("------------------------");
                sw.WriteLine();

                for (int i = 0; i < test.Questions.Count; i++)
                {
                    Question q = test.Questions[i];
                    sw.WriteLine((i + 1) + ". " + q.Text);
                    sw.WriteLine();

                    if (q.Options.Count > 0)
                    {
                        for (int j = 0; j < q.Options.Count; j++)
                        {
                            char letter = (char)(65 + j);
                            sw.WriteLine("   " + letter + ") " + q.Options[j]);
                        }
                        sw.WriteLine();
                    }

                    sw.WriteLine("   Ответ: __________");
                    sw.WriteLine();
                }

                sw.Close();
                MessageBox.Show("Сохранено в файл: " + fileName + ".docx");
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка! Не удалось сохранить файл. " + ex.Message);
                return false;
            }
        }
        public bool SaveVariantsToWord(string fileName, List<Test> variants)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName + ".docx");

                for (int v = 0; v < variants.Count; v++)
                {
                    Test variant = variants[v];

                    sw.WriteLine("\t\t" + variant.Title);
                    sw.WriteLine("------------------------------------------------------------");
                    sw.WriteLine();

                    for (int i = 0; i < variant.Questions.Count; i++)
                    {
                        Question q = variant.Questions[i];
                        sw.WriteLine((i + 1) + ". " + q.Text);
                        sw.WriteLine();

                        if (q.Options.Count > 0)
                        {
                            for (int j = 0; j < q.Options.Count; j++)
                            {
                                char letter = (char)(65 + j);
                                sw.WriteLine("   " + letter + ") " + q.Options[j]);
                            }
                            sw.WriteLine();
                        }

                        sw.WriteLine("   Ответ: __________");
                        sw.WriteLine();
                    }

                    sw.WriteLine();
                    sw.WriteLine();
                }

                sw.Close();
                MessageBox.Show("Сохранено в файл: " + fileName + ".docx");
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка! Не удалось сохранить файл. " + ex.Message);
                return false;
            }
        }
    }

} 
