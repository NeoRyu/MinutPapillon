namespace MinutPapillon
{
    partial class CU_StatsGlobales
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
            this.gb_GestionCarte = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gb_GestionCarte
            // 
            this.gb_GestionCarte.BackColor = System.Drawing.Color.Transparent;
            this.gb_GestionCarte.ForeColor = System.Drawing.Color.White;
            this.gb_GestionCarte.Location = new System.Drawing.Point(10, 3);
            this.gb_GestionCarte.Name = "gb_GestionCarte";
            this.gb_GestionCarte.Size = new System.Drawing.Size(250, 344);
            this.gb_GestionCarte.TabIndex = 21;
            this.gb_GestionCarte.TabStop = false;
            this.gb_GestionCarte.Text = "Statistiques";
            // 
            // CU_StatsGlobales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_GestionCarte);
            this.MinimumSize = new System.Drawing.Size(270, 350);
            this.Name = "CU_StatsGlobales";
            this.Size = new System.Drawing.Size(270, 350);
            this.Load += new System.EventHandler(this.CU_StatsVentes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_GestionCarte;
    }
}
