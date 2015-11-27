using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Aventurier;

namespace JRPG.Classes.Ennemi
{
    abstract class Ennemis
    {
        #region  Attributs
        public int Niveau { get; set; }
        public string Nom { get; set; }
        public Etat Etat { get; set; }
        public int Pvmax { get; set; }
        public int Pvactuel { get; set; }
        public int Initiative { get; set; }
        public int Precision { get; set; }
        public int Esquive { get; set; }
        public int Force { get; set; }
        public int Defense { get; set; }
        public int Gainxp { get; set; }
        public int Pieces { get; set; }

        protected string item; // Plutot faire une fonction qui determine au hasard si un item est retrouvé en loot ?
        protected string competence; //Pas un string évidamment
        protected string strategie; // Pas un string mais un enum et surment pas ici du tout mais juste pour pas l'oublier


        #endregion

        #region Fonctions
        protected void Agir()
        {

        }

        protected void Attaquer(Aventurier.Aventurier cible)
        {

        }

        protected void UtiliserCompetence()
        {

        }
        #endregion
    }
}
