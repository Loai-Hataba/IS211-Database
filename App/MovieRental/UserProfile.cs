using System;
using System.Windows.Forms;
using System.Drawing;

namespace MovieRental
{
    public partial class UserProfile : Form
    {
        private Panel mainPanel;
        private FlowLayoutPanel moviesFlowPanel;
        private Button editProfileButton;
        private Label titleLabel;

        public UserProfile()
        {
            InitializeComponent();
            LoadRentedMovies();
        }

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            moviesFlowPanel = new FlowLayoutPanel();
            editProfileButton = new Button();
            titleLabel = new Label();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(240, 240, 240);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(200, 100);
            mainPanel.TabIndex = 0;
            // 
            // moviesFlowPanel
            // 
            moviesFlowPanel.AutoScroll = true;
            moviesFlowPanel.BackColor = Color.White;
            moviesFlowPanel.Location = new Point(20, 80);
            moviesFlowPanel.Name = "moviesFlowPanel";
            moviesFlowPanel.Padding = new Padding(10);
            moviesFlowPanel.Size = new Size(750, 450);
            moviesFlowPanel.TabIndex = 2;
            // 
            // editProfileButton
            // 
            editProfileButton.BackColor = Color.FromArgb(0, 120, 212);
            editProfileButton.Cursor = Cursors.Hand;
            editProfileButton.FlatAppearance.BorderSize = 0;
            editProfileButton.FlatStyle = FlatStyle.Flat;
            editProfileButton.Font = new Font("Segoe UI", 10F);
            editProfileButton.ForeColor = Color.White;
            editProfileButton.Location = new Point(650, 20);
            editProfileButton.Name = "editProfileButton";
            editProfileButton.Size = new Size(120, 40);
            editProfileButton.TabIndex = 1;
            editProfileButton.Text = "Edit Profile";
            editProfileButton.UseVisualStyleBackColor = false;
            editProfileButton.Click += EditProfileButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(51, 51, 51);
            titleLabel.Location = new Point(20, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(177, 45);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "My Profile";
            // 
            // UserProfile
            // 
            BackColor = Color.White;
            ClientSize = new Size(800, 600);
            Controls.Add(titleLabel);
            Controls.Add(editProfileButton);
            Controls.Add(moviesFlowPanel);
            Name = "UserProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Profile";
            ResumeLayout(false);
            PerformLayout();

        }

        private Panel CreateMoviePanel(string title, DateTime rentalDate, DateTime returnDate, string status, string imageUrl = null)
        {
            Panel moviePanel = new Panel
            {
                Size = new Size(230, 320),
                BackColor = Color.White,
                Margin = new Padding(10),
                Cursor = Cursors.Hand // Add hand cursor to indicate clickability
            };

            // Add shadow effect
            moviePanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, moviePanel.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };

            // Movie Image
            PictureBox movieImage = new PictureBox
            {
                Size = new Size(200, 200),
                Location = new Point(15, 15),
                BackColor = Color.FromArgb(240, 240, 240),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Load image if available, otherwise show placeholder
            try
            {
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    movieImage.Image = Image.FromFile(imageUrl);
                }
            }
            catch
            {
                // Handle image loading error
            }

            // Movie Title
            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(15, 225),
                Size = new Size(200, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Rental Date
            Label rentalDateLabel = new Label
            {
                Text = $"Rented: {rentalDate:MM/dd/yyyy}",
                Font = new Font("Segoe UI", 9F),
                Location = new Point(15, 250),
                Size = new Size(200, 15),
                ForeColor = Color.Gray
            };

            // Return Date
            Label returnDateLabel = new Label
            {
                Text = $"Return: {returnDate:MM/dd/yyyy}",
                Font = new Font("Segoe UI", 9F),
                Location = new Point(15, 270),
                Size = new Size(200, 15),
                ForeColor = Color.Gray
            };

            // Status
            Label statusLabel = new Label
            {
                Text = status,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(15, 290),
                Size = new Size(200, 15),
                ForeColor = status.ToLower() == "active" ? Color.Green : Color.Gray
            };

            // Add hover effect
            EventHandler mouseEnter = (s, e) => moviePanel.BackColor = Color.FromArgb(245, 245, 245);
            EventHandler mouseLeave = (s, e) => moviePanel.BackColor = Color.White;

            // Add click handler for the panel
            EventHandler panelClick = (s, e) =>
            {
                var movieDetails = new MovieDetails(
                    movieId: 1, // Replace with actual movie ID
                    title: title,
                    description: "Get description from database", // Replace with actual description
                    price: 4.99m, // Replace with actual price
                    isAvailable: true, // Replace with actual availability
                    imageUrl: imageUrl
                );
                movieDetails.Show();
            };

            // Add event handlers to panel and all child controls
            moviePanel.Click += panelClick;
            moviePanel.MouseEnter += mouseEnter;
            moviePanel.MouseLeave += mouseLeave;

            // Make all child controls clickable too
            foreach (Control control in new Control[] { movieImage, titleLabel, rentalDateLabel, returnDateLabel, statusLabel })
            {
                control.Click += panelClick;
                control.Cursor = Cursors.Hand;
                control.MouseEnter += mouseEnter;
                control.MouseLeave += mouseLeave;
            }

            moviePanel.Controls.AddRange(new Control[] {
                movieImage,
                titleLabel,
                rentalDateLabel,
                returnDateLabel,
                statusLabel
            });

            return moviePanel;
        }

