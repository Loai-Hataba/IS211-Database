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
            filterPanel.BackColor = Color.FromArgb(44, 62, 80);
            filterPanel.Controls.Add(filterTitle);
            filterPanel.Dock = DockStyle.Fill;
            filterPanel.Location = new Point(1661, 0);
            filterPanel.Name = "filterPanel";
            filterPanel.Padding = new Padding(20);
            filterPanel.Size = new Size(139, 950);
            filterPanel.TabIndex = 0;
            // 
            // filterTitle
            // 
            filterTitle.Location = new Point(0, 0);
            filterTitle.Name = "filterTitle";
            filterTitle.Size = new Size(100, 23);
            filterTitle.TabIndex = 0;
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
        }

        #endregion

        private Label filterTitle;
    }
}
