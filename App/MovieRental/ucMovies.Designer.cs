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
            filterTitle = new Label();
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
            filterPanel.BackColor = Color.FromArgb(34, 49, 63); // Slightly darker than main background
            filterPanel.Dock = DockStyle.Right;
            filterPanel.Width = 300;
            filterPanel.Padding = new Padding(20);
            filterPanel.Location = new Point(1661, 0);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(300, 950);
            filterPanel.TabIndex = 0;
            // 
            // filterTitle
            // 
            filterTitle.Location = new Point(0, 0);
            filterTitle.Name = "filterTitle";
            filterTitle.Size = new Size(100, 23);
            filterTitle.TabIndex = 0;
            filterTitle.Text = "Filter Movies";
            filterTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            filterTitle.ForeColor = Color.FromArgb(52, 152, 219);
            filterTitle.AutoSize = true;
            filterTitle.Dock = DockStyle.Top;
            filterTitle.Padding = new Padding(0, 0, 0, 20);
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

            // Search Box
            TextBox searchBox = new TextBox
            {
                PlaceholderText = "🔍 Search movies...",
                Font = new Font("Segoe UI", 11F),
                Width = 260,
                Height = 30,
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.WhiteSmoke
            };

            // Genre Filter
            Label genreLabel = new Label
            {
                Text = "Genre:",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.WhiteSmoke,
                AutoSize = true,
                Padding = new Padding(0, 15, 0, 5)
            };

            ComboBox genreFilter = new ComboBox
            {
                Width = 260,
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 11F)
            };

            // Price Range
            Label priceLabel = new Label
            {
                Text = "Price Range:",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.WhiteSmoke,
                AutoSize = true,
                Padding = new Padding(0, 15, 0, 5)
            };

            FlowLayoutPanel pricePanel = new FlowLayoutPanel
            {
                Width = 260,
                Height = 35,
                FlowDirection = FlowDirection.LeftToRight
            };

            TextBox minPrice = new TextBox
            {
                PlaceholderText = "Min",
                Width = 120,
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 11F)
            };

            TextBox maxPrice = new TextBox
            {
                PlaceholderText = "Max",
                Width = 120,
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 11F)
            };

            pricePanel.Controls.AddRange(new Control[] { minPrice, maxPrice });

            // Release Year Range
            Label yearLabel = new Label
            {
                Text = "Release Year:",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.WhiteSmoke,
                AutoSize = true,
                Padding = new Padding(0, 15, 0, 5)
            };

            ComboBox yearFilter = new ComboBox
            {
                Width = 260,
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 11F)
            };

            // Apply Filter Button
            Button applyFilter = new Button
            {
                Text = "Apply Filters",
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F),
                Width = 260,
                Height = 40,
                Margin = new Padding(0, 20, 0, 0)
            };

            // Reset Filter Button
            Button resetFilter = new Button
            {
                Text = "Reset",
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F),
                Width = 260,
                Height = 40,
                Margin = new Padding(0, 10, 0, 0)
            };

            // Add controls to filter panel
            FlowLayoutPanel filterControls = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                WrapContents = false
            };

            filterControls.Controls.AddRange(new Control[] {
        filterTitle,
        searchBox,
        genreLabel,
        genreFilter,
        priceLabel,
        pricePanel,
        yearLabel,
        yearFilter,
        applyFilter,
        resetFilter
    });

            filterPanel.Controls.Add(filterControls);
        }

        #endregion

        private Label filterTitle;
    }
}
