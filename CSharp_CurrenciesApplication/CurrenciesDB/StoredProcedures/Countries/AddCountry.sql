CREATE PROCEDURE [dbo].[AddCountry]
	@Code nvarchar(3),
	@Name nvarchar(100)
AS
	INSERT INTO Countries ([CountryCode], [Name]) VALUES (@Code, @Name);
	
RETURN 0;
