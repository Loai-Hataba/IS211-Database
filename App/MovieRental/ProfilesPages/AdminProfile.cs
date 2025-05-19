using System;
using System.Windows.Forms;
using System.Drawing;
using MovieRental.MovieForms;
// using QuestPDF.Fluent;
// using QuestPDF.Helpers;
// using QuestPDF.Infrastructure;
// using ScottPlot;
// using ScottPlot.Plottables;
using System.Data.SqlClient;
using System.Linq;

namespace MovieRental.ProfilePages
{
    public partial class AdminProfile : Form
    {
        private Panel mainPanel;
        private FlowLayoutPanel moviesFlowPanel;
        private Panel navigationBar;
        private Button backButton;
        private Button homeButton;
        private Button addMovieButton;
        private Button reportButton; // Add with other private fields at the top
        private Button logoutButton; // Add logout button
        private Button addAdminButton;
        private ContextMenuStrip movieContextMenu;

        public AdminProfile()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            LoadAllMovies();
        }

        private void InitializeComponent()
        {
            // Initialize all controls
            mainPanel = new Panel();
            moviesFlowPanel = new FlowLayoutPanel();
            navigationBar = new Panel();
            backButton = new Button();
            homeButton = new Button();
            addMovieButton = new Button();
            reportButton = new Button(); // Initialize report button
            logoutButton = new Button(); // Initialize logout button
            addAdminButton = new Button();
            movieContextMenu = new ContextMenuStrip();

            SuspendLayout();

            // --- Navigation Bar ---
            navigationBar.Dock = DockStyle.Top;
            navigationBar.Height = 60;
            navigationBar.BackColor = Color.FromArgb(34, 49, 63);
            navigationBar.Padding = new Padding(10);

            // Back Button
            backButton.Text = "← Back";
            backButton.BackColor = Color.Transparent;
            backButton.ForeColor = Color.WhiteSmoke;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Segoe UI", 11F);
            backButton.Size = new Size(100, 40);
            backButton.Location = new Point(10, 10);
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Cursor = Cursors.Hand;
            backButton.Click += (s, e) => this.Close();
            backButton.MouseEnter += (s, e) => backButton.ForeColor = Color.FromArgb(52, 152, 219);
            backButton.MouseLeave += (s, e) => backButton.ForeColor = Color.WhiteSmoke;
            backButton.Click += backButton_Click;
            // Home Button
            homeButton.Text = "🏠 Home";
            homeButton.BackColor = Color.Transparent;
            homeButton.ForeColor = Color.WhiteSmoke;
            homeButton.FlatStyle = FlatStyle.Flat;
            homeButton.Font = new Font("Segoe UI", 11F);
            homeButton.Size = new Size(100, 40);
            homeButton.Location = new Point(120, 10);
            homeButton.FlatAppearance.BorderSize = 0;
            homeButton.Cursor = Cursors.Hand;
            homeButton.Click += (s, e) =>
            {
              
                this.Close();
            };
            homeButton.MouseEnter += (s, e) => homeButton.ForeColor = Color.FromArgb(52, 152, 219);
            homeButton.MouseLeave += (s, e) => homeButton.ForeColor = Color.WhiteSmoke;

            // Add Movie Button
            addMovieButton = new Button
            {
                Text = "➕ Add Movie",
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                Size = new Size(120, 40),
                Location = new Point(navigationBar.Width - 140, 10),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            addMovieButton.FlatAppearance.BorderSize = 0;
            addMovieButton.Click += AddMovie_Click;
            addMovieButton.MouseEnter += (s, e) => addMovieButton.BackColor = Color.FromArgb(39, 174, 96);
            addMovieButton.MouseLeave += (s, e) => addMovieButton.BackColor = Color.FromArgb(46, 204, 113);

            // Report Button
            reportButton = new Button
            {
                Text = "📊 Reports",
                BackColor = Color.FromArgb(52, 152, 219), // Blue color
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                Size = new Size(120, 40),
                Location = new Point(navigationBar.Width - 280, 10),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            reportButton.FlatAppearance.BorderSize = 0;
            reportButton.Click += ReportButton_Click;
            reportButton.MouseEnter += (s, e) => reportButton.BackColor = Color.FromArgb(41, 128, 185);
            reportButton.MouseLeave += (s, e) => reportButton.BackColor = Color.FromArgb(52, 152, 219);

            // Logout Button
            logoutButton = new Button
            {
                Text = "🚪 Logout",
                BackColor = Color.FromArgb(231, 76, 60), // Red color
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                Size = new Size(120, 40),
                Location = new Point(navigationBar.Width - 420, 10),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            logoutButton.FlatAppearance.BorderSize = 0;
            logoutButton.Click += LogoutButton_Click;
            logoutButton.MouseEnter += (s, e) => logoutButton.BackColor = Color.FromArgb(192, 57, 43);
            logoutButton.MouseLeave += (s, e) => logoutButton.BackColor = Color.FromArgb(231, 76, 60);

            // Add Admin Button
            addAdminButton = new Button
            {
                Text = "👤 Add Admin",
                BackColor = Color.FromArgb(155, 89, 182), // Purple color
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                Size = new Size(120, 40),
                Location = new Point(navigationBar.Width - 540, 10),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            addAdminButton.FlatAppearance.BorderSize = 0;
            addAdminButton.Click += AddAdminButton_Click;
            addAdminButton.MouseEnter += (s, e) => addAdminButton.BackColor = Color.FromArgb(142, 68, 173);
            addAdminButton.MouseLeave += (s, e) => addAdminButton.BackColor = Color.FromArgb(155, 89, 182);

            // Add to navigation bar
            navigationBar.Controls.AddRange(new Control[] { 
                backButton, 
                homeButton,
                addAdminButton,
                logoutButton,
                reportButton,
                addMovieButton 
            });

            // --- Main Panel ---
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.FromArgb(52, 73, 94);
            mainPanel.Padding = new Padding(40);

            // --- Movies Flow Panel ---
            moviesFlowPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(40),
                Margin = new Padding(0)  // Remove top margin since there's no title
            };

            // Setup context menu
            movieContextMenu.Items.Add("✎ Edit", null, (s, e) => EditMovie_Click(((ToolStripMenuItem)s).Tag, e));
            movieContextMenu.Items.Add("🗑️ Delete", null, (s, e) => DeleteMovie_Click(((ToolStripMenuItem)s).Tag, e));

            // Update controls hierarchy
            mainPanel.Controls.Add(moviesFlowPanel);

            Controls.Add(mainPanel);
            Controls.Add(navigationBar);

            BackColor = Color.FromArgb(44, 62, 80);
            WindowState = FormWindowState.Maximized;
            Text = "Admin Profile - Movie Management";

            ResumeLayout(false);
        }

        private void AddMovie_Click(object sender, EventArgs e)
        {
            using (var form = new AddMovieForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllMovies(); // Refresh the list
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void EditMovie_Click(object tag, EventArgs e)
        {
            if (tag is movieItem movie)
            {
                using (var form = new EditMovieForm(movie))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllMovies(); // Refresh the list
                    }
                }
            }
        }

        private void DeleteMovie_Click(object tag, EventArgs e)
        {
            if (tag is movieItem movie)
            {
                if (MessageBox.Show($"Are you sure you want to delete {movie.title}?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    MessageBox.Show($"Movie deleted: {movie.title}", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string query = "DELETE FROM [Movie Tape] WHERE tapeID = @Id";
                    var parameters = new Dictionary<string, object>
                        {
                            { "@Id", movie.id}
                        };
                    DatabaseManager.InsertData(query, parameters);
                    LoadAllMovies(); // Refresh the list
                }
            }
        }
        private void LoadAllMovies()
        {
            string query = "SELECT * FROM [Movie Tape]";
            moviesFlowPanel.Controls.Clear();

            List<movieItem> movieList = DatabaseManager.FetchData(query, reader => new movieItem
            {
                id = reader.GetInt32(0),          // TapeId
                title = reader.GetString(1),      // Title
                description = reader.GetString(2),
                actorId = reader.GetInt32(3),     // ActorID
                genreId = reader.GetInt32(4),     // GenreID
                rentalCharge = reader.GetDouble(5), // RentalCharge
                releaseDate = reader.GetDateTime(6), // ReleaseDate
                imagePath = reader.GetString(7),
                // ImagePath
                isAvailable = reader.GetBoolean(8) // IsAvailable
            });

            foreach (var movie in movieList)
            {
                var card = CreateAdminMovieCard(movie);
                moviesFlowPanel.Controls.Add(card);
            }
        }

        private Control CreateAdminMovieCard(movieItem movie)
        {
            var card = new movieCard(movie);

            // Remove the three dots button and use right-click context menu instead
            card.ContextMenuStrip = movieContextMenu;

            // Add mouse down event to handle right click
            card.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    foreach (ToolStripItem item in movieContextMenu.Items)
                    {
                        item.Tag = movie;
                    }
                }
            };

            // Make all child controls show the context menu on right click
            foreach (Control control in card.Controls)
            {
                control.ContextMenuStrip = movieContextMenu;
                control.MouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        foreach (ToolStripItem item in movieContextMenu.Items)
                        {
                            item.Tag = movie;
                        }
                    }
                };
            }

            // Style the context menu
            movieContextMenu.BackColor = Color.FromArgb(34, 49, 63);
            movieContextMenu.ForeColor = Color.WhiteSmoke;
            movieContextMenu.Font = new Font("Segoe UI", 11F);
            foreach (ToolStripItem item in movieContextMenu.Items)
            {
                item.BackColor = Color.FromArgb(34, 49, 63);
            }

            return card;
        }

