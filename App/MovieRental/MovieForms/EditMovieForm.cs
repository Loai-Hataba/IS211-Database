namespace MovieRental.MovieForms
{
    public class EditMovieForm : MovieForm
    {
        public List<genreItem> genreList;
        public List<Actor> actorsList;
        public EditMovieForm(movieItem movie) : base("Edit Movie")
        {
            Movie = movie;
            genreList = loadGenres();
            actorsList = loadActors();
            // Populate genreComboBox
            genreComboBox.DataSource = genreList;
            genreComboBox.DisplayMember = "title"; // property to display
            genreComboBox.ValueMember = "id";      // property to use as value

            // Populate actorComboBox
            actorComboBox.DataSource = actorsList;
            actorComboBox.DisplayMember = "fullName"; // or combine firstName + lastName if you want
            actorComboBox.ValueMember = "actorId";
            PopulateFields();
        }

        public List<genreItem> loadGenres()
        {
            string genresQuery = "SELECT * FROM Genre";
            List<genreItem> genresList = DatabaseManager.FetchData(genresQuery, reader => new genreItem
            {
                id = reader.GetInt32(0),
                title = reader.GetString(1)
            });
            return genresList;
        }
        public List<Actor> loadActors()
        {
            string actorsQuery = "SELECT * FROM Actor";
            List<Actor> actorsList = DatabaseManager.FetchData(actorsQuery, reader => new Actor
            {
                actorId = reader.GetInt32(0),
                firstName = reader.GetString(1),
                lastName = reader.GetString(2),
                gender = reader.GetBoolean(3),
                bio = reader.GetString(4)
            });
            return actorsList;
        }

        private void PopulateFields()
        {
            titleTextBox.Text = Movie.title;
            descriptionTextBox.Text = Movie.description;
            priceTextBox.Text = Movie.rentalCharge.ToString();
            releaseDatePicker.Value = Movie.releaseDate;
            imagePathTextBox.Text = Movie.imagePath;
            genreComboBox.SelectedValue = Movie.genreId;
            actorComboBox.SelectedValue = Movie.actorId;

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

           string query = @"UPDATE [Movie Tape]
                            SET 
                            Title = @title,
                            [Description] = @description,
                            ActorID = @actorId,
                            GenreID = @genreId,
                            RentalCharge =@price,
                            ReleaseDate =@releaseDate,
                            ImagePath =@imagePath,
                            IsAvailable =@isAvailable
                            WHERE TapeID = @tapeId;";
            string title = titleTextBox.Text;
            string description = descriptionTextBox.Text;
            var selectedActor = actorComboBox.SelectedItem as Actor;
            int actorId = selectedActor?.actorId ?? 0;
            var selectedGenre = genreComboBox.SelectedItem as genreItem;
            int genreId = selectedGenre?.id ?? 0;
            double price = double.Parse(priceTextBox.Text);
            DateTime releaseDate = releaseDatePicker.Value;
            string imagePath = imagePathTextBox.Text;
            bool isAvailable = true;
            var parameters = new Dictionary<string, object>
            {
                {@"title", title},
                {"@description", description},
                { @"actorId", actorId},
                {@"genreId", genreId},
                {@"price", price},
                {@"releaseDate", releaseDate},
                {@"imagePath", imagePath},
                {"@isAvailable", isAvailable},
                {"@tapeId", Movie.id}
            };
            DatabaseManager.InsertData(query, parameters);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
