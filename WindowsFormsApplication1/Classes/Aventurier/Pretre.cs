using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JRPG.Classes.Aventurier
{
    //Classe qui buff et heal ses alliés principalement. Utilise de la mana.
    class Pretre : Aventuriers
    {
        #region Constructeurs
        public Pretre(string pNomAventurier, int pExperience, int pNiveau)
        {
            nomAventurier = pNomAventurier;
            niveau = pNiveau;
            experience = pExperience;
            etat = Etat.Normal;
            pvactuel = pvbase = pvmax = 65;
            manaactuel = manabase = manamax = 150;
            initiativeactuel = initiativebase = 8;
            precisionactuel = precisionbase = 8;
            esquiveactuel = esquivebase = 8;
            forceactuel = forcebase = 10;
            defenseactuel = defensebase = 12;
            nomClasse = "Prêtre";
            ressource = Ressource.Mana;
            imageclasse = Properties.Resources.pretre;
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
