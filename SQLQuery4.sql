CREATE PROCEDURE [dbo].[AddActivites]
	@Id_activite int,
	@Nom_activite nvarchar (50),
	@Duree int ,
	@Cout int ,
	@Nombre_vote int 
AS
Begin
	INSERT INTO Activite (Id_activite, Nom_activite, Duree, Cout, Nombre_vote) values( @Id_activite, @Nom_activite, @Duree, @Cout, @Nombre_vote);
	end