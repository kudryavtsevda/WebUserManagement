CREATE PROCEDURE [dbo].[GetAllUsers] 	
AS
BEGIN
	SELECT Id,LastName,FirstName,Email FROM Users
END