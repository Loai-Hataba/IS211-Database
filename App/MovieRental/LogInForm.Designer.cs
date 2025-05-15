namespace MovieRental
{
    partial class LogInForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonCancel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise.</param>
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
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(60, 40);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(74, 19);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Username:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(180, 37);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(200, 26);
            textBoxUsername.TabIndex = 1;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(60, 90);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(70, 19);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Password:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(180, 87);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(200, 26);
            textBoxPassword.TabIndex = 3;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(180, 140);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(90, 35);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(290, 140);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(90, 35);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 220);
            Controls.Add(labelUsername);
            Controls.Add(textBoxUsername);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonLogin);
            Controls.Add(buttonCancel);
            Name = "LogInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log In";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}