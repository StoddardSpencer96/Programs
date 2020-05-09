CREATE PROCEDURE [dbo].[AddCurrency]
	@Name nvarchar(255),
	@newIdentity INT = NULL OUTPUT
AS
	INSERT INTO Currencies ([Name]) VALUES (@Name);
	SET @newIdentity = SCOPE_IDENTITY();

RETURN 0;
