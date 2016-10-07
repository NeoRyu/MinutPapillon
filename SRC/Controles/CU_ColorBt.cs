using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Librairies supplémentaires :
using System.Text.RegularExpressions;   // Regex + MatchCollection
using System.Data.SqlClient;            // SqlDataAdapter etc

namespace MinutPapillon
{
    public partial class CU_ColorBt : UserControl
    {
        #region VARIABLES
        DataGridView dgv;                             // Création d'un objet DataGridView pour pouvoir le manipulier
        //string Nomtable = "CONFIGCOLOR";              // Nom de la table pour les != procédures stockées qui demande une table
        #endregion

        #region INSTANCIATIONS
        Connexion BDD = new Connexion();                        // Class de connexion avec la base de donnée
        User user;                                              // Création de la classe User, instanciation faite dans l'initatizeComponent pour récuperer des informations du à l'authentification
        Window Herit = new Window();                            // Class pour le déplacement entre les != Forms et UserControl
        RequestData r = new RequestData();                      // Class pour l'éxécution des procédures stockées avec ou sans paramêtre
        ImportDGV import = new ImportDGV();

        Design ds = new Design();
        #region SHELL
        Shell.Error Debug = new Shell.Error();
        Shell.Sanitize Clean = new Shell.Sanitize();
        #endregion
        #endregion

        public CU_ColorBt(User _user, DataGridView _dgv)
        {
            InitializeComponent();
            user = _user;
            dgv = _dgv;

        }

        #region FONCTIONS
        private List<Button> PtBt = new List<Button>();

        public void Rainbow(Connexion BDD)
        {
            List<Data> PanelColorBt = new List<Data>();
            for (int i = 0; i < 13; i++)
            {
                Color Back = PtBt[i].BackColor;
                Color Fore = PtBt[i].ForeColor;

                PanelColorBt.Add(new Data() { name = "ConfCol_" + (i + 1), valeur = Back.ToArgb().ToString() });
                PanelColorBt.Add(new Data() { name = "ConfFont_" + (i + 1), valeur = Fore.ToArgb().ToString() });
            }
            PanelColorBt.Add(new Data() { name = "Random", valeur = cb_RandomButton.Checked.ToString() });

            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, "Resto.Color_Insert", PanelColorBt);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();
            BDD.SqlDr.Close();
        }

        public void PointeurButton()
        {
            // On crée une liste de boutons (pointeur) que l'on transferera ensuite dans une autre accessible dans tout le control user
            List<Button> ListButtons = new List<Button> { BtType1, BtType2, BtType3, BtType4, BtType5, BtType6, BtType7, BtType8, BtType9, BtType10, BtType11, BtType12, BtType13 };
            PtBt.AddRange(ListButtons);

            List<Button> PtBtFont = new List<Button> { BtFont1, BtFont2, BtFont3, BtFont4, BtFont5, BtFont6, BtFont7, BtFont8, BtFont9, BtFont10, BtFont11, BtFont12, BtFont13 };

            // On attribut à cette liste les couleurs de fond et de police que l'on recup de la BDD aux boutons du pointeur :
            for (int i = 0; i < 13; i++)
            {
                PtBt[i].BackColor = Design.ColorButton(BDD, (i + 1).ToString(), "BACK");
                PtBt[i].ForeColor = Design.ColorButton(BDD, (i + 1).ToString(), "FORE");

                PtBtFont[i].BackColor = Design.ColorButton(BDD, (i + 1).ToString(), "FORE");
                PtBtFont[i].ForeColor = Design.ColorButton(BDD, (i + 1).ToString(), "FORE");
            }

            if (Design.RandomButton)
                cb_RandomButton.CheckState = CheckState.Checked;
            else
                cb_RandomButton.CheckState = CheckState.Unchecked;
        }
        #endregion

        #region EVENEMENTS
        private void CU_ColorBt_Load(object sender, EventArgs e)
        {
            BDD.OpenBDD();
            ds.Importer_ColorBDD(BDD);
            PointeurButton();
        }

        private void BtColor_Click(object sender, EventArgs e)
        {
            // Ouverture de la boite de dialogue :
            DialogResult result = colorDialog1.ShowDialog();
            // Si on clic sur OK :
            if (result == DialogResult.OK)
            {
                // On defini alors la couleur :
                (sender as Button).BackColor = colorDialog1.Color;
            }
        }

        private void BtFontColor_Click(object sender, EventArgs e)
        {
            // Ouverture de la boite de dialogue :
            DialogResult result = colorDialog1.ShowDialog();
            // Si on clic sur OK :
            if (result == DialogResult.OK)
            {      
                // On recherche dans le nom du bouton tout les chiffres (qui serviront ensuite au pointeur de buttons)
                int chiffre = Convert.ToInt32(Clean.SearchNumInString((sender as Button).Name.ToString()));

                // Puis on lui defini la couleur de la police
                PtBt[chiffre-1].ForeColor = colorDialog1.Color;   // -1 car une List commence à 0
                // Et on colorise integrallement le carré pour un repère visuel plus important :
                (sender as Button).BackColor = colorDialog1.Color;
                (sender as Button).ForeColor = colorDialog1.Color;
            }
        }

        private void bt_SaveColor_Click(object sender, EventArgs e)
        {
                Rainbow(BDD);
                MessageBox.Show("Enregistrement effectué avec succès !");
        }
        #endregion
    }
}
