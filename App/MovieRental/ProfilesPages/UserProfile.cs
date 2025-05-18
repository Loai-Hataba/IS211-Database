using System;
using System.Windows.Forms;
using System.Drawing;

namespace MovieRental.ProfilePages
{
    public partial class UserProfile : Form
    {
        private Panel mainPanel;
        private FlowLayoutPanel moviesFlowPanel;
        private Button editProfileButton;
        private Label titleLabel;

        // Add new private fields for navigation
        private Panel navigationBar;
        private Button backButton;
        private Button homeButton;

        public UserProfile()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            LoadRentedMovies();
        }

        private void InitializeComponent()
        {
            // Initialize all controls
            mainPanel = new Panel();
            moviesFlowPanel = new FlowLayoutPanel();
            editProfileButton = new Button();
            titleLabel = new Label();
            navigationBar = new Panel();
            backButton = new Button();
            homeButton = new Button();

            SuspendLayout();

            // --- Navigation Bar ---
            navigationBar.Dock = DockStyle.Top;
            navigationBar.Height = 60;
            navigationBar.BackColor = Color.FromArgb(34, 49, 63);
            navigationBar.Padding = new Padding(10);

            backButton.Text = "← Back";
            backButton.BackColor = Color.Transparent;
            backButton.ForeColor = Color.WhiteSmoke;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Segoe UI", 11F);
            backButton.Size = new Size(100, 40);
            backButton.Location = new Point(10, 10);
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Cursor = Cursors.Hand;
            backButton.Click += (s, e) => this.Close();
            backButton.MouseEnter += (s, e) => backButton.ForeColor = Color.FromArgb(52, 152, 219);
            backButton.MouseLeave += (s, e) => backButton.ForeColor = Color.WhiteSmoke;
            backButton.Click += backButton_Click;

            homeButton.Text = "🏠 Home";
            homeButton.BackColor = Color.Transparent;
            homeButton.ForeColor = Color.WhiteSmoke;
            homeButton.FlatStyle = FlatStyle.Flat;
            homeButton.Font = new Font("Segoe UI", 11F);
            homeButton.Size = new Size(100, 40);
            homeButton.Location = new Point(120, 10);
            homeButton.FlatAppearance.BorderSize = 0;
            homeButton.Cursor = Cursors.Hand;
            homeButton.Click += (s, e) =>
            {
                // Navigate to home page
                var homeForm = new ApplicationForm();
                homeForm.Show();
                this.Close();
            };
            homeButton.MouseEnter += (s, e) => homeButton.ForeColor = Color.FromArgb(52, 152, 219);
            homeButton.MouseLeave += (s, e) => homeButton.ForeColor = Color.WhiteSmoke;

            navigationBar.Controls.Add(backButton);
            navigationBar.Controls.Add(homeButton);

            // --- Main Panel ---
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.FromArgb(52, 73, 94);
            mainPanel.Padding = new Padding(40, 20, 40, 40);

            // --- Title Label ---
            titleLabel.Text = "My Profile";
            titleLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(52, 152, 219);
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(0, 20);

            // --- Edit Profile Button ---
            editProfileButton.Text = "✎ Edit Profile";
            editProfileButton.BackColor = Color.Transparent;
            editProfileButton.ForeColor = Color.WhiteSmoke;
            editProfileButton.FlatStyle = FlatStyle.Flat;
            editProfileButton.Font = new Font("Segoe UI", 11F);
            editProfileButton.Size = new Size(120, 40);
            editProfileButton.Location = new Point(navigationBar.Width - 140, 10);
            editProfileButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editProfileButton.FlatAppearance.BorderSize = 0;
            editProfileButton.Cursor = Cursors.Hand;
            editProfileButton.Click += EditProfileButton_Click;

            // Update hover effects for Edit Profile button
            editProfileButton.MouseEnter += (s, e) =>
            {
                editProfileButton.ForeColor = Color.FromArgb(52, 152, 219);
            };
            editProfileButton.MouseLeave += (s, e) =>
            {
                editProfileButton.ForeColor = Color.WhiteSmoke;
            };

            // Add Edit Profile button to navigation bar instead of main panel
            navigationBar.Controls.Add(editProfileButton);

            // --- Movies Flow Panel ---
            moviesFlowPanel.AutoScroll = true;
            moviesFlowPanel.BackColor = Color.Transparent;
            moviesFlowPanel.Dock = DockStyle.Bottom;
            moviesFlowPanel.Size = new Size(ClientSize.Width - 80, ClientSize.Height - 200);
            moviesFlowPanel.Padding = new Padding(20);
            moviesFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            moviesFlowPanel.Location = new Point(0, 120);

            // Add controls to mainPanel
            mainPanel.Controls.Add(titleLabel);
            mainPanel.Controls.Add(moviesFlowPanel);

            // --- Final Form Setup ---
            Controls.Add(mainPanel);
            Controls.Add(navigationBar);

            BackColor = Color.FromArgb(44, 62, 80);
            WindowState = FormWindowState.Maximized;
            Text = "User Profile";
            ResumeLayout(false);
            PerformLayout();

            // Reposition editProfileButton on resize
            this.Resize += (s, e) =>
            {
                moviesFlowPanel.Size = new Size(mainPanel.Width - 40, mainPanel.Height - 160);
            };
        }


