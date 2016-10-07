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
    public partial class CU_Commande : UserControl
    {
        #region VARIABLES
        DataGridView dgv;                             // Création d'un objet DataGridView pour pouvoir le manipulier
        string Nomtable = "FACTURE";            // Nom de la table pour les != procédures stockées qui demande une table
        #endregion

        #region INSTANCIATIONS
        Connexion BDD = new Connexion();                        // Class de connexion avec la base de donnée
        User user;                                              // Création de la classe User, instanciation faite dans l'initatizeComponent pour récuperer des informations du à l'authentification
        Window Herit = new Window();                            // Class pour le déplacement entre les != Forms et UserControl
        RequestData r = new RequestData();                      // Class pour l'éxécution des procédures stockées avec ou sans paramêtre
        ImportDGV import = new ImportDGV();
        Rechercher search = new Rechercher();                   // Partie recherche (CU_Recherche) pour le DataGridView
        Materia invok = new Materia();
        Design ds = new Design();
        #region SHELL
        Shell.Error Debug = new Shell.Error();
        Shell.Sanitize Clean = new Shell.Sanitize();
        #endregion

        #endregion

        public CU_Commande(User _user, DataGridView _dgv)
        {
            InitializeComponent();
            user = _user;
            dgv = _dgv;
        }

        #region FONCTIONS
        private void reloadDGV(string Valeur)
        {
            List<Data> datas = new List<Data>();
            datas.Add(new Data() { name = "Date", valeur = DateJour() });
            datas.Add(new Data() { name = "Valeur", valeur = Valeur });
            search.affichage_dgv(BDD, dgv, "Resto.Affichage_DGV_RELCommander", datas);
            invok.affichageNomColonne(Nomtable, dgv);
        }

        private string DateJour()
        {
            // Affichage de la date actuelle :  
            string Jour, Mois, Annee;
            Annee = DateTime.Now.Year.ToString();
            if (Convert.ToInt32(DateTime.Now.Month) < 10)
                Mois = "0" + DateTime.Now.Month.ToString();
            else
                Mois = DateTime.Now.Month.ToString();
            if (Convert.ToInt32(DateTime.Now.Day) < 10)
                Jour = "0" + DateTime.Now.Day.ToString();
            else
                Jour = DateTime.Now.Day.ToString();

            return Jour + "/" + Mois + "/" + Annee;
        }

        private void EnableFacture(bool Active)
        {
            if (Active)
            {
                tb_Facture.Enabled = true;
                tb_Table.Enabled = true;
                tb_Couverts.Enabled = true;
                tb_NbrArts.Enabled = true;
                tb_NbrMenuDif.Enabled = true;
                tb_PrixTTC.Enabled = true;
                cb_FactureVal.Enabled = true;
                cb_FactureClo.Enabled = true;
            }
            else
            {
                tb_Facture.Enabled = false;
                tb_Table.Enabled = false;
                tb_Couverts.Enabled = false;
                tb_NbrArts.Enabled = false;
                tb_NbrMenuDif.Enabled = false;
                tb_PrixTTC.Enabled = false;
                cb_FactureVal.Enabled = false;
                cb_FactureClo.Enabled = false;
            }
        }

        private void ClearCu_Commande()
        {
            tb_Facture.Text = "";
            tb_Table.Text = "";
            tb_Couverts.Text = "";
            lb_FactureSave.Text = "Date d'enregistrement";
            lb_FactureSave.ForeColor = Color.White;
            lb_FactureMod.Text = "Date de modification";
            lb_FactureMod.ForeColor = Color.White;
            tb_NbrArts.Text = "";
            tb_NbrMenuDif.Text = "";
            tb_PrixTTC.Text = "";
            cb_FactureVal.Checked = false;
            cb_FactureClo.Checked = false;
        }

        public List<ItemCmd> ListCmdNoClot = new List<ItemCmd>();
        public void cobCmdSelect()
        {
            try
            {
                ListCmdNoClot.Clear();
                ComboBox cob = cob_NbrCmd;
                cob.Items.Clear();

                string query = "resto.Commander_SelectCmd";
                BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query);
                BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

                if (BDD.SqlDr.Read())
                {
                    EnableFacture(true);
                    cob.Enabled = true;

                    int i = 1;               
                    string ID_Fac, Date;
                    // Variable temporaire :
                    int SommeArticle = 0;
                    int SommeMenuDifferent = 0;

                    cob.Items.Add("Selectionnez une Facture");
                    cob.SuspendLayout();
                    cob.Items.Add(new Item(BDD.SqlDr["ID_Facture"].ToString(), Convert.ToDateTime(BDD.SqlDr["Facture_DateCrea"]).ToString()));// + "(" + ID_Fac + ")"));
                    ListCmdNoClot.Add(new ItemCmd(0, BDD.SqlDr["ID_Facture"].ToString(), BDD.SqlDr["User_Pseudo"].ToString(), Convert.ToInt32(BDD.SqlDr["Facture_TableNum"]), Convert.ToInt32(BDD.SqlDr["Facture_NbrCouvert"]), Convert.ToDateTime(BDD.SqlDr["Facture_DateCrea"]), Convert.ToBoolean(BDD.SqlDr["Facture_Modifiee"]), Convert.ToDateTime(BDD.SqlDr["Facture_DateModif"]), SommeArticle, SommeMenuDifferent, Convert.ToDouble(BDD.SqlDr["Facture_PrixTotalTTC"]), Convert.ToBoolean(BDD.SqlDr["Facture_Validee"]), Convert.ToBoolean(BDD.SqlDr["Facture_Cloturee"])));

                    while (BDD.SqlDr.Read())
                    {
                        ID_Fac = BDD.SqlDr["ID_Facture"].ToString();
                        Date = Convert.ToDateTime(BDD.SqlDr["Facture_DateCrea"]).ToString();
                        cob.Items.Add(new Item(ID_Fac, Date));// + "(" + ID_Fac + ")"));
                        ListCmdNoClot.Add(new ItemCmd(i, ID_Fac, BDD.SqlDr["User_Pseudo"].ToString(), Convert.ToInt32(BDD.SqlDr["Facture_TableNum"]), Convert.ToInt32(BDD.SqlDr["Facture_NbrCouvert"]), Convert.ToDateTime(BDD.SqlDr["Facture_DateCrea"]), Convert.ToBoolean(BDD.SqlDr["Facture_Modifiee"]), Convert.ToDateTime(BDD.SqlDr["Facture_DateModif"]), SommeArticle, SommeMenuDifferent, Convert.ToDouble(BDD.SqlDr["Facture_PrixTotalTTC"]), Convert.ToBoolean(BDD.SqlDr["Facture_Validee"]), Convert.ToBoolean(BDD.SqlDr["Facture_Cloturee"])));
                        i++;
                    }

                    cob.ValueMember = "ID_Facture";
                    cob.DisplayMember = "Facture_DateCrea";
                    cob.ResumeLayout();

                    cob.SelectedIndex = 0;
                    tb_NbrCmd.Text = i.ToString();
                }
                else
                {
                    EnableFacture(false);
                    tb_NbrCmd.Text = "0";
                    cob_NbrCmd.Enabled = false;
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

        public List<string> Requete_Importer()
        {
            RequestData r = new RequestData();
            Shell s = new Shell();

            // On recupere le bon ID ( ici ID_User ) :
            int id = Convert.ToInt32(dgv.Rows[user.IDRowDGV].Cells[s.SelectGoodID_Name(BDD, "FACTURE")].Value.ToString());

            // On interroge la BDD pour recuperer la ligne selectionné
            string query = "Resto.Commander_Select";

            List<Data> datas = new List<Data>()
            {
                new Data(){ name="Valeur", valeur= id.ToString() }
            };
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);


            DataTable dt = new DataTable();
            BDD.SqlDa = new SqlDataAdapter(BDD.SqlCmd);
            BDD.SqlDa.Fill(dt);

            List<string> result = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    result.Add(dr[i].ToString());
                }
            }
            return result;
        }

        public void Affichage_Requete_Textbox()
        {
            // Si l'utilisateur selectionne plusieurs lignes : valeur negative, donc :
            if (user.IDRowDGV >= 0)
            {
                ClearCu_Commande();
                EnableFacture(true);
                // Création de la list "result", elle récupére les données suite à l'appelle de la fonction "Requete_Importer()"
                List<string> result = Requete_Importer();

                tb_Facture.Text = result[0].ToString();
                lb_NomServeur.Text = result[1].ToString();
                tb_Table.Text = result[2].ToString();
                tb_Couverts.Text = result[3].ToString();

                lb_FactureSave.Text = "enregistrée le " + result[4].ToString();
                if (Convert.ToBoolean(result[5]))
                {
                    lb_FactureMod.Text = "modifiée le " + result[6].ToString();
                    lb_FactureMod.ForeColor = Color.Red;
                }
                else
                {
                    lb_FactureMod.Text = "Jamais modifiée";
                    lb_FactureMod.ForeColor = Color.Yellow;
                }

                tb_NbrArts.Text = result[7].ToString();
                tb_NbrMenuDif.Text = result[8].ToString();
                tb_PrixTTC.Text = result[9].ToString();

                cb_FactureVal.Checked = Convert.ToBoolean(result[10]);
                cb_FactureClo.Checked = Convert.ToBoolean(result[11]);
            }
        }

        public void CmdUpdate()
        {
            try
            {
                List<Data> datas = new List<Data>();
                datas.Add(new Data() { name = "idFacture", valeur = tb_Facture.Text });
                datas.Add(new Data() { name = "NumTable", valeur = tb_Table.Text });
                datas.Add(new Data() { name = "NbrCouverts", valeur = tb_Couverts.Text });
                datas.Add(new Data() { name = "Valid", valeur = cb_FactureVal.Checked.ToString() });
                datas.Add(new Data() { name = "Clot", valeur = cb_FactureClo.Checked.ToString() });
                datas.Add(new Data() { name = "DateModif", valeur = DateTime.Now.ToString() });

                string query = "resto.Commander_UpdateFac";
                BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
                if (BDD.SqlCmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Modification réalisée avec succès !");
                    bt_Modifier.Enabled = false;
                    ClearCu_Commande();
                    EnableFacture(false);
                    cobCmdSelect(); //On recharge la combobox des factures non cloturée
                }
                else
                {
                    MessageBox.Show("Echec lors de la modification, veuillez reessayer svp !","Erreur");
                    //CmdUpdate();  //Tel quel : Boucle infinie si echec constant...
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

        public void CmdAllUpdate()
        {
            try
            {
                List<Data> datas = new List<Data>();
                datas.Add(new Data() { name = "DateModif", valeur = DateTime.Now.ToString() });

                string query = "resto.Commander_UpdateAllFac";
                BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
                if (BDD.SqlCmd.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Modification réalisée avec succès !");
                    bt_Modifier.Enabled = false;
                    ClearCu_Commande();
                    EnableFacture(false);
                    cobCmdSelect(); //On recharge la combobox des factures non cloturée
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

        #region EVENEMENTS
        private void CU_Commande_Load(object sender, EventArgs e)
        {
            BDD.OpenBDD();

            if (cob_NbrCmd.Enabled) cob_NbrCmd.Enabled = true;

            EnableFacture(false);
            reloadDGV("0");
            cobCmdSelect();
        }

        private void cob_NbrCmd_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cob_NbrCmd.Text != "" || cob_NbrCmd.Text != "Selectionnez une Facture")
                {
                    foreach (ItemCmd role in ListCmdNoClot)
                    {
                        bt_Modifier.Enabled = true;
                        if (role.DateCrea.ToString() == cob_NbrCmd.Text)
                        {

                            reloadDGV(role.ID.ToString());

                            string query = "Resto.Commander_SelectNumber";
                            List<Data> datas = new List<Data>()
                            {
                                new Data(){ name="Valeur", valeur= role.ID.ToString() }
                            };
                            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
                            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

                            //TODO : Récuperation du Nombre d'article et Nombre menus différents de la Facture
                            if (BDD.SqlDr.Read())
                            {
                                if (BDD.SqlDr["Nbr_Article"].ToString() == null)
                                    tb_NbrArts.Text = "0";
                                else
                                    tb_NbrArts.Text = BDD.SqlDr["Nbr_Article"].ToString();

                                if (BDD.SqlDr["ID_Menu"].ToString() == null)
                                    tb_NbrMenuDif.Text = "0";
                                else
                                    tb_NbrMenuDif.Text = BDD.SqlDr["ID_Menu"].ToString();

                                
                            }                          
                            BDD.SqlDr.Close();
                            tb_Facture.Text = role.ID.ToString();
                            lb_NomServeur.Text = role.Pseudo.ToString();
                            tb_Table.Text = role.Table.ToString();
                            tb_Couverts.Text = role.Couverts.ToString();
                            lb_FactureSave.Text = "enregistrée le " + role.DateCrea.ToString();
                            cb_FactureVal.Checked = role.Valid;
                            cb_FactureClo.Checked = role.Clotur;
                            if (role.Modif)
                            {
                                lb_FactureMod.Text = "modifiée le " + role.DateModif.ToString();
                                lb_FactureMod.ForeColor = Color.Red;
                            }
                            else
                            {
                                lb_FactureMod.Text = "Jamais modifiée";
                                lb_FactureMod.ForeColor = Color.Yellow;
                            }
                            tb_PrixTTC.Text = role.Prix.ToString();
                            cb_FactureVal.Checked = Convert.ToBoolean(role.Valid);
                            cb_FactureClo.Checked = Convert.ToBoolean(role.Clotur);
                            break;
                        }
                        else
                        {
                            ClearCu_Commande();
                            bt_Modifier.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
            }
        }
        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            Affichage_Requete_Textbox();
            bt_Modifier.Enabled = true;
        }

        private void bt_Modifier_Click(object sender, EventArgs e)
        {
            EnableFacture(false);
            CmdUpdate();
            bt_Modifier.Enabled = false;
        }

        private void bt_ClotAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vous clôturer toutes les factures validées ?", "CLÔTURE DES FACTURES VALIDÉES", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                CmdAllUpdate();
            }
        }
        #endregion

    }

    #region CLASSE DE LISTE : ItemCmd
    public class ItemCmd
    {
        public ItemCmd(int _i, string _id, string _pseudo, int _table, int _couv, DateTime _dateC, bool _modif, DateTime _dateM, int _nbr, int _menu, double _prix, bool _valid, bool _clotur)
        { 
            i = _i;
            ID = _id;
            Pseudo = _pseudo;
            Table = _table;
            Couverts = _couv;
            DateCrea = _dateC;
            Modif = _modif;
            DateModif = _dateM;
            NbrArt = _nbr;
            MenuDif = _menu;
            Prix = _prix;
            Valid = _valid;
            Clotur = _clotur;            
        }

        public int i { get; set; }
        public string ID { get; set; }
        public string Pseudo { get; set; }
        public int Table { get; set; }
        public int Couverts { get; set; }
        public DateTime DateCrea { get; set; }
        public bool Modif { get; set; }
        public DateTime DateModif { get; set; }
        public int NbrArt { get; set; }
        public int MenuDif { get; set; }
        public double Prix { get; set; }
        public bool Valid { get; set; }
        public bool Clotur { get; set; }
    }
    #endregion
}
