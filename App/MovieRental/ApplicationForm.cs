using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MovieRental
{
    public partial class ApplicationForm : Form
    {
        private Panel headerPanel;
        private Panel navigationPanel;
        private Panel activeIndicator;
        private Button userProfileButton;
        private Button cartButton;

        public ApplicationForm()
        {
            InitializeComponent();
            CustomizeComponents();
            loadMovieBtn_Click(this, EventArgs.Empty); // Call Movies tab load at startup
        }

        private void CustomizeComponents()
        {
            // Form styling
            this.BackColor = Color.FromArgb(44, 62, 80);  // Dark blue-gray background
            
            // Create header panel with shadow effect
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 104,
                BackColor = Color.FromArgb(34, 49, 63),  // Slightly darker than background
                Padding = new Padding(20, 0, 20, 0)
            };
            headerPanel.Paint += (s, e) => DrawPanelShadow(headerPanel, e);

            // Navigation panel for buttons
            navigationPanel = new Panel
            {
                Height = 104,
                BackColor = Color.Transparent,
                AutoSize = true,
                Padding = new Padding(0)
            };

            // Style the Genre button with modern look
            loadGenreBtn.FlatStyle = FlatStyle.Flat;
            loadGenreBtn.FlatAppearance.BorderSize = 0;
            loadGenreBtn.BackColor = Color.Transparent;
            loadGenreBtn.ForeColor = Color.WhiteSmoke;
            loadGenreBtn.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Regular);
            loadGenreBtn.Size = new Size(150, 80);
            loadGenreBtn.Location = new Point(0, 12);
            loadGenreBtn.Cursor = Cursors.Hand;
            loadGenreBtn.TextAlign = ContentAlignment.MiddleCenter;

            // Style the Movies button with modern look
            loadMovieBtn.FlatStyle = FlatStyle.Flat;
            loadMovieBtn.FlatAppearance.BorderSize = 0;
            loadMovieBtn.BackColor = Color.Transparent;
            loadMovieBtn.ForeColor = Color.WhiteSmoke;
            loadMovieBtn.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Regular);
            loadMovieBtn.Size = new Size(150, 80);
            loadMovieBtn.Location = new Point(160, 12);
            loadMovieBtn.Cursor = Cursors.Hand;
            loadMovieBtn.TextAlign = ContentAlignment.MiddleCenter;

            // Create a right-aligned panel for profile and cart buttons
            Panel rightButtonsPanel = new Panel
            {
                Height = 104,
                AutoSize = true,
                BackColor = Color.Transparent,
                Dock = DockStyle.Right,
                Padding = new Padding(0, 12, 20, 12) // Add right padding to match header padding
            };

            // Create user profile button
            userProfileButton = CreateIconButton("👤", "Profile");
            userProfileButton.Margin = new Padding(10, 0, 0, 0);
            userProfileButton.Click += (s, e) => {
                var profileForm = new UserProfile();
                profileForm.Show();
            };

            // Create cart button
            cartButton = CreateIconButton("🛒", "Cart");
            cartButton.Margin = new Padding(10, 0, 0, 0);

            // Add buttons to right panel
            rightButtonsPanel.Controls.Add(userProfileButton);
            rightButtonsPanel.Controls.Add(cartButton);

            // Add smooth hover effects
            AddButtonHoverEffect(loadGenreBtn);
            AddButtonHoverEffect(loadMovieBtn);
            AddButtonHoverEffect(userProfileButton);
            AddButtonHoverEffect(cartButton);

            // Add logo/title
            Label titleLabel = new Label
            {
                Text = "Movie Rental",
                Font = new Font("Segoe UI", 26F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),  // Primary blue color
                AutoSize = true,
                Location = new Point(20, 25),
                Cursor = Cursors.Default
            };

            // Style the content panel with shadow
            contentPanel.BackColor = Color.FromArgb(52, 73, 94);  // Slightly lighter than background
            contentPanel.Padding = new Padding(20);
            contentPanel.Margin = new Padding(20);
            contentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            contentPanel.Paint += (s, e) => DrawPanelShadow(contentPanel, e);

            // Add subtle border to header
            Panel borderPanel = new Panel
            {
                Height = 1,
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(64, 82, 100)  // Slightly lighter than background
            };

            // Reorganize controls (same as before)
            this.Controls.Remove(loadGenreBtn);
            this.Controls.Remove(loadMovieBtn);
            this.Controls.Remove(contentPanel);

            navigationPanel.Controls.Add(loadGenreBtn);
            navigationPanel.Controls.Add(loadMovieBtn);

            headerPanel.Controls.Remove(userProfileButton);
            headerPanel.Controls.Remove(cartButton);
            
            headerPanel.Controls.Add(rightButtonsPanel);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(navigationPanel);
            headerPanel.Controls.Add(borderPanel);

            navigationPanel.Location = new Point(titleLabel.Right + 50, 0);

            this.Controls.Add(headerPanel);
            this.Controls.Add(contentPanel);

            // Initialize active indicator
            activeIndicator = new Panel
            {
                Height = 3,
                BackColor = Color.FromArgb(52, 152, 219),  // Primary blue color
                Width = loadMovieBtn.Width
            };
            navigationPanel.Controls.Add(activeIndicator);

            // Set up tab switching with animation
            loadGenreBtn.Click += (s, e) => AnimateTabSwitch(loadGenreBtn, loadMovieBtn);
            loadMovieBtn.Click += (s, e) => AnimateTabSwitch(loadMovieBtn, loadGenreBtn);

            // Set Movies as default active tab
            AnimateTabSwitch(loadMovieBtn, loadGenreBtn, false);
        }

        private Button CreateIconButton(string icon, string text)
        {
            var button = new Button
            {
                Text = $"{icon} {text}",
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = Color.Transparent,
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                Size = new Size(120, 80),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Dock = DockStyle.Left // Makes buttons flow left-to-right in the panel
            };

            return button;
        }

        private void AddButtonHoverEffect(Button button)
        {
            button.MouseEnter += (s, e) => {
                button.ForeColor = Color.FromArgb(52, 152, 219);  // Primary blue color
                button.Font = new Font(button.Font, FontStyle.Bold);
            };
            button.MouseLeave += (s, e) => {
                if (activeIndicator.Location.X != button.Location.X)
                {
                    button.ForeColor = Color.WhiteSmoke;
                    button.Font = new Font(button.Font, FontStyle.Regular);
                }
            };
        }

        private void DrawPanelShadow(Panel panel, PaintEventArgs e)
        {
            using (var shadowBrush = new SolidBrush(Color.FromArgb(20, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(shadowBrush, new Rectangle(0, panel.Height - 4, panel.Width, 4));
            }
        }

        private void DrawGradientText(Label label, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                label.ClientRectangle,
                Color.FromArgb(0, 120, 212),
                Color.FromArgb(0, 90, 180),
                LinearGradientMode.Horizontal))
            {
                e.Graphics.DrawString(label.Text, label.Font, brush, 0, 0);
            }
        }

        private async void AnimateTabSwitch(Button activeButton, Button inactiveButton, bool animate = true)
        {
            inactiveButton.ForeColor = Color.WhiteSmoke;
            inactiveButton.Font = new Font(inactiveButton.Font, FontStyle.Regular);
            activeButton.ForeColor = Color.FromArgb(52, 152, 219);  // Primary blue color
            activeButton.Font = new Font(activeButton.Font, FontStyle.Bold);

            if (animate)
            {
                int steps = 10;
                int currentX = activeIndicator.Location.X;
                int targetX = activeButton.Location.X;
                int stepSize = (targetX - currentX) / steps;

                for (int i = 0; i < steps; i++)
                {
                    activeIndicator.Location = new Point(currentX + (stepSize * i), activeButton.Bottom - 3);
                    await Task.Delay(10);
                }
            }

            activeIndicator.Location = new Point(activeButton.Location.X, activeButton.Bottom - 3);
            activeIndicator.Width = activeButton.Width;
            activeIndicator.BringToFront();
        }

        private void ApplicationForm_Load(object sender, EventArgs e)
        {
            // loadMovieBtn_Click();
          
        }
    }
}
