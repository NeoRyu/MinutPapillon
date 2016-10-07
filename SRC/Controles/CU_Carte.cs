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
    public partial class CU_Carte : UserControl
    {
        #region VARIABLES
        DataGridView dgv;                       // Création d'un objet DataGridView pour pouvoir le manipulier
        string Nomtable = "CARTE";              // Nom de la table pour les != procédures stockées qui demande une table
        string idModif;
        #endregion

        #region INSTANCIATIONS
        Connexion BDD = new Connexion();                        // Class de connexion avec la base de donnée
        User user;                                              // Création de la classe User, instanciation faite dans l'initatizeComponent pour récuperer des informations du à l'authentification
        Window Herit = new Window();                            // Class pour le déplacement entre les != Forms et UserControl
        Design Designer = new Design();                         // Class sur le design de l'application
        Rechercher search = new Rechercher();                   // Partie recherche (CU_Recherche) pour le DataGridView
        RequestData r = new RequestData();                      // Class pour l'éxécution des procédures stockées avec ou sans paramêtre
        ImportDGV import = new ImportDGV();
        GestionCarte gc = new GestionCarte();                   // partie gestion de la Carte, comprend les méthode d'ajout et de modification 
        Materia invok = new Materia();
            #region SHELL
            Shell.Error Debug = new Shell.Error();
            Shell.Sanitize Clean = new Shell.Sanitize();
            #endregion

        #endregion

        public CU_Carte(User _user, DataGridView _dgv)
        {
            InitializeComponent();
            user = _user;
            dgv = _dgv;
        }

        #region FONCTIONS
        private void reloadDGV()
        {
            List<Data> datas = new List<Data>();
            datas.Add(new Data() { name = "Table", valeur = Nomtable });
            search.affichage_dgv(BDD, dgv, "Resto.Affichage_DataGridView", datas);
            invok.affichageNomColonne(Nomtable, dgv);
        }

        private void reloadCB()
        {
            gc.affichageCb(BDD, cob_ItemTVA, "tva");
            gc.affichageCb(BDD, cob_ItemType, "type");
        }

        private bool cbeckboxReturn(string check)
        {
            if (Convert.ToBoolean(check))
                return true;
            else
                return false;
        }

        public void Affichage_Requete_Textbox()
        {
            // Si l'utilisateur selectionne plusieurs lignes : valeur negative, donc :
            if (user.IDRowDGV >= 0)
            {
                // Création de la list "result", elle récupére les données suite à l'appelle de la fonction "Requete_Importer()"
                List<string> result = import.Requete_Importer(BDD, dgv, user, Nomtable);
                // Récupération de l'ID pôur faire la modification
                idModif = result[0].ToString();

                // remplissage des données pour les textbox
                tb_ItemName.Text = result[2].ToString();
                tb_ItemInfo.Text = result[3].ToString();
                tb_ItemPrice.Text = result[4].ToString();
                tb_ItemQuantity.Text = result[9].ToString();
                
                // checkbox disponibilité
                cb_ItemDispo.Checked = cbeckboxReturn(result[1].ToString());
                // checkbox Supplément
                cb_ItemSup.Checked = cbeckboxReturn(result[5].ToString());
                // checkbox Préférence
                cb_ItemPref.Checked = cbeckboxReturn(result[6].ToString());
                // checkbox Alcoolisé
                cb_ItemAlcool.Checked = cbeckboxReturn(result[7].ToString());

                // Bouton de modification activé
                bt_ItemAdd.Enabled = true;

                // Bouton d'ajout désactivé
                bt_ItemModif.Enabled = false;

                foreach (Item type in gc.Type)
                {
                    if (type.Id == result[10])
                        cob_ItemType.Text = type.Libelle;
                }

                foreach (Item tva in gc.TVA)
                {
                    if (tva.Id == result[11])
                        cob_ItemTVA.Text = tva.Libelle;
                }

                // Button Ajout est désactivé
                bt_ItemAdd.Enabled = false;
                // Button modification est activé
                bt_ItemModif.Enabled = true;
            }
        }

        #region IMPORTATION D'UNE IMAGE [ TODO : Stocker sur serveur ]
        private void pic_ItemPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Fonctionnalité ne fonctionnant que localement...","AVERTISSEMENT");
                //pic_ItemPhoto.Image = null;
                OpenFileDialog ChoixPhoto = new OpenFileDialog();
                ChoixPhoto.Filter = "Afficher tout les fichiers|*.*|Afficher les images|*.png; *.png; *.jpg; *.jpeg; *.gif; *.bmp|Portable Network Graphics (PNG)|*.png|Joint Photographic Experts Group (JPEG)|*.jpg; *.jpeg|Graphics Interchange Format (GIF)|*.gif|Image Bitmap (BMP)|*.bmp";
                ChoixPhoto.ShowDialog();
                Image Photo = new Bitmap(ChoixPhoto.FileName);
                pic_ItemPhoto.BackgroundImage = Photo;
                // Recuperer par la suite Photo pour l'heberger sur le serveur et editer l'url dans la bdd par celle du serveur
            }
            catch
            {
                // Si l'utilisateur admin ferme la fenetre sans selectionner de fichier, on evite l'erreur d'exception par le try/catch !
                // moyen d'ameliorer le shell apres pour gerer le type d'erreur
            }
        }
        #endregion

        private string valueCheckbox(CheckBox check)
        {
            string val;
            if (check.CheckState == CheckState.Checked)
                val = "true";
            else
                val = "false";
            return val;
        }

        private void cleanElement()
        {
            tb_ItemName.Text = "Nom de l'article";
            cob_ItemType.SelectedIndex = 0;
            tb_ItemInfo.Text = "Format, Description, ...";
            tb_ItemPrice.Text = "Prix";
            tb_ItemQuantity.Text = "Quantité en stock";
            cb_ItemDispo.CheckState = CheckState.Unchecked;
            cb_ItemAlcool.CheckState = CheckState.Unchecked;
            cb_ItemSup.CheckState = CheckState.Unchecked;
            cb_ItemPref.CheckState = CheckState.Unchecked;
        }

        private List<string> takeDataElement()
        {
            List<string> datas = new List<string>();
                datas.Add(valueCheckbox(cb_ItemDispo));                     // CheckBox disponible
                datas.Add(tb_ItemName.Text);                                // TextBox Nom
                datas.Add(tb_ItemInfo.Text);                                // TextBox Format / info
                datas.Add(Clean.replacePerPoint(tb_ItemPrice.Text));                               // TextBox prix HT
                datas.Add(valueCheckbox(cb_ItemSup));                       // CheckBox Supplément
                datas.Add(valueCheckbox(cb_ItemPref));                      // CheckBox Préférence
                datas.Add(valueCheckbox(cb_ItemAlcool));                    // CheckBox Alcoolisé
                datas.Add(null);                                            // Pour l'image
                datas.Add(tb_ItemQuantity.Text);                            // TextBox Quantité disponible
                datas.Add(cob_ItemType.Text);                               // ComboBox Type produit
                datas.Add(Clean.replacePerPoint(cob_ItemTVA.Text));         // ComboBox Taux TVA
            return datas;
        }
        

        private void Fonction_CarteInsert()
        {
            //try
            //{
                List<string> datas = takeDataElement();
                if (datas[1] != "" && datas[2] != "" && datas[3] != "" && datas[8] != "" && cob_ItemType.SelectedIndex != 0 && cob_ItemTVA.SelectedIndex != 0
                    && datas[1] != "Nom de l'article" && datas[2] != "Format, Description, ..." && datas[3] != "Prix" && datas[8] != "Quantité en stock")
                {
                    gc.carteInsert(BDD, datas);      // appelle de la procédure de ajout
                    reloadDGV();
                    cleanElement();
                }
                else
                {
                    MessageBox.Show("Des champs sont manquants","Etat Ajout Carte");
                }
            //}
            //catch (Exception ex)
            //{
            //    Debug.C_Error(ex);
            //}
        }

        private void Fonction_CarteUpdate()
        {
            try
            {
                List<string> datas = takeDataElement();
                datas.Add(idModif);
                if (datas[1] != "" && datas[2] != "" && datas[3] != "" && datas[8] != "" && cob_ItemType.SelectedIndex != 0 && cob_ItemTVA.SelectedIndex != 0 && datas[11] != ""
                    && datas[1] != "Nom de l'article" && datas[2] != "Format, Description, ..." && datas[3] != "Prix" && datas[8] != "Quantité en stock")
                {
                    gc.carteUpdate(BDD, datas);      // appelle de la procédure de ajout
                    reloadDGV();
                    cleanElement();
                }
                else
                {
                    MessageBox.Show("Des champs sont manquants", "Etat Modification Carte");
                }
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }

        #endregion

        #region EVENEMENTS

        private void CU_Carte_Load(object sender, EventArgs e)
        {
            BDD.OpenBDD();
            reloadDGV();
            reloadCB();
        }
        private void bt_load_Click(object sender, EventArgs e)
        {
            Affichage_Requete_Textbox();
        }

        private void bt_ItemAdd_Click(object sender, EventArgs e)
        {
            Fonction_CarteInsert();
        }

        private void bt_ItemModif_Click(object sender, EventArgs e)
        {
            Fonction_CarteUpdate();
        }

        #region GESTION DES VALEURS DE SAISIES (PARSEUR)
        // Methode d'appel de la fonction Parseur XSS
        private void XSS_AlphaNum(object sender, EventArgs e)
        {
            XSS_AppelProcedure(sender, e, "");  // default
        }
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

        #region HIGHLIGH
        private void tb_ItemName_Enter(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_ItemName, "clic", "Nom de l'article");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }

        private void tb_ItemName_Leave(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_ItemName, "leave", "Nom de l'article");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }

        private void tb_ItemInfo_Enter(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_ItemInfo, "clic", "Format, Description, ...");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        
        private void tb_ItemInfo_Leave(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_ItemInfo, "leave", "Format, Description, ...");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }

        private void tb_ItemPrice_Enter(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_ItemPrice, "clic", "Prix");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        #endregion;

        private void tb_ItemPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_ItemPrice, "leave", "Prix");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }

        private void tb_ItemQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_ItemQuantity, "clic", "Qte stock");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }

        private void tb_ItemQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_ItemQuantity, "leave", "Qte stock");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        #endregion;
    }
}
