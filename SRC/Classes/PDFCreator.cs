using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librairies supplémentaires :
using sharpPDF;
using sharpPDF.Enumerators;     // predefinedFont.POLICE
using sharpPDF.Exceptions;
using System.Windows.Forms; // MessageForm et autre

namespace MinutPapillon
{
    class PDFCreator
    {
        #region DATE/ HEURE
            private string Calendar()
            {
                string Jour, Mois, Annee;
                string Heure, Minute, Seconde;

                // Affichage de la date actuelle :    
                Annee = DateTime.Now.Year.ToString();
                if (Convert.ToInt32(DateTime.Now.Month) < 10)
                    Mois = "0" + DateTime.Now.Month.ToString();
                else
                    Mois = DateTime.Now.Month.ToString();
                if (Convert.ToInt32(DateTime.Now.Day) < 10)
                    Jour = "0" + DateTime.Now.Day.ToString();
                else
                    Jour = DateTime.Now.Day.ToString();

                Heure = DateTime.Now.Hour.ToString();
                Minute = DateTime.Now.Minute.ToString();
                Seconde = DateTime.Now.Second.ToString();

                string Chaine = Annee + "-" + Mois + "-" + Jour + " " + Heure + "h" + Minute + "m" + Seconde + "s";

                return Chaine;
            }

            private string DateImpression()
            {
                string Jour, Mois, Annee;

                // Affichage de la date actuelle :    
                Annee = DateTime.Now.Year.ToString();

                if (Convert.ToInt32(DateTime.Now.Month) < 10)
                    Mois = "0" + DateTime.Now.Month.ToString();
                else
                    Mois = DateTime.Now.Month.ToString();

                if (Convert.ToInt32(DateTime.Now.Day) < 10)
                    Jour = "0" + DateTime.Now.Day.ToString();
                else
                    Jour = DateTime.Now.Day.ToString();

                string Chaine = Jour + "/" + Mois + "/" + Annee;

                return Chaine;
            }

            private string HeureImpression()
            {
                string Heure, Minute, Seconde;

                // Affichage de l'heure actuelle :    
                if (Convert.ToInt32(DateTime.Now.Hour) < 10)
                    Heure = "0" + DateTime.Now.Hour.ToString();
                else
                    Heure = DateTime.Now.Hour.ToString();

                if (Convert.ToInt32(DateTime.Now.Minute) < 10)
                    Minute = "0" + DateTime.Now.Minute.ToString();
                else
                    Minute = DateTime.Now.Minute.ToString();

                if (Convert.ToInt32(DateTime.Now.Second) < 10)
                    Seconde = "0" + DateTime.Now.Second.ToString();
                else
                    Seconde = DateTime.Now.Second.ToString();

                string Chaine = Heure + ":" + Minute + ":" + Seconde;

                return Chaine;
            }
        #endregion

        #region CALCUL DES PRIX
            private double CalculPourcentage(double nombre, double nombre2) // PrixTTC / TVA
            {
                return (nombre * nombre2) / 100;
            }
        #endregion

