Drop procedure [dbo].[Usp_Delete_User]
GO
CREATE PROCEDURE [dbo].[Usp_Delete_User]

(
@ID int
)
AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-03-26
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-tar bort en medlem från Persons / Adresses Table 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON
  
  DELETE FROM   Adresses
 where Adresses.ID= @ID

  DELETE FROM   GroupnMem
 where GroupnMem.Person_ID= @ID

  DELETE FROM   Persons
 where Persons.id = @ID


--GO
--EXEC [dbo].[Usp_Delete_User]

--@ID = 14
 
--select * from Persons  where Persons.id = 14
--select * from Adresses  where Adresses.ID= 14
--select * from GroupnMem  where GroupnMem.Person_ID= 14

