CREATE PROCEDURE [dbo].[GetOneCountry]
	@CountryCode nvarchar(3)
AS
	SELECT * FROM Countries WHERE Countries.CountryCode = @CountryCode;
RETURN 0
