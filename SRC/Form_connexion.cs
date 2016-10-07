using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librairies supplémentaires utilisées :
using System.Data.SqlClient;
using System.IO;    // EasterEgg
using System.Net;   // EasterEgg
using System.Diagnostics;


namespace MinutPapillon
{
    public partial class Form_connexion : Form
    {
        #region INSTANCIATIONS
        Connexion BDD = new Connexion();
        Shell.Error Debug = new Shell.Error();
        Window Herit = new Window();
        User user = new User();
        Design ds = new Design();
        #endregion

        public Form_connexion()
        {
            InitializeComponent();
        }

        #region FONCTIONS
        
        private void activeButton()
        {
            try
            {
                if (tb_Identifiant.Text != "" && tb_Password.Text != "")
                {
                    bt_Connexion.Enabled = true;
                }
                else
                {
                    bt_Connexion.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Debug.C_Error(ex);
                //Herit.FormClose(BDD.ConnectBDDPublic);
            }
        }

        private void authentification() // nom à changer
        {
            if (tb_Identifiant.Text != "" && tb_Password.Text != "")
            {
                Herit.WinFormRedirectAuthentification(this, user, tb_Identifiant, tb_Password);
            }
        }

        #endregion

        #region EVENEMENTS

        private void Form_connexion_Load(object sender, EventArgs e)
        {
            BDD.OpenBDD();
            tb_Identifiant.Text = "ADMIN";
            tb_Password.Text = "root";
            
            //ds.Importer_ColorBDD(BDD);

            if (EasterEggActivate) EasterEgg();    // Pour précharger l'image de fond sur le web
        }

        private void Form_connexion_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region
            if ((tb_Identifiant.Text.ToUpper() == "EASTER") && (tb_Password.Text.ToUpper() == "EGG"))
            {
                picload = false;
                EasterEgg();
            }
            #endregion
            Application.Exit();
        }

