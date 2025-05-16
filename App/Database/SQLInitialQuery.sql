CREATE DATABASE MovieRentalDB
ON PRIMARY (
    NAME = MovieRental_Data,
    FILENAME = 'D:\Programming\SQL\IS211-Database\App\Database\MovieRental.mdf'
	-- put the database folder path 
)
LOG ON (
    NAME = MovieRental_Log,
    FILENAME = 'D:\Programming\SQL\IS211-Database\App\Database\MovieRental.ldf'
	-- put the database folder path 
);


USE MovieRentalDB;


-- Create the Genres table
CREATE TABLE Genres (
    GenreID INT PRIMARY KEY IDENTITY(1,1),
    GenreName NVARCHAR(100) NOT NULL
);

-- Seed initial genres
INSERT INTO Genres (GenreName) VALUES
('Action'),
('Comedy'),
('Drama'),
('Horror'),
('Romance'),
('Sci-Fi'),
('Thriller');

Select * from Genres;

INSERT INTO Genres (GenreName) VALUES ('koki');