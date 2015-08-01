DROP PROCEDURE [dbo].[Usp_PersGroup]
GO
CREATE PROCEDURE [dbo].[Usp_PersGroup]
(
@Group_Id int
)

AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
sök efter personer som är med i en grupp enligt gruppsnamn
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON


--SELECT        Groups.Group_Id, Persons.vchFirstName, Persons.vchLastName
--FROM            GroupnMem INNER JOIN
--                         Groups ON GroupnMem.Group_ID = Groups.Group_Id INNER JOIN
--                         Persons ON GroupnMem.Person_ID = Persons.ID






SELECT        GroupnMem.Group_ID, Persons.vchFirstName, Persons.vchLastName
FROM            GroupnMem INNER JOIN
                         Persons ON GroupnMem.Person_ID = Persons.ID

WHERE GroupnMem.Group_Id = @Group_Id









--GO
--EXEC [dbo].[Usp_PersGroup]

--@Group_Id = 
