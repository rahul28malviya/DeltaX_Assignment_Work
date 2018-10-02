CREATE PROCEDURE [dbo].[InsertNewMovie]
	@Movie_Name varchar(50),
	@Movie_Release_Date DateTime,
	@Movie_Plot varchar(250),
	@Movie_Poster_Path nvarchar(MAX)
AS
	BEGIN
	INSERT INTO [dbo].[MOVIES] (MOVIENAME,DATEOFRELEASE,PLOT,POSTER) 
	VALUES(@Movie_Name,@Movie_Release_Date,@Movie_Plot,@Movie_Poster_Path)
END

CREATE PROCEDURE [dbo].[SelectProducers]
AS
	BEGIN
	SELECT PRODUCERID,PRODUCERNAME FROM [dbo].[PRODUCERS]
END

CREATE PROCEDURE [dbo].[SelectActors]
AS
	BEGIN
	SELECT ACTORID,ACTORNAME FROM [dbo].[ACTORS]
END

CREATE PROCEDURE [dbo].[InsertNewProducer]
	@ProducerName varchar(50),
	@Gender char(1),
	@DateOfBirth DateTime,
	@Bio varchar(250)
AS
	BEGIN
	INSERT INTO [dbo].[PRODUCERS] (PRODUCERNAME,GENDER,DATEOFBIRTH,BIO) 
	VALUES(@ProducerName,@Gender,@DateOfBirth,@Bio)
END

CREATE PROCEDURE [dbo].[InsertMapMovieProducer]
	@Producer_Id INT,
	@Movie_Id INT
AS
	BEGIN
	INSERT INTO [dbo].[MAPPRODUCERSMOVIES] (DIRECTORID,MOVIEID) 
	VALUES(@Producer_Id,@Movie_Id)
END

CREATE PROCEDURE [dbo].[InsertMapMovieActor]
	@Actor_Id INT,
	@Movie_Id INT
AS
	BEGIN
	INSERT INTO [dbo].[MAPACTORSMOVIES] (ACTORID,MOVIEID,ROLES) 
	VALUES(@Actor_Id,@Movie_Id)
END

CREATE PROCEDURE [dbo].[EditMovieDetails]
	@Movie_Id INT,
	@Movie_Plot varchar(250)
AS
	BEGIN
	UPDATE [dbo].[MOVIES] SET PLOT=@Movie_Plot WHERE MOVIEID=@Movie_Id
END

