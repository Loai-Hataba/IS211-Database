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
            // Add tooltips component
            var toolTip = new ToolTip();
            
            flpMovies = new FlowLayoutPanel();
            filterPanel = new Panel();
            filterTitle = new Label();
            searchBox = new TextBox();
            genreComboBox = new ComboBox();
            priceMinBox = new TextBox();
            priceMaxBox = new TextBox();
            yearComboBox = new ComboBox();
            applyFiltersButton = new Button();
            resetButton = new Button();
            filterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // flpMovies
            // 
            flpMovies.AutoScroll = true;
            flpMovies.BackColor = Color.FromArgb(52, 73, 94);
            flpMovies.Dock = DockStyle.Left;
            flpMovies.Location = new Point(0, 0);
            flpMovies.Name = "flpMovies";
            flpMovies.Padding = new Padding(20);
            flpMovies.Size = new Size(1661, 950);
            flpMovies.TabIndex = 1;
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.FromArgb(44, 62, 80);
            filterPanel.Dock = DockStyle.Fill;
            filterPanel.Location = new Point(1661, 0);
            filterPanel.Name = "filterPanel";
            filterPanel.Padding = new Padding(20);
            filterPanel.Size = new Size(239, 950);
            filterPanel.TabIndex = 0;
            // 
            // filterTitle
            // 
            filterTitle.Text = "Filter Movies";
            filterTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            filterTitle.ForeColor = Color.FromArgb(52, 152, 219);
            filterTitle.Location = new Point(0, 10);
            filterTitle.Size = new Size(220, 40);
            filterTitle.AutoSize = false;
            // 
            // searchBox
            // 
            searchBox.PlaceholderText = "🔍 Search movies...";
            searchBox.Font = new Font("Segoe UI", 11F);
            searchBox.Size = new Size(200, 30);
            searchBox.Location = new Point(0, 65);
            searchBox.BackColor = Color.FromArgb(52, 73, 94);
            searchBox.ForeColor = Color.WhiteSmoke;
            // 
            // genreComboBox
            // 
            genreComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            genreComboBox.Font = new Font("Segoe UI", 11F);
            genreComboBox.Size = new Size(200, 30);
            genreComboBox.Location = new Point(0, 125);
            genreComboBox.BackColor = Color.FromArgb(52, 73, 94);
            genreComboBox.ForeColor = Color.WhiteSmoke;
            // 
            // priceMinBox
            // 
            priceMinBox.PlaceholderText = "Min";
            priceMinBox.Font = new Font("Segoe UI", 11F);
            priceMinBox.Size = new Size(90, 30);
            priceMinBox.Location = new Point(0, 185);
            priceMinBox.BackColor = Color.FromArgb(52, 73, 94);
            priceMinBox.ForeColor = Color.WhiteSmoke;
            // 
            // priceMaxBox
            // 
            priceMaxBox.PlaceholderText = "Max";
            priceMaxBox.Font = new Font("Segoe UI", 11F);
            priceMaxBox.Size = new Size(90, 30);
            priceMaxBox.Location = new Point(110, 185);
            priceMaxBox.BackColor = Color.FromArgb(52, 73, 94);
            priceMaxBox.ForeColor = Color.WhiteSmoke;
            // 
            // yearComboBox
            // 
            yearComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            yearComboBox.Font = new Font("Segoe UI", 11F);
            yearComboBox.Size = new Size(200, 30);
            yearComboBox.Location = new Point(0, 245);
            yearComboBox.BackColor = Color.FromArgb(52, 73, 94);
            yearComboBox.ForeColor = Color.WhiteSmoke;
            // 
            // applyFiltersButton
            // 
            applyFiltersButton.Text = "Apply Filters";
            applyFiltersButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            applyFiltersButton.Size = new Size(200, 40);
            applyFiltersButton.Location = new Point(0, 305);
            applyFiltersButton.BackColor = Color.FromArgb(52, 152, 219);
            applyFiltersButton.ForeColor = Color.White;
            applyFiltersButton.FlatStyle = FlatStyle.Flat;
            applyFiltersButton.FlatAppearance.BorderSize = 0;
            // 
            // resetButton
            // 
            resetButton.Text = "Reset";
            resetButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            resetButton.Size = new Size(200, 40);
            resetButton.Location = new Point(0, 355);
            resetButton.BackColor = Color.FromArgb(231, 76, 60);
            resetButton.ForeColor = Color.White;
            resetButton.FlatStyle = FlatStyle.Flat;
            resetButton.FlatAppearance.BorderSize = 0;
            // 
            // Add controls to filterPanel
            filterPanel.Controls.Clear();
            filterPanel.Controls.Add(filterTitle);
            Label genreLabel = new Label { Text = "Genre:", Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.WhiteSmoke, Location = new Point(0, 105), Size = new Size(200, 20) };
            filterPanel.Controls.Add(searchBox);
            filterPanel.Controls.Add(genreLabel);
            filterPanel.Controls.Add(genreComboBox);
            Label priceLabel = new Label { Text = "Price Range:", Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.WhiteSmoke, Location = new Point(0, 165), Size = new Size(200, 20) };
            filterPanel.Controls.Add(priceLabel);
            filterPanel.Controls.Add(priceMinBox);
            filterPanel.Controls.Add(priceMaxBox);
            Label yearLabel = new Label { Text = "Release Year:", Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.WhiteSmoke, Location = new Point(0, 225), Size = new Size(200, 20) };
            filterPanel.Controls.Add(yearLabel);
            filterPanel.Controls.Add(yearComboBox);
            filterPanel.Controls.Add(applyFiltersButton);
            filterPanel.Controls.Add(resetButton);
            // 
            // ucMovies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            Controls.Add(filterPanel);
            Controls.Add(flpMovies);
            Name = "ucMovies";
            Size = new Size(1900, 940);
            filterPanel.ResumeLayout(false);
            ResumeLayout(false);

            // Add tooltips
            toolTip.SetToolTip(searchBox, "Search by movie title");
            toolTip.SetToolTip(genreComboBox, "Filter by movie genre");
            toolTip.SetToolTip(priceMinBox, "Minimum rental price");
            toolTip.SetToolTip(priceMaxBox, "Maximum rental price");
            toolTip.SetToolTip(yearComboBox, "Filter by release year");
            toolTip.SetToolTip(applyFiltersButton, "Apply selected filters");
            toolTip.SetToolTip(resetButton, "Reset all filters to default");

            // Make text boxes read-only during filter operation
            searchBox.ReadOnly = false;
            priceMinBox.ReadOnly = false;
            priceMaxBox.ReadOnly = false;

            // Update sizes and positions
            filterPanel.Width = 250; // Make filter panel slightly wider
            flpMovies.Width = this.Width - filterPanel.Width;
        }

        #endregion

        private Label filterTitle;
        private TextBox searchBox;
        private ComboBox genreComboBox;
        private TextBox priceMinBox;
        private TextBox priceMaxBox;
        private ComboBox yearComboBox;
        private Button applyFiltersButton;
        private Button resetButton;
    }
}
