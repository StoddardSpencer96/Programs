CREATE PROCEDURE [dbo].[UpdateColour]
	@Id int,
	@Name nvarchar(25)
AS
	UPDATE Colours SET [Name] = @Name WHERE Id = @Id;
RETURN 0
