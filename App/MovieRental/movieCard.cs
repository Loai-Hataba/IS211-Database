using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MovieRental
{
    public class movieCard : UserControl
    {
        private PictureBox pictureBoxPoster = null!;
        private Label labelTitle = null!;
        private Label labelGenre = null!;
        private Label labelPrice = null!;
        private Label labelYear = null!;
        private readonly movieItem movie; // Add movie field to store the data

        public movieCard(movieItem movie)
        {
            this.movie = movie; // Store the movie data
            InitializeComponent();
            LoadMovieData(movie);
        }

        private void InitializeComponent()
        {
            // Initialize controls
            pictureBoxPoster = new PictureBox();
            labelTitle = new Label();
            labelGenre = new Label();
            labelPrice = new Label();
            labelYear = new Label();

            // Main Control Setup
            this.Size = new Size(280, 400);
            this.BackColor = Color.FromArgb(34, 49, 63);
            this.Margin = new Padding(15);
            this.Padding = new Padding(10);
            this.Cursor = Cursors.Hand;

            // Add shadow effect
            this.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };

            // pictureBoxPoster
            pictureBoxPoster.Size = new Size(250, 250);
            pictureBoxPoster.Location = new Point(15, 15);
            pictureBoxPoster.BackColor = Color.FromArgb(44, 62, 80);
            pictureBoxPoster.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPoster.BorderStyle = BorderStyle.None;

            // labelTitle
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.Location = new Point(15, 275);
            labelTitle.Size = new Size(250, 25);
            labelTitle.ForeColor = Color.White;
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;

            // labelGenre
            labelGenre.Font = new Font("Segoe UI", 10F);
            labelGenre.Location = new Point(15, 305);
            labelGenre.Size = new Size(250, 20);
            labelGenre.ForeColor = Color.FromArgb(189, 195, 199);

            // labelPrice
            labelPrice.Font = new Font("Segoe UI", 10F);
            labelPrice.Location = new Point(15, 330);
            labelPrice.Size = new Size(250, 20);
            labelPrice.ForeColor = Color.FromArgb(189, 195, 199);

            // labelYear
            labelYear.Font = new Font("Segoe UI", 10F);
            labelYear.Location = new Point(15, 355);
            labelYear.Size = new Size(250, 20);
            labelYear.ForeColor = Color.FromArgb(189, 195, 199);

            // Add hover effect
            EventHandler mouseEnter = (s, e) => {
                this.BackColor = Color.FromArgb(41, 58, 74);
            };
            EventHandler mouseLeave = (s, e) => {
                this.BackColor = Color.FromArgb(34, 49, 63);
            };

            // Add click handler
            EventHandler cardClick = (s, e) =>
            {
                string imageFileName = movie.imagePath;
                string assetsPath = Path.Combine(Application.StartupPath, "..", "..", "..", "..", "Assets", imageFileName);
                assetsPath = Path.GetFullPath(assetsPath);

                var movieDetails = new MovieDetails(
                    movieId: movie.id,
                    title: movie.title,
                    description: "Get description from database",
                    price: Convert.ToDecimal(movie.rentalCharge),
                    isAvailable: true,
                    imageUrl: assetsPath
                );
                movieDetails.Show();
            };

            // Add event handlers
            this.Click += cardClick;
            this.MouseEnter += mouseEnter;
            this.MouseLeave += mouseLeave;

            // Make all child controls clickable
            foreach (Control control in new Control[] { pictureBoxPoster, labelTitle, labelGenre, labelPrice, labelYear })
            {
                control.Click += cardClick;
                control.Cursor = Cursors.Hand;
                control.MouseEnter += mouseEnter;
                control.MouseLeave += mouseLeave;
            }

            // Add controls to the UserControl
            Controls.AddRange(new Control[] {
                pictureBoxPoster,
                labelTitle,
                labelGenre,
                labelPrice,
                labelYear
            });
        }

        private void LoadMovieData(movieItem movie)
        {
            labelTitle.Text = movie.title;
            labelGenre.Text = $"Genre: {movie.genreId}";            labelPrice.Text = $"Price: ${movie.rentalCharge:0.00}";
            labelYear.Text = $"Released: {movie.releaseDate:yyyy}";

            try
            {
                string imageFileName = movie.imagePath;
                string assetsPath = Path.Combine(Application.StartupPath, "..", "..", "..", "..", "Assets", imageFileName);
                assetsPath = Path.GetFullPath(assetsPath);

                if (File.Exists(assetsPath))
                    pictureBoxPoster.Image = Image.FromFile(assetsPath);
                else
                    pictureBoxPoster.Image = SystemIcons.Information.ToBitmap();
            }
            catch
            {
                pictureBoxPoster.Image = SystemIcons.Information.ToBitmap();
            }
        }
    }
}
