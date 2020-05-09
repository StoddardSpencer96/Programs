CREATE PROCEDURE [dbo].[GetOneType]
	@Id int
AS
	SELECT * FROM Types WHERE Types.Id = @Id;
RETURN 0
