﻿CREATE TABLE [dbo].[MOVIES]
(
	[MOVIEID] INT IDENTITY(1000,1) PRIMARY KEY, 
    [MOVIENAME] VARCHAR(50) NOT NULL,
	[DATEOFRELEASE] DATETIME NOT NULL,
    [PLOT] VARCHAR(50) NOT NULL, 
    [POSTER] nvarchar(MAX)
)

CREATE TABLE [dbo].[ACTORS]
(
	[ACTORID] INT IDENTITY(5000,1) PRIMARY KEY, 
    [ACTORNAME] VARCHAR(50) NOT NULL, 
    [GENDER] CHAR(1) NOT NULL, 
    [DATEOFBIRTH] DATE NOT NULL, 
    [BIO] VARCHAR(200) NOT NULL
)

CREATE TABLE [dbo].[PRODUCERS]
(
	[PRODUCERID] INT IDENTITY(8000,1) PRIMARY KEY, 
    [PRODUCERNAME] VARCHAR(50) NOT NULL, 
    [GENDER] CHAR(1) NOT NULL, 
    [DATEOFBIRTH] DATE NOT NULL, 
    [BIO] VARCHAR(200) NOT NULL
)

CREATE TABLE [dbo].[MAPPRODUCERSMOVIES]
(
	[DIRECTORID] INT FOREIGN KEY REFERENCES [dbo].[PRODUCERS](PRODUCERID), 
    [MOVIEID] INT FOREIGN KEY REFERENCES [dbo].[MOVIES](MOVIEID) 
)

CREATE TABLE [dbo].[MAPACTORSMOVIES]
(
	[ACTORID] INT FOREIGN KEY REFERENCES [dbo].[ACTORS](ACTORID), 
    [MOVIEID] INT FOREIGN KEY REFERENCES [dbo].[MOVIES](MOVIEID),
	[ROLE] VARCHAR(50) NOT NULL
)