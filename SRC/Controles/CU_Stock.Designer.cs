namespace MinutPapillon
{
    partial class CU_Stock
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
            this.gb_GestionStock = new System.Windows.Forms.GroupBox();
            this.bt_load = new System.Windows.Forms.Button();
            this.bt_ItemModif = new System.Windows.Forms.Button();
            this.bt_ItemAdd = new System.Windows.Forms.Button();
            this.gb_GestionStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_GestionStock
            // 
            this.gb_GestionStock.BackColor = System.Drawing.Color.Transparent;
            this.gb_GestionStock.Controls.Add(this.bt_load);
            this.gb_GestionStock.Controls.Add(this.bt_ItemModif);
            this.gb_GestionStock.Controls.Add(this.bt_ItemAdd);
            this.gb_GestionStock.ForeColor = System.Drawing.Color.White;
            this.gb_GestionStock.Location = new System.Drawing.Point(10, 56);
            this.gb_GestionStock.Name = "gb_GestionStock";
            this.gb_GestionStock.Size = new System.Drawing.Size(250, 291);
            this.gb_GestionStock.TabIndex = 22;
            this.gb_GestionStock.TabStop = false;
            this.gb_GestionStock.Text = "Gestion des stocks";
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
            this.bt_load.Visible = false;
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
            this.bt_ItemModif.Visible = false;
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
            this.bt_ItemAdd.Visible = false;
            // 
            // CU_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_GestionStock);
            this.Name = "CU_Stock";
            this.Size = new System.Drawing.Size(270, 350);
            this.Load += new System.EventHandler(this.CU_Stock_Load);
            this.gb_GestionStock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_GestionStock;
        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.Button bt_ItemModif;
        private System.Windows.Forms.Button bt_ItemAdd;
    }
}
