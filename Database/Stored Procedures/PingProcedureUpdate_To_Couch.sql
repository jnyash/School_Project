DROP PROCEDURE [dbo].[Usp_Update_MembershipType]
GO
CREATE PROCEDURE [dbo].[Usp_Update_MembershipType]
(
@Id	int,
@vchtypename varchar(40)
)
AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-Uppdatera Medlemnsskap_Typ      
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON
DECLARE @xType int
SELECT @xType= xType  FROM xTypes WHERE vchtypename = @vchtypename 



UPDATE Persons SET intxType = @xType FROM Persons 
WHERE Persons.ID = @Id

/*
GO
EXEC [dbo].[Usp_Update_MembershipType]
@vchtypename ='',
@Id = ''


--       SELECT * FROM xTypes
--       SELECT * FROM Persons 



*/


