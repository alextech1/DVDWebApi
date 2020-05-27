--DvdLibrarySprocs.sql – Should create the stored procedures.
USE DvdLibrary

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsSelectAll')
		DROP PROC DvdsSelectAll
GO

CREATE PROC DvdsSelectAll AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsSelect')
		DROP PROC DvdsSelectAll
GO

CREATE PROC DvdsSelect (
	@DvdId int
) AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds
	WHERE DvdId = @DvdId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsInsert')
		DROP PROC DvdsInsert
GO

CREATE PROC DvdsInsert (
	@DvdId int output,
	@Title varchar(30),
	@ReleaseYear int,
	@Director varchar(30),
	@Rating varchar(10),
	@Notes varchar(50)
) AS
BEGIN

	INSERT INTO Dvds (Title, ReleaseYear, Director, Rating, Notes)
	VALUES (@Title, @ReleaseYear, @Director, @Rating, @Notes);

	SET @DvdId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsUpdate')
		DROP PROC DvdsUpdate
GO

CREATE PROC DvdsUpdate (
	@DvdId int,
	@Title varchar(30),
	@ReleaseYear int,
	@Director varchar(30),
	@Rating varchar(10),
	@Notes varchar(50)
) AS 
BEGIN
	UPDATE Dvds SET
		Title = @Title,
		ReleaseYear = @ReleaseYear,
		Director = @Director,
		Rating = @Rating,
		Notes = @Notes
	WHERE DvdId = @DvdId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsDelete')
		DROP PROC DvdsSelectAll
GO

CREATE PROC DvdsDelete (
	@DvdId int
) AS 
BEGIN 
	BEGIN TRANSACTION

	DELETE FROM Dvds WHERE DvdId = @DvdId;

	COMMIT TRANSACTION
END
GO
