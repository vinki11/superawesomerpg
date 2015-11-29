using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JRPG.Classes.Aventurier
{
    using li = ListeItem;
    using lc = ListeClasse;
    //Classe qui buff et heal ses alliés principalement. Utilise de la mana.
    [Serializable]
    class Pretre : Aventurier
    {
        #region Constructeurs
        public Pretre(string pNomAventurier, int pExperience, int pNiveau)
        {
            this.NomAventurier = pNomAventurier;
            this.Niveau = pNiveau;
            this.Experience = pExperience;
            this.Etat = Etat.Normal;
            this.Pvactuel = Pvbase = Pvmax = 65;
            this.Manaactuel = Manabase = Manamax = 150;
            this.Initiativeactuel = Initiativebase = 8;
            this.Precisionactuel = Precisionbase = 8;
            this.Esquiveactuel = Esquivebase = 8;
            this.Forceactuel = Forcebase = 10;
            this.Defenseactuel = Defensebase = 12;
            this.NomClasse = "Prêtre";
            this.DescriptionClasse = "Classe de support axé sur les soins des alliés";
            this.Ressource = Ressource.Mana;
            this.Imageclasse = Properties.Resources.pretre;
            this.ClassId = lc.PRETRE_ID;
            this.Arme = li.ListeArmes[li.BATON_ID];
            this.Armure = li.ListeArmures[li.ROBE_ID];
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
