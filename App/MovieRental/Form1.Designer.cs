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
            SuspendLayout();
            // 
            // sign_btn
            // 
            sign_btn.Location = new Point(186, 113);
            sign_btn.Name = "sign_btn";
            sign_btn.Size = new Size(182, 81);
            sign_btn.TabIndex = 0;
            sign_btn.Text = "Sign Up";
            sign_btn.UseVisualStyleBackColor = true;
            sign_btn.Click += sign_btn_Click;
            // 
            // log_btn
            // 
            log_btn.Location = new Point(186, 249);
            log_btn.Name = "log_btn";
            log_btn.Size = new Size(182, 81);
            log_btn.TabIndex = 1;
            log_btn.Text = "Log In";
            log_btn.UseVisualStyleBackColor = true;
            log_btn.Click += log_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Gray;
            ClientSize = new Size(556, 478);
            Controls.Add(log_btn);
            Controls.Add(sign_btn);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button sign_btn;
        private Button log_btn;
    }
}
