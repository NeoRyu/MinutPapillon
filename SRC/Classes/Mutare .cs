using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librairies supplémentaires utilisées :
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;   // Regex

namespace MinutPapillon
{
    public class Rechercher
    {
        RequestData r = new RequestData();
        Shell.Error e = new Shell.Error();

        public List<Data> LiasisonData(List<string> Param)
        {
            List<Data> datas = new List<Data>
            {
                new Data(){ name="Table", valeur = Param[0] },
                new Data(){ name="Attribut", valeur = Param[1] },
                new Data(){ name="Recherche", valeur = Param[2] }
            };
            return datas;
        }

        public int rechercheItem(Connexion BDD, DataGridView dgv, List<string> Param)
        {

            string query = "Resto.Rechercher";

            if (Param[2] == "false")
                Param[2] = "0";
            else if (Param[2] == "true")
                Param[2] = "1";

            if (Param[2] == "non")
                Param[2] = "0";
            else if (Param[2] == "oui")
                Param[2] = "1";

            if (Param[2] == "faux")
                Param[2] = "0";
            else if (Param[2] == "vrai")
                Param[2] = "1";


            //if (Param[2] == "")
            //    query = "Resto.Affichage_DataGridView";

            List<Data> datas = LiasisonData(Param);
            int nbRow = countRowRequest(BDD, query, datas);

            if (nbRow == 0)
            {
                MessageBox.Show("Aucun résultat trouvé...");
            }
            else if (nbRow >= 1)
            {
                // Affichage des résultats dans le DataGridView
                affichage_dgv(BDD, dgv, query, datas);
            }
            return nbRow;
        }

        public int countRowRequest(Connexion BDD, string query, List<Data> datas)
        {
            int nbRow = 0;

            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            while (BDD.SqlDr.Read())
            {
                nbRow++;
            }
            BDD.SqlDr.Close();
            return nbRow;
        }

        public void affichage_dgv(Connexion BDD, DataGridView dgv, string query, List<Data> datas)
        {
            try
            {
                BDD.SqlDs = new DataSet();
                BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
                BDD.SqlDa = new SqlDataAdapter(BDD.SqlCmd);
                BDD.SqlDa.Fill(BDD.SqlDs);
                dgv.DataSource = BDD.SqlDs.Tables[0];
                BDD.SqlDa.Dispose(); //MODIF
                BDD.SqlCmd.Dispose();
            }
            catch (SqlException ex)
            {
                e.SQL_Error(ex);
            }
            catch (Exception ex)
            {
                e.C_Error(ex);
            }
        }
    }




    public class gestionUtilisateur
    {
        RequestData r = new RequestData();
        Shell.Error e = new Shell.Error();

        public List<Item> Roles = new List<Item>();

        public void affichageCbRole(Connexion BDD, ComboBox cb)
        {
            try
            {
                string query = "Resto.Role_Affichage";

                cb.Items.Clear();
                cb.Items.Add("Selectionnez un rôle");
                cb.SuspendLayout();                                             // Bloque la combobox
                BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query);
                BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

                while (BDD.SqlDr.Read())                                        //Boucle d'injection de la combobox
                {
                    string id = BDD.SqlDr["ID_Role"].ToString();
                    string libelle = BDD.SqlDr["Role_Libelle"].ToString();
                    int niv = Convert.ToInt32(BDD.SqlDr["Role_NiveauDroits"].ToString());

                    Roles.Add(new Item(id, libelle, niv));
                    cb.Items.Add(new Item(id, libelle, niv));
                }

                cb.ValueMember = "ID_Role";
                cb.DisplayMember = "Role_Libelle";

                cb.ResumeLayout();                                              // Débloque la combobox
                BDD.SqlDr.Close();                                                  // Ferme le DataReader
                cb.SelectedIndex = 0;                                           // Sélectionne le 1er Item de la combobox 
            }
            catch (SqlException ex)
            {
                e.SQL_Error(ex);
            }
            catch (Exception ex)
            {
                e.C_Error(ex);
            }
        }

