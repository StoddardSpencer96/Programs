CREATE PROCEDURE [dbo].[DeleteType]
	@Id int
AS
	DELETE FROM Types WHERE Id = @Id;
RETURN @@rowcount
