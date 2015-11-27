using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Item
{
    public class Armure : Item
    {
        #region Attributs
        public int Defense { get; set; }
        #endregion

        #region Constructeurs
        public Armure(int pIdItem, string pNomItem, int pPrixRevente, int pDefense, bool pUtilisableGuerrier = false, bool pUtilisablePretre = false, bool pUtilisableMage = false, bool pUtilisableVoleur = false)
        {
            IdItem = pIdItem;
            NomItem = pNomItem;
            PrixRevente = pPrixRevente;
            Defense = pDefense;
            UtilisableGuerrier = pUtilisableGuerrier;
            UtilisablePretre = pUtilisablePretre;
            UtilisableMage = pUtilisableMage;
            UtilisableVoleur = pUtilisableVoleur;
        }
        #endregion
        
    }

}