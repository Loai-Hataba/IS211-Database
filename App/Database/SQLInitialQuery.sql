CREATE DATABASE MovieRentalDB;

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