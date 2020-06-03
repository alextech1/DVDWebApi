--DvdLibraryCreate.sql – Should create the database and its tables
USE DvdLibrary
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvds')
	DROP TABLE Dvds
GO

CREATE TABLE Dvds (
	DvdId int identity(1,1) primary key,
	Title varchar(30) not null,
	ReleaseYear int not null,
	Director varchar(30) not null,
	Rating varchar(10) not null,
	Notes varchar(50) not null,
	ImageFileName varchar(60)
)