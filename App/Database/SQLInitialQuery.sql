CREATE DATABASE MovieRentalDB;

USE MovieRentalDB;


-- Create the Genres table
CREATE TABLE Genres (
    GenreID INT PRIMARY KEY IDENTITY(1,1),
    GenreName NVARCHAR(100) NOT NULL
);

CREATE TABLE [Supplier] (
  [SupplierID] INT PRIMARY KEY IDENTITY(1,1),
  [Name] VARCHAR(75),
  [ContactInfo] VARCHAR (75)
);

SELECT * FROM Genres;

-- Seed initial genres
INSERT INTO Genres (GenreName) VALUES
('Action'),
('Comedy'),
('Drama'),
('Horror'),
('Romance'),
('Sci-Fi'),
('Thriller');

-- Seed initial genres
INSERT INTO Supplier ([Name], ContactInfo) VALUES
('koko & s', '01275397858'),
('hamada balto', '4546845'),
('baba we mama', 'sfsfsf'),
('testingoo', '45468123854');

Select * from Supplier;

INSERT INTO Genres (GenreName) VALUES ('koki');

drop table [Movie Tape];

CREATE TABLE [Movie Tape] (
  [TapeId] INT PRIMARY KEY IDENTITY(1,1),
  [Title] VarChar(75),
  [ActorID] INT,
  [GenreID] INT,
  [RentalCharge] FLOAT,
  [ReleaseDate] Date,
  [ImagePath] VARCHAR (200)
);


INSERT INTO [Movie Tape] ([Title], [ActorID], [GenreID], [RentalCharge], [ReleaseDate], [ImagePath])
VALUES 
('The Matrix', 101, 1, 3.9, '1999-03-31', 'theMatrix.png'),
('Inception', 102, 1, 4.50, '2010-07-16', 'inception.png'),
('The Godfather', 103, 2, 3.50, '1972-03-24', 'theGodfather.png'),
('The Dark Knight', 104, 1, 4.25, '2008-07-18', 'theDarkKnight.png'),
('Forrest Gump', 105, 3, 3.75, '1994-07-06', 'forrestGump.png'),
('Titanic', 106, 4, 4.00, '1997-12-19', 'titanic.png'),
('Pulp Fiction', 107, 2, 3.95, '1994-10-14', 'pulpFiction.png'),
('The Avengers', 108, 5, 4.99, '2012-05-04', 'avengers.png'),
('Jurassic Park', 109, 6,3.99, '1993-06-11', 'jurassicPark.png'),
('The Lion King', 110, 7, 3.25, '1994-06-24', 'lionKing.png');


select * from [Movie Tape];

ALTER TABLE [movie tape] add ImagePath VARCHAR(100);

