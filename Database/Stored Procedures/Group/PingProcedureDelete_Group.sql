DROP PROCEDURE [dbo].[Usp_Delete_Group]
GO

CREATE PROCEDURE [dbo].[Usp_Delete_Group]
(
@Group_Id	int
)
AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapa en ny grupp
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON


DELETE FROM GroupnMem
FROM  Groups INNER JOIN
GroupnMem ON Groups.Group_ID = GroupnMem.Group_Id
where Groups.Group_Id = @Group_Id


DELETE FROM Groups where Groups.Group_Id = @Group_Id

/*
GO
EXEC [dbo].[Usp_Delete_Group]

@Group_Id	= 




SELECT * from Groups
SELECT * from GroupnMem

*/