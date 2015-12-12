using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using JRPG.Classes.Aventurier;
using JRPG.Classes.Item;
using System.Drawing;

namespace JRPG.Classes.Aventurier
{
    using li = ListeItem;
    using lc = ListeClasse;
    //Classe d'aventurier qui a une bonne attaque et defense(hp) de base. Utilise de l'energie
    [Serializable]
    class Guerrier : Aventurier
    {

        #region Constructeurs
        public Guerrier(string pNomAventurier, int pExperience, int pNiveau)
        {
            this.NomAventurier = pNomAventurier;
            this.Niveau = pNiveau;
            this.Experience = pExperience;
            this.Etat = Etat.Normal;
            this.Pvactuel = Pvbase = Pvmax = 75;
            this.Energieactuel = Energiebase = Energiemax = 100;
            this.Initiativeactuel = Initiativebase = 10;
            this.Precisionactuel = Precisionbase = 10;
            this.Esquiveactuel = Esquivebase = 8;
            this.Forceactuel = Forcebase = 15;
            this.Defenseactuel = Defensebase = 2;
            this.NomClasse = "Guérrier";
            this.DescriptionClasse = "Combattant au corps à corps avec une bonne force et défense";
            this.Ressource = Ressource.Energie;
            this.Imageclasse = Properties.Resources.guerrier;
            this.ClassId = lc.GUERRIER_ID;
            this.Arme = li.ListeArmes[li.EPEE_BRONZE_ID];
            this.Armure = li.ListeArmures[li.ARMURE_BRONZE_ID];
            this.Bouclier = li.ListeBoucliers[li.BOUCLIER_BOIS_ID];
            this.NomCompetenceA = "Coup perçant"; // piercing strike en francais ? Kekechose qui ignore un pourcentage de la def de l'ennemi
            this.NomCompetenceB = "Cri de guerre"; //Buff self ou allallies ? ?
            this.NomCompetenceC = "Placeholder";
            this.CibleCompetenceA = Cible.Enemy;
            this.CibleCompetenceB = Cible.AllAllies;
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
        public override string UtiliserCompetenceA(Ennemi.Ennemi ennemi)
        {
            return "";
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
            int upPv = 10;
            int upInitiative = 2;
            int upPrecision = 2;
            int upEsquive = 2;
            int upForce = 4;
            int upDefense = 3;

            base.MonterNiveauExperience();
            this.Pvactuel = Pvbase = Pvmax += upPv;
            this.Initiativeactuel = Initiativebase += upInitiative;
            this.Precisionactuel = Precisionbase += upPrecision;
            this.Esquiveactuel = Esquivebase += upEsquive;
            this.Forceactuel = Forcebase += upForce;
            this.Defenseactuel = Defensebase += upDefense;

            strLevelUp += NomAventurier + " a monté de niveau!";
            strLevelUp += "\r\nNiveau: " + Niveau;
            strLevelUp += "\r\nPV: +" + upPv;
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
