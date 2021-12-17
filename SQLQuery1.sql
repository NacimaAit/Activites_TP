CREATE TABLE [dbo].[Participant]
(
	[Id_participant] INT NOT NULL PRIMARY KEY, 
    [Nom_participant] NVARCHAR(50) NULL, 
    [Adresse_participant] NVARCHAR(50) NULL, 
    [Vote] INT NULL
)