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
        private List<movieItem> allMovies = new List<movieItem>();
        private List<genreItem> genreList = new List<genreItem>();

        public ucMovies()
        {
            InitializeComponent();
            SetupTitle();
            SetupFilterPanel();
            LoadGenres();
            LoadYears();
            searchBox.TextChanged += (s, e) => ApplyFilters();
            applyFiltersButton.Click += (s, e) => ApplyFilters();
            resetButton.Click += (s, e) => ResetFilters();
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

        private void SetupFilterPanel()
        {
            // Add hover effects to buttons
            applyFiltersButton.MouseEnter += (s, e) => applyFiltersButton.BackColor = Color.FromArgb(41, 128, 185);
            applyFiltersButton.MouseLeave += (s, e) => applyFiltersButton.BackColor = Color.FromArgb(52, 152, 219);
            resetButton.MouseEnter += (s, e) => resetButton.BackColor = Color.FromArgb(192, 57, 43);
            resetButton.MouseLeave += (s, e) => resetButton.BackColor = Color.FromArgb(231, 76, 60);

            // Add price validation
            priceMinBox.KeyPress += ValidateNumericInput;
            priceMaxBox.KeyPress += ValidateNumericInput;
        }

        private void ValidateNumericInput(object? sender, KeyPressEventArgs e)
        {
            // Allow digits, decimal point, and control characters (backspace, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Only allow one decimal point
            TextBox? textBox = sender as TextBox;
            if (e.KeyChar == '.' && textBox?.Text.Contains('.') == true)
            {
                e.Handled = true;
                return;
            }

            // Validate decimal places
            if (textBox?.Text.Contains('.') == true && char.IsDigit(e.KeyChar))
            {
                int decimalIndex = textBox.Text.IndexOf('.');
                if (textBox.Text.Length - decimalIndex > 2) // Allow only 2 decimal places
                {
                    e.Handled = true;
                }
            }
        }

        private void LoadGenres()
        {
            genreList = DatabaseManager.FetchData("SELECT * FROM Genre", r => new genreItem { id = r.GetInt32(0), title = r.GetString(1) });
            genreComboBox.Items.Clear();
            genreComboBox.Items.Add("All");
            foreach (var genre in genreList)
                genreComboBox.Items.Add(genre.title);
            genreComboBox.SelectedIndex = 0;
        }

        private void LoadYears()
        {
            var years = DatabaseManager.FetchData("SELECT DISTINCT YEAR(ReleaseDate) FROM [Movie Tape] ORDER BY YEAR(ReleaseDate) DESC", r => r.GetInt32(0));
            yearComboBox.Items.Clear();
            yearComboBox.Items.Add("All");
            foreach (var y in years)
                yearComboBox.Items.Add(y.ToString());
            yearComboBox.SelectedIndex = 0;
        }

        public List<movieItem> loadMovies(string query)
        {
            allMovies = DatabaseManager.FetchData(query, reader => new movieItem
            {
                id = reader.GetInt32(0),
                title = reader.GetString(1),
                description = reader.GetString(2),
                actorId = reader.GetInt32(3),
                genreId = reader.GetInt32(4),
                rentalCharge = reader.GetDouble(5),
                releaseDate = reader.GetDateTime(6),
                imagePath = reader.GetString(7),
                isAvailable = reader.GetBoolean(8)
            });
            ApplyFilters();
            return allMovies;
        }

        private void ApplyFilters()
        {
            string search = searchBox.Text.Trim().ToLower();
            string selectedGenre = genreComboBox.SelectedItem != null ? genreComboBox.SelectedItem.ToString()! : "All";
            string minPriceText = priceMinBox.Text.Trim();
            string maxPriceText = priceMaxBox.Text.Trim();
            string selectedYear = yearComboBox.SelectedItem != null ? yearComboBox.SelectedItem.ToString()! : "All";

            double minPrice = 0, maxPrice = double.MaxValue;
            double.TryParse(minPriceText, out minPrice);
            double.TryParse(maxPriceText, out maxPrice);

            var filtered = allMovies.Where(m =>
                (string.IsNullOrEmpty(search) || m.title.ToLower().Contains(search)) &&
                (selectedGenre == "All" || genreList.FirstOrDefault(g => g.id == m.genreId)?.title == selectedGenre) &&
                (string.IsNullOrEmpty(minPriceText) || m.rentalCharge >= minPrice) &&
                (string.IsNullOrEmpty(maxPriceText) || m.rentalCharge <= maxPrice) &&
                (selectedYear == "All" || m.releaseDate.Year.ToString() == selectedYear)
            ).ToList();

            flpMovies.Controls.Clear();
            foreach (var movie in filtered)
            {
                movieCard card = new movieCard(movie);
                flpMovies.Controls.Add(card);
            }
        }

        private void ResetFilters()
        {
            searchBox.Text = "";
            genreComboBox.SelectedIndex = 0;
            priceMinBox.Text = "";
            priceMaxBox.Text = "";
            yearComboBox.SelectedIndex = 0;
            ApplyFilters();
        }
    }
}