        private void ReportButton_Click(object sender, EventArgs e)
         {
        //     QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

        //     Document.Create(container =>
        //     {
        //         container.Page(page =>
        //         {
        //             page.Size(PageSizes.A4);
        //             page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);

        //             page.Content().Column(column =>
        //             {
        //                 column.Spacing(10);

        //                 column.Item().Text("1] Rentals per Genre")
        //                     .AlignLeft().Bold()
        //                     .FontFamily("RockWell").FontSize(24);

        //                 column.Item().AspectRatio(1).Svg(size =>
        //                 {
        //                     Dictionary<string, int> genreRentals = getGenreRentals();
        //                     return GenerateBarChart(genreRentals, size);
        //                 });

        //                 column.Item().PageBreak();

        //                 column.Item().Text("2] Profit per Genre")
        //                     .AlignLeft().Bold()
        //                     .FontFamily("RockWell").FontSize(24);

        //                 column.Item().AspectRatio(1).Svg(size =>
        //                 {
        //                     Dictionary<string, int> genreProfit = getGenreProfit();
        //                     return GenerateBarChart(genreProfit, size);
        //                 });
        //             });

        //             page.Footer().AlignCenter()
        //                 .Text(x =>
        //                 {
        //                     x.Span("Page ").FontFamily("Rockwell");
        //                     x.CurrentPageNumber();
        //                 });
        //         });
        //     }).GeneratePdfAndShow();
        }

        // // Add the helper methods from report.cs
        // private Dictionary<string, int> getGenreRentals()
        // {
        //     // Copy implementation from report.cs
        // }

        // private Dictionary<string, int> getGenreProfit()
        // {
        //     // Copy implementation from report.cs
        // }

        // private string GenerateBarChart(Dictionary<string, int> stats, QuestPDF.Infrastructure.Size size)
        // {
        //     // Copy implementation from report.cs
        // }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private void AddAdminButton_Click(object sender, EventArgs e)
        {
            using (var form = new AddAdminForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string query = @"INSERT INTO Admin ([name], Email, PhoneNum, [password]) VALUES (@name, @email, @phoneNum, @password);";
                    var parameters = new Dictionary<string, object>
                    {
                        {@"name", form.AdminName},
                        {"@email", form.AdminEmail},
                        { @"phoneNum", form.AdminPhone},
                        {@"password", form.AdminPassword}
                    };
                    DatabaseManager.InsertData(query, parameters);

                    
                    MessageBox.Show("Admin added successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

