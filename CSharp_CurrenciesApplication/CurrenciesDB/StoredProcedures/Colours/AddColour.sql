CREATE PROCEDURE [dbo].[AddColour]	
	@Name nvarchar(25),
	@newIdentity INT OUTPUT
AS
	INSERT INTO Colours ([Name]) VALUES (@Name);
	SET @newIdentity = SCOPE_IDENTITY();

RETURN 0
