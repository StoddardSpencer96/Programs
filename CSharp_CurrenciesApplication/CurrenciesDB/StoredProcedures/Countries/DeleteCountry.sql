CREATE PROCEDURE [dbo].[DeleteCountry]
	@CountryCode nvarchar(3)
AS
	DELETE FROM Countries WHERE CountryCode = @CountryCode;
RETURN @@rowcount
