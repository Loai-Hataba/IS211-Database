using System;
using System.Windows.Forms;
using System.Drawing;

namespace MovieRental.MovieForms
{
    public class MovieForm : Form
    {
        protected TextBox titleTextBox;
        protected TextBox descriptionTextBox;
        protected ComboBox genreComboBox;
        protected ComboBox actorComboBox;
        protected TextBox priceTextBox;
        protected DateTimePicker releaseDatePicker;
        protected TextBox imagePathTextBox;
        protected Button browseButton;
        protected Button saveButton;
        protected Button cancelButton;
        protected PictureBox previewImage;
        protected movieItem Movie { get; set; }
        public MovieForm(string title)
        {
            InitializeComponent();
            this.Text = title;
                        
            // Prevent form resizing and maximizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void InitializeComponent()
        {
            this.Size = new Size(600, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(44, 62, 80);
            this.ForeColor = Color.WhiteSmoke;
            
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                RowCount = 9,
                ColumnCount = 2
            };

            // Add controls
            AddFormField(mainLayout, "Title:", titleTextBox = new TextBox(), 0);
            AddFormField(mainLayout, "Description:", descriptionTextBox = new TextBox(), 1);
            AddFormField(mainLayout, "Genre:", genreComboBox = new ComboBox(), 2);
            AddFormField(mainLayout, "Actor:", actorComboBox = new ComboBox(), 3);
            AddFormField(mainLayout, "Price:", priceTextBox = new TextBox(), 4);
            // Image path row (row 5)
            Panel imagePathPanel = new Panel { Dock = DockStyle.Fill, Height = 30 };
            imagePathTextBox = new TextBox { Width = 300, Location = new Point(0, 0) };
            browseButton = new Button
            {
                Text = "Browse",
                Location = new Point(310, 0),
                BackColor = Color.FromArgb(52, 152, 219),
                Size = new Size(80, 25)
            };
            browseButton.Click += BrowseButton_Click;
            imagePathPanel.Controls.AddRange(new Control[] { imagePathTextBox, browseButton });
            AddFormField(mainLayout, "Image Path:", imagePathPanel, 5);
            // Release date row (row 6)
            AddFormField(mainLayout, "Release Date:", releaseDatePicker = new DateTimePicker(), 6);

            // Preview image (row 7)
            previewImage = new PictureBox
            {
                Size = new Size(200, 300),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(34, 49, 63)
            };
            mainLayout.Controls.Add(previewImage, 1, 7);

            // Buttons panel (row 8)
            FlowLayoutPanel buttonsPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill
            };
            saveButton = new Button
            {
                Text = "Save",
                BackColor = Color.FromArgb(46, 204, 113),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 40)
            };
            saveButton.Click += SaveButton_Click;
            cancelButton = new Button
            {
                Text = "Cancel",
                BackColor = Color.FromArgb(231, 76, 60),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 40)
            };
            cancelButton.Click += (s, e) => this.Close();
            buttonsPanel.Controls.AddRange(new Control[] { cancelButton, saveButton });
            mainLayout.Controls.Add(buttonsPanel, 1, 8);

            this.Controls.Add(mainLayout);

            // Style controls
            foreach (Control control in mainLayout.Controls)
            {
                if (control is TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(52, 73, 94);
                    txt.ForeColor = Color.WhiteSmoke;
                }
                else if (control is ComboBox cmb)
                {
                    cmb.BackColor = Color.FromArgb(52, 73, 94);
                    cmb.ForeColor = Color.WhiteSmoke;
                }
                else if (control is DateTimePicker dtp)
                {
                    dtp.CalendarMonthBackground = Color.FromArgb(52, 73, 94);
                    dtp.CalendarForeColor = Color.WhiteSmoke;
                }
            }
        }

        private void AddFormField(TableLayoutPanel layout, string labelText, Control control, int row)
        {
            Label label = new Label
            {
                Text = labelText,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight
            };
            layout.Controls.Add(label, 0, row);
            layout.Controls.Add(control, 1, row);
        }

        protected virtual void BrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePathTextBox.Text = dialog.FileName;
                    try
                    {
                        previewImage.Image = Image.FromFile(dialog.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Failed to load image preview.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        protected virtual void SaveButton_Click(object sender, EventArgs e)
        {
            // To be implemented by derived classes
        }

        protected bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                MessageBox.Show("Please enter a title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (genreComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a genre.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (actorComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an actor.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(priceTextBox.Text, out _))
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(imagePathTextBox.Text))
            {
                MessageBox.Show("Please select an image.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}