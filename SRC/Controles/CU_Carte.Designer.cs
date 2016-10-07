namespace MinutPapillon
{
    partial class CU_Carte
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
            this.components = new System.ComponentModel.Container();
            this.gb_GestionCarte = new System.Windows.Forms.GroupBox();
            this.la_ItemName = new System.Windows.Forms.Label();
            this.tb_ItemQuantity = new System.Windows.Forms.TextBox();
            this.la_ItemType = new System.Windows.Forms.Label();
            this.la_ItemDescription = new System.Windows.Forms.Label();
            this.bt_load = new System.Windows.Forms.Button();
            this.tb_ItemInfo = new System.Windows.Forms.TextBox();
            this.cob_ItemType = new System.Windows.Forms.ComboBox();
            this.cob_ItemTVA = new System.Windows.Forms.ComboBox();
            this.bt_ItemModif = new System.Windows.Forms.Button();
            this.bt_ItemAdd = new System.Windows.Forms.Button();
            this.la_ItemPrice = new System.Windows.Forms.Label();
            this.pic_ItemPhoto = new System.Windows.Forms.PictureBox();
            this.cb_ItemSup = new System.Windows.Forms.CheckBox();
            this.cb_ItemPref = new System.Windows.Forms.CheckBox();
            this.cb_ItemAlcool = new System.Windows.Forms.CheckBox();
            this.tb_ItemPrice = new System.Windows.Forms.TextBox();
            this.tb_ItemName = new System.Windows.Forms.TextBox();
            this.cb_ItemDispo = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gb_GestionCarte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ItemPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_GestionCarte
            // 
            this.gb_GestionCarte.BackColor = System.Drawing.Color.Transparent;
            this.gb_GestionCarte.Controls.Add(this.la_ItemName);
            this.gb_GestionCarte.Controls.Add(this.tb_ItemQuantity);
            this.gb_GestionCarte.Controls.Add(this.la_ItemType);
            this.gb_GestionCarte.Controls.Add(this.la_ItemDescription);
            this.gb_GestionCarte.Controls.Add(this.bt_load);
            this.gb_GestionCarte.Controls.Add(this.tb_ItemInfo);
            this.gb_GestionCarte.Controls.Add(this.cob_ItemType);
            this.gb_GestionCarte.Controls.Add(this.cob_ItemTVA);
            this.gb_GestionCarte.Controls.Add(this.bt_ItemModif);
            this.gb_GestionCarte.Controls.Add(this.bt_ItemAdd);
            this.gb_GestionCarte.Controls.Add(this.la_ItemPrice);
            this.gb_GestionCarte.Controls.Add(this.pic_ItemPhoto);
            this.gb_GestionCarte.Controls.Add(this.cb_ItemSup);
            this.gb_GestionCarte.Controls.Add(this.cb_ItemPref);
            this.gb_GestionCarte.Controls.Add(this.cb_ItemAlcool);
            this.gb_GestionCarte.Controls.Add(this.tb_ItemPrice);
            this.gb_GestionCarte.Controls.Add(this.tb_ItemName);
            this.gb_GestionCarte.Controls.Add(this.cb_ItemDispo);
            this.gb_GestionCarte.ForeColor = System.Drawing.Color.White;
            this.gb_GestionCarte.Location = new System.Drawing.Point(10, 56);
            this.gb_GestionCarte.Name = "gb_GestionCarte";
            this.gb_GestionCarte.Size = new System.Drawing.Size(250, 286);
            this.gb_GestionCarte.TabIndex = 20;
            this.gb_GestionCarte.TabStop = false;
            this.gb_GestionCarte.Text = "Gestion de la carte";
            // 
            // la_ItemName
            // 
            this.la_ItemName.AutoSize = true;
            this.la_ItemName.Location = new System.Drawing.Point(3, 16);
            this.la_ItemName.Name = "la_ItemName";
            this.la_ItemName.Size = new System.Drawing.Size(88, 13);
            this.la_ItemName.TabIndex = 20;
            this.la_ItemName.Text = "Nom de l\'article : ";
            // 
            // tb_ItemQuantity
            // 
            this.tb_ItemQuantity.ForeColor = System.Drawing.Color.Gray;
            this.tb_ItemQuantity.Location = new System.Drawing.Point(108, 187);
            this.tb_ItemQuantity.Name = "tb_ItemQuantity";
            this.tb_ItemQuantity.Size = new System.Drawing.Size(45, 20);
            this.tb_ItemQuantity.TabIndex = 7;
            this.tb_ItemQuantity.Text = "Qte stock";
            this.tb_ItemQuantity.TextChanged += new System.EventHandler(this.XSS_Numerique);
            this.tb_ItemQuantity.Enter += new System.EventHandler(this.tb_ItemQuantity_Enter);
            this.tb_ItemQuantity.Leave += new System.EventHandler(this.tb_ItemQuantity_Leave);
            // 
            // la_ItemType
            // 
            this.la_ItemType.AutoSize = true;
            this.la_ItemType.Location = new System.Drawing.Point(3, 55);
            this.la_ItemType.Name = "la_ItemType";
            this.la_ItemType.Size = new System.Drawing.Size(149, 13);
            this.la_ItemType.TabIndex = 19;
            this.la_ItemType.Text = "Type de produit (viande, etc) :";
            // 
            // la_ItemDescription
            // 
            this.la_ItemDescription.AutoSize = true;
            this.la_ItemDescription.Location = new System.Drawing.Point(6, 95);
            this.la_ItemDescription.Name = "la_ItemDescription";
            this.la_ItemDescription.Size = new System.Drawing.Size(154, 13);
            this.la_ItemDescription.TabIndex = 18;
            this.la_ItemDescription.Text = "Brêve description (format, etc) :";
            // 
            // bt_load
            // 
            this.bt_load.BackColor = System.Drawing.Color.Transparent;
            this.bt_load.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_load.ForeColor = System.Drawing.Color.Black;
            this.bt_load.Location = new System.Drawing.Point(169, 16);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(75, 50);
            this.bt_load.TabIndex = 11;
            this.bt_load.Text = "IMPORTER DONNEES";
            this.bt_load.UseVisualStyleBackColor = false;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            // 
            // tb_ItemInfo
            // 
            this.tb_ItemInfo.ForeColor = System.Drawing.Color.Gray;
            this.tb_ItemInfo.Location = new System.Drawing.Point(6, 111);
            this.tb_ItemInfo.Name = "tb_ItemInfo";
            this.tb_ItemInfo.Size = new System.Drawing.Size(157, 20);
            this.tb_ItemInfo.TabIndex = 3;
            this.tb_ItemInfo.Text = "Format, Description, ...";
            this.tb_ItemInfo.TextChanged += new System.EventHandler(this.XSS_AlphaNum);
            this.tb_ItemInfo.Enter += new System.EventHandler(this.tb_ItemInfo_Enter);
            this.tb_ItemInfo.Leave += new System.EventHandler(this.tb_ItemInfo_Leave);
            // 
            // cob_ItemType
            // 
            this.cob_ItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_ItemType.FormattingEnabled = true;
            this.cob_ItemType.Location = new System.Drawing.Point(6, 71);
            this.cob_ItemType.Name = "cob_ItemType";
            this.cob_ItemType.Size = new System.Drawing.Size(157, 21);
            this.cob_ItemType.TabIndex = 2;
            // 
            // cob_ItemTVA
            // 
            this.cob_ItemTVA.FormattingEnabled = true;
            this.cob_ItemTVA.Location = new System.Drawing.Point(96, 150);
            this.cob_ItemTVA.Name = "cob_ItemTVA";
            this.cob_ItemTVA.Size = new System.Drawing.Size(67, 21);
            this.cob_ItemTVA.TabIndex = 5;
            this.cob_ItemTVA.Text = "TVA";
            // 
            // bt_ItemModif
            // 
            this.bt_ItemModif.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_ItemModif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ItemModif.Enabled = false;
            this.bt_ItemModif.ForeColor = System.Drawing.Color.Black;
            this.bt_ItemModif.Location = new System.Drawing.Point(169, 125);
            this.bt_ItemModif.Name = "bt_ItemModif";
            this.bt_ItemModif.Size = new System.Drawing.Size(75, 50);
            this.bt_ItemModif.TabIndex = 13;
            this.bt_ItemModif.Text = "MODIFIER";
            this.bt_ItemModif.UseVisualStyleBackColor = true;
            this.bt_ItemModif.Click += new System.EventHandler(this.bt_ItemModif_Click);
            // 
            // bt_ItemAdd
            // 
            this.bt_ItemAdd.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_ItemAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ItemAdd.ForeColor = System.Drawing.Color.Black;
            this.bt_ItemAdd.Location = new System.Drawing.Point(169, 69);
            this.bt_ItemAdd.Name = "bt_ItemAdd";
            this.bt_ItemAdd.Size = new System.Drawing.Size(75, 50);
            this.bt_ItemAdd.TabIndex = 12;
            this.bt_ItemAdd.Text = "AJOUTER";
            this.bt_ItemAdd.UseVisualStyleBackColor = true;
            this.bt_ItemAdd.Click += new System.EventHandler(this.bt_ItemAdd_Click);
            // 
            // la_ItemPrice
            // 
            this.la_ItemPrice.AutoSize = true;
            this.la_ItemPrice.Location = new System.Drawing.Point(6, 134);
            this.la_ItemPrice.Name = "la_ItemPrice";
            this.la_ItemPrice.Size = new System.Drawing.Size(135, 13);
            this.la_ItemPrice.TabIndex = 8;
            this.la_ItemPrice.Text = "Prix unitaire HT à la vente :";
            // 
            // pic_ItemPhoto
            // 
            this.pic_ItemPhoto.BackgroundImage = global::MinutPapillon.Properties.Resources.BGPatternGray;
            this.pic_ItemPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_ItemPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_ItemPhoto.Location = new System.Drawing.Point(159, 187);
            this.pic_ItemPhoto.Name = "pic_ItemPhoto";
            this.pic_ItemPhoto.Size = new System.Drawing.Size(85, 85);
            this.pic_ItemPhoto.TabIndex = 7;
            this.pic_ItemPhoto.TabStop = false;
            this.pic_ItemPhoto.Click += new System.EventHandler(this.pic_ItemPhoto_Click);
            // 
            // cb_ItemSup
            // 
            this.cb_ItemSup.AutoSize = true;
            this.cb_ItemSup.Location = new System.Drawing.Point(9, 233);
            this.cb_ItemSup.Name = "cb_ItemSup";
            this.cb_ItemSup.Size = new System.Drawing.Size(108, 17);
            this.cb_ItemSup.TabIndex = 9;
            this.cb_ItemSup.Text = "SUPPLEMENT ?";
            this.cb_ItemSup.UseVisualStyleBackColor = true;
            // 
            // cb_ItemPref
            // 
            this.cb_ItemPref.AutoSize = true;
            this.cb_ItemPref.Location = new System.Drawing.Point(8, 256);
            this.cb_ItemPref.Name = "cb_ItemPref";
            this.cb_ItemPref.Size = new System.Drawing.Size(107, 17);
            this.cb_ItemPref.TabIndex = 10;
            this.cb_ItemPref.Text = "PREFERENCE ?";
            this.cb_ItemPref.UseVisualStyleBackColor = true;
            // 
            // cb_ItemAlcool
            // 
            this.cb_ItemAlcool.AutoSize = true;
            this.cb_ItemAlcool.Location = new System.Drawing.Point(9, 210);
            this.cb_ItemAlcool.Name = "cb_ItemAlcool";
            this.cb_ItemAlcool.Size = new System.Drawing.Size(94, 17);
            this.cb_ItemAlcool.TabIndex = 8;
            this.cb_ItemAlcool.Text = "ALCOOLISE ?";
            this.cb_ItemAlcool.UseVisualStyleBackColor = true;
            // 
            // tb_ItemPrice
            // 
            this.tb_ItemPrice.ForeColor = System.Drawing.Color.Gray;
            this.tb_ItemPrice.Location = new System.Drawing.Point(6, 150);
            this.tb_ItemPrice.Name = "tb_ItemPrice";
            this.tb_ItemPrice.Size = new System.Drawing.Size(88, 20);
            this.tb_ItemPrice.TabIndex = 4;
            this.tb_ItemPrice.Text = "Prix";
            this.tb_ItemPrice.TextChanged += new System.EventHandler(this.XSS_Float);
            this.tb_ItemPrice.Enter += new System.EventHandler(this.tb_ItemPrice_Enter);
            this.tb_ItemPrice.Leave += new System.EventHandler(this.tb_ItemPrice_Leave);
            // 
            // tb_ItemName
            // 
            this.tb_ItemName.ForeColor = System.Drawing.Color.Gray;
            this.tb_ItemName.Location = new System.Drawing.Point(6, 32);
            this.tb_ItemName.Name = "tb_ItemName";
            this.tb_ItemName.Size = new System.Drawing.Size(157, 20);
            this.tb_ItemName.TabIndex = 1;
            this.tb_ItemName.Text = "Nom de l\'article";
            this.tb_ItemName.TextChanged += new System.EventHandler(this.XSS_AlphaNum);
            this.tb_ItemName.Enter += new System.EventHandler(this.tb_ItemName_Enter);
            this.tb_ItemName.Leave += new System.EventHandler(this.tb_ItemName_Leave);
            // 
            // cb_ItemDispo
            // 
            this.cb_ItemDispo.AutoSize = true;
            this.cb_ItemDispo.Location = new System.Drawing.Point(9, 187);
            this.cb_ItemDispo.Name = "cb_ItemDispo";
            this.cb_ItemDispo.Size = new System.Drawing.Size(99, 17);
            this.cb_ItemDispo.TabIndex = 6;
            this.cb_ItemDispo.Text = "DISPONIBLE ?";
            this.cb_ItemDispo.UseVisualStyleBackColor = true;
            // 
            // CU_Carte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_GestionCarte);
            this.MinimumSize = new System.Drawing.Size(270, 350);
            this.Name = "CU_Carte";
            this.Size = new System.Drawing.Size(270, 350);
            this.Load += new System.EventHandler(this.CU_Carte_Load);
            this.gb_GestionCarte.ResumeLayout(false);
            this.gb_GestionCarte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ItemPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_GestionCarte;
        private System.Windows.Forms.CheckBox cb_ItemDispo;
        private System.Windows.Forms.Label la_ItemPrice;
        private System.Windows.Forms.TextBox tb_ItemQuantity;
        private System.Windows.Forms.PictureBox pic_ItemPhoto;
        private System.Windows.Forms.CheckBox cb_ItemSup;
        private System.Windows.Forms.CheckBox cb_ItemPref;
        private System.Windows.Forms.CheckBox cb_ItemAlcool;
        private System.Windows.Forms.TextBox tb_ItemPrice;
        private System.Windows.Forms.TextBox tb_ItemInfo;
        private System.Windows.Forms.TextBox tb_ItemName;
        private System.Windows.Forms.Button bt_ItemModif;
        private System.Windows.Forms.Button bt_ItemAdd;
        private System.Windows.Forms.ComboBox cob_ItemType;
        private System.Windows.Forms.ComboBox cob_ItemTVA;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.Label la_ItemName;
        private System.Windows.Forms.Label la_ItemType;
        private System.Windows.Forms.Label la_ItemDescription;
    }
}
