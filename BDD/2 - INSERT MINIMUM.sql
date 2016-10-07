/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/

-- INSERTION DE DONNEES
USE ServeurResto
GO
	
	 -- CREATION DES ROLES UTILISATEURS [Niv 1 à 3 : acces autorisé / Niv 4 ou + : acces refusé]
		INSERT into Resto.ROLE (Role_Libelle,Role_NiveauDroits) values ('ADMINISTRATEUR',1);
		INSERT into Resto.ROLE (Role_Libelle,Role_NiveauDroits) values ('FORMATEUR',2);
		INSERT into Resto.ROLE (Role_Libelle,Role_NiveauDroits) values ('STAGIAIRE',3);
		INSERT into Resto.ROLE (Role_Libelle,Role_NiveauDroits) values ('ANCIEN FORMATEUR',4);
		INSERT into Resto.ROLE (Role_Libelle,Role_NiveauDroits) values ('ANCIEN STAGIAIRE',4);
		INSERT into Resto.ROLE (Role_Libelle,Role_NiveauDroits) values ('SUPPRIMÉ',5);	-- En cas d'erreur de saisie détectée tardivement
		--  [ NE PAS MODIFIER ! ] --
		GO
	
	 -- CREATION DES LOGINS DE UTILISATEUR [!!! DONNEES DE TEST !!!]
		INSERT into Resto.UTILISATEUR (User_Pseudo,User_Password,User_NomReel,User_PrenomReel,User_Telephone,ID_Role) values ('ADMIN','root','(MCP)','Maître Contrôle Principal','0000000000','1');
		INSERT into Resto.UTILISATEUR (User_Pseudo,User_Password,User_NomReel,User_PrenomReel,User_Telephone,ID_Role) values ('FORMATEUR','chef','Olivier','GABAUT','0000000000','2');
		INSERT into Resto.UTILISATEUR (User_Pseudo,User_Password,User_NomReel,User_PrenomReel,User_Telephone,ID_Role) values ('Serveur1','first','kevin','NOOB','0000000000','3');
		-- ... [ A MODIFIER ET COMPLETER ! ]
		GO
		
	 -- LES TYPES DE PRODUITS (ETAPE 1 A) 
		INSERT into Resto.TVA (TVA_Taux) values ('0.00');
		INSERT into Resto.TVA (TVA_Taux) values ('2.10');
		INSERT into Resto.TVA (TVA_Taux) values ('5.50');
		INSERT into Resto.TVA (TVA_Taux) values ('10.00');	
		INSERT into Resto.TVA (TVA_Taux) values ('20.00');
		-- [A MODIFIER SI BESOIN EST PAR LE CLIENT SELON LA LEGISLATION EN VIGUEUR]
		GO

	 -- LES TYPES DE PRODUITS (ETAPE 1 B)
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('AUCUN');
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('BOISSON');
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('ENTREE FROIDE');	
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('ENTREE CHAUDE');
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('PLAT PRINCIPAL');
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('FROMAGE');
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('DESSERT');
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('VIANDE');
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('POISSON');
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('LEGUME');
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('FRUIT');
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('SAUCE');
		INSERT into Resto.TYPEPRODUIT (Type_Libelle) values ('PAIN');
		--  [ NE PAS MODIFIER ! ] --
		GO
			
	 -- CREATION DES ARTICLES (ETAPE 2 A) 
		INSERT into Resto.CARTE (Article_Disponible,Article_Nom,Article_Format,Article_PrixHT,Article_Supplement,Article_Preference,Article_Alcoolise,ID_Type) values (0,'Menu','Ne pas effacer !',0.00,0,0,0,1);
		-- ... [ A MODIFIER ET COMPLETER ! ]
		GO

	 -- CREATION DES MENUS (ETAPE 2 B1)
		INSERT into Resto.MENU (Menu_Disponible,Menu_Libelle,Menu_DateAjout,Menu_PrixTTC) values (0,'Aucun menu disponible','09/04/2015 08:00:00',0.00);
		-- ... [ A MODIFIER ET COMPLETER ! ]
		GO		
		-- LES MENUS SONT COMPOSÉS DE... (ETAPE 2 B2)
			-- ... [ A COMPLETER ! ]

			
	 -- GESTION DU STOCK (ETAPE 3)
		INSERT into Resto.STOCK (Stock_Fournisseur,Stock_DateAchat,Stock_PrixAchatUnit,Stock_QuantiteEntree,Stock_QuantiteSortie,ID_Article) values ('STOCK VIDE','03:04:2015 08:00:00',0,0,0,0,1);
		-- ... [ A MODIFIER ET COMPLETER ! ]
		GO

	 -- PREFERENCES DU CLIENTS
		-- CUISSON DES VIANDES
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('VIANDE','Tartate','');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('VIANDE','Bleu','');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('VIANDE','Saignant','');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('VIANDE','A point','');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('VIANDE','Bien cuit','');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('VIANDE','Griller','');
		-- ... [ A MODIFIER ET COMPLETER SI BESOIN EST ! ]
		GO
		-- CUISSON DES POISSONS
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('POISSON','Micro-ondes','1 à 2,5 min');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('POISSON','Vapeur','5 à 6 min');	
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('POISSON','Pocher','6 à 8 min');			
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('POISSON','Griller','3 à 4 min / coté');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('POISSON','Frire','6 à 8 min');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('POISSON','Meunière','7 à 10 min');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('POISSON','Papillote','8 à 10 min');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('POISSON','Braiser','10 min');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('POISSON','Au four','10 à 15 min');	
		-- ... [ A MODIFIER ET COMPLETER SI BESOIN EST ! ]
		GO
		-- CUISSON DES POISSONS
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('LEGUME','Eau','');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('LEGUME','Vapeur','');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('LEGUME','Friture','');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('LEGUME','Grillade','');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('LEGUME','Mijotée','');
		INSERT into Resto.PREFERENCE (Preference_Type,Preference_Libelle,Preference_Duree) values ('LEGUME','Micro-Ondes','');
		-- ... [ A MODIFIER ET COMPLETER SI BESOIN EST ! ]
		GO

		INSERT INTO [Resto].[CONFIGCOLOR]
			([ConfCol_1],[ConfFont_1],[ConfCol_2],[ConfFont_2]
			,[ConfCol_3],[ConfFont_3],[ConfCol_4],[ConfFont_4]
			,[ConfCol_5],[ConfFont_5],[ConfCol_6],[ConfFont_6]
			,[ConfCol_7],[ConfFont_7],[ConfCol_8],[ConfFont_8]
			,[ConfCol_9],[ConfFont_9],[ConfCol_10],[ConfFont_10]
			,[ConfCol_11],[ConfFont_11],[ConfCol_12],[ConfFont_12]
			,[ConfCol_13],[ConfFont_13],[ConfRandom])
		VALUES
			('-16777216','-1','-5187329','-16777216'
			,'-2752555','-16777216','-18283','-16777216'
			,'-32640','-16777216','-71','-16777216'
			,'-1','-16777216','-49602','-16777216'
			,'-11885057','-16777216','-16727808','-16777216'
			,'-32704','-16777216','-3037787','-16777216'
			,'-4144960','-16777216','false')
		GO
		--  [ NE PAS MODIFIER ! ] --