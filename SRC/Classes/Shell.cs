using System;
using System.Collections.Generic;   // Gestion des List<>
using System.Text;                  // Gestion des stringbuilder

#region Librairies par defaut desactivées :
// using System.Linq;
// using System.Threading.Tasks;
#endregion

// Librairies supplémentaires :
using System.Data.SqlClient;            // Gestion des Erreurs SQL & tt ce qui est Base de données
using System.Windows.Forms;             // Pour pouvoir gérer les types et les fonctions system
using System.IO;                        // StringReader
using System.Text.RegularExpressions;   // Regex

namespace MinutPapillon
{
    // TOUT CE QUI CONCERNE LA PROTECTION, VERIFICATION DES DONNEES, ...
    class Shell
    {
        #region [SNIPPET] GESTION DES ERREURS
        public class Error
        {
            // FONCTION DE GESTION D'ERREURS GENEREES VIA DES REQUETES SQL
            public void SQL_Error(SqlException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // FONCTION DE GESTION D'ERREURS GENEREES PAR LE CODE SOURCE DE L'APPLICATION
            public void C_Error(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        // NETTOYAGE DES INSERTIONS DE DONNEES
        public class Sanitize
        {
            #region [SNIPPET] EXTRACTION DE CHIFFRES
            public string SearchNumInString(string AnalyseMe)
            {
                string ReturnMe = "";
                Regex rgx = new Regex(@"\b*\d+(,?|.?)\d*\b");  
                MatchCollection matches = rgx.Matches(AnalyseMe);
                foreach (Match m in matches)
                {
                    ReturnMe += m.Value;
                }
                return ReturnMe;
            }
            #endregion

            #region [SNIPPET] CONVERSION EN LETTRES NON ACCENTUEES
            public string SnippetParseurNoAccent(string chaine)
            {
                // Déclaration de variables
                string accent = "ÀÁÂÃÄÅàáâãäåÒÓÔÕÖØòóôõöøÈÉÊËèéêëÌÍÎÏìíîïÙÚÛÜùúûüÿÑñÇç";
                string sansAccent = "AAAAAAaaaaaaOOOOOOooooooEEEEeeeeIIIIiiiiUUUUuuuuyNnCc";

                // Conversion des chaines en tableaux de caractères
                char[] tableauSansAccent = sansAccent.ToCharArray();
                char[] tableauAccent = accent.ToCharArray();

                // Pour chaque accent
                for (int i = 0; i < accent.Length; i++)
                {
                    // Remplacement de l'accent par son équivalent sans accent dans la chaîne de caractères
                    chaine = chaine.Replace(tableauAccent[i].ToString(), tableauSansAccent[i].ToString());
                }

                // Retour du résultat
                return chaine;
            }
            #endregion

            #region [SNIPPET] PARSEUR XSS TEXTBOX ( TODO )
            public void Parseur_XSS_TbControl(TextBox mytb, string mypat)
            {
                // AIDE MICROSOFT : https://msdn.microsoft.com/fr-fr/library/az24scfc%28v=vs.110%29.aspx

                // On definit le pattern à utiliser :
                string pattern;                         
                switch (mypat)
                {
                    case "alphabetique":                // TODO : Gerer aussi les espaces !!!
                        pattern = @"[^A-Za-z\s]";         // @"[^A-Za-z{1,}\-{1}]"; TODO : L'integration des tirets pose un probleme de securité SQL...
                        break;
                    case "alpha'num" :
                        pattern = @"[^\w\'\:\s\/]";
                        break;
                    case "int":
                        pattern = @"[^\d]";
                        break;
                    case "float":
                        pattern = @"[^\d\.\,]";
                        break;                    
                    case "bool":
                        pattern = @"[^01]"; 
                        break;

                    // TODO [ A VERIFIER ] :
                    case "telephone":
                        pattern = @"[^\+{0,1}\d{10,11}]";
                        break;
                    case "url" :
                        pattern = @"/(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/"; 
                        break;
                    case "":
                    default :
                        pattern = @"[^\w\s\'\.\:\,]";
                        break;
                }
                // On instancie l'expression régulière (regex)
                Regex reg = new Regex(pattern);

                // Si on sort des limites du pattern
                if (reg.IsMatch(mytb.Text))
                    // On annule le symbole 
                    mytb.Text = reg.Replace(mytb.Text, "");
                
            }
            #endregion

            public string replaceTiret(string text)
            {
                // Evite les injections de données par double tiret (ex : login="" where 1=1 --password="textbox"; <- portion mise en commentaire...)
                string ParseurTiret = text.Replace("--", "-");
                // TODO : Verifier que si on met ---, la fonction retourne bien - et non -- ! (etc si on en met plus)
                //   ex :      while text.contient("--") ParseurTiret = text.Replace("--", "-");
                return ParseurTiret;
            }

            #region [SNIPPET] CONVERSION VIRGULE > POINT
            // Pour les float, on convertit les , (saisie utilisateur) par un point (comprehension BDD)
            public string replacePerPoint(string text)
            {
                return text.Replace(',', '.');
            }
            #endregion

            #region [SNIPPET] CONVERSION UNICODE DE 'QUOTE'
            // Remplace la Quote (') par son code UNICODE pour éviter les erreurs lors d'un clique sur un bouton de la carte ou menu 
            public string replaceQuote(string nom)
            {
                return nom.Replace('\'', '\u0066');
            }
            #endregion
        }
        #region [SNIPPET] GENERATION DE NOMBRE ALEATOIRE
        private static readonly object synLock = new object();
        private static readonly Random RandomButton = new Random();
        public static int GenNbrAleat(int mini, int maxi)
        {
            lock (synLock)
            {
                return RandomButton.Next(mini, maxi);
            }
        }
        #endregion

        #region GESTION DE SELECTION DU BON ID DANS LA BDD
        // Fonction qui retourne l'ID necessaire a l'import dans les Control_User
        public string SelectGoodID_Name(Connexion BDD, string Nomtable)
        {
            RequestData r = new RequestData();

            // Declaration des Variable
            string Query = "Resto.RechercherClefs";
            List<Data> Param = new List<Data>
                {
                    new Data(){ name="NomTable", valeur = Nomtable },
                    new Data(){ name="TypeClef",   valeur = "0" }
                };
            string IDResult = "";

            // On execute la requete
            BDD.SqlCmd = r.TraitementRequest(BDD.cnx, Query, Param);
            BDD.SqlDr = BDD.SqlCmd.ExecuteReader();

            // Pendant la lecture dans la base de donnée
            while (BDD.SqlDr.Read())
            {
                // On récupère la clef primaire correspondant a la colonne
                IDResult = BDD.SqlDr[0].ToString();
            }
            BDD.SqlDr.Close();
            return IDResult;
        }
        #endregion
    }
}
