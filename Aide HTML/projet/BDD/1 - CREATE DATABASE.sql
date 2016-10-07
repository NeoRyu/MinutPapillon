--------------------------------------
--          MINUT'PAPILLON			--
--								    --
--  CREATION DE LA BASE DE DONNÉES  --
--------------------------------------

USE [master]
GO

IF exists (SELECT * FROM sys.databases WHERE name='ServeurResto')
DROP DATABASE ServeurResto
GO
CREATE DATABASE ServeurResto 
GO

USE [ServeurResto]
GO
CREATE SCHEMA Resto 
GO


CREATE TABLE Resto.ROLE(
	ID_Role 	INT IDENTITY (1,1)   NOT NULL	PRIMARY KEY
	, Role_Libelle      VARCHAR (25) NOT NULL
	, Role_NiveauDroits INT NOT NULL
);

CREATE TABLE Resto.UTILISATEUR(
	ID_User 	INT IDENTITY (1,1)   NOT NULL	PRIMARY KEY
	, User_Pseudo     VARCHAR (50) NOT NULL
	, User_Password   VARCHAR (50) NOT NULL
	, User_NomReel    VARCHAR (50) NULL
	, User_PrenomReel VARCHAR (50) NULL
	, User_Telephone  CHAR (10)	NULL
	, ID_Role 	   INT NOT NULL FOREIGN KEY REFERENCES Resto.ROLE (ID_Role)
);

CREATE TABLE Resto.FACTURE(
	ID_Facture	  INT IDENTITY (1,1)      NOT NULL PRIMARY KEY
	, Facture_DateCrea	  DATETIME NOT NULL
	, Facture_TableNum     INT NOT NULL
	, Facture_NbrCouvert   INT NOT NULL
	, Facture_PrixTotalTTC  FLOAT  NULL
	, Facture_Validee    bit NOT NULL
	, Facture_Cloturee   bit NULL
	, Facture_Modifiee   bit NULL
	, Facture_DateModif  DATETIME NULL
	, ID_User            INT NOT NULL FOREIGN KEY REFERENCES Resto.UTILISATEUR(ID_User)
);

CREATE TABLE Resto.PAIEMENT(
	  ID_Paiement    	INT IDENTITY (1,1)		NOT NULL	PRIMARY KEY
	, Paiement_Moyen 	VARCHAR (50)			NOT NULL
	, ID_Facture     	INT  					NOT NULL	FOREIGN KEY REFERENCES Resto.FACTURE(ID_Facture)
);

CREATE TABLE Resto.TVA(
	ID_TVA      		INT IDENTITY (1,1)	NOT NULL PRIMARY KEY
	, TVA_taux 		FLOAT NOT NULL
);

CREATE TABLE Resto.PREFERENCE(
	ID_Preference		 INT IDENTITY (1,1)	NOT NULL PRIMARY KEY
	, Preference_Type   VARCHAR (50) NOT NULL
	, Preference_Libelle VARCHAR(50) NOT NULL
	, Preference_Duree	 VARCHAR (50) NULL
);

CREATE TABLE Resto.TYPEPRODUIT(
	ID_Type      		INT IDENTITY (1,1)	NOT NULL PRIMARY KEY
	, Type_Libelle      VARCHAR (50) NOT NULL
);

CREATE TABLE Resto.CARTE(
	ID_Article           INT IDENTITY (1,1)	NOT NULL PRIMARY KEY
	, Article_Disponible bit NOT NULL
	, Article_Nom       VARCHAR (50) NOT NULL
	, Article_Format    VARCHAR (250)	NULL
	, Article_PrixHT     FLOAT  NOT NULL
	, Article_Supplement bit NOT NULL
	, Article_Preference bit NOT NULL
	, Article_Alcoolise  bit NOT NULL
	, Article_ImageURL   VARCHAR (250) NULL
	, Article_QuantiteEnStock	INT NOT NULL
	, ID_Type	INT NOT NULL FOREIGN KEY REFERENCES Resto.TYPEPRODUIT(ID_Type)
	, ID_Tva	INT NOT NULL FOREIGN KEY REFERENCES Resto.TVA(ID_TVA)
);

CREATE TABLE Resto.MENU(
	ID_Menu		INT IDENTITY (1,1)	NOT NULL PRIMARY KEY
	, Menu_Disponible 	bit NOT NULL
	, Menu_Libelle     VARCHAR (100) NOT NULL
	, Menu_DateAjout    DATETIME NULL
	, Menu_PrixTTC    	FLOAT NOT NULL
);

CREATE TABLE Resto.GARNITURE(
	ID_Garniture        INT IDENTITY (1,1)	NOT NULL PRIMARY KEY
	, Garniture_Libelle VARCHAR(100) NOT NULL
);

