USE ServeurResto
GO

-----------------------------------------------------------------
-- Procédures généralistes permettant la récupération de clefs -- 
-- (Primaire ou Etrangère), de nom de colonne dans une table,  -- 
-- ou encore des noms de tables !							   -- 
-----------------------------------------------------------------
-- > Compatibles toutes BDD, juste changer le nom de schema !  --
-----------------------------------------------------------------

CREATE PROCEDURE [Resto].[RechercherClefs] -- V1
@NomTable  varchar(50),
@TypeClef int 
AS
IF ((@TypeClef != null) OR (@TypeClef != '') OR (@TypeClef = 0))
	BEGIN
	IF ((@NomTable != null) OR (@NomTable != ''))
		BEGIN		 -- La clef primaire de la colonne @NomTable
		SELECT       kcu.COLUMN_NAME AS 'Clef primaire' 
		FROM         INFORMATION_SCHEMA.table_constraints tc  
		INNER JOIN   INFORMATION_SCHEMA.key_column_usage kcu  
		ON           tc.CONSTRAINT_SCHEMA = kcu.CONSTRAINT_SCHEMA  
		AND          tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME  
		WHERE        tc.CONSTRAINT_TYPE = 'PRIMARY KEY'
		AND			 tc.TABLE_SCHEMA = 'Resto'			
		AND          tc.TABLE_NAME = @NomTable;	--EX : 'UTILISATEUR'
		END
	ELSE
		BEGIN		 -- Toutes les clefs primaires !
		SELECT       kcu.COLUMN_NAME AS 'Clefs primaires' 
		FROM         INFORMATION_SCHEMA.table_constraints tc  
		INNER JOIN   INFORMATION_SCHEMA.key_column_usage kcu
		ON           tc.CONSTRAINT_SCHEMA = kcu.CONSTRAINT_SCHEMA  
		AND          tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME  
		WHERE        tc.CONSTRAINT_TYPE = 'PRIMARY KEY'
		AND			 tc.TABLE_SCHEMA = 'Resto';
		END
	END
ELSE
	BEGIN
	IF ((@NomTable != null) OR (@NomTable != ''))
		BEGIN		 -- Les clefs etrangeres de la colonne @NomTable
		SELECT       kcu.COLUMN_NAME AS "Clefs etrangeres" 
		FROM         INFORMATION_SCHEMA.table_constraints tc  
		INNER JOIN   INFORMATION_SCHEMA.key_column_usage kcu  
		ON           tc.CONSTRAINT_SCHEMA = kcu.CONSTRAINT_SCHEMA  
		AND          tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME  
		WHERE        tc.CONSTRAINT_TYPE = 'FOREIGN KEY'
		AND			 tc.TABLE_SCHEMA = 'Resto'			
		AND          tc.TABLE_NAME = @NomTable;	
		END
	ELSE
		BEGIN		 -- Toutes les clefs etrangeres !
		SELECT       kcu.COLUMN_NAME AS "Clef etrangere" 
		FROM         INFORMATION_SCHEMA.table_constraints tc  
		INNER JOIN   INFORMATION_SCHEMA.key_column_usage kcu  
		ON           tc.CONSTRAINT_SCHEMA = kcu.CONSTRAINT_SCHEMA  
		AND          tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME  
		WHERE        tc.CONSTRAINT_TYPE = 'FOREIGN KEY'
		AND			 tc.TABLE_SCHEMA = 'Resto';
		END
	END
GO

CREATE PROCEDURE [Resto].[RechercherColonnes] -- v1
@NomColonne  varchar(50),
@TypeColonne int 
as
IF ((@NomColonne != null) OR (@NomColonne != ''))
	BEGIN
	IF (@TypeColonne = 0)
		BEGIN		-- La Colonne
		SELECT		COLONNES.name AS 'Colonne'
		FROM		dbo.syscolumns AS COLONNES
		INNER JOIN	dbo.systypes AS TYPES ON TYPES.xtype = COLONNES.xtype
		INNER JOIN	dbo.sysobjects AS TABLES ON TABLES.ID = COLONNES.ID
		WHERE 		TABLES.xtype = 'U' 
		AND			TABLES.name = @NomColonne;	--EX : 'UTILISATEUR'
		END
	ELSE
		BEGIN		-- La Colonne + son Type
		SELECT		COLONNES.name AS 'Colonne', TYPES.name AS 'Type'
		FROM		dbo.syscolumns AS COLONNES
		INNER JOIN	dbo.systypes AS TYPES ON TYPES.xtype = COLONNES.xtype
		INNER JOIN	dbo.sysobjects AS TABLES ON TABLES.ID = COLONNES.ID
		WHERE 		TABLES.xtype = 'U' 
		AND			TABLES.name = @NomColonne;
		END
	END
ELSE				-- SINON ON AFFICHE TOUTES LES TABLES ET LEURS COLONNES
	BEGIN
	IF (@TypeColonne = 0)
		BEGIN		-- Les Tables +	leurs Colonnes	
		SELECT 		TABLES.name AS 'Table', COLONNES.name AS 'Colonne'
		FROM		dbo.syscolumns AS COLONNES
		INNER JOIN 	dbo.sysobjects AS TABLES ON TABLES.ID = COLONNES.ID
		INNER JOIN 	dbo.systypes AS TYPES ON TYPES.xtype = COLONNES.xtype
		WHERE 		TABLES.xtype = 'U'
		ORDER BY	TABLES.name;
		END
	ELSE
		BEGIN		-- Les Tables +	leurs Colonnes + le Type de données de chaque colonnes
		SELECT 		TABLES.name AS 'Table', COLONNES.name AS 'Colonne', TYPES.name AS 'Type'
		FROM		dbo.syscolumns AS COLONNES
		INNER JOIN 	dbo.sysobjects AS TABLES ON TABLES.ID = COLONNES.ID
		INNER JOIN 	dbo.systypes AS TYPES ON TYPES.xtype = COLONNES.xtype
		WHERE 		TABLES.xtype = 'U'
		ORDER BY	TABLES.name;
		END
	END
GO

CREATE PROCEDURE [Resto].[RechercherTables] -- v1
as
	BEGIN
		SELECT 		TABLES.name AS "Tables"
		FROM		dbo.sysobjects AS TABLES
		WHERE 		TABLES.xtype = 'U'
		ORDER BY	TABLES.name;
	END
