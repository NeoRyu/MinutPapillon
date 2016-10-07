using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librairies supplémentaires :
using System.Data.SqlClient;

namespace MinutPapillon
{
    public partial class Form_commandes : Form
    {
        #region VARIABLES
        string textLabelFactureOrgine = "(Enregistrez un produit)";      // Text du label num_ticket
        List<string> values = new List<string>();
        public string ID_Facture;

        string TxtConnect = "MODE EDITION";
        string TxtDeco = "DECONNECTER ADMINISTRATEUR";
        #endregion

        #region INSTANCIATIONS
        Connexion BDD = new Connexion();
        User user;                                      // Inutile de reinstancier, on souhaite garder la connexion ! =)
        User adminUser = new User();
        Window herit = new Window();
        Timer Time_Heure = new Timer();                 // Creation d'un timer
        GestionCommande gc = new GestionCommande();     // Ouverture de la class Gestion Commande
        RequestData r = new RequestData();

        Design ds = new Design();
        Shell.Sanitize shs = new Shell.Sanitize();
        #endregion

        public Form_commandes(User _user)
        {
            InitializeComponent();
            //InitializePanelDynamique();                   // creation du FlowLayoutPanel et des Bouttons

            user = _user;
            if (user.droitUser >= 1 && user.droitUser <= 2)
            {
                bt_PanneauAdmin.Enabled = true;
                adminUser.droitUser = user.droitUser;
                lb_PasswordADMIN.Text = "Panneau administration";
                tb_PasswordADMIN.Visible = false;
                bt_ConnectionADMIN.Visible = false;
            }
            HeureTicket();
            Time_Heure.Start();
        }

        public bool debugmode = false;

        #region FONCTIONS
        #region DATE/ HEURE
        public string Jour, Mois, Annee;    // Pour pouvoir modifier l'ordre pour la base
        private void HeureTicket()
        {
            // Affichage de la date actuelle :    
            Annee = DateTime.Now.Year.ToString();
            if (Convert.ToInt32(DateTime.Now.Month) < 10)
                Mois = "0" + DateTime.Now.Month.ToString();
            else
                Mois = DateTime.Now.Month.ToString();
            if (Convert.ToInt32(DateTime.Now.Day) < 10)
                Jour = "0" + DateTime.Now.Day.ToString();
            else
                Jour = DateTime.Now.Day.ToString();

            lb_DateTicket.Text = Jour + "/" + Mois + "/" + Annee;

            // Ensuite on définit le traitement à faire à chaque interval pour l'heure
            Time_Heure.Tick += (s, e) =>
            {
                lb_HeureTicket.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            };
            Time_Heure.Interval = 333;      // en ms
            // Puis lancement de l'affichage de l'heure...
        }
        #endregion

        #region AFFICHAGE DES BOUTTONS MENUS
        public int NbrDeMenu = 0; 
        public void EnableBtMenus()
        {
            BDD.SqlDr.Close();
            // Requete permettant de connaître le nombre de menus disponibles :
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, "Resto.MenusDispoCount");
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();
            if (BDD.SqlDr.Read())
            {
                NbrDeMenu = Convert.ToInt32(BDD.SqlDr[0]);
            }
            BDD.SqlDr.Close();

            // Si les boutons Tables et Couverts sont remplis :
            if ((bt_NumTable.Text == "NUM" || bt_NumTable.Text == "") || (bt_NbrCouvert.Text == "NBR" || bt_NbrCouvert.Text == ""))
            {
                panel_MENUS.Visible = false;
                bt_Boisson.Enabled = false;
                bt_Boisson.Visible = false;
                bt_Carte.Enabled = false;
                bt_Carte.Visible = false;
                bt_Menus.Enabled = false;
                bt_Menus.Visible = false;
                bt_VoirServeur.Enabled = false;
                lb_HowToUseIt.Visible = true;
            }
            else
            {
                FlowLayoutPanel1.AutoScroll = true; // Correction d'un bug pour Welcome();
                lb_HowToUseIt.Visible = false;
                bt_Boisson.Enabled = true;
                bt_Boisson.Visible = true;
                bt_Carte.Enabled = true;
                bt_Carte.Visible = true;
                bt_Menus.Enabled = true;
                bt_Menus.Visible = true;
                panel_MENUS.Visible = true;
                bt_VoirServeur.Enabled = true;
            }
            BDD.SqlDr.Close();
        }
        #endregion

        #region CREATION DYNAMIQUE WELCOME
        public int BtTabIndex = 52;   // TODO fred : A verifier (par rapport au TabIndex max actuellement sur le form ! :o )

        // Message de bienvenue
        public void Welcome()
        {

            string Table = "ATTRIBUER UN NUMÉRO DE TABLE";
            string Couvert = "ATTRIBUER UN NOMBRE DE COUVERTS";
            int i = 0;

            for (int j = 0 ; j <= 1 ; j++)
            {
                Button ButtonName = new System.Windows.Forms.Button();
                ButtonName.Location = new System.Drawing.Point(0, 0);
                ButtonName.Width = Convert.ToInt32((FlowLayoutPanel1.Width) - 10);
                ButtonName.Height = Convert.ToInt32((FlowLayoutPanel1.Height / 2) - 10);
                ButtonName.Size = new System.Drawing.Size(ButtonName.Width, ButtonName.Height);
                //ButtonName.MaximumSize = ButtonName.Size;
                ButtonName.Anchor = (AnchorStyles.None);
                ButtonName.BackColor = Color.DimGray;
                ButtonName.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.BGButton));
                ButtonName.BackgroundImageLayout = ImageLayout.Stretch;
                ButtonName.Tag = "BtWelcome";
                ButtonName.Name = "Bt_Welcome";
                ButtonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ButtonName.TextAlign = ContentAlignment.MiddleCenter;
                ButtonName.ForeColor = Color.Gold;
                ButtonName.TabIndex = BtTabIndex + 1;

                if (i == 0)
                {
                    ButtonName.Text = Table;
                    ButtonName.Click += new EventHandler(bt_NumTable_Click);
                    i++;
                }
                else
                {
                    ButtonName.Text = Couvert;
                    ButtonName.Click += new EventHandler(bt_NbrCouvert_Click);
                }

