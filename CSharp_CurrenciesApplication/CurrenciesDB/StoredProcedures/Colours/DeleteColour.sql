CREATE PROCEDURE [dbo].[DeleteColour]
	@Id int
AS
	DELETE FROM Colours WHERE Id = @Id;
RETURN @@rowcount
