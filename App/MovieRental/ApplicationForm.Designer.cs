using MovieRental.ProfilePages;
namespace MovieRental
{
    partial class ApplicationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            contentPanel = new Panel();
            loadGenreBtn = new Button();
            loadMovieBtn = new Button();
            SuspendLayout();
            // 
            // contentPanel
            // 
            contentPanel.Location = new Point(3, 104);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1900, 937);
            contentPanel.TabIndex = 0;
            // 
            // loadGenreBtn
            // 
            loadGenreBtn.Font = new Font("Segoe UI", 25F);
            loadGenreBtn.Location = new Point(516, 8);
            loadGenreBtn.Name = "loadGenreBtn";
            loadGenreBtn.Size = new Size(247, 90);
            loadGenreBtn.TabIndex = 1;
            loadGenreBtn.Text = "Genres";
            loadGenreBtn.UseVisualStyleBackColor = true;
            loadGenreBtn.Click += loadGenreBtn_Click;
            // 
            // loadMovieBtn
            // 
            loadMovieBtn.Font = new Font("Segoe UI", 25F);
            loadMovieBtn.Location = new Point(994, 12);
            loadMovieBtn.Name = "loadMovieBtn";
            loadMovieBtn.Size = new Size(185, 83);
            loadMovieBtn.TabIndex = 2;
            loadMovieBtn.Text = "Movies";
            loadMovieBtn.UseVisualStyleBackColor = true;
            loadMovieBtn.Click += loadMovieBtn_Click;
            // 
            // ApplicationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(loadMovieBtn);
            Controls.Add(loadGenreBtn);
            Controls.Add(contentPanel);
            Name = "ApplicationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApplicationForm";
            WindowState = FormWindowState.Maximized;
            Load += ApplicationForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel contentPanel;
        private Button loadGenreBtn;
        private Button loadMovieBtn;


        public void LoadUserControl(UserControl uc)
        {
            contentPanel.Controls.Clear();        // Remove any existing control
            uc.Dock = DockStyle.Fill; // Make it fill the panel
            uc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            contentPanel.Controls.Add(uc);        // Add the new control
        }

        public void loadGenreBtn_Click(object sender, EventArgs e)
        {
            // Load the Genre UserControl
            var genreControl = new Genres();
            LoadUserControl(genreControl);
            List<genreItem> genreItems = genreControl.loadGenres(); // Call the method to load genres
        }
        public void loadMovieBtn_Click(object sender, EventArgs e)
        {
            // Load the Genre UserControl
            var movieControl = new ucMovies();
            LoadUserControl(movieControl);
            List<movieItem> movieItems = movieControl.loadMovies(); // Call the method to load genres
        }

        public void loadProfileBtn_Click(object sender, EventArgs e)
        {
            // Load the Profile UserControl
            var profileControl = new UserProfile();
            profileControl.Show();
            this.Hide(); // Hide the main form
        }
    }
}