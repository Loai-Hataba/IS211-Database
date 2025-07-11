﻿using System;
using System.Windows.Forms;
using System.Drawing;
using MovieRental.User;

namespace MovieRental.AuthForms
{
    public class LogInForm : Form
    {
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Button buttonCancel;
        private Label headerLabel;

        public LogInForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Initialize controls
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            buttonCancel = new Button();
            headerLabel = new Label();

            SuspendLayout();

            // Form settings
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(44, 62, 80);
            this.ClientSize = new Size(480, 280);
            this.Font = new Font("Segoe UI", 11F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Log In";

            // Header Label
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            headerLabel.ForeColor = Color.WhiteSmoke;
            headerLabel.Location = new Point(120, 15);
            headerLabel.Text = "Log In";

            // Email Label
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 12F);
            labelEmail.ForeColor = Color.White;
            labelEmail.Location = new Point(60, 80);
            labelEmail.Text = "Email:";

            // Email TextBox
            textBoxEmail.Font = new Font("Segoe UI", 12F);
            textBoxEmail.Location = new Point(180, 77);
            textBoxEmail.MaxLength = 50;
            textBoxEmail.Size = new Size(200, 29);

            // Password Label
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 12F);
            labelPassword.ForeColor = Color.White;
            labelPassword.Location = new Point(60, 140);
            labelPassword.Text = "Password:";

            // Password TextBox
            textBoxPassword.Font = new Font("Segoe UI", 12F);
            textBoxPassword.Location = new Point(180, 137);
            textBoxPassword.MaxLength = 30;
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(200, 29);

            // Login Button
            buttonLogin.BackColor = Color.FromArgb(52, 152, 219);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(180, 200);
            buttonLogin.Size = new Size(90, 40);
            buttonLogin.Text = "Login";
            buttonLogin.Click += buttonLogin_Click;

            // Cancel Button
            buttonCancel.BackColor = Color.FromArgb(231, 76, 60);
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Location = new Point(290, 200);
            buttonCancel.Size = new Size(90, 40);
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;

            // Add controls to form
            Controls.AddRange(new Control[] {
                headerLabel,
                labelEmail,
                textBoxEmail,
                labelPassword,
                textBoxPassword,
                buttonLogin,
                buttonCancel
            });

            ResumeLayout(false);
            PerformLayout();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Validate user inputs
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Log In Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check email validity
            if (!textBoxEmail.Text.Contains("@") || !textBoxEmail.Text.Contains("."))
            {
                MessageBox.Show("Invalid email structure it must contains '@'", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate password length
            if (textBoxPassword.Text.Length < 6)
            {
                MessageBox.Show("Invalid password it must be more than 6 characters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            appUser currentUser = new appUser();
            currentUser.email = textBoxEmail.Text;
            currentUser.password = textBoxPassword.Text;

            List<appUser> adminList = DatabaseManager.FetchData($"SELECT * FROM Admin WHERE Email = '{currentUser.email}' AND Password = '{currentUser.password}'", reader => new appUser
            {
                UID = reader.GetInt32(0),
                name = reader.GetString(1),
                email = reader.GetString(2),
                phoneNum = reader.GetString(3),
                password = reader.GetString(4),
                isAdmin = true
            });
            appUser adminCheck = adminList.FirstOrDefault();
            if (adminCheck != null)
            {
                var applicationForm = new ApplicationForm(adminCheck.UID ,true);
                applicationForm.Show();
                this.Close();
                return;
            }

            List<appUser> customerList = DatabaseManager.FetchData($"SELECT * FROM Customer WHERE Email = '{currentUser.email}' AND Password = '{currentUser.password}'", reader => new appUser
            {
                UID = reader.GetInt32(0),
                name = reader.GetString(1),
                email = reader.GetString(2),
                phoneNum = reader.GetString(3),
                address = reader.GetString(4),
                businessAdress = reader.GetString(5),
                password = reader.GetString(6),

            });
            
            appUser customerCheck = customerList.FirstOrDefault();
            
            if (customerCheck != null)
            {
                var applicationForm = new ApplicationForm(customerCheck.UID);
                applicationForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Email or Password are wrong", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Clear();
                textBoxPassword.Clear();
                return;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
