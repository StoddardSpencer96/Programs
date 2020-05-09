CREATE PROCEDURE [dbo].[DeleteCurrency]
	@Id int
AS
	DELETE FROM Currencies WHERE Id = @Id;
RETURN @@rowcount
