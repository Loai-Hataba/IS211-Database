namespace MovieRental
{
    partial class ucMovies
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nigga = new Button();
            SuspendLayout();
            // 
            // nigga
            // 
            nigga.Location = new Point(288, 154);
            nigga.Name = "nigga";
            nigga.Size = new Size(102, 58);
            nigga.TabIndex = 0;
            nigga.Text = "nigga";
            nigga.UseVisualStyleBackColor = true;
            nigga.Click += nigga_Click;
            // 
            // ucMovies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(nigga);
            Name = "ucMovies";
            Size = new Size(782, 512);
            ResumeLayout(false);
        }

        #endregion

        private Button nigga;
    }
}
