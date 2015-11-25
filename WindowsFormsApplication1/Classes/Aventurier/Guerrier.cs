using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Aventurier;
using System.Drawing;

namespace JRPG.Classes.Aventurier
{
    //Classe d'aventurier qui a une bonne attaque et defense(hp) de base. Utilise de l'energie
    class Guerrier : Aventuriers
    {

        #region Constructeurs
        public Guerrier(string pNomAventurier, int pExperience, int pNiveau)
        {
            nomAventurier = pNomAventurier;
            niveau = pNiveau;
            experience = pExperience;
            etat = Etat.Normal;
            pvactuel = pvbase = pvmax = 75;
            energieactuel = energiebase = energiemax = 100;
            initiativeactuel = initiativebase = 10;
            precisionactuel = precisionbase = 10;
            esquiveactuel = esquivebase = 8;
            forceactuel = forcebase = 15;
            defenseactuel = defensebase = 15;
            nomClasse = "Guérrier";
            ressource = Ressource.Energie;
            imageclasse = Properties.Resources.guerrier;

        }
        #endregion

        #region Fonctions
        public new void UtiliserCompetenceA()
        {

        }

        public new void UtiliserCompetenceB()
        {

        }

        public new void UtiliserCompetenceC()
        {

        }
        #endregion
    }



}
