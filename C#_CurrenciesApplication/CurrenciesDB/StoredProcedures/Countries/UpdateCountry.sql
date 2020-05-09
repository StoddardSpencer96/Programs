CREATE PROCEDURE [dbo].[UpdateCountry]
	@CountryCode nvarchar(3),
	@Name nvarchar(100)
AS
	UPDATE Countries SET Name = @Name WHERE CountryCode = @CountryCode;
RETURN 0
