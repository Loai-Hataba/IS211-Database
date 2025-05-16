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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // First validate the user inputs : 
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text) )
            {
                MessageBox.Show("Please fill in all fields.", "Log In Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 2- Check if the email is valid or not 
            if (!textBoxEmail.Text.Contains( "@" )  || !textBoxEmail.Text.Contains("."))
            {
                MessageBox.Show("Invalid email structure it must contains '@' ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 3- check if the email in the database or not 
            // TODO : if the email isn't in the database ask him to redirict to the sign up page or to login with another account 
            

            //4- validate the password :
            // first check if it less than 6 char 
            if (textBoxPassword.Text.Length< 6)
            {
                MessageBox.Show("Invalid password it must be more than 6 characters  ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO: Add your login logic here
            MessageBox.Show("Logged In successfully  ", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var profilePage = new UserProfile();
            profilePage.Show();
            this.Close(); // Close the login form after opening the profile page
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
    }
}
