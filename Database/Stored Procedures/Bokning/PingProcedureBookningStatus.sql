DROP PROCEDURE [dbo].[Usp_BookingStatus]
GO
CREATE PROCEDURE [dbo].[Usp_BookingStatus]
(
@vchGroupNamn varchar(60)
)
AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Check if a reservatin exist
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON
DECLARE @group_Id int
SELECT @group_Id = Group_Id FROM Groups WHERE vchGroupNamn = @vchGroupNamn




SELECT        xTIME.bokning_id
FROM            Group_bok 
INNER JOIN Groups ON Group_bok.Group_Id = Groups.Group_Id AND Group_bok.Group_Id = Groups.Group_Id 
INNER JOIN xTIME  ON Group_bok.bokning_id = xTIME.bokning_id AND Group_bok.bokning_id = xTIME.bokning_id
where Groups.Group_Id =  @group_Id



						



/*
GO
EXEC [dbo].[Usp_BookingStatus]

*/
