using System;
using System.Windows.Forms;
using System.Drawing;
using MovieRental.AuthForms;
using System.IO;

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
       


        public CartPage(ApplicationForm homepage)
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
              this.Close();
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
        private Panel CreateCartItemPanel(int movieId, string title, double price, string imageUrl)
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
                    string imageFileName = imageUrl;
                    string assetsPath = Path.Combine(Application.StartupPath, "..", "..", "..", "..", "Assets", imageFileName);
                    
                    if (File.Exists(assetsPath))
                    {
                        using (var stream = new FileStream(assetsPath, FileMode.Open, FileAccess.Read))
                        {
                            movieImage.Image = Image.FromStream(stream);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Image not found at: {assetsPath}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
            }

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
            removeButton.Click += (s, e) => RemoveFromCart(movieId, price, itemPanel);

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

        public double totalTemp;
        private void LoadCartItems()
        {
            totalTemp = 0;
            Cart cart = new Cart();
            string query = $"SELECT [Movie Tape].TapeID, [Movie Tape].Title,[Movie Tape].[Description],[Movie Tape].ActorID, [Movie Tape].GenreID, [Movie Tape].RentalCharge, [Movie Tape].ReleaseDate, [Movie Tape].ImagePath, [Movie Tape].IsAvailable FROM Cart JOIN [Movie Tape] ON Cart.TapeID = [Movie Tape].TapeID WHERE Cart.UID = {ApplicationForm.globalUID}";
            List<movieItem> moviesList = DatabaseManager.FetchData(query, reader => new movieItem
            {
                id = reader.GetInt32(0),
                title = reader.GetString(1),
                description = reader.GetString(2),
                actorId = reader.GetInt32(3),
                genreId = reader.GetInt32(4),
                rentalCharge = reader.GetDouble(5),
                releaseDate = reader.GetDateTime(6),
                imagePath = reader.GetString(7),
                isAvailable = reader.GetBoolean(8)
            });
            cart.moviesInCart = moviesList;

            cart.total = 0;
            foreach (var item in cart.moviesInCart)
            {
                var itemPanel = CreateCartItemPanel(item.id, item.title, item.rentalCharge, item.imagePath);
                cartItemsPanel.Controls.Add(itemPanel);
                cart.total += item.rentalCharge;
            }

            totalLabel.Text = $"Total: ${cart.total:F2}";
            totalTemp = cart.total;
        }

        private void RemoveFromCart(int movieId, double price, Panel itemPanel)
        {
            string query = $"DELETE FROM cart WHERE UID = {ApplicationForm.globalUID}  And TapeID = {movieId}";
            var parameters = new Dictionary<string, object>
            {
                { "@Id", movieId}
            };
            DatabaseManager.InsertData(query, parameters);
            cartItemsPanel.Controls.Remove(itemPanel);
            itemPanel.Dispose();

            totalTemp -= price;
            if (totalTemp < 0.1) totalTemp = 0;
            totalLabel.Text = $"Total: ${totalTemp:F2}";
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            
            // !FIXME: Mak the movie as rented in the database
            ///1- get the current cart 
            /// 2- insert the moives into the rented table
            /// remove the movies from the cart
            // 3- remove the movies from the cart
            string query = $"SELECT [Movie Tape].TapeID, [Movie Tape].Title,[Movie Tape].[Description],[Movie Tape].ActorID, [Movie Tape].GenreID, [Movie Tape].RentalCharge, [Movie Tape].ReleaseDate, [Movie Tape].ImagePath, [Movie Tape].IsAvailable FROM Cart JOIN [Movie Tape] ON Cart.TapeID = [Movie Tape].TapeID WHERE Cart.UID = {ApplicationForm.globalUID}";
            List<movieItem> moviesList = DatabaseManager.FetchData(query, reader => new movieItem
            {
                id = reader.GetInt32(0),
                title = reader.GetString(1),
                description = reader.GetString(2),
                actorId = reader.GetInt32(3),
                genreId = reader.GetInt32(4),
                rentalCharge = reader.GetDouble(5),
                releaseDate = reader.GetDateTime(6),
                imagePath = reader.GetString(7),
                isAvailable = reader.GetBoolean(8)
            });
            foreach (var item in moviesList)
            {
                string insertQuery = $"INSERT INTO Rents ([UID], TapeID, TotalCharge) VALUES (@UID ,@tapeId, @charge)";
                DatabaseManager.InsertData(insertQuery, new Dictionary<string, object>
                {
                    {"@UID", ApplicationForm.globalUID },
                    {"@TapeID", item.id },
                    {"@charge", item.rentalCharge}

                });
            }
            
            // Remove items from cart
            string deleteQuery = $"DELETE FROM Cart WHERE UID = {ApplicationForm.globalUID}";
            DatabaseManager.InsertData(deleteQuery, new Dictionary<string, object>
            {
                { "@UID", ApplicationForm.globalUID }
            });
            // Clear the cart items from the UI
            cartItemsPanel.Controls.Clear();
            totalLabel.Text = "Total: $0.00";
            // Show a message box to confirm checkout

            MessageBox.Show($"CheckedOut Successfully using: {SignUpForm.creditCardTemp}", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}