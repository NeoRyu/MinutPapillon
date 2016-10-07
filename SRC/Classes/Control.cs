using System;
using System.Collections.Generic;   // Gestion des Lists
// Librairies supplémentaires utilisées :
using System.Data.SqlClient;        // Gestion des Erreurs SQL & tt ce qui est Base de données
using System.Windows.Forms;         // Pour pouvoir gérer les types et les fonctions system
using System.Drawing;               // Pour la prise en charge des Color
using System.Windows.Input;

namespace MinutPapillon
{
    #region [SNIPPET] GESTION DES FENETRES
    public class Window
    {
        RequestData r = new RequestData();
        #region [SNIPPET] FERMETURE DE L'APPLICATION
        public void FormClose(SqlConnection BDD)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vous quittez l'application ?", "Fermeture", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    BDD.Close();
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        #endregion

        #region [SNIPPET] DECONNECTION DE L'UTILISATEUR
        public void FormUserDeco(Form WinFormInherit)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vous déconnecter ?", "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    Form_connexion Menu = new Form_connexion();
                    Menu.Show();
                    WinFormInherit.Hide();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        #endregion

        #region REDIRECTION POSSIBLES SUR LA FENETRE DE CONNEXION
        public void WinFormRedirectAuthentification(Form parent, User user, TextBox Identifiant, TextBox Password)
        {
            List<string> Param = new List<string>();
            Param.Add(Identifiant.Text);
            Param.Add(Password.Text);

            if (user.loginUser(Param))
            {
                if (user.droitUser == 1 || user.droitUser == 2) // Si l'utilisateur est un Admin, cela ouvre le panneau Admin
                {
                    Form_administration menu = new Form_administration(user);
                    menu.Show();
                }
                else if (user.droitUser == 3)// Sinon, cela ouvre le panneau des commande
                {
                    Form_commandes commande = new Form_commandes(user);
                    commande.Show();
                }
                else
                {
                    MessageBox.Show("Authentification impossible, contactez l'admin.", "Etat de l'authentification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                parent.Hide();
            }
            else
            {
                MessageBox.Show("L'identifiant et/ou le mot de passe sont erronés.", "Erreur Authentification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Password.Clear();
                Identifiant.Focus();
                Identifiant.SelectAll();
            }
        }
        #endregion


        #region AFFICHAGES DES USER CONTROL DANS Form_administration
        // TODO à faire : CU_Stock / CU_Stats
        public void OpenControlUser(User user, GroupBox panel, DataGridView dgv, string NomTable, Form parent)
        {
            panel.Controls.Clear();
            // ON AFFICHE D'ABORD LE USERCONTROL RECHERCHER
            CU_Rechercher Search = new CU_Rechercher(user, dgv, NomTable);
            panel.Controls.Add(Search);
            Search.Location = new Point(0, 8);
            Search.Name = "rechercher1";
            string AdminFormName = "MinutPapillon - Panneau d'administration";

            // PUIS ON AFFICHE LE USERCONTROL CORRESPONDANT AU STRING EN PARAMETRE
            switch (NomTable)
            {
                case "UTILISATEUR":
                    {
                        parent.Text = AdminFormName + " - Gestion Utilisateur";
                        CU_Utilisateur item = new CU_Utilisateur(user, dgv);
                        panel.Controls.Add(item);
                        item.Location = new Point(0, 8);
                        item.Name = "utilisateur1";
                        break;
                    }
                case "CARTE":
                    {
                        parent.Text = AdminFormName + " - Gestion de la Carte";
                        CU_Carte item = new CU_Carte(user, dgv);
                        panel.Controls.Add(item);
                        item.Location = new Point(0, 8);
                        item.Name = "carte1";
                        break;
                    }
                case "MENU":
                    {
                        parent.Text = AdminFormName + " - Gestion des Menus";
                        CU_Menu item = new CU_Menu(user, dgv);
                        panel.Controls.Add(item);
                        item.Location = new Point(0, 8);
                        item.Name = "menu1";
                        break;
                    }
                case "FACTURE":
                    {
                        parent.Text = AdminFormName + " - Gestion des Commandes";
                        CU_Commande item = new CU_Commande(user, dgv);
                        panel.Controls.Add(item);
                        item.Location = new Point(0, 8);
                        item.Name = "commande1";
                        break;
                    }

                case "STOCK":
                    {
                        panel.Controls.Clear(); // A DELETE
                        parent.Text = AdminFormName + " - Gestion des Stocks //!\\";
                        CU_Stock item = new CU_Stock(user, dgv);
                        panel.Controls.Add(item);
                        item.Location = new Point(0, 8);
                        item.Name = "stock1";
                        break;
                    }
                case "STATISTIQUES":
                    {
                        panel.Controls.Clear(); // A DELETE
                        parent.Text = AdminFormName + " - Statistiques //!\\";
                        CU_StatsGlobales item = new CU_StatsGlobales();
                        panel.Controls.Add(item);
                        item.Location = new Point(0, 8);
                        item.Name = "statsglobales1";
                        break;
                    }

                case "CONFIGCOLOR":
                    {
                        panel.Controls.Clear();
                        parent.Text = AdminFormName + " - Personnalisation de la Colorisation";
                        CU_ColorBt item = new CU_ColorBt(user, dgv);
                        panel.Controls.Add(item);
                        item.Location = new Point(0, 8);
                        item.Name = "colorbt1";
                        break;
                    }
                case "CONFIGFACTURE":
                    {
                        panel.Controls.Clear();
                        parent.Text = AdminFormName + " - Personnalisation des Factures";
                        CU_Facture item = new CU_Facture(user, dgv);
                        panel.Controls.Add(item);
                        item.Location = new Point(0, 8);
                        item.Name = "facture1";
                        break;
                    }
                default:
                    break;
            }

        }
        #endregion


        #region GESTIONNAIRE DE TOUCHES POUR LA SECTION SERVEUR
        #region GESTION DES VALEURS STOCKEES
        public static string Quantite_Article = "1";
        public static int QuantityModif = 1;
        public List<string> AppuiTouche = new List<string>();

        public static List<Item> objetCombo = new List<Item>();
        public static List<string> NumTableBDD = new List<string>();
        public bool ZeroInit = false;    // Permet le 0 initial seulement pour update (delete article)

        public static bool DesactivateKeyPress = false;
        public bool AutoriserBtNum = true;

        private string Chaine { get; set; }
        public string ChaineKeypress()
        {
            if (Chaine.ToString() == null)
                return "";
            else
                return Chaine.ToString();
        }

        public void BtNumServeur(string Touche)
        {
            AppuiTouche.Add(Touche.ToString());
        }
        public void KeyPressServeur(KeyPressEventArgs Touche)
        {
            if (DesactivateKeyPress == false)
            {
                if ((Touche.KeyChar.ToString() == "0") || (Touche.KeyChar.ToString() == "1") || (Touche.KeyChar.ToString() == "2") ||
                    (Touche.KeyChar.ToString() == "2") || (Touche.KeyChar.ToString() == "3") || (Touche.KeyChar.ToString() == "4") ||
                    (Touche.KeyChar.ToString() == "5") || (Touche.KeyChar.ToString() == "6") || (Touche.KeyChar.ToString() == "7") || 
                    (Touche.KeyChar.ToString() == "8") || (Touche.KeyChar.ToString() == "9"))
                {
                    AppuiTouche.Add(Touche.KeyChar.ToString());
                }
            }
        }
        public void KeyPressClear()
        {
            AppuiTouche.Clear();
        }
        public void ChaineClear()
        {
            Chaine = "1";
            Quantite_Article = Chaine;
        }
        #endregion

        public void KeyControlServeur(Button bt_Name, string redirect)
        {
            if (DesactivateKeyPress == false)
            {
                if (AppuiTouche.Count >= 1)
                {
                    switch (AppuiTouche[AppuiTouche.Count-1])
                    { 
                        case "0":
                            if (AppuiTouche[0] == "0")
                            {
                                if (ZeroInit)
                                {
                                    goto case "9";
                                }
                                else
                                {
                                    KeyPressClear();
                                    goto default;
                                }
                            }
                            else
                            {
                                goto case "9";
                            }
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                        case "6":
                        case "7":
                        case "8":
                        case "9":
                            {
                                if (AppuiTouche.Count == 1)
                                {
                                    //INSERT
                                    Chaine = AppuiTouche[0];
                                }
                                else
                                {
                                    if (AppuiTouche[0] == "0")
                                    {
                                        Chaine = AppuiTouche[1];    // Protection pour eviter une chaine du type "01"
                                    }
                                    if ((AppuiTouche[1] == "0") || (AppuiTouche[1] == "1") || (AppuiTouche[1] == "2") || (AppuiTouche[1] == "2") ||
                                        (AppuiTouche[1] == "3") || (AppuiTouche[1] == "4") || (AppuiTouche[1] == "5") || (AppuiTouche[1] == "6") ||
                                        (AppuiTouche[1] == "7") || (AppuiTouche[1] == "8") || (AppuiTouche[1] == "9"))
                                    {
                                        //UPDATE
                                        Chaine = AppuiTouche[0] + AppuiTouche[1];
                                    }
                                    else
                                    {
                                        Chaine = AppuiTouche[0];
                                    }
                                }
                                ZeroInit = false;
                                break;
                            }
                        default: 
                            {
                                if (redirect == "" || redirect == null)
                                    Chaine = "1";         // Si appui sur une touche non numérique, on donne une quantité de 1 par defaut
                                else
                                {
                                    Chaine = redirect;    // Si appui sur une touche non numérique, on reinscrit le texte d'origine sur le bouton
                                    KeyPressClear();    // Si il s'agit d'une touche non numérique, on nettoie la liste
                                }
                                break;
                            }
                    }
                }

                if (bt_Name != null)
                {
                    if (redirect != "")                     // TABLES et COUVERTS
                    {
                        if (bt_Name.Name == "bt_NumTable")
                        {
                            if (TableLibre())
                            {
                                bt_Name.Text = Chaine;
                            }
                            else
                            {
                                if (Chaine != null && Chaine != "")
                                {
                                    if (Chaine.Length == 2)
                                    {
                                        bt_Name.Text = "NUM";
                                        Chaine = "";
                                        KeyPressClear();
                                    }
                                }
                            }
                        }
                        else
                            bt_Name.Text = Chaine;
                    }
                    else                                    // QUANTITE ARTICLE COMMANDEE
                    {
                        if (Chaine == "0")  // Ne fonctionne que pour les insert
                        {
                            ChaineClear();
                            Quantite_Article = "1";
                        }
                        else
                            Quantite_Article = Chaine;
                    }
                }
                else
                {                    
                    if (!AutoriserBtNum)
                    {
                        MessageBox.Show("Cliquez sur un boutton avant de vouloir attribuer une valeur !");
                        KeyPressClear();
                    }
                }
            }
        }

        #region GESTION DES TABLES
        private string AfficherMsgBox { get; set; }
        private bool TableLibre()
        {
            Shell.Error e = new Shell.Error();
            bool acceptation = false;
            try
            {                
                if (Chaine != null && Chaine != "")
                {
                        Connexion BDD = new Connexion();
                        BDD.OpenBDD();
                        List<Data> datas = new List<Data>()
                        {
                            new Data(){ name = "table", valeur = Chaine },
                            new Data(){ name = "date" , valeur = DateTime.Now.ToShortDateString() }
                        };
                        string query = "Resto.Facture_checkTable";
                        BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
                        BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

                        //requete: SELECT NumTable FROM Resto.Facture WHERE date = datetime.now (AAAA/MM/JJ) AND NumTable = herit.Chaine (keypress) AND Facture_Cloturee = true;

                        BDD.SqlDr.Read();
                        if (Convert.ToInt32(BDD.SqlDr[0]) > 0)
                        {
                            if (AfficherMsgBox != "NO")
                            {
                                var result = MessageBox.Show("La table " + Chaine.ToString() + " est déjà attribuée, veuillez en selectionner une autre. Souhaitez vous afficher ce message la prochaine fois ?", "Information",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.No)
                                    AfficherMsgBox = "NO";
                                else
                                    AfficherMsgBox = "YES";
                            }
                            acceptation = false;
                        }
                        else
                        {
                            acceptation = true;
                        }
                        BDD.SqlDr.Close();
                }
                else
                {
                    acceptation = false;
                }
                return acceptation;
            }
            catch (SqlException ex)
            {
                string m = ex.ToString();
                // Erreur (non resolue, try/catch(sql) pour proteger), si l'on affecte 0 à Table (ex appui touche a 1-2-0)
                // > Desactivation du message d'erreur généré (qui n'affecte en rien le reste du programme de ce fait)
                //e.SQL_Error(ex);
            }
            catch (Exception ex)
            {
                e.C_Error(ex);
            }
            return acceptation;
        }
        #endregion
        #endregion
    }
    #endregion
}
