namespace CSharpLibraryApp
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userLogInLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userLogInTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.signUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userLogInLabel
            // 
            this.userLogInLabel.AutoSize = true;
            this.userLogInLabel.Location = new System.Drawing.Point(104, 52);
            this.userLogInLabel.Name = "userLogInLabel";
            this.userLogInLabel.Size = new System.Drawing.Size(42, 13);
            this.userLogInLabel.TabIndex = 0;
            this.userLogInLabel.Text = "Login : ";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(84, 86);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(62, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password : ";
            // 
            // userLogInTextBox
            // 
            this.userLogInTextBox.Location = new System.Drawing.Point(165, 52);
            this.userLogInTextBox.Name = "userLogInTextBox";
            this.userLogInTextBox.Size = new System.Drawing.Size(100, 20);
            this.userLogInTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(165, 83);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(189, 125);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "&Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(87, 124);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(75, 23);
            this.signUpButton.TabIndex = 4;
            this.signUpButton.Text = "&Sign Up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 169);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userLogInTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userLogInLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 208);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 208);
            this.Name = "LoginForm";
            this.Text = "C# - Library Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userLogInLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox userLogInTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button signUpButton;
    }
}