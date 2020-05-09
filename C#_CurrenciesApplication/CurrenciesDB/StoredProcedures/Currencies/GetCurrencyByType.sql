CREATE PROCEDURE [dbo].[GetCurrencyByType]
	@typeId INT
AS
	SELECT @typeId FROM Types
	INNER JOIN Currencies_Types ON Types.Id = Currencies_Types.TypeId
	WHERE @typeId = TypeId;
RETURN 0
