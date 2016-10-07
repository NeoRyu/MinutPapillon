namespace MinutPapillon
{
    partial class Form_administration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_administration));
            this.ms_Navigation = new System.Windows.Forms.MenuStrip();
            this.ts_m_Fichier = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_sm_Deconnexion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_sm_Quitter = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_m_User = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_m_Article = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_m_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_m_Stocks = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_m_Commande = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_m_Stats = new System.Windows.Forms.ToolStripMenuItem();
            this.globalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serveursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_m_Config = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_sm_ColorBt = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_sm_ModFacture = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_m_Aide = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_sm_About = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.gb_panel = new System.Windows.Forms.GroupBox();
            this.bt_InterfaceServ = new System.Windows.Forms.Button();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.bt_Deconnection = new System.Windows.Forms.Button();
            this.lb_NameAdmin = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_EasterEgg = new System.Windows.Forms.Label();
            this.manuelDutilisationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partieAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partieServeurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_Navigation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBoxConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ms_Navigation
            // 
            this.ms_Navigation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ms_Navigation.BackgroundImage")));
            this.ms_Navigation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ms_Navigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_m_Fichier,
            this.ts_m_User,
            this.ts_m_Article,
            this.ts_m_Menu,
            this.ts_m_Stocks,
            this.ts_m_Commande,
            this.ts_m_Stats,
            this.ts_m_Config,
            this.ts_m_Aide});
            this.ms_Navigation.Location = new System.Drawing.Point(0, 0);
            this.ms_Navigation.Name = "ms_Navigation";
            this.ms_Navigation.Padding = new System.Windows.Forms.Padding(6, 4, 0, 4);
            this.ms_Navigation.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ms_Navigation.Size = new System.Drawing.Size(714, 27);
            this.ms_Navigation.TabIndex = 20;
            this.ms_Navigation.Text = "menuStrip1";
            // 
            // ts_m_Fichier
            // 
            this.ts_m_Fichier.BackColor = System.Drawing.Color.Transparent;
            this.ts_m_Fichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_sm_Deconnexion,
            this.toolStripSeparator1,
            this.ts_sm_Quitter});
            this.ts_m_Fichier.ForeColor = System.Drawing.Color.White;
            this.ts_m_Fichier.Name = "ts_m_Fichier";
            this.ts_m_Fichier.Size = new System.Drawing.Size(54, 19);
            this.ts_m_Fichier.Text = "&Fichier";
            // 
            // ts_sm_Deconnexion
            // 
            this.ts_sm_Deconnexion.Name = "ts_sm_Deconnexion";
            this.ts_sm_Deconnexion.Size = new System.Drawing.Size(143, 22);
            this.ts_sm_Deconnexion.Text = "Déconnexion";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // ts_sm_Quitter
            // 
            this.ts_sm_Quitter.Name = "ts_sm_Quitter";
            this.ts_sm_Quitter.Size = new System.Drawing.Size(143, 22);
            this.ts_sm_Quitter.Text = "Quitter";
            // 
            // ts_m_User
            // 
            this.ts_m_User.BackColor = System.Drawing.Color.Transparent;
            this.ts_m_User.ForeColor = System.Drawing.Color.White;
            this.ts_m_User.Name = "ts_m_User";
            this.ts_m_User.Size = new System.Drawing.Size(77, 19);
            this.ts_m_User.Text = "Utilisateurs";
            this.ts_m_User.Click += new System.EventHandler(this.ts_m_User_Click);
            // 
            // ts_m_Article
            // 
            this.ts_m_Article.BackColor = System.Drawing.Color.Transparent;
            this.ts_m_Article.ForeColor = System.Drawing.Color.White;
            this.ts_m_Article.Name = "ts_m_Article";
            this.ts_m_Article.Size = new System.Drawing.Size(58, 19);
            this.ts_m_Article.Text = "Articles";
            this.ts_m_Article.Click += new System.EventHandler(this.ts_m_Article_Click);
            // 
            // ts_m_Menu
            // 
            this.ts_m_Menu.BackColor = System.Drawing.Color.Transparent;
            this.ts_m_Menu.ForeColor = System.Drawing.Color.White;
            this.ts_m_Menu.Name = "ts_m_Menu";
            this.ts_m_Menu.Size = new System.Drawing.Size(55, 19);
            this.ts_m_Menu.Text = "Menus";
            this.ts_m_Menu.Click += new System.EventHandler(this.ts_m_Menu_Click);
            // 
            // ts_m_Stocks
            // 
            this.ts_m_Stocks.BackColor = System.Drawing.Color.Transparent;
            this.ts_m_Stocks.ForeColor = System.Drawing.Color.White;
            this.ts_m_Stocks.Name = "ts_m_Stocks";
            this.ts_m_Stocks.Size = new System.Drawing.Size(53, 19);
            this.ts_m_Stocks.Text = "Stocks";
            this.ts_m_Stocks.Click += new System.EventHandler(this.ts_m_Stocks_Click);
            // 
            // ts_m_Commande
            // 
            this.ts_m_Commande.BackColor = System.Drawing.Color.Transparent;
            this.ts_m_Commande.ForeColor = System.Drawing.Color.White;
            this.ts_m_Commande.Name = "ts_m_Commande";
            this.ts_m_Commande.Size = new System.Drawing.Size(87, 19);
            this.ts_m_Commande.Text = "Commandes";
            this.ts_m_Commande.Click += new System.EventHandler(this.ts_m_Commande_Click);
            // 
            // ts_m_Stats
            // 
            this.ts_m_Stats.BackColor = System.Drawing.Color.Transparent;
            this.ts_m_Stats.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.globalesToolStripMenuItem,
            this.ventesToolStripMenuItem,
            this.serveursToolStripMenuItem});
            this.ts_m_Stats.ForeColor = System.Drawing.Color.White;
            this.ts_m_Stats.Name = "ts_m_Stats";
            this.ts_m_Stats.Size = new System.Drawing.Size(79, 19);
            this.ts_m_Stats.Text = "Statistiques";
            // 
            // globalesToolStripMenuItem
            // 
            this.globalesToolStripMenuItem.Name = "globalesToolStripMenuItem";
            this.globalesToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.globalesToolStripMenuItem.Text = "Globales";
            this.globalesToolStripMenuItem.Click += new System.EventHandler(this.ts_m_Stats_Click);
            // 
            // ventesToolStripMenuItem
            // 
            this.ventesToolStripMenuItem.Name = "ventesToolStripMenuItem";
            this.ventesToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.ventesToolStripMenuItem.Text = "Ventes";
            this.ventesToolStripMenuItem.Click += new System.EventHandler(this.ts_m_Stats_Click);
            // 
            // serveursToolStripMenuItem
            // 
            this.serveursToolStripMenuItem.Name = "serveursToolStripMenuItem";
            this.serveursToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.serveursToolStripMenuItem.Text = "Serveurs";
            this.serveursToolStripMenuItem.Click += new System.EventHandler(this.ts_m_Stats_Click);
            // 
            // ts_m_Config
            // 
            this.ts_m_Config.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_sm_ColorBt,
            this.ts_sm_ModFacture});
            this.ts_m_Config.ForeColor = System.Drawing.Color.White;
            this.ts_m_Config.Name = "ts_m_Config";
            this.ts_m_Config.Size = new System.Drawing.Size(93, 19);
            this.ts_m_Config.Text = "Configuration";
            // 
            // ts_sm_ColorBt
            // 
            this.ts_sm_ColorBt.Name = "ts_sm_ColorBt";
            this.ts_sm_ColorBt.Size = new System.Drawing.Size(206, 22);
            this.ts_sm_ColorBt.Text = "Colorisation des Boutons";
            this.ts_sm_ColorBt.Click += new System.EventHandler(this.ts_sm_ColorBt_Click);
            // 
            // ts_sm_ModFacture
            // 
            this.ts_sm_ModFacture.Name = "ts_sm_ModFacture";
            this.ts_sm_ModFacture.Size = new System.Drawing.Size(206, 22);
            this.ts_sm_ModFacture.Text = "Modèle de Facture";
            this.ts_sm_ModFacture.Click += new System.EventHandler(this.ts_sm_ModFacture_Click);
            // 
            // ts_m_Aide
            // 
            this.ts_m_Aide.BackColor = System.Drawing.Color.Transparent;
            this.ts_m_Aide.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_sm_About,
            this.manuelDutilisationToolStripMenuItem});
            this.ts_m_Aide.ForeColor = System.Drawing.Color.White;
            this.ts_m_Aide.Name = "ts_m_Aide";
            this.ts_m_Aide.Size = new System.Drawing.Size(43, 19);
            this.ts_m_Aide.Text = "Aide";
            // 
            // ts_sm_About
            // 
            this.ts_sm_About.Name = "ts_sm_About";
            this.ts_sm_About.Size = new System.Drawing.Size(179, 22);
            this.ts_sm_About.Text = "À propos de...";
            this.ts_sm_About.Click += new System.EventHandler(this.ts_sm_About_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Location = new System.Drawing.Point(286, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 399);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 9);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(416, 387);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // gb_panel
            // 
            this.gb_panel.BackColor = System.Drawing.Color.Transparent;
            this.gb_panel.Location = new System.Drawing.Point(12, 70);
            this.gb_panel.Name = "gb_panel";
            this.gb_panel.Size = new System.Drawing.Size(268, 359);
            this.gb_panel.TabIndex = 23;
            this.gb_panel.TabStop = false;
            // 
            // bt_InterfaceServ
            // 
            this.bt_InterfaceServ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_InterfaceServ.AutoSize = true;
            this.bt_InterfaceServ.BackColor = System.Drawing.Color.Transparent;
            this.bt_InterfaceServ.BackgroundImage = global::MinutPapillon.Properties.Resources.interfaceserveur_off;
            this.bt_InterfaceServ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_InterfaceServ.FlatAppearance.BorderSize = 0;
            this.bt_InterfaceServ.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_InterfaceServ.ForeColor = System.Drawing.Color.Black;
            this.bt_InterfaceServ.Location = new System.Drawing.Point(202, 9);
            this.bt_InterfaceServ.Name = "bt_InterfaceServ";
            this.bt_InterfaceServ.Size = new System.Drawing.Size(30, 30);
            this.bt_InterfaceServ.TabIndex = 0;
            this.bt_InterfaceServ.UseVisualStyleBackColor = false;
            this.bt_InterfaceServ.Click += new System.EventHandler(this.bt_InterfaceServ_Click);
            this.bt_InterfaceServ.MouseLeave += new System.EventHandler(this.bt_InterfaceServ_MouseLeave);
            this.bt_InterfaceServ.MouseHover += new System.EventHandler(this.bt_InterfaceServ_MouseHover);
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxConnection.Controls.Add(this.bt_InterfaceServ);
            this.groupBoxConnection.Controls.Add(this.bt_Deconnection);
            this.groupBoxConnection.Controls.Add(this.lb_NameAdmin);
            this.groupBoxConnection.ForeColor = System.Drawing.Color.White;
            this.groupBoxConnection.Location = new System.Drawing.Point(12, 30);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(268, 42);
            this.groupBoxConnection.TabIndex = 45;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Bienvenue";
            // 
            // bt_Deconnection
            // 
            this.bt_Deconnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Deconnection.AutoSize = true;
            this.bt_Deconnection.BackgroundImage = global::MinutPapillon.Properties.Resources.logout_off;
            this.bt_Deconnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Deconnection.FlatAppearance.BorderSize = 0;
            this.bt_Deconnection.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Deconnection.ForeColor = System.Drawing.Color.Black;
            this.bt_Deconnection.Location = new System.Drawing.Point(234, 9);
            this.bt_Deconnection.Name = "bt_Deconnection";
            this.bt_Deconnection.Size = new System.Drawing.Size(30, 30);
            this.bt_Deconnection.TabIndex = 1;
            this.bt_Deconnection.UseVisualStyleBackColor = true;
            this.bt_Deconnection.Click += new System.EventHandler(this.bt_Deconnection_Click);
            this.bt_Deconnection.MouseLeave += new System.EventHandler(this.bt_Deconnection_MouseLeave);
            this.bt_Deconnection.MouseHover += new System.EventHandler(this.bt_Deconnection_MouseHover);
            // 
            // lb_NameAdmin
            // 
            this.lb_NameAdmin.AutoSize = true;
            this.lb_NameAdmin.BackColor = System.Drawing.Color.Transparent;
            this.lb_NameAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NameAdmin.ForeColor = System.Drawing.Color.White;
            this.lb_NameAdmin.Location = new System.Drawing.Point(6, 19);
            this.lb_NameAdmin.Name = "lb_NameAdmin";
            this.lb_NameAdmin.Size = new System.Drawing.Size(93, 13);
            this.lb_NameAdmin.TabIndex = 11;
            this.lb_NameAdmin.Text = "Nom et Prénom";
            // 
            // toolTip1
            // 
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_Draw);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 431);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 2);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lb_EasterEgg
            // 
            this.lb_EasterEgg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_EasterEgg.AutoSize = true;
            this.lb_EasterEgg.BackColor = System.Drawing.Color.Transparent;
            this.lb_EasterEgg.ForeColor = System.Drawing.Color.DimGray;
            this.lb_EasterEgg.Location = new System.Drawing.Point(701, 7);
            this.lb_EasterEgg.Name = "lb_EasterEgg";
            this.lb_EasterEgg.Size = new System.Drawing.Size(13, 13);
            this.lb_EasterEgg.TabIndex = 47;
            this.lb_EasterEgg.Text = ":)";
            this.lb_EasterEgg.Visible = false;
            this.lb_EasterEgg.Click += new System.EventHandler(this.lb_EasterEgg_Click);
            // 
            // manuelDutilisationToolStripMenuItem
            // 
            this.manuelDutilisationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.partieAdminToolStripMenuItem,
            this.partieServeurToolStripMenuItem});
            this.manuelDutilisationToolStripMenuItem.Name = "manuelDutilisationToolStripMenuItem";
            this.manuelDutilisationToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.manuelDutilisationToolStripMenuItem.Text = "Manuel d\'utilisation";
            // 
            // partieAdminToolStripMenuItem
            // 
            this.partieAdminToolStripMenuItem.Name = "partieAdminToolStripMenuItem";
            this.partieAdminToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.partieAdminToolStripMenuItem.Text = "Partie Admin";
            this.partieAdminToolStripMenuItem.Click += new System.EventHandler(this.partieAdminToolStripMenuItem_Click);
            // 
            // partieServeurToolStripMenuItem
            // 
            this.partieServeurToolStripMenuItem.Name = "partieServeurToolStripMenuItem";
            this.partieServeurToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.partieServeurToolStripMenuItem.Text = "Partie Serveur";
            this.partieServeurToolStripMenuItem.Click += new System.EventHandler(this.partieServeurToolStripMenuItem_Click);
            // 
            // Form_administration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MinutPapillon.Properties.Resources.BGLuxury;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(714, 441);
            this.Controls.Add(this.lb_EasterEgg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxConnection);
            this.Controls.Add(this.gb_panel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ms_Navigation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(730, 480);
            this.Name = "Form_administration";
            this.Text = "MinutPapillon - Panneau d\'administration";
            this.Load += new System.EventHandler(this.Form_administration_Load);
            this.ms_Navigation.ResumeLayout(false);
            this.ms_Navigation.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms_Navigation;
        private System.Windows.Forms.ToolStripMenuItem ts_m_Fichier;
        private System.Windows.Forms.ToolStripMenuItem ts_sm_Deconnexion;
        private System.Windows.Forms.ToolStripMenuItem ts_sm_Quitter;
        private System.Windows.Forms.ToolStripMenuItem ts_m_Aide;
        private System.Windows.Forms.ToolStripMenuItem ts_sm_About;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox gb_panel;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Button bt_Deconnection;
        private System.Windows.Forms.Button bt_InterfaceServ;
        private System.Windows.Forms.Label lb_NameAdmin;
        private System.Windows.Forms.ToolStripMenuItem ts_m_User;
        private System.Windows.Forms.ToolStripMenuItem ts_m_Article;
        private System.Windows.Forms.ToolStripMenuItem ts_m_Menu;
        private System.Windows.Forms.ToolStripMenuItem ts_m_Stocks;
        private System.Windows.Forms.ToolStripMenuItem ts_m_Commande;
        private System.Windows.Forms.ToolStripMenuItem ts_m_Stats;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ts_m_Config;
        private System.Windows.Forms.ToolStripMenuItem ts_sm_ColorBt;
        private System.Windows.Forms.ToolStripMenuItem ts_sm_ModFacture;
        private System.Windows.Forms.ToolStripMenuItem globalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serveursToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_EasterEgg;
        private System.Windows.Forms.ToolStripMenuItem manuelDutilisationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partieAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partieServeurToolStripMenuItem;
    }
}