        #region CLAVIER VIRTUEL
        private void pic_Clavier_Click(object sender, EventArgs e)
        {
            Process.Start(@"osk.exe");
        }
        private void pic_Clavier_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pic_Clavier, "Cliquez pour activer le clavier virtuel de Windows");
        }
        #endregion

        #region GESTION DES LABEL
        private void la_Identifiant_Click(object sender, EventArgs e)
        {
            tb_Identifiant.Focus();
        }

        private void la_Password_Click(object sender, EventArgs e)
        {
            tb_Password.Focus();
        }
        #endregion

        #region GESTION DES TEXTBOX (pour tb_authentification et tb_password)

        private void Authentification_TextChanged(object sender, EventArgs e)
        {
            activeButton();
        }

        private void Authentification_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == 13))
            {
                authentification();
            }
        }

        private void bt_Connexion_Click(object sender, EventArgs e)
        {
            authentification();
        }
        #endregion  
        #endregion

        #region EASTER EGG
        private bool EasterEggActivate = true;    // On active / desactive l'EasterEgg ici ! =)
        private bool picload, openclose = true;
        private void Form_connexion_DoubleClick(object sender, EventArgs e)
        {
            if ((tb_Identifiant.Text.ToUpper() == "EASTER") && (tb_Password.Text.ToUpper() == "EGG"))
            {
                picload = false;
                EasterEgg();
            }
        }

        private void EasterEgg()
        {
            if ((EasterEggActivate) && ((tb_Identifiant.Text.ToUpper() == "EASTER") && (tb_Password.Text.ToUpper() == "EGG")))
            {
                var request = WebRequest.Create("https://kesako.files.wordpress.com/2010/08/kesako-pub-asterix-obelix-mc-donald.jpg");
                //http://vignette3.wikia.nocookie.net/shokugekinosoma/images/6/6a/Mayumi_&_Tentacles_(anime).png/revision/latest?cb=20150404135312");
                if (!picload)
                {
                    if (openclose)
                    { // On modifie l'interface
                        openclose = false;

                        // Changement du fond d'ecran
                        using (var response = request.GetResponse())
                        using (var stream = response.GetResponseStream())
                        {
                            this.BackgroundImage = Bitmap.FromStream(stream);
                        }

                        // On retire toute l'interface
                        la_Identifiant.Visible = false;
                        la_Password.Visible = false;
                        tb_Identifiant.Visible = false;
                        tb_Password.Visible = false;
                        bt_Connexion.Visible = false;
                        la_Information.Text = "";
                        la_Information.ForeColor = Color.Black;
                        pic_Clavier.Visible = false;

                        // On agrandi au maximum la fenetre
                        this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                        this.MinimumSize = this.MaximumSize;
                        this.WindowState = FormWindowState.Maximized;

                        // Creation d'un nombre aleatoire de fenetre de message
                        //Random rnd = new Random();
                        //int random = rnd.Next(1, 20);
                        //for (int i = 0; i <= 10; i++) //Convert.ToInt32(rnd)
                        MessageBox.Show("AFPA, La formation pour adulte où vous venez comme vous êtes !", "EASTER EGG");
                    }
                    else
                    { // On joue une musique en bip console
                        #region Theme Super Mario Bros.
                        //Geconverteerd d.m.v. de Portal42 Music-to-Hertz tool (http://tools.portal42.net/music.php)
                        Console.Beep(659, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 167);
                        Console.Beep(523, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(784, 125);
                        Console.Beep(20000, 375);
                        Console.Beep(392, 125);
                        Console.Beep(20000, 375);
                        Console.Beep(523, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(392, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(330, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(440, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(494, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(466, 125);
                        Console.Beep(20000, 42);
                        Console.Beep(440, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(392, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(784, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(880, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(698, 125);
                        Console.Beep(784, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(523, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(587, 125);
                        Console.Beep(494, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(523, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(392, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(330, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(440, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(494, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(466, 125);
                        Console.Beep(20000, 42);
                        Console.Beep(440, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(392, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(784, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(880, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(698, 125);
                        Console.Beep(784, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(523, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(587, 125);
                        Console.Beep(494, 125);
                        Console.Beep(20000, 375);
                        Console.Beep(784, 125);
                        Console.Beep(740, 125);
                        Console.Beep(698, 125);
                        Console.Beep(20000, 42);
                        Console.Beep(622, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 167);
                        Console.Beep(415, 125);
                        Console.Beep(440, 125);
                        Console.Beep(523, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(440, 125);
                        Console.Beep(523, 125);
                        Console.Beep(587, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(784, 125);
                        Console.Beep(740, 125);
                        Console.Beep(698, 125);
                        Console.Beep(20000, 42);
                        Console.Beep(622, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 167);
                        Console.Beep(698, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(698, 125);
                        Console.Beep(698, 125);
                        Console.Beep(20000, 625);
                        Console.Beep(784, 125);
                        Console.Beep(740, 125);
                        Console.Beep(698, 125);
                        Console.Beep(20000, 42);
                        Console.Beep(622, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 167);
                        Console.Beep(415, 125);
                        Console.Beep(440, 125);
                        Console.Beep(523, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(440, 125);
                        Console.Beep(523, 125);
                        Console.Beep(587, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(622, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(587, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(523, 125);
                        Console.Beep(20000, 1125);
                        Console.Beep(784, 125);
                        Console.Beep(740, 125);
                        Console.Beep(698, 125);
                        Console.Beep(20000, 42);
                        Console.Beep(622, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 167);
                        Console.Beep(415, 125);
                        Console.Beep(440, 125);
                        Console.Beep(523, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(440, 125);
                        Console.Beep(523, 125);
                        Console.Beep(587, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(784, 125);
                        Console.Beep(740, 125);
                        Console.Beep(698, 125);
                        Console.Beep(20000, 42);
                        Console.Beep(622, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 167);
                        Console.Beep(698, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(698, 125);
                        Console.Beep(698, 125);
                        Console.Beep(20000, 625);
                        Console.Beep(784, 125);
                        Console.Beep(740, 125);
                        Console.Beep(698, 125);
                        Console.Beep(20000, 42);
                        Console.Beep(622, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(659, 125);
                        Console.Beep(20000, 167);
                        Console.Beep(415, 125);
                        Console.Beep(440, 125);
                        Console.Beep(523, 125);
                        Console.Beep(20000, 125);
                        Console.Beep(440, 125);
                        Console.Beep(523, 125);
                        Console.Beep(587, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(622, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(587, 125);
                        Console.Beep(20000, 250);
                        Console.Beep(523, 125);
                        Console.Beep(20000, 625);
                        #endregion
                    }
                }
            }
        }
        #endregion
    }
}
