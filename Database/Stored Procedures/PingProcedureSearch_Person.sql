DROP PROCEDURE [dbo].[Usp_Search_Person]
GO
CREATE PROCEDURE [dbo].[Usp_Search_Person]
(
@Firstname	varchar(100),
@Lastname	varchar(100)
)
AS
/*
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Skapad:	2014-04-04
Av:	Sami Jansson Ajroud
Ändrad:
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
- sök kontaktuppgift på en person
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
SET NOCOUNT ON;

SELECT * FROM Persons inner join Adresses On Adresses.ID = Persons.ID where (vchFirstName like'%' + @Firstname + '%') 



 SELECT * FROM Persons inner join Adresses On Adresses.ID = Persons.ID where (vchLastName like '%' + @Lastname + '%')


GO
EXEC [dbo].[Usp_Search_Person]

@Firstname	='pat',
@Lastname	= ''

select * from Persons

select * from xTypes
