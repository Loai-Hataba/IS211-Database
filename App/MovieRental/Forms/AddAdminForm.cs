using System;
using System.Windows.Forms;
using System.Drawing;

namespace MovieRental
{
    public class AddAdminForm : Form
    {
        private TextBox nameTextBox;
        private TextBox emailTextBox;
        private TextBox phoneTextBox;
        private TextBox passwordTextBox;
        private Button saveButton;
        private Button cancelButton;

        public string AdminName => nameTextBox.Text;
        public string AdminEmail => emailTextBox.Text;
        public string AdminPhone => phoneTextBox.Text;
        public string AdminPassword => passwordTextBox.Text;

        public AddAdminForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Add New Admin";
            Size = new Size(400, 450);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.FromArgb(44, 62, 80);

            var labelName = new Label
            {
                Text = "Name:",
                ForeColor = Color.White,
                Location = new Point(20, 20),
                Font = new Font("Segoe UI", 11F)
            };

            nameTextBox = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.White
            };

            var labelEmail = new Label
            {
                Text = "Email:",
                ForeColor = Color.White,
                Location = new Point(20, 90),
                Font = new Font("Segoe UI", 11F)
            };

            emailTextBox = new TextBox
            {
                Location = new Point(20, 120),
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.White
            };

            var labelPhone = new Label
            {
                Text = "Phone:",
                ForeColor = Color.White,
                Location = new Point(20, 160),
                Font = new Font("Segoe UI", 11F)
            };

            phoneTextBox = new TextBox
            {
                Location = new Point(20, 190),
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.White,
                MaxLength = 11
            };

            var labelPassword = new Label
            {
                Text = "Password:",
                ForeColor = Color.White,
                Location = new Point(20, 230),
                Font = new Font("Segoe UI", 11F)
            };

            passwordTextBox = new TextBox
            {
                Location = new Point(20, 260),
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.White,
                UseSystemPasswordChar = true
            };

            saveButton = new Button
            {
                Text = "Save",
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Location = new Point(20, 320),
                Size = new Size(160, 40),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F)
            };
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button
            {
                Text = "Cancel",
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                Location = new Point(200, 320),
                Size = new Size(160, 40),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F)
            };
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;

            Controls.AddRange(new Control[] {
                labelName, nameTextBox,
                labelEmail, emailTextBox,
                labelPhone, phoneTextBox,
                labelPassword, passwordTextBox,
                saveButton, cancelButton
            });
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(phoneTextBox.Text) ||
                string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!emailTextBox.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (phoneTextBox.Text.Length != 11)
            {
                MessageBox.Show("Phone number must be 11 digits.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}