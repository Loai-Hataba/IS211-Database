using System;
using System.Windows.Forms;
using System.Drawing;

namespace MovieRental
{
    public partial class CartPage : Form
    {
        private Panel navigationBar;
        private Button backButton;
        private Button homeButton;
        private Panel mainPanel;
        private FlowLayoutPanel cartItemsPanel;
        private Label titleLabel;
        private Label totalLabel;
        private Button checkoutButton;

        public CartPage()
        {
            InitializeComponent();
            LoadCartItems();
        }

        private void InitializeComponent()
        {
            // Form properties
            this.BackColor = Color.FromArgb(44, 62, 80);
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Shopping Cart";
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- Navigation Bar ---
            navigationBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(34, 49, 63),
                Padding = new Padding(10)
            };

            backButton = new Button
            {
                Text = "← Back",
                BackColor = Color.Transparent,
                ForeColor = Color.WhiteSmoke,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                Size = new Size(100, 40),
                Location = new Point(10, 10),
                Cursor = Cursors.Hand
            };
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Click += (s, e) => this.Close();
            backButton.MouseEnter += (s, e) => backButton.ForeColor = Color.FromArgb(52, 152, 219);
            backButton.MouseLeave += (s, e) => backButton.ForeColor = Color.WhiteSmoke;
            backButton.Click += backButton_Click;

            homeButton = new Button
            {
                Text = "🏠 Home",
                BackColor = Color.Transparent,
                ForeColor = Color.WhiteSmoke,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                Size = new Size(100, 40),
                Location = new Point(120, 10),
                Cursor = Cursors.Hand
            };
            homeButton.FlatAppearance.BorderSize = 0;
            homeButton.Click += (s, e) =>
            {
                var homePage = new ApplicationForm();
                homePage.Show();
                this.Close();
                homePage.BringToFront();
                homePage.Focus();
            };
            homeButton.MouseEnter += (s, e) => homeButton.ForeColor = Color.FromArgb(52, 152, 219);
            homeButton.MouseLeave += (s, e) => homeButton.ForeColor = Color.WhiteSmoke;

            navigationBar.Controls.AddRange(new Control[] { backButton, homeButton });

            // Add spacer panel
            Panel spacerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.FromArgb(44, 62, 80)
            };

            // --- Main Panel ---
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(52, 73, 94),
                Padding = new Padding(40)
            };

            // Title
            titleLabel = new Label
            {
                Text = "Shopping Cart",
                Font = new Font("Segoe UI", 32F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                AutoSize = true,
                Location = new Point(40, 20)
            };

            // Cart Items Panel
            cartItemsPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Location = new Point(40, 100),
                Size = new Size(1000, 500),
                BackColor = Color.FromArgb(44, 62, 80),
                Padding = new Padding(10)
            };

            // Total Label
            totalLabel = new Label
            {
                Text = "Total: $0.00",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113),
                AutoSize = true,
                Location = new Point(40, 620)
            };

            // Checkout Button
            checkoutButton = new Button
            {
                Text = "Proceed to Checkout",
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Size = new Size(200, 50),
                Location = new Point(840, 620),
                Cursor = Cursors.Hand
            };
            checkoutButton.FlatAppearance.BorderSize = 0;
            checkoutButton.Click += CheckoutButton_Click;

            // Add hover effects
            checkoutButton.MouseEnter += (s, e) => checkoutButton.BackColor = Color.FromArgb(39, 174, 96);
            checkoutButton.MouseLeave += (s, e) => checkoutButton.BackColor = Color.FromArgb(46, 204, 113);

            // Add controls to mainPanel
            mainPanel.Controls.AddRange(new Control[] {
                titleLabel,
                cartItemsPanel,
                totalLabel,
                checkoutButton
            });

            // Final Form Setup
            Controls.Add(mainPanel);
            Controls.Add(spacerPanel);
            Controls.Add(navigationBar);

            // Handle resize
            this.Resize += (s, e) =>
            {
                cartItemsPanel.Size = new Size(mainPanel.Width - 80, mainPanel.Height - 220);
                checkoutButton.Location = new Point(mainPanel.Width - 240, mainPanel.Height - 80);
                totalLabel.Location = new Point(40, mainPanel.Height - 80);
            };
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Panel CreateCartItemPanel(int movieId, string title, decimal price, string imageUrl)
        {
            Panel itemPanel = new Panel
            {
                Size = new Size(960, 120),
                BackColor = Color.FromArgb(34, 49, 63),
                Margin = new Padding(0, 0, 0, 10)
            };

            PictureBox movieImage = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(10, 10),
                BackColor = Color.FromArgb(44, 62, 80),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            try
            {
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    movieImage.Image = Image.FromFile(imageUrl);
                }
            }
            catch { }

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(100, 10),
                Size = new Size(400, 30)
            };

            Label priceLabel = new Label
            {
                Text = $"${price:F2}",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.FromArgb(46, 204, 113),
                Location = new Point(100, 45),
                Size = new Size(100, 20)
            };

            Button removeButton = new Button
            {
                Text = "Remove",
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                Size = new Size(100, 30),
                Location = new Point(840, 45),
                Cursor = Cursors.Hand
            };
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.Click += (s, e) => RemoveFromCart(movieId, itemPanel);

            // Add hover effects
            removeButton.MouseEnter += (s, e) => removeButton.BackColor = Color.FromArgb(192, 57, 43);
            removeButton.MouseLeave += (s, e) => removeButton.BackColor = Color.FromArgb(231, 76, 60);

            itemPanel.Controls.AddRange(new Control[] {
                movieImage,
                titleLabel,
                priceLabel,
                removeButton
            });

            return itemPanel;
        }

        private void LoadCartItems()
        {
            // TODO: Load actual cart items from database
            // Sample data
            var cartItems = new[]
            {
                new { Id = 1, Title = "Sample Movie 1", Price = 4.99m, ImageUrl = "" },
                new { Id = 2, Title = "Sample Movie 2", Price = 5.99m, ImageUrl = "" }
            };

            decimal total = 0;
            foreach (var item in cartItems)
            {
                var itemPanel = CreateCartItemPanel(item.Id, item.Title, item.Price, item.ImageUrl);
                cartItemsPanel.Controls.Add(itemPanel);
                total += item.Price;
            }

            totalLabel.Text = $"Total: ${total:F2}";
        }

        private void RemoveFromCart(int movieId, Panel itemPanel)
        {
            // TODO: Remove item from database
            cartItemsPanel.Controls.Remove(itemPanel);
            itemPanel.Dispose();

            // Recalculate total
            decimal total = 0;
            // TODO: Calculate new total from database
            totalLabel.Text = $"Total: ${total:F2}";
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            // TODO: Implement checkout functionality
            MessageBox.Show("Proceeding to checkout...", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}