        private void LoadRentedMovies()
        {
            // Clear existing panels
            moviesFlowPanel.Controls.Clear();

            // Sample data - replace with actual database data
            var movies = new[]
            {
                new {
                    Title = "The Matrix",
                    RentalDate = DateTime.Now.AddDays(-5),
                    ReturnDate = DateTime.Now.AddDays(2),
                    Status = "Active",
                    ImageUrl = "path/to/matrix.jpg",
                    Id = 1,
                    Description = "A computer programmer discovers that reality as he knows it is a simulation created by machines, and joins a rebellion to break free.",
                    Price = 4.99m,
                    IsAvailable = true
                },
                new {
                    Title = "Inception",
                    RentalDate = DateTime.Now.AddDays(-10),
                    ReturnDate = DateTime.Now.AddDays(-3),
                    Status = "Returned",
                    ImageUrl = "path/to/inception.jpg",
                    Id = 2,
                    Description = "A thief who steals corporate secrets through dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    Price = 5.99m,
                    IsAvailable = true
                }
            };

            foreach (var movie in movies)
            {
                var moviePanel = CreateMoviePanel(
                    movie.Title,
                    movie.RentalDate,
                    movie.ReturnDate,
                    movie.Status,
                    movie.ImageUrl
                );
                moviesFlowPanel.Controls.Add(moviePanel);
            }
        }

        private void EditProfileButton_Click(object sender, EventArgs e)
        {
            var editForm = new EditProfileForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh profile data after edit
                // TODO: Implement refresh logic
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
            // Form properties
            Text = "Edit Profile";
            Size = new Size(400, 500);
            StartPosition = FormStartPosition.CenterScreen;  // Center the form
            FormBorderStyle = FormBorderStyle.FixedDialog;  // Fixed size
            MaximizeBox = false;                           // Disable maximize button
            MinimizeBox = true;                            // Allow minimize
            BackColor = Color.White;
            Padding = new Padding(20);

            // Create controls
            Label labelName = new Label
            {
                Text = "Name:",
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 20),
                Size = new Size(100, 23)
            };

            textBoxName = new TextBox
            {
                Location = new Point(20, 45),
                Size = new Size(340, 23),
                Font = new Font("Segoe UI", 9F)
            };

            Label labelEmail = new Label
            {
                Text = "Email:",
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 80),
                Size = new Size(100, 23)
            };

            textBoxEmail = new TextBox
            {
                Location = new Point(20, 105),
                Size = new Size(340, 23),
                Font = new Font("Segoe UI", 9F)
            };

            Label labelPhone = new Label
            {
                Text = "Phone:",
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 140),
                Size = new Size(100, 23)
            };

            textBoxPhone = new TextBox
            {
                Location = new Point(20, 165),
                Size = new Size(340, 23),
                Font = new Font("Segoe UI", 9F)
            };

            Label labelResidence = new Label
            {
                Text = "Residence Address:",
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 200),
                Size = new Size(200, 23)
            };

            textBoxResidenceAddress = new TextBox
            {
                Location = new Point(20, 225),
                Size = new Size(340, 23),
                Font = new Font("Segoe UI", 9F)
            };

            Label labelBusiness = new Label
            {
                Text = "Business Address:",
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 260),
                Size = new Size(200, 23)
            };

            textBoxBusinessAddress = new TextBox
            {
                Location = new Point(20, 285),
                Size = new Size(340, 23),
                Font = new Font("Segoe UI", 9F)
            };

            saveButton = new Button
            {
                Text = "Save",
                BackColor = Color.FromArgb(0, 120, 212),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(160, 400),
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 9F),
                Cursor = Cursors.Hand
            };
            saveButton.FlatAppearance.BorderSize = 0;

            cancelButton = new Button
            {
                Text = "Cancel",
                BackColor = Color.FromArgb(240, 240, 240),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(270, 400),
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 9F),
                Cursor = Cursors.Hand
            };

            // Wire up events
            saveButton.Click += SaveButton_Click;
 

            // Add controls to form
            Controls.AddRange(new Control[] { 
                labelName, textBoxName,
                labelEmail, textBoxEmail,
                labelPhone, textBoxPhone,
                labelResidence, textBoxResidenceAddress,
                labelBusiness, textBoxBusinessAddress,
                saveButton, cancelButton
            });
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
                // TODO : update the data in the database 
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