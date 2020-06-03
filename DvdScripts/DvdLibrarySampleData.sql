--DvdLibrarySampleData.sql – Should create sample data

USE DvdLibrary
GO

--DELETE FROM Dvds;

INSERT INTO Dvds (Title, ReleaseYear, Director, Rating, Notes, ImageFileName)
VALUES ('Harry Potter', 2002, 'J.K Rowling', 'PG-13', 'Amazing movie!', 'dvd2.png'),
('Indiana Jones', 2003, 'Peter Smith', 'PG-13', 'Funny movie!', 'dvd2.png'),
('Batman', 2005, 'John Holmes', 'PG-13', 'Cool movie!', 'dvd2.png'),
('Superman', 2009, 'Mike Cooks', 'PG-13', 'What a hero!', 'dvd2.png');
