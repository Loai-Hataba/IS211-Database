using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRental
{
    public partial class SignUpForm : Form
    {
       
        public SignUpForm()
        {
            InitializeComponent();
           
        }

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
            if (!textBoxEmail.Text.Contains("@"))
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

            // If all validations pass
            MessageBox.Show("Sign up successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Helper method to check password strength
        private bool IsStrongPassword(string password)
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
