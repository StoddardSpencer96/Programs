CREATE PROCEDURE [dbo].[GetOneCurrency]
	@Id int
AS
	SELECT * FROM Currencies WHERE Currencies.Id = @Id;
RETURN 0
