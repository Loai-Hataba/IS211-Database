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

        public List<genreItem> loadGenres()
        {
            string query = "Select * from Genres;";
            return DatabaseManager.FetchData(query, reader => new genreItem
            {
                id = reader.GetInt32(0),
                title = reader.GetString(1),
                // description = reader.GetString(2)
            });
        }
    }
}
