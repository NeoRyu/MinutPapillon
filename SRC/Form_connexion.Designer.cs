namespace MinutPapillon
{
    partial class Form_connexion
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_connexion));
            this.la_Information = new System.Windows.Forms.Label();
            this.bt_Connexion = new System.Windows.Forms.Button();
            this.la_Password = new System.Windows.Forms.Label();
            this.la_Identifiant = new System.Windows.Forms.Label();
            this.tb_Identifiant = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.pic_Clavier = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Clavier)).BeginInit();
            this.SuspendLayout();
            // 
            // la_Information
            // 
            this.la_Information.AutoSize = true;
            this.la_Information.BackColor = System.Drawing.Color.Transparent;
            this.la_Information.Font = new System.Drawing.Font("Book Antiqua", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la_Information.ForeColor = System.Drawing.Color.White;
            this.la_Information.Location = new System.Drawing.Point(33, 155);
            this.la_Information.Name = "la_Information";
            this.la_Information.Size = new System.Drawing.Size(261, 54);
            this.la_Information.TabIndex = 31;
            this.la_Information.Text = "Veuillez saisir votre identifiant et votre \r\nmot de passe pour pouvoir vous \r\ncon" +
    "necter à l\'application !";
            this.la_Information.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_Connexion
            // 
            this.bt_Connexion.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_Connexion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Connexion.Enabled = false;
            this.bt_Connexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Connexion.Font = new System.Drawing.Font("Book Antiqua", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Connexion.ForeColor = System.Drawing.Color.Black;
            this.bt_Connexion.Location = new System.Drawing.Point(44, 105);
            this.bt_Connexion.Name = "bt_Connexion";
            this.bt_Connexion.Size = new System.Drawing.Size(235, 40);
            this.bt_Connexion.TabIndex = 28;
            this.bt_Connexion.Text = "&CONNEXION";
            this.bt_Connexion.UseVisualStyleBackColor = true;
            this.bt_Connexion.Click += new System.EventHandler(this.bt_Connexion_Click);
            // 
            // la_Password
            // 
            this.la_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.la_Password.AutoSize = true;
            this.la_Password.BackColor = System.Drawing.Color.Transparent;
            this.la_Password.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la_Password.ForeColor = System.Drawing.Color.White;
            this.la_Password.Location = new System.Drawing.Point(34, 77);
            this.la_Password.Name = "la_Password";
            this.la_Password.Size = new System.Drawing.Size(102, 19);
            this.la_Password.TabIndex = 30;
            this.la_Password.Text = "&Mot de passe :";
            this.la_Password.Click += new System.EventHandler(this.la_Password_Click);
            // 
            // la_Identifiant
            // 
            this.la_Identifiant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.la_Identifiant.AutoSize = true;
            this.la_Identifiant.BackColor = System.Drawing.Color.Transparent;
            this.la_Identifiant.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la_Identifiant.ForeColor = System.Drawing.Color.White;
            this.la_Identifiant.Location = new System.Drawing.Point(36, 51);
            this.la_Identifiant.Name = "la_Identifiant";
            this.la_Identifiant.Size = new System.Drawing.Size(100, 19);
            this.la_Identifiant.TabIndex = 29;
            this.la_Identifiant.Text = "&Identifiant    :";
            this.la_Identifiant.Click += new System.EventHandler(this.la_Identifiant_Click);
            // 
            // tb_Identifiant
            // 
            this.tb_Identifiant.Location = new System.Drawing.Point(138, 51);
            this.tb_Identifiant.Name = "tb_Identifiant";
            this.tb_Identifiant.Size = new System.Drawing.Size(144, 20);
            this.tb_Identifiant.TabIndex = 26;
            this.tb_Identifiant.TextChanged += new System.EventHandler(this.Authentification_TextChanged);
            this.tb_Identifiant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Authentification_KeyPress);
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(138, 77);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(144, 20);
            this.tb_Password.TabIndex = 27;
            this.tb_Password.UseSystemPasswordChar = true;
            this.tb_Password.TextChanged += new System.EventHandler(this.Authentification_TextChanged);
            this.tb_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Authentification_KeyPress);
            // 
            // pic_Clavier
            // 
            this.pic_Clavier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_Clavier.BackgroundImage")));
            this.pic_Clavier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_Clavier.Location = new System.Drawing.Point(12, 231);
            this.pic_Clavier.Name = "pic_Clavier";
            this.pic_Clavier.Size = new System.Drawing.Size(30, 18);
            this.pic_Clavier.TabIndex = 33;
            this.pic_Clavier.TabStop = false;
            this.pic_Clavier.Click += new System.EventHandler(this.pic_Clavier_Click);
            this.pic_Clavier.MouseEnter += new System.EventHandler(this.pic_Clavier_MouseEnter);
            // 
            // Form_connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MinutPapillon.Properties.Resources.BGLuxury;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(324, 261);
            this.Controls.Add(this.pic_Clavier);
            this.Controls.Add(this.la_Information);
            this.Controls.Add(this.bt_Connexion);
            this.Controls.Add(this.la_Password);
            this.Controls.Add(this.la_Identifiant);
            this.Controls.Add(this.tb_Identifiant);
            this.Controls.Add(this.tb_Password);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(340, 300);
            this.MinimumSize = new System.Drawing.Size(340, 300);
            this.Name = "Form_connexion";
            this.Text = "MinutPapillon - Connexion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_connexion_FormClosing);
            this.Load += new System.EventHandler(this.Form_connexion_Load);
            this.DoubleClick += new System.EventHandler(this.Form_connexion_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Clavier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label la_Information;
        private System.Windows.Forms.Button bt_Connexion;
        private System.Windows.Forms.Label la_Password;
        private System.Windows.Forms.Label la_Identifiant;
        private System.Windows.Forms.TextBox tb_Identifiant;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.PictureBox pic_Clavier;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}