GO


-------------------------------------------------------
-- Procédure pour l'authentification à l'application --
-------------------------------------------------------

CREATE PROCEDURE [Resto].[Authentification] -- V1
@pseudo varchar(50),
@password varchar(50)
AS
	BEGIN
		SELECT ID_User, User_Pseudo, User_Password,User_NomReel, User_PrenomReel, Role_NiveauDroits
		FROM Resto.UTILISATEUR U
		INNER JOIN Resto.ROLE R on U.ID_Role = R.ID_Role
		WHERE User_Pseudo = @pseudo
		AND User_Password = @password;
	END
GO

------------------------------------------------
-- Procédure d'affichage pour le DataGridView --
------------------------------------------------

CREATE PROCEDURE [Resto].[Affichage_DataGridView] -- V1
as
	SELECT [User_Pseudo]as 'Pseudo',[User_Password] as 'Mot de Passe',[User_NomReel] as 'Nom',[User_PrenomReel] as 'Prénom', [User_Telephone] as 'N° téléphone',[Role_Libelle] as 'Rôle'
	FROM Resto.UTILISATEUR U
	INNER JOIN Resto.ROLE R on U.ID_Role = R.ID_Role
	WHERE [Role_NiveauDroits] Between 1 AND 3;
GO

ALTER procedure [Resto].[Affichage_DataGridView] -- V2
	@Table		varchar(50)			--(TABLE)
AS
	DECLARE @SQL VARCHAR(255) ;
	BEGIN
		IF(@Table = NULL) --(REQUETE INVALIDE)
			BEGIN
				ROLLBACK
		END
		ELSE
			BEGIN
			SET @SQL = 'SELECT * FROM [Resto].['+ @Table +'] ;';
			EXEC (@SQL) ;
		END
	END
GO

----------------------------------------------------------------
-- Procédure de recherche pour le DGV à partir du CU_Recheche --
----------------------------------------------------------------

CREATE PROCEDURE [Resto].[Rechercher] -- V1
	@Table		varchar(50),			--(TABLE : le label invisible)
	@Attribut	varchar(50),			--(COMBOBOX : pseudo, nom, prenom, carte, menu, etc...)
	@Recherche	varchar(50)				--(TEXTBOX : la recherche)
AS
	DECLARE @SQL VARCHAR(255) ;

	BEGIN
		IF(@Recherche = NULL OR @Attribut = NULL OR @Table = NULL) --(REQUETE INVALIDE)
			BEGIN
				ROLLBACK
			END
		ELSE
			BEGIN
				SET @SQL = 'SELECT * FROM [Resto].['+ @Table +'] WHERE '+ @Attribut +' LIKE ''%' + @Recherche + '%'';';
				EXEC (@SQL) ;
			END
	END
GO

---------------------------------------------------------------------------------
-- Procédure d'affichage dans les TextBox à partir d'une sélection dans le DGV --
---------------------------------------------------------------------------------

CREATE PROCEDURE [Resto].[SelectLineDGV] -- V1
	@Table		varchar(50),			--(TABLE : le label invisible)
	@Attribut	varchar(50),			--(COMBOBOX : pseudo, nom, prenom, carte, menu, etc...)
	@Recherche	varchar(50)				--(TEXTBOX : la recherche)
