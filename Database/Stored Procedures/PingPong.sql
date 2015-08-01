--DROP DATABASE Ping_Pong
--  CREATE DATABASE Ping_Pong

-- FÖRKLARINGAR
-- Helst Normaliseras = (HN)
-- (PK), (FK) = Primary/Foreign key

CREATE TABLE Persons  
(
ID					INT IDENTITY (1,1) not null,	 --(PK)
vchFirstName		VARCHAR(100) NOT NULL,
vchLastName			VARCHAR(100) NOT NULL,
SSN					VARCHAR(11) NOT NULL,
vchEmail			VARCHAR(100),
vchPhone			VARCHAR(100),
intxType			int --(FK- xTypes)-- 0=Member, 1=Couch (DEFAULT=0)
)

CREATE TABLE Groups  
-- Beskrivning av gruppen. och har en mellantabell för att lägga till alla medlemmar.
(	--Innehållande specifikt ID, vilka som är med i gruppen och sorts grupp
Group_Id		INT IDENTITY (1,1) not null,	-- Får ej vara tomt, då t.ex 5 pers id vill vara med.
vchGroupNamn varchar(60),
intGroup_Type	 int		--(HN) (FK till group_types) 1=Starter, 2=Middling, 3=Competitor 
)


CREATE TABLE GroupnMem
(
Group_ID		INT,		--(FK)
Person_ID		INT	--(FK)
)

CREATE TABLE Group_types
(
intGroup_Type	int IDENTITY (1,1) not null,	 --(PK)
vchGroup		VARCHAR(40)--(HN) 1=Starter, 2=Middling, 3=Competitor
)

CREATE TABLE xTypes
( -- Vilken sorts medlemstyp du har.
xType		INT IDENTITY (1,1) not null,	--(PK)
vchtypename VARCHAR(40) -- 0=Member, 1=Couch
)

CREATE TABLE Adresses

( -- Adressen till de specifika personerna
ID 			INT,  --(FK)
vchAdress	VARCHAR(100),
vchCity		VARCHAR(100),
intZIP		INT
)
Alter Table  Adresses
--drop table clogin
CREATE TABLE clogin
(
cusername	VARCHAR(100),
cpassword	VARCHAR(100)
)

CREATE TABLE xTIME
( --datum och tider när alla grupper startar, räknas med endast 1h
bokning_id int Identity(1,1),
zDAY	 DATE,
zTime	 varchar(15) NOT NULL,
)

CREATE TABLE Group_bok
(
bokning_id INT, 
Group_Id INT NOT NULL --FK till groups
)

--PRIMARY KEYS--
Alter table Persons		Add Primary Key (ID ASC)
Alter table xTypes		Add Primary Key (xType asc)
Alter Table Groups		Add Primary Key (Group_ID ASC)
Alter table group_types Add Primary Key (intgroup_type ASC)
Alter table xTIME		Add Primary Key (bokning_id ASC)
--FOREIGN KEYS--
Alter Table Persons		Add Foreign Key (intxType) REFERENCES xTypes(xtype)
Alter table groups		Add FOREIGN KEY (intGroup_Type) REFERENCES Group_types(intgroup_type)
Alter TABLE xTIME		ADD FOREIGN KEY (Group_ID) REFERENCES Groups(group_id)
Alter table adresses	Add foreign key (ID) References Persons(ID)
ALTER TABLE Groupnmem	ADD FOREIGN KEY (Person_ID) REFERENCES Persons(ID)
ALTER TABLE Groupnmem	ADD FOREIGN KEY (Group_ID)	References Groups(Group_ID)
ALTER TABLE Group_bok	ADD FOREIGN KEY (Group_Id)	REFERENCES Groups(Group_Id)
ALTER TABLE Group_bok	ADD FOREIGN KEY (bokning_id)	REFERENCES xTIME(bokning_id)

INSERT INTO clogin VALUES ('admin','pass');

