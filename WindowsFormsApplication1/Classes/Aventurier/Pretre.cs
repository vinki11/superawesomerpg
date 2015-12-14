using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            this.Pvactuel = Pvbase = Pvmax = 55;
            this.Manaactuel = Manabase = Manamax = 150;
            this.Initiativeactuel = Initiativebase = 8;
            this.Precisionactuel = Precisionbase = 8;
            this.Esquiveactuel = Esquivebase = 8;
            this.Forceactuel = Forcebase = 10;
            this.Defenseactuel = Defensebase = 2;
            this.NomClasse = "Prêtre";
            this.DescriptionClasse = "Classe de support axé sur les soins des alliés";
            this.Ressource = Ressource.Mana;
            this.Imageclasse = Properties.Resources.pretre;
            this.ClassId = lc.PRETRE_ID;
            this.Arme = li.ListeArmes[li.BATON_ID];
            this.Armure = li.ListeArmures[li.ROBE_ID];
            this.NomCompetenceA = "Sort de lumière"; //Petit dmg sur un ennemi
            this.NomCompetenceB = "Soins"; //Soigne 1 allié
            this.NomCompetenceC = "Protection"; //Augmente la def d'un allié pour le combat
            this.CibleCompetenceA = Cible.Enemy;
            this.CibleCompetenceB = Cible.Ally;
            this.CibleCompetenceC = Cible.Ally;
            this.CoutCompetenceA = 15;
            this.CoutCompetenceB = 20;
            this.CoutCompetenceC = 15;
            this.ImageCompetenceA = Properties.Resources.lumiere;
            this.ImageCompetenceB = Properties.Resources.soins;
            this.ImageCompetenceC = Properties.Resources.protection;
            this.EsquiveBuff = false;
            this.DefenseBuff = false;
            this.PrecisionBuff = false;
            this.ForceBuff = false;
        }
        #endregion


        #region Fonctions
        public override string UtiliserCompetenceA(Ennemi.Ennemi cible)
        {
            int degatAttaque = 0;
            string strAction = "";
            Random rnd = new Random();
            int chiffreAleatoire = rnd.Next(0, 10);

            strAction = this.NomAventurier + " lance un sort de lumière vers " + cible.Nom;
            if (chiffreAleatoire > 2)
            {
                degatAttaque = 5 + (this.Niveau * 3);
                cible.PvActuel -= degatAttaque;

                strAction += "\r\n" + this.NomAventurier + " à touché la cible et infligé : " + degatAttaque + " points de dégats!";

                if (cible.PvActuel <= 0)
                {
                    cible.Etat = Etat.Mort;
                    strAction += "\r\n" + cible.Nom + " est mort!";
                }


                //MessageBox.Show(strAction);

            }
            else
            {
                strAction += "\r\n" + this.NomAventurier + " à manqué la cible!";
                //MessageBox.Show(strAction);
            }

            this.Manaactuel -= this.CoutCompetenceA;
            return strAction;
        }

        public override string UtiliserCompetenceB(Aventurier cible)
        {
            string strAction = "";
            int soins;

            strAction = this.NomAventurier + " lance un sort de soins sur " + cible.NomAventurier;

            soins = 15 + (5 * this.Niveau);

            cible.Pvactuel = cible.Pvactuel + soins > cible.Pvmax ? cible.Pvmax : cible.Pvactuel + soins;

            strAction += "\r\n" + cible.NomAventurier + " a été soigné de " + soins + " point de vie!";

            this.Manaactuel -= this.CoutCompetenceB;
            return strAction;

        }

        public override string UtiliserCompetenceC(Aventurier cible)
        {
            string strAction = "";
            int modifDef;

            strAction = this.NomAventurier + " lance un sort de protection sur " + cible.NomAventurier;

            modifDef = 1 + (2 * this.Niveau);

            cible.Defenseactuel += modifDef;
            cible.DefenseBuff = true;
            
            strAction += "\r\nLa défense de " + cible.NomAventurier + " a augmenté de " + modifDef + " pour la durée du combat!";

            this.Manaactuel -= this.CoutCompetenceC;
            return strAction;
        }
        public override string MonterNiveauExperience()
        {
            string strLevelUp = "";
            int upPv = 7;
            int upMana = 20;
            int upInitiative = 2;
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