        public void userInsert(Connexion BDD, List<string> values)
        {
            List<Data> datas = new List<Data>()
                {
                    new Data(){ name = "pseudo",    valeur=values[0] },
                    new Data(){ name = "pass",      valeur=values[1] },
                    new Data(){ name = "nom",       valeur=values[2] },
                    new Data(){ name = "prenom",    valeur=values[3] },
                    new Data(){ name = "tel",       valeur=values[4] },
                    new Data(){ name = "role",      valeur=values[5] }
                };
            string query = "resto.Utilisateur_Insert";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            if (BDD.SqlCmd.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ajout d'un utilisateur a réussi", "Etat Ajout Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void userUpdate(Connexion BDD, List<string> values)
        {
            List<Data> datas = new List<Data>()
                {
                    new Data(){ name = "id",        valeur=values[6]},
                    new Data(){ name = "pseudo",    valeur=values[0]},
                    new Data(){ name = "pass",      valeur=values[1]},
                    new Data(){ name = "nom",       valeur=values[2]},
                    new Data(){ name = "prenom",    valeur=values[3]},
                    new Data(){ name = "tel",       valeur=values[4]},
                    new Data(){ name = "role",      valeur=values[5] }
                };

            string query = "resto.Utilisateur_Update";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            if (BDD.SqlCmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Modification d'un utilisateur a réussi", "Etat Modification Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Modification d'un utilisateur a échoué", "Etat Modification Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void roleInsert(Connexion BDD, List<string> values)
        {
            List<Data> datas = new List<Data>()
            {
                new Data(){ name="libelle", valeur = values[0] },
                new Data(){ name="niveau",  valeur = values[1] }
            };

            string query = "resto.Role_Insert";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            if (BDD.SqlCmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Ajout d'un role a réussi", "Etat Ajout Rôle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ajout d'un Role a échoué", "Etat Ajout Rôle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void roleUpdate(Connexion BDD, List<string> value)
        {
            string idRole = "0";
            foreach (Item item in Roles)
            {
                if (value[0] == item.Libelle)
                {
                    idRole = item.Id;
                }
            }

            List<Data> datas = new List<Data>(){
                new Data(){ name="id",      valeur=value[0] },
                new Data(){ name="libelle", valeur=value[1] },
                new Data(){ name="niveau",  valeur=value[2] }
            };

            string query = "resto.Role_Update";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            if (BDD.SqlCmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Modification d'un role a réussi", "Etat modification Rôle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Modification d'un Role a échoué", "Etat modification Rôle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }




    public class GestionCarte
    {
        RequestData r = new RequestData();
        public List<Item> TVA = new List<Item>();

        public List<Item> Type = new List<Item>();

        public void affichageCb(Connexion BDD, ComboBox cb, string target)
        {
            string query = "";
            if (target == "tva")
                query = "Resto.TVA_affichage";
            if (target == "type")
                query = "Resto.TYPE_affichage";

            cb.Items.Clear();

            if (target == "tva")
                cb.Items.Add("TVA (%)");
            if (target == "type")
                cb.Items.Add("Type de produit");

            cb.SuspendLayout();                                     // Bloque la combobox
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            while (BDD.SqlDr.Read())                                //Boucle d'injection de la combobox
            {
                string id = BDD.SqlDr[0].ToString();
                string libelle = BDD.SqlDr[1].ToString();

                if (target == "tva")
                    TVA.Add(new Item(id, libelle));
                if (target == "type")
                    Type.Add(new Item(id, libelle));

                cb.Items.Add(new Item(id, libelle));
            }

            if (target == "tva")
            {
                cb.ValueMember = "ID_TVA";
                cb.DisplayMember = "TVA_Libelle"; ;
            }
            if (target == "type")
            {
                cb.ValueMember = "ID_Type";
                cb.DisplayMember = "Type_Libelle"; ;
            }


            cb.ResumeLayout();                                      // Débloque la combobox
            BDD.SqlDr.Close();                                      // Ferme le DataReader
            cb.SelectedIndex = 0;                                   // Sélectionne le 1er Item de la combobox 
        }

        public void carteInsert(Connexion BDD, List<string> values)
        {
            List<Data> datas = new List<Data>()
            {
                new Data(){ name="dispo",       valeur = values[0]  },
                new Data(){ name="nom",         valeur = values[1]  },
                new Data(){ name="format",      valeur = values[2]  },
                new Data(){ name="prix",        valeur = values[3]  },
                new Data(){ name="supplement",  valeur = values[4]  },
                new Data(){ name="preference",  valeur = values[5]  },
                new Data(){ name="alcool",      valeur = values[6]  },
                new Data(){ name="image",       valeur = values[7]  },
                new Data(){ name="qteStock",    valeur = values[8]  },
                new Data(){ name="type",        valeur = values[9]  },
                new Data(){ name="tva",         valeur = values[10] }
            };

            string query = "resto.Carte_Insert";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            if (BDD.SqlCmd.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ajout d'un article dans la carte est réussi", "Etat Ajout Article", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void carteUpdate(Connexion BDD, List<string> values)
        {
            List<Data> datas = new List<Data>()
            {
                new Data(){ name="id",          valeur = values[11] },
                new Data(){ name="dispo",       valeur = values[0]  },
                new Data(){ name="nom",         valeur = values[1]  },
                new Data(){ name="format",      valeur = values[2]  },
                new Data(){ name="prix",        valeur = values[3]  },
                new Data(){ name="supplement",  valeur = values[4]  },
                new Data(){ name="preference",  valeur = values[5]  },
                new Data(){ name="alcool",      valeur = values[6]  },
                new Data(){ name="image",       valeur = values[7]  },
                new Data(){ name="qteStock",    valeur = values[8]  },
                new Data(){ name="type",        valeur = values[9]  },
                new Data(){ name="tva",         valeur = values[10] }
            };

            string query = "resto.Carte_Update";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            if (BDD.SqlCmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Modification d'un article dans la carte est réussi", "Etat Modification Article", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Modification d'un article dans la carte a échoué", "Etat Modification Article", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }




    public class GestionMenu
    {
        RequestData r = new RequestData();
        Shell.Sanitize clean = new Shell.Sanitize();

        #region MENU
        public void affichageCbMenu(Connexion BDD, ComboBox cb)
        {
            cb.Items.Clear();
            cb.SuspendLayout();                                     // Bloque la combobox
            cb.Items.Insert(0, "Sélectionnez un menu");

            string query = "Resto.Affichage_DataGridView";
            List<Data> datas = new List<Data>();
            datas.Add(new Data() { name = "Table", valeur = "MENU" });

            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            while (BDD.SqlDr.Read())                                //Boucle d'injection de la combobox
            {
                if (Convert.ToInt32(BDD.SqlDr["ID_menu"]) != 1)
                    cb.Items.Add(BDD.SqlDr[2].ToString());
            }

            cb.ResumeLayout();                                      // Débloque la combobox
            BDD.SqlDr.Close();                                      // Ferme le DataReader
            cb.SelectedIndex = 0;                                   // Sélectionne le 1er Item de la combobox 
        }

        public void affichageCbMenuComposer(Connexion BDD, ComboBox cb)
        {
            BDD.SqlDr.Close();

            List<Data> datas = new List<Data>();
            List<Item> item = new List<Item>();

            string query = "Resto.Affichage_DataGridView";
            datas.Add(new Data() { name = "Table", valeur = "MENU" });
            item.Add(new Item("0", "Sélectionnez un menu"));

            cb.SuspendLayout();                                     // Bloque la combobox
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            while (BDD.SqlDr.Read())                                //Boucle d'injection de la combobox
            {
                if(Convert.ToInt32(BDD.SqlDr["ID_menu"]) != 1)
                    item.Add(new Item(BDD.SqlDr[0].ToString(), BDD.SqlDr[2].ToString()));
            }

            cb.DataSource = item;
            cb.DisplayMember = "libelle";
            cb.ValueMember = "id";

            BDD.SqlDr.Close();
        }

        public void affichageCbArticle(Connexion BDD,ComboBox cb)
        {
            BDD.SqlDr.Close();

            List<Data> datas = new List<Data>();
            List<Item> item = new List<Item>();

            string query = "Resto.Affichage_DataGridView";
            datas.Add(new Data() { name = "Table", valeur = "CARTE" });
            item.Add(new Item("0", "Sélectionnez un article"));

            cb.SuspendLayout();                                     // Bloque la combobox
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            while (BDD.SqlDr.Read())                                //Boucle d'injection de la combobox
            {
                if (BDD.SqlDr["ID_TYPE"].ToString() != "2")
                    item.Add(new Item(BDD.SqlDr[0].ToString(), BDD.SqlDr[2].ToString()));
            }

            cb.DataSource = item;
            cb.DisplayMember = "libelle";
            cb.ValueMember = "id";

            BDD.SqlDr.Close();
        }

        public List<string> afficherMenu(Connexion BDD, string chaine)
        {
            BDD.SqlDr.Close();
            string query = "Resto.SelectLineDGV";
            List<string> values = new List<string>();               // List des données à retourner
            List<Data> datas = new List<Data>()                     // List des donneés pour la procédure stockée
            {
                new Data(){ name = "Table"    , valeur = "MENU"         },
                new Data(){ name = "Attribut" , valeur = "Menu_Libelle" },
                new Data(){ name = "Recherche", valeur = chaine         }
            };

            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            if (BDD.SqlDr.Read())                                   // Lecture des données
            {
                values.Add(BDD.SqlDr[0].ToString());
                values.Add(BDD.SqlDr[1].ToString());
                values.Add(BDD.SqlDr[2].ToString());
                values.Add(BDD.SqlDr[3].ToString());
                values.Add(BDD.SqlDr[4].ToString());
            }

            BDD.SqlDr.Close();

            return values;
        }

        public void menuInsert(Connexion BDD, List<string> values)
        {
            List<Data> datas = new List<Data>()
            {
                new Data(){ name="dispo",   valeur = values[0] },
                new Data(){ name="libelle", valeur = values[1] },
                new Data(){ name="date",    valeur = values[2] },
                new Data(){ name="prix",    valeur = values[3] }
            };

            string query = "resto.Menu_Insert";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            if (BDD.SqlCmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Ajout d'un menu est réussi", "Etat Ajout Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ajout d'un menu a échoué", "Etat Ajout Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            BDD.SqlCmd.Dispose();
        }

        public void menuUpdate(Connexion BDD, List<string> values)
        {
            List<Data> datas = new List<Data>()
            {
                new Data(){ name="id",      valeur = values[4] },
                new Data(){ name="dispo",   valeur = values[0] },
                new Data(){ name="libelle", valeur = values[1] },
                new Data(){ name="date",    valeur = values[2] },
                new Data(){ name="prix",    valeur = values[3] }
            };

            string query = "resto.Menu_Update";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            if (BDD.SqlCmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Modification d'un menu est réussi", "Etat Modification Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Modification d'un menu a échoué", "Etat Modification Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            BDD.SqlCmd.Dispose();
        }
        #endregion

        #region COMPOSER
        public List<string> affichagePrixArticle(Connexion BDD, string idArticle)
        {
            BDD.SqlDr.Close();
            string query = "Resto.Composer_AffichageArticle";
            List<Data> datas = new List<Data>()
            {
                new Data(){name = "idArticle", valeur = idArticle}
            };
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();
            List<string> param = new List<string>();
            if (BDD.SqlDr.Read())
            {
                param.Add(BDD.SqlDr["Article_PrixHT"].ToString());
                param.Add(BDD.SqlDr["Type_Libelle"].ToString());
            }

            BDD.SqlDr.Close();
            return param;
        }

        public void ComposerInsert(Connexion BDD, List<string> values)
        {
            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "idMenu", valeur = values[0] },
                new Data(){ name = "idArticle"  , valeur = values[1] },
                new Data(){ name = "LibelleType", valeur = values[2] }
            };

            string query = "resto.Composer_Insert";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            if (BDD.SqlCmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Ajout d'un composant est réussi", "Etat Ajout Composant ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ajout d'un composant a échoué", "Etat Ajout Composant ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            BDD.SqlCmd.Dispose();
        }

        public void ComposerDelete(Connexion BDD, List<string> values)
        {
            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "idMenu"    , valeur = values[0] },
                new Data(){ name = "idArticle" , valeur = values[1] }
            };

            string query = "resto.Composer_Delete";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            if (BDD.SqlCmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Suppression d'un composant est réussi", "Etat Suppression Composant ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Suppression d'un composant a échoué", "Etat Suppression Composant ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            BDD.SqlCmd.Dispose();
        }
        #endregion
    }




    public class GestionCommande
    {
        Window herit = new Window();
        RequestData r = new RequestData();
        Shell.Sanitize clean = new Shell.Sanitize();

        public int createFacture(Connexion BDD, List<string> values)
        {
            int id = 0;

            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "dateCrea", valeur = values[0] },
                new Data(){ name = "table"   , valeur = values[1] },
                new Data(){ name = "couvert" , valeur = values[2] },
                new Data(){ name = "idUser"  , valeur = values[3] }
            };

            string query = "resto.Facture_Insert";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            if (BDD.SqlDr.Read())
            {
                id = Convert.ToInt32(BDD.SqlDr[0].ToString());
            }

            BDD.SqlDr.Close();
            return id;
        }

        public void affichageCommandeNonCloturee(Connexion BDD, List<string> values, ComboBox cb)
        {
            BDD.SqlDr.Close();
            BDD.SqlCmd.Dispose();

            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "idUser" , valeur = values[0] },
                new Data(){ name = "droit"  , valeur = values[1] },
                new Data(){ name = "date"   , valeur = values[2] }
            };

            string query = "Resto.Commande_Affichage";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();
            cb.SuspendLayout();

            Window.objetCombo.Clear();
            Window.objetCombo.Add(new Item("0", "Nouvelle Table"));
            while (BDD.SqlDr.Read())
            {
                Window.objetCombo.Add(new Item(BDD.SqlDr["ID_Facture"].ToString(), BDD.SqlDr["Facture_TableNum"].ToString()));
            }
            cb.DataSource = Window.objetCombo;

            cb.DisplayMember = "libelle";
            cb.ValueMember = "id";

            cb.ResumeLayout();
            BDD.SqlDr.Close();
        }

        public void CommandeInsert(Connexion BDD, List<string> Values)
        {
            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "idFacture", valeur = Values[0] },
                new Data(){ name = "idCarte",   valeur = Values[1] },
                new Data(){ name = "idMenu",    valeur = Values[2] },
                new Data(){ name = "qte",       valeur = Values[3] },
                new Data(){ name = "pref",      valeur = Values[4] },
                new Data(){ name = "serveur",   valeur = Values[5] },
                new Data(){ name = "offert",    valeur = Values[6] },
                new Data(){ name = "insert",    valeur = Values[7] }
            };

            string query = "resto.Commander_Insert";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            datas.Clear();
            BDD.SqlCmd.ExecuteNonQuery();
            BDD.SqlCmd.Dispose();
        }

        public double returnPrice(Connexion BDD,string table, string attribut, string id)
        {
            double prix = 0;

            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "Table"    , valeur = table      },
                new Data(){ name = "Attribut" , valeur = attribut   },
                new Data(){ name = "Recherche", valeur = id         },
            };

            string query = "Resto.SelectLineDGV";

            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();
            if (BDD.SqlDr.Read())
            {
                prix = Convert.ToDouble(BDD.SqlDr[4].ToString());
            }
            BDD.SqlDr.Close();
            datas.Clear();
            return prix;
        }

        public string returnName(Connexion BDD, string id)
        {
            string name = "";
            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "Table"    , valeur = "MENU"    },
                new Data(){ name = "Attribut" , valeur = "ID_Menu" },
                new Data(){ name = "Recherche", valeur = id        },
            };

            string query = "Resto.SelectLineDGV";

            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();
            if (BDD.SqlDr.Read())
            {
                name = BDD.SqlDr["Menu_Libelle"].ToString();
            }
            BDD.SqlDr.Close();
            datas.Clear();
            return name;
        }

        public string returnType(Connexion BDD, string id)
        {
            string type = "";
            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "Table"    , valeur = "CARTE"      },
                new Data(){ name = "Attribut" , valeur = "ID_Article" },
                new Data(){ name = "Recherche", valeur = id           },
            };

            string query = "Resto.SelectLineDGV";

            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();
            if (BDD.SqlDr.Read())
            {
                type = BDD.SqlDr["ID_Type"].ToString();
            }
            BDD.SqlDr.Close();
            datas.Clear();
            return type;
        }

        public int nbLigne(Connexion BDD, string id, string menu, string article, string gratuit)
        {
            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "idFacture", valeur = id      },
                new Data(){ name = "idMenu"   , valeur = menu    },
                new Data(){ name = "idArticle", valeur = article },
                new Data(){ name = "gratuit"  , valeur = gratuit }
            };

