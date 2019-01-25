using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Repository;

namespace CSharpLibraryApp
{
    public partial class LoginForm : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm;
            Account account = new Account { UserLogin = userLogInTextBox.Text, Password = passwordTextBox.Text };
            if (BookRepository.LogIn(account) == 1)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
                if (account.UserLogin != "admin")
                {
                    mainForm = new MainForm() { UserLogin = userLogInTextBox.Text };
                }
                else
                {
                    mainForm = new MainForm() { UserLogin = userLogInTextBox.Text, Admin = true};
                }
                mainForm.ShowDialog();
                if (mainForm.DialogResult == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
            else
            {
                errorProvider.SetIconAlignment(loginButton, ErrorIconAlignment.MiddleRight);
                errorProvider.SetError(loginButton, "Login and Password pair could not be found");
                errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
            this.Hide();
        }
    }
}
