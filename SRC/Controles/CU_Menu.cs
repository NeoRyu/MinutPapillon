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
    public partial class CU_Menu : UserControl
    {
        #region VARIABLES
        DataGridView dgv;                                       // Création d'un objet DataGridView pour pouvoir le manipulier
        private string Nomtable = "MENU";                       // Nom de la table pour les != procédures stockées qui demande une table
        private string idModif = "0";
        #endregion

        #region CREATION ET INSTANCIATIONS DES CLASSES
        Connexion BDD = new Connexion();                        // Class de connexion avec la base de donnée
        User user;                                              // Création de la classe User, instanciation faite dans l'initatizeComponent pour récuperer des informations du à l'authentification
        Window Herit = new Window();                            // Class pour le déplacement entre les != Forms et UserControl
        Design Designer = new Design();                         // Class sur le design de l'application
        Rechercher search = new Rechercher();                   // Partie recherche (CU_Recherche) pour le DataGridView
        RequestData r = new RequestData();                      // Class pour l'éxécution des procédures stockées avec ou sans paramêtre
        ImportDGV import = new ImportDGV();
        GestionMenu gm = new GestionMenu();
        Materia invok = new Materia();
        #region SHELL
        Shell.Error Debug = new Shell.Error();
        Shell.Sanitize Clean = new Shell.Sanitize();
        #endregion
        #endregion

        public CU_Menu(User _user, DataGridView _dgv)
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
            gm.affichageCbMenu(BDD, cob_menu);
            gm.affichageCbMenuComposer(BDD, cob_selectMenu);
            gm.affichageCbArticle(BDD, cob_selectArticle);
        }

        #region MENU
        private void NettoyerComposant()
        {
            idModif = "0";
            tb_prixTTC.Clear();
            cb_disponible.CheckState = CheckState.Unchecked;
            dtp_dateAjout.Text = DateTime.Now.ToString();
        }

        private void affichageMenuContenu(List<string> datas)       // affiche les données de la provenance du combobox et du dgv
        {
            try
            {
                List<string> values = datas;

                idModif = values[0];
                if (Convert.ToBoolean(values[1]))
                    cb_disponible.Checked = true;
                else
                    cb_disponible.Checked = false;
                cob_menu.Text = values[2];
                dtp_dateAjout.Text = values[3];
                tb_prixTTC.Text = values[4];
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }

        private List<string> takeValuesMenu()                       // Prend tous les données dans les items TextBox, ComboBox et CheckBox
        {
            List<string> datas = new List<string>();
            if (cb_disponible.CheckState == CheckState.Checked)
                datas.Add("true");
            else
                datas.Add("false");
            datas.Add(cob_menu.Text);
            datas.Add(dtp_dateAjout.Text);
            datas.Add(Clean.replacePerPoint(tb_prixTTC.Text));
            return datas;
        }

        private void FonctionInsertMenu()                           // Fonction local pour l'ajout d'un menu
        {
            if (cob_menu.SelectedIndex != 0 && tb_prixTTC.Text != "")
            {
                gm.menuInsert(BDD, takeValuesMenu());
                // Recharge des composants nécessitants la base de données
                reloadDGV();
                reloadCB();
                NettoyerComposant();                                // Reset les composants de la form
            }
            else
                MessageBox.Show("Création d'un menu échoué", "Etat Ajout Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FonctionUpdateMenu()                           // Fonction local pour l'a modification d'un menu
        {
            if (idModif != "0" && cob_menu.SelectedIndex != 0 && tb_prixTTC.Text != "")
            {
                List<string> datas = takeValuesMenu();
                datas.Add(idModif);
                gm.menuUpdate(BDD, datas);
                // Recharge des composants nécessitants la base de données
                reloadDGV();
                reloadCB();
                NettoyerComposant();                                // Reset les composants de la form
            }
            else
                MessageBox.Show("Création d'un menu échoué", "Etat Ajout Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region COMPOSER
        private void activeButtonComposer()
        {
            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "LibelleMenu"   , valeur = cob_selectMenu.Text    },
                new Data(){ name = "LibelleArticle", valeur = cob_selectArticle.Text } 
            };

            if (cob_selectMenu.SelectedIndex != 0 && cob_selectArticle.SelectedIndex != 0 && cob_type.SelectedIndex != 0)
            {
                if (search.countRowRequest(BDD, "Resto.Composer_Comptage", datas) == 1)
                {
                    bt_ComposerAdd.Enabled = false;
                    bt_ComposerSupp.Enabled = true;
                }
                else
                {
                    bt_ComposerAdd.Enabled = true;
                    bt_ComposerSupp.Enabled = false;
                }
            }
        }

        private void changeMenuComposer()
        {
            dgv.Controls.Clear();
            if (cob_selectMenu.SelectedIndex != 0)
            {
                List<Data> datas = new List<Data>();
                datas.Add(new Data() { name = "LibelleMenu", valeur = cob_selectMenu.Text });
                search.affichage_dgv(BDD, dgv, "Resto.Composer_Affichage", datas);
            }

            activeButtonComposer();
        }

        private void changeArticleComposer()
        {
            if (cob_selectArticle.SelectedIndex != 0)
            {
                List<string> value = gm.affichagePrixArticle(BDD, cob_selectArticle.SelectedValue.ToString());
                tb_prixArticle.Text = value[0];
                lb_type.Text = value[1];
            }
            else
            {
                lb_type.Text = "Type de plat";
                tb_prixArticle.Text = "";
            }
            activeButtonComposer();
        }

        private void affichageTypePlat()                            // Affichage pour la ComboBox cob_type
        {
            cob_type.Items.Add("Sélectionnez un type de plat");
            cob_type.Items.Add("Entrée");
            cob_type.Items.Add("Plat Principal");
            cob_type.Items.Add("Dessert");
            cob_type.SelectedIndex = 0;
        }

        private List<string> TakeValuesComposer()
        {
            List<string> values = new List<string>();
            values.Add(cob_selectMenu.SelectedValue.ToString());
            values.Add(cob_selectArticle.SelectedValue.ToString());
            values.Add(cob_type.Text);
            return values;
        }

        private void FonctionInsertComposer()
        {
            gm.ComposerInsert(BDD, TakeValuesComposer());
            changeMenuComposer();
        }

        private void FonctionDeleteComposer()
        {
            gm.ComposerDelete(BDD, TakeValuesComposer());
            changeMenuComposer();
        }
        #endregion
        #endregion

        #region EVENEMENTS
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

        private void CU_Menu_Load(object sender, EventArgs e)
        {
            BDD.OpenBDD();
            dtp_dateAjout.Text = DateTime.Now.ToString();
            // Chargement du DataGridView
            reloadDGV();
            // Chargement des ComboBox
            reloadCB(); affichageTypePlat();
        }

        #region Appel Fonctions
        private void bt_load_Click(object sender, EventArgs e)
        {
            affichageMenuContenu(import.Requete_Importer(BDD, dgv, user, Nomtable));
        }

        private void cob_menu_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cob_menu.SelectedIndex != 0)
                affichageMenuContenu(gm.afficherMenu(BDD, cob_menu.Text));
        }

        private void bt_ItemAdd_Click(object sender, EventArgs e)
        {
            FonctionInsertMenu();
        }

        private void bt_ItemModif_Click(object sender, EventArgs e)
        {
            FonctionUpdateMenu();
        }

        private void cob_selectMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeMenuComposer();
        }

        private void cob_selectArticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeArticleComposer();
        }

        private void cob_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeButtonComposer();
        }

        private void bt_ComposerAdd_Click(object sender, EventArgs e)
        {
            FonctionInsertComposer();
        }

        private void bt_ComposerSupp_Click(object sender, EventArgs e)
        {
            FonctionDeleteComposer();
        }
        #endregion
        #endregion
    }
}
