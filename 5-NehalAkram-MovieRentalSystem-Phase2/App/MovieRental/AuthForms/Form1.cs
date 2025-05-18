using System.Drawing;
using System.Windows.Forms;

namespace MovieRental.AuthForms
{
    public class Form1 : Form
    {
        private Button sign_btn;
        private Button log_btn;
        private Label headerLabel;

        public Form1()
        {
            InitializeComponent();
            // Prevent form resizing and maximizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void InitializeComponent()
        {
            sign_btn = new Button();
            log_btn = new Button();
            headerLabel = new Label();
            SuspendLayout();

            // sign_btn
            sign_btn.BackColor = Color.FromArgb(52, 152, 219);
            sign_btn.FlatAppearance.BorderSize = 0;
            sign_btn.FlatStyle = FlatStyle.Flat;
            sign_btn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            sign_btn.ForeColor = Color.White;
            sign_btn.Location = new Point(186, 113);
            sign_btn.Size = new Size(182, 81);
            sign_btn.Text = "Sign Up";
            sign_btn.Click += sign_btn_Click;

            // log_btn
            log_btn.BackColor = Color.FromArgb(46, 204, 113);
            log_btn.FlatAppearance.BorderSize = 0;
            log_btn.FlatStyle = FlatStyle.Flat;
            log_btn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            log_btn.ForeColor = Color.White;
            log_btn.Location = new Point(186, 249);
            log_btn.Size = new Size(182, 81);
            log_btn.Text = "Log In";
            log_btn.Click += log_btn_Click;

            // headerLabel
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            headerLabel.ForeColor = Color.WhiteSmoke;
            headerLabel.Location = new Point(173, 36);
            headerLabel.Size = new Size(204, 41);
            headerLabel.Text = "📽️ Rented";

            // Form1
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
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rented";

            ResumeLayout(false);
            PerformLayout();
        }

        private void sign_btn_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide();
        }

        private void log_btn_Click(object sender, EventArgs e)
        {
            LogInForm logInForm = new LogInForm();
            logInForm.Show();
            this.Hide();
        }
    }
}
