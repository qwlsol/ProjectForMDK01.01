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
    public partial class LoginForm : Form
    {
        private DatabaseManager _db;
        private int _attempts = 0;
        private DateTime _blockedUntil = DateTime.MinValue;
        public LoginForm()
        {
            InitializeComponent();

        }
    }   
}