                this.FlowLayoutPanel1.Controls.Add(ButtonName);
                FlowLayoutPanel1.AutoScroll = false;
            }
        }
        #endregion

        // Récupération des données dans la base de données et affichage dans les buttons
        public void CreateButton(Connexion BDD, List<string> values)
        {
            #region Nettoyage du FlowLayoutPanel
            FlowLayoutPanel1.BackgroundImage = null;
            while (FlowLayoutPanel1.Controls.Count > 0)
            {
                var controltoremove = FlowLayoutPanel1.Controls[0];
                FlowLayoutPanel1.Controls.Remove(controltoremove);
                controltoremove.Dispose();
            }
            #endregion

            #region Récupération des données
            // Creation d'une liste pour l'envoi à la procedure stockée
            List<Data> datas = new List<Data>()
            {
                new Data(){ name = "Button"    , valeur = values[0] },
                new Data(){ name = "Critere"   , valeur = values[1] }
            };

            // Traitement de la requete
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, "Resto.ArticlesDisponibles", datas); // TODO : ALTER ComposerType a recup si menu
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            // Tant qu'il a lecture de données dans la BDD :
            List<DynamicButton> valeur = new List<DynamicButton>();
            int _id;
            string _nom, _type;
            while (BDD.SqlDr.Read())
            {
                if (values[2] == "0")                                       // Affichage des différents MENUS
                {
                    _id = Convert.ToInt32(BDD.SqlDr["ID_Menu"].ToString());
                    _nom = BDD.SqlDr["Menu_Libelle"].ToString();
                    valeur.Add(new DynamicButton(_id,_nom));
                }
                else                                                        // Affichage des différents ARTICLES
                {
                    _id = Convert.ToInt32(BDD.SqlDr["ID_Article"].ToString());
                    _nom = BDD.SqlDr["Article_Nom"].ToString();
                    if ((values[0] == "0") || (values[0] == "1"))
                        _type = BDD.SqlDr["ID_Type"].ToString();                // ARTICLE HORS MENU
                    else
                        _type = BDD.SqlDr["Composer_Type"].ToString();          // ARTICLE COMPOSANT UN MENU
                    valeur.Add(new DynamicButton(_id, _nom, _type));
                }
            }
            BDD.SqlDr.Close();
            #endregion

            #region Mélange des boutons
            // On effectue en fond un tri aleatoire, classé par catégorie, des items recups :
            List<DynamicButton> valeurtriee = new List<DynamicButton>();
            if (debugmode)
                MessageBox.Show( Design.RandomButton.ToString() );
            if (Design.RandomButton)
            {
                if (values[2] == "1") // On melange les articles avec Doppelganger
                    valeurtriee = Doppelganger(valeur);
                else                  // mais concernant les menus... :
                    valeurtriee = valeur;
            }
            else
            { // Si random n'ets pas activé, on fait juste le transfert entre les deux listes :
                valeurtriee = valeur;
            }
            #endregion

            #region Création dynmique des bouttons
            // Puis on crée dynamiquement chaque bouton :
            int i = 0;

            // TODO Fred : Si Menu alors insert List<Button> MenuDynamique , contenant tout les bouttons generee dynamiquement ci dessous, puis methode affichage dans l'ordre Entree/Plat/Dessert
            foreach (DynamicButton linedata in valeurtriee)
            {
                Button ButtonName = new System.Windows.Forms.Button();              // Instanciation d'un nouveau bouton
                
                ButtonName.Location = new System.Drawing.Point(0, 0);               // On definit ensuite : son emplacement,
                ButtonName.Size = new System.Drawing.Size(98, 98);                // sa taille,
                ButtonName.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);     // comment il se comporte lors des redimensionnement,

                ButtonName.Text = linedata.nom;                                     // le texte du bouton,
                ButtonName.TabIndex = i + BtTabIndex;                               // son numero de tabulation (incrementé a chaque loop)
                ButtonName.Name = "Bt_" + linedata.id;                              // son nom systeme 

                if (values[2] != "0")
                {
                    // Creation dynamique d'un boutton ARTICLE (carte ou menu)                    
                    ButtonName.Click += new EventHandler(ButtonDynamique_Click);        // Sinon on crée un event dynamique de clic (insertbdd) sur le bouton 
                    ButtonName.BackColor = Design.ColorButton(BDD, linedata.type, "BACK");
                    ButtonName.ForeColor = Design.ColorButton(BDD, linedata.type, "FORE");
                    // On définit un TAG :
                    if (Convert.ToInt32(values[0]) >= 2)                                    // ARTICLE COMPRIS DANS UN MENU
                        ButtonName.Tag = values[1];
                    else                                                                    // ARTICLE A LA CARTE
                        ButtonName.Tag = values[2];
                    this.FlowLayoutPanel1.Controls.Add(ButtonName);                     // On ajoute ce bouton au FlowLayoutPanel
                }
                else
                {
                    // Creation dynamique d'un boutton CHOIX MENU
                    ButtonName.Click += new EventHandler(ButtonChoixMenu_Click);       // on lui assigne un event dynamique de clic (createbt) sur le bouton
                    ButtonName.BackColor = Color.AntiqueWhite;
                    ButtonName.ForeColor = Color.Black;
                    ButtonName.Tag = linedata.id;
                    this.FlowLayoutPanel1.Controls.Add(ButtonName);                     // On ajoute ce bouton au FlowLayoutPanel
                }
                i++;
            }
            #endregion
        }

        //Methode permettant de copier, puis separer par catégorie les données d'une List dans plusieurs autres
        public static List<DynamicButton> Doppelganger(List<DynamicButton> valeur)
        {
            #region Instanciation des List<>
            // Tableau contenant et retournant toutes les List<> de categories triée aléatoirement :
            List<DynamicButton> ListReturn = new List<DynamicButton>();

            // Creation de List de tri par catégorie d'articles :
            List<DynamicButton> ListeBoissons = new List<DynamicButton>();
            List<DynamicButton> ListeEntFroides = new List<DynamicButton>();
            List<DynamicButton> ListeEntChaudes = new List<DynamicButton>();
            List<DynamicButton> ListePlatsPrinc = new List<DynamicButton>();
            List<DynamicButton> ListeFromages = new List<DynamicButton>();
            List<DynamicButton> ListeDesserts = new List<DynamicButton>();
            List<DynamicButton> ListeViandes = new List<DynamicButton>();
            List<DynamicButton> ListePoissons = new List<DynamicButton>();
            List<DynamicButton> ListeLegumes = new List<DynamicButton>();
            List<DynamicButton> ListeFruits = new List<DynamicButton>();
            List<DynamicButton> ListeSauces = new List<DynamicButton>();
            List<DynamicButton> ListePains = new List<DynamicButton>();

            // Création d'un tableau de pointeurs d'objets instanciés :
            List<List<DynamicButton>> PointeurList = new List<List<DynamicButton>> { ListeBoissons, ListeEntFroides, ListeEntChaudes, ListePlatsPrinc, ListeFromages, ListeDesserts, ListeViandes, ListePoissons, ListeLegumes, ListeFruits, ListeSauces, ListePains };
            #endregion

            //Pour chaque Bouton Dynamique dans valeur (la liste a triée)
            foreach (DynamicButton linetocopy in valeur)
            {
                int i = 2;   //On déclare i à 2 pour qu'il pointe sur le typeproduit "boisson" au niveau BDD (il sera reset a chaque boucle)
                // Pour chaque pointeur de liste de boutons que nous avons declaré au dessus
                foreach (List<DynamicButton> pointeur in PointeurList)
                {
                    // Si le type produit du bouton dynamique actuel correspond a i, 
                    // sinon on reboucle implicitement dans le foreach pour trouver dans quel pointeur dois etre ajouter l'element actuel
                    if (linetocopy.type == i.ToString())
                        // Alors on ajoute ce bouton a cette liste :
                        pointeur.Add(new DynamicButton(linetocopy.id, linetocopy.nom, linetocopy.type));
                    i++; // On incremente i pour qu'il pointe sur un autre type produit
                }
            }
            foreach (List<DynamicButton> pointeur in PointeurList)
            {
                if (pointeur.Count != 0) // Si le pointeur de list a l'endroit foreach contient un element alors :
                    // Pour chaque List de categorie, on ajoute a la List de retour les elements mélangés :
                    ListReturn.AddRange(TriAleatoire(pointeur).ToList());
            }

            return ListReturn;
        }

        // Methode permettant de trier aleatoirement chaque categorie de List
        public static List<DynamicButton> TriAleatoire(List<DynamicButton> ListeATrier)
        {
            List<DynamicButton> ListRandomized = new List<DynamicButton>();
            int compteur = ListeATrier.Count();
            int random = 0;

            if (ListeATrier.Count() > 0)
            {
                for (int i = 0; i < compteur; i++)
                {
                    random = Shell.GenNbrAleat(0, ListeATrier.Count());                    
                    ListRandomized.Add(ListeATrier[random]);                    
                    ListeATrier.RemoveAt(random);                    
                }
            }
            return ListRandomized;
        }

        private void reload()
        {
            List<string> values = new List<string>();
            values.Add(user.idUser.ToString());
            values.Add(user.droitUser.ToString());
            values.Add(DateTime.Now.ToShortDateString());
            gc.affichageCommandeNonCloturee(BDD, values, cob_ChoixCommande);
            cob_ChoixCommande.SelectedIndex = 0;
        }

        public void NewCmd(bool Active)
        {
            if (Active)
            {
                // Suppression de tout les Controls d'un FlowLayoutPanel
                while (FlowLayoutPanel1.Controls.Count > 0)
                {
                    var controltoremove = FlowLayoutPanel1.Controls[0];
                    FlowLayoutPanel1.Controls.Remove(controltoremove);
                    controltoremove.Dispose();
                }                
            }

            FlowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.pac_miam));

            dgv_commande.Rows.Clear();
            cob_ChoixCommande.SelectedIndex = 0;
            lb_NumTicket.Text = textLabelFactureOrgine;
            bt_NumTable.Text = "NUM";
            bt_NbrCouvert.Text = "NBR";
            bt_VoirServeur.Visible = false;
            tb_TotalPrice.Text = "";
            lb_HowToUseIt.Visible = true;
            bt_IMPRIMER.Enabled = false;
            bt_CLOTURER.Enabled = false;
            bt_NumTable.Enabled = true;
            bt_VALIDER.Text = "VALIDER";
            EnableBtMenus();
            while (FlowLayoutPanel1.Controls.Count > 0)
            {
                var controltoremove = FlowLayoutPanel1.Controls[0];
                FlowLayoutPanel1.Controls.Remove(controltoremove);
                controltoremove.Dispose();
            }
        }

        // Créer une facture
        private void CreateFacture()
        {
            // CREATION D'UNE NOUVELLE FACTURE
            if (lb_NumTicket.Text == textLabelFactureOrgine)
            {
                FlowLayoutPanel1.BackgroundImage = null;
                
                values.Clear();                                 // Nettoyage de la list
                values.Add(DateTime.Now.ToString());            // Ajout de la date à la list
                values.Add(bt_NumTable.Text);                   // Ajout dela table à la list
                values.Add(bt_NbrCouvert.Text);                 // Ajout du nombre de couvert  à la list
                values.Add(user.idUser.ToString());             // Ajout de L'ID Utilisateur à la list
                int id = gc.createFacture(BDD, values);         // Création d'un variable ID pour le nom du label facture et pour la list de données 
                lb_NumTicket.Text = id.ToString();              // Affichage de la facture en cours
                ID_Facture = id.ToString();
                values.Clear();                                 // Nettoyage de la list

                Window.objetCombo.Add(new Item(id.ToString(), bt_NumTable.Text));

                cob_ChoixCommande.DataSource = null;
                cob_ChoixCommande.DataSource = Window.objetCombo;
                //cob_ChoixCommande.ResetText();
                //cob_ChoixCommande.Items.Add(new Item(id.ToString(), bt_NumTable.Text));  // Ajout de la facture en cours dans la Combobox
                cob_ChoixCommande.SelectedValue = id.ToString();         // Sélectionne la nouvelle facture dans la Combobox
                bt_NumTable.Enabled = false;
                bt_VoirServeur.Visible = true;
            }
        }

        private string nbQTE()
        {
            if (Window.Quantite_Article == "" || Window.Quantite_Article == null)
                return "1";
            else
                return Window.Quantite_Article;
        }

        // Resélectionne une facture non cloturée
        private void reloadCommande()
        {
            dgv_commande.Rows.Clear();
            if (cob_ChoixCommande.SelectedIndex > 0)
            {
                FlowLayoutPanel1.BackgroundImage = null;
                bt_NumTable.Enabled = false;               
                 
                string id = cob_ChoixCommande.SelectedValue.ToString();
                // récupération des infos de la facture par la classe Facture
                Facture facture = new Facture(BDD, id);
                ID_Facture = facture.id;
                lb_NumTicket.Text = facture.id;
                bt_NumTable.Text = facture.table;
                bt_NbrCouvert.Text = facture.couvert;
                bt_VoirServeur.Visible = true;

                if (facture.valider)
                {
                    bt_IMPRIMER.Enabled = true;
                    bt_CLOTURER.Enabled = true;
                    if (adminUser.droitUser >= 1 && adminUser.droitUser <= 2)
                    {
                        bt_NbrCouvert.Enabled = true;
                        bt_VALIDER.Text = "ANNULER VALIDATION";
                    }
                    else
                    {
                        bt_VALIDER.Text = "VALIDER";
                        bt_NbrCouvert.Enabled = false;
                    }
                }
                else
                {
                    bt_VALIDER.Text = "VALIDER";
                    bt_IMPRIMER.Enabled = false;
                    bt_CLOTURER.Enabled = false;
                    bt_NbrCouvert.Enabled = true;
                }

                List<Data> datas = new List<Data>()
                {
                    new Data(){ name = "idFacture", valeur = facture.id }
                };

                // TODO - J'ai changé la PS regarde dans le fichier
                string query = "Resto.Commander_Recherche";

                BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
                BDD.SqlDr = BDD.SqlCmd.ExecuteReader();
                dgv_commande.RowTemplate.Height = 40;
                
                while (BDD.SqlDr.Read())
                {
                    // VOIR SERVEUR / Nom Menu / NOM ARTICLE / QTE / PRIX / ID Article (invisible) / N°MENU(invisible) / TYPE (invisible) / GRATUIT (invisible)
                    string[] row = new string[] 
                    { 
                        BDD.SqlDr["Voir_Serveur"].ToString(), 
                        BDD.SqlDr["Menu_Libelle"].ToString(), 
                        BDD.SqlDr["Article_Nom"].ToString(), 
                        BDD.SqlDr["Nbr_Article"].ToString(), 
                        BDD.SqlDr["Article_PrixHT"].ToString(), 
                        BDD.SqlDr["ID_Article"].ToString(), 
                        BDD.SqlDr["ID_Menu"].ToString(), 
                        BDD.SqlDr["ID_Type"].ToString(),
                        BDD.SqlDr["Article_offert"].ToString()
                    };
                    if (Convert.ToInt32(BDD.SqlDr["ID_Menu"]) != 1)
                    {
                        if (Convert.ToInt32(BDD.SqlDr["ID_Article"]) == 1)
                        {
                            row[1] = "MENU";
                            row[2] = BDD.SqlDr["Menu_Libelle"].ToString();
                            row[4] = BDD.SqlDr["Menu_PrixTTC"].ToString();
                        }
                        else
                        {
                            row[4] = "";
                        }
                    }
                    if (Convert.ToBoolean(BDD.SqlDr["Article_offert"]) == true)
                    {
                        row[4] = "Offert";
                    }
                    // Ajout une ligne dans le DGV
                    dgv_commande.Rows.Add(row);
                    dgv_commande.ClearSelection();
                    //Unicodecode point	    character	UTF-8(hex.)	        name
                    //  U+00B6	                ¶	        c2 b6	        PILCROW SIGN
                }
                BDD.SqlDr.Close();


                dgv_commande.Sort(dgv_commande.Columns["Produit_IDMenu"], ListSortDirection.Ascending);

                calculPrix();

                herit.AutoriserBtNum = true;    // Permet de pouvoir utiliser les boutons numeriques   
            }
            else
            {
                NewCmd(true); //NewCmd(false);
                bt_NumTable.Enabled = true;
                bt_NbrCouvert.Enabled = true;
                herit.AutoriserBtNum = false;
                FlowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.pac_miam));
            }
            //BouttonCommande = false;                                            // Dois cibler le numero d'ID_Menu
            EnableBtMenus();
        }

        private void insertMenu(string ID_Menu)
        {
            if (lb_NumTicket.Text != textLabelFactureOrgine)
            {
                Facture facture = new Facture(BDD, lb_NumTicket.Text);
                if (!facture.valider || (adminUser.droitUser >= 1 && adminUser.droitUser <= 2))
                {
                    string Quantity = nbQTE();
                    bool inserted = false;
                    // ID facture, ID Menu, ID Article, gratuit
                    if (gc.nbLigne(BDD, lb_NumTicket.Text, ID_Menu, "1", "false") <= 0)
                    {
                        inserted = true;
                        string[] row = new string[] {   
                            "false",                                                                // 0 - VOIR SERVEUR
                            "MENU",                                                             
                            gc.returnName(BDD, ID_Menu),                                            // 2 - NOM MENU
                            Quantity,                                                               // 3 - QTE
                            gc.returnPrice(BDD,"MENU","ID_Menu",ID_Menu).ToString(),                // 4 - PRIX
                            "1",                                                                    // 5 - ID Article   (invisible)
                            ID_Menu,                                                                // 6 - N°MENU       (invisible)
                            "1",                                                                    // 7 - TYPE         (invisible)
                            false.ToString()                                                        // 8 - GRATUIT      (invisible)
                        };

                        values.Add(lb_NumTicket.Text);                                          // ID Facture
                        values.Add("1");                                                        // ID Carte
                        values.Add(ID_Menu);                                                    // ID Menu
                        values.Add(Quantity);                                                   // Quantité
                        values.Add("false");                                                    // Préférence
                        values.Add(Voir_Serveur.ToString());                                    // Serveur
                        values.Add("false");                                                    // Offert
                        values.Add(inserted.ToString());
                        gc.CommandeInsert(BDD, values);                                         // Appel de l'INSERT de l'article
                        values.Clear();
                        // Affichage dans le DataGridView
                        dgv_commande.Rows.Add(row);
                    }
                    else
                    {
                        // PARTIE UPDATE
                        DialogResult result = MessageBox.Show("Voulez-vous ajouter " + Quantity + " menu(s) ?", "Ajout Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow row in dgv_commande.Rows)
                            {
                                // Recherche et sélectionne l'article par son ID, l'ID menu et s'il est gratuit
                                if (row.Cells["Produit_IDArticle"].Value.ToString() == "1"
                                    && row.Cells["Produit_IDMenu"].Value.ToString() == ID_Menu
                                    && Convert.ToBoolean(row.Cells["Produit_Gratuit"].Value) == false)
                                {
                                    values.Add(lb_NumTicket.Text);
                                    values.Add(row.Cells["Produit_IDArticle"].Value.ToString());
                                    values.Add(row.Cells["Produit_IDMenu"].Value.ToString());
                                    int qte = Convert.ToInt32(row.Cells["Produit_Qte"].Value) + Convert.ToInt32(Quantity);
                                    values.Add(qte.ToString());
                                    row.Cells["Produit_Qte"].Value = qte.ToString();
                                    values.Add(false.ToString());

                                    // Modifie la quantité
                                    executeQTE(values);
                                    values.Clear();
                                }
                            }
                        }
                    }
                }

                // Trie du DGV par l'ID du menu
                dgv_commande.Sort(dgv_commande.Columns["Produit_IDMenu"], ListSortDirection.Ascending);
                calculPrix();
            }
        }

        // Ajoute un article à la facture
        private void insertArticle()
        {
            if (lb_NumTicket.Text != textLabelFactureOrgine)
            {
                Facture facture = new Facture(BDD, lb_NumTicket.Text);
                if (!facture.valider || (adminUser.droitUser >= 1 && adminUser.droitUser <= 2))
                {
                    bool inserted = false;
                    values.Clear();
                    // DEBUG CODE :
                    string Quantity = nbQTE();
                    

                    // INSERT or UPDATE D'UN PRODUIT COMMANDEE :
                    // ID facture, ID Menu, ID Article, gratuit
                    if (gc.nbLigne(BDD, lb_NumTicket.Text, BtTag, shs.SearchNumInString(BtName.Name.ToString()), "false") <= 0)
                    {
                        // PARTIE INSERT
                        inserted = true;
                        // Préparation de l'ajout d'un ligne dans le DGV
                        string idArticle = shs.SearchNumInString(BtName.Name.ToString());
                        string[] row = new string[] {   
                            Voir_Serveur.ToString(),                                            // 0 - VOIR SERVEUR
                            gc.returnName(BDD, BtTag),                                          // 1 - Nom Menu
                            BtText,                                                             // 2 - NOM ARTICLE
                            Quantity,                                                           // 3 - QTE
                            gc.returnPrice(BDD,"CARTE","ID_Article",idArticle).ToString(),      // 4 - PRIX
                            shs.SearchNumInString(BtName.Name.ToString()),                      // 5 - ID Article   (invisible)
                            BtTag,                                                              // 6 - N°MENU       (invisible)
                            gc.returnType(BDD, shs.SearchNumInString(BtName.Name.ToString())),  // 7 - TYPE         (invisible)
                            false.ToString()                                                    // 8 - GRATUIT      (invisible)
                        };
                        // Modifie le prix de l'article si l'article fait partie d'un menu
                        if (row[6] != "1")
                            if (row[5] == "1")
                                row[4] = gc.returnPrice(BDD, "MENU", "ID_Menu", row[6]).ToString();
                            else
                                row[4] = "";

                        // Ajout des données dans une liste pour l'ajout dans la BDD
                        values.Add(lb_NumTicket.Text);                                          // ID Facture
                        if (BouttonCommande)                                                    // Condition pour l'insert
                        {
                            values.Add(shs.SearchNumInString(BtName.Name.ToString()));          // ID Carte
                            values.Add(shs.SearchNumInString(BtTag));                           // ID Menu
                        }
                        values.Add(Quantity);                                                   // Quantité
                        values.Add("false");                                                    // Préférence
                        values.Add(Voir_Serveur.ToString());                                    // Serveur
                        values.Add("false");                                                    // Offert
                        values.Add(inserted.ToString());
                        gc.CommandeInsert(BDD, values);                                         // Appel de l'INSERT de l'article
                        values.Clear();

                        // Affichage dans le DataGridView
                        dgv_commande.Rows.Add(row);
                        // On retire la sélection des lignes du DGV
                        dgv_commande.ClearSelection();
                    }
                    else
                    {
                        // PARTIE UPDATE
                        foreach (DataGridViewRow row in dgv_commande.Rows)
                        {
                            // Recherche et sélectionne l'article par son ID, l'ID menu et s'il est gratuit
                            if (row.Cells["Produit_IDArticle"].Value.ToString() == shs.SearchNumInString(BtName.Name.ToString()) 
                                && row.Cells["Produit_IDMenu"].Value.ToString() == BtTag 
                                && Convert.ToBoolean(row.Cells["Produit_Gratuit"].Value) == false)
                            {
                                values.Add(lb_NumTicket.Text);
                                values.Add(row.Cells["Produit_IDArticle"].Value.ToString());
                                values.Add(row.Cells["Produit_IDMenu"].Value.ToString());
                                int qte = Convert.ToInt32(row.Cells["Produit_Qte"].Value) + Convert.ToInt32(Quantity);
                                values.Add(qte.ToString());
                                row.Cells["Produit_Qte"].Value = qte.ToString();
                                values.Add(false.ToString());
                                
                                // Modifie la quantité
                                executeQTE(values);
                                values.Clear();
                            }
                        }
                    }
                    // Trie du DGV par l'ID du menu
                    dgv_commande.Sort(dgv_commande.Columns["Produit_IDMenu"], ListSortDirection.Ascending);

                    calculPrix();
                }
                else
                    MessageBox.Show("Impossible de modifier la commande \n Celle-ci a été validé.", "Etat modification");
            }
        }

        // Calcule le prix de la facture
        private void calculPrix()
        {
            double prixTTC = 0.0;
            // TODO - faire fonction calcul du prix
            if (dgv_commande.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgv_commande.Rows)
                {
                    if (Convert.ToInt32(row.Cells["Produit_IDArticle"].Value.ToString()) == 1 || Convert.ToInt32(row.Cells["Produit_IDMenu"].Value.ToString()) == 1)
                    {
                        if (row.Cells["Produit_Prix"].Value.ToString() != "Offert")
                            prixTTC += Convert.ToDouble(row.Cells["Produit_Prix"].Value) * Convert.ToDouble(Convert.ToDouble(row.Cells["Produit_Qte"].Value));
                    }
                }
                tb_TotalPrice.Text = prixTTC.ToString();
            }
            else
            {
                tb_TotalPrice.Text = prixTTC.ToString();
            }
        }

        // Change l'état du bouton voir serveur
        private void colorVoirServeur()
        {
            if (Voir_Serveur == false)
            {
                bt_VoirServeur.BackColor = Color.LightCoral;
                bt_VoirServeur.Text = "VOIR SERVEUR (desactivé)";
            }
            else
            {
                bt_VoirServeur.BackColor = Color.LightGreen;
                bt_VoirServeur.Text = "VOIR SERVEUR (activé)";
            }
        }

        // Ajoute ou supprime l'état "Voir Serveur" d'un article dans le DGV
        private void VoirServeurUpdate()
        {
            if ((dgv_commande.RowCount != 0) && (!dgv_commande.CurrentRow.Selected))
            {
                if (Convert.ToBoolean(dgv_commande.CurrentRow.Cells["Produit_Serveur"].Value))
                {
                    dgv_commande.CurrentRow.Cells["Produit_Serveur"].Value = false;
                }
                else
                {
                    dgv_commande.CurrentRow.Cells["Produit_Serveur"].Value = true;
                }
                // récupération des valeurs du DGV dans des variables
                string idFacture = lb_NumTicket.Text;
                string idArticle = dgv_commande.CurrentRow.Cells["Produit_IDArticle"].Value.ToString();
                string idMenu = dgv_commande.CurrentRow.Cells["Produit_IDMenu"].Value.ToString();
                string qte = dgv_commande.CurrentRow.Cells["Produit_Qte"].Value.ToString();

                values.Add(idFacture);
                values.Add(idArticle);
                values.Add(idMenu);
                values.Add(qte);
                values.Add("false"); // Préférence
                values.Add(dgv_commande.CurrentRow.Cells["Produit_Serveur"].Value.ToString());
                values.Add("false"); // Offert
                values.Add("false"); // Cible pour la PS insert (true) ou update (false)
                gc.CommandeInsert(BDD, values); 

                //Voir_Serveur = false;
                values.Clear();
                dgv_commande.CurrentRow.Selected = false;
                dgv_commande.ClearSelection();
            }
        }

        // Demande à l'utilisateur si l'article va être supprimer
        private void questionUpdateQTE()
        {
            if (tb_KeyPressValue.Text != "")
            {
                string oldqte = dgv_commande.CurrentCell.Value.ToString();
                dgv_commande.CurrentCell.Value = tb_KeyPressValue.Text;
                // List pour la Procédure stockée
                values.Add(lb_NumTicket.Text);
                values.Add(dgv_commande.CurrentRow.Cells["Produit_IDArticle"].Value.ToString());
                values.Add(dgv_commande.CurrentRow.Cells["Produit_IDMenu"].Value.ToString());
                values.Add(dgv_commande.CurrentRow.Cells["Produit_Qte"].Value.ToString());
                values.Add(dgv_commande.CurrentRow.Cells["Produit_Gratuit"].Value.ToString());

                int IDMenu = Convert.ToInt32(dgv_commande.CurrentRow.Cells["Produit_IDMenu"].Value);
                int IDArticle = Convert.ToInt32(dgv_commande.CurrentRow.Cells["Produit_IDArticle"].Value);
                bool Gratuit = Convert.ToBoolean(dgv_commande.CurrentRow.Cells["Produit_Gratuit"].Value);

                if (Convert.ToInt32(tb_KeyPressValue.Text) == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Voulez-vous supprimez l'article ?", "Suppression Article", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (IDMenu != 1 && IDArticle == 1)
                        {
                            for (int i = 0; i <= 4; i++)
                                foreach (DataGridViewRow row in dgv_commande.Rows)
                                {
                                    if (IDMenu == Convert.ToInt32(row.Cells["Produit_IDMenu"].Value) && Gratuit == Convert.ToBoolean(row.Cells["Produit_Gratuit"].Value))
                                    {
                                        values[1] = row.Cells["Produit_IDArticle"].Value.ToString();
                                        row.Cells["Produit_Qte"].Value = "0";
                                        executeQTE(values);
                                    }
                                }
                        }
                        else
                        {
                            executeQTE(values);
                        }
                    }
                    else
                    {
                        dgv_commande.CurrentCell.Value = oldqte;
                        herit.KeyPressClear();
                        herit.ChaineClear();
                        tb_KeyPressValue.Text = "";
                    }
                }
                else
                {
                    executeQTE(values);
                }

                values.Clear();
                herit.KeyPressClear();
                herit.ChaineClear();

                calculPrix();
            }
        }

        // Modifie la quantité d'un article
        private void executeQTE(List<string> val)
        {
            List<Data> datas = new List<Data>()
                {
                    new Data(){ name = "idFacture", valeur = val[0] },
                    new Data(){ name = "idCarte"  , valeur = val[1] },
                    new Data(){ name = "idMenu"   , valeur = val[2] },
                    new Data(){ name = "qte"      , valeur = val[3] },
                    new Data(){ name = "gratuit"  , valeur = val[4] }
                };

            string query = "Resto.Commander_Qte";

            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, query, datas);
            // Execute la requete SQL
            BDD.SqlCmd.ExecuteNonQuery();
            // vide la commande SQL
            BDD.SqlCmd.Dispose();

            // SUPPRESSION
            foreach (DataGridViewRow row in dgv_commande.Rows)
            {
                if (row.Cells["Produit_Qte"].Value.ToString() == "0"  
                    && row.Cells["Produit_IDMenu"].Value.ToString() == val[2]
                    && row.Cells["Produit_IDArticle"].Value.ToString() == val[1]
                    && row.Cells["Produit_Gratuit"].Value.ToString() == val[4])
                {
                    dgv_commande.Rows.RemoveAt(row.Index);
                    break;
                }
            }
        }

        private void fonction_gratuit()
        {
            if (dgv_commande.RowCount > 0)
            {
                if (!Convert.ToBoolean(dgv_commande.CurrentRow.Cells["Produit_Gratuit"].Value))
                {
                    bool inserted = false;
                    string[] ligne = new string[] 
                    {   
                        dgv_commande.CurrentRow.Cells[0].Value.ToString(),  // VOIR SERVEUR
                        dgv_commande.CurrentRow.Cells[1].Value.ToString(),  // Nom Menu
                        dgv_commande.CurrentRow.Cells[2].Value.ToString(),  // NOM ARTICLE
                        dgv_commande.CurrentRow.Cells[3].Value.ToString(),  // QTE
                        "Offert",                                           // PRIX
                        dgv_commande.CurrentRow.Cells[5].Value.ToString(),  // ID Article   (invisible)
                        dgv_commande.CurrentRow.Cells[6].Value.ToString(),  // N°MENU       (invisible)
                        dgv_commande.CurrentRow.Cells[7].Value.ToString(),  // TYPE         (invisible)
                        true.ToString()                                     // GRATUIT      (invisible)
                    };
                    // MODIFICATION DE LA QUANTITE
                    dgv_commande.CurrentRow.Cells["Produit_Qte"].Value = Convert.ToInt32(dgv_commande.CurrentRow.Cells[3].Value) - 1;

                    // MODIFICATION DE LA QUANTITE D'UN ARTICLE
                    values.Add(lb_NumTicket.Text);                                  // ID Facture
                    values.Add(dgv_commande.CurrentRow.Cells[5].Value.ToString());  // ID Article
                    values.Add(dgv_commande.CurrentRow.Cells[6].Value.ToString());  // ID Menu
                    values.Add(dgv_commande.CurrentRow.Cells[3].Value.ToString());  // Quantité
                    values.Add(false.ToString());                                   // Gratuit
                    executeQTE(values);
                    values.Clear();

                    if (gc.nbLigne(BDD, lb_NumTicket.Text, ligne[6], ligne[5], "true") == 0) // Condition du IF BDD, idFacture, IDmenu, IDarticle, gratuit
                    {
                        inserted = true;

                        ligne[3] = "1";

                        // AJOUT D'UNE LIGNE ARTICLE GRATUIT
                        values.Add(lb_NumTicket.Text);              // ID Facture
                        values.Add(ligne[5]);                       // ID Carte ou ID Article
                        values.Add(ligne[6]);                       // ID Menu
                        values.Add(ligne[3]);                       // Quantité
                        values.Add("false");                        // Préférence
                        values.Add(ligne[0]);                       // Serveur
                        values.Add("true");                         // Offert
                        values.Add(inserted.ToString());
                        gc.CommandeInsert(BDD, values);             // Appel de l'INSERT de l'article
                        values.Clear();                             // Nettoyage de la liste

                        dgv_commande.Rows.Add(ligne);
                    }
                    else
                    {
                        // MODIFICATION DE LA QUANTITE
                        foreach (DataGridViewRow row in dgv_commande.Rows)
                        {
                            if (row.Cells["Produit_IDArticle"].Value.ToString() == dgv_commande.CurrentRow.Cells[5].Value.ToString()
                                && row.Cells["Produit_IDMenu"].Value.ToString() == dgv_commande.CurrentRow.Cells[6].Value.ToString()
                                && Convert.ToBoolean(row.Cells["Produit_Gratuit"].Value) == true)
                            {
                                // ID Facture
                                values.Add(lb_NumTicket.Text);
                                // ID Article
                                values.Add(row.Cells["Produit_IDArticle"].Value.ToString());
                                // ID Menu
                                values.Add(row.Cells["Produit_IDMenu"].Value.ToString());
                                // Quantité
                                values.Add((Convert.ToInt32(row.Cells["Produit_Qte"].Value) + 1).ToString());
                                // Affichage de la quantité
                                row.Cells["Produit_Qte"].Value = (Convert.ToInt32(row.Cells["Produit_Qte"].Value) + 1).ToString();
                                // Gratuit
                                values.Add(true.ToString());
                                row.Cells["Produit_Prix"].Value = "Offert";
                                executeQTE(values);
                                values.Clear();
                            }
                        }
                    }

                    dgv_commande.Sort(dgv_commande.Columns["Produit_IDMenu"], ListSortDirection.Ascending);
                    calculPrix();
                }
            }
        }

        private void keypressView()
        {
            if (herit.AppuiTouche.Count == 0)
                tb_KeyPressValue.Text = "";
            if (herit.AppuiTouche.Count == 1)
                tb_KeyPressValue.Text = herit.AppuiTouche[0];
            if (herit.AppuiTouche.Count >= 2)
            {
                tb_KeyPressValue.Text += herit.AppuiTouche[1];
                herit.KeyPressClear();
            }

        }

        private void validerCommande()
        {
            if (lb_NumTicket.Text != textLabelFactureOrgine)
            {
                Facture facture = new Facture(BDD, lb_NumTicket.Text);
                if (!facture.valider)
                {
                    facture.updateValideCommande("Facture_Validee","true");
                    facture.updatePrixTTC(shs.replacePerPoint(tb_TotalPrice.Text));
                    bt_IMPRIMER.Enabled = true;
                    bt_CLOTURER.Enabled = true;
                    bt_NbrCouvert.Enabled = false;
                    facture.updatePrixTTC(shs.replacePerPoint(tb_TotalPrice.Text));
                    if (adminUser.droitUser >= 1 && adminUser.droitUser <= 2)
                    {
                        bt_NbrCouvert.Enabled = true;
                        bt_VALIDER.Text = "ANNULER VALIDATION";
                    }
                }
                else if(adminUser.droitUser >= 1 && adminUser.droitUser <= 2)
                {
                    bt_VALIDER.Text = "VALIDER";
                    bt_IMPRIMER.Enabled = false;
                    bt_CLOTURER.Enabled = false;
                    bt_NbrCouvert.Enabled = true;
                    facture.updateValideCommande("Facture_Validee", "false");
                }
            }
        }

        private void imprimerCommande()
        {
            if (lb_NumTicket.Text != textLabelFactureOrgine)
            {
                // Ouverture du PDF dynamique :
                MinutPapillon.PDFCreator pdf = new MinutPapillon.PDFCreator();
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdf.CreatePDF(user, ID_Facture), "PDF"));

                bt_CLOTURER.Enabled = true;
            }
        }

        private void cloturerCommande()
        {
            if (lb_NumTicket.Text != textLabelFactureOrgine)
            {
                Facture facture = new Facture(BDD, lb_NumTicket.Text);
                facture.updateValideCommande("Facture_Cloturee","true");

                Window.objetCombo.RemoveAt(cob_ChoixCommande.SelectedIndex);

                cob_ChoixCommande.DataSource = null;
                cob_ChoixCommande.DataSource = Window.objetCombo;

                NewCmd(true);
            }
        }

        private void connexionSuperviseur()
        {
            if (lb_NumTicket.Text != textLabelFactureOrgine)
            {
                Facture facture = new Facture(BDD, lb_NumTicket.Text);
                if (bt_ConnectionADMIN.Text == TxtDeco)
                {
                    // DECONNEXION ADMIN
                    bt_ConnectionADMIN.Text = TxtConnect;
                    bt_ConnectionADMIN.Enabled = false;
                    tb_PasswordADMIN.Visible = true;
                    lb_PasswordADMIN.Visible = true;
                    adminUser = new User();
                    adminUser.droitUser = 0;
                    bt_ConnectionADMIN.Width = 134;
                    bt_ConnectionADMIN.Location = new Point(199, 75);
                    bt_ConnectionADMIN.BackColor = Color.Gray;
                    this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.BGLuxury));
                    lb_NomServeur.Text = user.nomUser + " " + user.prenomUser;
                    lb_NomServeur.ForeColor = Color.White;
                    bt_VALIDER.Text = "VALIDER";
                    if (facture.valider)
                        bt_NbrCouvert.Enabled = false;
                }
                else
                {
                    if (tb_PasswordADMIN.Text != null && tb_PasswordADMIN.Text != "")
                    {
                        // CONNEXION ADMIN
                        values.Add("ADMIN");
                        values.Add(tb_PasswordADMIN.Text);
                        if (adminUser.loginUser(values))
                        {
                            bt_ConnectionADMIN.Text = TxtDeco;
                            tb_PasswordADMIN.Visible = false;
                            lb_PasswordADMIN.Visible = false;
                            bt_ConnectionADMIN.Width = 264;
                            bt_ConnectionADMIN.Location = new Point(69, 75);
                            bt_ConnectionADMIN.BackColor = Color.Gold;
                            this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.BG_AdminServeur));
                            string ModeAdmin = "(Mode Admin)";
                            lb_NomServeur.Text += " " + ModeAdmin;
                            lb_NomServeur.ForeColor = Color.Gold;

                            if (facture.valider)
                            {
                                bt_NbrCouvert.Enabled = true;
                                bt_VALIDER.Text = "ANNULER VALIDATION";
                            }
                        }
                        else
                            tb_PasswordADMIN.Clear();
                    }
                }
                tb_PasswordADMIN.Clear();
                values.Clear();
            }
            else
                MessageBox.Show("Sélectionnez une commande pour passer en Superviseur.", "/!\\ AVERTISSEMENT /!\\");
        }

        private void number(object sender)
        {
            bt_Name = (sender as Button);
            herit.KeyPressClear();
            EnableBtMenus();
        }
        #endregion

        #region EVENEMENTS
        private void Form_commandes_Load(object sender, EventArgs e)
        {
            // Desactive le scrollbar horizontal pour les articles :
            FlowLayoutPanel1.HorizontalScroll.Enabled = false;
            FlowLayoutPanel1.HorizontalScroll.Visible = false;

            // 
            BDD.OpenBDD();
            lb_NomServeur.Text = user.nomLabel(user);
            ds.Importer_ColorBDD(BDD);
            // Combobox Liste des commandes
            reload();
            colorVoirServeur();
            if (!(user.droitUser >= 1 && user.droitUser <= 2))
            {
                adminUser.droitUser = 0;
                bt_PanneauAdmin.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.porte_sortie));
            }
            else
            {
                this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.BG_AdminServeur));
            }
            if (lb_NumTicket.Text == textLabelFactureOrgine)
                Welcome();
        }

        private void FormSizeChanged(object sender, EventArgs e)
        {
            FlowLayoutPanel1.SuspendLayout();
            foreach (Control ctrl in FlowLayoutPanel1.Controls)
            {
                if (ctrl is Button)
                {
                    if (ctrl.Name == "Bt_Welcome")
                    {
                        ctrl.Width = FlowLayoutPanel1.Width;
                        ctrl.Height = FlowLayoutPanel1.Height;
                    }
                }
            }
            FlowLayoutPanel1.ResumeLayout();
        }

        #region GESTION VALEURS NUMERIQUES (Button et KeyPress)
        private void bt_ClearKeyPressValue_Click(object sender, EventArgs e)
        {
            herit.KeyPressClear();
            tb_KeyPressValue.Text = "";
            if (lb_NumTicket.Text == textLabelFactureOrgine)
            {
                bt_Name.Text = TypeAppuiBt;
            }

        }

        private void btNum_Click(object sender, EventArgs e)
        {
            herit.BtNumServeur((sender as Button).Text.ToString());
            herit.KeyControlServeur(bt_Name, TypeAppuiBt);
            EnableBtMenus();            
            // Update des couverts
            if (bt_NbrCouvert.Text != "NBR" && bt_NumTable.Text != "NUM" && lb_NumTicket.Text != textLabelFactureOrgine)
            {
                Facture facture = new Facture(BDD, lb_NumTicket.Text);
                facture.updateNbCouvert(bt_NbrCouvert.Text);
            }
            keypressView();
        }

        #region GESTION DES KEYPRESS
        public string TypeAppuiBt = "";
        Button bt_Name;
        
        private void Form_commandes_KeyPress(object sender, KeyPressEventArgs e)
        {
            herit.KeyPressServeur(e);
            herit.KeyControlServeur(bt_Name, TypeAppuiBt);
            keypressView();
        }

        private void Form_commandes_KeyDown(object sender, KeyEventArgs e)
        {
            EnableBtMenus();
        }
        // Problème sur Visual Studio C# 2012 : 
        // > Impossible de récupérer les valeurs des touches NUMERIQUES préssées si le keypress et keydown ne sont pas utilisés simultanément... oO"
        #endregion
        #endregion

        #region TABLE ET COUVERTS
        private void bt_NumTable_Click(object sender, EventArgs e)
        {
            TypeAppuiBt = "NUM";
            bt_Name = bt_NumTable;
            number(bt_Name);
        }

        private void bt_NbrCouvert_Click(object sender, EventArgs e)
        {
            TypeAppuiBt = "NBR";
            bt_Name = bt_NbrCouvert;
            number(bt_Name);
        }
        #endregion

        #region BOUTTONS : BOISSONS / A LA CARTE / MENUS

        public bool BouttonCommande = false;     // CARTE ou MENU
        private void bt_Boisson_Click(object sender, EventArgs e)
        {
            BouttonCommande = true; // Dois cibler le numero d'ID_Menu 1
            TypeAppuiBt = "";   // Si il est different de "", sert a afficher les chiffres dans bt_Name.text
            bt_Name = (sender as Button);
            List<string> values = new List<string>();
            values.Add("0");
            values.Add("2");
            values.Add("1");
            herit.KeyPressClear();
            CreateButton(BDD, values);
            values.Clear();
        }

        private void bt_Carte_Click(object sender, EventArgs e)
        {
            BouttonCommande = true;
            TypeAppuiBt = "";
            bt_Name = (sender as Button);
            List<string> values = new List<string>();
            values.Add("1");
            values.Add("2");
            values.Add("1");
            herit.KeyPressClear();
            CreateButton(BDD, values);
            values.Clear();
        }
        private void bt_Menus_Click(object sender, EventArgs e)
        {
            string fuck = "";
            TypeAppuiBt = "";
            bt_Name = (sender as Button);
            List<string> values = new List<string>();
            if (NbrDeMenu > 0)
            {                                               // On affiche tout les menus en tant que bouttons
                BouttonCommande = false;                    // Dois cibler le numero d'ID_Menu
                values.Add("2");
                values.Add("0");                            // critere pro stock : aucune valeur utilisee pour 2
                values.Add("0");                            // 0 = juste un bt n'inserant rien dans le dgv ! =)
            }
            else
            {
                // Requete permettant de connaître le nom du menu disponible :
                BDD.SqlCmd = r.TraitementRequest(BDD.cnx, "Resto.MenusDispoLibelle");
                BDD.SqlDr = BDD.SqlCmd.ExecuteReader();
                
                while (BDD.SqlDr.Read())
                {
                    fuck = BDD.SqlDr[0].ToString();
                    BtTag = BDD.SqlDr[0].ToString();

                    BouttonCommande = true;
                    values.Add("3");
                    values.Add(BDD.SqlDr[0].ToString());
                    values.Add("1");                             // Le bt inserera qqch si on clic dessus
                }
                BDD.SqlDr.Close();
                           
            }
            herit.KeyPressClear();
            CreateButton(BDD, values);
            values.Clear();
            if (NbrDeMenu == 0)
                insertMenu(fuck);   
        }

        #endregion
        
        private void bt_NewCmd_Click(object sender, EventArgs e)
        {
            NewCmd(true);
        }

        private void bt_VoirServeur_Click(object sender, EventArgs e)
        {
            if (Voir_Serveur)
                Voir_Serveur = false;
            else
                Voir_Serveur = true;

            colorVoirServeur();
        }  

        #region EVENT DES BOUTONS DYNAMIQUE ARTICLES
        public Button BtName;       // Contient l'ID du boutton / ID article = shs.SearchNumInString(BtName.Name.ToString())
        public string BtTag = "";   // Contient l'ID du Menu associé à l'article
        public string BtText = "";  // Contient le nom de l'article
        public bool Voir_Serveur = false;

        // Methode permettant l'affichage du Menu selectionné
        private void ButtonChoixMenu_Click(object sender, EventArgs e)
        {
            string ID_Menu = shs.SearchNumInString((sender as Button).Tag.ToString());

            BouttonCommande = true;
            TypeAppuiBt = "";
            bt_Name = (sender as Button);

            List<string> values = new List<string>();
            values.Add("4");                            // switch pro stock au case 3
            values.Add(ID_Menu);                        // Critere = Numero ID du Menu
            values.Add(ID_Menu);                        // 
            CreateButton(BDD, values);

            // Création d'une nouvelle facture
            CreateFacture();
            // Ajoute ou modifie la quantité d'un menu dans le DGV
            insertMenu(ID_Menu);
        }

        // Methode permettant l'insertion de l'article selectionné
        private void ButtonDynamique_Click(object sender, EventArgs e)
        {
            dgv_commande.TabStop = false;
            herit.KeyPressClear();
            BtName = (sender as Button);
            BtTag = (sender as Button).Tag.ToString();
            BtText = (sender as Button).Text.ToString();
            
            dgv_commande.RowTemplate.Height = 40;
            lb_HowToUseIt.Visible = false;

            // Création d'une nouvelle facture
            CreateFacture();
            // Ajoute ou modifie la quantité d'un article dans le DGV
            insertArticle();                  

        }
        #endregion
        private void cob_ChoixCommande_SelectedIndexChanged(object sender, EventArgs e)
        {            
            reloadCommande();
            while (FlowLayoutPanel1.Controls.Count > 0)
            {
                var controltoremove = FlowLayoutPanel1.Controls[0];
                FlowLayoutPanel1.Controls.Remove(controltoremove);
                controltoremove.Dispose();
            }
        }

        private void dgv_commande_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lb_NumTicket.Text != textLabelFactureOrgine)
            {
                Facture facture = new Facture(BDD, lb_NumTicket.Text);
                if (!facture.valider || adminUser.droitUser !=0)
                {
                    if (e.RowIndex >= 0)
                    {
                        if (dgv_commande.CurrentCell.ColumnIndex == dgv_commande.Columns["Produit_Serveur"].Index)
                            VoirServeurUpdate();
                        if (dgv_commande.CurrentCell.ColumnIndex == dgv_commande.Columns["Produit_Qte"].Index)
                        {
                            herit.ZeroInit = true;
                            questionUpdateQTE();
                            tb_KeyPressValue.Clear();
                        }
                    }
                }
            }
        }

        #region GESTION FACTURE (valider etc)
        private void bt_VALIDER_Click(object sender, EventArgs e)
        {
            validerCommande();
        }

        private void bt_IMPRIMER_Click(object sender, EventArgs e)
        {
            imprimerCommande();
        }

        private void bt_CLOTURER_Click(object sender, EventArgs e)
        {
            cloturerCommande();
        }
        #endregion

        #region MODIF ADMIN
        // Acces pour un Administrateur only au panneau d'administration :
        private void bt_PanneauAdmin_Click(object sender, EventArgs e)
        {
            if ((user.droitUser >= 1 && user.droitUser <= 2))
            {
                Form_administration menu = new Form_administration(user);
                menu.Show();
                this.Hide();
            }
            else
            {
                herit.FormUserDeco(this);
            }
        }

        private void tb_PasswordADMIN_Enter(object sender, EventArgs e)
        {
            Window.DesactivateKeyPress = true;
        }
        private void tb_PasswordADMIN_Leave(object sender, EventArgs e)
        {
            Window.DesactivateKeyPress = false;
        }
        private void tb_PasswordADMIN_TextChanged(object sender, EventArgs e)
        {
            if (tb_PasswordADMIN.Text != "" && lb_PasswordADMIN.Text != TxtDeco)
            {
                bt_ConnectionADMIN.Enabled = true;
                bt_ConnectionADMIN.ForeColor = Color.White;
            }
            else
            {
                bt_ConnectionADMIN.ForeColor = Color.Black;
            }
        }

        private void bt_ConnectionADMIN_Click(object sender, EventArgs e)
        {
            connexionSuperviseur();
        }

        private void tb_PasswordADMIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == 13))
            {
                connexionSuperviseur();
            }
        }
        #endregion

        private void dgv_commande_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgv_commande.Sort(dgv_commande.Columns["Produit_IDMenu"], ListSortDirection.Ascending);

            calculPrix();
            if (bt_VALIDER.Enabled == false)
                bt_VALIDER.Enabled = true;
        }

        private void dgv_commande_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgv_commande.Sort(dgv_commande.Columns["Produit_IDMenu"], ListSortDirection.Ascending);

            calculPrix();
            if (dgv_commande.RowCount <= 0)
                bt_VALIDER.Enabled = false;
        }

        
        private void tb_TotalPrice_TextChanged(object sender, EventArgs e)
        {
            //Facture facture = new Facture(BDD, lb_NumTicket.Text);
            //facture.updatePrixTTC(tb_TotalPrice.Text);
        }

        private void bt_offert_Click(object sender, EventArgs e)
        {
            fonction_gratuit();
        }

        private void Form_commandes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion  

    }

    public class DynamicButton // pour la liste des buttons et class à renommer 
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string type { get; set; }

        public DynamicButton(int _id, string _nom)
        {
            id = _id;
            nom = _nom;
        }

        public DynamicButton(int _id, string _nom, string _type)
        {
            id = _id;
            nom = _nom;
            type = _type;
        }
    }
}
