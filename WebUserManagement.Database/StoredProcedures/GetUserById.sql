CREATE PROCEDURE [dbo].[GetUserById]
	@Id BIGINT
AS
BEGIN
	SELECT Id, LastName, FirstName, Email FROM Users
	WHERE Id = @Id
END