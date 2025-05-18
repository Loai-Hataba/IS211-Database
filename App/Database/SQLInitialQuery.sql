CREATE DATABASE MovieRentalDB;


-- MAKE SURE TO USE IT BEFORE ANYTHING
USE MovieRentalDB;

CREATE TABLE Genre (
  GenreID INT PRIMARY KEY IDENTITY(1,1),
  [Name] VARCHAR(75)
);

CREATE TABLE Supplier (
  SupplierID INT PRIMARY KEY IDENTITY(1,1),
  [Name] VARCHAR(75),
  ContactInfo VARCHAR(75)
);


CREATE TABLE Admin (
  AdminID INT PRIMARY KEY IDENTITY(1,1),
  [Name] VARCHAR(75),
  Email VARCHAR(75),
  PhoneNum CHAR(11),
  [Password] VARCHAR(20)
);


CREATE TABLE Actor (
  ActorID INT PRIMARY KEY IDENTITY(1,1),
  FirstName VARCHAR(75),
  LastName VARCHAR(75),
  Gender BIT,		
  Bio VARCHAR(500)
);

CREATE TABLE Customer (
  [UID] INT PRIMARY KEY IDENTITY(1,1),
  [Name] VARCHAR(75),
  Email VARCHAR(75),
  PhoneNum CHAR(11),
  [Address] VARCHAR(100),
  BusinessAddress VARCHAR(100),
  [Password] VARCHAR(20),
);


CREATE TABLE [Movie Tape] (
  TapeID INT PRIMARY KEY IDENTITY(1,1),
  Title VARCHAR(50),
  [Description] VARCHAR (500),
  ActorID INT,
  GenreID INT,
  RentalCharge FLOAT,
  ReleaseDate DATE,
  ImagePath VARCHAR(300),
  IsAvailable BIT,
  SupplierID INT,
  SupplyDate DATE DEFAULT CAST(GETDATE() AS DATE),
  FOREIGN KEY (ActorID) REFERENCES Actor(ActorID),
  FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID),
  FOREIGN KEY (GenreID) REFERENCES Genre(GenreID)
);


CREATE TABLE [Card] (
  LastFour VARCHAR(4),
  [UID] INT,
  CardType VARCHAR(75),
  [Status] VARCHAR(75),
  Token VARCHAR(75),
  PRIMARY KEY (LastFour, UID),
  FOREIGN KEY (UID) REFERENCES Customer (UID)
);

CREATE TABLE Rents (
  [UID] INT,
  TapeID INT,
  RentDate DATE,
  ReturnDate DATE,
  IsRented BIT,
  TotalCharge VARCHAR(100),
  PRIMARY KEY (UID, TapeID),
  FOREIGN KEY (UID) REFERENCES Customer (UID),
  FOREIGN KEY (TapeID) REFERENCES [Movie Tape](TapeID)
);

CREATE TABLE ActsIn (
  ActorID INT,
  TapeID INT,
  PRIMARY KEY (ActorID, TapeID),
  FOREIGN KEY (ActorID) REFERENCES Actor(ActorID),
  FOREIGN KEY (TapeID) REFERENCES [Movie Tape](TapeID)
);

CREATE TABLE Cart (
  CartID INT IDENTITY (1,1),
  UID INT,
  TapeID INT,
  PRIMARY KEY (CartID),
  FOREIGN KEY (UID) REFERENCES Customer(UID),
  FOREIGN KEY (TapeID) REFERENCES [Movie Tape](TapeID)
);




