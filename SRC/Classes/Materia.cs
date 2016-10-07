using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librairies supplémentaires :
using System.Windows.Forms;         // textbox etc

namespace MinutPapillon
{
    class Materia
    {
        #region GESTION DES RECHERCHES ( CU_Rechercher )
        public class Desc
        {
            public string Text { get; set; }
            public string Descript { get; set; }
        }

        public string Combobox_Search_Description(string NomDeLaTable, string ChampSelect)
        {
            List<Desc> Description = new List<Desc>();
            switch (NomDeLaTable)
            {
                #region UTILISATEUR
                case "UTILISATEUR":
                    {
                        Description.Add(new Desc() { Text = "", Descript = "" });
                        Description.Add(new Desc() { Text = "Pseudonyme", Descript = "ex : Serveur1" });
                        Description.Add(new Desc() { Text = "Mot de passe", Descript = "ex : T8f7Ftr" });
                        Description.Add(new Desc() { Text = "Nom de famille", Descript = "ex : Dupont" });
                        Description.Add(new Desc() { Text = "Prénom", Descript = "ex : Jean" });
                        Description.Add(new Desc() { Text = "Numéro de téléphone", Descript = "ex : 0123456789" });
                        break;
                    }
                #endregion
                #region CARTE
                case "CARTE":
                    {
                        Description.Add(new Desc() { Text = "", Descript = "" });
                        Description.Add(new Desc() { Text = "Nom de l'article", Descript = "ex : Pizza" });
                        Description.Add(new Desc() { Text = "Format / Description", Descript = "ex : 25cl" });
                        Description.Add(new Desc() { Text = "Prix HT", Descript = "ex : 1.23" });
                        Description.Add(new Desc() { Text = "Quantité en Stock", Descript = "(supérieur ou egal à) ex : 10" });
                        Description.Add(new Desc() { Text = "Article dispo", Descript = "dispo : true / indispo : false" });
                        Description.Add(new Desc() { Text = "En supplément", Descript = "ex : true / false" });
                        Description.Add(new Desc() { Text = "Alcoolisé", Descript = "ex : true / false" });
                        break;
                    }
                #endregion
                #region MENU
                case "MENU":
                    {
                        Description.Add(new Desc() { Text = "", Descript = "" });
                        Description.Add(new Desc() { Text = "Nom du menu", Descript = "ex : Menu Italien" });
                        Description.Add(new Desc() { Text = "Menu disponible", Descript = "ex : true / false" });
                        Description.Add(new Desc() { Text = "Prix TTC (= ou sup)", Descript = "(supérieur ou egal à) ex : 1.23" });
                        break;
                    }
                #endregion
                #region FACTURE
                case "FACTURE":
                    {
                        Description.Add(new Desc() { Text = "", Descript = "" });
                        Description.Add(new Desc() { Text = "Numéro de facture", Descript = "ex : 0" });
                        Description.Add(new Desc() { Text = "Date de facturation", Descript = "format : AA/MM/JJ" });
                        Description.Add(new Desc() { Text = "Numéro de table", Descript = "ex : 4" });
                        Description.Add(new Desc() { Text = "Nombre de ouverts", Descript = "ex : 2" });
                        Description.Add(new Desc() { Text = "Prix Total TTC (= ou sup)", Descript = "" });
                        Description.Add(new Desc() { Text = "Facture Validée", Descript = "ex : true / false" });
                        Description.Add(new Desc() { Text = "Facture Cloturée", Descript = "ex : true / false" });
                        Description.Add(new Desc() { Text = "Facture Modifiée", Descript = "ex : true / false" });
                        break;
                    }
                #endregion
                #region STOCK
                case "STOCK":
                    {
                        Description.Add(new Desc() { Text = "", Descript = "" });
                        Description.Add(new Desc() { Text = "Nom de l'article", Descript = "ex : Salade" });
                        Description.Add(new Desc() { Text = "Nom du fournisseur", Descript = "ex : Monbonbio" });
                        Description.Add(new Desc() { Text = "Date d'achat", Descript = "format : AA/MM/JJ" });
                        Description.Add(new Desc() { Text = "Prix d'achat unitaire", Descript = "ex : 1.23" });
                        break;
                    }
                #endregion
                #region STATSCONSO
                case "STATSCONSO":
                    {
                        Description.Add(new Desc() { Text = "", Descript = "" });
                        Description.Add(new Desc() { Text = "Vendu(s) [Carte]", Descript = "(supérieur ou egal à) ex : 10" });
                        Description.Add(new Desc() { Text = "Vendu(s) [Menu]", Descript = "(supérieur ou egal à) ex : 10" });
                        Description.Add(new Desc() { Text = "Offert [supplément]", Descript = "(supérieur ou egal à) ex : 10" });
                        Description.Add(new Desc() { Text = "Détruit", Descript = "(supérieur ou egal à) ex : 10" });
                        break;
                    }
                #endregion
                default:
                    break;
            }
            foreach (Desc TexteDesc in Description)
            {
                if (ChampSelect == TexteDesc.Text)
                    return TexteDesc.Descript;
            }
            return "Rechercher...";
        }
        #endregion

