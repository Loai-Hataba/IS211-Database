namespace MovieRental
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sign_btn = new Button();
            log_btn = new Button();
            headerLabel = new Label();
            SuspendLayout();
            // 
            // sign_btn
            // 
            sign_btn.BackColor = Color.FromArgb(52, 152, 219);
            sign_btn.FlatAppearance.BorderSize = 0;
            sign_btn.FlatStyle = FlatStyle.Flat;
            sign_btn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            sign_btn.ForeColor = Color.White;
            sign_btn.Location = new Point(186, 113);
            sign_btn.Name = "sign_btn";
            sign_btn.Size = new Size(182, 81);
            sign_btn.TabIndex = 0;
            sign_btn.Text = "Sign Up";
            sign_btn.UseVisualStyleBackColor = false;
            sign_btn.Click += sign_btn_Click;
            // 
            // log_btn
            // 
            log_btn.BackColor = Color.FromArgb(46, 204, 113);
            log_btn.FlatAppearance.BorderSize = 0;
            log_btn.FlatStyle = FlatStyle.Flat;
            log_btn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            log_btn.ForeColor = Color.White;
            log_btn.Location = new Point(186, 249);
            log_btn.Name = "log_btn";
            log_btn.Size = new Size(182, 81);
            log_btn.TabIndex = 1;
            log_btn.Text = "Log In";
            log_btn.UseVisualStyleBackColor = false;
            log_btn.Click += log_btn_Click;
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            headerLabel.ForeColor = Color.WhiteSmoke;
            headerLabel.Location = new Point(173, 36);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(204, 41);
            headerLabel.TabIndex = 2;
            headerLabel.Text = "Movie Rental";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(558, 478);
            Controls.Add(headerLabel);
            Controls.Add(log_btn);
            Controls.Add(sign_btn);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movie Rental";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sign_btn;
        private Button log_btn;
        private Label headerLabel;
    }
}
