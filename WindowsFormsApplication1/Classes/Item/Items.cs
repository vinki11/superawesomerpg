using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Item
{
    abstract class Items
    {
        #region Attributs
        protected string nomItem;
        //protected Categorie categorieItem; //C'est tu vrm valable d'avoir l'attribut et l'enum ou je suis mieu avoir simplement l'heritage
        protected int prixRevente;
        protected bool utilisableGuerrier;
        protected bool utilisablePretre;
        protected bool utilisableMage;
        protected bool utilisableVoleur;
        #endregion

        #region Accesseurs et Mutateurs
        public string NomItem
        {
            get { return this.nomItem; }
            set { this.nomItem = value; }
        }

        public int PrixRevente
        {
            get { return this.prixRevente; }
            set { this.prixRevente = value; }
        }


        public bool UtilisableGuerrier
        {
            get { return this.utilisableGuerrier; }
            set { this.utilisableGuerrier = value; }
        }

        public bool UtilisablePretre
        {
            get { return this.utilisablePretre; }
            set { this.utilisablePretre = value; }
        }

        public bool UtilisableMage
        {
            get { return this.utilisableMage; }
            set { this.utilisableMage = value; }
        }

        public bool UtilisableVoleur
        {
            get { return this.utilisableVoleur; }
            set { this.utilisableVoleur = value; }
        }
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
