using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
// Libraires supplémentaires :
using System.Data.SqlClient;        // Gestion des Erreurs SQL & tt ce qui est Base de données


namespace MinutPapillon
{

    public partial class CU_Utilisateur : UserControl
    {
        #region VARIABLES
        DataGridView dgv;                       // Création d'un objet DataGridView pour pouvoir le manipulier
        string Nomtable = "UTILISATEUR";        // Nom de la table pour les != procédures stockées qui demande une table
        string idModif;                         // ID de l'utilisateur à modifier
        string idRole;                          // ID du role à Modifier 
        #endregion

        #region INSTANCIATIONS
        Connexion BDD = new Connexion();                        // Class de connexion avec la base de donnée
        User user;                                              // Création de la classe User, instanciation faite dans l'initatizeComponent pour récuperer des informations du à l'authentification
        Window Herit = new Window();                            // Class pour le déplacement entre les != Forms et UserControl
        Design Designer = new Design();                         // Class sur le design du l'application
        gestionUtilisateur gu = new gestionUtilisateur();       // partie gestion Utilisateur, comprend les méthode d'ajout et de modification
        Rechercher search = new Rechercher();                   // Partie recherche (CU_Recherche) pour le DataGridView
        RequestData r = new RequestData();                      // Class pour l'éxécution des procédures stockées avec ou sans 
        ImportDGV import = new ImportDGV();
        Materia invok = new Materia();
            #region SHELL
            Shell.Error Debug = new Shell.Error();
            Shell.Sanitize Clean = new Shell.Sanitize();
            #endregion
        #endregion

        public CU_Utilisateur(User _user, DataGridView _dgv)
        {
            InitializeComponent();
            user = _user;               // Instancitation de user, pas de "new" pour éviter de perdre les informations de connexion
            dgv = _dgv;                 // Instancitation de la DataGridView, permet d'utiliser l'objet même si l'objet ne fait pas partie du "UserControl" 
        }

        #region FONCTIONS
        public void Affichage_Requete_Textbox()
        {
            // Si l'utilisateur selectionne plusieurs lignes : valeur negative, donc :
            if (user.IDRowDGV >= 0)
            {
                // Création de la list "result", elle récupére les données suite à l'appelle de la fonction "Requete_Importer()"
                List<string> result = import.Requete_Importer(BDD, dgv, user, Nomtable);
                // Récupération de l'ID pôur faire la modification
                idModif = result[0].ToString();
                // On insere les données dans les textbox, modifie la couleur du texte (gris > noir) et de fond (blanc > vert)
                // Pour la List<Textbox>, puisque l'on n'affiche pas l'ID_User, on peut utiliser la valeur null palié à l'élément 0
                List<TextBox> NomTB = new List<TextBox> { null, tb_UserPseudo, tb_UserPassword, tb_UserNom, tb_UserPrenom, tb_UserTel };
                for (int i = 1; i <= 5; i++)
                {
                        NomTB[i].Text = result[i];
                        if (result[i] != "")
                        {
                            NomTB[i].ForeColor = Color.Black;
                            NomTB[i].BackColor = Color.Honeydew;
                        }
                        else
                            NomTB[i].BackColor = Color.MistyRose;
                }
                foreach (Item role in gu.Roles)
                {
                    if (role.Id == result[6])
                        cob_UserRole.Text = role.Libelle;
                }

                // Bouton de modification activé
                bt_UserUpdate.Enabled = true;
                // Bouton d'ajout désactivé
                bt_UserInsert.Enabled = false;
            }
        }

        private List<string> takeDataElement()               // Récupération des textbox pour l'envoie dans l'ajout ou la modif 
        {
            List<string> tbText = new List<string>();
            tbText.Add(tb_UserPseudo.Text);
            tbText.Add(tb_UserPassword.Text);
            tbText.Add(tb_UserNom.Text);
            tbText.Add(tb_UserPrenom.Text);
            tbText.Add(tb_UserTel.Text);
            tbText.Add(cob_UserRole.Text);

            return tbText;
        }

        public void Fonction_UserAdd()                      // Procédure d'ajout d'un Utilisateur
        {
            if ((tb_UserPseudo.Text != "") && (tb_UserPseudo.Text != "Pseudonyme")
                && (tb_UserPassword.Text != "") && (tb_UserPassword.Text != "Mot de passe")
                && (tb_UserNom.Text != "") && (tb_UserNom.Text != "Nom de famille")
                && (tb_UserPrenom.Text != "") && (tb_UserPrenom.Text != "Prénom")
                && (tb_UserTel.Text != "") && (tb_UserTel.Text != "Numéro de télephone")
                && (cob_UserRole.Text != ""))
            {
                gu.userInsert(BDD, takeDataElement());      // appelle de la procédure de ajout
                reloadDGV();                                // recharge du datagridview
            }
            else
            {
                Fonction_DonneeManquante();
            }
        }

