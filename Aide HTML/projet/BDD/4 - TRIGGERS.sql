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


-- TODO : A FAIRE !
USE [ServeurResto]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER NoModifADMIN
ON Resto.UTILISATEUR
INSTEAD OF UPDATE AS
if ((select i.User_Pseudo from inserted i where i.ID_User = 1) != 'ADMIN')
	BEGIN
		ROLLBACK
		RAISERROR ('INTERDICTION DE MODIFIER LE PSEUDO ADMIN !', 16, 1);
	END
else
	BEGIN
		UPDATE [Resto].[UTILISATEUR] SET
			User_Pseudo = i.User_Pseudo, User_Password = i.User_Password, 
			User_NomReel = i.User_NomReel, User_PrenomReel = i.User_PrenomReel, 
			User_Telephone = i.User_Telephone, ID_Role = i.ID_Role
		From inserted i		
		INNER JOIN Resto.UTILISATEUR u ON u.ID_User = i.ID_User;
	END
GO

---- TEST :
UPDATE Resto.UTILISATEUR SET User_Pseudo = 'ADMINA' WHERE ID_User = 1 ; -- NO MODIF DU PSEUDO
UPDATE Resto.UTILISATEUR SET User_Pseudo = 'ADMINB' WHERE ID_User = 3 ; -- PAS DE SOUCI LOGIQUEMENT !
---- TODO : VERIFIER SUR APPLI QUE L'ON PUISSE MODIFIER password DE ADMIN !
UPDATE Resto.UTILISATEUR SET User_Password = 'troll' WHERE ID_User = 1 ;
--GO

/*        public void userUpdate(Connexion BDD, List<string> values)
        {
            List<Data> datas = new List<Data>()
                {
                    new Data(){ name = "id",        valeur=values[6]},
                    new Data(){ name = "pseudo",    valeur=values[0]},
                    new Data(){ name = "pass",      valeur=values[1]},
                    new Data(){ name = "nom",       valeur=values[2]},
                    new Data(){ name = "prenom",    valeur=values[3]},
                    new Data(){ name = "tel",       valeur=values[4]},
                    new Data(){ name = "role",      valeur=values[5] }
                };

            string query = "resto.Utilisateur_Update";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            if (BDD.SqlCmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Modification d'un utilisateur a réussi", "Etat Modification Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Modification d'un utilisateur a échoué", "Etat Modification Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
*/