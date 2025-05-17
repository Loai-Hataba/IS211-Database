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
                Location = new Point(20, 20)
            };

            Controls.Add(titleLabel);
            flpMovies.Location = new Point(0, titleLabel.Bottom + 20);
            flpMovies.Height = Height - titleLabel.Bottom - 40;
        }

        public List<movieItem> loadMovies()
        {
            string query = "SELECT * FROM [Movie Tape]";

            List<movieItem> movieList = DatabaseManager.FetchData(query, reader => new movieItem
            {
                id = reader.GetInt32(0),
                title = reader.GetString(1),
                actorId = reader.GetInt32(2),
                genreId = reader.GetInt32(3),
                rentalCharge = reader.GetDouble(4),
                releaseDate = reader.GetDateTime(5),
                imagePath = reader.GetString(6)

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
