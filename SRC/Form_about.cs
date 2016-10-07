using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Librairies supplémentaires :
using System.Configuration;

namespace MinutPapillon
{
    public partial class Form_about : Form
    {
        public bool c = true;
        public Form_about()
        {
            InitializeComponent();

        }
        #region FONCTIONS
        private void Copyright(bool c)
        {
            if (!c)
            {
                if (ConfigurationManager.AppSettings["A1"] != link_Auteur1.Text)
                {
                    if (link_Auteur1.Text != "Mr COUPEZ Frédéric")
                    {
                        ConfigurationManager.AppSettings["A1"] = "Mr COUPEZ Frédéric";
                        ConfigurationManager.AppSettings["M1"] = "coupez.frederic@gmail.com";
                    }
                }
                if (ConfigurationManager.AppSettings["A2"] != link_Auteur2.Text)
                {
                    if (link_Auteur1.Text != "Mr MASSON Guillaume")
                    {
                        ConfigurationManager.AppSettings["A2"] = "Mr MASSON Guillaume";
                        ConfigurationManager.AppSettings["M2"] = "g.masson02@gmail.com";
                    }
                }
            }
        }
        private void AllRightsReserved()
        {
            if (c)
            {
                lb_Auteur1.Text = ConfigurationManager.AppSettings["A1"];
                link_Auteur1.Text = ConfigurationManager.AppSettings["M1"];
                lb_Auteur2.Text = ConfigurationManager.AppSettings["A2"];
                link_Auteur2.Text = ConfigurationManager.AppSettings["M2"];
            }
        }
        #endregion

        #region EVENEMENTS
        private void Form_about_Load(object sender, EventArgs e)
        {
            Copyright(c);
            AllRightsReserved();
        }
        #region FINANCEURS
        private void pic_AFPA_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.afpa.fr/");
            }
            catch {}
        }

        private void pic_ConseilReg_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.picardie.fr/");
            }
            catch { }
        }
        #endregion
        #region NOUS CONTACTER
        private void link_Auteur1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:"+link_Auteur1.Text);
            }
            catch { }
        }

        private void link_Auteur2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:" + link_Auteur2.Text);
            }
            catch { }
        }
        #endregion
        #endregion
    }
}
