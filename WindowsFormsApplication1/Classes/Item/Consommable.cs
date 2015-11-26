using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Item
{
    public class Consommable : Items
    {
        #region Attributs
        private int pv;
        private int mana;
        private int defense;
        private int esquive;
        private int force;
        private int precision;
        //private int initiative;
        #endregion


        #region Constructeurs
        public Consommable(int pIdItem, string pNomItem, int pPrixRevente, int pPv = 0, int pMana = 0, int pDefense = 0, int pEsquive = 0, int pForce = 0, int pPrecision = 0, bool pUtilisableGuerrier = true, bool pUtilisablePretre = true, bool pUtilisableMage = true, bool pUtilisableVoleur = true)
        {
            idItem = pIdItem;
            nomItem = pNomItem;
            prixRevente = pPrixRevente;
            pv = pPv;
            mana = pMana;
            defense = pDefense;
            esquive = pEsquive;
            force = pForce;
            precision = pPrecision;
            utilisableGuerrier = pUtilisableGuerrier;
            utilisablePretre = pUtilisablePretre;
            utilisableMage = pUtilisableMage;
            utilisableVoleur = pUtilisableVoleur;
        }
        #endregion


        #region Accesseur et Mutateur
        public int Pv
        {
            get { return this.pv; }
            set { this.pv = value; }
        }

        public int Mana
        {
            get { return this.mana; }
            set { this.mana = value; }
        }

        public int Defense
        {
            get { return this.defense; }
            set { this.defense = value; }
        }

        public int Esquive
        {
            get { return this.esquive; }
            set { this.esquive = value; }
        }

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
