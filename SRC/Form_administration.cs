using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Libraires supplémentaires :
using System.Data.SqlClient;        // Gestion des Erreurs SQL & tt ce qui est Base de données

namespace MinutPapillon
{
    public partial class Form_administration : Form
    {
        #region INSTANCIATIONS
            User user;  // Inutile de reinstancier, on souhaite garder la connexion ! =)
            Window herit = new Window();
            Connexion BDD = new Connexion();
        #endregion

        private string Nomtable; 

        public Form_administration(User _user)
        {
            InitializeComponent();

            user = _user;

            #region DESIGN
            // Gestion de la colorisation de la barre menu (ToolStrip)
            ms_Navigation.Renderer = new Design.MyRenderer();

            // Gestion de la colorisation des info-bulles  (ToolTip)
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.MistyRose;
            #endregion
        }

        #region FONCTIONS
        #endregion

        #region EVENEMENTS
        
        private void Form_administration_Load(object sender, EventArgs e)
        {
            lb_NameAdmin.Text = user.nomLabel(user);                                    // Affichage nom et prenom de l'admin
            Nomtable = "FACTURE";
            herit.OpenControlUser(user, gb_panel, dataGridView, Nomtable,this);         // Ouverture des control_user
            BDD.OpenBDD();
            if (EasterEggActivate)  lb_EasterEgg.Visible = true;
            //Picture.Rotate;
        }

        // GESTION COULEURS DES INFOBULLES
        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            Design MyDesign = new Design();
            MyDesign.ColorTooltip(sender, e, toolTip1);
        }

        #region BOUTON DECONNECTION
        private void bt_Deconnection_MouseHover(object sender, EventArgs e)
        {
            bt_Deconnection.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.logout_on));
            toolTip1.SetToolTip(bt_Deconnection, "Deconnexion");
        }
        
        private void bt_Deconnection_MouseLeave(object sender, EventArgs e)
        {
            bt_Deconnection.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.logout_off));
        }

        private void bt_Deconnection_Click(object sender, EventArgs e)
        {
            // FONCTION DECONNECTION
            herit.FormUserDeco(this);
        }

        private void ts_sm_Deconnexion_Click(object sender, EventArgs e)
        {
            herit.FormUserDeco(this);
        }

        private void ts_sm_Quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region BOUTON INTERFACE SERVEUR
        private void bt_InterfaceServ_MouseHover(object sender, EventArgs e)
        {
            bt_InterfaceServ.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.interfaceserveur_on));  
            toolTip1.SetToolTip(bt_InterfaceServ, "Accès à l'interface de prise de commandes");
        }

        private void bt_InterfaceServ_MouseLeave(object sender, EventArgs e)
        {
            bt_InterfaceServ.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.interfaceserveur_off));  
        }

        private void bt_InterfaceServ_Click(object sender, EventArgs e)
        {
            // APPEL DE LA PAGE SERVEUR
            Form_commandes commande = new Form_commandes(user);
            commande.Show();
            this.Hide();
        }
        #endregion

        #region Navigation
        private void ts_m_User_Click(object sender, EventArgs e)
        {
            Nomtable = "UTILISATEUR";
            herit.OpenControlUser(user, gb_panel, dataGridView, Nomtable,this);
        }        

        private void ts_m_Article_Click(object sender, EventArgs e)
        {
            Nomtable = "CARTE";
            herit.OpenControlUser(user, gb_panel, dataGridView, Nomtable, this);
        }

        private void ts_m_Menu_Click(object sender, EventArgs e)
        {
            Nomtable = "MENU";
            herit.OpenControlUser(user, gb_panel, dataGridView, Nomtable, this);
        }

        private void ts_m_Stocks_Click(object sender, EventArgs e)
        {
            Nomtable = "STOCK";
            herit.OpenControlUser(user, gb_panel, dataGridView, Nomtable, this);
        }

        private void ts_m_Commande_Click(object sender, EventArgs e)
        {
            Nomtable = "FACTURE";
            herit.OpenControlUser(user, gb_panel, dataGridView, Nomtable, this);
        }

        private void ts_m_Stats_Click(object sender, EventArgs e)
        {
            Nomtable = "STATISTIQUES";
            herit.OpenControlUser(user, gb_panel, dataGridView, Nomtable, this);
        }

        private void ts_sm_ColorBt_Click(object sender, EventArgs e)
        {
            Nomtable = "CONFIGCOLOR";
            herit.OpenControlUser(user, gb_panel, dataGridView, Nomtable, this);
        }

        private void ts_sm_ModFacture_Click(object sender, EventArgs e)
        {
            Nomtable = "CONFIGFACTURE";
            herit.OpenControlUser(user, gb_panel, dataGridView, Nomtable, this);
        }

        private void ts_sm_About_Click(object sender, EventArgs e)
        {
            Form_about about = new Form_about();
            about.ShowDialog();
        }

        #region HELP
        public string Path = Application.StartupPath;
        private void partieAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string PathOfMyDoc = @Path + "\\HOW TO USE IT - ADMIN.pdf"; // Le copier dans le dossier Debug
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(PathOfMyDoc, "PDF"));

        }

        private void partieServeurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string PathOfMyDoc = @Path + "\\HOW TO USE IT - SERVEUR.pdf"; // Le copier dans le dossier Debug
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(PathOfMyDoc, "PDF"));
        }
        #endregion
        #endregion

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                //On tranmet en variable globale (int virtuel) le rowindex du datagridview 
                user.IDRowDGV = Convert.ToInt32(e.RowIndex);

                //// CI DESSOUS - NE FONCTIONNE PAS : PROBLEME DE PORTEE DES TEXTBOXS (AUCUN REFRESH POSSIBLE !
                //CU_Utilisateur CU_USER = new CU_Utilisateur(user, dataGridView);
                //CU_USER.Affichage_Requete_Textbox();
        }
        #endregion

        #region EASTER EGG
        private bool EasterEggActivate = true;
        private void lb_EasterEgg_Click(object sender, EventArgs e)
        {
            lb_EasterEgg.Visible = false;
            if (EasterEggActivate)
            {
                // On agrandi au maximum la fenetre
                this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                this.MinimumSize = this.MaximumSize;
                this.WindowState = FormWindowState.Maximized;
                //On affiche l'EasterEgg
                pictureBox1.Visible = true;
                MessageBox.Show("Why so serious ?","Joker said :");  
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }
        #endregion


    }
}
