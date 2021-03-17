CREATE PROCEDURE [dbo].[UpdateUser]
	@Id BIGINT,
	@LastName NVARCHAR(max)
	,@FirstName NVARCHAR(max)
	,@Email NVARCHAR(max)	
AS
BEGIN
	UPDATE Users 
	SET LastName=@LastName,
		FirstName=@FirstName,
		Email=@Email
	WHERE Id=@Id
END