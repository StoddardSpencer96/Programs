CREATE TABLE [dbo].[Currencies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [ColourId] INT NOT NULL, 
    [CountryCode] NVARCHAR(3) NOT NULL, 
    CONSTRAINT [FK_Currencies_ToCountries] FOREIGN KEY ([CountryCode]) REFERENCES [Countries]([CountryCode])

)
