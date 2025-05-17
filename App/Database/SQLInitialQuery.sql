CREATE DATABASE MovieRentalDB;

-- MAKE SURE TO USE IT BEFORE ANYTHING
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
  [Description] VARCHAR(300),
  [ActorID] INT,
  [GenreID] INT,
  [RentalCharge] FLOAT,
  [ReleaseDate] Date,
  [ImagePath] VARCHAR (200),
  [IsAvailable] BIT
);


INSERT INTO [Movie Tape] ([Title], [Description], [ActorID], [GenreID], [RentalCharge], [ReleaseDate], [ImagePath], [IsAvailable])
VALUES 
('The Matrix', 'A hacker discovers the shocking truth about reality and joins a rebellion against intelligent machines.', 101, 1, 3.9, '1999-03-31', 'theMatrix.png', 0),
('Inception', 'A skilled thief enters people''s dreams to steal secrets and plant ideas, blurring reality and illusion.', 102, 1, 4.50, '2010-07-16', 'inception.png', 1),
('The Godfather', 'An aging patriarch transfers control of his crime dynasty to his reluctant son.', 103, 2, 3.50, '1972-03-24', 'theGodfather.png', 0),
('The Dark Knight', 'Batman battles the Joker, who seeks to create chaos and challenge the limits of justice.', 104, 1, 4.25, '2008-07-18', 'theDarkKnight.png', 1),
('Forrest Gump', 'The life journey of a simple man who influences major historical events with kindness and persistence.', 105, 3, 3.75, '1994-07-06', 'forrestGump.png', 1),
('Titanic', 'A romance blossoms aboard the ill-fated Titanic between a wealthy woman and a poor artist.', 106, 4, 4.00, '1997-12-19', 'titanic.png', 0),
('Pulp Fiction', 'Interwoven tales of crime, redemption, and dark humor set in Los Angeles.', 107, 2, 3.95, '1994-10-14', 'pulpFiction.png', 1),
('The Avengers', 'Earth''s mightiest heroes unite to stop a global threat led by Loki.', 108, 5, 4.99, '2012-05-04', 'avengers.png', 1),
('Jurassic Park', 'A theme park with cloned dinosaurs faces disaster when security fails.', 109, 6, 3.99, '1993-06-11', 'jurassicPark.png', 1),
('The Lion King', 'A young lion prince flees his kingdom after his father''s death and learns the meaning of responsibility.', 110, 7, 3.25, '1994-06-24', 'lionKing.png', 1),
('Interstellar', 'A team of explorers travels through a wormhole to find a new home for humanity.', 111, 1, 4.75, '2014-11-07', 'interstellar.png', 1),
('Gladiator', 'A betrayed Roman general seeks revenge and fights his way back through the arena.', 112, 2, 3.80, '2000-05-05', 'gladiator.png', 1),
('The Shawshank Redemption', 'A banker wrongly imprisoned for murder forms a powerful bond with a fellow inmate.', 113, 3, 3.90, '1994-09-23', 'shawshank.png', 1),
('Avatar', 'A paraplegic marine joins an alien world and becomes torn between two worlds.', 114, 6, 4.60, '2009-12-18', 'avatar.png', 0),
('The Social Network', 'The story of Facebook''s controversial rise and the battles over ownership.', 115, 3, 3.70, '2010-10-01', 'socialNetwork.png', 1),
('Fight Club', 'An office worker creates an underground fight club that spirals out of control.', 116, 2, 3.85, '1999-10-15', 'fightClub.png', 1),
('The Silence of the Lambs', 'An FBI trainee seeks the help of a brilliant but insane cannibal to catch a serial killer.', 117, 8, 3.65, '1991-02-14', 'silenceLambs.png', 1),
('Coco', 'A young boy dreams of becoming a musician and travels to the Land of the Dead.', 118, 7, 3.55, '2017-11-22', 'coco.png', 1),
('Up', 'An old man fulfills his dream of adventure by tying balloons to his house and flying to South America.', 119, 7, 3.40, '2009-05-29', 'up.png', 1),
('John Wick', 'A retired hitman seeks vengeance after gangsters kill his beloved dog.', 120, 5, 4.20, '2014-10-24', 'johnWick.png', 1);



select * from [Movie Tape];
