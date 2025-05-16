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
        }

        private void InitializeComponent()
        {
            // Main Panel
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            // Movie Image
            movieImage = new PictureBox
            {
                Size = new Size(300, 450),
                Location = new Point(20, 20),
                BackColor = Color.FromArgb(240, 240, 240),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.None
            };

            // Title
            titleLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51),
                Location = new Point(340, 20),
                MaximumSize = new Size(400, 0)
            };

            // Description Label
            descriptionLabel = new Label
            {
                Text = "Description",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51),
                Location = new Point(340, 80),
                Size = new Size(100, 25)
            };

            // Description Text
            descriptionText = new RichTextBox
            {
                Location = new Point(340, 110),
                Size = new Size(400, 200),
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                ReadOnly = true
            };

            // Price Label
            priceLabel = new Label
            {
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 212),
                Location = new Point(340, 330),
                Size = new Size(200, 30)
            };

            // Availability Label
            availabilityLabel = new Label
            {
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(340, 370),
                Size = new Size(200, 25)
            };

            // Add to Cart Button
            addToCartButton = new Button
            {
                Text = "Add to Cart",
                BackColor = Color.FromArgb(0, 120, 212),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Size = new Size(200, 45),
                Location = new Point(340, 410),
                Cursor = Cursors.Hand
            };
            addToCartButton.FlatAppearance.BorderSize = 0;
            addToCartButton.Click += AddToCartButton_Click;


            // Form properties
            Text = "Movie Details";
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;

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

            // Add panel to form
            Controls.Add(mainPanel);
        }

        private void LoadMovieDetails()
        {
            titleLabel.Text = MovieTitle;
            descriptionText.Text = Description;
            priceLabel.Text = $"${Price:F2}";

            // Set availability status with color coding
            availabilityLabel.Text = IsAvailable ? "Available for Rent" : "Currently Unavailable";
            availabilityLabel.ForeColor = IsAvailable ? Color.Green : Color.Red;

            // Load movie image
            try
            {
                if (!string.IsNullOrEmpty(ImageUrl))
                {
                    movieImage.Image = Image.FromFile(ImageUrl);
                }
                else
                {
                    // Set placeholder image
                    // movieImage.Image = Properties.Resources.movie_placeholder;
                }
            }
            catch
            {
                // Handle image loading error
                // movieImage.Image = Properties.Resources.movie_placeholder;
            }

            // Update add to cart button based on availability
            addToCartButton.Enabled = IsAvailable;
            if (!IsAvailable)
            {
                addToCartButton.BackColor = Color.Gray;
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