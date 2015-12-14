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
            this.NomCompetenceA = "Frappe puissante"; //? Kekechose qui ignore un pourcentage de la def de l'ennemi
            this.NomCompetenceB = "Attaque circulaire"; // Cleave qui attaque tout le monde
            this.NomCompetenceC = "Cri de guerre"; //Buff la précision de tous les alliés !
            this.CibleCompetenceA = Cible.Enemy;
            this.CibleCompetenceB = Cible.AllEnemies;
            this.CibleCompetenceC = Cible.AllAllies;
            this.CoutCompetenceA = 25;
            this.CoutCompetenceB = 30;
            this.CoutCompetenceC = 30;
            this.ImageCompetenceA = Properties.Resources.frappepuissante;
            this.ImageCompetenceB = Properties.Resources.coupcirculaire;
            this.ImageCompetenceC = Properties.Resources.warcry;
            this.EsquiveBuff = false;


        }
        #endregion

        #region Fonctions
        public override string UtiliserCompetenceA(Ennemi.Ennemi cible)
        {
            int chanceAttaque = 4;
            int degatAttaque = 0;
            string strAction = "";

            chanceAttaque += this.Precisionactuel + this.Arme.Precision - cible.Esquive;
            chanceAttaque = chanceAttaque > 9 ? 9 : chanceAttaque;
            chanceAttaque = chanceAttaque < 1 ? 1 : chanceAttaque;

            Random rnd = new Random();
            int chiffreAleatoire = rnd.Next(0, 10);

            strAction = this.NomAventurier + " tente une frappe puissante sur " + cible.Nom;
            if (chiffreAleatoire < chanceAttaque)
            {
                double defenseCible = cible.Defense / 2;
                degatAttaque = this.Forceactuel + this.Arme.Force - (int)Math.Ceiling(defenseCible);
                degatAttaque = degatAttaque < 1 ? 1 : degatAttaque;
                cible.PvActuel -= degatAttaque;

                strAction += "\r\n" + this.NomAventurier + " à touché la cible et infligé : " + degatAttaque + " points de dégats!";
                
                if (cible.PvActuel <= 0)
                {
                    cible.Etat = Etat.Mort;
                    strAction += "\r\n" + cible.Nom + " est mort!";
                }
            }
            else
            {
                strAction += "\r\n" + this.NomAventurier + " à manqué la cible!";
                //MessageBox.Show(strAction);
            }

            this.Energieactuel -= this.CoutCompetenceA;
            return strAction;
        }

        public override string UtiliserCompetenceB(List<Ennemi.Ennemi> listeEnnemi)
        {
            int chanceAttaque = 4;
            int degatAttaque = 0;
            string strAction = "";

            strAction = this.NomAventurier + " tente une attaque circulaire.";

            for (var i = 0; i < listeEnnemi.Count(); i++)
            {
                chanceAttaque += this.Precisionactuel + this.Arme.Precision - listeEnnemi[i].Esquive;
                chanceAttaque = chanceAttaque > 9 ? 9 : chanceAttaque;
                chanceAttaque = chanceAttaque < 1 ? 1 : chanceAttaque;

                Random rnd = new Random();
                int chiffreAleatoire = rnd.Next(0, 10);

                if (chiffreAleatoire < chanceAttaque)
                {
                    degatAttaque = this.Forceactuel + this.Arme.Force - listeEnnemi[i].Defense - 5;
                    degatAttaque = degatAttaque < 1 ? 1 : degatAttaque;
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


            this.Energieactuel -= this.CoutCompetenceB;
            return strAction;

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
