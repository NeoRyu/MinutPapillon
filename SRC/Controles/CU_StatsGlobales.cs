using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinutPapillon
{
    public partial class CU_StatsGlobales : UserControl
    {
        public CU_StatsGlobales()
        {
            InitializeComponent();
        }

        #region FONCTIONS
        #endregion

        #region EVENEMENTS
        private void CU_StatsVentes_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Gestion des statistiques non implémentée", "AVERTISSEMENT");
        }
        #endregion
    }
}
