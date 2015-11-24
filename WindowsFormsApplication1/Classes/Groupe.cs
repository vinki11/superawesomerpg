using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Item;
using JRPG.Classes.Aventurier;

namespace JRPG.Classes
{
    class Groupe
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
        public int NbPiecesOr
        {
            get { return this.nbPiecesOr; }
            set { this.nbPiecesOr = value; }
        }
        #endregion

        #region Fonctions
        public void AjouterAventurier()
        {

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