AS
	DECLARE @SQL VARCHAR(255) ;
	BEGIN

		IF(@Recherche = NULL OR @Attribut = NULL OR @Table = NULL) --(REQUETE INVALIDE)
			BEGIN
				ROLLBACK
			END
		ELSE
			BEGIN
				SET @SQL = 'SELECT * FROM [Resto].['+ @Table +'] WHERE '+ @Attribut +' = ''' + @Recherche + ''';';
				EXEC (@SQL);
			END
	END
GO

---------------------------------------------------------------------------------------
------------- 			PARTIE SERVEUR - Creation des boutons 			---------------
---------------------------------------------------------------------------------------
-- Procédure permettant la selection de la catégorie d'articles disponibles demandée --
---------------------------------------------------------------------------------------

CREATE PROCEDURE [Resto].[ArticlesDisponibles] -- V2
	@Button		int, --varchar(50)				-- (Nom du Boutton)
	@Critere	int
AS
	BEGIN

		IF(@Button = NULL) 						--(REQUETE INVALIDE)
			BEGIN
				ROLLBACK
			END
		ELSE
			BEGIN
				IF (@Button = 0) -- BOISSONS	
					SELECT * FROM [Resto].[CARTE] WHERE ID_Type = @Critere AND Article_Disponible = 1;
				IF (@Button = 1) -- CARTE	
					SELECT * FROM [Resto].[CARTE] WHERE ID_Type != @Critere AND ID_Type != 1 AND Article_Disponible = 1;
				IF (@Button = 2) -- TOUT LES MENUS
				BEGIN		
					SELECT M.ID_Menu, Menu_Disponible, Menu_Libelle, Menu_DateAjout, Menu_PrixTTC FROM MENU M 
					WHERE Menu_Disponible = 1;
				END
				IF (@Button = 3) -- MENU UNIQUE (UN SEUL MENU DISPO)
				BEGIN		
					SELECT * FROM MENU M 
					INNER JOIN Resto.REL_Composer C ON M.ID_Menu = C.ID_Menu 
					INNER JOIN Resto.CARTE A ON C.ID_Article = A.ID_Article
					WHERE Menu_Disponible = 1
					ORDER BY C.Composer_Type;
				END
				IF (@Button = 4) -- MENU CIBLE (PLUSIEURS MENUS DISPO)
				BEGIN		
					SELECT * FROM MENU M 
					INNER JOIN Resto.REL_Composer C ON M.ID_Menu = C.ID_Menu 
					INNER JOIN Resto.CARTE A ON C.ID_Article = A.ID_Article
					WHERE Menu_Disponible = 1 AND M.ID_Menu = @Critere
					ORDER BY C.Composer_Type;
				END
			END
	END
GO

----------------------------------------------------
-- Compte le nombre de menu des menus disponibles --
----------------------------------------------------

CREATE PROCEDURE [Resto].[MenusDispoCount] -- V1
AS 
	BEGIN
		SELECT COUNT(*) FROM MENU WHERE Menu_Disponible = 1; 
	END
GO

---------------------------------------------------
-- Récupère le 1er du menu des menus disponibles --
---------------------------------------------------

CREATE PROCEDURE [Resto].[MenusDispoLibelle] -- V1
AS 
	BEGIN
		SELECT TOP 1 ID_Menu, Menu_Libelle FROM MENU WHERE Menu_Disponible = 1; 
	END

GO

CREATE PROCEDURE [Resto].[Color_Insert] -- V1
  @ConfCol_1	VARCHAR (50), @ConfFont_1	VARCHAR (50)
, @ConfCol_2	VARCHAR (50), @ConfFont_2	VARCHAR (50)
, @ConfCol_3	VARCHAR (50), @ConfFont_3	VARCHAR (50)
, @ConfCol_4	VARCHAR (50), @ConfFont_4	VARCHAR (50)
, @ConfCol_5	VARCHAR (50), @ConfFont_5	VARCHAR (50)
, @ConfCol_6	VARCHAR (50), @ConfFont_6	VARCHAR (50)
, @ConfCol_7	VARCHAR (50), @ConfFont_7	VARCHAR (50)
, @ConfCol_8	VARCHAR (50), @ConfFont_8	VARCHAR (50)
, @ConfCol_9	VARCHAR (50), @ConfFont_9	VARCHAR (50)
, @ConfCol_10	VARCHAR (50), @ConfFont_10	VARCHAR (50)
, @ConfCol_11	VARCHAR (50), @ConfFont_11	VARCHAR (50)
, @ConfCol_12	VARCHAR (50), @ConfFont_12	VARCHAR (50)
, @ConfCol_13	VARCHAR (50), @ConfFont_13	VARCHAR (50)
, @Random		VARCHAR (50)
AS
	BEGIN
		IF EXISTS (SELECT ID_ConfCol FROM [Resto].[CONFIGCOLOR] WHERE ID_ConfCol = '1')
		BEGIN
			UPDATE [Resto].[CONFIGCOLOR] 
			SET
			ConfCol_1  = @ConfCol_1 , ConfFont_1  = @ConfFont_1, 
			ConfCol_2  = @ConfCol_2 , ConfFont_2  = @ConfFont_2, 
			ConfCol_3  = @ConfCol_3 , ConfFont_3  = @ConfFont_3, 
			ConfCol_4  = @ConfCol_4 , ConfFont_4  = @ConfFont_4, 
			ConfCol_5  = @ConfCol_5 , ConfFont_5  = @ConfFont_5, 
			ConfCol_6  = @ConfCol_6 , ConfFont_6  = @ConfFont_6, 
			ConfCol_7  = @ConfCol_7 , ConfFont_7  = @ConfFont_7, 
			ConfCol_8  = @ConfCol_8 , ConfFont_8  = @ConfFont_8, 
			ConfCol_9  = @ConfCol_9 , ConfFont_9  = @ConfFont_9, 
			ConfCol_10 = @ConfCol_10, ConfFont_10 = @ConfFont_10, 
			ConfCol_11 = @ConfCol_11, ConfFont_11 = @ConfFont_11, 
			ConfCol_12 = @ConfCol_12, ConfFont_12 = @ConfFont_12, 
			ConfCol_13 = @ConfCol_13, ConfFont_13 = @ConfFont_13,
			ConfRandom = @Random
			WHERE [ID_ConfCol] = 1;
		END
		ELSE
		BEGIN
			DBCC CHECKIDENT ('Resto.CONFIGCOLOR', RESEED, 0);
			INSERT INTO [Resto].[CONFIGCOLOR]
           ([ConfCol_1],[ConfFont_1],[ConfCol_2],[ConfFont_2]
           ,[ConfCol_3],[ConfFont_3],[ConfCol_4],[ConfFont_4]
           ,[ConfCol_5],[ConfFont_5],[ConfCol_6],[ConfFont_6]
           ,[ConfCol_7],[ConfFont_7],[ConfCol_8],[ConfFont_8]
           ,[ConfCol_9],[ConfFont_9],[ConfCol_10],[ConfFont_10]
           ,[ConfCol_11],[ConfFont_11],[ConfCol_12],[ConfFont_12]
           ,[ConfCol_13],[ConfFont_13], [ConfRandom])
			VALUES
		   (@ConfCol_1 , @ConfFont_1, @ConfCol_2 , @ConfFont_2, 
			@ConfCol_3 , @ConfFont_3, @ConfCol_4 , @ConfFont_4, 
			@ConfCol_5 , @ConfFont_5, @ConfCol_6 , @ConfFont_6, 
			@ConfCol_7 , @ConfFont_7, @ConfCol_8 , @ConfFont_8, 
			@ConfCol_9 , @ConfFont_9, @ConfCol_10, @ConfFont_10, 
			@ConfCol_11, @ConfFont_11, @ConfCol_12, @ConfFont_12, 
			@ConfCol_13, @ConfFont_13, @Random);
		END
	END
GO

----------------------------------------------------------------
-------------- Partie Admin - Gestion Utilisateur --------------
----------------------------------------------------------------
		  -- Procédure d'insertion d'un utilisateur --
		  --------------------------------------------

CREATE procedure [Resto].[Utilisateur_Insert] -- V1
@pseudo varchar(50),
@pass varchar(50),
@nom varchar(50),
@prenom varchar(50),
@tel char(10) = null,
@role varchar(50)
AS
	Insert into [Resto].[UTILISATEUR](User_Pseudo, User_Password, User_NomReel, User_PrenomReel, User_Telephone, ID_Role)
	values (@pseudo, @pass, @nom, @prenom, @tel, @role);
GO

ALTER PROCEDURE [Resto].[Utilisateur_Insert] -- V2
@pseudo varchar(50),
@pass varchar(50),
@nom varchar(50),
@prenom varchar(50),
@tel char(10) = null,
@role varchar(50)
AS
	BEGIN
		INSERT INTO [Resto].[UTILISATEUR](User_Pseudo, User_Password, User_NomReel, User_PrenomReel, User_Telephone, ID_Role)
		VALUES (@pseudo, @pass, @nom, @prenom, @tel, (SELECT ID_Role FROM Resto.ROLE WHERE Role_Libelle = ''+@role+''));
	END
GO

------------------------------------------------
-- Procédure de modification d'un utilisateur --
------------------------------------------------

CREATE PROCEDURE [Resto].[Utilisateur_Update]  -- V1
@id int,@pseudo varchar(50), 
@pass varchar(50),@nom varchar(50), 
@prenom varchar(50),@tel char(10), 
@role varchar(50)
AS
	update [Resto].[UTILISATEUR] SET
		User_Pseudo = @pseudo, User_Password = @pass, 
		User_NomReel = @nom, User_PrenomReel = @prenom, 
		User_Telephone = @tel, ID_Role = @role
	where
		ID_User = @id;
GO

ALTER PROCEDURE [Resto].[Utilisateur_Update] -- V2
@id int,@pseudo varchar(50), 
@pass varchar(50),@nom varchar(50), 
@prenom varchar(50),@tel char(10), 
@role varchar(50)
AS
	BEGIN
		UPDATE [Resto].[UTILISATEUR] SET
			User_Pseudo = @pseudo, User_Password = @pass, 
			User_NomReel = @nom, User_PrenomReel = @prenom, 
			User_Telephone = @tel, ID_Role = (SELECT ID_Role FROM Resto.ROLE WHERE Role_Libelle = ''+@role+'')
		WHERE
			ID_User = @id;
	END
GO

-------------------------------------
-- Procédure d'affichage d'un Role --
-------------------------------------

CREATE PROCEDURE [Resto].[Role_Affichage] -- V1
AS
	BEGIN
		SELECT *
		FROM Resto.ROLE;
	END
GO

ALTER PROCEDURE [Resto].[Role_Affichage] -- V2
AS
	BEGIN
		SELECT *
		FROM Resto.ROLE
		ORDER BY 3;
	END
GO

-------------------------------------
-- Procédure d'insertion d'un Role --
-------------------------------------

CREATE PROCEDURE [Resto].[Role_Insert] -- V1
@libelle varchar(50),
@niveau varchar (3)
AS
	BEGIN
		INSERT INTO [Resto].[ROLE](Role_Libelle, Role_NiveauDroits)
		VALUES (@libelle,@niveau);
	END
GO

-----------------------------------------
-- Procédure de modification d'un Role --
-----------------------------------------

CREATE PROCEDURE [Resto].[Role_Update] -- V1
@id varchar (3),
@libelle varchar(50),
@niveau varchar (3)
AS
	BEGIN
		UPDATE [Resto].[ROLE] SET
			Role_Libelle = @libelle,
			Role_NiveauDroits = @niveau
		WHERE
			ID_Role = @id;
	END
GO

-----------------------------------------------------------------
-------------- Partie Admin - Gestion des commande --------------
-----------------------------------------------------------------
			   -- Affichage pour le DataGridView --
			   ------------------------------------

CREATE procedure [Resto].[Affichage_DGV_RELCommander] -- V1
	@Date		Datetime,			--(TABLE)
	@Valeur		int
AS
	BEGIN
		IF(@Date = NULL OR @Valeur = NULL) --(REQUETE INVALIDE)
			BEGIN
				ROLLBACK
			END
		ELSE
			BEGIN
			IF (@Valeur = 0)
				BEGIN
					SELECT C.ID_Facture, U.User_Pseudo, F.Facture_DateCrea, F.Facture_Validee, 
						F.Facture_Cloturee, F.Facture_Modifiee, C.ID_Article, A.Article_Nom, 
						C.ID_Menu, C.Nbr_Article, C.Preference_Type, C.Voir_Serveur, 
						C.Article_offert, A.Article_PrixHT
						FROM [Resto].[REL_Commander] C
						INNER JOIN [Resto].[CARTE] A ON C.ID_Article = A.ID_Article
						INNER JOIN [Resto].[FACTURE] F ON C.ID_Facture = F.ID_Facture
						INNER JOIN [Resto].[UTILISATEUR] U ON F.ID_User = U.ID_User
						WHERE F.Facture_DateCrea BETWEEN ''+@Date-1+' 00:00:00' AND ''+@Date+' 23:59:59'
						ORDER BY C.ID_Facture DESC;
				END
			ELSE
				BEGIN
					SELECT C.ID_Facture, U.User_Pseudo, F.Facture_DateCrea, F.Facture_Validee, 
						F.Facture_Cloturee, F.Facture_Modifiee, C.ID_Article, A.Article_Nom, 
						C.ID_Menu, C.Nbr_Article, C.Preference_Type, C.Voir_Serveur, 
						C.Article_offert, A.Article_PrixHT
						FROM [Resto].[REL_Commander] C
						INNER JOIN [Resto].[CARTE] A ON C.ID_Article = A.ID_Article
						INNER JOIN [Resto].[FACTURE] F ON C.ID_Facture = F.ID_Facture
						INNER JOIN [Resto].[UTILISATEUR] U ON F.ID_User = U.ID_User
						WHERE C.ID_Facture = @Valeur
						ORDER BY C.ID_Facture DESC ;
				END
			END
	END
GO

------------------------------------------------
-- Affiche les articles commandés dans le DGV --
------------------------------------------------

CREATE PROCEDURE [Resto].[Commander_Recherche] -- v1
@idFacture int
AS
	BEGIN
		SELECT ID_Facture, ID_Menu, C.ID_Article, Nbr_Article, Preference_Type, Voir_Serveur, Article_offert, [Article_Nom], [Article_PrixHT]
		FROM [Resto].[REL_Commander] C
		INNER JOIN [Resto].[CARTE] A ON C.ID_Article = A.ID_Article
		WHERE ID_Facture = @idFacture;
	END
GO

ALTER PROCEDURE [Resto].[Commander_Recherche] -- v2
@idFacture int
AS
	BEGIN
		SELECT [ID_Facture], C.[ID_Menu], [Menu_Libelle], C.[ID_Article], [Nbr_Article], [Preference_Type], [Voir_Serveur], [Article_offert], [Article_Nom], [Article_PrixHT], [ID_Type], [TVA_Taux], [Menu_PrixTTC]
		FROM [Resto].[REL_Commander] C
		INNER JOIN [Resto].[CARTE] A ON C.ID_Article = A.ID_Article
		INNER JOIN [Resto].[MENU] M ON C.ID_Menu = M.ID_Menu
		INNER JOIN [Resto].[TVA] T ON A.ID_TVA = T.ID_TVA
		WHERE ID_Facture = @idFacture
		ORDER BY ID_Menu,C.ID_Article;
	END
GO


CREATE PROCEDURE [Resto].[Commander_Select] -- v1
@Valeur int
AS
	DECLARE @SQL VARCHAR(255) ;
	BEGIN
		IF(@Valeur = NULL) --(REQUETE INVALIDE)
			BEGIN
				ROLLBACK
			END
		ELSE
			BEGIN
				SELECT 
				F.ID_Facture, U.User_Pseudo, F.Facture_TableNum, F.Facture_NbrCouvert, 
				F.Facture_DateCrea, F.Facture_Modifiee, F.Facture_DateModif,		
				SUM(C.Nbr_Article), COUNT(DISTINCT(C.ID_Menu)), F.Facture_PrixTotalTTC,
				F.Facture_Validee, F.Facture_Cloturee	
					
				FROM [Resto].REL_Commander C
				INNER JOIN [Resto].[FACTURE] F ON C.ID_Facture = F.ID_Facture
				INNER JOIN [Resto].[UTILISATEUR] U ON F.ID_User = U.ID_User

				WHERE C.ID_Facture = @Valeur

				GROUP BY F.ID_Facture, U.User_Pseudo, F.Facture_TableNum, F.Facture_NbrCouvert, 
				F.Facture_DateCrea, F.Facture_Modifiee, F.Facture_DateModif, 		
				F.Facture_PrixTotalTTC, F.Facture_Validee, F.Facture_Cloturee;
			END
	END
GO

-----------------------------------------------
-- Modifie une facture par l'interface admin --
-----------------------------------------------

CREATE PROCEDURE [Resto].[Commander_UpdateFac] -- v2
@idFacture int,
@NumTable int,
@NbrCouverts int,
@DateModif datetime,
@Valid varchar(10),
@Clot varchar(10)
AS
	BEGIN
		UPDATE [Resto].[FACTURE] SET
		Facture_TableNum = @NumTable,
		Facture_NbrCouvert = @NbrCouverts,
		Facture_DateModif = @DateModif,
		Facture_Modifiee = 1,
		Facture_Validee = @Valid,
		Facture_Cloturee = @Clot
		WHERE ID_Facture = @idFacture;
	END
GO

CREATE PROCEDURE [Resto].[Commander_SelectNumber] -- v1
@Valeur int
AS
	BEGIN
		IF(@Valeur = NULL) --(REQUETE INVALIDE)
			BEGIN
				ROLLBACK
			END
		ELSE
			BEGIN
				SELECT SUM(C.Nbr_Article) AS Nbr_Article, COUNT(DISTINCT(C.ID_Menu)) AS ID_Menu
				FROM [Resto].REL_Commander C
				WHERE C.ID_Facture = @Valeur;
			END
	END
GO

----------------------------------------------------------------
-------------- Partie Admin - Gestion de la Carte --------------
----------------------------------------------------------------
	-- Affichage pour la combobox TVA la liste de la TVA --
	-------------------------------------------------------

CREATE PROCEDURE [Resto].[TVA_affichage] -- V1
AS
	BEGIN
		SELECT * FROM Resto.TVA;
	END
GO

----------------------------------------------------------
-- Affichage pour la combobox TYPEPRODUIT pour sa liste --
----------------------------------------------------------

CREATE PROCEDURE [Resto].[TYPE_affichage] -- V1
AS
	BEGIN
		SELECT * FROM Resto.TYPEPRODUIT;
	END
GO

----------------------------------------------------
-- Procédure d'insertion d'un article de la carte --
----------------------------------------------------

CREATE PROCEDURE [Resto].[Carte_Insert] -- V1
@dispo varchar(10),@nom varchar (50),
@format varchar(250),@prix varchar(10),
@supplement varchar(10),@preference varchar(10),
@alcool varchar(10),@image varchar(255) =null,
@qteStock int,@type varchar(50),
@tva varchar(10)
AS
	BEGIN
		INSERT INTO [Resto].[CARTE](Article_Disponible,Article_Nom,Article_Format,Article_PrixHT,Article_Supplement,Article_Preference,Article_Alcoolise,Article_ImageURL,Article_QuantiteEnStock,ID_Type,ID_Tva)
		VALUES (@dispo,@nom,@format,@prix,@supplement,@preference,@alcool,@image,@qteStock,(SELECT ID_Type FROM Resto.TYPEPRODUIT WHERE Type_Libelle = @type),(SELECT ID_TVA FROM Resto.TVA WHERE TVA_taux = @tva));
	END
GO

-----------------------------------------------------
-- Procédure de modification d'un article de Carte --
-----------------------------------------------------

CREATE PROCEDURE [Resto].[Carte_Update] -- V1
@id int, @dispo varchar(10),
@nom varchar (50),@format varchar(250),
@prix float, @supplement varchar(10),
@preference varchar(10),@alcool varchar(10),
@image varchar(255) = null,@qteStock int,
@type varchar(50),@tva varchar(10)
AS
	BEGIN
		UPDATE [Resto].[CARTE] SET
			Article_Disponible=@dispo,
			Article_Nom=@nom,Article_Format=@format,
			Article_PrixHT=@prix,
			Article_Supplement=@supplement,
			Article_Preference=@preference,
			Article_Alcoolise=@alcool,
			Article_ImageURL=@image,
			Article_QuantiteEnStock=@qteStock,
			ID_Type=(SELECT ID_Type FROM Resto.TYPEPRODUIT WHERE Type_Libelle = @type),
			ID_Tva=(SELECT ID_TVA FROM Resto.TVA WHERE TVA_taux = @tva)
		WHERE 
			ID_Article=@id;
	END
GO

--------------------------------------------------------------
-------------- Partie Admin - Gestion des menus --------------
--------------------------------------------------------------
			-- Procédure d'insertion d'un menu --
			-------------------------------------

CREATE PROCEDURE [Resto].[Menu_Insert] -- V1
@dispo varchar(10),
@libelle varchar (100),
@date varchar (20),
@prix float
AS
	BEGIN
		INSERT INTO [Resto].[MENU](Menu_Disponible, Menu_Libelle,Menu_DateAjout,Menu_PrixTTC)
		VALUES (@dispo,@libelle,@date,@prix);
	END
GO

-----------------------------------------------------
-- Procédure de modification d'un article de Carte --
-----------------------------------------------------

CREATE PROCEDURE [Resto].[Menu_Update] -- V1
@id int,
@dispo varchar(10),
@libelle varchar (100),
@date varchar (20),
@prix float
AS
	BEGIN
		UPDATE [Resto].[MENU] SET
			Menu_Disponible = @dispo,
			Menu_Libelle = @libelle,
			Menu_DateAjout = @date,
			Menu_PrixTTC = @prix
		WHERE
			ID_Menu = @id;
	END
GO

--------------------------------------------------------------
-- Procédure d'affichage des articles d'un Menu dans le DGV --
--------------------------------------------------------------

CREATE PROCEDURE [Resto].[Composer_Affichage] -- V1
@LibelleMenu varchar(50)
AS
	BEGIN
		SELECT M.ID_Menu AS 'N° Menu', Menu_Libelle AS 'Nom Menu', Menu_PrixTTC AS 'Prix TTC Menu', Article_Nom AS 'Nom Article', Article_PrixHT AS 'Prix HT Article', Article_Disponible AS 'Article Disponible'
		FROM MENU M
		INNER JOIN Resto.REL_Composer C ON M.ID_Menu = C.ID_Menu
		INNER JOIN Resto.CARTE A ON C.ID_Article = A.ID_Article
		WHERE Menu_Libelle = @LibelleMenu
		ORDER BY Composer_Type;
	END
GO


CREATE PROCEDURE [Resto].[Composer_AffichageArticle] -- V1
@idArticle int
AS
	BEGIN
		SELECT [ID_Article],[Article_Nom],[Article_PrixHT],[Type_Libelle]
		FROM [Resto].[CARTE] C
		INNER JOIN [Resto].[TYPEPRODUIT] P ON c.ID_Type = P.ID_Type
		WHERE C.ID_Type != 2
		AND ID_Article = @idArticle;
	END
GO

----------------------------------------------
-- Procédure d'ajout d'un article à un Menu --
----------------------------------------------

CREATE PROCEDURE [Resto].[Composer_Insert] -- V1
@LibelleMenu varchar(100),
@LibelleArticle varchar(50),
@libelleType varchar (10)
AS
	BEGIN
		INSERT INTO [Resto].[REL_Composer]([ID_Menu], [ID_Article], [Composer_Type])
		VALUES 
			(
				(SELECT ID_Menu FROM Resto.MENU WHERE Menu_Libelle = @LibelleMenu),
				(SELECT ID_Article FROM Resto.CARTE WHERE Article_Nom = @LibelleArticle),
				@libelleType
			);
	END
GO

ALTER PROCEDURE [Resto].[Composer_Insert] -- V2
@idMenu varchar(100),
@idArticle int,
@libelleType varchar (10)
AS
	BEGIN
		INSERT INTO [Resto].[REL_Composer]([ID_Menu], [ID_Article], [Composer_Type])
		VALUES (@idMenu, @idArticle, @libelleType);
	END
GO

-----------------------------------------------------
-- Procédure de suppression d'un article à un Menu --
-----------------------------------------------------

CREATE PROCEDURE [Resto].[Composer_Delete] -- V1
@LibelleMenu varchar(100),
@LibelleArticle varchar(50)
AS
	BEGIN
		DELETE FROM [Resto].[REL_Composer]
		WHERE 
			[ID_Menu] = (SELECT ID_Menu FROM Resto.MENU WHERE Menu_Libelle = @LibelleMenu) 
			AND 
			[ID_Article] = (SELECT ID_Article FROM Resto.CARTE WHERE Article_Nom = @LibelleArticle);
	END
GO

ALTER PROCEDURE [Resto].[Composer_Delete] -- V2
@idMenu varchar(100),
@idArticle varchar(50)
AS
	BEGIN
		DELETE FROM [Resto].[REL_Composer]
		WHERE 
			[ID_Menu] = @idMenu
		AND 
			[ID_Article] = @idArticle;
	END
GO

-----------------------------------------------------------
-- Procédure de comptage de ligne d'un article à un Menu --
-----------------------------------------------------------

CREATE PROCEDURE [Resto].[Composer_Comptage] -- V1
@LibelleMenu varchar(100),
@LibelleArticle varchar(50)
AS
	DECLARE @SQL VARCHAR(255);
	BEGIN
		SET @SQL = 'SELECT *
		FROM [Resto].[REL_Composer]
		WHERE 			
			[ID_Menu] IN (SELECT ID_Menu FROM Resto.MENU WHERE Menu_Libelle = '''+@LibelleMenu+''')
		AND
			[ID_Article] IN (SELECT ID_Article FROM Resto.CARTE WHERE Article_Nom = '''+@LibelleArticle+''');'
		EXEC (@SQL);
	END
GO

--------------------------------------------------------
-- Procédure d'affichage des libellés pour la facture --
--------------------------------------------------------

CREATE PROCEDURE [Resto].[ConfigFac_Insert] -- v1
@FontSizeTitle int,
@FontSizeMax int,
@FontSizeNor int,
@FontSizeMin int,
@LibTitle varchar(250),
@LibDesc varchar(250),
@LibAdresse varchar(250),
@LibNumTel varchar(250),
@LibThanks varchar(250),
@LibMention varchar(250)
AS
	BEGIN
	IF EXISTS (SELECT ID_ConfigFac FROM [Resto].[CONFIGFACTURE] WHERE ID_ConfigFac = '1')
		BEGIN
		UPDATE [Resto].[CONFIGFACTURE] SET
		ConfigFac_FontSizeTitle = @FontSizeTitle,
		ConfigFac_FontSizeMax = @FontSizeMax,
		ConfigFac_FontSizeNor = @FontSizeNor,
		ConfigFac_FontSizeMin = @FontSizeMin,
		ConfigFac_LibTitle = @LibTitle,
		ConfigFac_LibDesc = @LibDesc,
		ConfigFac_LibAdresse = @LibAdresse,
		ConfigFac_LibNumTel = @LibNumTel,
		ConfigFac_LibThanks = @LibThanks,
		ConfigFac_LibMention = @LibMention
		WHERE ID_ConfigFac = 1;
		END
	ELSE
		BEGIN
		DBCC CHECKIDENT ('Resto.CONFIGFACTURE', RESEED, 0);
		INSERT INTO [Resto].[CONFIGFACTURE]
		(ConfigFac_FontSizeTitle, ConfigFac_FontSizeMax , 
		 ConfigFac_FontSizeNor , ConfigFac_FontSizeMin , 
		 ConfigFac_LibTitle , ConfigFac_LibDesc , 
		 ConfigFac_LibAdresse , ConfigFac_LibNumTel , 
		 ConfigFac_LibThanks , ConfigFac_LibMention)
		VALUES
		(@FontSizeTitle , @FontSizeMax , @FontSizeNor , @FontSizeMin , 
		 @LibTitle , @LibDesc , @LibAdresse , 
		 @LibNumTel , @LibThanks , @LibMention);
		END
	END
GO

------------------------
-- Partie Facturation --
------------------------
------- Insert ---------
------------------------

CREATE PROCEDURE [Resto].[Facture_Insert] -- v1
@dateCrea datetime,
@table int,
@couvert int,
@idUser int
AS
	BEGIN
		BEGIN
			INSERT INTO [Resto].[FACTURE](Facture_DateCrea, Facture_TableNum, Facture_NbrCouvert, Facture_PrixTotalTTC, Facture_Validee, Facture_Cloturee, Facture_Modifiee, Facture_DateModif, ID_User)
			VALUES (@dateCrea, @table, @couvert, 0.0, 0, 0, 0, @dateCrea, @idUser);
		END
		BEGIN
			SELECT ID_Facture
			FROM [Resto].[FACTURE]
			WHERE
				[Facture_DateCrea] = @dateCrea
			AND
				[ID_User] = @idUser;
		END
	END
GO

-------------------------------------------
-- Cherche si une table est déjà utilisé --
-------------------------------------------

CREATE PROCEDURE [Resto].[Facture_checkTable] -- v1
@table int,
@date datetime
AS
	BEGIN
		SELECT count(*)
		FROM [Resto].[FACTURE]
		WHERE
			[Facture_TableNum] = @table
		AND 
			year([Facture_DateCrea]) = year(@date)
		AND
			month([Facture_DateCrea]) = month(@date)
		AND
			day([Facture_DateCrea]) = day(@date)
		AND
			[Facture_Cloturee] = 0
	END
GO

---------------------------------------------------
-- Modifie le nombre de couvert dans une facture --
---------------------------------------------------

CREATE PROCEDURE [Resto].[Facture_UpdateCouvert] -- v1
@idFacture int,
@Couvert int
AS
	BEGIN
		UPDATE [Resto].[FACTURE] SET
			[Facture_NbrCouvert] = @Couvert
		WHERE
			[ID_Facture] = @idFacture;
	END
GO

--------------------------------------
-- Modifie les états de la commande --
--------------------------------------

CREATE PROCEDURE [Resto].[Facture_AValider] -- V1
@attribut varchar (50),
@id varchar (10)
AS
	BEGIN
		IF (@attribut = 'Facture_Validee')
		BEGIN
			UPDATE Resto.FACTURE SET Facture_Validee = 1 WHERE ID_Facture = @id;
		END
		IF (@attribut = 'Facture_Cloturee')
		BEGIN
			UPDATE Resto.FACTURE SET Facture_Cloturee = 1 WHERE ID_Facture = @id;
		END
	END
GO

ALTER PROCEDURE [Resto].[Facture_AValider] -- v2
@attribut varchar (50),
@id varchar (10),
@valeur bit
AS
	BEGIN
		IF (@attribut = 'Facture_Validee')
		BEGIN
			UPDATE Resto.FACTURE SET Facture_Validee = @valeur WHERE ID_Facture = @id;
		END
		IF (@attribut = 'Facture_Cloturee')
		BEGIN
			UPDATE Resto.FACTURE SET Facture_Cloturee = 1 WHERE ID_Facture = @id;
		END
	END
GO

---------------------------------------------------------------------
-- Clôture toutes les factures déjà validées par l'interface admin --
---------------------------------------------------------------------

CREATE PROCEDURE [Resto].[Commander_UpdateAllFac] -- v1
@DateModif datetime
AS
	BEGIN
		UPDATE [Resto].[FACTURE] SET
		Facture_DateModif = @DateModif,
		Facture_Modifiee = 1,
		Facture_Cloturee = 1
		WHERE Facture_Cloturee = 0
		AND Facture_Validee = 1;
	END
GO

------------------------------------------------------------------------
-- Modifie le prix de la facture lors de la validation de la commande --
------------------------------------------------------------------------

CREATE PROCEDURE [Resto].[Facture_UpdatePrixTotal] -- v1
@idFacture int,
@prixTotal float
AS
	BEGIN
		UPDATE [Resto].[FACTURE] SET
			[Facture_PrixTotalTTC] = @prixTotal
		WHERE
			[ID_Facture] = @idFacture
	END
GO

--------------------------------------
-- Affichage des Commandes du jours --
--------------------------------------

CREATE PROCEDURE [Resto].[Commande_Affichage]
@id int,
@date datetime
AS
	BEGIN
		SELECT *
		FROM [Resto].[FACTURE]
		WHERE 
			ID_User = @id
		AND
			Facture_DateCrea BETWEEN ''+@date+' 00:00:00' AND ''+@date+' 23:59:59';
	END
GO

ALTER PROCEDURE [Resto].[Commande_Affichage] -- v2
@id int,
@date datetime
AS
	BEGIN
		SELECT *
		FROM [Resto].[FACTURE]
		WHERE 
			ID_User = @id
		AND
			Facture_DateCrea BETWEEN ''+@date+' 00:00:00' AND ''+@date+' 23:59:59'
		AND
			[Facture_Cloturee] = 'false';
	END
GO

ALTER PROCEDURE [Resto].[Commande_Affichage] -- v3
@idUser int,
@droit int,
@date datetime
AS
	BEGIN
	IF (@droit >= 1 AND @droit <= 2)
		BEGIN
			SELECT *
			FROM [Resto].[FACTURE]
			WHERE 
				Facture_DateCrea BETWEEN ''+@date+' 00:00:00' AND ''+@date+' 23:59:59'
			AND
				[Facture_Cloturee] = 'false';
		END
	ELSE
		BEGIN
			SELECT *
			FROM [Resto].[FACTURE]
			WHERE 
				ID_User = @idUser
			AND
				Facture_DateCrea BETWEEN ''+@date+' 00:00:00' AND ''+@date+' 23:59:59'
			AND
				[Facture_Cloturee] = 'false';
		END
	END
GO

------------------------------
-- Insertion d'une commande --
------------------------------

CREATE PROCEDURE [Resto].[Commander_Insert] -- v1
@idFacture int,
@idCarte int,
@idMenu int,
@qte int,
@pref varchar(50),
@serveur bit,
@offert bit,
@insert bit
AS
	BEGIN
		INSERT INTO [Resto].[REL_Commander]([ID_Facture],[ID_Article],[ID_Menu],[Nbr_Article],[Preference_Type],[Voir_Serveur],[Article_offert])
		VALUES (@idFacture, @idCarte, @idMenu, @qte, @pref, @serveur, @offert);
	END
GO

---------------------------------
-- Insert ou modifie une ligne --
---------------------------------

ALTER PROCEDURE [Resto].[Commander_Insert] -- v2
@idFacture int,
@idCarte int,
@idMenu int,
@qte int,
@pref varchar(50),
@serveur bit,
@offert bit,
@insert bit
AS
	IF (@insert = 1)
	BEGIN
		BEGIN
			INSERT INTO [Resto].[REL_Commander]([ID_Facture],[ID_Article],[ID_Menu],[Nbr_Article],[Preference_Type],[Voir_Serveur],[Article_offert])
			VALUES (@idFacture, @idCarte, @idMenu, @qte, @pref, @serveur, @offert);
		END
	END
	ELSE
	BEGIN
		UPDATE [Resto].[REL_Commander] SET
			[Nbr_Article] = @qte,
			[Preference_Type] = @pref,
			[Voir_Serveur] = @serveur,
			[Article_offert] = @offert
		WHERE
			[ID_Facture] = @idFacture
		AND
			[ID_Article] = @idCarte
		AND
			[ID_Menu] = @idMenu;
	END
GO

--------------------------------------------------------------
-- Modifie la qte ou supprime les articles dans une facture --
--------------------------------------------------------------

CREATE PROCEDURE [Resto].[Commander_Qte] -- v1
@idFacture int,
@idCarte int,
@idMenu int,
@qte int
AS
	BEGIN
		IF (@qte != 0)
		BEGIN
			UPDATE [Resto].[REL_Commander] SET
				[Nbr_Article] = @qte
			WHERE
				[ID_Facture] = @idFacture
			AND
				[ID_Article] = @idCarte
			AND
				[ID_Menu] = @idMenu;
		END
		ELSE
		BEGIN
			DELETE FROM [Resto].[REL_Commander]
			WHERE
				[ID_Facture] = @idFacture
			AND
				[ID_Article] = @idCarte
			AND
				[ID_Menu] = @idMenu;
		END
	END
GO

ALTER PROCEDURE [Resto].[Commander_Qte] -- v2
@idFacture int,
@idCarte int,
@idMenu int,
@qte int,
@gratuit bit
AS
	BEGIN
		IF (@qte != 0)
		BEGIN
			UPDATE [Resto].[REL_Commander] SET
				[Nbr_Article] = @qte
			WHERE
				[ID_Facture] = @idFacture
			AND
				[ID_Article] = @idCarte
			AND
				[ID_Menu] = @idMenu
			AND
				[Article_offert] = @gratuit;
		END
		ELSE
		BEGIN
			DELETE FROM [Resto].[REL_Commander]
			WHERE
				[ID_Facture] = @idFacture
			AND
				[ID_Article] = @idCarte
			AND
				[ID_Menu] = @idMenu
			AND
				[Article_offert] = @gratuit;
		END
	END
GO

---------------------------------------------------------
-- Recherche les articles enregistrer dans une facture --
---------------------------------------------------------

CREATE PROCEDURE [Resto].[Commander_Recherche] -- v1
@idFacture int
AS
	BEGIN
		SELECT ID_Facture, ID_Menu, C.ID_Article, Nbr_Article, Preference_Type, Voir_Serveur, Article_offert, Article_Nom, Article_PrixHT
		FROM [Resto].[REL_Commander] C
		INNER JOIN [Resto].[CARTE] A ON C.ID_Article = A.ID_Article
		WHERE ID_Facture = @idFacture;
	END
GO

ALTER PROCEDURE [Resto].[Commander_Recherche] -- v2
@idFacture int
AS
	BEGIN
		SELECT [ID_Facture], [C.ID_Menu], [Menu_Libelle], [C.ID_Article], [Nbr_Article], [Preference_Type], [Voir_Serveur], [Article_offert], [Article_Nom], [Article_PrixHT], [ID_Type], [TVA_Taux]
		FROM [Resto].[REL_Commander] C
		INNER JOIN [Resto].[CARTE] A ON C.ID_Article = A.ID_Article
		INNER JOIN [Resto].[MENU] M ON C.ID_Menu = M.ID_Menu
		INNER JOIN [Resto].[TVA] T ON A.ID_TVA = T.ID_TVA
		WHERE ID_Facture = @idFacture
		ORDER BY ID_Menu,C.ID_Article;
	END

-----------------------------------------------------------------
-- Compte le nombre de ligne de la Facture N et de l'article M --
-----------------------------------------------------------------

CREATE PROCEDURE [Resto].[Commander_Nbligne] -- V1
@idFacture int,
@idMenu int,
@labelArticle varchar(50)
AS
	BEGIN
		SELECT COUNT(*)
		FROM [Resto].[REL_Commander]
		WHERE 
			ID_Facture = @idFacture
		AND
			ID_Article IN	(	
								SELECT	ID_Article 
								FROM	[Resto].[CARTE] 
								WHERE	[Article_Nom]	= ''+@labelArticle+''
								AND		[ID_Menu]		= ''+@idMenu+''
							);
	END
GO

ALTER PROCEDURE [Resto].[Commander_Nbligne] -- V2
@idFacture int,
@idMenu int,
@idArticle int,
@gratuit bit
AS
	BEGIN
		SELECT COUNT(*)
		FROM [Resto].[REL_Commander]
		WHERE 
			ID_Facture = @idFacture
		AND
			ID_Article = @idArticle
		AND
			ID_Menu = @idMenu
		AND
			Article_offert = @gratuit
	END
GO

