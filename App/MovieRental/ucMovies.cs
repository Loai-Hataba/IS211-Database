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
    public partial class ucMovies : UserControl
    {
        private Label titleLabel;

        public ucMovies()
        {
            InitializeComponent();
            SetupTitle();
        }

        private void SetupTitle()
        {
            titleLabel = new Label
            {
                Text = "Available Movies",
                Font = new Font("Segoe UI", 32F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                AutoSize = true,
                Location = new Point(40, 30)  // Increased spacing from top
            };

            Controls.Add(titleLabel);
            flpMovies.Location = new Point(0, titleLabel.Bottom + 30);  // Increased spacing after title
            flpMovies.Height = Height - titleLabel.Bottom - 60;  // Adjusted height calculation
        }
        public List<movieItem> loadMovies(string query)
        {
            List<movieItem> movieList = DatabaseManager.FetchData(query, reader => new movieItem
            {
                id = reader.GetInt32(0),          // TapeId
                title = reader.GetString(1),      // Title
                description = reader.GetString(2),
                actorId = reader.GetInt32(3),     // ActorID
                genreId = reader.GetInt32(4),     // GenreID
                rentalCharge = reader.GetDouble(5), // RentalCharge
                releaseDate = reader.GetDateTime(6), // ReleaseDate
                imagePath = reader.GetString(7), // ImagePath
                isAvailable = reader.GetBoolean(8) // IsAvailable
            });

            flpMovies.Controls.Clear();

            foreach (var movie in movieList)
            {
                movieCard card = new movieCard(movie);
                flpMovies.Controls.Add(card);
            }
            return movieList;
        }
    }
}