        #region RECUPERATION DES TEXTES ET TAILLES DE FONT
            public List<string> ConfigFacture = new List<string>();
            public int FTit, FMax, FNor, FMin;
            public string TTit, TDes, TAdd, TTel, TThk, TMen = "";
            private void ConfigContenu(Connexion BDD)
            {
                RequestData r = new RequestData();
                List<Data> datas = new List<Data>
                {
                    new Data(){ name="Table", valeur = "CONFIGFACTURE" },
                    new Data(){ name="Attribut", valeur = "ID_ConfigFac" },
                    new Data(){ name="Recherche", valeur = "1" }
                };
                BDD.SqlCmd = r.TraitementRequest(BDD.cnx, "Resto.SelectLineDGV", datas);
                BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

                if (BDD.SqlDr.Read())
                {
                    for (int i = 0; i < BDD.SqlDr.FieldCount; i++)
                    {
                        if (i != 0)
                            ConfigFacture.Add(BDD.SqlDr[i].ToString());
                    }
                }

                if (ConfigFacture.Count == 0)
                {
                    ConfigFacture.Add("20");
                    ConfigFacture.Add("16");
                    ConfigFacture.Add("12");
                    ConfigFacture.Add("8");
                    ConfigFacture.Add("Restaurant de l'A.F.P.A. Laon");
                    ConfigFacture.Add("Association pour la Formation Professionnelle des Adultes");
                    ConfigFacture.Add("2 rue des Minimes, 02000 Laon");
                    ConfigFacture.Add("03 23 23 61 60");
                    ConfigFacture.Add("Nous vous remercions de votre visite et esperons vous revoir prochainement !");
                    ConfigFacture.Add("Dont services compris 15%");
                }

                BDD.SqlDr.Close();
                CompleteContenu();
            }
            private void CompleteContenu()
            {
                Shell.Sanitize clean = new Shell.Sanitize();

                // Taille des caracteres :
                FTit = Convert.ToInt32(ConfigFacture[0]);
                FMax = Convert.ToInt32(ConfigFacture[1]);
                FNor = Convert.ToInt32(ConfigFacture[2]);
                FMin = Convert.ToInt32(ConfigFacture[3]);

                // Si une taille est videon remplace :
                if (FTit < 20)
                    FTit = 20;
                if (FMax < 16)
                    FMax = 16;
                if (FNor < 12)
                    FNor = 12;
                if (FMin < 8)
                    FMin = 8;

                // Contenu du texte :
                TTit = clean.SnippetParseurNoAccent(ConfigFacture[4]);
                TDes = clean.SnippetParseurNoAccent(ConfigFacture[5]);
                TAdd = clean.SnippetParseurNoAccent(ConfigFacture[6]);
                TTel = clean.SnippetParseurNoAccent(ConfigFacture[7]);
                TThk = clean.SnippetParseurNoAccent(ConfigFacture[8]);
                TMen = clean.SnippetParseurNoAccent(ConfigFacture[9]);

                // Si le texte est vide on remplace :
                if ((TTit == null)  || (TTit == "") || (TTit == " "))
                    TTit = "Restaurant de l'A.F.P.A. Laon";
                if ((TDes == null) || (TDes == "") || (TDes == " "))
                    TDes = "Association pour la Formation Professionnelle des Adultes";
                if ((TAdd == null) || (TAdd == "") || (TAdd == " "))
                    TAdd = "2 rue des Minimes, 02000 Laon";
                if ((TTel == null) || (TTel == "") || (TTel == " "))
                    TTel = "03 23 23 61 60";
                if ((TThk == null) || (TThk == "") || (TThk == " "))
                    TThk = "Nous vous remercions de votre visite et esperons vous revoir prochainement !";
                if ((TMen == null) || (TMen == "") || (TMen == " "))
                    TMen = "Dont services compris 15%";
            }
        #endregion

