using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MovieRental
{
    public partial class Genres : UserControl
    {
        private Panel mainPanel;
        private Panel headerPanel;
        private DataGridView genresGrid;
        private Label titleLabel;
        private TextBox searchBox;
        private Button addGenreButton;
        private Button refreshButton;

        public Genres()
        {
            InitializeComponent();
            loadGenres();
        }

        private void InitializeComponent()
        {
            // Initialize controls
            mainPanel = new Panel();
            headerPanel = new Panel();
            genresGrid = new DataGridView();
            titleLabel = new Label();
            searchBox = new TextBox();
            addGenreButton = new Button();
            refreshButton = new Button();

            // UserControl settings
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(44, 62, 80);

            // Header Panel
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 100;
            headerPanel.BackColor = Color.FromArgb(34, 49, 63);
            headerPanel.Padding = new Padding(20);

            // Title Label
            titleLabel.Text = "Movie Genres";
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.WhiteSmoke;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(20, 20);

            // Search Box
            searchBox.PlaceholderText = "🔍 Search genres...";
            searchBox.Font = new Font("Segoe UI", 11F);
            searchBox.Size = new Size(200, 30);
            searchBox.Location = new Point(300, 30);
            searchBox.BackColor = Color.FromArgb(52, 73, 94);
            searchBox.ForeColor = Color.WhiteSmoke;
            searchBox.TextChanged += SearchBox_TextChanged;

            // Add Genre Button
            addGenreButton.Text = "➕ Add Genre";
            addGenreButton.BackColor = Color.FromArgb(46, 204, 113);
            addGenreButton.ForeColor = Color.White;
            addGenreButton.FlatStyle = FlatStyle.Flat;
            addGenreButton.Font = new Font("Segoe UI", 10F);
            addGenreButton.Size = new Size(120, 35);
            addGenreButton.Location = new Point(520, 28);


            // Refresh Button
            refreshButton.Text = "🔄 Refresh";
            refreshButton.BackColor = Color.FromArgb(52, 152, 219);
            refreshButton.ForeColor = Color.White;
            refreshButton.FlatStyle = FlatStyle.Flat;
            refreshButton.Font = new Font("Segoe UI", 10F);
            refreshButton.Size = new Size(100, 35);
            refreshButton.Location = new Point(650, 28);
            refreshButton.Click += (s, e) => loadGenres();

            // Main Panel
            mainPanel.Dock = DockStyle.Top;
            mainPanel.BackColor = Color.FromArgb(44, 62, 80);
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(1000, 600);
            this.Size = new Size(1900, 940);

            // Configure Grid
            SetupDataGrid();

            // Add controls
            headerPanel.Controls.AddRange(new Control[] {
                titleLabel, searchBox, addGenreButton, refreshButton
            });
            mainPanel.Controls.Add(genresGrid);

            var layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.BackColor = Color.Transparent;
            layout.RowCount = 2;
            layout.ColumnCount = 1;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100)); // Header height
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Fill remaining
            layout.Controls.Add(headerPanel, 0, 0);
            layout.Controls.Add(mainPanel, 0, 1);

            this.Controls.Add(layout);
        }

        private void SetupDataGrid()
        {
            // Genres Grid basic settings
            genresGrid.Dock = DockStyle.Fill;
            genresGrid.BackgroundColor = Color.FromArgb(52, 73, 94);
            genresGrid.BorderStyle = BorderStyle.None;
            genresGrid.GridColor = Color.FromArgb(44, 62, 80);

            // Cell and row styling
            genresGrid.RowTemplate.Height = 40;
            genresGrid.RowTemplate.DefaultCellStyle.Padding = new Padding(5);
            genresGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(47, 66, 85);
            genresGrid.DefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            genresGrid.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            genresGrid.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            genresGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            genresGrid.DefaultCellStyle.SelectionForeColor = Color.White;

            // Column header styling
            genresGrid.ColumnHeadersHeight = 50;
            genresGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 49, 63);
            genresGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            genresGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            genresGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            genresGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            genresGrid.EnableHeadersVisualStyles = false;

            // Border and selection styling
            genresGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            genresGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            genresGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            genresGrid.MultiSelect = false;

            // Remove unused features
            genresGrid.RowHeadersVisible = false;
            genresGrid.AllowUserToAddRows = false;
            genresGrid.AllowUserToDeleteRows = false;
            genresGrid.AllowUserToResizeRows = false;
            genresGrid.ReadOnly = true;

            // Initialize columns with enhanced styling
            var idColumn = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            var titleColumn = new DataGridViewTextBoxColumn
            {
                Name = "Title",
                HeaderText = "Genre Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Padding = new Padding(10, 0, 0, 0)
                }
            };

            // Add columns to grid
            genresGrid.Columns.AddRange(new DataGridViewColumn[] { idColumn, titleColumn });

            // Add hover effect
            genresGrid.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    genresGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(57, 79, 102);
                }
            };

            genresGrid.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    genresGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        e.RowIndex % 2 == 0 ? Color.FromArgb(52, 73, 94) : Color.FromArgb(47, 66, 85);
                }
            };
            genresGrid.CellClick += GenresGrid_CellClick;
        }

        private void GenresGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure it's not the header row
            {
                string genreId = genresGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                string query = $"SELECT * FROM [Movie Tape] WHERE genreId = {genreId}";
                // Get the parent form and show ucMovies with filtered movies
                var mainForm = this.FindForm() as ApplicationForm;
                if (mainForm != null)
                {
                    var moviesControl = new ucMovies();
                    moviesControl.loadMovies(query);
                    mainForm.LoadUserControl(moviesControl);
                }
            }
        }

        public List<genreItem> loadGenres()
        {
            try
            {
                genresGrid.Rows.Clear();
                string query = "SELECT * FROM Genre";

                List<genreItem> genresList = DatabaseManager.FetchData(query, reader => new genreItem
                {
                    id = reader.GetInt32(0),
                    title = reader.GetString(1),
                });


                foreach (var genre in genresList)
                {
                    genresGrid.Rows.Add(genre.id, genre.title);
                }
                return genresList;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading genres: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = searchBox.Text.Trim().ToLower();
                foreach (DataGridViewRow row in genresGrid.Rows)
                {
                    bool visible = row.Cells["Title"].Value.ToString().ToLower().Contains(searchTerm);
                    row.Visible = visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering genres: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}