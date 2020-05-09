CREATE PROCEDURE [dbo].[UpdateCurrency]
	@Id int,
	@Name nvarchar(255),
	@ColourId int,
	@CountryCode nvarchar(3)
AS
	UPDATE Currencies SET Name=@Name, ColourId=@ColourId, CountryCode=@CountryCode WHERE Id = @Id;
RETURN @@rowcount
