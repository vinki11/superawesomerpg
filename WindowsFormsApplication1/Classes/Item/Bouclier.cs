using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Item
{
    public class Bouclier : Item
    {
        #region Attributs
        public int Esquive { get; set; }
        #endregion

        #region Constructeurs
        public Bouclier(int pIdItem, string pNomItem, int pPrixRevente, int pEsquive,  bool pUtilisableGuerrier = false, bool pUtilisablePretre = false, bool pUtilisableMage = false, bool pUtilisableVoleur = false)
        {
            IdItem = pIdItem;
            NomItem = pNomItem;
            PrixRevente = pPrixRevente;
            Esquive = pEsquive;
            UtilisableGuerrier = pUtilisableGuerrier;
            UtilisablePretre = pUtilisablePretre;
            UtilisableMage = pUtilisableMage;
            UtilisableVoleur = pUtilisableVoleur;
        }
        #endregion
    }
}
