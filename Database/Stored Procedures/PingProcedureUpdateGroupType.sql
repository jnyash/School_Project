DROP PROCEDURE [dbo].[Usp_Update_GroupType]
GO
CREATE PROCEDURE [dbo].[Usp_Update_GroupType]
(
@vchGroup varchar(40),
@vchGroupNamn varchar(60)
)
AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-Uppdatera Group_Typ för Groups
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON
DECLARE @intGroup_Type int
SELECT @intGroup_Type = intGroup_Type FROM Group_types WHERE vchGroup = @vchGroup

declare @Group_Id int
Select @Group_Id = Group_Id  FROM Groups WHERE vchGroupNamn = @vchGroupNamn


UPDATE Groups SET intGroup_Type = @intGroup_Type
FROM Group_types 
INNER JOIN Groups ON Group_types.intGroup_Type = Groups.intGroup_Type
where Groups.vchGroupNamn = @vchGroupNamn

/*
GO
EXEC [dbo].[Usp_Update_GroupType]

@vchGroup			='Competitor',
@vchGroupNamn		='Hulk'

--				select * from Group_types
--				select * from Groups
*/