INSERT INTO Group_types Values ('Starter')
INSERT INTO Group_types Values ('Middling')
INSERT INTO Group_types VALUES ('Competitor')

INSERT INTO xTypes VALUES ('Member')
INSERT INTO xTypes VALUES ('Couch')
INSERT INTO xTypes VALUES ('SUPER USER')

INSERT INTO Groups VALUES ('Cyborg',1)
INSERT INTO Groups VALUES ('Terminator',1)
INSERT INTO Groups VALUES ('Hulk',3)
INSERT INTO Groups VALUES ('Superman',3)
INSERT INTO Groups VALUES ('Batman',2)
INSERT INTO Groups VALUES ('BatGirl',2)

INSERT INTO Persons Values('Patrik','Svartholm','870616-0007','putte@gmail.com','5678943210',1)
INSERT INTO Adresses Values(1,'Uppsalavägen 69','Uppsala',742)
INSERT INTO Persons Values('Sami','Ajroud','870608-0757','sami@hotmail.com','0737166521',1)
INSERT INTO Adresses Values(2,'Flemmingsbergsvägen 71','Norrtälje', 761)
INSERT INTO Persons Values('Pia','Ahlgren','850318-0943','pia@gmail.com','0725388067',1)
INSERT INTO Adresses Values(3,'Stockholmsvägen 56','Stockholm',756)
INSERT INTO Persons Values('Mitra','Babapour','850925-0290','mitra@hotmail.com','0718299461',1)
INSERT INTO Adresses Values(4,'Roslagsvägen 32','Stockholm', 732)
INSERT INTO Persons Values('Patrik','Rosenblad','840914-7874','patrik@gmail.com','7836592782',1)
INSERT INTO Adresses Values(5,'Sveavägen 42','Stockholm',652)
INSERT INTO Persons Values('Robin','Falkenkrans','801209-8754','robin@gmail.com','0401119202',1)
INSERT INTO Adresses Values(6,'highwaytohell 71','Blidö',609)
INSERT INTO Persons Values('Osman','Osman','811108-7643','osman@hotmail.com','0409358221',1)
INSERT INTO Adresses Values(7,'Bergsgatan 48','Norrköping',627)
INSERT INTO Persons Values('Farhan','Naeem','821007-6532','farhan@gmail.com','0541809925',1)
INSERT INTO Adresses Values(8,'Kungsholmsgatan 37','Täby',883)
INSERT INTO Persons Values('John Costas','Diamantis','830906-6421','johncostas@gmail.com','0185173842',1)
INSERT INTO Adresses Values(9,'Klarabergsviadukten 49','Danderyd',134)
INSERT INTO Persons Values('Sebastian','Dahlgren','840805-5310','sebastian@hotmail.com','0801163591',1)
INSERT INTO Adresses Values(10,'Katarinavägen 2','Järfälla',634)
INSERT INTO Persons Values('Pierre','Lahouar','850704-4201','pirre@hotmail.com','0249436230',1)
INSERT INTO Adresses Values(11,'Lejonvägen 19','Vaxholm',416)
INSERT INTO Persons Values('Linus','Björkman','860603-3112','linus@gmail.com','0854780042',1)
INSERT INTO Adresses Values(12,'Bergsgatan 54','Tyresö',710)
INSERT INTO Persons Values('Jimmy','Näslund','870502-2223','jimmy@hotmail.com','0626132326',1)
INSERT INTO Adresses Values(13,'Rosenlundsgatan 9','Nacka',293)
INSERT INTO Persons Values('Dennis','Blomqvist','860401-1342','Dennis@hotmail.com','0936214246',1)
INSERT INTO Adresses Values(14,'Söderhallarna 3','Sollentuna',402)
INSERT INTO Persons Values('Jessika','Nilsson','850330-2451','jessik@gmail.com','0211386685',1)
INSERT INTO Adresses Values(15,'Surbrunnsgatan 66','Österåker',415)
INSERT INTO Persons Values('Johanna','Hofstam','860229-3562','johanna@hotmail.com','0921952975',1)
INSERT INTO Adresses Values(16,'Brahegatan 49','Ekrö',403)
INSERT INTO Persons Values('Robert','Miskiewicz','790125-4671','robert@hotmail.com','0989631568',1)
INSERT INTO Adresses Values(17,'Kungsholmsgatan 43','Salem',433)
INSERT INTO Persons Values('Beata','Alving','791213-8763','beata@hotmail.com','6066361463',1)
INSERT INTO Adresses Values(18,'Pajalagatan 46','Vällingby',654)
INSERT INTO Persons Values('Ramin','Cavani','881019-6539','ramin@gmail.com','6192352905',1)
INSERT INTO Adresses Values(19,'Askebykroken 15','Spånga',007)
INSERT INTO Persons Values('Jens','Fogelholm','870922-8543','jens@gmail.com','8043459152',1)	
INSERT INTO Adresses Values(20,'Sundbybergsvägen 15','Solna',762)
INSERT INTO Persons Values('Gabriel','Haddad','860417-8211','gabriel@gmail.com','849942390',1)
INSERT INTO Adresses Values(21,'Sundbybergsvägen 24','Solna',864)
INSERT INTO Persons Values('Samir','Jader','820914-8734','samir@hotmail.com','8241628877',1)
INSERT INTO Adresses Values(22,'Nyköpingsvägen 23','Södertälje',527)
INSERT INTO Persons Values('Robert','Miskiewicz','850516-5639','robert@hotmail.com','1320160776',1)
INSERT INTO Adresses Values(23,'Gröndalsvägen 4','Södertälje',953)
INSERT INTO Persons Values('Nesrin','Tirpan','870621-8763','nesrin@hotmail.com','9129158730',1)
INSERT INTO Adresses Values(24,'Kungsholmsgatan 76','Stockholm',347)

