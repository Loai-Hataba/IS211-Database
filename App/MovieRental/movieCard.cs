using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MovieRental
{
    public class movieCard : UserControl
    {
        private PictureBox pictureBoxPoster;
        private Label labelTitle;
        private Label labelGenre;
        private Label labelPrice;
        private Label labelYear;

        public movieCard(movieItem movie)
        {
            InitializeComponent();

            labelTitle.Text = movie.title;
            labelGenre.Text = $"Genre: {movie.genreId}";
            labelPrice.Text = $"Price: ${movie.rentalCharge:F2}";
            labelYear.Text = $"ReleaseYear: {movie.releaseDate}";

            string imageFileName = movie.imagePath; // e.g., "theMatrix.png"
            MessageBox.Show(Application.StartupPath);
            string assetsPath = Path.Combine(Application.StartupPath, "..", "..", "..", "..", "Assets", imageFileName);
            assetsPath = Path.GetFullPath(assetsPath);

            if (File.Exists(assetsPath))
                pictureBoxPoster.Image = Image.FromFile(assetsPath);
            else
                pictureBoxPoster.Image = SystemIcons.Information.ToBitmap(); // placeholder
        }

        private void InitializeComponent()
        {
            pictureBoxPoster = new PictureBox();
            labelTitle = new Label();
            labelGenre = new Label();
            labelPrice = new Label();
            labelYear = new Label();

            // pictureBoxPoster
            pictureBoxPoster.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxPoster.Size = new Size(120, 160);
            pictureBoxPoster.Location = new Point(10, 10);

            // labelTitle
            labelTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTitle.Location = new Point(10, 180);
            labelTitle.AutoSize = true;

            // labelGenre
            labelGenre.Font = new Font("Segoe UI", 9F);
            labelGenre.Location = new Point(10, 200);
            labelGenre.AutoSize = true;

            // labelPrice
            labelPrice.Font = new Font("Segoe UI", 9F);
            labelPrice.Location = new Point(10, 220);
            labelPrice.AutoSize = true;

            // labelYear
            labelYear.Font = new Font("Segoe UI", 9F);
            labelYear.Location = new Point(10, 240);
            labelYear.AutoSize = true;

            // Add controls to the UserControl
            Controls.Add(pictureBoxPoster);
            Controls.Add(labelTitle);
            Controls.Add(labelGenre);
            Controls.Add(labelPrice);
            Controls.Add(labelYear);

            // Setup this control
            this.Size = new Size(150, 280);
            this.BackColor = Color.White;
            this.Margin = new Padding(10);
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }


}
