namespace MinutPapillon
{
    partial class Form_commandes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_commandes));
            this.grb_Header = new System.Windows.Forms.GroupBox();
            this.bt_NbrCouvert = new System.Windows.Forms.Button();
            this.bt_NumTable = new System.Windows.Forms.Button();
            this.lb_NomServeur = new System.Windows.Forms.Label();
            this.lb_HeureTicket = new System.Windows.Forms.Label();
            this.lb_DateTicket = new System.Windows.Forms.Label();
            this.lb_NumTicket = new System.Windows.Forms.Label();
            this.lb_TITRE_NomServeur = new System.Windows.Forms.Label();
            this.lb_TITRE_NbrCouvert = new System.Windows.Forms.Label();
            this.lb_TITRE_NumTable = new System.Windows.Forms.Label();
            this.lb_TITRE_HeureTicket = new System.Windows.Forms.Label();
            this.lb_TITRE_DateTicket = new System.Windows.Forms.Label();
            this.lb_TITRE_NumTicket = new System.Windows.Forms.Label();
            this.grb_Commande = new System.Windows.Forms.GroupBox();
            this.cob_ChoixCommande = new System.Windows.Forms.ComboBox();
            this.lb_TotalTTC = new System.Windows.Forms.Label();
            this.tb_TotalPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_commande = new System.Windows.Forms.DataGridView();
            this.Produit_Serveur = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Produit_Menu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produit_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produit_Qte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produit_Prix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produit_IDArticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produit_IDMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produit_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produit_Gratuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grb_Facture = new System.Windows.Forms.GroupBox();
            this.bt_PanneauAdmin = new System.Windows.Forms.Button();
            this.bt_ConnectionADMIN = new System.Windows.Forms.Button();
            this.lb_PasswordADMIN = new System.Windows.Forms.Label();
            this.tb_PasswordADMIN = new System.Windows.Forms.TextBox();
            this.bt_CLOTURER = new System.Windows.Forms.Button();
            this.bt_IMPRIMER = new System.Windows.Forms.Button();
            this.bt_VALIDER = new System.Windows.Forms.Button();
            this.bt_Boisson = new System.Windows.Forms.Button();
            this.bt_Carte = new System.Windows.Forms.Button();
            this.bt_Menus = new System.Windows.Forms.Button();
            this.bt_VoirServeur = new System.Windows.Forms.Button();
            this.bt_neuf = new System.Windows.Forms.Button();
            this.bt_huit = new System.Windows.Forms.Button();
            this.bt_sept = new System.Windows.Forms.Button();
            this.bt_six = new System.Windows.Forms.Button();
            this.bt_cinq = new System.Windows.Forms.Button();
            this.bt_quatre = new System.Windows.Forms.Button();
            this.bt_trois = new System.Windows.Forms.Button();
            this.bt_deux = new System.Windows.Forms.Button();
            this.bt_un = new System.Windows.Forms.Button();
            this.bt_zero = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_MENUS = new System.Windows.Forms.Panel();
            this.bt_offert = new System.Windows.Forms.Button();
            this.bt_NewCmd = new System.Windows.Forms.Button();
            this.panelClavierNum = new System.Windows.Forms.Panel();
            this.bt_ClearKeyPressValue = new System.Windows.Forms.Button();
            this.tb_KeyPressValue = new System.Windows.Forms.TextBox();
            this.lb_HowToUseIt = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grb_Header.SuspendLayout();
            this.grb_Commande.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_commande)).BeginInit();
            this.grb_Facture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_MENUS.SuspendLayout();
            this.panelClavierNum.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb_Header
            // 
            this.grb_Header.BackColor = System.Drawing.Color.Transparent;
            this.grb_Header.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grb_Header.Controls.Add(this.bt_NbrCouvert);
            this.grb_Header.Controls.Add(this.bt_NumTable);
            this.grb_Header.Controls.Add(this.lb_NomServeur);
            this.grb_Header.Controls.Add(this.lb_HeureTicket);
            this.grb_Header.Controls.Add(this.lb_DateTicket);
            this.grb_Header.Controls.Add(this.lb_NumTicket);
            this.grb_Header.Controls.Add(this.lb_TITRE_NomServeur);
            this.grb_Header.Controls.Add(this.lb_TITRE_NbrCouvert);
            this.grb_Header.Controls.Add(this.lb_TITRE_NumTable);
            this.grb_Header.Controls.Add(this.lb_TITRE_HeureTicket);
            this.grb_Header.Controls.Add(this.lb_TITRE_DateTicket);
            this.grb_Header.Controls.Add(this.lb_TITRE_NumTicket);
            this.grb_Header.ForeColor = System.Drawing.Color.White;
            this.grb_Header.Location = new System.Drawing.Point(12, 9);
            this.grb_Header.Name = "grb_Header";
            this.grb_Header.Size = new System.Drawing.Size(339, 112);
            this.grb_Header.TabIndex = 28;
            this.grb_Header.TabStop = false;
            this.grb_Header.Text = "Informations";
            // 
            // bt_NbrCouvert
            // 
            this.bt_NbrCouvert.BackColor = System.Drawing.Color.DarkGray;
            this.bt_NbrCouvert.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_NbrCouvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_NbrCouvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_NbrCouvert.ForeColor = System.Drawing.Color.Cornsilk;
            this.bt_NbrCouvert.Location = new System.Drawing.Point(279, 32);
            this.bt_NbrCouvert.Name = "bt_NbrCouvert";
            this.bt_NbrCouvert.Size = new System.Drawing.Size(52, 44);
            this.bt_NbrCouvert.TabIndex = 13;
            this.bt_NbrCouvert.Text = "NBR";
            this.bt_NbrCouvert.UseVisualStyleBackColor = false;
            this.bt_NbrCouvert.Click += new System.EventHandler(this.bt_NbrCouvert_Click);
            // 
            // bt_NumTable
            // 
            this.bt_NumTable.BackColor = System.Drawing.Color.DarkGray;
            this.bt_NumTable.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_NumTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_NumTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_NumTable.ForeColor = System.Drawing.Color.Cornsilk;
            this.bt_NumTable.Location = new System.Drawing.Point(214, 32);
            this.bt_NumTable.Name = "bt_NumTable";
            this.bt_NumTable.Size = new System.Drawing.Size(51, 44);
            this.bt_NumTable.TabIndex = 12;
            this.bt_NumTable.Text = "NUM";
            this.bt_NumTable.UseVisualStyleBackColor = false;
            this.bt_NumTable.Click += new System.EventHandler(this.bt_NumTable_Click);
            // 
            // lb_NomServeur
            // 
            this.lb_NomServeur.AutoSize = true;
            this.lb_NomServeur.BackColor = System.Drawing.Color.Transparent;
            this.lb_NomServeur.Location = new System.Drawing.Point(63, 87);
            this.lb_NomServeur.MaximumSize = new System.Drawing.Size(270, 16);
            this.lb_NomServeur.Name = "lb_NomServeur";
            this.lb_NomServeur.Size = new System.Drawing.Size(267, 16);
            this.lb_NomServeur.TabIndex = 11;
            this.lb_NomServeur.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            // 
            // lb_HeureTicket
            // 
            this.lb_HeureTicket.AutoSize = true;
            this.lb_HeureTicket.BackColor = System.Drawing.Color.Transparent;
            this.lb_HeureTicket.Location = new System.Drawing.Point(112, 56);
            this.lb_HeureTicket.MaximumSize = new System.Drawing.Size(200, 13);
            this.lb_HeureTicket.Name = "lb_HeureTicket";
            this.lb_HeureTicket.Size = new System.Drawing.Size(49, 13);
            this.lb_HeureTicket.TabIndex = 8;
            this.lb_HeureTicket.Text = "00:00:00";
            // 
            // lb_DateTicket
            // 
            this.lb_DateTicket.AutoSize = true;
            this.lb_DateTicket.BackColor = System.Drawing.Color.Transparent;
            this.lb_DateTicket.Location = new System.Drawing.Point(111, 38);
            this.lb_DateTicket.MaximumSize = new System.Drawing.Size(200, 13);
            this.lb_DateTicket.Name = "lb_DateTicket";
            this.lb_DateTicket.Size = new System.Drawing.Size(65, 13);
            this.lb_DateTicket.TabIndex = 7;
            this.lb_DateTicket.Text = "00/00/0000";
            // 
            // lb_NumTicket
            // 
            this.lb_NumTicket.AutoSize = true;
            this.lb_NumTicket.BackColor = System.Drawing.Color.Transparent;
            this.lb_NumTicket.Location = new System.Drawing.Point(111, 21);
            this.lb_NumTicket.MaximumSize = new System.Drawing.Size(200, 13);
            this.lb_NumTicket.Name = "lb_NumTicket";
            this.lb_NumTicket.Size = new System.Drawing.Size(115, 13);
            this.lb_NumTicket.TabIndex = 6;
            this.lb_NumTicket.Text = "(Enregistrez un produit)";
            // 
            // lb_TITRE_NomServeur
            // 
            this.lb_TITRE_NomServeur.AutoSize = true;
            this.lb_TITRE_NomServeur.BackColor = System.Drawing.Color.Transparent;
            this.lb_TITRE_NomServeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TITRE_NomServeur.Location = new System.Drawing.Point(7, 87);
            this.lb_TITRE_NomServeur.Name = "lb_TITRE_NomServeur";
            this.lb_TITRE_NomServeur.Size = new System.Drawing.Size(50, 13);
            this.lb_TITRE_NomServeur.TabIndex = 5;
            this.lb_TITRE_NomServeur.Text = "Serveur :";
            // 
            // lb_TITRE_NbrCouvert
            // 
            this.lb_TITRE_NbrCouvert.AutoSize = true;
            this.lb_TITRE_NbrCouvert.BackColor = System.Drawing.Color.Transparent;
            this.lb_TITRE_NbrCouvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TITRE_NbrCouvert.Location = new System.Drawing.Point(278, 16);
            this.lb_TITRE_NbrCouvert.Name = "lb_TITRE_NbrCouvert";
            this.lb_TITRE_NbrCouvert.Size = new System.Drawing.Size(55, 13);
            this.lb_TITRE_NbrCouvert.TabIndex = 4;
            this.lb_TITRE_NbrCouvert.Text = "Couverts :";
            // 
            // lb_TITRE_NumTable
            // 
            this.lb_TITRE_NumTable.AutoSize = true;
            this.lb_TITRE_NumTable.BackColor = System.Drawing.Color.Transparent;
            this.lb_TITRE_NumTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TITRE_NumTable.Location = new System.Drawing.Point(221, 16);
            this.lb_TITRE_NumTable.Name = "lb_TITRE_NumTable";
            this.lb_TITRE_NumTable.Size = new System.Drawing.Size(40, 13);
            this.lb_TITRE_NumTable.TabIndex = 3;
            this.lb_TITRE_NumTable.Text = "Table :";
            // 
            // lb_TITRE_HeureTicket
            // 
            this.lb_TITRE_HeureTicket.AutoSize = true;
            this.lb_TITRE_HeureTicket.BackColor = System.Drawing.Color.Transparent;
            this.lb_TITRE_HeureTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TITRE_HeureTicket.Location = new System.Drawing.Point(7, 56);
            this.lb_TITRE_HeureTicket.Name = "lb_TITRE_HeureTicket";
            this.lb_TITRE_HeureTicket.Size = new System.Drawing.Size(86, 13);
            this.lb_TITRE_HeureTicket.TabIndex = 2;
            this.lb_TITRE_HeureTicket.Text = "Heure du ticket :";
            // 
            // lb_TITRE_DateTicket
            // 
            this.lb_TITRE_DateTicket.AutoSize = true;
            this.lb_TITRE_DateTicket.BackColor = System.Drawing.Color.Transparent;
            this.lb_TITRE_DateTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TITRE_DateTicket.Location = new System.Drawing.Point(7, 38);
            this.lb_TITRE_DateTicket.Name = "lb_TITRE_DateTicket";
            this.lb_TITRE_DateTicket.Size = new System.Drawing.Size(80, 13);
            this.lb_TITRE_DateTicket.TabIndex = 1;
            this.lb_TITRE_DateTicket.Text = "Date du ticket :";
            // 
            // lb_TITRE_NumTicket
            // 
            this.lb_TITRE_NumTicket.AutoSize = true;
            this.lb_TITRE_NumTicket.BackColor = System.Drawing.Color.Transparent;
            this.lb_TITRE_NumTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TITRE_NumTicket.Location = new System.Drawing.Point(7, 21);
            this.lb_TITRE_NumTicket.Name = "lb_TITRE_NumTicket";
            this.lb_TITRE_NumTicket.Size = new System.Drawing.Size(94, 13);
            this.lb_TITRE_NumTicket.TabIndex = 0;
            this.lb_TITRE_NumTicket.Text = "Numéro du ticket :";
            // 
            // grb_Commande
            // 
            this.grb_Commande.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grb_Commande.BackColor = System.Drawing.Color.Transparent;
            this.grb_Commande.Controls.Add(this.cob_ChoixCommande);
            this.grb_Commande.Controls.Add(this.lb_TotalTTC);
            this.grb_Commande.Controls.Add(this.tb_TotalPrice);
            this.grb_Commande.Controls.Add(this.label1);
            this.grb_Commande.Controls.Add(this.dgv_commande);
            this.grb_Commande.ForeColor = System.Drawing.Color.Black;
            this.grb_Commande.Location = new System.Drawing.Point(12, 122);
            this.grb_Commande.Name = "grb_Commande";
            this.grb_Commande.Size = new System.Drawing.Size(339, 340);
            this.grb_Commande.TabIndex = 29;
            this.grb_Commande.TabStop = false;
            this.grb_Commande.Text = "                                 ";
            // 
            // cob_ChoixCommande
            // 
            this.cob_ChoixCommande.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_ChoixCommande.FormattingEnabled = true;
            this.cob_ChoixCommande.Items.AddRange(new object[] {
            "Commande en cours",
            "Commande 1",
            "Commande 2",
            "Commande 3"});
            this.cob_ChoixCommande.Location = new System.Drawing.Point(189, -1);
            this.cob_ChoixCommande.Name = "cob_ChoixCommande";
            this.cob_ChoixCommande.Size = new System.Drawing.Size(148, 21);
            this.cob_ChoixCommande.TabIndex = 2;
            this.cob_ChoixCommande.SelectedIndexChanged += new System.EventHandler(this.cob_ChoixCommande_SelectedIndexChanged);
            // 
            // lb_TotalTTC
            // 
            this.lb_TotalTTC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_TotalTTC.AutoSize = true;
            this.lb_TotalTTC.ForeColor = System.Drawing.Color.White;
            this.lb_TotalTTC.Location = new System.Drawing.Point(7, 323);
            this.lb_TotalTTC.Name = "lb_TotalTTC";
            this.lb_TotalTTC.Size = new System.Drawing.Size(205, 13);
            this.lb_TotalTTC.TabIndex = 51;
            this.lb_TotalTTC.Text = "Prix total TTC de la commande en cours : ";
            // 
            // tb_TotalPrice
            // 
            this.tb_TotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_TotalPrice.Enabled = false;
            this.tb_TotalPrice.Location = new System.Drawing.Point(212, 320);
            this.tb_TotalPrice.Name = "tb_TotalPrice";
            this.tb_TotalPrice.ReadOnly = true;
            this.tb_TotalPrice.Size = new System.Drawing.Size(125, 20);
            this.tb_TotalPrice.TabIndex = 50;
            this.tb_TotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_TotalPrice.TextChanged += new System.EventHandler(this.tb_TotalPrice_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Table en cours";
            // 
            // dgv_commande
            // 
            this.dgv_commande.AllowUserToAddRows = false;
            this.dgv_commande.AllowUserToDeleteRows = false;
            this.dgv_commande.AllowUserToResizeRows = false;
            this.dgv_commande.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_commande.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_commande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_commande.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Produit_Serveur,
            this.Produit_Menu,
            this.Produit_Name,
            this.Produit_Qte,
            this.Produit_Prix,
            this.Produit_IDArticle,
            this.Produit_IDMenu,
            this.Produit_Type,
            this.Produit_Gratuit});
            this.dgv_commande.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgv_commande.Location = new System.Drawing.Point(1, 19);
            this.dgv_commande.MultiSelect = false;
            this.dgv_commande.Name = "dgv_commande";
            this.dgv_commande.ReadOnly = true;
            this.dgv_commande.RowHeadersVisible = false;
            this.dgv_commande.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_commande.Size = new System.Drawing.Size(337, 301);
            this.dgv_commande.TabIndex = 3;
            this.dgv_commande.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_commande_CellClick);
            this.dgv_commande.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_commande_RowsAdded);
            this.dgv_commande.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_commande_RowsRemoved);
            // 
            // Produit_Serveur
            // 
            this.Produit_Serveur.FillWeight = 55F;
            this.Produit_Serveur.HeaderText = "Serveur";
            this.Produit_Serveur.Name = "Produit_Serveur";
            this.Produit_Serveur.ReadOnly = true;
            this.Produit_Serveur.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Produit_Menu
            // 
            this.Produit_Menu.FillWeight = 55F;
            this.Produit_Menu.HeaderText = "Menu";
            this.Produit_Menu.Name = "Produit_Menu";
            this.Produit_Menu.ReadOnly = true;
            this.Produit_Menu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Produit_Name
            // 
            this.Produit_Name.FillWeight = 180F;
            this.Produit_Name.HeaderText = "Nom Article";
            this.Produit_Name.Name = "Produit_Name";
            this.Produit_Name.ReadOnly = true;
            this.Produit_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Produit_Qte
            // 
            this.Produit_Qte.FillWeight = 40F;
            this.Produit_Qte.HeaderText = "QTE";
            this.Produit_Qte.Name = "Produit_Qte";
            this.Produit_Qte.ReadOnly = true;
            this.Produit_Qte.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Produit_Qte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Produit_Prix
            // 
            this.Produit_Prix.FillWeight = 45F;
            this.Produit_Prix.HeaderText = "PU T.T.C.";
            this.Produit_Prix.Name = "Produit_Prix";
            this.Produit_Prix.ReadOnly = true;
            this.Produit_Prix.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Produit_Prix.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Produit_IDArticle
            // 
            this.Produit_IDArticle.HeaderText = "IDArticle";
            this.Produit_IDArticle.Name = "Produit_IDArticle";
            this.Produit_IDArticle.ReadOnly = true;
            this.Produit_IDArticle.Visible = false;
            // 
            // Produit_IDMenu
            // 
            this.Produit_IDMenu.FillWeight = 30F;
            this.Produit_IDMenu.HeaderText = "IDMenu";
            this.Produit_IDMenu.Name = "Produit_IDMenu";
            this.Produit_IDMenu.ReadOnly = true;
            this.Produit_IDMenu.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Produit_IDMenu.Visible = false;
            // 
            // Produit_Type
            // 
            this.Produit_Type.HeaderText = "Type";
            this.Produit_Type.Name = "Produit_Type";
            this.Produit_Type.ReadOnly = true;
            this.Produit_Type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Produit_Type.Visible = false;
            // 
            // Produit_Gratuit
            // 
            this.Produit_Gratuit.HeaderText = "Gratuit";
            this.Produit_Gratuit.Name = "Produit_Gratuit";
            this.Produit_Gratuit.ReadOnly = true;
            this.Produit_Gratuit.Visible = false;
            // 
            // grb_Facture
            // 
            this.grb_Facture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grb_Facture.BackColor = System.Drawing.Color.Transparent;
            this.grb_Facture.Controls.Add(this.bt_PanneauAdmin);
            this.grb_Facture.Controls.Add(this.bt_ConnectionADMIN);
            this.grb_Facture.Controls.Add(this.lb_PasswordADMIN);
            this.grb_Facture.Controls.Add(this.tb_PasswordADMIN);
            this.grb_Facture.Controls.Add(this.bt_CLOTURER);
            this.grb_Facture.Controls.Add(this.bt_IMPRIMER);
            this.grb_Facture.Controls.Add(this.bt_VALIDER);
            this.grb_Facture.ForeColor = System.Drawing.Color.White;
            this.grb_Facture.Location = new System.Drawing.Point(12, 468);
            this.grb_Facture.Name = "grb_Facture";
            this.grb_Facture.Size = new System.Drawing.Size(339, 121);
            this.grb_Facture.TabIndex = 30;
            this.grb_Facture.TabStop = false;
            this.grb_Facture.Text = "Gestion de Factures";
            // 
            // bt_PanneauAdmin
            // 
            this.bt_PanneauAdmin.BackColor = System.Drawing.Color.Transparent;
            this.bt_PanneauAdmin.BackgroundImage = global::MinutPapillon.Properties.Resources.ADMIN;
            this.bt_PanneauAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_PanneauAdmin.FlatAppearance.BorderSize = 0;
            this.bt_PanneauAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PanneauAdmin.ForeColor = System.Drawing.Color.Lime;
            this.bt_PanneauAdmin.Location = new System.Drawing.Point(10, 75);
            this.bt_PanneauAdmin.Name = "bt_PanneauAdmin";
            this.bt_PanneauAdmin.Size = new System.Drawing.Size(47, 40);
            this.bt_PanneauAdmin.TabIndex = 34;
            this.bt_PanneauAdmin.UseVisualStyleBackColor = false;
            this.bt_PanneauAdmin.Click += new System.EventHandler(this.bt_PanneauAdmin_Click);
            // 
            // bt_ConnectionADMIN
            // 
            this.bt_ConnectionADMIN.BackColor = System.Drawing.Color.DarkGray;
            this.bt_ConnectionADMIN.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_ConnectionADMIN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ConnectionADMIN.Enabled = false;
            this.bt_ConnectionADMIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ConnectionADMIN.ForeColor = System.Drawing.Color.Black;
            this.bt_ConnectionADMIN.Location = new System.Drawing.Point(199, 75);
            this.bt_ConnectionADMIN.Name = "bt_ConnectionADMIN";
            this.bt_ConnectionADMIN.Size = new System.Drawing.Size(134, 40);
            this.bt_ConnectionADMIN.TabIndex = 33;
            this.bt_ConnectionADMIN.Text = "&MODE EDITION";
            this.bt_ConnectionADMIN.UseVisualStyleBackColor = false;
            this.bt_ConnectionADMIN.Click += new System.EventHandler(this.bt_ConnectionADMIN_Click);
            // 
            // lb_PasswordADMIN
            // 
            this.lb_PasswordADMIN.AutoSize = true;
            this.lb_PasswordADMIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_PasswordADMIN.Location = new System.Drawing.Point(61, 79);
            this.lb_PasswordADMIN.Name = "lb_PasswordADMIN";
            this.lb_PasswordADMIN.Size = new System.Drawing.Size(128, 13);
            this.lb_PasswordADMIN.TabIndex = 31;
            this.lb_PasswordADMIN.Text = "Password Administrateur :";
            // 
            // tb_PasswordADMIN
            // 
            this.tb_PasswordADMIN.Location = new System.Drawing.Point(62, 95);
            this.tb_PasswordADMIN.Name = "tb_PasswordADMIN";
            this.tb_PasswordADMIN.Size = new System.Drawing.Size(133, 20);
            this.tb_PasswordADMIN.TabIndex = 30;
            this.tb_PasswordADMIN.UseSystemPasswordChar = true;
            this.tb_PasswordADMIN.TextChanged += new System.EventHandler(this.tb_PasswordADMIN_TextChanged);
            this.tb_PasswordADMIN.Enter += new System.EventHandler(this.tb_PasswordADMIN_Enter);
            this.tb_PasswordADMIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_PasswordADMIN_KeyPress);
            this.tb_PasswordADMIN.Leave += new System.EventHandler(this.tb_PasswordADMIN_Leave);
            // 
            // bt_CLOTURER
            // 
            this.bt_CLOTURER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_CLOTURER.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_CLOTURER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_CLOTURER.Enabled = false;
            this.bt_CLOTURER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_CLOTURER.ForeColor = System.Drawing.Color.Black;
            this.bt_CLOTURER.Location = new System.Drawing.Point(238, 19);
            this.bt_CLOTURER.Name = "bt_CLOTURER";
            this.bt_CLOTURER.Size = new System.Drawing.Size(98, 50);
            this.bt_CLOTURER.TabIndex = 2;
            this.bt_CLOTURER.Text = "&CLOTURER";
            this.bt_CLOTURER.UseVisualStyleBackColor = false;
            this.bt_CLOTURER.Click += new System.EventHandler(this.bt_CLOTURER_Click);
            // 
            // bt_IMPRIMER
            // 
            this.bt_IMPRIMER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_IMPRIMER.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_IMPRIMER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_IMPRIMER.Enabled = false;
            this.bt_IMPRIMER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_IMPRIMER.ForeColor = System.Drawing.Color.Black;
            this.bt_IMPRIMER.Location = new System.Drawing.Point(124, 19);
            this.bt_IMPRIMER.Name = "bt_IMPRIMER";
            this.bt_IMPRIMER.Size = new System.Drawing.Size(108, 50);
            this.bt_IMPRIMER.TabIndex = 1;
            this.bt_IMPRIMER.Text = "&IMPRIMER";
            this.bt_IMPRIMER.UseVisualStyleBackColor = false;
            this.bt_IMPRIMER.Click += new System.EventHandler(this.bt_IMPRIMER_Click);
            // 
            // bt_VALIDER
            // 
            this.bt_VALIDER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_VALIDER.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_VALIDER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_VALIDER.Enabled = false;
            this.bt_VALIDER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_VALIDER.ForeColor = System.Drawing.Color.Black;
            this.bt_VALIDER.Location = new System.Drawing.Point(10, 19);
            this.bt_VALIDER.Name = "bt_VALIDER";
            this.bt_VALIDER.Size = new System.Drawing.Size(108, 50);
            this.bt_VALIDER.TabIndex = 0;
            this.bt_VALIDER.Text = "&VALIDER";
            this.bt_VALIDER.UseVisualStyleBackColor = false;
            this.bt_VALIDER.Click += new System.EventHandler(this.bt_VALIDER_Click);
            // 
            // bt_Boisson
            // 
            this.bt_Boisson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Boisson.BackColor = System.Drawing.Color.LightSkyBlue;
            this.bt_Boisson.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_Boisson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Boisson.Enabled = false;
            this.bt_Boisson.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Boisson.ForeColor = System.Drawing.Color.White;
            this.bt_Boisson.Location = new System.Drawing.Point(3, 3);
            this.bt_Boisson.Name = "bt_Boisson";
            this.bt_Boisson.Size = new System.Drawing.Size(110, 73);
            this.bt_Boisson.TabIndex = 47;
            this.bt_Boisson.Text = "BOISSONS";
            this.bt_Boisson.UseVisualStyleBackColor = false;
            this.bt_Boisson.Visible = false;
            this.bt_Boisson.Click += new System.EventHandler(this.bt_Boisson_Click);
            // 
            // bt_Carte
            // 
            this.bt_Carte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Carte.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bt_Carte.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_Carte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Carte.Enabled = false;
            this.bt_Carte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Carte.ForeColor = System.Drawing.Color.White;
            this.bt_Carte.Location = new System.Drawing.Point(119, 3);
            this.bt_Carte.Name = "bt_Carte";
            this.bt_Carte.Size = new System.Drawing.Size(110, 73);
            this.bt_Carte.TabIndex = 46;
            this.bt_Carte.Text = "A LA CARTE";
            this.bt_Carte.UseVisualStyleBackColor = false;
            this.bt_Carte.Visible = false;
            this.bt_Carte.Click += new System.EventHandler(this.bt_Carte_Click);
            // 
            // bt_Menus
            // 
            this.bt_Menus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Menus.BackColor = System.Drawing.Color.LightSeaGreen;
            this.bt_Menus.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_Menus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Menus.Enabled = false;
            this.bt_Menus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Menus.ForeColor = System.Drawing.Color.White;
            this.bt_Menus.Location = new System.Drawing.Point(235, 3);
            this.bt_Menus.Name = "bt_Menus";
            this.bt_Menus.Size = new System.Drawing.Size(110, 73);
            this.bt_Menus.TabIndex = 42;
            this.bt_Menus.Text = "MENUS";
            this.bt_Menus.UseVisualStyleBackColor = false;
            this.bt_Menus.Visible = false;
            this.bt_Menus.Click += new System.EventHandler(this.bt_Menus_Click);
            // 
            // bt_VoirServeur
            // 
            this.bt_VoirServeur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_VoirServeur.BackColor = System.Drawing.Color.LightGreen;
            this.bt_VoirServeur.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_VoirServeur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_VoirServeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_VoirServeur.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_VoirServeur.Location = new System.Drawing.Point(469, 3);
            this.bt_VoirServeur.Name = "bt_VoirServeur";
            this.bt_VoirServeur.Size = new System.Drawing.Size(86, 73);
            this.bt_VoirServeur.TabIndex = 41;
            this.bt_VoirServeur.Text = "VOIR &SERVEUR";
            this.bt_VoirServeur.UseVisualStyleBackColor = false;
            this.bt_VoirServeur.Visible = false;
            this.bt_VoirServeur.Click += new System.EventHandler(this.bt_VoirServeur_Click);
            // 
            // bt_neuf
            // 
            this.bt_neuf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_neuf.BackColor = System.Drawing.Color.DarkGray;
            this.bt_neuf.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_neuf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_neuf.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_neuf.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_neuf.Location = new System.Drawing.Point(505, 3);
            this.bt_neuf.Name = "bt_neuf";
            this.bt_neuf.Size = new System.Drawing.Size(50, 60);
            this.bt_neuf.TabIndex = 40;
            this.bt_neuf.Text = "9";
            this.bt_neuf.UseVisualStyleBackColor = false;
            this.bt_neuf.Click += new System.EventHandler(this.btNum_Click);
            // 
            // bt_huit
            // 
            this.bt_huit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_huit.BackColor = System.Drawing.Color.DarkGray;
            this.bt_huit.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_huit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_huit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_huit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_huit.Location = new System.Drawing.Point(449, 3);
            this.bt_huit.Name = "bt_huit";
            this.bt_huit.Size = new System.Drawing.Size(50, 60);
            this.bt_huit.TabIndex = 39;
            this.bt_huit.Text = "8";
            this.bt_huit.UseVisualStyleBackColor = false;
            this.bt_huit.Click += new System.EventHandler(this.btNum_Click);
            // 
            // bt_sept
            // 
            this.bt_sept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_sept.BackColor = System.Drawing.Color.DarkGray;
            this.bt_sept.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_sept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_sept.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_sept.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_sept.Location = new System.Drawing.Point(393, 3);
            this.bt_sept.Name = "bt_sept";
            this.bt_sept.Size = new System.Drawing.Size(50, 60);
            this.bt_sept.TabIndex = 38;
            this.bt_sept.Text = "7";
            this.bt_sept.UseVisualStyleBackColor = false;
            this.bt_sept.Click += new System.EventHandler(this.btNum_Click);
            // 
            // bt_six
            // 
            this.bt_six.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_six.BackColor = System.Drawing.Color.DarkGray;
            this.bt_six.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_six.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_six.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_six.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_six.Location = new System.Drawing.Point(337, 3);
            this.bt_six.Name = "bt_six";
            this.bt_six.Size = new System.Drawing.Size(50, 60);
            this.bt_six.TabIndex = 37;
            this.bt_six.Text = "6";
            this.bt_six.UseVisualStyleBackColor = false;
            this.bt_six.Click += new System.EventHandler(this.btNum_Click);
            // 
            // bt_cinq
            // 
            this.bt_cinq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_cinq.BackColor = System.Drawing.Color.DarkGray;
            this.bt_cinq.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_cinq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_cinq.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cinq.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_cinq.Location = new System.Drawing.Point(281, 3);
            this.bt_cinq.Name = "bt_cinq";
            this.bt_cinq.Size = new System.Drawing.Size(50, 60);
            this.bt_cinq.TabIndex = 36;
            this.bt_cinq.Text = "5";
            this.bt_cinq.UseVisualStyleBackColor = false;
            this.bt_cinq.Click += new System.EventHandler(this.btNum_Click);
            // 
            // bt_quatre
            // 
            this.bt_quatre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_quatre.BackColor = System.Drawing.Color.DarkGray;
            this.bt_quatre.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_quatre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_quatre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_quatre.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_quatre.Location = new System.Drawing.Point(225, 3);
            this.bt_quatre.Name = "bt_quatre";
            this.bt_quatre.Size = new System.Drawing.Size(50, 60);
            this.bt_quatre.TabIndex = 35;
            this.bt_quatre.Text = "4";
            this.bt_quatre.UseVisualStyleBackColor = false;
            this.bt_quatre.Click += new System.EventHandler(this.btNum_Click);
            // 
            // bt_trois
            // 
            this.bt_trois.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_trois.BackColor = System.Drawing.Color.DarkGray;
            this.bt_trois.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_trois.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_trois.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_trois.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_trois.Location = new System.Drawing.Point(169, 3);
            this.bt_trois.Name = "bt_trois";
            this.bt_trois.Size = new System.Drawing.Size(50, 60);
            this.bt_trois.TabIndex = 34;
            this.bt_trois.Text = "3";
            this.bt_trois.UseVisualStyleBackColor = false;
            this.bt_trois.Click += new System.EventHandler(this.btNum_Click);
            // 
            // bt_deux
            // 
            this.bt_deux.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_deux.BackColor = System.Drawing.Color.DarkGray;
            this.bt_deux.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_deux.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_deux.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_deux.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_deux.Location = new System.Drawing.Point(113, 3);
            this.bt_deux.Name = "bt_deux";
            this.bt_deux.Size = new System.Drawing.Size(50, 60);
            this.bt_deux.TabIndex = 33;
            this.bt_deux.Text = "2";
            this.bt_deux.UseVisualStyleBackColor = false;
            this.bt_deux.Click += new System.EventHandler(this.btNum_Click);
            // 
            // bt_un
            // 
            this.bt_un.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_un.BackColor = System.Drawing.Color.DarkGray;
            this.bt_un.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_un.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_un.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_un.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_un.Location = new System.Drawing.Point(56, 3);
            this.bt_un.Name = "bt_un";
            this.bt_un.Size = new System.Drawing.Size(50, 60);
            this.bt_un.TabIndex = 32;
            this.bt_un.Text = "1";
            this.bt_un.UseVisualStyleBackColor = false;
            this.bt_un.Click += new System.EventHandler(this.btNum_Click);
            // 
            // bt_zero
            // 
            this.bt_zero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_zero.BackColor = System.Drawing.Color.DarkGray;
            this.bt_zero.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_zero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_zero.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_zero.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_zero.Location = new System.Drawing.Point(3, 3);
            this.bt_zero.Name = "bt_zero";
            this.bt_zero.Size = new System.Drawing.Size(47, 60);
            this.bt_zero.TabIndex = 31;
            this.bt_zero.Text = "0";
            this.bt_zero.UseVisualStyleBackColor = false;
            this.bt_zero.Click += new System.EventHandler(this.btNum_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(357, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 139);
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // panel_MENUS
            // 
            this.panel_MENUS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_MENUS.BackColor = System.Drawing.Color.Transparent;
            this.panel_MENUS.Controls.Add(this.bt_offert);
            this.panel_MENUS.Controls.Add(this.bt_NewCmd);
            this.panel_MENUS.Controls.Add(this.bt_Boisson);
            this.panel_MENUS.Controls.Add(this.bt_Carte);
            this.panel_MENUS.Controls.Add(this.bt_Menus);
            this.panel_MENUS.Controls.Add(this.bt_VoirServeur);
            this.panel_MENUS.Location = new System.Drawing.Point(362, 12);
            this.panel_MENUS.Name = "panel_MENUS";
            this.panel_MENUS.Size = new System.Drawing.Size(638, 79);
            this.panel_MENUS.TabIndex = 49;
            this.panel_MENUS.Visible = false;
            // 
            // bt_offert
            // 
            this.bt_offert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_offert.BackColor = System.Drawing.Color.Orange;
            this.bt_offert.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_offert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_offert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_offert.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_offert.Location = new System.Drawing.Point(559, 3);
            this.bt_offert.Name = "bt_offert";
            this.bt_offert.Size = new System.Drawing.Size(74, 73);
            this.bt_offert.TabIndex = 49;
            this.bt_offert.Text = "OFFERT";
            this.bt_offert.UseVisualStyleBackColor = false;
            this.bt_offert.Click += new System.EventHandler(this.bt_offert_Click);
            // 
            // bt_NewCmd
            // 
            this.bt_NewCmd.BackColor = System.Drawing.Color.LightGray;
            this.bt_NewCmd.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_NewCmd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_NewCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_NewCmd.ForeColor = System.Drawing.Color.White;
            this.bt_NewCmd.Location = new System.Drawing.Point(357, 3);
            this.bt_NewCmd.Name = "bt_NewCmd";
            this.bt_NewCmd.Size = new System.Drawing.Size(106, 73);
            this.bt_NewCmd.TabIndex = 48;
            this.bt_NewCmd.Text = "NOUVELLE COMMANDE";
            this.bt_NewCmd.UseVisualStyleBackColor = false;
            this.bt_NewCmd.Click += new System.EventHandler(this.bt_NewCmd_Click);
            // 
            // panelClavierNum
            // 
            this.panelClavierNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelClavierNum.BackColor = System.Drawing.Color.Transparent;
            this.panelClavierNum.Controls.Add(this.bt_ClearKeyPressValue);
            this.panelClavierNum.Controls.Add(this.tb_KeyPressValue);
            this.panelClavierNum.Controls.Add(this.bt_zero);
            this.panelClavierNum.Controls.Add(this.bt_un);
            this.panelClavierNum.Controls.Add(this.bt_deux);
            this.panelClavierNum.Controls.Add(this.bt_neuf);
            this.panelClavierNum.Controls.Add(this.bt_trois);
            this.panelClavierNum.Controls.Add(this.bt_huit);
            this.panelClavierNum.Controls.Add(this.bt_quatre);
            this.panelClavierNum.Controls.Add(this.bt_sept);
            this.panelClavierNum.Controls.Add(this.bt_cinq);
            this.panelClavierNum.Controls.Add(this.bt_six);
            this.panelClavierNum.Location = new System.Drawing.Point(362, 94);
            this.panelClavierNum.Name = "panelClavierNum";
            this.panelClavierNum.Size = new System.Drawing.Size(638, 66);
            this.panelClavierNum.TabIndex = 50;
            // 
            // bt_ClearKeyPressValue
            // 
            this.bt_ClearKeyPressValue.BackColor = System.Drawing.Color.DimGray;
            this.bt_ClearKeyPressValue.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_ClearKeyPressValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ClearKeyPressValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ClearKeyPressValue.ForeColor = System.Drawing.Color.White;
            this.bt_ClearKeyPressValue.Location = new System.Drawing.Point(559, 28);
            this.bt_ClearKeyPressValue.Name = "bt_ClearKeyPressValue";
            this.bt_ClearKeyPressValue.Size = new System.Drawing.Size(75, 35);
            this.bt_ClearKeyPressValue.TabIndex = 42;
            this.bt_ClearKeyPressValue.Text = "CLEAR";
            this.bt_ClearKeyPressValue.UseVisualStyleBackColor = false;
            this.bt_ClearKeyPressValue.Click += new System.EventHandler(this.bt_ClearKeyPressValue_Click);
            // 
            // tb_KeyPressValue
            // 
            this.tb_KeyPressValue.BackColor = System.Drawing.Color.Gainsboro;
            this.tb_KeyPressValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_KeyPressValue.Location = new System.Drawing.Point(561, 3);
            this.tb_KeyPressValue.Name = "tb_KeyPressValue";
            this.tb_KeyPressValue.ReadOnly = true;
            this.tb_KeyPressValue.Size = new System.Drawing.Size(73, 21);
            this.tb_KeyPressValue.TabIndex = 41;
            this.tb_KeyPressValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_HowToUseIt
            // 
            this.lb_HowToUseIt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_HowToUseIt.AutoSize = true;
            this.lb_HowToUseIt.BackColor = System.Drawing.Color.Transparent;
            this.lb_HowToUseIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_HowToUseIt.ForeColor = System.Drawing.Color.White;
            this.lb_HowToUseIt.Location = new System.Drawing.Point(385, 15);
            this.lb_HowToUseIt.Name = "lb_HowToUseIt";
            this.lb_HowToUseIt.Size = new System.Drawing.Size(590, 80);
            this.lb_HowToUseIt.TabIndex = 1;
            this.lb_HowToUseIt.Text = resources.GetString("lb_HowToUseIt.Text");
            this.lb_HowToUseIt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowLayoutPanel1.AutoScroll = true;
            this.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.FlowLayoutPanel1.BackgroundImage = global::MinutPapillon.Properties.Resources.pac_miam;
            this.FlowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(357, 166);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(643, 423);
            this.FlowLayoutPanel1.TabIndex = 51;
            // 
            // Form_commandes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MinutPapillon.Properties.Resources.BGLuxury;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.lb_HowToUseIt);
            this.Controls.Add(this.panelClavierNum);
            this.Controls.Add(this.panel_MENUS);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grb_Facture);
            this.Controls.Add(this.grb_Commande);
            this.Controls.Add(this.grb_Header);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "Form_commandes";
            this.Text = "MinutPapillon - Prise de commandes (Serveurs)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_commandes_FormClosing);
            this.Load += new System.EventHandler(this.Form_commandes_Load);
            this.SizeChanged += new System.EventHandler(this.FormSizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_commandes_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_commandes_KeyPress);
            this.grb_Header.ResumeLayout(false);
            this.grb_Header.PerformLayout();
            this.grb_Commande.ResumeLayout(false);
            this.grb_Commande.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_commande)).EndInit();
            this.grb_Facture.ResumeLayout(false);
            this.grb_Facture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_MENUS.ResumeLayout(false);
            this.panelClavierNum.ResumeLayout(false);
            this.panelClavierNum.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_Header;
        private System.Windows.Forms.Button bt_NbrCouvert;
        private System.Windows.Forms.Button bt_NumTable;
        private System.Windows.Forms.Label lb_NomServeur;
        private System.Windows.Forms.Label lb_HeureTicket;
        private System.Windows.Forms.Label lb_DateTicket;
        private System.Windows.Forms.Label lb_NumTicket;
        private System.Windows.Forms.Label lb_TITRE_NomServeur;
        private System.Windows.Forms.Label lb_TITRE_NbrCouvert;
        private System.Windows.Forms.Label lb_TITRE_NumTable;
        private System.Windows.Forms.Label lb_TITRE_HeureTicket;
        private System.Windows.Forms.Label lb_TITRE_DateTicket;
        private System.Windows.Forms.Label lb_TITRE_NumTicket;
        private System.Windows.Forms.GroupBox grb_Commande;
        private System.Windows.Forms.ComboBox cob_ChoixCommande;
        private System.Windows.Forms.GroupBox grb_Facture;
        private System.Windows.Forms.Button bt_PanneauAdmin;
        private System.Windows.Forms.Button bt_ConnectionADMIN;
        private System.Windows.Forms.Label lb_PasswordADMIN;
        private System.Windows.Forms.TextBox tb_PasswordADMIN;
        private System.Windows.Forms.Button bt_CLOTURER;
        private System.Windows.Forms.Button bt_IMPRIMER;
        private System.Windows.Forms.Button bt_VALIDER;
        private System.Windows.Forms.Button bt_Boisson;
        private System.Windows.Forms.Button bt_Carte;
        private System.Windows.Forms.Button bt_Menus;
        private System.Windows.Forms.Button bt_VoirServeur;
        private System.Windows.Forms.Button bt_neuf;
        private System.Windows.Forms.Button bt_huit;
        private System.Windows.Forms.Button bt_sept;
        private System.Windows.Forms.Button bt_six;
        private System.Windows.Forms.Button bt_cinq;
        private System.Windows.Forms.Button bt_quatre;
        private System.Windows.Forms.Button bt_trois;
        private System.Windows.Forms.Button bt_deux;
        private System.Windows.Forms.Button bt_un;
        private System.Windows.Forms.Button bt_zero;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv_commande;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_MENUS;
        private System.Windows.Forms.TextBox tb_TotalPrice;
        private System.Windows.Forms.Label lb_TotalTTC;
        private System.Windows.Forms.Panel panelClavierNum;
        private System.Windows.Forms.Button bt_NewCmd;
        private System.Windows.Forms.Label lb_HowToUseIt;
        private System.Windows.Forms.Button bt_ClearKeyPressValue;
        private System.Windows.Forms.TextBox tb_KeyPressValue;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        private System.Windows.Forms.Button bt_offert;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Produit_Serveur;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produit_Menu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produit_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produit_Qte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produit_Prix;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produit_IDArticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produit_IDMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produit_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produit_Gratuit;
    }
}