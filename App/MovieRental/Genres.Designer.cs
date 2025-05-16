namespace MovieRental
{
    partial class Genres
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
            genresDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)genresDataGrid).BeginInit();
            SuspendLayout();
            // 
            // genresDataGrid
            // 
            genresDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            genresDataGrid.Location = new Point(3, 3);
            genresDataGrid.Name = "genresDataGrid";
            genresDataGrid.Size = new Size(1344, 674);
            genresDataGrid.TabIndex = 0;
            genresDataGrid.AllowUserToAddRows = false;
            genresDataGrid.AllowUserToDeleteRows = false;
            genresDataGrid.ReadOnly = true;
            genresDataGrid.RowTemplate.Height = 25;
            // 
            // Genres
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(genresDataGrid);
            Name = "Genres";
            Size = new Size(1501, 885);
            ((System.ComponentModel.ISupportInitialize)genresDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView genresDataGrid;
    }
}
