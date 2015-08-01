DROP PROCEDURE [dbo].[Usp_Update_Persons]
GO
CREATE PROCEDURE [dbo].[Usp_Update_Persons]
(
@vchFirstName		VARCHAR(100),
@vchLastName		VARCHAR(100),
@vchEmail			VARCHAR(100),
@vchPhone			VARCHAR(100),
@ID					int,
@vchAdress			VARCHAR(100),
@vchCity			VARCHAR(100),
@intZIP				INT
)
AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
- Uppdatera Persons Tabel
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON;

Update Persons set 
vchFirstName = @vchFirstName,
vchLastName = @vchLastName,
vchemail = @vchEmail,
vchPhone = @vchPhone
where ID = @ID


Update Adresses set 
vchAdress= @vchAdress,
vchCity = @vchCity,
intZIP = @intZIP FROM Adresses
INNER JOIN Persons ON Adresses.ID = Persons.ID
WHERE Persons.ID = @ID

/*
GO
EXEC [dbo].[Usp_Update_Persons]

@ID				= 	,
@vchFirstName	=''	,
@vchLastName	=''	,
@vchEmail		=''	,
@vchPhone		=''	,
@vchAdress		= '',
@vchCity		= '',
@intZIP			= 	

--select * from Persons,Adresses

*/