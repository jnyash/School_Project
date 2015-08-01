DROP PROCEDURE [dbo].[Usp_Book_Tabel]
GO
CREATE PROCEDURE [dbo].[Usp_Book_Tabel]


AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
visa bokning tabel för en Group
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON




SELECT     Groups.Group_Id,Groups.vchGroupNamn,  CONVERT(VARCHAR(10), xTIME.zDAY, 120)AS zDAY, xTIME.zTime, Group_types.vchGroup
FROM            Group_bok INNER JOIN
                         Groups ON Group_bok.Group_Id = Groups.Group_Id AND Group_bok.Group_Id = Groups.Group_Id INNER JOIN
                         Group_types ON Groups.intGroup_Type = Group_types.intGroup_Type INNER JOIN
                         xTIME ON Group_bok.bokning_id = xTIME.bokning_id AND Group_bok.bokning_id = xTIME.bokning_id




/*
GO
EXEC [dbo].[Usp_Book_Tabel]

*/
