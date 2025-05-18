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
        private Label? titleLabel;
        private TextBox? searchBox;
        private ComboBox? genreFilter;
        private TextBox? minPrice;
        private TextBox? maxPrice;
        private ComboBox? yearFilter;
        private List<movieItem>? allMovies;

        public ucMovies()
        {
            InitializeComponent();
            SetupTitle();
            SetupFilterHandlers();
            allMovies = new List<movieItem>();
        }

        private void SetupFilterHandlers()
        {
            if (filterPanel.Controls[0] is FlowLayoutPanel filterControls)
            {
                // Get the controls from the designer
                searchBox = filterControls.Controls.OfType<TextBox>().First();
                genreFilter = filterControls.Controls.OfType<ComboBox>().First();
                var pricePanel = filterControls.Controls.OfType<FlowLayoutPanel>().First();
                minPrice = pricePanel.Controls.OfType<TextBox>().First();
                maxPrice = pricePanel.Controls.OfType<TextBox>().Last();
                yearFilter = filterControls.Controls.OfType<ComboBox>().Last();

                // Add event handlers
                searchBox.TextChanged += (s, e) => FilterMovies();
                genreFilter.SelectedIndexChanged += (s, e) => FilterMovies();
                minPrice.TextChanged += (s, e) => FilterMovies();
                maxPrice.TextChanged += (s, e) => FilterMovies();
                yearFilter.SelectedIndexChanged += (s, e) => FilterMovies();

                // Get the buttons
                var applyFilter = filterControls.Controls.OfType<Button>().First();
                var resetFilter = filterControls.Controls.OfType<Button>().Last();

                resetFilter.Click += (s, e) => {
                    if (searchBox != null) searchBox.Clear();
                    if (genreFilter != null) genreFilter.SelectedIndex = -1;
                    if (minPrice != null) minPrice.Clear();
                    if (maxPrice != null) maxPrice.Clear();
                    if (yearFilter != null) yearFilter.SelectedIndex = -1;
                    RefreshMovies();
                };
            }
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
            allMovies = DatabaseManager.FetchData(query, reader => new movieItem
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

            PopulateFilters();
            RefreshMovies();
            return allMovies;
        }

        private void PopulateFilters()
        {
            if (genreFilter == null || yearFilter == null || allMovies == null) return;

            // Populate genre filter
            var genres = DatabaseManager.FetchData("SELECT * FROM Genre", reader => new genreItem
            {
                id = reader.GetInt32(0),
                title = reader.GetString(1)
            });
            genreFilter.DataSource = genres;
            genreFilter.DisplayMember = "title";
            genreFilter.ValueMember = "id";
            genreFilter.SelectedIndex = -1;

            // Populate year filter with unique years from movies
            var years = allMovies.Select(m => m.releaseDate.Year).Distinct().OrderByDescending(y => y).ToList();
            yearFilter.DataSource = years;
            yearFilter.SelectedIndex = -1;
        }

        private void FilterMovies()
        {
            if (allMovies == null) return;
            var filteredMovies = allMovies.ToList();

            // Apply search filter
            if (searchBox != null && !string.IsNullOrWhiteSpace(searchBox.Text))
            {
                string searchTerm = searchBox.Text.ToLower();
                // First try to find movies where title starts with the search term
                var titleMatches = filteredMovies.Where(m => m.title.ToLower().StartsWith(searchTerm));
                if (titleMatches.Any())
                {
                    filteredMovies = titleMatches.ToList();
                }
                else
                {
                    // If no title matches found, look for the term anywhere in title or description
                    filteredMovies = filteredMovies.Where(m => 
                        m.title.ToLower().Contains(searchTerm)).ToList();
                }
            }

            // Apply genre filter
            if (genreFilter?.SelectedItem is genreItem selectedGenre)
            {
                filteredMovies = filteredMovies.Where(m => m.genreId == selectedGenre.id).ToList();
            }

            // Apply price filter
            if (minPrice != null && decimal.TryParse(minPrice.Text, out decimal min))
            {
                filteredMovies = filteredMovies.Where(m => m.rentalCharge >= (double)min).ToList();
            }

            if (maxPrice != null && decimal.TryParse(maxPrice.Text, out decimal max))
            {
                filteredMovies = filteredMovies.Where(m => m.rentalCharge <= (double)max).ToList();
            }

            // Apply year filter
            if (yearFilter?.SelectedItem is int year)
            {
                filteredMovies = filteredMovies.Where(m => m.releaseDate.Year == year).ToList();
            }

            RefreshMovies(filteredMovies);
        }

        private void RefreshMovies(List<movieItem>? movies = null)
        {
            flpMovies.Controls.Clear();
            foreach (var movie in movies ?? allMovies ?? Enumerable.Empty<movieItem>())
            {
                movieCard card = new movieCard(movie);
                flpMovies.Controls.Add(card);
            }
        }
    }
}