        public void Fonction_UserUpdate()                   // Procédure de modification d'un Utilisateur
        {
            if ((tb_UserPseudo.Text != "") && (tb_UserPseudo.Text != "Pseudonyme")
                && (tb_UserPassword.Text != "") && (tb_UserPassword.Text != "Mot de passe")
                && (tb_UserNom.Text != "") && (tb_UserNom.Text != "Nom de famille")
                && (tb_UserPrenom.Text != "") && (tb_UserPrenom.Text != "Prénom")
                && (tb_UserTel.Text != "") && (tb_UserTel.Text != "Numéro de télephone")
                && (cob_UserRole.Text != ""))
            {
                List<string> datas = takeDataElement();     // création de la list et instanciation des champs
                datas.Add(idModif);                         // Ajout de l'id à la list
                gu.userUpdate(BDD, datas);                  // appelle de la procédure de modification
                reloadDGV();                                // recharge du datagridview

                // Controle des Boutons
                bt_UserInsert.Enabled = true;
                bt_UserUpdate.Enabled = false;
            }
            else
            {
                Fonction_DonneeManquante();
            }
        }

        public void Fonction_RoleInsert()                   // Procédure d'ajout d'un rôle
        {
            List<string> datas = new List<string>();
            datas.Add(cob_UserUpdateRole.Text);
            datas.Add(tb_UserUpdateRole.Text);
            gu.roleInsert(BDD, datas);
            reloadCB();
        }

        public void Fonction_RoleUpdate()                   // Procédure de modification d'un rôle
        {
            List<string> datas = new List<string>();
            datas.Add(idRole);
            datas.Add(cob_UserUpdateRole.Text);
            datas.Add(tb_UserUpdateRole.Text);
            gu.roleUpdate(BDD, datas);
            reloadCB();
        }

        private void reloadDGV()                            // Procédure de chargement ou recharge du DataGridView
        {
            List<Data> datas = new List<Data>();
            datas.Add(new Data() { name = "Table", valeur = Nomtable });
            search.affichage_dgv(BDD, dgv, "Resto.Affichage_DataGridView", datas);
            invok.affichageNomColonne(Nomtable, dgv);
        }

        private void reloadCB()                             // Procédure de chargement ou recharge des combobox
        {
            gu.affichageCbRole(BDD, cob_UserUpdateRole);
            gu.affichageCbRole(BDD, cob_UserRole);
        }
        #region FONCTION DE DESIGN : Si l'insertion n'est pas complète
        public void Fonction_DonneeManquante()
        {
            MessageBox.Show("Veuillez remplir tout les champs surligné en rouge pour valider l'envoi !");

            Color Origine = Color.White;    // Sert a pouvoir modifier rapidement le backcolor des textbox (si correcte)

            if (cob_UserRole.Text == "")
                cob_UserRole.BackColor = Color.MistyRose; // Seule valeur a modifier si on modif DesignTextbox !
            else
                cob_UserRole.BackColor = Origine;

            if ((tb_UserPseudo.Text == "") || (tb_UserPseudo.Text == "Pseudonyme"))
                Designer.HighlightTextbox(tb_UserPseudo, "incomplet", "Pseudonyme");
            else
                tb_UserPseudo.BackColor = Origine;

            if ((tb_UserPassword.Text == "") || (tb_UserPassword.Text == "Mot de passe"))
                Designer.HighlightTextbox(tb_UserPassword, "incomplet", "Mot de passe");
            else
                tb_UserPassword.BackColor = Origine;

            if ((tb_UserNom.Text == "") || (tb_UserNom.Text == "Nom de famille"))
                Designer.HighlightTextbox(tb_UserNom, "incomplet", "Nom de famille");
            else
                tb_UserNom.BackColor = Origine;

            if ((tb_UserPrenom.Text == "") || (tb_UserPrenom.Text == "Prénom"))
                Designer.HighlightTextbox(tb_UserPrenom, "incomplet", "Prénom");
            else
                tb_UserPrenom.BackColor = Origine;

            if ((tb_UserTel.Text == "") || (tb_UserTel.Text == "Numéro de télephone"))
                Designer.HighlightTextbox(tb_UserTel, "incomplet", "Numéro de télephone");
            else
                tb_UserTel.BackColor = Origine;
        }
        #endregion

        #endregion

        #region EVENEMENTS

        private void CU_Utilisateur_Load(object sender, EventArgs e)
        {
            BDD.OpenBDD();
            reloadDGV();
            reloadCB();
        }

        #region GESTION DES VALEURS DE SAISIES (PARSEUR)
        // Methode d'appel de la fonction Parseur XSS
        private void XSS_AppelProcedure(object sender, EventArgs e, string pattern)
        {
            Clean.Parseur_XSS_TbControl((sender as TextBox), pattern);
        }
        // Methodes definissant le pattern à utiliser :
        private void XSS_AlphaNum(object sender, EventArgs e)
        {
            XSS_AppelProcedure(sender, e, "");              // default
        }
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

