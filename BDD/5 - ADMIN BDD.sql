-----------------------------------------
-- CREATION DE L'UTILISATEUR SQLSERVER --
-----------------------------------------
	-- CREATION DES LOGINS --
	-------------------------

CREATE LOGIN ADMINISTRATEUR
	WITH PASSWORD = 'root', -- MUST_CHANGE,
	DEFAULT_DATABASE = master,
	CHECK_POLICY = OFF,
	CHECK_EXPIRATION = OFF
GO

USE [ServeurResto]
GO
	-------------------------------
	-- CREATION DES UTILISATEURS --
	-------------------------------

	CREATE user ADMINISTRATEUR for login ADMINISTRATEUR
	GO
		
	------------------------
	-- CREATION D'UN ROLE --
	------------------------

	CREATE ROLE Administration
		GRANT ALL ON OBJECT::Resto.[ROLE]			TO Administration;
		GRANT ALL ON OBJECT::Resto.[UTILISATEUR]	TO Administration;
		GRANT ALL ON OBJECT::Resto.[FACTURE]		TO Administration;
		GRANT ALL ON OBJECT::Resto.[PAIEMENT]		TO Administration;			
		GRANT ALL ON OBJECT::Resto.[TVA]			TO Administration;
		GRANT ALL ON OBJECT::Resto.[PREFERENCE]		TO Administration;
		GRANT ALL ON OBJECT::Resto.[TYPEPRODUIT]	TO Administration;
		GRANT ALL ON OBJECT::Resto.[CARTE]			TO Administration;
		GRANT ALL ON OBJECT::Resto.[MENU]			TO Administration;
		GRANT ALL ON OBJECT::Resto.[GARNITURE]		TO Administration;
		GRANT ALL ON OBJECT::Resto.[STOCK]			TO Administration;
		GRANT ALL ON OBJECT::Resto.[STATSCONSO]		TO Administration;
		GRANT ALL ON OBJECT::Resto.[CONFIGFACTURE]	TO Administration;
		GRANT ALL ON OBJECT::Resto.[CONFIGCOLOR]	TO Administration;
		GRANT ALL ON OBJECT::Resto.[REL_Commander]	TO Administration;
		GRANT ALL ON OBJECT::Resto.[REL_Composer]	TO Administration;
	GO

	-------------------------
	-- AJOUTER A UN GROUPE --
	-------------------------
	EXECUTE sp_addrolemember 'Administration','ADMINISTRATEUR'
	GO
		

