CREATE PROCEDURE [dbo].[GetOneColour]
	@Id int
AS
	SELECT * FROM Colours WHERE Colours.Id=@Id;
RETURN 0
