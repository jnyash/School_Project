DROP PROCEDURE [dbo].[Usp_Cancel]
GO
CREATE PROCEDURE [dbo].[Usp_Cancel]
(
@group_Id		int
--@vchGroupNamn varchar(60)
)

AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
- Avboka dag och tid 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON
--DECLARE @group_Id int
--SELECT @group_Id = Group_Id FROM Groups WHERE vchGroupNamn = @vchGroupNamn


Delete From xTIME 
FROM   xTIME 
inner join Group_bok on Group_bok.bokning_id = xTime.bokning_id
inner join Groups on Groups.Group_Id = Group_bok.Group_Id
where Groups.Group_Id = @group_Id


GO
EXEC [dbo].[Usp_Cancel]

@group_Id	= 2




