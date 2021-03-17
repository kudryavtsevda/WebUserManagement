CREATE PROCEDURE [dbo].[AddUser]
	@LastName nvarchar(max)
	,@FirstName nvarchar(max)
	,@Email nvarchar(max)	
AS
BEGIN
	INSERT INTO [dbo].[Users]
           ([LastName]
           ,[FirstName]
           ,[Email])
     VALUES
           (@LastName
           ,@FirstName
           ,@Email)

	SELECT SCOPE_IDENTITY() AS Id    
END