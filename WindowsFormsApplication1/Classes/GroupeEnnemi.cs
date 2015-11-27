using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Ennemi;
using JRPG.Classes.Item;

namespace JRPG.Classes
{
    class GroupeEnnemi
    {
        #region Attributs
        public List<Ennemis> ListeEnnemi { get; set; }
        public int TotalPieces { get; set; }
        public int TotalXp { get; set; }
        public List<Item.Item> ListeItem { get; set; }
        #endregion

        #region Constructeurs
        // J'ai fait le constructeur par défaut et non paramétré car je crois qu'on risque de geré les groupes par des fonctions mais la personne
        // qui le fera verra en temps et lieu (xp et pieces calculé assuré et non par constructeur)
        public GroupeEnnemi() 
        {
            ListeEnnemi = new List<Ennemis>();
            TotalPieces = 0;
            TotalXp = 0;
            ListeItem = new List<Item.Item>();
        }
        #endregion

    }
}

