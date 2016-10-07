namespace MinutPapillon
{
    partial class CU_Rechercher
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
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.bt_Search = new System.Windows.Forms.Button();
            this.cob_Search = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tb_Search
            // 
            this.tb_Search.Enabled = false;
            this.tb_Search.ForeColor = System.Drawing.Color.Gray;
            this.tb_Search.Location = new System.Drawing.Point(16, 30);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(150, 20);
            this.tb_Search.TabIndex = 3;
            this.tb_Search.Text = "Rechercher le mot/chiffre...";
            this.tb_Search.Click += new System.EventHandler(this.tb_Search_Click);
            this.tb_Search.TextChanged += new System.EventHandler(this.tb_Search_TextChanged);
            this.tb_Search.Enter += new System.EventHandler(this.tb_Search_Enter);
            this.tb_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Search_KeyPress);
            this.tb_Search.Leave += new System.EventHandler(this.tb_Search_Leave);
            // 
            // bt_Search
            // 
            this.bt_Search.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Search.Enabled = false;
            this.bt_Search.Location = new System.Drawing.Point(172, 3);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(88, 47);
            this.bt_Search.TabIndex = 4;
            this.bt_Search.Text = "Lancer la &Recherche";
            this.bt_Search.UseVisualStyleBackColor = true;
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // cob_Search
            // 
            this.cob_Search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Search.FormattingEnabled = true;
            this.cob_Search.Location = new System.Drawing.Point(16, 3);
            this.cob_Search.Name = "cob_Search";
            this.cob_Search.Size = new System.Drawing.Size(150, 21);
            this.cob_Search.TabIndex = 2;
            this.cob_Search.SelectedValueChanged += new System.EventHandler(this.cob_Search_SelectedValueChanged);
            this.cob_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cob_Search_KeyPress);
            // 
            // CU_Rechercher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cob_Search);
            this.Controls.Add(this.tb_Search);
            this.Controls.Add(this.bt_Search);
            this.Name = "CU_Rechercher";
            this.Size = new System.Drawing.Size(272, 57);
            this.Load += new System.EventHandler(this.CU_Rechercher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.Button bt_Search;
        private System.Windows.Forms.ComboBox cob_Search;
    }
}
