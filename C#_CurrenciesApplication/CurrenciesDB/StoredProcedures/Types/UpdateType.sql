CREATE PROCEDURE [dbo].[UpdateType]
	@Id int,
	@Name nvarchar(100)
AS
	UPDATE Types SET Name = @Name WHERE Id = @Id;
RETURN 0
