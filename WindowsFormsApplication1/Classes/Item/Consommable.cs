using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Item
{
    [Serializable]
    public class Consommable : Item
    {
        #region Attributs
        public int Pv { get; set; }
        public int Mana { get; set; }
        public int Energie { get; set; }
        #endregion


        #region Constructeurs
        public Consommable(int pIdItem, string pNomItem, int pPrixRevente, int pPv = 0, int pMana = 0, int pEnergie = 0, bool pUtilisableGuerrier = true, bool pUtilisablePretre = true, bool pUtilisableMage = true, bool pUtilisableVoleur = true)
        {
            IdItem = pIdItem;
            NomItem = pNomItem;
            PrixRevente = pPrixRevente;
            Pv = pPv;
            Mana = pMana;
            Energie = pEnergie;
            UtilisableGuerrier = pUtilisableGuerrier;
            UtilisablePretre = pUtilisablePretre;
            UtilisableMage = pUtilisableMage;
            UtilisableVoleur = pUtilisableVoleur;
        }
        #endregion

    }
}
