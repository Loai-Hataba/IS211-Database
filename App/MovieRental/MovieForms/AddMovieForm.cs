namespace MovieRental.MovieForms
{
    public class AddMovieForm : MovieForm
    {
        public AddMovieForm() : base("Add New Movie")
        {
            LoadGenresAndActors();
        }

        private void LoadGenresAndActors()
        {
            // TODO: Load genres from database
            string genresQuery = "SELECT * FROM Genre";
            // TODO: Load actors from database
            string actorsQuery = "SELECT * FROM Actor";
        }

        protected override void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            // TODO: Insert new movie into database
            string query = @"INSERT INTO [Movie Tape] (Title, ActorId, GenreId, RentalCharge, ReleaseDate, ImagePath) 
                           VALUES (@title, @actorId, @genreId, @price, @releaseDate, @imagePath)";

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}