            string query = "Resto.Commander_NbLigne";

            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            BDD.SqlDr.Read();

            int nb = Convert.ToInt32(BDD.SqlDr[0]);
            BDD.SqlDr.Close();
            return nb;
        }

    }




    public class Facture
    {
        Connexion BDD;
        RequestData r = new RequestData();

        public string id { set; get; }
        public string table { set; get; }
        public string couvert { set; get; }
        public bool valider { get; set; }
        public bool cloturer { get; set; }

        public Facture(Connexion _BDD, string _id)
        {
            BDD = _BDD;
            id = _id;
            List<Data> datas = new List<Data>();
            datas.Add(new Data() { name = "Table", valeur = "FACTURE" });
            datas.Add(new Data() { name = "Attribut", valeur = "ID_Facture" });
            datas.Add(new Data() { name = "Recherche", valeur = id });

            string query = "resto.SelectLineDGV";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);

            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            if (BDD.SqlDr.Read())
            {
                table = BDD.SqlDr["Facture_TableNum"].ToString();
                couvert = BDD.SqlDr["Facture_NbrCouvert"].ToString();

                valider = Convert.ToBoolean(BDD.SqlDr["Facture_Validee"].ToString());
                cloturer = Convert.ToBoolean(BDD.SqlDr["Facture_Cloturee"].ToString());
            }
            BDD.SqlDr.Close(); //TODO
        }

        public void updateNbCouvert(string _couvert)
        {
            couvert = _couvert;
            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "idFacture", valeur = id },
                new Data(){ name = "Couvert"  , valeur = couvert }
            };

            string query = "Resto.Facture_UpdateCouvert";

            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlCmd.ExecuteNonQuery();
        }

        public void updateValideCommande(string cible, string val)
        {
            List<Data> datas = new List<Data>();
            datas.Add(new Data() { name = "Attribut", valeur = cible });
            datas.Add(new Data() { name = "id"      , valeur = id    });
            datas.Add(new Data() { name = "valeur"  , valeur = val   });

            string query = "resto.Facture_AValider";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);

            if (BDD.SqlCmd.ExecuteNonQuery() == 1)
            {
                if (cible == "Facture_Validee")
                    valider = true;
                if (cible == "Facture_Cloturee")
                    cloturer = true;
            }
        }

        public void updatePrixTTC(string prix)
        {
            List<Data> datas = new List<Data>();
            datas.Add(new Data() { name = "idFacture", valeur = id });
            datas.Add(new Data() { name = "prixTotal", valeur = prix });

            string query = "resto.Facture_UpdatePrixTotal";
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlCmd.ExecuteNonQuery();
        }
    }
}
