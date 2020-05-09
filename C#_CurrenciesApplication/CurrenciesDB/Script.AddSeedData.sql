/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


--Populate Countries Table
IF NOT EXISTS (SELECT 1 FROM Countries)
BEGIN
	INSERT INTO Countries (CountryCode, Name) VALUES ('CAN', 'Canada');
	INSERT INTO Countries (CountryCode, Name) VALUES ('FRA', 'France');
	INSERT INTO Countries (CountryCode, Name) VALUES ('GRE', 'Greece');
END



--Populate Types table
IF NOT EXISTS (SELECT 1 FROM Types)
BEGIN
	INSERT INTO Types (Id, Name) VALUES ('3', 'Crypto');
END



--Populate Colours Table
IF NOT EXISTS (SELECT 1 FROM Colours) 
BEGIN
	INSERT INTO Colours (Id, Name) VALUES ('1', 'Green');
	INSERT INTO Colours (Id, Name) VALUES ('2', 'Blue');
	INSERT INTO Colours (Id, Name) VALUES ('3', 'Pink');
	INSERT INTO Colours (Id, Name) VALUES ('4', 'Red');
END



--Populate Currencies Table FIGURE OUT WHY ITS NOT ALL WORKING
IF NOT EXISTS (SELECT 1 FROM Currencies)
BEGIN
	INSERT INTO Currencies (Id, Name, ColourId, CountryCode) VALUES ('1', 'Canadian Dollar', '1', 'CAN');
	INSERT INTO Currencies (Id, Name, ColourId, CountryCode) VALUES ('2', 'Euro', '2', 'FRA');
	INSERT INTO Currencies (Id, Name, ColourId, CountryCode) VALUES ('3', 'Euro', '3', 'GRE');
	INSERT INTO Currencies (Id, Name, ColourId, CountryCode) VALUES ('4', 'Brazilian Real', '4', 'BRA');
	INSERT INTO Currencies (Id, Name, ColourId, CountryCode) VALUES ('5', 'US Dollar', '5', 'USA');
	INSERT INTO Currencies (Id, Name, ColourId, CountryCode) VALUES ('6', 'Russian Ruble', '6', 'RUS');
END
