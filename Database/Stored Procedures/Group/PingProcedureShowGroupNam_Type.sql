DROP PROCEDURE [dbo].[Usp_ShowGroupName_Type]
GO

CREATE PROCEDURE [dbo].[Usp_ShowGroupName_Type]
(
@Group_Id int
)
AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:                              NOT FINSIH
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Visa  group name and group type
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/

--SELECT Groups.Group_Id, Groups.vchGroupNamn, Group_types.vchGroup
--FROM Group_types 
--INNER JOIN Groups ON Group_types.intGroup_Type = Groups.intGroup_Type



SELECT        Group_Id, vchGroupNamn
FROM            Groups


SELECT Group_types.vchGroup, Groups.Group_Id
FROM Group_types 
INNER JOIN Groups ON Group_types.intGroup_Type = Groups.intGroup_Type
where Groups.Group_Id = @Group_Id









/*
GO
EXEC [dbo].[Usp_ShowGroupName_Type]

@Group_Id =
*/
