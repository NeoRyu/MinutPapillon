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
    public partial class CU_Stock : UserControl
    {
        #region VARIABLES
        DataGridView dgv;                       // Création d'un objet DataGridView pour pouvoir le manipulier
        //string Nomtable = "STOCK";              // Nom de la table pour les != procédures stockées qui demande une table
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

            #region SHELL
            Shell.Error Debug = new Shell.Error();
            Shell.Sanitize Clean = new Shell.Sanitize();
            #endregion

        #endregion

        public CU_Stock(User _user, DataGridView _dgv)
        {
            InitializeComponent();
            user = _user;
            dgv = _dgv;
        }

        #region FONCTIONS
        #endregion

        #region EVENEMENTS
        private void CU_Stock_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Gestion des stocks non implémentée","AVERTISSEMENT");
        }
        #endregion
    }
}
