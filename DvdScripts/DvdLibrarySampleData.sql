--DvdLibrarySampleData.sql – Should create sample data

USE DvdLibrary
GO

--DELETE FROM Dvds;

INSERT INTO Dvds (Title, ReleaseYear, Director, Rating, Notes)
VALUES ('Harry Potter', 2002, 'J.K Rowling', 'PG-13', 'Amazing movie!'),
('Indiana Jones', 2003, 'Peter Smith', 'PG-13', 'Funny movie!'),
('Batman', 2005, 'John Holmes', 'PG-13', 'Cool movie!'),
('Superman', 2009, 'Mike Cooks', 'PG-13', 'What a hero!')
