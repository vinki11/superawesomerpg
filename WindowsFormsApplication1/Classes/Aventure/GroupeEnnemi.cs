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
        public List<Ennemi.Ennemi> ListeEnnemi { get; set; }
        public int TotalPieces { get; set; }
        public int TotalXp { get; set; }
        public List<Item.Item> ListeItem { get; set; }
        #endregion

        #region Constructeurs

        public GroupeEnnemi()
        {
            ListeEnnemi = new List<Ennemi.Ennemi>();
            TotalPieces = 0;
            TotalXp = 0;
            ListeItem = new List<Item.Item>();
        }
        #endregion

        #region Fonctions

        public void AjouterEnnemi(Ennemi.Ennemi groupe)
        {
            this.ListeEnnemi.Add(groupe);
            CalculerPiecesEtXp();
        }

        private void CalculerPiecesEtXp()
        {
            int totalPiece = 0;
            int totalXp = 0;

            foreach (var ennemi in ListeEnnemi)
            {
                totalPiece += ennemi.Pieces;
                totalXp += ennemi.Gainxp;
            }

            this.TotalPieces = totalPiece;
            this.TotalXp = totalXp;
        }

        #endregion

    }
}