        public string CreatePDF(User _user, string _ID)
        {
            #region BDD
                // Recupération des données :
                User user = _user;
                int NumFacture = Convert.ToInt32(_ID);
                string ID_Facture = NumFacture.ToString();

                // Instanciations pour interrogation de la BDD :
                Connexion BDD = new Connexion();
                RequestData r = new RequestData();  

                // Récupération des données :
                BDD.OpenBDD();
                ConfigContenu(BDD);                

                Facture facture = new Facture(BDD, ID_Facture);

                // récupération des infos de la facture par la classe Facture
                List<Data> datas = new List<Data>()
                {
                    new Data(){ name = "idFacture", valeur = ID_Facture }
                };

                string query = "Resto.Commander_Recherche";

                BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
                BDD.SqlDr = BDD.SqlCmd.ExecuteReader();             
            #endregion

            #region DECLARATION DES VARIABLES LOCALES
            // Nécessaires à la création dynamique du .pdf :                
                string Horloge = Calendar();            
                string Title = "Facture N°" + NumFacture + " - " + Horloge;
                string NomPDF = Title + ".pdf";
                string Path = @"C:\Users\Public\Documents\" + NomPDF;
                string retPath = Path;
                bool UnePage = true;

                // Nécessaires à l'édition dynamique du .pdf générée :
                string Date = DateImpression();
                string Time = HeureImpression();
            #endregion

            #region INSTANCIATIONS  
                // Parseur pour securisation des données et transformation des caracteres incompatibles :
                Shell.Sanitize clean = new Shell.Sanitize();
                GestionCommande gc = new GestionCommande();
                // var lol = clean.SnippetParseurNoAccent(string); // Permet de nettoyer une chaine des accents qui incompatibles ici
                // TODO : Faire attention, symbole € etc (européens) incompatibles, mais non pris en compte pour le moment...

                // Creation d'un nouveau document, ainsi que d'une page à editer :
                pdfDocument myDoc = new pdfDocument("Facture N°" + NumFacture, clean.SnippetParseurNoAccent(user.nomUser +" "+ user.prenomUser));
                pdfPage myPage = myDoc.addPage();    // Creation d'une nouvelle page

                // Création d'un tableau pour affichage du contenu de la commande :
                pdfTable myTable = new pdfTable();
                pdfTable myTable2 = new pdfTable();
                pdfTableRow myRow = myTable.createRow(); // myRow = Permet d'ajouter une ligne quand la variable est appelée
            #endregion

            #region DECLARATION DES VARIABLES POUR LE POSITIONNEMENT DES ELEMENTS
                // Hauteur et Largeur du PDF
                int Height = myPage.height;     // 792
                int Width = myPage.width;       // 612
                bool AntiPage2MontantOnly = false;

                // Configuration de la taille de la police de caractere
                int tailleFontTit = Convert.ToInt32(FTit); // 20 : nom resto (taille max : 26)
                int tailleFontMax = Convert.ToInt32(FMax); // 16 : header table (taille max : 18)
                int tailleFontNor = Convert.ToInt32(FNor); // 12 : tout le reste (taille max : 15)
                int tailleFontMin = Convert.ToInt32(FMin);  // 8 : mention services compris (taille max : 13)

                // Positionnement des textes
                int HauteurRow = (tailleFontNor * 2);
                int PosYMention = 10;     
                int PosYAdresse = (Height - (tailleFontTit * 2) - (tailleFontNor) - 10);
                int PosYCommande = (Height - 28);
                int PosYFacture = (PosYAdresse - (tailleFontNor * 2) - 5);
                int PosYTableau = (PosYFacture - tailleFontNor - 10);
                int PosYMontant = (PosYTableau - (tailleFontMax * 2));    
                int TableauTropGrand = ((Height - (Height - PosYTableau)) - ((tailleFontNor * 2) + PosYMention) - (tailleFontMax * 2)); //
            #endregion

            #region EDITION DYNAMIQUE DU CONTENU DU PDF

                #region HEADER
                    // TITRE
                    myPage.addText(TTit, 20, (Height - tailleFontTit), predefinedFont.csHelveticaBold, tailleFontTit, predefinedColor.csBlack);
                    myPage.addText(TDes, 20, (Height - (tailleFontTit * 2) + 5), predefinedFont.csHelveticaOblique, tailleFontNor, predefinedColor.csBlack);

                    // ADRESSE                
                    myPage.addText(TAdd, 20, PosYAdresse, predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                    myPage.addText("Telephone : "+ TTel, 20, (PosYAdresse - tailleFontNor), predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);

                    // INFOS COMMANDE                
                    myPage.addText("SERVEUR :", 406, PosYCommande, predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                    myPage.addText(clean.SnippetParseurNoAccent(user.prenomUser), 506, PosYCommande, predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);
                    myPage.addText("TABLE :", 416, (PosYCommande - tailleFontNor), predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                    myPage.addText(facture.table, 506, (PosYCommande - tailleFontNor), predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);
                    myPage.addText("CVTS :", 426, (PosYCommande - (tailleFontNor * 2)), predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                    myPage.addText(facture.couvert, 506, (PosYCommande - (tailleFontNor * 2)), predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);

                    // INFOS FACTURE                
                    myPage.addText("NUMERO DE LA FACTURE :", 56, PosYFacture, predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                    myPage.addText(NumFacture.ToString(), (230 + (tailleFontNor * 2)), PosYFacture, predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);
                    myPage.addText(clean.SnippetParseurNoAccent("Le " + Date), 356, PosYFacture, predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack); // Jour
                    myPage.addText(clean.SnippetParseurNoAccent(" a " + Time), 456, PosYFacture, predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);     // Heure
                #endregion

                #region BODY
                    #region STYLESHEET (Border)
                        // On défini les bordures du tableau
                        myTable.borderSize = 0;
                        myTable2.borderSize = myTable.borderSize;
                        myTable.borderColor = predefinedColor.csWhite;
                        myTable2.borderColor = myTable.borderColor;
                    #endregion

                    // Création des en-têtes du tableau
                    myTable.tableHeader.addColumn(new pdfTableColumn("QTE", predefinedAlignment.csCenter, 50));
                    myTable.tableHeader.addColumn(new pdfTableColumn("PRODUIT", predefinedAlignment.csLeft, 250));
                    myTable.tableHeader.addColumn(new pdfTableColumn("UNIT", predefinedAlignment.csCenter, 100));
                    myTable.tableHeader.addColumn(new pdfTableColumn("TOTAL", predefinedAlignment.csCenter, 100));

                    // Création des en-têtes du tableau si il y a une deuxieme page (impossible de delete des rows du premier tableau)
                    myTable2.tableHeader.addColumn(new pdfTableColumn("QTE", predefinedAlignment.csCenter, 50));
                    myTable2.tableHeader.addColumn(new pdfTableColumn("PRODUIT", predefinedAlignment.csLeft, 250));
                    myTable2.tableHeader.addColumn(new pdfTableColumn("UNIT", predefinedAlignment.csCenter, 100));
                    myTable2.tableHeader.addColumn(new pdfTableColumn("TOTAL", predefinedAlignment.csCenter, 100));
                    #region STYLESHEET (Header Table)
                    // On defini le style des en-têtes
                    myTable.tableHeaderStyle = new pdfTableRowStyle(predefinedFont.csCourierBoldOblique, tailleFontMax, predefinedColor.csYellow, predefinedColor.csGray);
                    myTable2.tableHeaderStyle = myTable.tableHeaderStyle;
                    #endregion   

                    #region GENERATION DU TABLEAU

                        #region DECLARATION DES VARIABLES CONDITIONNELLES
                            string NomMenu = "";
                            int iMenu = 0;
                            int CountArt = 1;
                            int HauteurTable = HauteurRow * CountArt;
                            double PrixArticleTTC = 0.00;
                            double PrixTotal = 0;
                            double TVA = 20.00;
                            double CalculTVA = 0.00;
                            double CalculTVATotal = 0.00;
                        #endregion

                        #region STYLESHEET (Lignes table)
                            // Puis celui des lignes
                            myTable.rowStyle = new pdfTableRowStyle(predefinedFont.csCourier, tailleFontNor, predefinedColor.csBlack, predefinedColor.csWhite);
                            myTable2.rowStyle = myTable.rowStyle;
                            // Et des lignes en alternance
                            myTable.alternateRowStyle = myTable.rowStyle;
                            myTable2.alternateRowStyle = myTable.alternateRowStyle;
                        #endregion

                        // Si il y a des articles commandés dans le menu 1 (a la carte) alors : / sinon on verif si il y a un menu 2 etc

                        // FOREACH (Rel_Commander WHERE Id_Menu = iMenu)
                        while (BDD.SqlDr.Read())
                        {
                            CalculTVA = CalculPourcentage(Convert.ToDouble(BDD.SqlDr["Article_PrixHT"]), Convert.ToDouble(BDD.SqlDr["TVA_taux"]));
                            if (NomMenu != BDD.SqlDr["ID_menu"].ToString()) // AJOUT DU TITRE DU MENU
                            {
                                NomMenu = BDD.SqlDr["ID_menu"].ToString();
                                if (BDD.SqlDr["ID_menu"].ToString() != "1")
                                {
                                    // Ajout d'une ligne vide de séparation :
                                    myRow = myTable.createRow();
                                    CountArt++;
                                    if (UnePage)
                                        myTable.addRow(myRow);
                                    else
                                        myTable2.addRow(myRow);
                                }

                                // Ligne contenant le nom du menu :
                                myRow = myTable.createRow();
                                if (!Convert.ToBoolean(BDD.SqlDr["Article_offert"]))
                                {
                                    if (BDD.SqlDr["ID_menu"].ToString() == "1")         // TITRE : A LA CARTE
                                    {
                                        myRow[0].columnValue = clean.SnippetParseurNoAccent(" ");
                                        myRow[1].columnValue = clean.SnippetParseurNoAccent(BDD.SqlDr["Menu_Libelle"].ToString());
                                        myRow[2].columnValue = clean.SnippetParseurNoAccent(" ");
                                        myRow[3].columnValue = clean.SnippetParseurNoAccent(" ");
                                    }
                                    else                                                // TITRE : MENU
                                    {
                                        myRow[0].columnValue = clean.SnippetParseurNoAccent(BDD.SqlDr["Nbr_Article"].ToString());
                                        myRow[1].columnValue = clean.SnippetParseurNoAccent(BDD.SqlDr["Menu_Libelle"].ToString());
                                        PrixArticleTTC = Math.Round(Convert.ToDouble(BDD.SqlDr["Menu_PrixTTC"]) + CalculTVA, 2);
                                        myRow[2].columnValue = clean.SnippetParseurNoAccent(PrixArticleTTC.ToString());
                                        PrixTotal += (PrixArticleTTC * Convert.ToDouble(BDD.SqlDr["Nbr_Article"]));
                                        myRow[3].columnValue = clean.SnippetParseurNoAccent(Math.Round(PrixArticleTTC * Convert.ToInt32(BDD.SqlDr["Nbr_Article"]), 2).ToString());
                                    }
                                }
                                else
                                {
                                    myRow[2].columnValue = "Offert";            // Article offert
                                    myRow[3].columnValue = "0";
                                }
                                PosYMontant -= (HauteurRow * 2);
                                
                                // Si le menu est à la carte, on ajoute le premier article (a contrario du menu ajoutant un article ID 1)
                                if (BDD.SqlDr["ID_menu"].ToString() == "1")
                                {
                                    //On ajoute le titre menu :
                                    if (UnePage)
                                        myTable.addRow(myRow);
                                    else
                                        myTable2.addRow(myRow); 

                                    myRow = myTable.createRow();
                                    myRow[0].columnValue = clean.SnippetParseurNoAccent(BDD.SqlDr["Nbr_Article"].ToString());         // Quantité
                                    myRow[1].columnValue = clean.SnippetParseurNoAccent(BDD.SqlDr["Article_Nom"].ToString());      // Nom de l'article
                                    if (!Convert.ToBoolean(BDD.SqlDr["Article_offert"]))
                                    {
                                        //CALCUL TVA                                    
                                        PrixArticleTTC = Math.Round(Convert.ToDouble(BDD.SqlDr["Article_PrixHT"]) + CalculTVA, 2);
                                        myRow[2].columnValue = clean.SnippetParseurNoAccent(PrixArticleTTC.ToString());
                                        PrixTotal += (PrixArticleTTC * Convert.ToDouble(BDD.SqlDr["Nbr_Article"]));
                                        myRow[3].columnValue = clean.SnippetParseurNoAccent(Math.Round(PrixArticleTTC * Convert.ToInt32(BDD.SqlDr["Nbr_Article"]), 2).ToString());
                                    }
                                    else
                                    {
                                        myRow[2].columnValue = "Offert";         // Article offert
                                        myRow[3].columnValue = "0";
                                    }
                                    PosYMontant -= HauteurRow;
                                }
                            }
                            else                                                // AJOUT D'UN ARTICLE DU MENU
                            {
                                myRow = myTable.createRow();
                                myRow[0].columnValue = clean.SnippetParseurNoAccent(BDD.SqlDr["Nbr_Article"].ToString());         // Quantité
                                myRow[1].columnValue = clean.SnippetParseurNoAccent(BDD.SqlDr["Article_Nom"].ToString());      // Nom de l'article
                                if (!Convert.ToBoolean(BDD.SqlDr["Article_offert"]))
                                {
                                    if (NomMenu == "1") // "A LA CARTE"
                                    {
                                        //CALCUL TVA                                    
                                        PrixArticleTTC = Math.Round(Convert.ToDouble(BDD.SqlDr["Article_PrixHT"]) + CalculTVA, 2);
                                        myRow[2].columnValue = clean.SnippetParseurNoAccent(PrixArticleTTC.ToString());
                                        PrixTotal += (PrixArticleTTC * Convert.ToDouble(BDD.SqlDr["Nbr_Article"]));
                                        myRow[3].columnValue = clean.SnippetParseurNoAccent(Math.Round(PrixArticleTTC * Convert.ToInt32(BDD.SqlDr["Nbr_Article"]), 2).ToString());
                                    }
                                    else
                                    {
                                        myRow[2].columnValue = " ";         // Prix Unit TTC (VIDE car compris dans un menu)
                                        myRow[3].columnValue = " ";         // Prix Total (VIDE car compris dans un menu)
                                    }
                                }
                                else
                                {
                                    myRow[2].columnValue = "Offert";         // Article offert
                                    myRow[3].columnValue = "0";
                                }
                                PosYMontant -= HauteurRow;
                            }


                            if (UnePage)
                                myTable.addRow(myRow);
                            else
                                myTable2.addRow(myRow);                            
                            CountArt++;
                            
                            HauteurTable = HauteurRow * CountArt;
                            if ((HauteurTable >= TableauTropGrand) && (UnePage == true))   // Si la taille de tailleFontNor ets modifiée (donc hauteur des row)
                            {
                                if (AntiPage2MontantOnly == true)
                                {
                                    UnePage = false;

                                    // Ligne contenant le nom du menu :
                                    myRow = myTable.createRow();
                                    myRow[0].columnValue = clean.SnippetParseurNoAccent(" ");
                                    myRow[1].columnValue = clean.SnippetParseurNoAccent(BDD.SqlDr["Menu_Libelle"].ToString());
                                    myRow[2].columnValue = "( suite de ";
                                    myRow[3].columnValue = "la commande )";
                                    CountArt++;

                                    myTable2.addRow(myRow);
                                    CountArt = 1;
                                    MessageBox.Show("0");
                                }
                                else
                                {                                    
                                    AntiPage2MontantOnly = true;
                                    MessageBox.Show("1");
                                }
                            }
                            iMenu++;
                        }  

                    #endregion
                #endregion

                #region FOOTER
                    CalculTVATotal = CalculPourcentage(Convert.ToDouble(PrixTotal), Convert.ToDouble(TVA));
                    if (UnePage)
                    {
                        // Ajout par deplacement du tableau généré dynamiquement vers la page en cours d"édition de la facture
                        myPage.addTable(myTable, 56, PosYTableau);                        

                        // Prix Total TTC + TVA
                        PosYMontant = ((tailleFontMax * 2) + (tailleFontNor * 2) + (PosYMention * 2));
                        myPage.addText("Montant NET TTC a regler :", 106, PosYMontant, predefinedFont.csHelveticaBold, tailleFontMax, predefinedColor.csBlack);
                        myPage.addText(PrixTotal.ToString(), 356, PosYMontant, predefinedFont.csHelveticaBold, tailleFontMax, predefinedColor.csBlack);
                        myPage.addText(clean.SnippetParseurNoAccent("Dont TVA a " + TVA + " % incluse :"), 106, (PosYMontant - tailleFontMax), predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                        myPage.addText(CalculTVATotal.ToString(), 356, (PosYMontant - tailleFontMax), predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);
                         
                        myPage.addText(TThk, (100 - (tailleFontNor * 2)), ((tailleFontNor * 2) + PosYMention), predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);
                        myPage.addText(TMen, 250, PosYMention, predefinedFont.csHelveticaOblique, tailleFontMin, predefinedColor.csBlack);
                    }
                    else
                    {
                        myPage.addTable(myTable, 56, PosYTableau);
                        // AJOUT DU MONTANT
                        PosYMontant = ((tailleFontMax) + (tailleFontNor) + (PosYMention * 2));
                        myPage.addText("Montant NET TTC a regler :", 106, PosYMontant, predefinedFont.csHelveticaBold, tailleFontMax, predefinedColor.csBlack);
                        myPage.addText(PrixTotal.ToString(), 356, PosYMontant, predefinedFont.csHelveticaBold, tailleFontMax, predefinedColor.csBlack);
                        myPage.addText(clean.SnippetParseurNoAccent("Dont TVA a " + TVA + " % incluse :"), 106, (PosYMontant - tailleFontMax), predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                        myPage.addText(CalculTVATotal.ToString(), 356, (PosYMontant - tailleFontMax), predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);
                         

                        // Si la commande est trop longue et ne tient pas sur une page, on en crée une deuxieme !
                        pdfPage myPage2 = myDoc.addPage();

                        // TITRE
                        myPage2.addText(TTit, 20, (Height - tailleFontTit), predefinedFont.csHelveticaBold, tailleFontTit, predefinedColor.csBlack);
                        myPage2.addText(TDes, 20, (Height - (tailleFontTit * 2) + 5), predefinedFont.csHelveticaOblique, tailleFontNor, predefinedColor.csBlack);

                        // INFOS COMMANDE               
                        myPage2.addText("SERVEUR :", 406, PosYCommande, predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                        myPage2.addText(clean.SnippetParseurNoAccent(user.prenomUser), 506, PosYCommande, predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);
                        myPage2.addText("TABLE :", 416, (PosYCommande - tailleFontNor), predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                        myPage2.addText(facture.table, 506, (PosYCommande - tailleFontNor), predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);
                        myPage2.addText("CVTS :", 426, (PosYCommande - (tailleFontNor * 2)), predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                        myPage2.addText(facture.couvert, 506, (PosYCommande - (tailleFontNor * 2)), predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);

                        // INFOS FACTURE                
                        myPage2.addText("NUMERO DE LA FACTURE :", 56, PosYFacture, predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                        myPage2.addText(NumFacture.ToString(), (230 + (tailleFontNor *2)), PosYFacture, predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);
                        myPage2.addText(clean.SnippetParseurNoAccent("Le " + Date), 356, PosYFacture, predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack); // Jour
                        myPage2.addText(clean.SnippetParseurNoAccent(" a " + Time), 456, PosYFacture, predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);     // Heure

                            // AJOUT DE LA SUITE DU TABLEAU
                            myPage2.addTable(myTable2, 56, PosYTableau);
                
                        // Prix Total TTC + TVA
                        PosYMontant = (PosYTableau - (tailleFontMax * 2) - (HauteurRow * CountArt));
                        myPage2.addText("Montant NET TTC a regler :", 106, (PosYMontant-10), predefinedFont.csHelveticaBold, tailleFontMax, predefinedColor.csBlack);
                        myPage2.addText(PrixTotal.ToString(), 356, (PosYMontant - 10), predefinedFont.csHelveticaBold, tailleFontMax, predefinedColor.csBlack);
                        myPage2.addText(clean.SnippetParseurNoAccent("Dont TVA a " + TVA + " % incluse :"), 106, ((PosYMontant - tailleFontMax) - 10), predefinedFont.csHelveticaBold, tailleFontNor, predefinedColor.csBlack);
                        myPage2.addText(CalculTVATotal.ToString(), 356, ((PosYMontant - tailleFontMax) - 10), predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);

                        myPage2.addText(TThk, (100 - (tailleFontNor * 2)), ((tailleFontNor * 2) + PosYMention), predefinedFont.csHelvetica, tailleFontNor, predefinedColor.csBlack);
                        myPage2.addText(TMen, 250, PosYMention, predefinedFont.csHelveticaOblique, tailleFontMin, predefinedColor.csBlack);

                        // Ajout du numéro de page en bas de chacune d'elle
                        myPage.addText("Page 1 / 2", 550, PosYMention, predefinedFont.csHelveticaOblique, tailleFontMin, predefinedColor.csBlack);
                        myPage2.addText("Page 2 / 2", 550, PosYMention, predefinedFont.csHelveticaOblique, tailleFontMin, predefinedColor.csBlack);
                    }
                #endregion

            #endregion

            #region CREATION DU PDF
                // Création du PDF
                if (System.IO.File.Exists(Path))
                {
                    System.IO.File.Delete(Path);    // Evite un bug si le fichier existe déjà (en théorie non, mais si on change le nom du fichier manuellement...)
                }
                myDoc.createPDF(Path);
            #endregion

            #region NETTOYAGE MEMOIRE
                // Variables d'instanciations :
                myTable = null;
                myPage = null;
                myDoc = null;
                BDD.SqlDr.Close();
            #endregion

            return retPath; // Chemin où est stocké le fichier
        }

    }
}
