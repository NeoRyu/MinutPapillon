namespace MinutPapillon
{
    partial class CU_Utilisateur
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
            this.tb_UserTel = new System.Windows.Forms.TextBox();
            this.tb_UserPrenom = new System.Windows.Forms.TextBox();
            this.tb_UserNom = new System.Windows.Forms.TextBox();
            this.tb_UserPassword = new System.Windows.Forms.TextBox();
            this.tb_UserUpdateRole = new System.Windows.Forms.TextBox();
            this.cob_UserRole = new System.Windows.Forms.ComboBox();
            this.gb_GestionRoles = new System.Windows.Forms.GroupBox();
            this.lb_InfoNivRole = new System.Windows.Forms.Label();
            this.lb_UserUpdateNivRole = new System.Windows.Forms.Label();
            this.bt_UserRoleAdd = new System.Windows.Forms.Button();
            this.bt_UserUpdateRole = new System.Windows.Forms.Button();
            this.cob_UserUpdateRole = new System.Windows.Forms.ComboBox();
            this.tb_UserPseudo = new System.Windows.Forms.TextBox();
            this.gb_GestionUser = new System.Windows.Forms.GroupBox();
            this.bt_load = new System.Windows.Forms.Button();
            this.bt_UserUpdate = new System.Windows.Forms.Button();
            this.bt_UserInsert = new System.Windows.Forms.Button();
            this.gb_GestionRoles.SuspendLayout();
            this.gb_GestionUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_UserTel
            // 
            this.tb_UserTel.ForeColor = System.Drawing.Color.Gray;
            this.tb_UserTel.Location = new System.Drawing.Point(9, 124);
            this.tb_UserTel.MaxLength = 10;
            this.tb_UserTel.Name = "tb_UserTel";
            this.tb_UserTel.Size = new System.Drawing.Size(147, 20);
            this.tb_UserTel.TabIndex = 9;
            this.tb_UserTel.Text = "Numéro de télephone";
            this.tb_UserTel.TextChanged += new System.EventHandler(this.XSS_Numerique);
            this.tb_UserTel.Enter += new System.EventHandler(this.tb_UserTel_Enter);
            this.tb_UserTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeypressEnter);
            this.tb_UserTel.Leave += new System.EventHandler(this.tb_UserTel_Leave);
            // 
            // tb_UserPrenom
            // 
            this.tb_UserPrenom.ForeColor = System.Drawing.Color.Gray;
            this.tb_UserPrenom.Location = new System.Drawing.Point(9, 97);
            this.tb_UserPrenom.MaxLength = 250;
            this.tb_UserPrenom.Name = "tb_UserPrenom";
            this.tb_UserPrenom.Size = new System.Drawing.Size(147, 20);
            this.tb_UserPrenom.TabIndex = 8;
            this.tb_UserPrenom.Text = "Prénom";
            this.tb_UserPrenom.TextChanged += new System.EventHandler(this.XSS_AlphaNum);
            this.tb_UserPrenom.Enter += new System.EventHandler(this.tb_UserPrenom_Enter);
            this.tb_UserPrenom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeypressEnter);
            this.tb_UserPrenom.Leave += new System.EventHandler(this.tb_UserPrenom_Leave);
            // 
            // tb_UserNom
            // 
            this.tb_UserNom.ForeColor = System.Drawing.Color.Gray;
            this.tb_UserNom.Location = new System.Drawing.Point(9, 71);
            this.tb_UserNom.MaxLength = 250;
            this.tb_UserNom.Name = "tb_UserNom";
            this.tb_UserNom.Size = new System.Drawing.Size(147, 20);
            this.tb_UserNom.TabIndex = 7;
            this.tb_UserNom.Text = "Nom de famille";
            this.tb_UserNom.TextChanged += new System.EventHandler(this.XSS_Alphabetique);
            this.tb_UserNom.Enter += new System.EventHandler(this.tb_UserNom_Enter);
            this.tb_UserNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeypressEnter);
            this.tb_UserNom.Leave += new System.EventHandler(this.tb_UserNom_Leave);
            // 
            // tb_UserPassword
            // 
            this.tb_UserPassword.BackColor = System.Drawing.Color.White;
            this.tb_UserPassword.ForeColor = System.Drawing.Color.Gray;
            this.tb_UserPassword.Location = new System.Drawing.Point(9, 45);
            this.tb_UserPassword.MaxLength = 250;
            this.tb_UserPassword.Name = "tb_UserPassword";
            this.tb_UserPassword.Size = new System.Drawing.Size(147, 20);
            this.tb_UserPassword.TabIndex = 6;
            this.tb_UserPassword.Text = "Mot de passe";
            this.tb_UserPassword.TextChanged += new System.EventHandler(this.XSS_AlphaNum);
            this.tb_UserPassword.Enter += new System.EventHandler(this.tb_UserPassword_Enter);
            this.tb_UserPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeypressEnter);
            this.tb_UserPassword.Leave += new System.EventHandler(this.tb_UserPassword_Leave);
            // 
            // tb_UserUpdateRole
            // 
            this.tb_UserUpdateRole.Enabled = false;
            this.tb_UserUpdateRole.ForeColor = System.Drawing.Color.Gray;
            this.tb_UserUpdateRole.Location = new System.Drawing.Point(102, 54);
            this.tb_UserUpdateRole.MaxLength = 2;
            this.tb_UserUpdateRole.Name = "tb_UserUpdateRole";
            this.tb_UserUpdateRole.Size = new System.Drawing.Size(54, 20);
            this.tb_UserUpdateRole.TabIndex = 15;
            this.tb_UserUpdateRole.Text = "0";
            this.tb_UserUpdateRole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_UserUpdateRole.TextChanged += new System.EventHandler(this.tb_UserUpdateRole_TextChanged);
            this.tb_UserUpdateRole.Enter += new System.EventHandler(this.tb_UserUpdateRole_Enter);
            this.tb_UserUpdateRole.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeypressEnter);
            this.tb_UserUpdateRole.Leave += new System.EventHandler(this.tb_UserUpdateRole_Leave);
            // 
            // cob_UserRole
            // 
            this.cob_UserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_UserRole.FormattingEnabled = true;
            this.cob_UserRole.Location = new System.Drawing.Point(9, 152);
            this.cob_UserRole.Name = "cob_UserRole";
            this.cob_UserRole.Size = new System.Drawing.Size(147, 21);
            this.cob_UserRole.TabIndex = 10;
            this.cob_UserRole.Click += new System.EventHandler(this.cob_UserRole_Click);
            this.cob_UserRole.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeypressEnter);
            // 
            // gb_GestionRoles
            // 
            this.gb_GestionRoles.BackColor = System.Drawing.Color.Transparent;
            this.gb_GestionRoles.Controls.Add(this.lb_InfoNivRole);
            this.gb_GestionRoles.Controls.Add(this.lb_UserUpdateNivRole);
            this.gb_GestionRoles.Controls.Add(this.tb_UserUpdateRole);
            this.gb_GestionRoles.Controls.Add(this.bt_UserRoleAdd);
            this.gb_GestionRoles.Controls.Add(this.bt_UserUpdateRole);
            this.gb_GestionRoles.Controls.Add(this.cob_UserUpdateRole);
            this.gb_GestionRoles.ForeColor = System.Drawing.Color.White;
            this.gb_GestionRoles.Location = new System.Drawing.Point(10, 249);
            this.gb_GestionRoles.Name = "gb_GestionRoles";
            this.gb_GestionRoles.Size = new System.Drawing.Size(250, 93);
            this.gb_GestionRoles.TabIndex = 19;
            this.gb_GestionRoles.TabStop = false;
            this.gb_GestionRoles.Text = "Gestion des rôles";
            // 
            // lb_InfoNivRole
            // 
            this.lb_InfoNivRole.AutoSize = true;
            this.lb_InfoNivRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_InfoNivRole.Location = new System.Drawing.Point(-2, 77);
            this.lb_InfoNivRole.Name = "lb_InfoNivRole";
            this.lb_InfoNivRole.Size = new System.Drawing.Size(254, 13);
            this.lb_InfoNivRole.TabIndex = 18;
            this.lb_InfoNivRole.Text = "1 = Admin+ / 2 = Admin / 3 = User / 4 ou + = Inactif ";
            // 
            // lb_UserUpdateNivRole
            // 
            this.lb_UserUpdateNivRole.AutoSize = true;
            this.lb_UserUpdateNivRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_UserUpdateNivRole.Location = new System.Drawing.Point(3, 52);
            this.lb_UserUpdateNivRole.Name = "lb_UserUpdateNivRole";
            this.lb_UserUpdateNivRole.Size = new System.Drawing.Size(95, 15);
            this.lb_UserUpdateNivRole.TabIndex = 16;
            this.lb_UserUpdateNivRole.Text = "Niveau de droits";
            // 
            // bt_UserRoleAdd
            // 
            this.bt_UserRoleAdd.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_UserRoleAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_UserRoleAdd.Enabled = false;
            this.bt_UserRoleAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_UserRoleAdd.ForeColor = System.Drawing.Color.Black;
            this.bt_UserRoleAdd.Location = new System.Drawing.Point(165, 14);
            this.bt_UserRoleAdd.Name = "bt_UserRoleAdd";
            this.bt_UserRoleAdd.Size = new System.Drawing.Size(75, 26);
            this.bt_UserRoleAdd.TabIndex = 16;
            this.bt_UserRoleAdd.Text = "Ajouter";
            this.bt_UserRoleAdd.UseVisualStyleBackColor = true;
            this.bt_UserRoleAdd.Click += new System.EventHandler(this.bt_UserRoleAdd_Click);
            // 
            // bt_UserUpdateRole
            // 
            this.bt_UserUpdateRole.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_UserUpdateRole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_UserUpdateRole.Enabled = false;
            this.bt_UserUpdateRole.ForeColor = System.Drawing.Color.Black;
            this.bt_UserUpdateRole.Location = new System.Drawing.Point(165, 45);
            this.bt_UserUpdateRole.Name = "bt_UserUpdateRole";
            this.bt_UserUpdateRole.Size = new System.Drawing.Size(75, 26);
            this.bt_UserUpdateRole.TabIndex = 17;
            this.bt_UserUpdateRole.Text = "&Modifier";
            this.bt_UserUpdateRole.UseVisualStyleBackColor = true;
            this.bt_UserUpdateRole.Click += new System.EventHandler(this.bt_UserUpdateRole_Click);
            // 
            // cob_UserUpdateRole
            // 
            this.cob_UserUpdateRole.FormattingEnabled = true;
            this.cob_UserUpdateRole.Items.AddRange(new object[] {
            "Selectionnez un Rôle",
            "Administrateur",
            "Formateur",
            "Stagiaire",
            "Ancien Formateur",
            "Ancien Stagiaire"});
            this.cob_UserUpdateRole.Location = new System.Drawing.Point(6, 19);
            this.cob_UserUpdateRole.Name = "cob_UserUpdateRole";
            this.cob_UserUpdateRole.Size = new System.Drawing.Size(150, 21);
            this.cob_UserUpdateRole.TabIndex = 14;
            this.cob_UserUpdateRole.SelectedValueChanged += new System.EventHandler(this.cob_UserUpdateRole_SelectedValueChanged);
            this.cob_UserUpdateRole.Click += new System.EventHandler(this.cob_UserUpdateRole_Click);
            this.cob_UserUpdateRole.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeypressEnter);
            // 
            // tb_UserPseudo
            // 
            this.tb_UserPseudo.BackColor = System.Drawing.Color.White;
            this.tb_UserPseudo.ForeColor = System.Drawing.Color.Gray;
            this.tb_UserPseudo.Location = new System.Drawing.Point(9, 19);
            this.tb_UserPseudo.MaxLength = 250;
            this.tb_UserPseudo.Name = "tb_UserPseudo";
            this.tb_UserPseudo.Size = new System.Drawing.Size(147, 20);
            this.tb_UserPseudo.TabIndex = 5;
            this.tb_UserPseudo.Text = "Pseudonyme";
            this.tb_UserPseudo.TextChanged += new System.EventHandler(this.XSS_AlphaNum);
            this.tb_UserPseudo.Enter += new System.EventHandler(this.tb_UserPseudo_Enter);
            this.tb_UserPseudo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeypressEnter);
            this.tb_UserPseudo.Leave += new System.EventHandler(this.tb_UserPseudo_Leave);
            // 
            // gb_GestionUser
            // 
            this.gb_GestionUser.BackColor = System.Drawing.Color.Transparent;
            this.gb_GestionUser.Controls.Add(this.bt_load);
            this.gb_GestionUser.Controls.Add(this.cob_UserRole);
            this.gb_GestionUser.Controls.Add(this.tb_UserTel);
            this.gb_GestionUser.Controls.Add(this.tb_UserPseudo);
            this.gb_GestionUser.Controls.Add(this.tb_UserPrenom);
            this.gb_GestionUser.Controls.Add(this.tb_UserNom);
            this.gb_GestionUser.Controls.Add(this.bt_UserUpdate);
            this.gb_GestionUser.Controls.Add(this.bt_UserInsert);
            this.gb_GestionUser.Controls.Add(this.tb_UserPassword);
            this.gb_GestionUser.ForeColor = System.Drawing.Color.White;
            this.gb_GestionUser.Location = new System.Drawing.Point(10, 56);
            this.gb_GestionUser.Name = "gb_GestionUser";
            this.gb_GestionUser.Size = new System.Drawing.Size(250, 187);
            this.gb_GestionUser.TabIndex = 20;
            this.gb_GestionUser.TabStop = false;
            this.gb_GestionUser.Text = "Gestion des utilisateurs";
            // 
            // bt_load
            // 
            this.bt_load.BackColor = System.Drawing.Color.Transparent;
            this.bt_load.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_load.ForeColor = System.Drawing.Color.Black;
            this.bt_load.Location = new System.Drawing.Point(165, 19);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(75, 50);
            this.bt_load.TabIndex = 11;
            this.bt_load.Text = "IMPORTER DONNEES";
            this.bt_load.UseVisualStyleBackColor = false;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            // 
            // bt_UserUpdate
            // 
            this.bt_UserUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_UserUpdate.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_UserUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_UserUpdate.Enabled = false;
            this.bt_UserUpdate.ForeColor = System.Drawing.Color.Black;
            this.bt_UserUpdate.Location = new System.Drawing.Point(165, 124);
            this.bt_UserUpdate.Name = "bt_UserUpdate";
            this.bt_UserUpdate.Size = new System.Drawing.Size(75, 50);
            this.bt_UserUpdate.TabIndex = 13;
            this.bt_UserUpdate.Text = "&Modifier";
            this.bt_UserUpdate.UseVisualStyleBackColor = true;
            this.bt_UserUpdate.Click += new System.EventHandler(this.bt_UserUpdate_Click);
            // 
            // bt_UserInsert
            // 
            this.bt_UserInsert.BackgroundImage = global::MinutPapillon.Properties.Resources.BGButton;
            this.bt_UserInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_UserInsert.ForeColor = System.Drawing.Color.Black;
            this.bt_UserInsert.Location = new System.Drawing.Point(165, 71);
            this.bt_UserInsert.Name = "bt_UserInsert";
            this.bt_UserInsert.Size = new System.Drawing.Size(75, 50);
            this.bt_UserInsert.TabIndex = 12;
            this.bt_UserInsert.Text = "&Ajouter";
            this.bt_UserInsert.UseVisualStyleBackColor = true;
            this.bt_UserInsert.Click += new System.EventHandler(this.bt_UserInsert_Click);
            // 
            // CU_Utilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_GestionRoles);
            this.Controls.Add(this.gb_GestionUser);
            this.Name = "CU_Utilisateur";
            this.Size = new System.Drawing.Size(270, 350);
            this.Load += new System.EventHandler(this.CU_Utilisateur_Load);
            this.gb_GestionRoles.ResumeLayout(false);
            this.gb_GestionRoles.PerformLayout();
            this.gb_GestionUser.ResumeLayout(false);
            this.gb_GestionUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_UserRoleAdd;
        private System.Windows.Forms.TextBox tb_UserTel;
        private System.Windows.Forms.TextBox tb_UserPrenom;
        private System.Windows.Forms.TextBox tb_UserNom;
        private System.Windows.Forms.Button bt_UserUpdate;
        private System.Windows.Forms.Button bt_UserInsert;
        private System.Windows.Forms.TextBox tb_UserPassword;
        private System.Windows.Forms.TextBox tb_UserUpdateRole;
        private System.Windows.Forms.Button bt_UserUpdateRole;
        private System.Windows.Forms.ComboBox cob_UserRole;
        private System.Windows.Forms.GroupBox gb_GestionRoles;
        private System.Windows.Forms.TextBox tb_UserPseudo;
        private System.Windows.Forms.ComboBox cob_UserUpdateRole;
        private System.Windows.Forms.GroupBox gb_GestionUser;
        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.Label lb_UserUpdateNivRole;
        private System.Windows.Forms.Label lb_InfoNivRole;
    }
}
