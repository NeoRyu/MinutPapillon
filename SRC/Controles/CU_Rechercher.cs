using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinutPapillon
{
    public partial class CU_Rechercher : UserControl
    {
        #region INSTANCIATIONS        
        Window Herit = new Window();
        Design Designer = new Design();
        Connexion BDD = new Connexion();
        Rechercher Search = new Rechercher();       
        User user; // Création de la classe User, instanciation faite dans l'initatizeComponent
        DataGridView dgv; // Création d'un objet DataGridView pour pouvoir le manipulier
        Materia invok = new Materia();
        #region SHELL
            Shell Description = new Shell();
            Shell.Error Debug = new Shell.Error();
            Shell.Sanitize Clean = new Shell.Sanitize();
        #endregion
        #endregion

        private string NomDeLaTable;    // Variable globale contenant soit : UTILISATEUR / CARTE / MENU / FACTURE / STOCK / STATSCONSO
        public string DescTextbox;

        public CU_Rechercher(User _user, DataGridView _dgv, string NomTable)
        {
            InitializeComponent();
            NomDeLaTable = NomTable;
            user = _user; // recup de l'instancitation de user, pas de "new" pour éviter de perdre les informations de connexion !
            dgv = _dgv;   // Instancitation du DataGridView, permet d'utiliser l'objet même si l'objet ne fait pas partie du "UserControl" 
        }

        #region FONCTIONS
        public void Combobox_Search_Elements()
        {
            // GENERATION DE LA COMBOBOX SELON LE CONTROL UTILISATEUR EN COURS :
            cob_Search.DisplayMember = "Text";
            cob_Search.ValueMember = "Value";

            switch (NomDeLaTable) //Le control utilisateur en cours passe le nom de la table a interrogée en parametre du main de CU_Rechercher
            {
                #region UTILISATEUR
                case "UTILISATEUR":
                    {
                        // Creation d'une liste contenant les string à afficher et les valeurs (celles de la bdd) qui seront envoyées à la procédure stockée :
                        var items = new[] { 
                            new { Text = "", Value = "" }, 
                            new { Text = "Pseudonyme", Value = "User_Pseudo" }, 
                            new { Text = "Mot de passe", Value = "User_Password" }, 
                            new { Text = "Nom de famille", Value = "User_NomReel" },
                            new { Text = "Prénom", Value = "User_PrenomReel" },
                            new { Text = "Numéro de téléphone", Value = "User_Telephone" }
                        };
                        cob_Search.DataSource = items;
                        break;
                    }
                #endregion
                #region CARTE
                case "CARTE":
                    {

                        var items = new[] { 
                            new { Text = "", Value = "" }, 
                            new { Text = "Nom de l'article", Value = "Article_Nom" }, 
                            new { Text = "Format / Description", Value = "Article_Format" }, 
                            new { Text = "Prix HT", Value = "Article_PrixHT" },
                            new { Text = "Quantité en Stock", Value = "Article_QuantiteEnStock" },
                            new { Text = "Article dispo", Value = "Article_Disponible" },                            
                            new { Text = "En supplément", Value = "Article_Supplement" },                               
                            new { Text = "Alcoolisé", Value = "Article_Alcoolise" }
                        };
                        cob_Search.DataSource = items;
                        break;

                    };
                #endregion
                #region MENU
                case "MENU":
                    {

                        var items = new[] { 
                            new { Text = "", Value = "" }, 
                            new { Text = "Nom du menu", Value = "Menu_Libelle" }, 
                            new { Text = "Menu disponible", Value = "Menu_Disponible" }, 
                            new { Text = "Prix TTC (= ou sup)", Value = "Menu_PrixTTC" }
                        };
                        cob_Search.DataSource = items;
                        break;

                    };
                #endregion
                #region FACTURE
                case "FACTURE":
                    {

                        var items = new[] { 
                            new { Text = "", Value = "" }, 
                            new { Text = "Numéro de facture", Value = "ID_Facture" }, 
                            new { Text = "Date de facturation", Value = "Facture_DateCrea" }, 
                            new { Text = "Numéro de table", Value = "Facture_TableNum" },
                            new { Text = "Nombre de ouverts", Value = "Facture_NbrCouvert" }, 
                            new { Text = "Prix Total TTC (= ou sup)", Value = "Facture_PrixTotalTTC" }, 
                            new { Text = "Facture Validée", Value = "Facture_Validee" }, 
                            new { Text = "Facture Cloturée", Value = "Facture_Cloturee" }, 
                            new { Text = "Facture Modifiée", Value = "Facture_Modifiee" }, 
                        };
                        cob_Search.DataSource = items;
                        break;

                    };
                #endregion
                #region STOCK
                case "STOCK":
                    {
                        var items = new[] { 
                            new { Text = "", Value = "" }, 
                            new { Text = "Nom de l'article", Value = "ID_Article" }, 
                            new { Text = "Nom du fournisseur", Value = "Stock_Fournisseur" }, 
                            new { Text = "Date d'achat", Value = "Stock_DateAchat" }, 
                            new { Text = "Prix d'achat unitaire", Value = "Stock_PrixAchatUnit" }
                        };
                        cob_Search.DataSource = items;
                        break;

                    };
                #endregion
                #region STATSCONSO
                case "STATSCONSO":
                    {
                        var items = new[] { 
                            new { Text = "", Value = "" }, 
                            new { Text = "Vendu(s) [Carte]", Value = "Article_VenduCarte" }, 
                            new { Text = "Vendu(s) [Menu]", Value = "Article_VenduMenu" }, 
                            new { Text = "Offert [supplément]", Value = "Article_Offert" }, 
                            new { Text = "Détruit", Value = "Article_Detruit" }
                        };
                        cob_Search.DataSource = items;
                        break;

                    };
                #endregion
                default:
                    break;
            }
        }

        public List<string> Param()
        {
            List<string> Param = new List<string>();
            Param.Add(NomDeLaTable);                            // Nom de la table de la BDD
            Param.Add(cob_Search.SelectedValue.ToString());     // Nom du champs de la BDD
            Param.Add(tb_Search.Text);
            return Param;
        }

        public void Fonction_Search(string NomDuChamps, string RechercherMot)
        {
            Search.rechercheItem(BDD, dgv, Param());
        }
        #endregion

        #region EVENEMENTS

        private void CU_Rechercher_Load(object sender, EventArgs e)
        {
            BDD.OpenBDD();
            Combobox_Search_Elements();
        }

        #region GESTION DES VALEURS DE SAISIES (PARSEUR)
        // Methode d'appel de la fonction Parseur XSS
        private void XSS_AppelProcedure(object sender, EventArgs e, string pattern)
        {
            Clean.Parseur_XSS_TbControl((sender as TextBox), pattern);
        }
        // Methodes definissant le pattern à utiliser :
        private void XSS_Alphabetique(object sender, EventArgs e)
        {
            XSS_AppelProcedure(sender, e, "alphabetique");
        }
        private void XSS_AlphaNumQuote(object sender, EventArgs e)
        {
            XSS_AppelProcedure(sender, e, "alpha'num");
        }
        private void XSS_AlphaNum(object sender, EventArgs e)
        {
            XSS_AppelProcedure(sender, e, "");  // default
        }
        private void XSS_Numerique(object sender, EventArgs e)
        {
            XSS_AppelProcedure(sender, e, "int");
        }
        private void XSS_Float(object sender, EventArgs e)
        {
            XSS_AppelProcedure(sender, e, "float");
        }
        private void XSS_Boolen(object sender, EventArgs e)
        {
            XSS_AppelProcedure(sender, e, "bool");
        }
        #endregion

        #region DESIGN
        #region TextBox
        private void tb_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_Search.Text == DescTextbox)
                {
                    tb_Search.Text = "";
                    tb_Search.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_Search_Enter(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_Search, "clic", DescTextbox);
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_Search_Leave(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_Search, "leave", DescTextbox);
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Activation du parseur XSS :
                XSS_AlphaNumQuote(sender, e);

                if ((tb_Search.Text != DescTextbox) && (tb_Search.Text != ""))
                {
                    bt_Search.Enabled = true;
                }
                else
                {
                    bt_Search.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (cob_Search.Text != "" && tb_Search.Text != "")
                {
                    Fonction_Search(tb_Search.Text, cob_Search.Text);
                }
                //else
                //{
                //        List<Data> datas = new List<Data>();
                //        datas.Add(new Data() { name = "Table", valeur = NomDeLaTable });
                //        Search.affichage_dgv(BDD, dgv, "Resto.Affichage_DataGridView", datas);
                //        Designer.affichageNomColonne(NomDeLaTable, dgv);
                //}
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        #endregion

        #region ComboBox
        private void cob_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (cob_Search.Text != "" && tb_Search.Text != "")
                {
                    Fonction_Search(tb_Search.Text,cob_Search.Text);
                }
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void cob_Search_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {                
                DescTextbox = invok.Combobox_Search_Description(NomDeLaTable, cob_Search.Text);

                if (cob_Search.Text != "")
                {
                    tb_Search.Enabled = true;
                    tb_Search.Text = DescTextbox;
                    if ((tb_Search.Text != DescTextbox) && (tb_Search.Text != ""))
                    {
                        bt_Search.Enabled = true;
                    }
                }
                else
                {
                    tb_Search.Enabled = false;
                    bt_Search.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        #endregion

        #region Button
        private void bt_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (cob_Search.Text != "" && tb_Search.Text != "")
                {
                    Fonction_Search(cob_Search.Text, tb_Search.Text);
                }
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        #endregion
        #endregion

        #endregion
    }
}
