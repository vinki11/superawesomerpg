using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes.Aventurier;
using System.Drawing;

namespace JRPG.Classes.Ennemi
{
    using p = Program;
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
        public StrategieAction Strategie { get; set; }


        protected string item; // Plutot faire une fonction qui determine au hasard si un item est retrouvé en loot ?
        protected string competence; //Pas un string évidamment
        
        #endregion

        #region Constructeur

        public Ennemi(int pId, string pNom, int pNiveau, int pPv, int pInitiative, int pPrecision, int pEsquive, int pForce, int pDefense, int pGainXp, int pPieces, Bitmap pImageEnnemi, StrategieAction pStrat)
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
            Strategie = pStrat;
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
            this.Strategie = pEnnemi.Strategie;
        }

        #endregion

        #region Fonctions
        public void Agir()
        {
            int cibleAleatoire;
            switch (Strategie)
            {
                case StrategieAction.AttaqueAleatoire:
                    if (p.groupeAventurier.NombreMembreVivant() == 3)
                    {
                        Random rnd = new Random();
                        cibleAleatoire = rnd.Next(1, 10);

                        if (cibleAleatoire >= 1 && cibleAleatoire <= 3)
                        {
                            MessageBox.Show(this.Nom + " attaque l'aventurier #1");
                        }
                        else if (cibleAleatoire >= 4 && cibleAleatoire <= 6)
                        {
                            MessageBox.Show(this.Nom + " attaque l'aventurier #2");
                        }
                        else if (cibleAleatoire >= 7 && cibleAleatoire <= 9)
                        {
                            MessageBox.Show(this.Nom + " attaque l'aventurier #3");
                        }
                    }
                    break;

                case StrategieAction.AttaquePlusFaible:
                    if (p.groupeAventurier.NombreMembreVivant() == 3)
                    {
                        Random rnd = new Random();
                         cibleAleatoire = rnd.Next(1, 10);
                        
                        /*if (cibleAleatoire >= 1 && cibleAleatoire <=3)
                        {
                            MessageBox.Show(this.Nom + " attaque l'aventurier #1");
                        }*/
                    }
                    break;

                case StrategieAction.AttaquePlusFort:
                    break;
            }

        }

        public void Attaquer(Aventurier.Aventurier cible)
        {

        }

        public void UtiliserCompetence()
        {
            
        }
        #endregion


        public enum StrategieAction
        {
            AttaquePlusFaible,
            AttaquePlusFort,
            AttaqueAleatoire
        };
    }
}
