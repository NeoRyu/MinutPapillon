using System;
// Librairies supplémentaires :
using System.Data;
using System.Data.SqlClient;        // Gestion des Erreurs SQL & tt ce qui est Base de données
using System.Windows.Forms;         // Pour pouvoir gérer les types et les fonctions system
using System.Collections.Generic;   // Prise en charge des collections
using System.Configuration;         // Pour permettre la lecture d'App.config

namespace MinutPapillon
{
    public class Connexion
    {
        #region [SNIPPET] CONNECTION A LA BASE DE DONNEES
        // Recup des information pour connection à la base de données via fichier de configuration
        static string nameServer = ConfigurationManager.AppSettings["DataSource"];       // Source de la base de données
        static string nameDatabase = ConfigurationManager.AppSettings["InitialCatalog"]; // Nom de la base de données
        private SqlConnection connect = new SqlConnection(@"Data Source=" + nameServer + ";Initial Catalog=" + nameDatabase + ";Integrated Security=True");
        public SqlConnection cnx
        {
            get { return connect; }
        }

        public void OpenBDD()
        {
            Shell.Error e = new Shell.Error();
            try
            {
                cnx.Open();
            }
            catch (SqlException ex)
            {
                e.SQL_Error(ex);
                Application.Exit();
            }
        }
        #endregion

        #region [SNIPPET] Instantiation + Accesseurs SQL
        // Instantiation
        private SqlCommand cmd;
        private SqlDataReader dr;
        private SqlDataAdapter da;
        private DataSet ds;

        // Accesseurs pour la connexion à la base de données, il a qu'un getteur, le setteur est retiré pour des raisons de protection
        public SqlCommand SqlCmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        public SqlDataReader SqlDr
        {
            get { return dr; }
            set { dr = value; }
        }
        public SqlDataAdapter SqlDa
        {
            get { return da; }
            set { da = value; }
        }
        public DataSet SqlDs
        {
            get { return ds; }
            set { ds = value; }
        }
        #endregion
    }

    #region STOCKAGE DES INFORMATIONS DE L'UTILISATEUR CONNECTÉ
    public class User
    {
        RequestData r = new RequestData(); // Instanciation de la classe request, nécessaire pour faire les procédure

        #region Variables
        private int id;
        private int droit;
        private string nom, prenom;
        #endregion

        public virtual int IDRowDGV { get; set; } // Pour la recuperation de l'ID via le datagridview

        #region Accesseurs
        public int idUser
        {
            get { return id; }
            set { id = value; }
        }
        public int droitUser
        {
            get { return droit; }
            set { droit = value; }
        }
        public string nomUser
        {
            get { return nom; }
            set { nom = value; }
        }
        public string prenomUser
        {
            get { return prenom; }
            set { prenom = value; }
        }
        #endregion

        public bool loginUser(List<string> Param)
        {
            Connexion BDD = new Connexion();
            bool validationConnexion = false;

            BDD.OpenBDD();

            // Liste des parametres à passer pour la procédure stockée
            List<Data> datas = new List<Data>
            {
                new Data(){ name="pseudo", valeur = Param[0] },
                new Data(){ name="password", valeur = Param[1] }
            };

            string query = "resto.Authentification"; // nom de la procédure stockée
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            // Traitement des données
            if (BDD.SqlDr.Read())
            {
                if (BDD.SqlDr["User_Pseudo"].ToString() == Param[0] && BDD.SqlDr["User_Password"].ToString() == Param[1]) // SqlDr[1] équivaut la valeur du login et SqlDr[2] le mot de passe
                {
                    validationConnexion = true; // Authentification réussite
                    idUser = Convert.ToInt32(BDD.SqlDr["ID_User"].ToString()); // Récupération de la donnée ID et convertion en Int
                    nomUser = BDD.SqlDr["User_NomReel"].ToString(); // Récuparation du nom
                    prenomUser = BDD.SqlDr["User_PrenomReel"].ToString(); // Récuparation du prénom
                    droitUser = Convert.ToInt32(BDD.SqlDr["Role_NiveauDroits"].ToString());  // Récupération du rôle et convertion en int
                }
            }
            BDD.SqlDr.Close();
            return validationConnexion; // returne l'état de l'authentification, si false, le mot de passe et/ou le login est faux
        }

