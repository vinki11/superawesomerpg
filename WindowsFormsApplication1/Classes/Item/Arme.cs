using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Item
{
    public class Arme : Items
    {
        #region Attributs
        private int force;
        private int precision;
        #endregion

        #region Constructeurs
        public Arme(int pIdItem, string pNomItem, int pPrixRevente, int pForce, int pPrecision, bool pUtilisableGuerrier = false, bool pUtilisablePretre = false, bool pUtilisableMage = false, bool pUtilisableVoleur = false)
        {
            idItem = pIdItem;
            nomItem = pNomItem;
            prixRevente = pPrixRevente;
            force = pForce;
            precision = pPrecision;
            utilisableGuerrier = pUtilisableGuerrier;
            utilisablePretre = pUtilisablePretre;
            utilisableMage = pUtilisableMage;
            utilisableVoleur = pUtilisableVoleur;
        }
        #endregion

        #region Accesseurs et Mutateurs
        public int Force
        {
            get { return this.force; }
            set { this.force = value; }
        }

        public int Precision
        {
            get { return this.precision; }
            set { this.precision = value; }
        }
        #endregion

    }
}
