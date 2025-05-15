using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRental
{
    public partial class Movies : Form
    {
        public Movies()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPage(new ucMovies());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadPage(UserControl page)
        {
            panel1.Controls.Clear();         // Remove existing content
            page.Dock = DockStyle.Fill;        // Make it fill the panel
            panel1.Controls.Add(page);       // Add the new control
        }

    }
}
