CREATE PROCEDURE [dbo].[GetCurrencyByColor]
	@colourId INT
AS
	SELECT * FROM Currencies WHERE ColourId = @colourId;
RETURN 0
