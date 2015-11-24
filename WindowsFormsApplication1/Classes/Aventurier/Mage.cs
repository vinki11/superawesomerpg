using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Aventurier
{
    //Classe avec des mauvaises statistique mais des sorts puissants. Utilise de la mana.
    class Mage : Aventuriers
    {
        #region Constructeurs
        public Mage(string pNomAventurier, int pExperience, int pNiveau)
        {
            nomAventurier = pNomAventurier;
            niveau = pNiveau;
            experience = pExperience;
            etat = Etat.Normal;
            pvactuel = pvbase = pvmax = 50;
            manaactuel = manabase = manamax = 150;
            initiativeactuel = initiativebase = 12;
            precisionactuel = precisionbase = 8;
            esquiveactuel = esquivebase = 10;
            forceactuel = forcebase = 5;
            defenseactuel = defensebase = 8;
            nomClasse = "Mage";
            ressource = Ressource.Mana;
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
