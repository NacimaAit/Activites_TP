CREATE PROCEDURE [dbo].[detailActivite]
	@Nom_activite nvarchar(50)
	
AS
	SELECT *
	from Activite
	where Nom_activite= @Nom_activite

