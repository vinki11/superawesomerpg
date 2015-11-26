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
            this.NomAventurier = pNomAventurier;
            this.Niveau = pNiveau;
            this.Experience = pExperience;
            this.Etat = Etat.Normal;
            this.Pvactuel = Pvbase = Pvmax = 50;
            this.Manaactuel = Manabase = Manamax = 150;
            this.Initiativeactuel = Initiativebase = 12;
            this.Precisionactuel = Precisionbase = 8;
            this.Esquiveactuel = Esquivebase = 10;
            this.Forceactuel = Forcebase = 5;
            this.Defenseactuel = Defensebase = 8;
            this.NomClasse = "Mage";
            this.Ressource = Ressource.Mana;
            this.Imageclasse = Properties.Resources.mage;
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
