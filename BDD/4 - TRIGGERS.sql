USE [ServeurResto]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [Resto].[DoublonArticle]
ON [Resto].[CARTE]
INSTEAD OF INSERT AS

if exists ( select * from Resto.CARTE t 
    inner join inserted i on i.Article_Nom=t.Article_Nom)
	begin
		rollback
		RAISERROR ('AJOUT IMPOSSIBLE ! Le nom de cet article existe déjà...', 16, 1);
	end
else
	begin
		INSERT into Resto.CARTE (Article_Disponible,Article_Nom,Article_Format,Article_PrixHT,Article_Supplement,Article_Preference,Article_Alcoolise,ID_Type)
		SELECT Article_Disponible,Article_Nom,Article_Format,Article_PrixHT,Article_Supplement,Article_Preference,Article_Alcoolise,ID_Type FROM inserted;
	end
GO

CREATE TRIGGER [Resto].[DoublonPseudo]
ON [Resto].[UTILISATEUR]
INSTEAD OF INSERT AS

if exists ( select * from Resto.UTILISATEUR t 
    inner join inserted i on i.User_Pseudo=t.User_Pseudo)
	begin
		rollback
		RAISERROR ('AJOUT IMPOSSIBLE ! Le Pseudonyme existe déjà...', 16, 1);
	end
else
	begin
		INSERT into Resto.UTILISATEUR (User_Pseudo,User_Password,User_NomReel,User_PrenomReel,User_Telephone,ID_Role) 
		SELECT User_Pseudo,User_Password,User_NomReel,User_PrenomReel,User_Telephone,ID_Role FROM inserted;
	end
GO