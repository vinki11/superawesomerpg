using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Item;
using JRPG.Classes.Aventurier;

namespace JRPG.Classes
{
    public class Groupe
    {
        #region Attributs
        protected List<Aventuriers> membres;
        protected int nbPiecesOr;
        protected List<Items> inventaire;
        #endregion

        #region Constructeurs
        public Groupe()
        {
            membres = new List<Aventuriers>();
            nbPiecesOr = 20;
            inventaire = new List<Items>();
        }
        #endregion

        #region Accesseurs et mutateurs
        public List<Aventuriers> Membres
        {
            get { return this.membres; }
            set { this.membres = value; }
        }

        public int NbPiecesOr
        {
            get { return this.nbPiecesOr; }
            set { this.nbPiecesOr = value; }
        }

        public List<Items> Inventaire
        {
            get { return this.inventaire; }
            set { this.inventaire = value; }
        }
        #endregion

        #region Fonctions
        public void AjouterAventurier(Aventuriers nouveauAventurier)
        {
            if (membres.Count() < 3)
            {
                membres.Add(nouveauAventurier);
            }
        }

        public void RetirerAventurier()
        {

        }

        public void AjouterItem()
        {

        }

        public void UtiliserItem()
        {

        }
        #endregion

    }
}
