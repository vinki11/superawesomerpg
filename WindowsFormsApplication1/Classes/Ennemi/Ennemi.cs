using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Aventurier;

namespace JRPG.Classes.Ennemi
{
    public abstract class Ennemis
    {
        #region  Attributs
        protected int niveau;
        protected string nom;
        protected Etat etat;
        protected int pvmax;
        protected int pvactuel;
        protected int initiative;
        protected int precision;
        protected int esquive;
        protected int force;
        protected int defense;
        protected int gainxp;
        protected int pieces;

        protected string item; // Plutot faire une fonction qui determine au hasard si un item est retrouvé en loot ?
        protected string competence; //Pas un string évidamment
        protected string strategie; // Pas un string mais un enum et surment pas ici du tout mais juste pour pas l'oublier


        #endregion


        #region Accesseurs et mutateurs
        public int Niveau
        {
            get { return this.niveau; }
            set { this.niveau = value; }
        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        public Etat Etat
        {
            get { return this.etat; }
            set { this.etat = value; }
        }

        public int Pvmax
        {
            get { return this.pvmax; }
            set { this.pvmax = value; }
        }

        public int Pvactuel
        {
            get { return this.pvactuel; }
            set { this.pvactuel = value; }
        }

        public int Initiative
        {
            get { return this.initiative; }
            set { this.initiative = value; }
        }

        public int Precision
        {
            get { return this.precision; }
            set { this.precision = value; }
        }

        public int Esquive
        {
            get { return this.esquive; }
            set { this.esquive = value; }
        }

        public int Force
        {
            get { return this.force; }
            set { this.force = value; }
        }

        public int Defense
        {
            get { return this.defense; }
            set { this.defense = value; }
        }
        public int Gainxp
        {
            get { return this.gainxp; }
            set { this.gainxp = value; }
        }

        public int Pieces
        {
            get { return this.pieces; }
            set { this.pieces = value; }
        }
        #endregion

        #region Fonctions
        protected void Agir()
        {

        }

        protected void Attaquer(Aventuriers cible)
        {

        }

        protected void UtiliserCompetence()
        {

        }
        #endregion
    }
}
