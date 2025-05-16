using System;
using System.Windows.Forms;
using System.Drawing;

namespace MovieRental
{
    public partial class AdminProfile : Form
    {
        private Panel mainPanel;
        private FlowLayoutPanel moviesFlowPanel;
        private Label titleLabel;
        private Panel navigationBar;
        private Button backButton;
        private Button homeButton;
        private Panel actionPanel;
        private Button addMovieButton;
        private Button editMovieButton;
        private Button deleteMovieButton;

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
            titleLabel = new Label();
            navigationBar = new Panel();
            backButton = new Button();
            homeButton = new Button();
            actionPanel = new Panel();
            addMovieButton = new Button();
            editMovieButton = new Button();
            deleteMovieButton = new Button();

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
            homeButton.Click += (s, e) => {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is ApplicationForm)
                    {
                        form.Show();
                    }
                    else if (form != this)
                    {
                        form.Close();
                    }
                }
                this.Close();
            };
            homeButton.MouseEnter += (s, e) => homeButton.ForeColor = Color.FromArgb(52, 152, 219);
            homeButton.MouseLeave += (s, e) => homeButton.ForeColor = Color.WhiteSmoke;

            // Action Panel with Admin Buttons
            actionPanel = new Panel
            {
                Height = 40,
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(navigationBar.Width - 400, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            // Add Movie Button
            addMovieButton = new Button
            {
                Text = "➕ Add Movie",
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                Size = new Size(120, 40),
                Location = new Point(0, 0),
                Cursor = Cursors.Hand
            };
            addMovieButton.FlatAppearance.BorderSize = 0;
            addMovieButton.Click += AddMovie_Click;

            // Edit Movie Button
            editMovieButton = new Button
            {
                Text = "✎ Edit",
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                Size = new Size(120, 40),
                Location = new Point(130, 0),
                Cursor = Cursors.Hand
            };
            editMovieButton.FlatAppearance.BorderSize = 0;
            editMovieButton.Click += EditMovie_Click;

            // Delete Movie Button
            deleteMovieButton = new Button
            {
                Text = "🗑️ Delete",
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                Size = new Size(120, 40),
                Location = new Point(260, 0),
                Cursor = Cursors.Hand
            };
            deleteMovieButton.FlatAppearance.BorderSize = 0;
            deleteMovieButton.Click += DeleteMovie_Click;

            // Add hover effects
            addMovieButton.MouseEnter += (s, e) => addMovieButton.BackColor = Color.FromArgb(39, 174, 96);
            addMovieButton.MouseLeave += (s, e) => addMovieButton.BackColor = Color.FromArgb(46, 204, 113);
            
            editMovieButton.MouseEnter += (s, e) => editMovieButton.BackColor = Color.FromArgb(41, 128, 185);
            editMovieButton.MouseLeave += (s, e) => editMovieButton.BackColor = Color.FromArgb(52, 152, 219);
            
            deleteMovieButton.MouseEnter += (s, e) => deleteMovieButton.BackColor = Color.FromArgb(192, 57, 43);
            deleteMovieButton.MouseLeave += (s, e) => deleteMovieButton.BackColor = Color.FromArgb(231, 76, 60);

            // Add buttons to action panel
            actionPanel.Controls.AddRange(new Control[] { addMovieButton, editMovieButton, deleteMovieButton });

            // Add all elements to navigation bar
            navigationBar.Controls.Add(backButton);
            navigationBar.Controls.Add(homeButton);
            navigationBar.Controls.Add(actionPanel);

            // --- Main Panel ---
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.FromArgb(52, 73, 94);
            mainPanel.Padding = new Padding(40, 20, 40, 40);

            // --- Title Label ---
            titleLabel.Text = "Movie Management";
            titleLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(52, 152, 219);
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(40, 20);

            // --- Movies Flow Panel ---
            moviesFlowPanel.AutoScroll = true;
            moviesFlowPanel.BackColor = Color.Transparent;
            moviesFlowPanel.Dock = DockStyle.Bottom;
            moviesFlowPanel.Size = new Size(ClientSize.Width - 80, ClientSize.Height - 200);
            moviesFlowPanel.Padding = new Padding(20);
            moviesFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            moviesFlowPanel.Location = new Point(0, 120);

            // Add controls to mainPanel
            mainPanel.Controls.Add(titleLabel);
            mainPanel.Controls.Add(moviesFlowPanel);

            // --- Final Form Setup ---
            Controls.Add(mainPanel);
            Controls.Add(navigationBar);

            BackColor = Color.FromArgb(44, 62, 80);
            WindowState = FormWindowState.Maximized;
            Text = "Admin Profile - Movie Management";
            ResumeLayout(false);
            PerformLayout();

            // Handle window resize
            this.Resize += (s, e) =>
            {
                moviesFlowPanel.Size = new Size(mainPanel.Width - 40, mainPanel.Height - 160);
            };
        }

        private void AddMovie_Click(object sender, EventArgs e)
        {
            // TODO: Implement Add Movie functionality
            MessageBox.Show("Add Movie functionality to be implemented", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditMovie_Click(object sender, EventArgs e)
        {
            // TODO: Implement Edit Movie functionality
            MessageBox.Show("Edit Movie functionality to be implemented", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteMovie_Click(object sender, EventArgs e)
        {
            // TODO: Implement Delete Movie functionality
            MessageBox.Show("Delete Movie functionality to be implemented", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadAllMovies()
        {
            // TODO: Load movies from database
            // For now, using sample data similar to UserProfile
            // Implement actual database loading logic
        }
    }
}