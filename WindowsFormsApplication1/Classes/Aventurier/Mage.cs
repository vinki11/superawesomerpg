using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JRPG.Classes.Item;
using System.Threading.Tasks;

namespace JRPG.Classes.Aventurier
{
    using li = ListeItem;
    using lc = ListeClasse;
    //Classe avec des mauvaises statistique mais des sorts puissants. Utilise de la mana.
    [Serializable]
    class Mage : Aventurier
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
            this.Defenseactuel = Defensebase = 2;
            this.NomClasse = "Mage";
            this.DescriptionClasse = "Spécialiste de la magie avec des attributs faibles mais des sorts offensifs puissants";
            this.Ressource = Ressource.Mana;
            this.Imageclasse = Properties.Resources.mage;
            this.ClassId = lc.MAGE_ID;
            this.Arme = li.ListeArmes[li.BATON_ID];
            this.Armure = li.ListeArmures[li.ROBE_ID];
            this.NomCompetenceA = "Éclair"; //Single damage spell
            this.NomCompetenceB = "Boule de feu"; //Aoe Spell
            this.NomCompetenceC = "Placeholder";
            this.CibleCompetenceA = Cible.Enemy;
            this.CibleCompetenceB = Cible.AllEnemies;
            this.CibleCompetenceC = Cible.Enemy;
            this.CoutCompetenceA = 30;
            this.CoutCompetenceB = 30;
            this.CoutCompetenceC = 30;
            this.ImageCompetenceA = Properties.Resources.attaque;
            this.ImageCompetenceB = Properties.Resources.attaque;
            this.ImageCompetenceC = Properties.Resources.attaque;
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

        public override string MonterNiveauExperience()
        {
            string strLevelUp = "";

            int upPv = 5;
            int upMana = 20;
            int upInitiative = 3;
            int upPrecision = 2;
            int upEsquive = 2;
            int upForce = 2;
            int upDefense = 2;

            base.MonterNiveauExperience();
            this.Pvactuel = Pvbase = Pvmax += upPv;
            this.Manaactuel = Manabase = Manamax += upMana;
            this.Initiativeactuel = Initiativebase += upInitiative;
            this.Precisionactuel = Precisionbase += upPrecision;
            this.Esquiveactuel = Esquivebase += upEsquive;
            this.Forceactuel = Forcebase += upForce;
            this.Defenseactuel = Defensebase += upDefense;

            strLevelUp += NomAventurier + " a monté de niveau!";
            strLevelUp += "\r\nNiveau: " + Niveau;
            strLevelUp += "\r\nPV: +" + upPv;
            strLevelUp += "\r\nMana: +" + upMana;
            strLevelUp += "\r\nInitiative: +" + upInitiative;
            strLevelUp += "\r\nPrécision: +" + upPrecision;
            strLevelUp += "\r\nEsquive: +" + upEsquive;
            strLevelUp += "\r\nForce: +" + upForce;
            strLevelUp += "\r\nDefense: +" + upDefense;

            return strLevelUp;
        }
        #endregion
    }
}
