CREATE PROCEDURE [dbo].[AddType]
	@Name nvarchar(100),
	@newID INT OUTPUT
AS
	INSERT INTO Types ([Name]) VALUES (@Name);
	SET @newID = SCOPE_IDENTITY();

RETURN 0
