using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Item
{
    public class Armure : Items
    {
        #region Attributs
        private int defense;
        #endregion

        #region Constructeurs
        public Armure(int pIdItem, string pNomItem, int pPrixRevente, int pDefense, bool pUtilisableGuerrier, bool pUtilisablePretre, bool pUtilisableMage, bool pUtilisableVoleur)
        {
            idItem = pIdItem;
            nomItem = pNomItem;
            prixRevente = pPrixRevente;
            defense = pDefense;
            utilisableGuerrier = pUtilisableGuerrier;
            utilisablePretre = pUtilisablePretre;
            utilisableMage = pUtilisableMage;
            utilisableVoleur = pUtilisableVoleur;
        }
        #endregion

        #region Accesseurs et Mutateurs
        public int Defense
        {
            get { return this.defense; }
            set { this.defense = value; }
        }
        #endregion
    }

}