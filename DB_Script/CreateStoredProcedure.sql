CREATE PROCEDURE [dbo].[InsertNewMovie]
	@Movie_Name varchar(250),
	@Movie_Release_Date DateTime,
	@Movie_Plot varchar(250),
	@Movie_Poster nvarchar(MAX)
	@Movie_Id    INT OUTPUT
AS
	BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [dbo].[MOVIES] (MOVIENAME,DATEOFRELEASE,PLOT,POSTER) 
	VALUES(@Movie_Name,@Movie_Release_Date,@Movie_Plot,@Movie_Poster)
	
	SET @Movie_Id=SCOPE_IDENTITY()
    RETURN  @Movie_Id
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
	@ProducerName varchar(250),
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
	INSERT INTO [dbo].[MAPACTORSMOVIES] (ACTORID,MOVIEID) 
	VALUES(@Actor_Id,@Movie_Id)
END

CREATE PROCEDURE [dbo].[EditMovieDetails]
	@Movie_Id INT,
	@Movie_Plot varchar(250)
AS
	BEGIN
	UPDATE [dbo].[MOVIES] SET PLOT=@Movie_Plot WHERE MOVIEID=@Movie_Id
END

