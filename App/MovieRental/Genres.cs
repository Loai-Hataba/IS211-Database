using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRental
{
    public partial class Genres : UserControl
    {
        public Genres()
        {
            InitializeComponent();
        }

        public void loadGenres()
        {
            MessageBox.Show("walad!!");
            string sql = "SELECT * FROM Genres";
            DataTable genresTable = DatabaseManager.FetchData(sql);
            genresDataGrid.DataSource = genresTable;
        }
    }
}
