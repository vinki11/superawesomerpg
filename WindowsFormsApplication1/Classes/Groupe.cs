using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Item;
using JRPG.Classes.Aventurier;

namespace JRPG.Classes
{
    [Serializable]
    class Groupe
    {
        #region Attributs
        public List<Aventurier.Aventurier> Membres { get; set; }
        public int NbPiecesOr { get; set; }
        public List<Item.Item> Inventaire { get; set; }
        #endregion

        #region Constructeurs
        public Groupe()
        {
            Membres = new List<Aventurier.Aventurier>();
            NbPiecesOr = 20;
            Inventaire = new List<Item.Item>();
        }
        #endregion

        #region Fonctions
        public void AjouterAventurier(Aventurier.Aventurier nouveauAventurier)
        {
            if (Membres.Count() < 3)
            {
                Membres.Add(nouveauAventurier);
            }
        }

        public void RetirerAventurier()
        {

        }

        public void AjouterItem(Item.Item nouvelItem)
        {
            Inventaire.Add(nouvelItem);
        }

        public void RetirerItem(Item.Item ancienItem)
        {
            Inventaire.Remove(ancienItem);
        }

        public void UtiliserItem()
        {

        }
        #endregion

    }
}
