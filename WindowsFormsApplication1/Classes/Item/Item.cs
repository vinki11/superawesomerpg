using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Item
{
    [Serializable]
    public abstract class Item
    {
        #region Attributs
        public int IdItem { get; set; }
        public string NomItem { get; set; }
        public int PrixRevente { get; set; }
        public bool UtilisableGuerrier { get; set; }
        public bool UtilisablePretre { get; set; }
        public bool UtilisableMage { get; set; }
        public bool UtilisableVoleur { get; set; }
        #endregion

        
    }

    /*enum Categorie
    {
        Arme,
        Armure,
        Bouclier,
        Consommable
    }*/
}
