CREATE PROCEDURE [dbo].[GetCurrencyByCountry]
	@countryCode nvarchar(3)
AS
	SELECT * FROM Currencies WHERE CountryCode = @countryCode;
RETURN 0
