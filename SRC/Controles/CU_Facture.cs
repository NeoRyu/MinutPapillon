using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librairies supplémentaires :
using System.Data.SqlClient;        // Gestion des Erreurs SQL & tt ce qui est Base de données

namespace MinutPapillon
{
    public partial class CU_Facture : UserControl
    {
        #region VARIABLES
        //string Nomtable = "CONFIGFACTURE";              // Nom de la table pour les != procédures stockées qui demande une table
        public List<string> ConfigFacture = new List<string>();
        #endregion

        #region INSTANCIATIONS
        Connexion BDD = new Connexion();                        // Class de connexion avec la base de donnée
        User user;                                              // Création de la classe User, instanciation faite dans l'initatizeComponent pour récuperer des informations du à l'authentification
        DataGridView dgv;                             // Création d'un objet DataGridView pour pouvoir le manipulier
        Window Herit = new Window();                            // Class pour le déplacement entre les != Forms et UserControl
        RequestData r = new RequestData();                      // Class pour l'éxécution des procédures stockées avec ou sans paramêtre
        ImportDGV import = new ImportDGV();

        Design ds = new Design();
        #region SHELL
        Shell.Error Debug = new Shell.Error();
        Shell.Sanitize Clean = new Shell.Sanitize();
        #endregion
        #endregion

        public CU_Facture(User _user, DataGridView _dgv)
        {
            InitializeComponent();
            user = _user;
            dgv = _dgv;
        }

        #region FONCTIONS
        private void BDDConfigFacture()
        {
            try
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
                CUAutoComplete();    // On rempli automatiquement les textbox et combobox du CU
            }
            catch (SqlException ex)
            {
                Debug.SQL_Error(ex);
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }

        private void CUAutoComplete()
        {
            try
            {
                // On rempli le contenu des combobx :

                cob_Font_Titre.Text = ConfigFacture[0];
                cob_Font_Header.Text = ConfigFacture[1];
                cob_Font_Body.Text = ConfigFacture[2];
                cob_Font_Footer.Text = ConfigFacture[3]; 

                // On rempli le contenu des textbox :
                tb_Titre.Text = ConfigFacture[4];
                tb_Description.Text = ConfigFacture[5];
                tb_Adresse.Text = ConfigFacture[6];
                tb_NumTel.Text = ConfigFacture[7];
                tb_Thanks.Text = ConfigFacture[8];
                tb_Mention.Text = ConfigFacture[9]; 
            }
            catch (SqlException ex)
            {
                Debug.SQL_Error(ex);
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        #endregion

        #region EVENEMENTS
        private void CU_Facture_Load(object sender, EventArgs e)
        {
            try
            {
                BDD.OpenBDD();
                BDDConfigFacture();  // Recupération des données SQL 

                //// DEBUG MODE :
                //foreach (string lol in ConfigFacture)
                //{
                //    MessageBox.Show(lol);
                //}
            }
            catch (SqlException ex)
            {
                Debug.SQL_Error(ex);
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }           
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            try
            {
                List<Data> datas = new List<Data>();
                datas.Add(new Data() { name = "FontSizeTitle", valeur = cob_Font_Titre.Text });
                datas.Add(new Data() { name = "FontSizeMax", valeur = cob_Font_Header.Text });
                datas.Add(new Data() { name = "FontSizeNor", valeur = cob_Font_Body.Text });
                datas.Add(new Data() { name = "FontSizeMin", valeur = cob_Font_Footer.Text });
                datas.Add(new Data() { name = "LibTitle", valeur = tb_Titre.Text });
                datas.Add(new Data() { name = "LibDesc", valeur = tb_Description.Text });
                datas.Add(new Data() { name = "LibAdresse", valeur = tb_Adresse.Text });
                datas.Add(new Data() { name = "LibNumTel", valeur = tb_NumTel.Text });
                datas.Add(new Data() { name = "LibThanks", valeur = tb_Thanks.Text });
                datas.Add(new Data() { name = "LibMention", valeur = tb_Mention.Text });

                string query = "resto.ConfigFac_Insert";

                BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
                if (BDD.SqlCmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Modification réalisée avec succès !");
                }
                else
                {
                    MessageBox.Show("Echec lors de la modification, veuillez reessayer svp !", "Erreur");
                }
                BDD.SqlDr.Close();
            }
            catch (SqlException ex)
            {
                Debug.SQL_Error(ex);
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        #endregion
    }
}
