namespace MinutPapillon
{
    partial class CU_Commande
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
            this.gb_ShowCmdNoClot = new System.Windows.Forms.GroupBox();
            this.cob_NbrCmd = new System.Windows.Forms.ComboBox();
            this.tb_NbrCmd = new System.Windows.Forms.TextBox();
            this.lb_NbrCmd = new System.Windows.Forms.Label();
            this.gb_GestionFac = new System.Windows.Forms.GroupBox();
            this.panelCom = new System.Windows.Forms.Panel();
            this.lb_PrixTCC = new System.Windows.Forms.Label();
            this.tb_NbrMenuDif = new System.Windows.Forms.TextBox();
            this.tb_NbrArts = new System.Windows.Forms.TextBox();
            this.tb_PrixTTC = new System.Windows.Forms.TextBox();
            this.lb_NbrMenuDif = new System.Windows.Forms.Label();
            this.lb_NbrArts = new System.Windows.Forms.Label();
            this.lb_Couverts = new System.Windows.Forms.Label();
            this.lb_Table = new System.Windows.Forms.Label();
            this.tb_Couverts = new System.Windows.Forms.TextBox();
            this.tb_Table = new System.Windows.Forms.TextBox();
            this.lb_FactureMod = new System.Windows.Forms.Label();
            this.lb_NomServeur = new System.Windows.Forms.Label();
            this.cb_FactureClo = new System.Windows.Forms.CheckBox();
            this.cb_FactureVal = new System.Windows.Forms.CheckBox();
            this.lb_FactureSave = new System.Windows.Forms.Label();
            this.lb_par = new System.Windows.Forms.Label();
            this.lb_Facture = new System.Windows.Forms.Label();
            this.tb_Facture = new System.Windows.Forms.TextBox();
            this.panelPic = new System.Windows.Forms.Panel();
            this.bt_Modifier = new System.Windows.Forms.Button();
            this.bt_load = new System.Windows.Forms.Button();
            this.bt_ClotAll = new System.Windows.Forms.Button();
            this.gb_ShowCmdNoClot.SuspendLayout();
            this.gb_GestionFac.SuspendLayout();
            this.panelCom.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_ShowCmdNoClot
            // 
            this.gb_ShowCmdNoClot.BackColor = System.Drawing.Color.Transparent;
            this.gb_ShowCmdNoClot.Controls.Add(this.bt_ClotAll);
            this.gb_ShowCmdNoClot.Controls.Add(this.cob_NbrCmd);
            this.gb_ShowCmdNoClot.Controls.Add(this.tb_NbrCmd);
            this.gb_ShowCmdNoClot.Controls.Add(this.lb_NbrCmd);
            this.gb_ShowCmdNoClot.ForeColor = System.Drawing.Color.White;
            this.gb_ShowCmdNoClot.Location = new System.Drawing.Point(10, 56);
            this.gb_ShowCmdNoClot.Name = "gb_ShowCmdNoClot";
            this.gb_ShowCmdNoClot.Size = new System.Drawing.Size(250, 60);
            this.gb_ShowCmdNoClot.TabIndex = 22;
            this.gb_ShowCmdNoClot.TabStop = false;
            this.gb_ShowCmdNoClot.Text = "Affichage des impayés";
            // 
            // cob_NbrCmd
            // 
            this.cob_NbrCmd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_NbrCmd.FormattingEnabled = true;
            this.cob_NbrCmd.Location = new System.Drawing.Point(57, 31);
            this.cob_NbrCmd.Name = "cob_NbrCmd";
            this.cob_NbrCmd.Size = new System.Drawing.Size(147, 21);
            this.cob_NbrCmd.TabIndex = 2;
            this.cob_NbrCmd.SelectedValueChanged += new System.EventHandler(this.cob_NbrCmd_SelectedValueChanged);
            // 
            // tb_NbrCmd
            // 
            this.tb_NbrCmd.Enabled = false;
            this.tb_NbrCmd.Location = new System.Drawing.Point(9, 32);
            this.tb_NbrCmd.Name = "tb_NbrCmd";
            this.tb_NbrCmd.ReadOnly = true;
            this.tb_NbrCmd.Size = new System.Drawing.Size(42, 20);
            this.tb_NbrCmd.TabIndex = 1;
            this.tb_NbrCmd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_NbrCmd
            // 
            this.lb_NbrCmd.AutoSize = true;
            this.lb_NbrCmd.Location = new System.Drawing.Point(6, 16);
            this.lb_NbrCmd.Name = "lb_NbrCmd";
            this.lb_NbrCmd.Size = new System.Drawing.Size(163, 13);
            this.lb_NbrCmd.TabIndex = 0;
            this.lb_NbrCmd.Text = "Liste des factures non cloturées :";
            // 
            // gb_GestionFac
            // 
            this.gb_GestionFac.BackColor = System.Drawing.Color.Transparent;
            this.gb_GestionFac.Controls.Add(this.panelCom);
            this.gb_GestionFac.Controls.Add(this.lb_Couverts);
            this.gb_GestionFac.Controls.Add(this.lb_Table);
            this.gb_GestionFac.Controls.Add(this.tb_Couverts);
            this.gb_GestionFac.Controls.Add(this.tb_Table);
            this.gb_GestionFac.Controls.Add(this.lb_FactureMod);
            this.gb_GestionFac.Controls.Add(this.bt_Modifier);
            this.gb_GestionFac.Controls.Add(this.lb_NomServeur);
            this.gb_GestionFac.Controls.Add(this.bt_load);
            this.gb_GestionFac.Controls.Add(this.cb_FactureClo);
            this.gb_GestionFac.Controls.Add(this.cb_FactureVal);
            this.gb_GestionFac.Controls.Add(this.lb_FactureSave);
            this.gb_GestionFac.Controls.Add(this.lb_par);
            this.gb_GestionFac.Controls.Add(this.lb_Facture);
            this.gb_GestionFac.Controls.Add(this.tb_Facture);
            this.gb_GestionFac.ForeColor = System.Drawing.Color.White;
            this.gb_GestionFac.Location = new System.Drawing.Point(10, 122);
            this.gb_GestionFac.Name = "gb_GestionFac";
            this.gb_GestionFac.Size = new System.Drawing.Size(250, 225);
            this.gb_GestionFac.TabIndex = 23;
            this.gb_GestionFac.TabStop = false;
            this.gb_GestionFac.Text = "Gestion des commandes";
            // 
            // panelCom
            // 
            this.panelCom.Controls.Add(this.panelPic);
            this.panelCom.Controls.Add(this.lb_PrixTCC);
            this.panelCom.Controls.Add(this.tb_NbrMenuDif);
            this.panelCom.Controls.Add(this.tb_NbrArts);
            this.panelCom.Controls.Add(this.tb_PrixTTC);
            this.panelCom.Controls.Add(this.lb_NbrMenuDif);
            this.panelCom.Controls.Add(this.lb_NbrArts);
            this.panelCom.Location = new System.Drawing.Point(10, 107);
            this.panelCom.Name = "panelCom";
            this.panelCom.Size = new System.Drawing.Size(155, 89);
            this.panelCom.TabIndex = 33;
            // 
            // lb_PrixTCC
            // 
            this.lb_PrixTCC.AutoSize = true;
            this.lb_PrixTCC.Location = new System.Drawing.Point(5, 50);
            this.lb_PrixTCC.Name = "lb_PrixTCC";
            this.lb_PrixTCC.Size = new System.Drawing.Size(108, 13);
            this.lb_PrixTCC.TabIndex = 5;
            this.lb_PrixTCC.Text = "Pour un prix TTC de :";
            // 
            // tb_NbrMenuDif
            // 
            this.tb_NbrMenuDif.Location = new System.Drawing.Point(92, 25);
            this.tb_NbrMenuDif.Name = "tb_NbrMenuDif";
            this.tb_NbrMenuDif.ReadOnly = true;
            this.tb_NbrMenuDif.Size = new System.Drawing.Size(60, 20);
            this.tb_NbrMenuDif.TabIndex = 7;
            this.tb_NbrMenuDif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_NbrArts
            // 
            this.tb_NbrArts.Location = new System.Drawing.Point(92, 3);
            this.tb_NbrArts.Name = "tb_NbrArts";
            this.tb_NbrArts.ReadOnly = true;
            this.tb_NbrArts.Size = new System.Drawing.Size(60, 20);
            this.tb_NbrArts.TabIndex = 6;
            this.tb_NbrArts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_PrixTTC
            // 
            this.tb_PrixTTC.Location = new System.Drawing.Point(5, 65);
            this.tb_PrixTTC.Name = "tb_PrixTTC";
            this.tb_PrixTTC.ReadOnly = true;
            this.tb_PrixTTC.Size = new System.Drawing.Size(103, 20);
            this.tb_PrixTTC.TabIndex = 8;
            this.tb_PrixTTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_NbrMenuDif
            // 
            this.lb_NbrMenuDif.AutoSize = true;
            this.lb_NbrMenuDif.Location = new System.Drawing.Point(1, 28);
            this.lb_NbrMenuDif.Name = "lb_NbrMenuDif";
            this.lb_NbrMenuDif.Size = new System.Drawing.Size(91, 13);
            this.lb_NbrMenuDif.TabIndex = 2;
            this.lb_NbrMenuDif.Text = "Menus differents :";
            // 
            // lb_NbrArts
            // 
            this.lb_NbrArts.AutoSize = true;
            this.lb_NbrArts.Location = new System.Drawing.Point(1, 6);
            this.lb_NbrArts.Name = "lb_NbrArts";
            this.lb_NbrArts.Size = new System.Drawing.Size(94, 13);
            this.lb_NbrArts.TabIndex = 0;
            this.lb_NbrArts.Text = "Nombre d\'articles :";
            // 
            // lb_Couverts
            // 
            this.lb_Couverts.AutoSize = true;
            this.lb_Couverts.Location = new System.Drawing.Point(119, 48);
            this.lb_Couverts.Name = "lb_Couverts";
            this.lb_Couverts.Size = new System.Drawing.Size(75, 13);
            this.lb_Couverts.TabIndex = 32;
            this.lb_Couverts.Text = "Nbr Couverts :";
            // 
            // lb_Table
            // 
            this.lb_Table.AutoSize = true;
            this.lb_Table.Location = new System.Drawing.Point(7, 48);
            this.lb_Table.Name = "lb_Table";
            this.lb_Table.Size = new System.Drawing.Size(55, 13);
            this.lb_Table.TabIndex = 31;
            this.lb_Table.Text = "Table N° :";
            // 
            // tb_Couverts
            // 
            this.tb_Couverts.Location = new System.Drawing.Point(196, 45);
            this.tb_Couverts.Name = "tb_Couverts";
            this.tb_Couverts.Size = new System.Drawing.Size(50, 20);
            this.tb_Couverts.TabIndex = 5;
            this.tb_Couverts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Table
            // 
            this.tb_Table.Location = new System.Drawing.Point(63, 45);
            this.tb_Table.Name = "tb_Table";
            this.tb_Table.Size = new System.Drawing.Size(50, 20);
            this.tb_Table.TabIndex = 4;
            this.tb_Table.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_FactureMod
            // 
            this.lb_FactureMod.AutoSize = true;
            this.lb_FactureMod.ForeColor = System.Drawing.SystemColors.Info;
            this.lb_FactureMod.Location = new System.Drawing.Point(7, 91);
            this.lb_FactureMod.Name = "lb_FactureMod";
            this.lb_FactureMod.Size = new System.Drawing.Size(81, 13);
            this.lb_FactureMod.TabIndex = 28;
            this.lb_FactureMod.Text = "Jamais modifiée";
            // 
            // lb_NomServeur
            // 
            this.lb_NomServeur.AutoSize = true;
            this.lb_NomServeur.Location = new System.Drawing.Point(135, 22);
            this.lb_NomServeur.Name = "lb_NomServeur";
            this.lb_NomServeur.Size = new System.Drawing.Size(106, 13);
            this.lb_NomServeur.TabIndex = 26;
            this.lb_NomServeur.Text = "NOM DU SERVEUR";
            // 
            // cb_FactureClo
            // 
            this.cb_FactureClo.AutoSize = true;
            this.cb_FactureClo.Enabled = false;
            this.cb_FactureClo.Location = new System.Drawing.Point(94, 202);
            this.cb_FactureClo.Name = "cb_FactureClo";
            this.cb_FactureClo.Size = new System.Drawing.Size(65, 17);
            this.cb_FactureClo.TabIndex = 9;
            this.cb_FactureClo.Text = "Cloturée";
            this.cb_FactureClo.UseVisualStyleBackColor = true;
            // 
            // cb_FactureVal
            // 
            this.cb_FactureVal.AutoSize = true;
            this.cb_FactureVal.Enabled = false;
            this.cb_FactureVal.Location = new System.Drawing.Point(15, 202);
            this.cb_FactureVal.Name = "cb_FactureVal";
            this.cb_FactureVal.Size = new System.Drawing.Size(61, 17);
            this.cb_FactureVal.TabIndex = 9;
            this.cb_FactureVal.Text = "Validée";
            this.cb_FactureVal.UseVisualStyleBackColor = true;
            // 
            // lb_FactureSave
            // 
            this.lb_FactureSave.AutoSize = true;
            this.lb_FactureSave.Location = new System.Drawing.Point(7, 71);
            this.lb_FactureSave.Name = "lb_FactureSave";
            this.lb_FactureSave.Size = new System.Drawing.Size(197, 13);
            this.lb_FactureSave.TabIndex = 21;
            this.lb_FactureSave.Text = "enregistrée le 00 / 00 / 0000 à 00:00:00";
            // 
            // lb_par
            // 
            this.lb_par.AutoSize = true;
            this.lb_par.Location = new System.Drawing.Point(116, 22);
            this.lb_par.Name = "lb_par";
            this.lb_par.Size = new System.Drawing.Size(22, 13);
            this.lb_par.TabIndex = 20;
            this.lb_par.Text = "par";
            // 
            // lb_Facture
            // 
            this.lb_Facture.AutoSize = true;
            this.lb_Facture.Location = new System.Drawing.Point(6, 22);
            this.lb_Facture.Name = "lb_Facture";
            this.lb_Facture.Size = new System.Drawing.Size(56, 13);
            this.lb_Facture.TabIndex = 19;
            this.lb_Facture.Text = "Facture n°";
            // 
            // tb_Facture
            // 
            this.tb_Facture.Enabled = false;
            this.tb_Facture.Location = new System.Drawing.Point(63, 19);
            this.tb_Facture.Name = "tb_Facture";
            this.tb_Facture.ReadOnly = true;
            this.tb_Facture.Size = new System.Drawing.Size(50, 20);
            this.tb_Facture.TabIndex = 3;
            this.tb_Facture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelPic
            // 
            this.panelPic.BackgroundImage = global::MinutPapillon.Properties.Resources.money;
            this.panelPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelPic.Location = new System.Drawing.Point(112, 51);
            this.panelPic.Name = "panelPic";
            this.panelPic.Size = new System.Drawing.Size(37, 34);
            this.panelPic.TabIndex = 29;
            this.panelPic.Click += new System.EventHandler(this.panel2_Click);
            // 
            // bt_Modifier
            // 
            this.bt_Modifier.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_Modifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Modifier.Enabled = false;
            this.bt_Modifier.ForeColor = System.Drawing.Color.Black;
            this.bt_Modifier.Location = new System.Drawing.Point(171, 169);
            this.bt_Modifier.Name = "bt_Modifier";
            this.bt_Modifier.Size = new System.Drawing.Size(75, 50);
            this.bt_Modifier.TabIndex = 14;
            this.bt_Modifier.Text = "MODIFIER";
            this.bt_Modifier.UseVisualStyleBackColor = true;
            this.bt_Modifier.Click += new System.EventHandler(this.bt_Modifier_Click);
            // 
            // bt_load
            // 
            this.bt_load.BackColor = System.Drawing.Color.Transparent;
            this.bt_load.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_load.ForeColor = System.Drawing.Color.Black;
            this.bt_load.Location = new System.Drawing.Point(171, 113);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(75, 50);
            this.bt_load.TabIndex = 17;
            this.bt_load.Text = "IMPORTER DONNEES";
            this.bt_load.UseVisualStyleBackColor = false;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            // 
            // bt_ClotAll
            // 
            this.bt_ClotAll.BackgroundImage = global::MinutPapillon.Properties.Resources.ok;
            this.bt_ClotAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ClotAll.FlatAppearance.BorderSize = 0;
            this.bt_ClotAll.Location = new System.Drawing.Point(210, 16);
            this.bt_ClotAll.Name = "bt_ClotAll";
            this.bt_ClotAll.Size = new System.Drawing.Size(31, 36);
            this.bt_ClotAll.TabIndex = 3;
            this.bt_ClotAll.UseVisualStyleBackColor = true;
            this.bt_ClotAll.Click += new System.EventHandler(this.bt_ClotAll_Click);
            // 
            // CU_Commande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_GestionFac);
            this.Controls.Add(this.gb_ShowCmdNoClot);
            this.Name = "CU_Commande";
            this.Size = new System.Drawing.Size(270, 350);
            this.Load += new System.EventHandler(this.CU_Commande_Load);
            this.gb_ShowCmdNoClot.ResumeLayout(false);
            this.gb_ShowCmdNoClot.PerformLayout();
            this.gb_GestionFac.ResumeLayout(false);
            this.gb_GestionFac.PerformLayout();
            this.panelCom.ResumeLayout(false);
            this.panelCom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_ShowCmdNoClot;
        private System.Windows.Forms.ComboBox cob_NbrCmd;
        private System.Windows.Forms.TextBox tb_NbrCmd;
        private System.Windows.Forms.Label lb_NbrCmd;
        private System.Windows.Forms.GroupBox gb_GestionFac;
        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.Button bt_Modifier;
        private System.Windows.Forms.CheckBox cb_FactureClo;
        private System.Windows.Forms.CheckBox cb_FactureVal;
        private System.Windows.Forms.Label lb_FactureSave;
        private System.Windows.Forms.Label lb_par;
        private System.Windows.Forms.Label lb_Facture;
        private System.Windows.Forms.TextBox tb_Facture;
        private System.Windows.Forms.Label lb_NomServeur;
        private System.Windows.Forms.Panel panelPic;
        private System.Windows.Forms.Panel panelCom;
        private System.Windows.Forms.Label lb_PrixTCC;
        private System.Windows.Forms.TextBox tb_NbrMenuDif;
        private System.Windows.Forms.TextBox tb_NbrArts;
        private System.Windows.Forms.TextBox tb_PrixTTC;
        private System.Windows.Forms.Label lb_NbrMenuDif;
        private System.Windows.Forms.Label lb_NbrArts;
        private System.Windows.Forms.Label lb_Couverts;
        private System.Windows.Forms.Label lb_Table;
        private System.Windows.Forms.TextBox tb_Couverts;
        private System.Windows.Forms.TextBox tb_Table;
        private System.Windows.Forms.Label lb_FactureMod;
        private System.Windows.Forms.Button bt_ClotAll;
    }
}
