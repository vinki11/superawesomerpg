using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Item
{
    class Bouclier : Items
    {
        #region Attributs
        private int esquive;
        #endregion

        #region Constructeurs
        public Bouclier(string pNomItem, int pPrixRevente, int pEsquive,  bool pUtilisableGuerrier, bool pUtilisablePretre, bool pUtilisableMage, bool pUtilisableVoleur)
        {
            nomItem = pNomItem;
            prixRevente = pPrixRevente;
            esquive = pEsquive;
            utilisableGuerrier = pUtilisableGuerrier;
            utilisablePretre = pUtilisablePretre;
            utilisableMage = pUtilisableMage;
            utilisableVoleur = pUtilisableVoleur;
        }
        #endregion

        #region Accesseurs et Mutateurs
        public int Esquive
        {
            get { return this.esquive; }
            set { this.esquive = value; }
        }
        #endregion
    }
}