INSERT INTO GroupnMem VALUES (1,17)
INSERT INTO GroupnMem VALUES (1,14)
INSERT INTO GroupnMem VALUES (1,11)
INSERT INTO GroupnMem VALUES (1,9)
INSERT INTO GroupnMem VALUES (2,21)
INSERT INTO GroupnMem VALUES (2,7)
INSERT INTO GroupnMem VALUES (2,13)
INSERT INTO GroupnMem VALUES (2,16)
INSERT INTO GroupnMem VALUES (3,6)
INSERT INTO GroupnMem VALUES (3,5)
INSERT INTO GroupnMem VALUES (3,18)
INSERT INTO GroupnMem VALUES (3,2)
INSERT INTO GroupnMem VALUES (4,20)
INSERT INTO GroupnMem VALUES (4,22)
INSERT INTO GroupnMem VALUES (4,19)
INSERT INTO GroupnMem VALUES (4,8)
INSERT INTO GroupnMem VALUES (5,10)
INSERT INTO GroupnMem VALUES (5,12)
INSERT INTO GroupnMem VALUES (5,23)
INSERT INTO GroupnMem VALUES (5,24)
INSERT INTO GroupnMem VALUES (6,3)
INSERT INTO GroupnMem VALUES (6,4)
INSERT INTO GroupnMem VALUES (6,15)
INSERT INTO GroupnMem VALUES (6,1)


INSERT INTO Group_bok VALUES (5,1)
INSERT INTO xTIME VALUES ('2014-05-16','14:00-16:00')

/*
Select * from Persons,Adresses WHERE Persons.ID=Adresses.ID
Select * from Groups
Select * from GroupnMem
Select * from xTIME
Select * from Group_types
Select * from xTypes
*/

/*
DELETE FROM Adresses 
DELETE FROM Persons
DELETE FROM Groups
DELETE FROM GroupnMem
DELETE FROM xTIME
DELETE FROM Group_types
DELETE FROM xTypes
*/