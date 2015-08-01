DROP PROCEDURE [dbo].[Usp_Show_Person]
GO
CREATE PROCEDURE [dbo].[Usp_Show_Person]
(@ID int)
AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
- visa kontaktuppgift på en person
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON;
if (@ID = 0)
BEGIN
SELECT Persons.ID, Persons.vchFirstName, Persons.vchLastName, Persons.SSN, Persons.vchEmail, Persons.vchPhone,Adresses.vchAdress,Adresses.vchCity,Adresses.intZIP FROM Persons 
INNER JOIN Adresses ON Adresses.ID = Persons.ID
END 
ELSE
BEGIN
SELECT Persons.ID, Persons.vchFirstName, Persons.vchLastName, Persons.SSN, Persons.vchEmail, Persons.vchPhone,Adresses.vchAdress,Adresses.vchCity,Adresses.intZIP FROM Persons 
INNER JOIN Adresses ON Adresses.ID = Persons.ID
where Persons.ID = @ID
END 


GO
/*
EXEC [dbo].[Usp_Show_Person]

	@ID = 1		
*/