CREATE TABLE Resto.STOCK(
	ID_Stock            INT IDENTITY (1,1)	NOT NULL PRIMARY KEY
	, Stock_Fournisseur    VARCHAR (250) NULL
	, Stock_DateAchat      DATETIME NULL
	, Stock_PrixAchatUnit  INT NULL
	, Stock_QuantiteEntree INT NOT NULL
	, Stock_QuantiteSortie INT NOT NULL
	, ID_Article      INT NOT NULL FOREIGN KEY REFERENCES Resto.CARTE(ID_Article)
);

CREATE TABLE Resto.STATSCONSO(
	ID_StatsConso		INT IDENTITY (1,1) 				NOT NULL PRIMARY KEY
	, Article_Venducarte INT NULL
	, Article_VenduMenu  INT NULL
	, Article_Offert     INT NULL
	, Article_Detruit    INT NULL
	, ID_Article      INT NOT NULL FOREIGN KEY REFERENCES Resto.CARTE(ID_Article)
);

CREATE TABLE CONFIGFACTURE(
	ID_ConfigFac            int IDENTITY(1,1) NOT NULL PRIMARY KEY
	, ConfigFac_FontSizeTitle Int NOT NULL
	, ConfigFac_FontSizeMax   Int NOT NULL
	, ConfigFac_FontSizeNor   Int NOT NULL
	, ConfigFac_FontSizeMin   Int NOT NULL
	, ConfigFac_LibTitle      Varchar (250)
	, ConfigFac_LibDesc       Varchar (250)
	, ConfigFac_LibAdresse    Varchar (250)
	, ConfigFac_LibNumTel     Varchar (250)
	, ConfigFac_LibThanks     Varchar (250)
	, ConfigFac_LibMention    Varchar (250)
);

CREATE TABLE [Resto].[CONFIGCOLOR](
	[ID_ConfCol] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY
	, [ConfCol_1] [varchar](50) NOT NULL
	, [ConfFont_1] [varchar](50) NOT NULL
	, [ConfCol_2] [varchar](50) NOT NULL
	, [ConfFont_2] [varchar](50) NOT NULL
	, [ConfCol_3] [varchar](50) NOT NULL
	, [ConfFont_3] [varchar](50) NOT NULL
	, [ConfCol_4] [varchar](50) NOT NULL
	, [ConfFont_4] [varchar](50) NOT NULL
	, [ConfCol_5] [varchar](50) NOT NULL
	, [ConfFont_5] [varchar](50) NOT NULL
	, [ConfCol_6] [varchar](50) NOT NULL
	, [ConfFont_6] [varchar](50) NOT NULL
	, [ConfCol_7] [varchar](50) NOT NULL
	, [ConfFont_7] [varchar](50) NOT NULL
	, [ConfCol_8] [varchar](50) NOT NULL
	, [ConfFont_8] [varchar](50) NOT NULL
	, [ConfCol_9] [varchar](50) NOT NULL
	, [ConfFont_9] [varchar](50) NOT NULL
	, [ConfCol_10] [varchar](50) NOT NULL
	, [ConfFont_10] [varchar](50) NOT NULL
	, [ConfCol_11] [varchar](50) NOT NULL
	, [ConfFont_11] [varchar](50) NOT NULL
	, [ConfCol_12] [varchar](50) NOT NULL
	, [ConfFont_12] [varchar](50) NOT NULL
	, [ConfCol_13] [varchar](50) NOT NULL
	, [ConfFont_13] [varchar](50) NOT NULL
	, [ConfRandom] bit NULL
);

-- Creation des tables de relations :
CREATE TABLE Resto.REL_Commander(
/* ID_GenCommande	INT IDENTITY (1,1) 			   NOT NULL PRIMARY KEY ,*/
	ID_Facture      INT NOT NULL FOREIGN KEY REFERENCES Resto.FACTURE(ID_Facture)
	, ID_Menu         INT NOT NULL FOREIGN KEY REFERENCES Resto.MENU(ID_Menu)
	, ID_Article      INT NOT NULL FOREIGN KEY REFERENCES Resto.CARTE(ID_Article)
	, Preference_Type   VARCHAR (50) NULL
	, Voir_Serveur    	bit NULL
	, Article_offert    bit NULL
	, Nbr_Article     Int NULL
);

CREATE TABLE Resto.REL_Composer(
/*  ID_GenComposer	INT IDENTITY (1,1) 		NOT NULL	PRIMARY KEY ,*/
	Composer_Type       VARCHAR (30) NOT NULL
	, ID_Menu        INT NOT NULL FOREIGN KEY REFERENCES Resto.MENU(ID_Menu)
	, ID_Article     INT NOT NULL FOREIGN KEY REFERENCES Resto.CARTE(ID_Article)
);

-- Creation d'un index sur les Pseudonymes d'utilisateurs
CREATE NONCLUSTERED INDEX IX_UTILISATEUR_User_Pseudo ON Resto.UTILISATEUR(User_Pseudo); 

GO