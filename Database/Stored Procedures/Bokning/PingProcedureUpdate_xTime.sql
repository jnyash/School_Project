DROP PROCEDURE [dbo].[Usp_Update_xTime]
GO
CREATE PROCEDURE [dbo].[Usp_Update_xTime]
(
@zDay date,
@zTime  varchar(15),
@vchGroupNamn varchar(60)

)
AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
- Uppdatera  xTime tabell
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON;
 DECLARE @Group_Id int
 SELECT Group_Id = @Group_Id from Groups 
INNER JOIN Group_bok ON Groups.Group_Id = Group_bok.Group_Id
 where vchGroupNamn = @vchGroupNamn


if (@Group_Id = 0)
BEGIN


DECLARE @bokning_id int

INSERT INTO xTIME VALUES (@zDay,@zTime)

SELECT @bokning_id = @@identity FROM xTIME 

INSERT INTO Group_bok VALUES (@bokning_id,@Group_Id)

 END 
ELSE
BEGIN

UPDATE       xTIME
SET                zDAY =@zDay, zTime =@zTime
FROM            xTIME 
INNER JOIN Groups 
INNER JOIN Group_bok ON Groups.Group_Id = Group_bok.Group_Id AND Groups.Group_Id = Group_bok.Group_Id ON xTIME.bokning_id = Group_bok.bokning_id AND 
 xTIME.bokning_id = Group_bok.bokning_id
 where Groups.Group_Id  = @Group_Id


--END 
GO
EXEC [dbo].[Usp_Update_xTime]


@zDay = '2014-09-21',
@zTime = '15:00',
@vchGroupNamn ='Terminator'


/*

SELECT     Groups.Group_Id,Groups.vchGroupNamn,  FORMAT( xTIME.zDAY,'yyyy-mm-dd')AS zDAY, xTIME.zTime, Group_types.vchGroup
FROM            Group_bok INNER JOIN
                         Groups ON Group_bok.Group_Id = Groups.Group_Id AND Group_bok.Group_Id = Groups.Group_Id INNER JOIN
                         Group_types ON Groups.intGroup_Type = Group_types.intGroup_Type INNER JOIN
                         xTIME ON Group_bok.bokning_id = xTIME.bokning_id AND Group_bok.bokning_id = xTIME.bokning_id

*/
