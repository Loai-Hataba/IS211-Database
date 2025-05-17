namespace MovieRental
{
    partial class ucMovies
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpMovies;
        private Panel filterPanel; // Add filter panel

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpMovies = new FlowLayoutPanel();
            filterPanel = new Panel();
            SuspendLayout();
            
            // Main content panel for movies
            flpMovies.Name = "flpMovies";
            flpMovies.Dock = DockStyle.Left;
            flpMovies.Width = 1700; // Adjusted width
            flpMovies.Height = 800; // Adjusted width
            flpMovies.FlowDirection = FlowDirection.LeftToRight;
            flpMovies.AutoScroll = true;
            flpMovies.WrapContents = true;
            flpMovies.Padding = new Padding(20);
            flpMovies.BackColor = Color.FromArgb(52, 73, 94);
            flpMovies.AutoSize = false;

            // Filter Panel - will automatically fill remaining space
            filterPanel.Dock = DockStyle.Fill; // Changed to Fill instead of Right
            filterPanel.BackColor = Color.FromArgb(44, 62, 80);
            filterPanel.Padding = new Padding(20);

            // Add a title to the filter panel
            Label filterTitle = new Label
            {
                Text = "Filters",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleLeft
            };
            filterPanel.Controls.Add(filterTitle);
            
            Controls.Add(filterPanel);
            Controls.Add(flpMovies);
            
            // UserControl properties
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            Name = "ucMovies";
            Size = new Size(1800, 950);
            ResumeLayout(false);
        }

        #endregion

    }
}
