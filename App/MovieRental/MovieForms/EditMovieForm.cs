namespace MovieRental.MovieForms
{
    public class EditMovieForm : MovieForm
    {
        public EditMovieForm(movieItem movie) : base("Edit Movie")
        {
            Movie = movie;
            LoadGenresAndActors();
            PopulateFields();
        }

        private void LoadGenresAndActors()
        {
            // TODO: Load genres from database
            string genresQuery = "SELECT * FROM Genre";
            // TODO: Load actors from database
            string actorsQuery = "SELECT * FROM Actor";
        }

        private void PopulateFields()
        {
            titleTextBox.Text = Movie.title;
            priceTextBox.Text = Movie.rentalCharge.ToString();
            releaseDatePicker.Value = Movie.releaseDate;
            imagePathTextBox.Text = Movie.imagePath;
            
            // TODO: Set selected genre and actor based on IDs
            // genreComboBox.SelectedValue = Movie.genreId;
            // actorComboBox.SelectedValue = Movie.actorId;

            if (!string.IsNullOrEmpty(Movie.imagePath))
            {
                try
                {
                    previewImage.Image = Image.FromFile(Movie.imagePath);
                }
                catch { }
            }
        }

        protected override void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            // TODO: Update movie in database
            string query = @"UPDATE [Movie Tape] 
                           SET Title = @title, 
                               ActorId = @actorId, 
                               GenreId = @genreId, 
                               RentalCharge = @price, 
                               ReleaseDate = @releaseDate, 
                               ImagePath = @imagePath
                           WHERE Id = @id";

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}