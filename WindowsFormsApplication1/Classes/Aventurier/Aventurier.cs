using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Ennemi;
using JRPG.Classes.Item;
using System.Drawing;

namespace JRPG.Classes.Aventurier
{
    [Serializable]
    abstract class Aventurier
    {

        #region Attributs
        public int Experience { get; set; }

        public int Niveau { get; set; }

        public string NomAventurier { get; set; }

        public int ClassId { get; protected set; }

        public string NomClasse { get; protected set; }

        public string DescriptionClasse { get; protected set; }

        public Bitmap Imageclasse { get; protected set; }

        public Ressource Ressource { get; protected set; }

        public Etat Etat { get; set; }

        public int Pvbase { get; set; }

        public int Pvmax { get; set; }

        public int Pvactuel { get; set; }

        public int Manabase { get; set; }

        public int Manamax { get; set; }

        public int Manaactuel { get; set; }

        public int Energiemax { get; set; }

        public int Energiebase { get; set; }

        public int Energieactuel { get; set; }

        public int Initiativebase { get; set; }

        public int Initiativeactuel { get; set; }

        public int Precisionbase { get; set; }

        public int Precisionactuel { get; set; }

        public int Esquivebase { get; set; }

        public int Esquiveactuel { get; set; }

        public int Forcebase { get; set; }

        public int Forceactuel { get; set; }

        public int Defensebase { get; set; }

        public int Defenseactuel { get; set; }

        public bool EsquiveBuff { get; set; }

        public bool PrecisionBuff { get; set; }

        public bool DefenseBuff { get; set; }

        public bool ForceBuff { get; set; }

        public Arme Arme { get; set; }

        public Armure Armure { get; set; }

        public Bouclier Bouclier { get; set; }

        public string NomCompetenceA { get; set; }
        public string NomCompetenceB { get; set; }
        public string NomCompetenceC { get; set; }

        public Cible CibleCompetenceA { get; set; }
        public Cible CibleCompetenceB { get; set; }
        public Cible CibleCompetenceC { get; set; }

        public int CoutCompetenceA { get; set; }
        public int CoutCompetenceB { get; set; }
        public int CoutCompetenceC { get; set; }

        public Bitmap ImageCompetenceA { get; set; }
        public Bitmap ImageCompetenceB { get; set; }
        public Bitmap ImageCompetenceC { get; set; }

        #endregion

        #region Fonctions
        public string Attaquer(Ennemi.Ennemi cible)
        {
            int chanceAttaque = 5;
            int degatAttaque = 0;
            string strAction = "";

            chanceAttaque += this.Precisionactuel + this.Arme.Precision - cible.Esquive;
            chanceAttaque = chanceAttaque > 9 ? 9 : chanceAttaque;
            chanceAttaque = chanceAttaque < 1 ? 1 : chanceAttaque;

            //MessageBox.Show("La chance de l'attaque est de: " + chanceAttaque);

            Random rnd = new Random();
            int chiffreAleatoire = rnd.Next(0, 10);

            //MessageBox.Show("Le chiffre aléatoire est de: " + chiffreAleatoire);
            strAction = this.NomAventurier + " à attaqué " + cible.Nom;
            if (chiffreAleatoire < chanceAttaque)
            {
                degatAttaque = this.Forceactuel + this.Arme.Force - cible.Defense;
                degatAttaque = degatAttaque < 1 ? 1 : degatAttaque;
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

            return strAction;

        }

        public virtual string UtiliserCompetenceA(Ennemi.Ennemi cible)
        {
            MessageBox.Show("J'aimerais bien ca passe pas ici svp");
            return "";
        }

        public virtual string UtiliserCompetenceB(Aventurier cible)
        {
            MessageBox.Show("J'aimerais bien ca passe pas ici svp");
            return "";
        }

        public virtual string UtiliserCompetenceB()
        {
            MessageBox.Show("J'aimerais bien ca passe pas ici svp");
            return "";
        }

        public virtual string UtiliserCompetenceB(List <Ennemi.Ennemi> listEnnemi)
        {
            MessageBox.Show("J'aimerais bien ca passe pas ici svp");
            return "";
        }


        public virtual string UtiliserCompetenceC()
        {
            MessageBox.Show("J'aimerais bien ca passe pas ici svp");
            return "";
        }

        public virtual string UtiliserCompetenceC(Ennemi.Ennemi cible)
        {
            MessageBox.Show("J'aimerais bien ca passe pas ici svp");
            return "";
        }

        public virtual string UtiliserCompetenceC(Aventurier cible)
        {
            MessageBox.Show("J'aimerais bien ca passe pas ici svp");
            return "";
        }

        public virtual string MonterNiveauExperience()
        {
            Niveau += 1;
            return "";
        }

        public void VerifSiMonterNiveau()
        {
            int niv1Cap = 1000;
            int niv2Cap = 2500;
            int niv3Cap = 5000;
            int niv4Cap = 8000;

            string strLevelUp = "";

            if (Niveau == 1 && Experience >= niv1Cap)
            {
                strLevelUp += "\r\n" + MonterNiveauExperience();
            }
            if (Niveau == 2 && Experience >= niv2Cap)
            {
                strLevelUp += "\r\n" + MonterNiveauExperience();
            }
            if (Niveau == 3 && Experience >= niv3Cap)
            {
                strLevelUp += "\r\n" + MonterNiveauExperience();
            }
            if (Niveau == 4 && Experience >= niv4Cap)
            {
                strLevelUp += "\r\n" + MonterNiveauExperience();
            }
            if (strLevelUp != "")
            {
                MessageBox.Show(strLevelUp);
            }
            

        }

        public void UtiliserItem() //consumable genre potion de vie ou mana
        {

        }
        #endregion
    }

    public enum Etat
    {
        Normal,
        Etourdi,
        Mort
    };

    public enum Ressource
    {
        Mana,
        Energie
    };

    public enum Cible
    {
        Self,
        Enemy,
        AllEnemies,
        Ally,
        AllAllies
    };


}