        #region IMPORTER LES DONNEES DGV A AFFICHER
        private void bt_load_Click(object sender, EventArgs e)
        {
            Affichage_Requete_Textbox();
        }
        #endregion

        #region HIGHLIGH
        private void cob_UserRole_Click(object sender, EventArgs e)
        {
            if (cob_UserUpdateRole.BackColor == Color.MistyRose)
                cob_UserUpdateRole.BackColor = Color.Cornsilk;
            if (cob_UserUpdateRole.BackColor == Color.Gold)
                cob_UserUpdateRole.BackColor = Color.White;
        }
        private void tb_UserPseudo_Enter(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_UserPseudo, "clic", "Pseudonyme");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserPseudo_Leave(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_UserPseudo, "leave", "Pseudonyme");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_UserPassword, "clic", "Mot de passe");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_UserPassword, "leave", "Mot de passe");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserNom_Enter(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_UserNom, "clic", "Nom de famille");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserNom_Leave(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_UserNom, "leave", "Nom de famille");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserPrenom_Enter(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_UserPrenom, "clic", "Prénom");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserPrenom_Leave(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_UserPrenom, "leave", "Prénom");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserTel_Enter(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_UserTel, "clic", "Numéro de télephone");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserTel_Leave(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_UserTel, "leave", "Numéro de télephone");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void bt_UserInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Fonction_UserAdd();
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void bt_UserUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Fonction_UserUpdate();
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        #endregion

        #region UTILISATEUR : GESTION DES ROLES
        // Event click sur le bouton ajout role
        private void bt_UserRoleAdd_Click(object sender, EventArgs e)
        {
            Fonction_RoleInsert();
        }
        // Event click sur le bouton modif role
        private void bt_UserUpdateRole_Click(object sender, EventArgs e)
        {
            Fonction_RoleUpdate();
        }

        private void cob_UserUpdateRole_Click(object sender, EventArgs e)
        {
            // on bloque les évènements de la combobox
            cob_UserRole.Items.Clear();
            cob_UserRole.SuspendLayout();
            foreach (object item in cob_UserUpdateRole.Items)
                cob_UserRole.Items.Add(item);
            // on redémarre les évènements
            cob_UserRole.ResumeLayout(false);
        }
        private void cob_UserUpdateRole_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cob_UserRole.Text != "" || cob_UserRole.Text != "Selectionnez un rôle")
                {
                    foreach (Item role in gu.Roles)
                    {
                        if (role.Libelle == cob_UserUpdateRole.Text)
                        {
                            idRole = role.Id.ToString();
                            tb_UserUpdateRole.Text = role.NivRole.ToString();
                            tb_UserUpdateRole.ForeColor = Color.Red;
                            break;
                        }
                        else
                        {
                            tb_UserUpdateRole.Text = "";
                            tb_UserUpdateRole.ForeColor = Color.Gray;
                        }
                    }
                    tb_UserUpdateRole.Enabled = true;
                }
                else
                    tb_UserUpdateRole.Enabled = false;
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserUpdateRole_Enter(object sender, EventArgs e)
        {
            try
            {
                tb_UserUpdateRole.ForeColor = Color.Black;
                Designer.HighlightTextbox(tb_UserUpdateRole, "clic", "0");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserUpdateRole_Leave(object sender, EventArgs e)
        {
            try
            {
                Designer.HighlightTextbox(tb_UserUpdateRole, "leave", "0");
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void tb_UserUpdateRole_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Appel du parseur XSS :
                XSS_Numerique(sender, e);
                //Suite du code :
                if (tb_UserUpdateRole.ForeColor == Color.Red)
                    tb_UserUpdateRole.ForeColor = Color.Black;

                if ((tb_UserUpdateRole.Text != "") && (tb_UserUpdateRole.Text != "0"))
                {
                    foreach (Item role in gu.Roles)
                    {
                        if (role.Libelle == cob_UserUpdateRole.Text)
                        {
                            bt_UserUpdateRole.Enabled = true;
                            bt_UserRoleAdd.Enabled = false;
                            break;
                        }
                        else
                        {
                            bt_UserUpdateRole.Enabled = false;
                            bt_UserRoleAdd.Enabled = true;
                        }
                    }
                }
                else
                    bt_UserUpdateRole.Enabled = false;
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        #endregion

        private void KeypressEnter(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == 13))
                {
                    if ((sender == cob_UserUpdateRole) || (sender == tb_UserUpdateRole))
                    {
                        if (cob_UserUpdateRole.Text != "" && tb_UserUpdateRole.Text != "")
                        {
                            Fonction_RoleUpdate();
                        }
                    }
                    else
                    {
                        if (tb_UserPseudo.Text != "" && tb_UserPassword.Text != "" && tb_UserNom.Text != "" &&
                            tb_UserPrenom.Text != "" && tb_UserTel.Text != "" && cob_UserRole.Text != "")
                        {
                            if (bt_UserUpdate.Enabled)
                                Fonction_UserUpdate();
                            else
                                Fonction_UserAdd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }

        #endregion
    }    
}
