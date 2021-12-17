CREATE PROCEDURE [dbo].[EditPostActivite]
	@Id_activite int,
	@Nom_activite nvarchar(50),
	@Duree int,
	@Cout int,
	@Nombre_vote nvarchar(50)
AS
BEGIN
	INSERT INTO Activite
	VALUES (@Id_activite, @Nom_activite, @Duree, @Cout, @Nombre_vote);
END