        #region AFFICHAGE DES NOMS DE COLONNES DU DATAGRIDVIEW
        public void affichageNomColonne(string nomTable, DataGridView dgv)
        {
            switch (nomTable)
            {
                case "UTILISATEUR":
                    dgv.Columns[0].HeaderText = "Identifiant";
                    dgv.Columns[1].HeaderText = "Pseudo";
                    dgv.Columns[2].HeaderText = "Mot de Passe";
                    dgv.Columns[3].HeaderText = "Nom";
                    dgv.Columns[4].HeaderText = "Prénom";
                    dgv.Columns[5].HeaderText = "N° Tel";
                    dgv.Columns[6].HeaderText = "ID rôle";
                    break;
                case "CARTE":
                    dgv.Columns[0].HeaderText = "Identifiant";
                    dgv.Columns[1].HeaderText = "Disponible";
                    dgv.Columns[2].HeaderText = "Nom";
                    dgv.Columns[3].HeaderText = "Description";
                    dgv.Columns[4].HeaderText = "Prix H.T.";
                    dgv.Columns[5].HeaderText = "Supplément";
                    dgv.Columns[6].HeaderText = "Préférence";
                    dgv.Columns[7].HeaderText = "Alcoolisé";
                    dgv.Columns[8].HeaderText = "Image du Produit";
                    dgv.Columns[9].HeaderText = "Quantité";
                    dgv.Columns[10].HeaderText = "Type Produit";
                    dgv.Columns[11].HeaderText = "TVA";
                    break;
                case "MENU":
                    dgv.Columns[0].HeaderText = "Identifiant";
                    dgv.Columns[1].HeaderText = "Disponible";
                    dgv.Columns[2].HeaderText = "Description";
                    dgv.Columns[3].HeaderText = "Date d'ajout";
                    dgv.Columns[4].HeaderText = "Prix T.T.C.";
                    break;
                case "FACTURE":
                    dgv.Columns[0].HeaderText = "Facture";
                    dgv.Columns[1].HeaderText = "Pseudo";
                    dgv.Columns[2].HeaderText = "Date Création";
                    dgv.Columns[3].HeaderText = "Validée";
                    dgv.Columns[4].HeaderText = "Cloturée";
                    dgv.Columns[5].HeaderText = "Modifiée";
                    dgv.Columns[6].Visible = false;
                    dgv.Columns[7].HeaderText = "Article";
                    dgv.Columns[8].HeaderText = "Menu";
                    dgv.Columns[9].HeaderText = "Qte";
                    dgv.Columns[10].HeaderText = "Pref";
                    dgv.Columns[11].HeaderText = "VoirServeur";
                    dgv.Columns[12].HeaderText = "Offert";
                    dgv.Columns[13].HeaderText = "Prix HT";
                    break;
            }
        }
        #endregion
    }
}
