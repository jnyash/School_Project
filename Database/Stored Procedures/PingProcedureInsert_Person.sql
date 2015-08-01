DROP PROCEDURE [dbo].[Usp_Insert_Person]
GO
CREATE PROCEDURE [dbo].[Usp_Insert_Person] 
(

@vchFirstName varchar(100),
@vchLastName varchar(100),
@SSN varchar(11),
@vchEmail varchar(100),
@vchPhone varchar(100),
@vchtypename varchar(40),
@vchAdress varchar(100),
@vchCity varchar(100),
@intZIP int

)
AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-03-26
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-Lägga till en medlem i Persons / Adresses / xTypes Table 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON
-- Subquery för att få xType  från vchtypename 
DECLARE @intxType int
Select @intxType = xType FROM xTypes where vchtypename = @vchtypename
DECLARE @ID int

INSERT INTO [dbo].[Persons] Values (@vchFirstName, @vchLastName, @SSN, @vchEmail, @vchPhone, @intxType)

SELECT @ID = @@identity FROM Persons 
INSERT INTO [dbo].[Adresses] VALUES (@ID,@vchAdress, @vchCity, @intZIP)  




/*
GO
EXEC [dbo].[Usp_Insert_Person]


@vchFirstName	  ='',
@vchLastName      ='',
@SSN			  ='',
@vchEmail		  ='',
@vchPhone		  ='',
@vchtypename      ='',   -- Man kan bara ha 'Member' (default) eller 'Couch' 
@vchAdress		  ='',
@vchCity 	      ='',
@intZIP 	      =''



*/