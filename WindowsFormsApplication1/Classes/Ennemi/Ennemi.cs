using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Aventurier;
using System.Drawing;

namespace JRPG.Classes.Ennemi
{
    class Ennemi
    {
        #region  Attributs
        public int IdEnnemie { get; set; }
        public string Nom { get; set; }
        public Bitmap ImageEnnemi { get; protected set; }
        public int Niveau { get; set; }
        public Etat Etat { get; set; }
        public int PvMax { get; set; }
        public int PvActuel { get; set; }
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

        #region Constructeur

        public Ennemi(int pId, string pNom, int pNiveau, int pPv, int pInitiative, int pPrecision, int pEsquive, int pForce, int pDefense, int pGainXp, int pPieces, Bitmap pImageEnnemi)
        {
            Nom = pNom;
            Niveau = pNiveau;
            Etat = Etat.Normal;
            PvMax = PvActuel = pPv;
            Initiative = pInitiative;
            Precision = pPrecision;
            Esquive = pEsquive;
            Force = pForce;
            Defense = pDefense;
            Gainxp = pGainXp;
            Pieces = pPieces;
            ImageEnnemi = pImageEnnemi;
        }

        public Ennemi(Ennemi pEnnemi)
        {
            this.Nom = pEnnemi.Nom;
            this.Niveau = pEnnemi.Niveau;
            this.Etat = Etat.Normal;
            this.PvMax = this.PvActuel = pEnnemi.PvMax;
            this.Initiative = pEnnemi.Initiative;
            this.Precision = pEnnemi.Precision;
            this.Esquive = pEnnemi.Esquive;
            this.Force = pEnnemi.Force;
            this.Defense = pEnnemi.Defense;
            this.Gainxp = pEnnemi.Gainxp;
            this.Pieces = pEnnemi.Pieces;
            this.ImageEnnemi = pEnnemi.ImageEnnemi;
        }

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
