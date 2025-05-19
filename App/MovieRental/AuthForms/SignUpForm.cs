using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MovieRental.AuthForms
{
    public class SignUpForm : Form
    {
        private Label labelName;
        private TextBox textBoxName;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelResidenceAddress;
        private TextBox textBoxResidenceAddress;
        private Label labelBusinessAddress;
        private TextBox textBoxBusinessAddress;
        private Label labelPhoneNumber;
        private TextBox textBoxPhoneNumber;
        private Label labelCreditCard;
        private TextBox textBoxCreditCard;
        private Button signup_btn;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Label labelConfirmPassword;
        private TextBox textBoxConfirmPassword;
        private Label headerLabel;

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Initialize controls
            labelName = new Label();
            textBoxName = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelResidenceAddress = new Label();
            textBoxResidenceAddress = new TextBox();
            labelBusinessAddress = new Label();
            textBoxBusinessAddress = new TextBox();
            labelPhoneNumber = new Label();
            textBoxPhoneNumber = new TextBox();
            labelCreditCard = new Label();
            textBoxCreditCard = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            labelConfirmPassword = new Label();
            textBoxConfirmPassword = new TextBox();
            signup_btn = new Button();
            headerLabel = new Label();

            SuspendLayout();

            // Form settings
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(44, 62, 80);
            this.ClientSize = new Size(600, 580);
            this.Font = new Font("Segoe UI", 11F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sign Up";

            // Header Label
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            headerLabel.ForeColor = Color.WhiteSmoke;
            headerLabel.Location = new Point(120, 15);
            headerLabel.Size = new Size(300, 60);
            headerLabel.Text = "Sign Up";

            // Name Fields
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 12F);
            labelName.ForeColor = Color.White;
            labelName.Location = new Point(50, 90);
            labelName.Text = "Name:";

            textBoxName.Font = new Font("Segoe UI", 12F);
            textBoxName.Location = new Point(250, 87);
            textBoxName.MaxLength = 20;
            textBoxName.Size = new Size(250, 39);

            // Email Fields
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 12F);
            labelEmail.ForeColor = Color.White;
            labelEmail.Location = new Point(50, 140);
            labelEmail.Text = "Email:";

            textBoxEmail.Font = new Font("Segoe UI", 12F);
            textBoxEmail.Location = new Point(250, 137);
            textBoxEmail.MaxLength = 30;
            textBoxEmail.Size = new Size(250, 39);

            // Password Fields
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 12F);
            labelPassword.ForeColor = Color.White;
            labelPassword.Location = new Point(50, 190);
            labelPassword.Text = "Password:";

            textBoxPassword.Font = new Font("Segoe UI", 12F);
            textBoxPassword.Location = new Point(250, 187);
            textBoxPassword.MaxLength = 18;
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(250, 39);

            // Confirm Password Fields
            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Font = new Font("Segoe UI", 12F);
            labelConfirmPassword.ForeColor = Color.White;
            labelConfirmPassword.Location = new Point(50, 240);
            labelConfirmPassword.Text = "Confirm Password:";

            textBoxConfirmPassword.Font = new Font("Segoe UI", 12F);
            textBoxConfirmPassword.Location = new Point(250, 237);
            textBoxConfirmPassword.MaxLength = 18;
            textBoxConfirmPassword.PasswordChar = '*';
            textBoxConfirmPassword.Size = new Size(250, 39);

            // Address Fields
            labelResidenceAddress.AutoSize = true;
            labelResidenceAddress.Font = new Font("Segoe UI", 12F);
            labelResidenceAddress.ForeColor = Color.White;
            labelResidenceAddress.Location = new Point(50, 290);
            labelResidenceAddress.Text = "Residence Address:";

            textBoxResidenceAddress.Font = new Font("Segoe UI", 12F);
            textBoxResidenceAddress.Location = new Point(250, 287);
            textBoxResidenceAddress.MaxLength = 70;
            textBoxResidenceAddress.Size = new Size(250, 39);

            labelBusinessAddress.AutoSize = true;
            labelBusinessAddress.Font = new Font("Segoe UI", 12F);
            labelBusinessAddress.ForeColor = Color.White;
            labelBusinessAddress.Location = new Point(50, 340);
            labelBusinessAddress.Text = "Business Address:";

            textBoxBusinessAddress.Font = new Font("Segoe UI", 12F);
            textBoxBusinessAddress.Location = new Point(250, 337);
            textBoxBusinessAddress.MaxLength = 70;
            textBoxBusinessAddress.Size = new Size(250, 39);

            // Phone Number Fields
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.Font = new Font("Segoe UI", 12F);
            labelPhoneNumber.ForeColor = Color.White;
            labelPhoneNumber.Location = new Point(50, 390);
            labelPhoneNumber.Text = "Phone Number:";

            textBoxPhoneNumber.Font = new Font("Segoe UI", 12F);
            textBoxPhoneNumber.Location = new Point(250, 387);
            textBoxPhoneNumber.MaxLength = 11;
            textBoxPhoneNumber.Size = new Size(250, 39);

            // Credit Card Fields
            labelCreditCard.AutoSize = true;
            labelCreditCard.Font = new Font("Segoe UI", 12F);
            labelCreditCard.ForeColor = Color.White;
            labelCreditCard.Location = new Point(50, 440);
            labelCreditCard.Text = "Credit Card:";

            textBoxCreditCard.Font = new Font("Segoe UI", 12F);
            textBoxCreditCard.Location = new Point(250, 437);
            textBoxCreditCard.MaxLength = 16;
            textBoxCreditCard.Size = new Size(250, 39);

            // Sign Up Button
            signup_btn.BackColor = Color.FromArgb(52, 152, 219);
            signup_btn.FlatStyle = FlatStyle.Flat;
            signup_btn.FlatAppearance.BorderSize = 0;
            signup_btn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            signup_btn.ForeColor = Color.White;
            signup_btn.Location = new Point(250, 500);
            signup_btn.Size = new Size(180, 50);
            signup_btn.Text = "Sign Up";
            signup_btn.Click += signup_btn_Click;

            // Add all controls to form
            Controls.AddRange(new Control[] {
                headerLabel,
                labelName, textBoxName,
                labelEmail, textBoxEmail,
                labelPassword, textBoxPassword,
                labelConfirmPassword, textBoxConfirmPassword,
                labelResidenceAddress, textBoxResidenceAddress,
                labelBusinessAddress, textBoxBusinessAddress,
                labelPhoneNumber, textBoxPhoneNumber,
                labelCreditCard, textBoxCreditCard,
                signup_btn
            });

            ResumeLayout(false);
            PerformLayout();
        }


        public static string lastFour = "2005";
        public static string creditCardTemp = $"MasterCard No.: **** **** {lastFour}";
        private void signup_btn_Click(object sender, EventArgs e)
        {
            // Check for empty fields
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxConfirmPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxResidenceAddress.Text) ||
                string.IsNullOrWhiteSpace(textBoxBusinessAddress.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(textBoxCreditCard.Text))
            {
                MessageBox.Show("Please fill in all fields.", "SignUp Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if passwords match
            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate email format
            if (!textBoxEmail.Text.Contains("@") || !textBoxEmail.Text.Contains("."))
            {
                MessageBox.Show("Email must contain '@'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validate the phone number
            if (textBoxPhoneNumber.Text.Length != 11 || !textBoxPhoneNumber.Text.All(char.IsDigit))
            {
                MessageBox.Show("Phone Number must be 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxPhoneNumber.Text[0] != '0' || textBoxPhoneNumber.Text[1] != '1')
            {
                MessageBox.Show("Phone Number must start with 01.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxCreditCard.Text.Length != 16 || !textBoxCreditCard.Text.All(char.IsDigit))
            {
                MessageBox.Show("Credit Card must contain exactly 16 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Check password strength
            string password = textBoxPassword.Text;
            if (!IsStrongPassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain uppercase, lowercase, digit, and special character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name = textBoxName.Text;
            string email = textBoxEmail.Text;
            string phoneNum = textBoxPhoneNumber.Text;
            string address = textBoxResidenceAddress.Text;
            string businessAdress = textBoxBusinessAddress.Text;
            string passwordData = textBoxPassword.Text;
            string creditCard = textBoxCreditCard.Text;

            // insert the user into the database TODO : 
            string insertQuery = @"INSERT INTO Customer ([Name], Email, PhoneNum, [Address], BusinessAddress, [password]) Values (@Name, @Email, @PhoneNum, @Address, @BusinessAddress, @password)";
            var parameters = new Dictionary<string, object>
            {
                {"@Name", name},
                {"@Email", email},
                {"@PhoneNum", phoneNum},
                {"@Address", address},
                {"@BusinessAddress", businessAdress},
                {"@password", password},
            };

            DatabaseManager.InsertData(insertQuery, parameters);

            lastFour = creditCard.Substring(creditCard.Length - 4);
            Console.WriteLine($"Credit four: {lastFour}");

            



            // If all validations pass
            MessageBox.Show("Sign up successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var loginForm = new LogInForm();
            loginForm.Show();
            this.Close();
        }
        // Helper method to check password strength
        private static bool IsStrongPassword(string password)
        {
            if (password.Length < 8)
                return false;
            if (!password.Any(char.IsUpper))
                return false;
            if (!password.Any(char.IsLower))
                return false;
            if (!password.Any(char.IsDigit))
                return false;
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                return false;
            return true;
        }

    }
}
