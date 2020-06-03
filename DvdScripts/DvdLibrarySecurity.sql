--DvdLibrarySecurity.sql – Should create an application account.
USE DvdLibrary
GO
 
--Create a server login 
CREATE LOGIN DvdLibraryApp WITH PASSWORD='Testing123'
GO

--Create a database account
CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

/* CREATE A NEW ROLE */
CREATE ROLE db_executor
 
/* GRANT EXECUTE TO THE ROLE */
GRANT EXECUTE TO db_executor
 
/* ADD THE USER TO THE ROLE */
ALTER ROLE db_executor ADD MEMBER DvdLibraryApp

--Grant Execute on all used stored procedures to ‘DvdLibrary’
GRANT EXECUTE ON DvdsSelectAll TO DvdLibraryApp
GRANT EXECUTE ON DvdsSelect TO DvdLibraryApp
GRANT EXECUTE ON DvdsInsert TO DvdLibraryApp
GRANT EXECUTE ON DvdsUpdate TO DvdLibraryApp
GRANT EXECUTE ON DvdsDelete TO DvdLibraryApp
GO


GRANT SELECT ON Dvds TO DvdLibraryApp
GRANT INSERT ON Dvds TO DvdLibraryApp
GRANT UPDATE ON Dvds TO DvdLibraryApp
GRANT DELETE ON Dvds TO DvdLibraryApp
GO

