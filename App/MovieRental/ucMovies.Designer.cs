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
            
            // FlowLayoutPanel styling
            flpMovies.Name = "flpMovies";
            flpMovies.Dock = DockStyle.Fill;
            flpMovies.FlowDirection = FlowDirection.LeftToRight;
            flpMovies.AutoScroll = true;
            flpMovies.WrapContents = true;
            flpMovies.Padding = new Padding(40);  // Increased padding
            flpMovies.BackColor = Color.FromArgb(52, 73, 94);
            
            // Make the UserControl bigger
            Size = new Size(1900, 1000);  // Increased from 782, 512
    
            Controls.Add(flpMovies);
            
            // UserControl properties
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            Name = "ucMovies";
            ResumeLayout(false);
        }

        #endregion

    }
}