        public string nomLabel(User u)
        {
            return u.nomUser.ToUpper() + " " + u.prenomUser; // retourne le nom et prénom de la personne
        }
    }
    #endregion

    #region IMPORTATION DE DONNEES DATAGRIDVIEW
    public class ImportDGV
    {
        public List<string> Requete_Importer(Connexion BDD, DataGridView dgv, User user, string Nomtable)
        {
            RequestData r = new RequestData();
            Shell s = new Shell();

            // On recupere le bon ID ( ici ID_User ) :
            int id = Convert.ToInt32(dgv.Rows[user.IDRowDGV].Cells[s.SelectGoodID_Name(BDD, Nomtable)].Value.ToString());

            // On interroge la BDD pour recuperer la ligne selectionné
            string query = "Resto.SelectLineDGV";
            
            List<Data> datas = new List<Data>()
            {
                new Data(){ name="Table",valeur=Nomtable},
                new Data(){ name="Attribut", valeur=s.SelectGoodID_Name(BDD,Nomtable)},
                new Data(){ name="Recherche", valeur=id.ToString() }
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
    }

    public class Item
    {
        public Item(string _id, string _libelle)
            {
                Id = _id;
                Libelle = _libelle;
            }

        public Item(string _idRole, string _libelleRole, int _nivRole)
        {
            Id = _idRole;
            Libelle = _libelleRole;
            NivRole = _nivRole;
        }
              
        public override string ToString()
        {
            return Libelle;
        }
        
        public string Id { get; set; }
        public string Libelle { get; set; }
        public int NivRole { get; set; }
    }
    #endregion

    #region [SNIPPET] TRAITEMENT DES PROCEDURES STOCKEES
    // Tableau de données pour les procédures stockées qui demande des paramêtre
    public class Data
    {
        public string name { get; set; }        // Le "name" est le nom du paramêtre 
        public string valeur { get; set; }      // La "valeur" est le donnée pour le paramêtre 
        //public SqlDbType type { get; set; }   // Le "type" de donnée pour  le parametre
    }

    // Execution des procédures stockées (PS)
    public class RequestData
    {
        // PS sans paramêtre
        public SqlCommand TraitementRequest(SqlConnection cnx, string query)
        {
            // Appel d'une requete
            SqlCommand SqlCmd = new SqlCommand(query, cnx);

            // précision du type de la requete (procédure stockée)
            SqlCmd.CommandType = CommandType.StoredProcedure;

            // Lecture des données
            return SqlCmd;
        }

        // PS avec un ou plusieurs paramêtre(s)
        public SqlCommand TraitementRequest(SqlConnection cnx, string query, List<Data> datas)
        {
            // Appel d'une requete
            SqlCommand SqlCmd = new SqlCommand(query, cnx);

            // Déclaration du type de la requete (procédure stockée)
            SqlCmd.CommandType = CommandType.StoredProcedure;

            // Création des variables de la procédure stockée qui sont en paramêtre
            foreach (Data d in datas)
                SqlCmd.Parameters.Add("@" + d.name + "", SqlDbType.VarChar);

            // Linkage des paramètres entre visual et sqlserver
            foreach (Data d in datas)
                SqlCmd.Parameters["@" + d.name + ""].Direction = ParameterDirection.Input;

            // On donne les valeurs des parametres par la valeur de la List<Data> 
            foreach (Data d in datas)
                SqlCmd.Parameters["@" + d.name + ""].Value = d.valeur;

            // Renvoie les données
            return SqlCmd;
        }
    }
    #endregion
}

