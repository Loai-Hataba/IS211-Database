using System;
using System.Windows.Forms;

namespace MovieRental
{
    public partial class UserProfile : Form
    {
        private Panel mainPanel;
        private DataGridView rentedMoviesGrid;
        private Button editProfileButton;
        private Label titleLabel;

        public UserProfile()
        {
            InitializeComponent();
            InitializeUI();
            LoadRentedMovies();
        }

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            rentedMoviesGrid = new DataGridView();
            editProfileButton = new Button();
            titleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)rentedMoviesGrid).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(200, 100);
            mainPanel.TabIndex = 0;
            // 
            // rentedMoviesGrid
            // 
            rentedMoviesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            rentedMoviesGrid.Location = new Point(20, 80);
            rentedMoviesGrid.Name = "rentedMoviesGrid";
            rentedMoviesGrid.ReadOnly = true;
            rentedMoviesGrid.Size = new Size(750, 400);
            rentedMoviesGrid.TabIndex = 2;
            // 
            // editProfileButton
            // 
            editProfileButton.Location = new Point(650, 20);
            editProfileButton.Name = "editProfileButton";
            editProfileButton.Size = new Size(120, 35);
            editProfileButton.TabIndex = 1;
            editProfileButton.Text = "Edit Profile";
            editProfileButton.Click += EditProfileButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.Location = new Point(20, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(120, 30);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "My Profile";
            // 
            // UserProfile
            // 
            ClientSize = new Size(784, 561);
            Controls.Add(titleLabel);
            Controls.Add(editProfileButton);
            Controls.Add(rentedMoviesGrid);
            Name = "UserProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Profile";
            ((System.ComponentModel.ISupportInitialize)rentedMoviesGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeUI()
        {
            // Initialize grid columns
            rentedMoviesGrid.Columns.Add("MovieTitle", "Movie Title");
            rentedMoviesGrid.Columns.Add("RentalDate", "Rental Date");
            rentedMoviesGrid.Columns.Add("ReturnDate", "Return Date");
            rentedMoviesGrid.Columns.Add("Status", "Status");
        }

        private void LoadRentedMovies()
        {
            // TODO: Load actual rented movies data from your database
            // This is sample data
            rentedMoviesGrid.Rows.Add("The Matrix", DateTime.Now.AddDays(-5), DateTime.Now.AddDays(2), "Active");
            rentedMoviesGrid.Rows.Add("Inception", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-3), "Returned");
        }

        private void EditProfileButton_Click(object sender, EventArgs e)
        {
            var editForm = new EditProfileForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh profile data after edit
            }
        }
    }

    public class EditProfileForm : Form
    {
        private TextBox textBoxName;
        private TextBox textBoxEmail;
        private TextBox textBoxPhone;
        private TextBox textBoxResidenceAddress;
        private TextBox textBoxBusinessAddress;
        private Button saveButton;
        private Button cancelButton;

        public EditProfileForm()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void InitializeComponent()
        {
            Text = "Edit Profile";
            Size = new Size(400, 500);
            // Create and position controls
            Label labelName = new Label();
            textBoxName = new TextBox();
            Label labelEmail = new Label();
            textBoxEmail = new TextBox();
            Label labelPhone = new Label();
            textBoxPhone = new TextBox();
            Label labelResidence = new Label();
            textBoxResidenceAddress = new TextBox();
            Label labelBusiness = new Label();
            textBoxBusinessAddress = new TextBox();
            saveButton = new Button();
            saveButton.Click += SaveButton_Click;
            cancelButton = new Button();
            // Add controls to form
            Controls.AddRange(new Control[] { labelName, textBoxName, labelEmail, textBoxEmail, labelPhone, textBoxPhone, labelResidence, textBoxResidenceAddress, labelBusiness, textBoxBusinessAddress, saveButton, cancelButton });
        }

        private void LoadUserData()
        {
            // TODO: Load actual user data from your database
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // TODO: Validate and save user data to database
            if (ValidateInputs())
            {
                // Save changes
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhone.Text) ||
                string.IsNullOrWhiteSpace(textBoxResidenceAddress.Text) ||
                string.IsNullOrWhiteSpace(textBoxBusinessAddress.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!textBoxEmail.Text.Contains("@") || !textBoxEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}