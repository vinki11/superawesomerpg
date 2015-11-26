using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JRPG.Classes.Item;
using System.Threading.Tasks;


namespace JRPG.Classes.Aventurier
{
    using li = ListeItem;
    using lc = ListeClasse;
    //Classe qui a une bonne précision et esquive. Utilise de l'énergie
    class Voleur : Aventurier
    {
        #region Constructeurs
        public Voleur(string pNomAventurier, int pExperience, int pNiveau)
        {
            this.NomAventurier = pNomAventurier;
            this.Niveau = pNiveau;
            this.Experience = pExperience;
            this.Etat = Etat.Normal;
            this.Pvactuel = Pvbase = Pvmax = 60;
            this.Energieactuel = Energiebase = Energiemax = 100;
            this.Initiativeactuel = Initiativebase = 20;
            this.Precisionactuel = Precisionbase = 20;
            this.Esquiveactuel = Esquivebase = 15;
            this.Forceactuel = Forcebase = 10;
            this.Defenseactuel = Defensebase = 10;
            this.NomClasse = "Voleur";
            this.Ressource = Ressource.Energie;
            this.Imageclasse = Properties.Resources.voleur;
            this.ClassId = lc.VOLEUR_ID;
            this.Arme = li.ListeArmes[li.DAGUE_BRONZE_ID];
            this.Armure = li.ListeArmures[li.ARMURE_CUIR_ID];
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
