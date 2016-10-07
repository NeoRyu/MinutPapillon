namespace MinutPapillon
{
    partial class CU_Facture
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
            this.tb_Titre = new System.Windows.Forms.TextBox();
            this.tb_Description = new System.Windows.Forms.TextBox();
            this.tb_Adresse = new System.Windows.Forms.TextBox();
            this.gb_Font = new System.Windows.Forms.GroupBox();
            this.lb_Font_Footer = new System.Windows.Forms.Label();
            this.lb_Font_Body = new System.Windows.Forms.Label();
            this.lb_Font_Header = new System.Windows.Forms.Label();
            this.lb_Font_Titre = new System.Windows.Forms.Label();
            this.cob_Font_Footer = new System.Windows.Forms.ComboBox();
            this.cob_Font_Body = new System.Windows.Forms.ComboBox();
            this.cob_Font_Header = new System.Windows.Forms.ComboBox();
            this.cob_Font_Titre = new System.Windows.Forms.ComboBox();
            this.bt_Save = new System.Windows.Forms.Button();
            this.bt_Template = new System.Windows.Forms.Button();
            this.gb_Contenu = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Mention = new System.Windows.Forms.TextBox();
            this.tb_NumTel = new System.Windows.Forms.TextBox();
            this.tb_Thanks = new System.Windows.Forms.TextBox();
            this.gb_Font.SuspendLayout();
            this.gb_Contenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_Titre
            // 
            this.tb_Titre.Location = new System.Drawing.Point(70, 19);
            this.tb_Titre.Name = "tb_Titre";
            this.tb_Titre.Size = new System.Drawing.Size(185, 20);
            this.tb_Titre.TabIndex = 0;
            // 
            // tb_Description
            // 
            this.tb_Description.Location = new System.Drawing.Point(70, 45);
            this.tb_Description.Name = "tb_Description";
            this.tb_Description.Size = new System.Drawing.Size(185, 20);
            this.tb_Description.TabIndex = 1;
            // 
            // tb_Adresse
            // 
            this.tb_Adresse.Location = new System.Drawing.Point(71, 71);
            this.tb_Adresse.Name = "tb_Adresse";
            this.tb_Adresse.Size = new System.Drawing.Size(184, 20);
            this.tb_Adresse.TabIndex = 2;
            // 
            // gb_Font
            // 
            this.gb_Font.Controls.Add(this.lb_Font_Footer);
            this.gb_Font.Controls.Add(this.lb_Font_Body);
            this.gb_Font.Controls.Add(this.lb_Font_Header);
            this.gb_Font.Controls.Add(this.lb_Font_Titre);
            this.gb_Font.Controls.Add(this.cob_Font_Footer);
            this.gb_Font.Controls.Add(this.cob_Font_Body);
            this.gb_Font.Controls.Add(this.cob_Font_Header);
            this.gb_Font.Controls.Add(this.cob_Font_Titre);
            this.gb_Font.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gb_Font.Location = new System.Drawing.Point(3, 187);
            this.gb_Font.Name = "gb_Font";
            this.gb_Font.Size = new System.Drawing.Size(260, 124);
            this.gb_Font.TabIndex = 4;
            this.gb_Font.TabStop = false;
            this.gb_Font.Text = "Taille des caractères";
            // 
            // lb_Font_Footer
            // 
            this.lb_Font_Footer.AutoSize = true;
            this.lb_Font_Footer.Location = new System.Drawing.Point(6, 103);
            this.lb_Font_Footer.Name = "lb_Font_Footer";
            this.lb_Font_Footer.Size = new System.Drawing.Size(122, 13);
            this.lb_Font_Footer.TabIndex = 7;
            this.lb_Font_Footer.Text = "Mention (pied de page) :";
            // 
            // lb_Font_Body
            // 
            this.lb_Font_Body.AutoSize = true;
            this.lb_Font_Body.Location = new System.Drawing.Point(6, 76);
            this.lb_Font_Body.Name = "lb_Font_Body";
            this.lb_Font_Body.Size = new System.Drawing.Size(105, 13);
            this.lb_Font_Body.TabIndex = 6;
            this.lb_Font_Body.Text = "Corps du document :";
            // 
            // lb_Font_Header
            // 
            this.lb_Font_Header.AutoSize = true;
            this.lb_Font_Header.Location = new System.Drawing.Point(6, 49);
            this.lb_Font_Header.Name = "lb_Font_Header";
            this.lb_Font_Header.Size = new System.Drawing.Size(113, 13);
            this.lb_Font_Header.TabIndex = 5;
            this.lb_Font_Header.Text = "En-tête (+ Total TTC) :";
            // 
            // lb_Font_Titre
            // 
            this.lb_Font_Titre.AutoSize = true;
            this.lb_Font_Titre.Location = new System.Drawing.Point(6, 22);
            this.lb_Font_Titre.Name = "lb_Font_Titre";
            this.lb_Font_Titre.Size = new System.Drawing.Size(100, 13);
            this.lb_Font_Titre.TabIndex = 4;
            this.lb_Font_Titre.Text = "Nom du restaurant :";
            // 
            // cob_Font_Footer
            // 
            this.cob_Font_Footer.FormattingEnabled = true;
            this.cob_Font_Footer.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.cob_Font_Footer.Location = new System.Drawing.Point(133, 98);
            this.cob_Font_Footer.Name = "cob_Font_Footer";
            this.cob_Font_Footer.Size = new System.Drawing.Size(121, 21);
            this.cob_Font_Footer.TabIndex = 3;
            // 
            // cob_Font_Body
            // 
            this.cob_Font_Body.FormattingEnabled = true;
            this.cob_Font_Body.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.cob_Font_Body.Location = new System.Drawing.Point(133, 71);
            this.cob_Font_Body.Name = "cob_Font_Body";
            this.cob_Font_Body.Size = new System.Drawing.Size(121, 21);
            this.cob_Font_Body.TabIndex = 2;
            // 
            // cob_Font_Header
            // 
            this.cob_Font_Header.FormattingEnabled = true;
            this.cob_Font_Header.Items.AddRange(new object[] {
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.cob_Font_Header.Location = new System.Drawing.Point(133, 44);
            this.cob_Font_Header.Name = "cob_Font_Header";
            this.cob_Font_Header.Size = new System.Drawing.Size(121, 21);
            this.cob_Font_Header.TabIndex = 1;
            // 
            // cob_Font_Titre
            // 
            this.cob_Font_Titre.FormattingEnabled = true;
            this.cob_Font_Titre.Items.AddRange(new object[] {
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26"});
            this.cob_Font_Titre.Location = new System.Drawing.Point(133, 17);
            this.cob_Font_Titre.Name = "cob_Font_Titre";
            this.cob_Font_Titre.Size = new System.Drawing.Size(121, 21);
            this.cob_Font_Titre.TabIndex = 0;
            // 
            // bt_Save
            // 
            this.bt_Save.BackColor = System.Drawing.Color.DarkGray;
            this.bt_Save.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Save.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_Save.Location = new System.Drawing.Point(132, 317);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(125, 30);
            this.bt_Save.TabIndex = 5;
            this.bt_Save.Text = "ENREGISTRER";
            this.bt_Save.UseVisualStyleBackColor = false;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // bt_Template
            // 
            this.bt_Template.BackColor = System.Drawing.Color.DarkGray;
            this.bt_Template.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_Template.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Template.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Template.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_Template.Location = new System.Drawing.Point(4, 317);
            this.bt_Template.Name = "bt_Template";
            this.bt_Template.Size = new System.Drawing.Size(125, 30);
            this.bt_Template.TabIndex = 6;
            this.bt_Template.Text = "APERCU";
            this.bt_Template.UseVisualStyleBackColor = false;
            this.bt_Template.Visible = false;
            // 
            // gb_Contenu
            // 
            this.gb_Contenu.Controls.Add(this.label6);
            this.gb_Contenu.Controls.Add(this.label5);
            this.gb_Contenu.Controls.Add(this.label4);
            this.gb_Contenu.Controls.Add(this.label3);
            this.gb_Contenu.Controls.Add(this.label2);
            this.gb_Contenu.Controls.Add(this.label1);
            this.gb_Contenu.Controls.Add(this.tb_Mention);
            this.gb_Contenu.Controls.Add(this.tb_NumTel);
            this.gb_Contenu.Controls.Add(this.tb_Thanks);
            this.gb_Contenu.Controls.Add(this.tb_Titre);
            this.gb_Contenu.Controls.Add(this.tb_Adresse);
            this.gb_Contenu.Controls.Add(this.tb_Description);
            this.gb_Contenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gb_Contenu.Location = new System.Drawing.Point(3, 3);
            this.gb_Contenu.Name = "gb_Contenu";
            this.gb_Contenu.Size = new System.Drawing.Size(260, 178);
            this.gb_Contenu.TabIndex = 7;
            this.gb_Contenu.TabStop = false;
            this.gb_Contenu.Text = "Gestion du contenu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mention";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "F. Politesse";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Telephone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Adresse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Titre";
            // 
            // tb_Mention
            // 
            this.tb_Mention.Location = new System.Drawing.Point(70, 148);
            this.tb_Mention.Name = "tb_Mention";
            this.tb_Mention.Size = new System.Drawing.Size(185, 20);
            this.tb_Mention.TabIndex = 5;
            // 
            // tb_NumTel
            // 
            this.tb_NumTel.Location = new System.Drawing.Point(70, 97);
            this.tb_NumTel.Name = "tb_NumTel";
            this.tb_NumTel.Size = new System.Drawing.Size(185, 20);
            this.tb_NumTel.TabIndex = 3;
            // 
            // tb_Thanks
            // 
            this.tb_Thanks.Location = new System.Drawing.Point(70, 123);
            this.tb_Thanks.Name = "tb_Thanks";
            this.tb_Thanks.Size = new System.Drawing.Size(185, 20);
            this.tb_Thanks.TabIndex = 4;
            // 
            // CU_Facture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_Contenu);
            this.Controls.Add(this.bt_Template);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.gb_Font);
            this.MinimumSize = new System.Drawing.Size(270, 350);
            this.Name = "CU_Facture";
            this.Size = new System.Drawing.Size(270, 350);
            this.Load += new System.EventHandler(this.CU_Facture_Load);
            this.gb_Font.ResumeLayout(false);
            this.gb_Font.PerformLayout();
            this.gb_Contenu.ResumeLayout(false);
            this.gb_Contenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Titre;
        private System.Windows.Forms.TextBox tb_Description;
        private System.Windows.Forms.TextBox tb_Adresse;
        private System.Windows.Forms.GroupBox gb_Font;
        private System.Windows.Forms.ComboBox cob_Font_Footer;
        private System.Windows.Forms.ComboBox cob_Font_Body;
        private System.Windows.Forms.ComboBox cob_Font_Header;
        private System.Windows.Forms.ComboBox cob_Font_Titre;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Button bt_Template;
        private System.Windows.Forms.GroupBox gb_Contenu;
        private System.Windows.Forms.Label lb_Font_Footer;
        private System.Windows.Forms.Label lb_Font_Body;
        private System.Windows.Forms.Label lb_Font_Header;
        private System.Windows.Forms.Label lb_Font_Titre;
        private System.Windows.Forms.TextBox tb_Mention;
        private System.Windows.Forms.TextBox tb_NumTel;
        private System.Windows.Forms.TextBox tb_Thanks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
