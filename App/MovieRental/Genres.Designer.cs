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
            label1 = new Label();
            baba = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(475, 188);
            label1.MaximumSize = new Size(1000, 1000);
            label1.MinimumSize = new Size(5, 5);
            label1.Name = "label1";
            label1.Size = new Size(262, 128);
            label1.TabIndex = 0;
            label1.Text = "koko";
            // 
            // baba
            // 
            baba.Font = new Font("Segoe UI", 20F);
            baba.Location = new Point(509, 375);
            baba.Name = "baba";
            baba.Size = new Size(353, 192);
            baba.TabIndex = 1;
            baba.Text = "baba we mama";
            baba.UseVisualStyleBackColor = true;
            baba.Click += baba_click;
            // 
            // Genres
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(baba);
            Controls.Add(label1);
            Name = "Genres";
            Size = new Size(1501, 885);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button baba;

        private void baba_click(object sender, EventArgs e)
        {
            // Handle button click event here
            MessageBox.Show("Button clicked!");
        }
    }
}
