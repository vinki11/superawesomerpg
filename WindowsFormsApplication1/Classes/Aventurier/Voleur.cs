using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using JRPG.Classes.Item;
using System.Threading.Tasks;


namespace JRPG.Classes.Aventurier
{
    using li = ListeItem;
    using lc = ListeClasse;
    //Classe qui a une bonne précision et esquive. Utilise de l'énergie
    [Serializable]
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
            this.Esquiveactuel = Esquivebase = 12;
            this.Forceactuel = Forcebase = 10;
            this.Defenseactuel = Defensebase = 2;
            this.NomClasse = "Voleur";
            this.DescriptionClasse = "Combattant agile et rapide. Ses forces sont la précision et l'esquive";
            this.Ressource = Ressource.Energie;
            this.Imageclasse = Properties.Resources.voleur;
            this.ClassId = lc.VOLEUR_ID;
            this.Arme = li.ListeArmes[li.DAGUE_BRONZE_ID];
            this.Armure = li.ListeArmures[li.ARMURE_CUIR_ID];
            this.NomCompetenceA = "Coup étourdissant"; //Étourdi un ennemi
            this.NomCompetenceB = "Placeholder";
            this.NomCompetenceC = "Placeholder";
            this.CibleCompetenceA = Cible.Enemy;
            this.CibleCompetenceB = Cible.Enemy;
            this.CibleCompetenceC = Cible.Enemy;
            this.CoutCompetenceA = 30;
            this.CoutCompetenceB = 30;
            this.CoutCompetenceC = 30;
            this.ImageCompetenceA = Properties.Resources.coupetourdissant;
            this.ImageCompetenceB = Properties.Resources.attaque;
            this.ImageCompetenceC = Properties.Resources.attaque;
        }
        #endregion


        #region Fonctions
        public override string UtiliserCompetenceA(Ennemi.Ennemi cible)
        {
            int chanceAttaque = 5;
            int degatAttaque = 0;
            string strAction = "";

            chanceAttaque += this.Precisionactuel + this.Arme.Precision - cible.Esquive;
            chanceAttaque = chanceAttaque > 9 ? 9 : chanceAttaque;
            chanceAttaque = chanceAttaque < 1 ? 1 : chanceAttaque;

            Random rnd = new Random();
            int chiffreAleatoire = rnd.Next(0, 10);

            strAction = this.NomAventurier + " tente un coup étourdissant sur " + cible.Nom;
            if (chiffreAleatoire < chanceAttaque)
            {
                degatAttaque = this.Forceactuel + this.Arme.Force - cible.Defense - 2;
                degatAttaque = degatAttaque < 1 ? 1 : degatAttaque;
                cible.PvActuel -= degatAttaque;

                strAction += "\r\n" + this.NomAventurier + " à touché la cible et infligé : " + degatAttaque + " points de dégats!";

                int chanceEtourdi = rnd.Next(0, 10);
                chanceEtourdi += (this.Niveau - cible.Niveau);


                if (cible.PvActuel <= 0)
                {
                    cible.Etat = Etat.Mort;
                    strAction += "\r\n" + cible.Nom + " est mort!";
                } else if (chanceEtourdi > 1)
                {
                    cible.Etat = Etat.Etourdi;
                    strAction += "\r\n" + cible.Nom + " est étourdi!";
                }
                else
                {
                    strAction += "\r\n" + cible.Nom + " a résister à l'étourdissement!";
                }



                //MessageBox.Show(strAction);

            }
            else
            {
                strAction += "\r\n" + this.NomAventurier + " à manqué la cible!";
                //MessageBox.Show(strAction);
            }

            this.Energieactuel -= this.CoutCompetenceA;
            return strAction;
        }

        public override string UtiliserCompetenceB()
        {
            return "";
        }

        public override string UtiliserCompetenceC()
        {
            return "";
        }

        public override string MonterNiveauExperience()
        {
            string strLevelUp = "";
            int upPv = 8;
            int upInitiative = 4;
            int upPrecision = 3;
            int upEsquive = 3;
            int upForce = 3;
            int upDefense = 2;

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
