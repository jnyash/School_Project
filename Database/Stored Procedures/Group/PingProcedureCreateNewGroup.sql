DROP PROCEDURE [dbo].[Usp_Create_NewGroup]
GO

CREATE PROCEDURE [dbo].[Usp_Create_NewGroup]
(
@vchGroupNamn varchar(60),
@vchGroup		VARCHAR(40)
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
DECLARE @intGroup_Type int
Select @intGroup_Type = intGroup_Type FROM Group_types WHERE vchGroup = @vchGroup

INSERT INTO Groups VALUES (@vchGroupNamn,@intGroup_Type)

/*
GO
EXEC [dbo].[Usp_Create_NewGroup]

@vchGroupNamn ='',
@vchGroup =''    -- kan  vara 'Starter', 'Middling', 'Competitor' 



*/

