using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Item
{
    [Serializable]
    public class Arme : Item
    {
        #region Attributs
        public int Force { get; set; }
        public int Precision { get; set; }
        #endregion

        #region Constructeurs
        public Arme(int pIdItem, string pNomItem, int pPrixRevente, int pForce, int pPrecision, bool pUtilisableGuerrier = false, bool pUtilisablePretre = false, bool pUtilisableMage = false, bool pUtilisableVoleur = false)
        {
            IdItem = pIdItem;
            NomItem = pNomItem;
            PrixRevente = pPrixRevente;
            Force = pForce;
            Precision = pPrecision;
            UtilisableGuerrier = pUtilisableGuerrier;
            UtilisablePretre = pUtilisablePretre;
            UtilisableMage = pUtilisableMage;
            UtilisableVoleur = pUtilisableVoleur;
        }
        #endregion
        

    }
}
