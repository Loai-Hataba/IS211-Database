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
        private Label descriptionText;
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
            this.BackColor = Color.FromArgb(44, 62, 80);
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Movie Details";
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- Navigation Bar ---
            navigationBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(34, 49, 63),
                Padding = new Padding(10)
            };

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
            backButton.MouseEnter += (s, e) => backButton.ForeColor = Color.FromArgb(52, 152, 219);
            backButton.MouseLeave += (s, e) => backButton.ForeColor = Color.WhiteSmoke;

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
                foreach (Form form in Application.OpenForms)
                {
                    if (form is ApplicationForm) form.Show();
                    else if (form != this) form.Close();
                }
                this.Close();
            };
            homeButton.MouseEnter += (s, e) => homeButton.ForeColor = Color.FromArgb(52, 152, 219);
            homeButton.MouseLeave += (s, e) => homeButton.ForeColor = Color.WhiteSmoke;

            navigationBar.Controls.AddRange(new Control[] { backButton, homeButton });

            // Add spacer panel between navigation and content
            Panel spacerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.FromArgb(44, 62, 80) // Match form background color
            };

            // --- Main Panel ---
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(52, 73, 94),
                Padding = new Padding(40)
            };

            // Movie Image
            movieImage = new PictureBox
            {
                Size = new Size(400, 600),
                Location = new Point(40, 20),
                BackColor = Color.FromArgb(34, 49, 63),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.None
            };

            // Title
            titleLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 32F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                Location = new Point(480, 20),
                MaximumSize = new Size(800, 0)
            };

            // Description Label
            descriptionLabel = new Label
            {
                Text = "Description",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(480, 100),
                Size = new Size(200, 30)
            };

            // Description Text
            descriptionText = new Label
            {
                Location = new Point(480, 140),
                Size = new Size(600, 300),
                Font = new Font("Segoe UI", 12F),
                BackColor = Color.FromArgb(34, 49, 63),
                ForeColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.None,
            };

            // Price Label
            priceLabel = new Label
            {
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113),
                Location = new Point(480, 460),
                Size = new Size(200, 40)
            };

            // Availability Label
            availabilityLabel = new Label
            {
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(480, 510),
                Size = new Size(200, 30)
            };

            // Add to Cart Button
            addToCartButton = new Button
            {
                Text = "Add to Cart",
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Size = new Size(200, 50),
                Location = new Point(480, 560),
                Cursor = Cursors.Hand
            };
            addToCartButton.FlatAppearance.BorderSize = 0;
            addToCartButton.Click += AddToCartButton_Click;

            // Add hover effects
            addToCartButton.MouseEnter += (s, e) => addToCartButton.BackColor = Color.FromArgb(41, 128, 185);
            addToCartButton.MouseLeave += (s, e) => addToCartButton.BackColor = Color.FromArgb(52, 152, 219);

            // Add controls to mainPanel
            mainPanel.Controls.AddRange(new Control[] {
                movieImage,
                titleLabel,
                descriptionLabel,
                descriptionText,
                priceLabel,
                availabilityLabel,
                addToCartButton
            });

            // Final Form Setup
            Controls.Add(mainPanel);
            Controls.Add(spacerPanel);    // Add spacer between nav and main panel
            Controls.Add(navigationBar);

            // Handle resize
            this.Resize += (s, e) => {
                // Adjust controls if needed on resize
            };
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