INSERT INTO [Movie Tape] ([Title], [Description], [ActorID], [GenreID], [RentalCharge], [ReleaseDate], [ImagePath], [IsAvailable], [supplierId])
VALUES 
('The Matrix', 'A computer hacker named Neo discovers the disturbing truth that the reality he lives in is actually a simulated world created by sentient machines to subdue the human population. After being contacted by a mysterious group of rebels, he joins their fight to break free from the Matrix and uncover the truth about his destiny as "The One." Together with Morpheus and Trinity, Neo learns to manipulate the digital world and takes a stand against the machine overlords.', 1, 1, 3.9, '1999-03-31', 'theMatrix.png', 0),
('Inception', 'Dom Cobb is a skilled thief with the rare ability to enter people''s dreams and steal their deepest secrets from their subconscious. His unique skill has made him a valuable asset in the world of corporate espionage, but it has also cost him everything he loves. When offered a chance to have his past crimes erased, he must pull off an impossible task: planting an idea in someone''s mind. As Cobb and his team dive deeper into layered dream worlds, the line between dream and reality begins to blur.', 2, 1, 4.50, '2010-07-16', 'inception.png', 1),
('The Godfather', 'In post-war America, Don Vito Corleone is the aging patriarch of a powerful Italian-American crime family. As he prepares to hand over his empire to his reluctant son Michael, a wave of betrayal and violence threatens to tear the family apart. Through cold calculations and brutal decisions, Michael transforms from an outsider to a ruthless mafia boss, securing the family''s legacy at great personal cost. The story explores power, loyalty, and the dark cost of ambition.', 3, 2, 3.50, '1972-03-24', 'theGodfather.png', 0),
('The Dark Knight', 'With Gotham City gripped by crime and fear, Batman continues his fight for justice alongside Lieutenant Gordon and District Attorney Harvey Dent. Their efforts seem to be working until a mysterious new criminal known as the Joker emerges, unleashing chaos and challenging everything Batman stands for. As the Joker manipulates events with cunning precision, Batman must confront moral dilemmas and personal sacrifice to stop a descent into anarchy.', 4, 1, 4.25, '2008-07-18', 'theDarkKnight.png', 1),
('Forrest Gump', 'Forrest Gump, a kind-hearted man with a low IQ, unintentionally influences major events in American history through his unwavering integrity and childlike optimism. From becoming a football star to serving in Vietnam and starting a shrimp business, Forrest touches countless lives along the way. Despite the chaos of the world around him, his devotion to his childhood love, Jenny, remains constant, reminding everyone of the power of innocence and perseverance.', 5, 3, 3.75, '1994-07-06', 'forrestGump.png', 1),
('Titanic', 'Aboard the luxurious Titanic''s maiden voyage, Jack, a poor artist, and Rose, a wealthy young woman trapped in a rigid upper-class life, find love against all odds. As they defy social expectations and forge a deep connection, tragedy strikes when the "unsinkable" ship hits an iceberg. Amid the chaos, their love story becomes a tale of passion, sacrifice, and the enduring human spirit in the face of disaster.', 6, 4, 4.00, '1997-12-19', 'titanic.png', 0),
('Pulp Fiction', 'Told in a nonlinear fashion, Pulp Fiction weaves together multiple interrelated stories involving hitmen, boxers, gangsters, and a mysterious briefcase. Vincent Vega and Jules Winnfield carry out mob duties while discussing philosophy, a boxer named Butch double-crosses a crime boss, and unexpected events unfold with dark humor and shocking violence. Quentin Tarantino''s signature style blends gritty realism with sharp dialogue in this cult classic.', 7, 2, 3.95, '1994-10-14', 'pulpFiction.png', 1),
('The Avengers', 'When the powerful trickster god Loki threatens Earth with an alien invasion, Nick Fury assembles a team of extraordinary individuals: Iron Man, Captain America, Thor, Hulk, Black Widow, and Hawkeye to save the planet. Though their personalities clash, the heroes must overcome their differences and learn to work together to prevent global destruction. With breathtaking battles and teamwork, they emerge as Earth''s mightiest heroes.', 8, 5, 4.99, '2012-05-04', 'avengers.png', 1),
('Jurassic Park', 'Billionaire John Hammond creates a revolutionary theme park filled with living, cloned dinosaurs on a remote island. When a group of scientists and children are invited to preview the park, a security failure unleashes the deadly creatures. As chaos erupts, the visitors must use their wits to survive. Jurassic Park is a thrilling blend of science fiction, adventure, and cautionary tale about the dangers of tampering with nature.', 9, 6, 3.99, '1993-06-11', 'jurassicPark.png', 1),
('The Lion King', 'In the African savannah, young lion Simba is destined to become king, but tragedy strikes when his father Mufasa is killed in a treacherous plot by his uncle Scar. Fleeing his past, Simba grows up in exile, learning life lessons from new friends. When the kingdom falls into ruin under Scar''s rule, Simba must confront his destiny, reclaim his rightful place, and bring balance back to the Pride Lands.', 10, 7, 3.25, '1994-06-24', 'lionKing.png', 1),
('Interstellar', 'In a future where Earth is dying, former pilot Cooper is recruited by a secret NASA mission to travel through a wormhole in search of a habitable planet for humanity. Leaving his children behind, he embarks on a journey across space and time, encountering mind-bending phenomena and emotional challenges. As the crew races against time, they discover the true power of love and sacrifice in humanity''s last hope for survival.', 4, 1, 4.75, '2014-11-07', 'interstellar.png', 1),
('Gladiator', 'Maximus, a respected Roman general, is betrayed when the corrupt Commodus seizes power and murders his family. Forced into slavery and the brutal world of gladiatorial combat, Maximus rises as a champion of the arena. Driven by vengeance and honor, he fights to bring justice to Rome and to restore the republic. His journey becomes a symbol of resistance against tyranny and the enduring strength of the human spirit.', 5, 2, 3.80, '2000-05-05', 'gladiator.png', 1),
('The Shawshank Redemption', 'Andy Dufresne, a banker wrongfully convicted of murder, is sentenced to life in the brutal Shawshank prison. Over decades, he maintains hope and builds a quiet legacy by transforming the prison and forming a deep friendship with fellow inmate Red. Through patience, ingenuity, and a secret plan, Andy orchestrates one of the most daring escapes in cinematic history, proving that hope can set a man free.', 6, 3, 3.90, '1994-09-23', 'shawshank.png', 1),
('Avatar', 'Jake Sully, a paraplegic marine, is sent to the alien world of Pandora to infiltrate the native Navi using an avatar body. As he gains their trust and learns their ways, he finds himself torn between his duty to the military and his bond with the Navi. When the humans threaten the peaceful world for resources, Jake must choose where his true allegiance lies. The film explores themes of identity, nature, and resistance.', 4, 6, 4.60, '2009-12-18', 'avatar.png', 0),
('The Social Network', 'In the early 2000s, Harvard student Mark Zuckerberg develops a new social networking platform that would become Facebook. As the site skyrockets in popularity, conflicts arise with friends and collaborators over ownership and intellectual rights. The film chronicles the legal battles and personal fallout that follow, offering a gripping portrayal of ambition, genius, and betrayal in the digital age.', 5, 3, 3.70, '2010-10-01', 'socialNetwork.png', 1),
('Fight Club', 'A disillusioned office worker suffering from insomnia finds solace in underground fight clubs formed with the charismatic and anarchistic Tyler Durden. As their movement grows into a dangerous cult, the man''s grasp on reality begins to unravel. The film explores themes of masculinity, consumerism, and psychological instability in a twisted journey toward self-destruction and discovery.', 1, 2, 3.85, '1999-10-15', 'fightClub.png', 1),
('The Silence of the Lambs', 'FBI trainee Clarice Starling seeks the aid of imprisoned cannibalistic psychiatrist Dr. Hannibal Lecter to catch a serial killer known as Buffalo Bill. As Lecter toys with her mind, Clarice must confront her own past while navigating a terrifying investigation. The psychological tension builds as the cat-and-mouse game between hunter and hunted reaches a chilling climax.', 1, 8, 3.65, '1991-02-14', 'silenceLambs.png', 1),
('Coco', 'Young Miguel dreams of becoming a musician, despite his family''s ancestral ban on music. On Da de los Muertos, he finds himself magically transported to the Land of the Dead, where he searches for his great-great-grandfather, a legendary singer. Along the way, he uncovers family secrets and learns the importance of remembrance, love, and following one''s passion. Coco celebrates heritage with heartwarming visuals and powerful music.', 2, 7, 3.55, '2017-11-22', 'coco.png', 1),
('Up', 'Carl Fredricksen, a widowed balloon salesman, ties thousands of balloons to his house and sets off for South America to fulfill a lifelong dream. Along the way, he is joined by an eager young scout named Russell. Their journey is filled with unexpected challenges, colorful characters, and lessons about adventure, friendship, and letting go of the past. "Up" delivers emotional depth and lighthearted fun.', 3, 7, 3.40, '2009-05-29', 'up.png', 1),
('John Wick', 'John Wick, a legendary assassin in retirement, is pulled back into the criminal underworld after a group of gangsters kill his beloved doga final gift from his late wife. Fueled by vengeance and grief, he unleashes his lethal skills on those who wronged him. With a relentless drive and unmatched precision, John wages a one-man war, redefining modern action cinema with its stylized combat and dark emotional core.', 7, 5, 4.20, '2014-10-24', 'johnWick.png', 1);


