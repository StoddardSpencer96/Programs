CREATE TABLE [dbo].[Currencies_Types]
(
	[TypeId] INT NOT NULL PRIMARY KEY, 
    [CurrenciesId] INT NOT NULL, 
    CONSTRAINT [FK_Currencies_Types_ToCurrencies] FOREIGN KEY (CurrenciesId) REFERENCES Currencies(Id), 
    CONSTRAINT [FK_Currencies_Types_ToTypes] FOREIGN KEY ([TypeId]) REFERENCES Types(Id)
)
