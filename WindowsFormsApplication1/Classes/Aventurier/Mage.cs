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
            this.NomCompetenceC = "Enchantement de l'arme"; //Buff Force ally
            this.CibleCompetenceA = Cible.Enemy;
            this.CibleCompetenceB = Cible.AllEnemies;
            this.CibleCompetenceC = Cible.Ally;
            this.CoutCompetenceA = 20;
            this.CoutCompetenceB = 25;
            this.CoutCompetenceC = 10;
            this.ImageCompetenceA = Properties.Resources.eclair;
            this.ImageCompetenceB = Properties.Resources.boulefeu;
            this.ImageCompetenceC = Properties.Resources.enchantement;
            this.EsquiveBuff = false;
        }
        #endregion

        #region Fonctions
        public override string UtiliserCompetenceA(Ennemi.Ennemi cible)
        {
            int degatAttaque = 0;
            string strAction = "";
            Random rnd = new Random();
            int chiffreAleatoire = rnd.Next(0, 10);

            strAction = this.NomAventurier + " lance un éclair vers " + cible.Nom;
            if (chiffreAleatoire > 1)
            {
                degatAttaque = 10 + (this.Niveau * 5);
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

        public override string UtiliserCompetenceB(List<Ennemi.Ennemi> listeEnnemi)
        {
            int degatAttaque = 0;
            string strAction = "";

            strAction = this.NomAventurier + " lance une boule de feu.";

            for (var i = 0; i < listeEnnemi.Count(); i++)
            {
                Random rnd = new Random();
                int chiffreAleatoire = rnd.Next(0, 10);

                if (chiffreAleatoire > 2)
                {
                    degatAttaque = 6 + (this.Niveau * 3);
                    listeEnnemi[i].PvActuel -= degatAttaque;

                    strAction += "\r\n" + listeEnnemi[i].Nom + " à été touché pour : " + degatAttaque + " points de dégats!";

                    if (listeEnnemi[i].PvActuel <= 0)
                    {
                        listeEnnemi[i].Etat = Etat.Mort;
                        strAction += "\r\n" + listeEnnemi[i].Nom + " est mort!";
                    }
                }
                else
                {
                    strAction += "\r\n" + listeEnnemi[i].Nom + " à évité l'attaque!";
                    //MessageBox.Show(strAction);
                }
            }


            this.Manaactuel -= this.CoutCompetenceB;
            return strAction;

        }

        public override string UtiliserCompetenceC()
        {
            return "";
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