        private Panel CreateMoviePanel(string title, DateTime rentalDate, DateTime returnDate, string status, string imageUrl = null)
        {
            Panel moviePanel = new Panel
            {
                Size = new Size(280, 400),
                BackColor = Color.FromArgb(34, 49, 63), // Darker panel background
                Margin = new Padding(15),
                Padding = new Padding(10),
                Cursor = Cursors.Hand
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
                Size = new Size(250, 250),
                Location = new Point(15, 15),
                BackColor = Color.FromArgb(44, 62, 80),
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
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(15, 275),
                Size = new Size(250, 25),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Rental Date
            Label rentalDateLabel = new Label
            {
                Text = $"Rented: {rentalDate:MM/dd/yyyy}",
                Font = new Font("Segoe UI", 10F),
                Location = new Point(15, 305),
                Size = new Size(250, 20),
                ForeColor = Color.FromArgb(189, 195, 199)
            };

            // Return Date
            Label returnDateLabel = new Label
            {
                Text = $"Return: {returnDate:MM/dd/yyyy}",
                Font = new Font("Segoe UI", 10F),
                Location = new Point(15, 330),
                Size = new Size(250, 20),
                ForeColor = Color.FromArgb(189, 195, 199)
            };

            // Status
            Label statusLabel = new Label
            {
                Text = status,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(15, 355),
                Size = new Size(250, 20),
                ForeColor = status.ToLower() == "active" ? Color.FromArgb(46, 204, 113) : Color.FromArgb(189, 195, 199)
            };

            // Add hover effect
            EventHandler mouseEnter = (s, e) =>
            {
                moviePanel.BackColor = Color.FromArgb(41, 58, 74);
            };
            EventHandler mouseLeave = (s, e) =>
            {
                moviePanel.BackColor = Color.FromArgb(34, 49, 63);
            };

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
              
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = true;
            BackColor = Color.FromArgb(44, 62, 80); // Dark blue background like other forms

            // Create controls with updated styling
            Label labelName = new Label
            {
                Text = "Name:",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(20, 20),
                Size = new Size(100, 23)
            };

            textBoxName = new TextBox
            {
                Location = new Point(20, 45),
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label labelEmail = new Label
            {
                Text = "Email:",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(20, 80),
                Size = new Size(100, 23)
            };

            textBoxEmail = new TextBox
            {
                Location = new Point(20, 105),
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label labelPhone = new Label
            {
                Text = "Phone:",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(20, 140),
                Size = new Size(100, 23)
            };

            textBoxPhone = new TextBox
            {
                Location = new Point(20, 165),
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label labelResidence = new Label
            {
                Text = "Residence Address:",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(20, 200),
                Size = new Size(200, 23)
            };

            textBoxResidenceAddress = new TextBox
            {
                Location = new Point(20, 225),
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label labelBusiness = new Label
            {
                Text = "Business Address:",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(20, 260),
                Size = new Size(200, 23)
            };

            textBoxBusinessAddress = new TextBox
            {
                Location = new Point(20, 285),
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };

            saveButton = new Button
            {
                Text = "Save",
                BackColor = Color.FromArgb(46, 204, 113), // Green color
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(20, 400),
                Size = new Size(160, 40),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            saveButton.FlatAppearance.BorderSize = 0;

            cancelButton = new Button
            {
                Text = "Cancel",
                BackColor = Color.FromArgb(231, 76, 60), // Red color
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(200, 400),
                Size = new Size(160, 40),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            cancelButton.FlatAppearance.BorderSize = 0;

            // Add hover effects
            saveButton.MouseEnter += (s, e) => saveButton.BackColor = Color.FromArgb(39, 174, 96);
            saveButton.MouseLeave += (s, e) => saveButton.BackColor = Color.FromArgb(46, 204, 113);

            cancelButton.MouseEnter += (s, e) => cancelButton.BackColor = Color.FromArgb(192, 57, 43);
            cancelButton.MouseLeave += (s, e) => cancelButton.BackColor = Color.FromArgb(231, 76, 60);

            // Wire up events
            saveButton.Click += SaveButton_Click;
            cancelButton.Click += CancelButton_Click;

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
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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