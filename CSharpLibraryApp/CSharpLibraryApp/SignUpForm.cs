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
using Valdiation;

namespace CSharpLibraryApp
{
    public partial class SignUpForm : Form
    {
        ErrorProvider errorProvider;
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            int result;
            Account account = new Account() { Email = emailTextBox.Text, userLogIn = userLoginTextBox.Text, Password = passwordTextBox.Text };
                result = Validator.CreateAccount(account);
                if (result == 1)
                {
                    MainForm mainForm = new MainForm() { UserLogin = userLoginTextBox.Text };
                    mainForm.Show();
                    this.Close();
                }
                else
                {
                    errorProvider.SetIconAlignment(signUpButton, ErrorIconAlignment.MiddleLeft);
                    errorProvider.SetError(signUpButton, Validator.GetMessage);
                    errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                }
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            errorProvider = new ErrorProvider();
        }
    }
}