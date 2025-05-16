using System;
using System.Windows.Forms;
using System.Drawing;

namespace MovieRental
{
    public partial class MovieDetails : Form
    {
        private PictureBox movieImage;
        private Label titleLabel;
        private Label descriptionLabel;
        private RichTextBox descriptionText;
        private Label priceLabel;
        private Label availabilityLabel;
        private Button addToCartButton;
        private Panel mainPanel;

        // Properties to store movie details
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; }

        // Add new private fields
        private Panel navigationBar;
        private Button backButton;
        private Button homeButton;

        public MovieDetails(int movieId, string title, string description, decimal price, bool isAvailable, string imageUrl)
        {
            MovieId = movieId;
            MovieTitle = title;
            Description = description;
            Price = price;
            IsAvailable = isAvailable;
            ImageUrl = imageUrl;

            InitializeComponent();
            LoadMovieDetails();
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeComponent()
        {
            // Form properties
            this.BackColor = Color.FromArgb(44, 62, 80); // Dark blue-gray background
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Movie Details";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Navigation Bar - Add bottom margin using a spacer panel
            navigationBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(34, 49, 63),
                Padding = new Padding(10)
            };

            // Back Button
            backButton = new Button
            {
                Text = "← Back",
                BackColor = Color.Transparent,
                ForeColor = Color.WhiteSmoke,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                Size = new Size(100, 40),
                Location = new Point(10, 10),
                Cursor = Cursors.Hand
            };
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Click += (s, e) => this.Close();

            // Home Button
            homeButton = new Button
            {
                Text = "🏠 Home",
                BackColor = Color.Transparent,
                ForeColor = Color.WhiteSmoke,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                Size = new Size(100, 40),
                Location = new Point(120, 10),
                Cursor = Cursors.Hand
            };
            homeButton.FlatAppearance.BorderSize = 0;
            homeButton.Click += (s, e) => {
                // Close all forms except ApplicationForm
                foreach (Form form in Application.OpenForms)
                {
                    if (form is ApplicationForm)
                    {
                        form.Show();
                    }
                    else if (form != this)
                    {
                        form.Close();
                    }
                }
                this.Close();
            };

            // Add hover effects
            backButton.MouseEnter += (s, e) => {
                backButton.ForeColor = Color.FromArgb(52, 152, 219);
            };
            backButton.MouseLeave += (s, e) => {
                backButton.ForeColor = Color.WhiteSmoke;
            };

            homeButton.MouseEnter += (s, e) => {
                homeButton.ForeColor = Color.FromArgb(52, 152, 219);
            };
            homeButton.MouseLeave += (s, e) => {
                homeButton.ForeColor = Color.WhiteSmoke;
            };

            // Add buttons to navigation bar
            navigationBar.Controls.Add(backButton);
            navigationBar.Controls.Add(homeButton);

            // Add bottom border to navigation bar
            Panel borderPanel = new Panel
            {
                Height = 1,
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(64, 82, 100)
            };
            navigationBar.Controls.Add(borderPanel);

           // Spacer Panel - reduced height for cleaner spacing
Panel spacerPanel = new Panel
{
    Dock = DockStyle.Top,
    Height = 30, // Adjusted height for cleaner spacing
    BackColor = Color.FromArgb(44, 62, 80) // Match form background
};

// Main Panel - Update padding and add top margin for spacing
mainPanel = new Panel
{
    Dock = DockStyle.Fill,
    BackColor = Color.FromArgb(52, 73, 94),
    Padding = new Padding(60, 20, 60, 40),
    Margin = new Padding(0, 10, 0, 0) // Add spacing below spacerPanel
};

            // Movie Image - Update location
            movieImage = new PictureBox
            {
                Size = new Size(400, 600),
                Location = new Point(60, 0), // Increase left spacing
                BackColor = Color.FromArgb(34, 49, 63),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.None
            };

            // Title
            titleLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 32F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219), // Blue accent color
                Location = new Point(520, 0), // 60 + 400 + 60
                MaximumSize = new Size(800, 0)
            };

            // Description Label
            descriptionLabel = new Label
            {
                Text = "Description",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(520, 80),
                Size = new Size(200, 30)
            };

            // Description Text
            descriptionText = new RichTextBox
            {
                Location = new Point(520, 120),
                Size = new Size(600, 300),
                Font = new Font("Segoe UI", 12F),
                BackColor = Color.FromArgb(34, 49, 63),
                ForeColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.None,
                ReadOnly = true
            };

            // Price Label
            priceLabel = new Label
            {
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113), // Green for price
                Location = new Point(520, 440),
                Size = new Size(200, 40)
            };

            // Availability Label
            availabilityLabel = new Label
            {
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(520, 490),
                Size = new Size(200, 30),
                ForeColor = Color.WhiteSmoke
            };

            // Add to Cart Button
            addToCartButton = new Button
            {
                Text = "Add to Cart",
                BackColor = Color.FromArgb(13, 110, 253), // Bootstrap-like blue
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Size = new Size(200, 50),
                Location = new Point(520, 540),
                Cursor = Cursors.Hand
            };
            addToCartButton.FlatAppearance.BorderSize = 0;

            // Add hover effect to button
            addToCartButton.MouseEnter += (s, e) => {
                addToCartButton.BackColor = Color.FromArgb(11, 94, 215);
            };
            addToCartButton.MouseLeave += (s, e) => {
                addToCartButton.BackColor = Color.FromArgb(13, 110, 253);
            };

            // Add controls to panel
            mainPanel.Controls.AddRange(new Control[] {
                movieImage,
                titleLabel,
                descriptionLabel,
                descriptionText,
                priceLabel,
                availabilityLabel,
                addToCartButton
            });

            // Add panels to form in correct order
            Controls.Add(mainPanel);
            Controls.Add(spacerPanel);
            Controls.Add(navigationBar);
        }

        private void LoadMovieDetails()
        {
            titleLabel.Text = MovieTitle;
            descriptionText.Text = Description;
            priceLabel.Text = $"${Price:F2}";

            // Set availability status with color coding
            availabilityLabel.Text = IsAvailable ? "Available for Rent" : "Currently Unavailable";
            availabilityLabel.ForeColor = IsAvailable 
                ? Color.FromArgb(46, 204, 113)  // Green for available
                : Color.FromArgb(231, 76, 60);  // Red for unavailable

            try
            {
                if (!string.IsNullOrEmpty(ImageUrl))
                {
                    movieImage.Image = Image.FromFile(ImageUrl);
                }
            }
            catch
            {
                // Handle image loading error
            }

            // Update add to cart button based on availability
            addToCartButton.Enabled = IsAvailable;
            if (!IsAvailable)
            {
                addToCartButton.BackColor = Color.FromArgb(149, 165, 166); // Lighter gray for disabled
            }
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement add to cart functionality
                // Add the movie to the user's cart in the database
                MessageBox.Show("Movie added to cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding movie to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}