namespace MinutPapillon
{
    partial class CU_Menu
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CU_Menu));
            this.gb_GestionMenu = new System.Windows.Forms.GroupBox();
            this.la_dateAjout = new System.Windows.Forms.Label();
            this.dtp_dateAjout = new System.Windows.Forms.DateTimePicker();
            this.cob_menu = new System.Windows.Forms.ComboBox();
            this.cb_disponible = new System.Windows.Forms.CheckBox();
            this.la_prixTTC = new System.Windows.Forms.Label();
            this.tb_prixTTC = new System.Windows.Forms.TextBox();
            this.la_nomMenu = new System.Windows.Forms.Label();
            this.bt_load = new System.Windows.Forms.Button();
            this.bt_ItemModif = new System.Windows.Forms.Button();
            this.bt_ItemAdd = new System.Windows.Forms.Button();
            this.tb_prixArticle = new System.Windows.Forms.TextBox();
            this.cob_selectArticle = new System.Windows.Forms.ComboBox();
            this.gb_compositionMenu = new System.Windows.Forms.GroupBox();
            this.lb_type = new System.Windows.Forms.Label();
            this.bt_ComposerAdd = new System.Windows.Forms.Button();
            this.bt_ComposerSupp = new System.Windows.Forms.Button();
            this.cob_type = new System.Windows.Forms.ComboBox();
            this.cob_selectMenu = new System.Windows.Forms.ComboBox();
            this.gb_GestionMenu.SuspendLayout();
            this.gb_compositionMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_GestionMenu
            // 
            this.gb_GestionMenu.BackColor = System.Drawing.Color.Transparent;
            this.gb_GestionMenu.Controls.Add(this.la_dateAjout);
            this.gb_GestionMenu.Controls.Add(this.dtp_dateAjout);
            this.gb_GestionMenu.Controls.Add(this.cob_menu);
            this.gb_GestionMenu.Controls.Add(this.cb_disponible);
            this.gb_GestionMenu.Controls.Add(this.la_prixTTC);
            this.gb_GestionMenu.Controls.Add(this.tb_prixTTC);
            this.gb_GestionMenu.Controls.Add(this.la_nomMenu);
            this.gb_GestionMenu.Controls.Add(this.bt_load);
            this.gb_GestionMenu.Controls.Add(this.bt_ItemModif);
            this.gb_GestionMenu.Controls.Add(this.bt_ItemAdd);
            this.gb_GestionMenu.ForeColor = System.Drawing.Color.White;
            this.gb_GestionMenu.Location = new System.Drawing.Point(10, 56);
            this.gb_GestionMenu.Name = "gb_GestionMenu";
            this.gb_GestionMenu.Size = new System.Drawing.Size(250, 118);
            this.gb_GestionMenu.TabIndex = 21;
            this.gb_GestionMenu.TabStop = false;
            this.gb_GestionMenu.Text = "Gestion des menus";
            // 
            // la_dateAjout
            // 
            this.la_dateAjout.AutoSize = true;
            this.la_dateAjout.Location = new System.Drawing.Point(6, 92);
            this.la_dateAjout.Name = "la_dateAjout";
            this.la_dateAjout.Size = new System.Drawing.Size(57, 13);
            this.la_dateAjout.TabIndex = 30;
            this.la_dateAjout.Text = "Date Ajout";
            // 
            // dtp_dateAjout
            // 
            this.dtp_dateAjout.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_dateAjout.Location = new System.Drawing.Point(82, 86);
            this.dtp_dateAjout.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtp_dateAjout.Name = "dtp_dateAjout";
            this.dtp_dateAjout.Size = new System.Drawing.Size(86, 20);
            this.dtp_dateAjout.TabIndex = 29;
            // 
            // cob_menu
            // 
            this.cob_menu.FormattingEnabled = true;
            this.cob_menu.Location = new System.Drawing.Point(6, 38);
            this.cob_menu.Name = "cob_menu";
            this.cob_menu.Size = new System.Drawing.Size(162, 21);
            this.cob_menu.TabIndex = 28;
            this.cob_menu.SelectedValueChanged += new System.EventHandler(this.cob_menu_SelectedValueChanged);
            // 
            // cb_disponible
            // 
            this.cb_disponible.AutoSize = true;
            this.cb_disponible.Location = new System.Drawing.Point(93, 20);
            this.cb_disponible.Name = "cb_disponible";
            this.cb_disponible.Size = new System.Drawing.Size(75, 17);
            this.cb_disponible.TabIndex = 22;
            this.cb_disponible.Text = "Disponible";
            this.cb_disponible.UseVisualStyleBackColor = true;
            // 
            // la_prixTTC
            // 
            this.la_prixTTC.AutoSize = true;
            this.la_prixTTC.Location = new System.Drawing.Point(6, 66);
            this.la_prixTTC.Name = "la_prixTTC";
            this.la_prixTTC.Size = new System.Drawing.Size(92, 13);
            this.la_prixTTC.TabIndex = 21;
            this.la_prixTTC.Text = "Prix du menu TTC";
            // 
            // tb_prixTTC
            // 
            this.tb_prixTTC.Location = new System.Drawing.Point(104, 63);
            this.tb_prixTTC.Name = "tb_prixTTC";
            this.tb_prixTTC.Size = new System.Drawing.Size(64, 20);
            this.tb_prixTTC.TabIndex = 20;
            this.tb_prixTTC.TextChanged += new System.EventHandler(this.XSS_Float);
            // 
            // la_nomMenu
            // 
            this.la_nomMenu.AutoSize = true;
            this.la_nomMenu.Location = new System.Drawing.Point(6, 22);
            this.la_nomMenu.Name = "la_nomMenu";
            this.la_nomMenu.Size = new System.Drawing.Size(73, 13);
            this.la_nomMenu.TabIndex = 19;
            this.la_nomMenu.Text = "Nom du menu";
            // 
            // bt_load
            // 
            this.bt_load.BackColor = System.Drawing.Color.Transparent;
            this.bt_load.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_load.ForeColor = System.Drawing.Color.Black;
            this.bt_load.Location = new System.Drawing.Point(173, 11);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(75, 40);
            this.bt_load.TabIndex = 17;
            this.bt_load.Text = "IMPORTER DONNEES";
            this.bt_load.UseVisualStyleBackColor = false;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            // 
            // bt_ItemModif
            // 
            this.bt_ItemModif.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_ItemModif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ItemModif.ForeColor = System.Drawing.Color.Black;
            this.bt_ItemModif.Location = new System.Drawing.Point(173, 82);
            this.bt_ItemModif.Name = "bt_ItemModif";
            this.bt_ItemModif.Size = new System.Drawing.Size(75, 25);
            this.bt_ItemModif.TabIndex = 14;
            this.bt_ItemModif.Text = "MODIFIER";
            this.bt_ItemModif.UseVisualStyleBackColor = true;
            this.bt_ItemModif.Click += new System.EventHandler(this.bt_ItemModif_Click);
            // 
            // bt_ItemAdd
            // 
            this.bt_ItemAdd.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_ItemAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ItemAdd.ForeColor = System.Drawing.Color.Black;
            this.bt_ItemAdd.Location = new System.Drawing.Point(173, 54);
            this.bt_ItemAdd.Name = "bt_ItemAdd";
            this.bt_ItemAdd.Size = new System.Drawing.Size(75, 25);
            this.bt_ItemAdd.TabIndex = 13;
            this.bt_ItemAdd.Text = "AJOUTER";
            this.bt_ItemAdd.UseVisualStyleBackColor = true;
            this.bt_ItemAdd.Click += new System.EventHandler(this.bt_ItemAdd_Click);
            // 
            // tb_prixArticle
            // 
            this.tb_prixArticle.Enabled = false;
            this.tb_prixArticle.Location = new System.Drawing.Point(173, 57);
            this.tb_prixArticle.Name = "tb_prixArticle";
            this.tb_prixArticle.ReadOnly = true;
            this.tb_prixArticle.Size = new System.Drawing.Size(65, 20);
            this.tb_prixArticle.TabIndex = 26;
            this.tb_prixArticle.Text = "prix article";
            this.tb_prixArticle.TextChanged += new System.EventHandler(this.XSS_Float);
            // 
            // cob_selectArticle
            // 
            this.cob_selectArticle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_selectArticle.FormattingEnabled = true;
            this.cob_selectArticle.Location = new System.Drawing.Point(6, 56);
            this.cob_selectArticle.Name = "cob_selectArticle";
            this.cob_selectArticle.Size = new System.Drawing.Size(157, 21);
            this.cob_selectArticle.TabIndex = 27;
            this.cob_selectArticle.SelectedIndexChanged += new System.EventHandler(this.cob_selectArticle_SelectedIndexChanged);
            // 
            // gb_compositionMenu
            // 
            this.gb_compositionMenu.Controls.Add(this.lb_type);
            this.gb_compositionMenu.Controls.Add(this.bt_ComposerAdd);
            this.gb_compositionMenu.Controls.Add(this.bt_ComposerSupp);
            this.gb_compositionMenu.Controls.Add(this.cob_type);
            this.gb_compositionMenu.Controls.Add(this.cob_selectMenu);
            this.gb_compositionMenu.Controls.Add(this.cob_selectArticle);
            this.gb_compositionMenu.Controls.Add(this.tb_prixArticle);
            this.gb_compositionMenu.ForeColor = System.Drawing.Color.White;
            this.gb_compositionMenu.Location = new System.Drawing.Point(10, 202);
            this.gb_compositionMenu.Name = "gb_compositionMenu";
            this.gb_compositionMenu.Size = new System.Drawing.Size(250, 145);
            this.gb_compositionMenu.TabIndex = 28;
            this.gb_compositionMenu.TabStop = false;
            this.gb_compositionMenu.Text = "Composition du menu";
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Location = new System.Drawing.Point(6, 83);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(66, 13);
            this.lb_type.TabIndex = 33;
            this.lb_type.Text = "Type de plat";
            // 
            // bt_ComposerAdd
            // 
            this.bt_ComposerAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_ComposerAdd.BackgroundImage")));
            this.bt_ComposerAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ComposerAdd.Enabled = false;
            this.bt_ComposerAdd.ForeColor = System.Drawing.Color.Black;
            this.bt_ComposerAdd.Location = new System.Drawing.Point(159, 83);
            this.bt_ComposerAdd.Name = "bt_ComposerAdd";
            this.bt_ComposerAdd.Size = new System.Drawing.Size(80, 23);
            this.bt_ComposerAdd.TabIndex = 32;
            this.bt_ComposerAdd.Text = "AJOUTER";
            this.bt_ComposerAdd.UseVisualStyleBackColor = true;
            this.bt_ComposerAdd.Click += new System.EventHandler(this.bt_ComposerAdd_Click);
            // 
            // bt_ComposerSupp
            // 
            this.bt_ComposerSupp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_ComposerSupp.BackgroundImage")));
            this.bt_ComposerSupp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ComposerSupp.Enabled = false;
            this.bt_ComposerSupp.ForeColor = System.Drawing.Color.Black;
            this.bt_ComposerSupp.Location = new System.Drawing.Point(159, 108);
            this.bt_ComposerSupp.Name = "bt_ComposerSupp";
            this.bt_ComposerSupp.Size = new System.Drawing.Size(80, 23);
            this.bt_ComposerSupp.TabIndex = 31;
            this.bt_ComposerSupp.Text = "SUPPRIMER";
            this.bt_ComposerSupp.UseVisualStyleBackColor = true;
            this.bt_ComposerSupp.Click += new System.EventHandler(this.bt_ComposerSupp_Click);
            // 
            // cob_type
            // 
            this.cob_type.AutoCompleteCustomSource.AddRange(new string[] {
            "Entrée",
            "Plat",
            "Dessert"});
            this.cob_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_type.FormattingEnabled = true;
            this.cob_type.Location = new System.Drawing.Point(7, 108);
            this.cob_type.Name = "cob_type";
            this.cob_type.Size = new System.Drawing.Size(146, 21);
            this.cob_type.TabIndex = 30;
            this.cob_type.SelectedIndexChanged += new System.EventHandler(this.cob_type_SelectedIndexChanged);
            // 
            // cob_selectMenu
            // 
            this.cob_selectMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_selectMenu.FormattingEnabled = true;
            this.cob_selectMenu.Location = new System.Drawing.Point(6, 29);
            this.cob_selectMenu.Name = "cob_selectMenu";
            this.cob_selectMenu.Size = new System.Drawing.Size(232, 21);
            this.cob_selectMenu.TabIndex = 29;
            this.cob_selectMenu.SelectedIndexChanged += new System.EventHandler(this.cob_selectMenu_SelectedIndexChanged);
            // 
            // CU_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_compositionMenu);
            this.Controls.Add(this.gb_GestionMenu);
            this.MinimumSize = new System.Drawing.Size(270, 350);
            this.Name = "CU_Menu";
            this.Size = new System.Drawing.Size(270, 350);
            this.Load += new System.EventHandler(this.CU_Menu_Load);
            this.gb_GestionMenu.ResumeLayout(false);
            this.gb_GestionMenu.PerformLayout();
            this.gb_compositionMenu.ResumeLayout(false);
            this.gb_compositionMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_GestionMenu;
        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.Button bt_ItemModif;
        private System.Windows.Forms.Button bt_ItemAdd;
        private System.Windows.Forms.Label la_prixTTC;
        private System.Windows.Forms.TextBox tb_prixTTC;
        private System.Windows.Forms.Label la_nomMenu;
        private System.Windows.Forms.CheckBox cb_disponible;
        private System.Windows.Forms.ComboBox cob_menu;
        private System.Windows.Forms.ComboBox cob_selectArticle;
        private System.Windows.Forms.TextBox tb_prixArticle;
        private System.Windows.Forms.DateTimePicker dtp_dateAjout;
        private System.Windows.Forms.GroupBox gb_compositionMenu;
        private System.Windows.Forms.ComboBox cob_selectMenu;
        private System.Windows.Forms.Button bt_ComposerAdd;
        private System.Windows.Forms.Button bt_ComposerSupp;
        private System.Windows.Forms.ComboBox cob_type;
        private System.Windows.Forms.Label la_dateAjout;
        private System.Windows.Forms.Label lb_type;
    }
}