-- Seed initial genres
INSERT INTO Genre ([Name]) VALUES
('Action'),
('Drama'),
('Comedy'),
('Romance'),
('Thriller'),
('Science Fiction'),
('Fantasy'),
('Horror'),
('Documentary'),
('Animation');


-- seed intial actors
INSERT INTO Actor (FirstName, LastName, Bio, Gender) Values
('Keanu', 'Reeves', 'Canadian actor known for action roles and philosophical characters, especially in "The Matrix" and "John Wick" series.', 1),
('Leonardo', 'DiCaprio', 'Oscar-winning American actor known for intense roles in films like "Inception", "Titanic", and "The Revenant".', 1),
('Marlon', 'Brando', 'Legendary American actor acclaimed for his method acting, with iconic roles in "The Godfather" and "A Streetcar Named Desire".', 1),
('Christian', 'Bale', 'Versatile British actor known for physically transformative roles including Batman and American Psycho.', 1),
('Tom', 'Hanks', 'Beloved American actor with a warm on-screen presence, known for roles in "Forrest Gump", "Cast Away", and "Saving Private Ryan".', 1),
('Kate', 'Winslet', 'British actress renowned for her work in period dramas and modern classics like "Titanic" and "The Reader".', 0),
('John', 'Travolta', 'American actor and dancer who rose to fame in the 70s and revived his career with "Pulp Fiction".', 1),
('Robert', 'Downey', 'Charismatic American actor best known for his role as Iron Man in the Marvel Cinematic Universe.', 1),
('Sam', 'Neill', 'New Zealand actor best known for his role as Dr. Alan Grant in "Jurassic Park".', 1),
('Matthew', 'Broderick', 'American actor and singer, known for voice acting Simba in "The Lion King" and his iconic role in "Ferris Bueller’s Day Off".', 1),
('Matthew', 'McConaughey', 'Academy Award-winning American actor celebrated for both romantic comedies and dramatic roles like in "Interstellar".', 1),
('Russell', 'Crowe', 'New Zealand-born Australian actor best known for his Oscar-winning performance in "Gladiator".', 1),
('Tim', 'Robbins', 'American actor and director known for socially conscious films and his powerful role in "The Shawshank Redemption".', 1),
('Sam', 'Worthington', 'Australian actor known for leading roles in sci-fi blockbusters like "Avatar" and "Clash of the Titans".', 1),
('Jesse', 'Eisenberg', 'American actor known for playing intellectual, often neurotic characters like Mark Zuckerberg in "The Social Network".', 1),
('Edward', 'Norton', 'Critically acclaimed American actor known for intense performances in films like "Fight Club" and "American History X".', 1),
('Jodie', 'Foster', 'Two-time Oscar-winning American actress known for intelligent, strong-willed roles including "The Silence of the Lambs".', 0),
('Anthony', 'Gonzalez', 'Young American voice actor and singer best known for voicing Miguel in Pixar’s "Coco".', 1),
('Ed', 'Asner', 'Veteran American actor and voice artist known for playing Carl in "Up" and for his Emmy-winning TV roles.', 1);


Insert INTO Supplier ([name], ContactInfo) Values
('Legendary Pictures', 'info@legendary.com'),
('Warner Bros.', 'contact@warnerbros.com'),
('Miramax Films', 'contact@miramax.com'),
('Marvel Studios', 'support@marvelstudios.com'),
('Universal Pictures', 'info@universalpictures.com'),
('Walt Disney Pictures', 'contact@disney.com'),
('Paramount Pictures', 'info@paramount.com'),
('DreamWorks Pictures', 'contact@dreamworks.com'),
('Columbia Pictures', 'legal@columbiapictures.com'),
('20th Century Fox', 'press@fox.com'),
('Orion Pictures', 'info@orionpictures.com'),
('Pixar Animation Studios', 'contact@pixar.com'),
('Summit Entertainment', 'info@summitent.com')