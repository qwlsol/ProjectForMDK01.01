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
            
                _db = new DatabaseManager();
            

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (DateTime.Now < _blockedUntil)
            {
                MessageBox.Show($"Доступ заблокирован до {_blockedUntil.ToShortTimeString()}");
                return;
            }

            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            if (_db.ValidateUser(login, password, out UserRole role, out int userId))
            {
                _attempts = 0;
                this.Hide();

                User user = new User(userId, login, "", role);
                user.TestResults = _db.GetUserResults(userId);

                if (role == UserRole.Teacher)
                    new TeacherForm(_db, user).ShowDialog();
                else
                    new StudentForm(_db, user).ShowDialog();

                this.Show();
                txtPassword.Text = "";
            }
            else
            {
                _attempts++;
                if (_attempts >= 3)
                {
                    _blockedUntil = DateTime.Now.AddMinutes(5);
                    MessageBox.Show("Превышено количество попыток. Доступ заблокирован на 5 минут.");
                    txtLogin.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    MessageBox.Show($"Неверный логин или пароль. Осталось: {3 - _attempts}");
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}      