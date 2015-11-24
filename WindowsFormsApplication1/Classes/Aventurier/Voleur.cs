using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Classe qui a une bonne précision et esquive. Utilise de l'énergie
namespace JRPG.Classes.Aventurier
{
    class Voleur : Aventuriers
    {
        public Voleur()
        {
            etat = Etat.Normal;
            pvactuel = pvbase = pvmax = 60;
            energieactuel = energiebase = energiemax = 100;
            initiativeactuel = initiativebase = 20;
            precisionactuel = precisionbase = 20;
            esquiveactuel = esquivebase = 15;
            forceactuel = forcebase = 10;
            defenseactuel = defensebase = 10;
            nomClasse = "Voleur";
            ressource = Ressource.Energie;
        }

        public Voleur(string pNomAventurier, int pExperience, int pNiveau)
        {
            nomAventurier = pNomAventurier;
            niveau = pNiveau;
            experience = pExperience;
        }



        public new void UtiliserCompetenceA()
        {

        }

        public new void UtiliserCompetenceB()
        {

        }

        public new void UtiliserCompetenceC()
        {

        }

    }
}
