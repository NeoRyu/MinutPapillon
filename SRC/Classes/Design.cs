using System;
// Librairies supplémentaires :
using System.Drawing;               // Color
using System.Windows.Forms;         // textbox etc
using System.Collections.Generic;   // List

namespace MinutPapillon
{
    public class MyColor
    {
        public string name { get; set; }        // Le "name" est le nom du paramêtre 
        public Color valeur { get; set; }       // La "valeur" est la donnée COLOR du paramêtre
    }

    class Design
    {
        #region [SNIPPET] GESTION COULEURS DES INFOBULLES
        public void ColorTooltip(object sender, DrawToolTipEventArgs e, ToolTip toolTip1)
        {
            #region Section à ajouter dans le main du Form
            //toolTip1.OwnerDraw = true;
            //toolTip1.BackColor = System.Drawing.Color.MistyRose;
            #endregion

            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
        #endregion

        #region [SNIPPET] GESTION COULEURS D'UN MENU NAVIGATION (Heritage de classe)
        public class MyRenderer : ToolStripProfessionalRenderer
        {
            #region Section à ajouter dans le main du Form
            // ms_Navigation.Renderer = new Design.MyRenderer();
            #endregion

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(Brushes.Tomato, rc);
                    e.Graphics.DrawRectangle(Pens.Crimson, 1, 0, rc.Width - 2, rc.Height - 1);
                }
            }
        }
        #endregion

        #region GESTION DES SURLIGNAGES ( HIGHLIGHT ) ET DESCRITPION DANS LES TEXTBOXS
        public void HighlightTextbox(TextBox NomTB, string Event, string Texte)
        {
            if (Event == "clic")
            {
                if (NomTB.Text == Texte)
                    NomTB.Text = "";
                if (NomTB.ForeColor == Color.Gray)
                    NomTB.ForeColor = Color.Black;
                if ((NomTB.BackColor != Color.MistyRose) && (NomTB.BackColor != Color.Cornsilk)) // Si différent d'une erreur
                    NomTB.BackColor = Color.Gold;
            }
            if (Event == "leave")
            {
                if (NomTB.BackColor == Color.Gold)      // Leave la selection actuelle
                    NomTB.BackColor = Color.White;
                if (NomTB.BackColor == Color.MistyRose) // Leave la selection ayant eu une erreur
                    NomTB.BackColor = Color.Cornsilk;
                if ((NomTB.Text == "") || (NomTB.Text == Texte))
                {
                    NomTB.ForeColor = Color.Gray;
                    NomTB.Text = Texte;
                }
            }
            if (Event == "incomplet")
            {
                NomTB.BackColor = Color.MistyRose; //Gold;
                NomTB.ForeColor = Color.Gray;
                NomTB.Text = Texte;
            }
        }
        #endregion

        #region GESTION D'UN BACKCOLOR POUR LES BOUTONS ARTICLES (Partie Serveur)
        public static bool RandomButton;

        public List<Color> Importer_ColorBDD(Connexion BDD)
        {
            RequestData r = new RequestData();
            List<Color> ListRainbow = new List<Color>();

            List<Data> datas = new List<Data>
            {
                new Data(){ name="Table", valeur = "CONFIGCOLOR" },
                new Data(){ name="Attribut", valeur = "ID_ConfCol" },
                new Data(){ name="Recherche", valeur = "1" }
            };
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, "Resto.SelectLineDGV",datas); 
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            if (BDD.SqlDr.Read())
            {
                for (int i = 0 ; i < BDD.SqlDr.FieldCount-1; i++)
                {
                    ListRainbow.Add(Color.FromArgb(Convert.ToInt32(BDD.SqlDr[i])));
                }
                Design.RandomButton = Convert.ToBoolean(BDD.SqlDr[BDD.SqlDr.FieldCount-1]);
            }
            BDD.SqlDr.Close();
            return ListRainbow;
        }

        public static Color ColorButton(Connexion BDD, string TypeProduit, string ForeOrBack)
        {
            Design ds = new Design();

            List<Color> ListRainbow = new List<Color>();
            ListRainbow.AddRange(ds.Importer_ColorBDD(BDD));

            // Mesure de sécurité : si la BDD ne contient aucune ligne, on attribue des couleurs par defaut
            if (ListRainbow.Count == 0)
            {
                ListRainbow.Add(Color.Red);
                for (int i = 1; i <= 13; i++)
                {
                    ListRainbow.Add(Color.Gray);
                    ListRainbow.Add(Color.Black);
                }
            }

            #region Attribution des couleurs :
            Color Result;
            if (ForeOrBack.ToUpper() == "BACK")
            {
                switch (TypeProduit)
                {
                    case "2": // Boissons
                        Result = ListRainbow[3]; 
                        break;
                    case "Entrée":
                    case "3": // Entrees Froides
                        Result = ListRainbow[5];
                        break;
                    case "4": // Entrees Chaudes
                        Result = ListRainbow[7];
                        break;
                        case "Plat":
                    case "5": // Plat Principal
                        Result = ListRainbow[9];
                        break;
                    case "6": // Fromage
                        Result = ListRainbow[11];
                        break;
                    case "Dessert":  
                    case "7": // Dessert
                        Result = ListRainbow[13];
                        break;
                    case "8": // Viande
                        Result = ListRainbow[15];
                        break;
                    case "9": // Poisson
                        Result = ListRainbow[17];
                        break;
                    case "10": // Legume
                        Result = ListRainbow[19];
                        break;
                    case "11": // Fruit
                        Result = ListRainbow[21];
                        break;
                    case "12": // Sauce
                        Result = ListRainbow[23];
                        break;
                    case "13": // Pain
                        Result = ListRainbow[25];
                        break;
                    case "0":
                    case "1":
                    default:
                        Result = ListRainbow[1];
                        break;
                }
            }
            else                    // FORE
            {
                switch (TypeProduit)
                {
                    case "2": // Boissons
                        Result = ListRainbow[4];
                        break;
                    case "Entrée":
                    case "3": // Entrees Froides
                        Result = ListRainbow[6];
                        break;
                    case "4": // Entrees Chaudes
                        Result = ListRainbow[8];
                        break;
                    case "Plat":
                    case "5": // Plat Principal
                        Result = ListRainbow[10];
                        break;
                    case "6": // Fromage
                        Result = ListRainbow[12];
                        break;
                    case "Dessert":    
                    case "7": // Dessert
                        Result = ListRainbow[14];
                        break;
                    case "8": // Viande
                        Result = ListRainbow[16];
                        break;
                    case "9": // Poisson
                        Result = ListRainbow[18];
                        break;
                    case "10": // Legume
                        Result = ListRainbow[20];
                        break;
                    case "11": // Fruit
                        Result = ListRainbow[22];
                        break;
                    case "12": // Sauce
                        Result = ListRainbow[24];
                        break;
                    case "13": // Pain
                        Result = ListRainbow[26];
                        break;
                    case "0":
                    case "1":
                    default:
                        Result = ListRainbow[2];
                        break;
                }
            }
            #endregion
            return Result;
        }
        #endregion      
    }
}
