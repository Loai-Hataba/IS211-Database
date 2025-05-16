namespace MovieRental
{
    partial class ucMovies
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpMovies;

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
            SuspendLayout();
            // 
            // flpMovies
            // 
            flpMovies.Name = "flpMovies";
            flpMovies.Dock = DockStyle.Fill;
            flpMovies.FlowDirection = FlowDirection.LeftToRight;
            flpMovies.AutoScroll = true;
            flpMovies.WrapContents = true;
            flpMovies.Padding = new Padding(10);
            flpMovies.BackColor = SystemColors.MenuHighlight;
            Controls.Add(flpMovies);
            // 
            // ucMovies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            Name = "ucMovies";
            Size = new Size(782, 512);
            ResumeLayout(false);
        }

        #endregion

    }
}
