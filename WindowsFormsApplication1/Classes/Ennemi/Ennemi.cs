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
        protected int niveau;
        protected string nom;
        protected string etat; //changer string pour un enum etat
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


        //Verif le reste

        protected string competence; //Pas un string évidamment
        protected string strategie; // Pas un string mais un enum et surment pas ici du tout mais juste pour pas l'oublier

        protected void Agir()
        {

        }

        protected void Attaquer(Aventuriers cible)
        {

        }

        protected void UtiliserCompetence()
        {

        }
    }
}
