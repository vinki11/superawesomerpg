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
        protected List<Ennemis> listeEnnemi;
        protected int totalPieces;
        protected int totalXp;
        protected List<Items> listeItem;
        #endregion

        #region Constructeurs
        // J'ai fait le constructeur par défaut et non paramétré car je crois qu'on risque de geré les groupes par des fonctions mais la personne
        // qui le fera verra en temps et lieu (xp et pieces calculé assuré et non par constructeur)
        public GroupeEnnemi() 
        {
            listeEnnemi = new List<Ennemis>();
            totalPieces = 0;
            totalXp = 0;
            listeItem = new List<Items>();
        }
        #endregion

        #region Accesseurs et mutateurs
        public List<Ennemis> ListeEnnemi
        {
            get { return this.listeEnnemi; }
            set { this.listeEnnemi = value; }
        }

        public int TotalPieces
        {
            get { return this.totalPieces; }
            set { this.totalPieces = value; }
        }

        public int TotalXp
        {
            get { return this.totalXp; }
            set { this.totalXp = value; }
        }


        public List<Items> ListeItem
        {
            get { return this.listeItem; }
            set { this.listeItem = value; }
        }
        #endregion

    }
}

