using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorTests
{
    public partial class ErrorReportForm : Form
    {
        public ErrorReportForm(List<string> errors)
        {
            InitializeComponent();
            if (errors.Count == 0)
            {
                txtErrors.Text = "Ошибок не обнаружено";
                return;
            }

            string report = "ОТЧЕТ ОБ ОШИБКАХ ЗАГРУЗКИ\n\n";
            report += $"Всего ошибок: {errors.Count}\n\n";

            for (int i = 0; i < errors.Count; i++)
            {
                report += $"{i + 1}. {errors[i]}\n";
            }

            txtErrors.Text = report;
        }

    }
}

