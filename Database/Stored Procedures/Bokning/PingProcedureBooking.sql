DROP PROCEDURE [dbo].[Usp_booking]
GO
CREATE PROCEDURE [dbo].[Usp_booking]
(
@day	date,
@time	varchar(15),
@vchGroupNamn varchar(60)
)
AS
/*             
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
- Boka dag och tid 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON
DECLARE @Group_Id int
SELECT @Group_Id = Group_Id from Groups where vchGroupNamn = @vchGroupNamn
DECLARE @bokning_id int

INSERT INTO xTIME VALUES (@day,@time)

SELECT @bokning_id = @@identity FROM xTIME 

INSERT INTO Group_bok(bokning_id, Group_Id)
VALUES (@bokning_id,@Group_Id)


--GO
--EXEC [dbo].[Usp_booking]

--@day ='2030-05-15',
--@time ='12:00-14:00',
--@vchGroupNamn = 'Superman'


--select * from xTIME
--select * from Group_bok
--select * from Groups


--SELECT        Groups.Group_Id, Groups.vchGroupNamn, Group_types.vchGroup, xTIME.bokning_id, xTIME.zDAY, xTIME.zTime, Group_bok.bokning_id AS GroupBok_Bok, 
--              Group_bok.Group_Id AS GroupBok_Group
--FROM          Groups INNER JOIN
--                         Group_bok ON Groups.Group_Id = Group_bok.Group_Id AND Groups.Group_Id = Group_bok.Group_Id INNER JOIN
--                         Group_types ON Groups.intGroup_Type = Group_types.intGroup_Type INNER JOIN
--                         xTIME ON Group_bok.bokning_id = xTIME.bokning_id AND Group_bok.bokning_id = xTIME.bokning_id

