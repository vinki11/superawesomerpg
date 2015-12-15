using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes.Aventurier;
using System.Drawing;

namespace JRPG.Classes.Ennemi
{
    using p = Program;
    class Ennemi
    {
        #region  Attributs
        public int IdEnnemie { get; set; }
        public string Nom { get; set; }
        public Bitmap ImageEnnemi { get; protected set; }
        public int Niveau { get; set; }
        public Etat Etat { get; set; }
        public int PvMax { get; set; }
        public int PvActuel { get; set; }
        public int Initiative { get; set; }
        public int Precision { get; set; }
        public int Esquive { get; set; }
        public int Force { get; set; }
        public int Defense { get; set; }
        public int Gainxp { get; set; }
        public int Pieces { get; set; }
        public StrategieAction Strategie { get; set; }

        public List<Item.Item> Items { get; set; }

        public List<int> ProbItems { get; set; }

        public int CompetenceId { get; set; }

        public int ProbCompetence { get; set; } //Plus le chiffre est haut, moins il utilise souvent sa compétence

        #endregion

        #region Constructeur

        public Ennemi(int pId, string pNom, int pNiveau, int pPv, int pInitiative, int pPrecision, int pEsquive, int pForce, int pDefense, int pGainXp, int pPieces, Bitmap pImageEnnemi, StrategieAction pStrat, List<Item.Item> pItems, List<int> pProbItems, int pCompetenceId = 0, int pProbCompetence = 0)
        {
            Nom = pNom;
            Niveau = pNiveau;
            Etat = Etat.Normal;
            PvMax = PvActuel = pPv;
            Initiative = pInitiative;
            Precision = pPrecision;
            Esquive = pEsquive;
            Force = pForce;
            Defense = pDefense;
            Gainxp = pGainXp;
            Pieces = pPieces;
            ImageEnnemi = pImageEnnemi;
            Strategie = pStrat;
            Items = pItems;
            ProbItems = pProbItems;
            CompetenceId = pCompetenceId;
            ProbCompetence = pProbCompetence;
        }

        public Ennemi(Ennemi pEnnemi)
        {
            this.Nom = pEnnemi.Nom;
            this.Niveau = pEnnemi.Niveau;
            this.Etat = Etat.Normal;
            this.PvMax = this.PvActuel = pEnnemi.PvMax;
            this.Initiative = pEnnemi.Initiative;
            this.Precision = pEnnemi.Precision;
            this.Esquive = pEnnemi.Esquive;
            this.Force = pEnnemi.Force;
            this.Defense = pEnnemi.Defense;
            this.Gainxp = pEnnemi.Gainxp;
            this.Pieces = pEnnemi.Pieces;
            this.ImageEnnemi = pEnnemi.ImageEnnemi;
            this.Strategie = pEnnemi.Strategie;
            this.Items = pEnnemi.Items;
            this.ProbItems = pEnnemi.ProbItems;
            CompetenceId = pEnnemi.CompetenceId;
            ProbCompetence = pEnnemi.ProbCompetence;
        }

        #endregion

        #region Fonctions
        public string Agir()
        {
            int action;
            string strAction = "";
            Random rnd = new Random();
            action = rnd.Next(1, 101);

            if (action > ProbCompetence)
            {
                strAction = Attaquer();
            }
            else
            {
                strAction = UtiliserCompetence();
            }

            MessageBox.Show(strAction);
            return strAction;
            
        }

        public Aventurier.Aventurier DeterminerCible()
        {
            int cibleAleatoire;
            int cibleId = -1;

            switch (Strategie)
            {
                #region Attaque Aléatoire
                case StrategieAction.AttaqueAleatoire:
                    if (p.groupeAventurier.NombreMembreVivant() == 3)
                    {
                        Random rnd = new Random();
                        cibleAleatoire = rnd.Next(1, 10);

                        if (cibleAleatoire >= 1 && cibleAleatoire <= 3)
                        {
                            cibleId = 0;
                            // MessageBox.Show(this.Nom + " attaque l'aventurier #1");
                        }
                        else if (cibleAleatoire >= 4 && cibleAleatoire <= 6)
                        {
                            cibleId = 1;
                            // MessageBox.Show(this.Nom + " attaque l'aventurier #2");
                        }
                        else if (cibleAleatoire >= 7 && cibleAleatoire <= 9)
                        {
                            cibleId = 2;
                            //MessageBox.Show(this.Nom + " attaque l'aventurier #3");
                        }
                    }
                    else if (p.groupeAventurier.NombreMembreVivant() == 2)
                    {
                        int index1 = -1;
                        int index2 = -1;
                        for (var i = 0; i < p.groupeAventurier.Membres.Count(); i++)
                        {
                            if (p.groupeAventurier.Membres[i].Etat != Etat.Mort)
                            {
                                if (index1 == -1)
                                {
                                    index1 = i;
                                }
                                else
                                {
                                    index2 = i;
                                }
                            }
                        }

                        Random rnd = new Random();
                        cibleAleatoire = rnd.Next(1, 11);

                        if (cibleAleatoire >= 1 && cibleAleatoire <= 5)
                        {
                            cibleId = index1;
                            // MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                        }
                        else if (cibleAleatoire >= 6 && cibleAleatoire <= 10)
                        {
                            cibleId = index2;
                            // MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                        }
                    }
                    else if (p.groupeAventurier.NombreMembreVivant() == 1)
                    {
                        cibleId = 0;
                        for (var i = 0; i < p.groupeAventurier.Membres.Count(); i++)
                        {
                            if (p.groupeAventurier.Membres[i].Etat != Etat.Mort)
                            {
                                cibleId = i;
                            }
                        }
                        // MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                    }
                    break;
                #endregion
                #region Attaque plus faible
                case StrategieAction.AttaquePlusFaible:
                    if (p.groupeAventurier.NombreMembreVivant() == 3)
                    {
                        Random rnd = new Random();
                        cibleAleatoire = rnd.Next(1, 9);

                        if (cibleAleatoire >= 1 && cibleAleatoire <= 4)
                        {
                            cibleId = p.groupeAventurier.MembrePlusFaible();
                            // MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                        }
                        else if (cibleAleatoire >= 5 && cibleAleatoire <= 8)
                        {
                            int index1 = -1;
                            int index2 = -1;
                            for (var i = 0; i < p.groupeAventurier.Membres.Count(); i++)
                            {
                                if (i != p.groupeAventurier.MembrePlusFaible() && index1 == -1)
                                {
                                    index1 = i;
                                }
                                else
                                {
                                    index2 = i;
                                }
                            }

                            if (cibleAleatoire <= 6)
                            {
                                cibleId = index1;
                                //MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                            }
                            else
                            {
                                cibleId = index2;
                                //MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                            }
                        }
                    }
                    else if (p.groupeAventurier.NombreMembreVivant() == 2)
                    {
                        int index = -1;
                        for (var i = 0; i < p.groupeAventurier.Membres.Count(); i++)
                        {
                            if (p.groupeAventurier.Membres[i].Etat != Etat.Mort && i != p.groupeAventurier.MembrePlusFaible())
                            {
                                index = i;
                            }
                        }

                        Random rnd = new Random();
                        cibleAleatoire = rnd.Next(1, 4);

                        if (cibleAleatoire >= 1 && cibleAleatoire <= 2)
                        {
                            cibleId = p.groupeAventurier.MembrePlusFaible();
                            //MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                        }
                        else if (cibleAleatoire >= 2)
                        {
                            cibleId = index;
                            //MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                        }
                    }
                    else if (p.groupeAventurier.NombreMembreVivant() == 1)
                    {
                        cibleId = 0;
                        for (var i = 0; i < p.groupeAventurier.Membres.Count(); i++)
                        {
                            if (p.groupeAventurier.Membres[i].Etat != Etat.Mort)
                            {
                                cibleId = i;
                            }
                        }
                        //MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                    }
                    break;
                #endregion
                #region Attaque plus fort
                case StrategieAction.AttaquePlusFort:
                    if (p.groupeAventurier.NombreMembreVivant() == 3)
                    {
                        Random rnd = new Random();
                        cibleAleatoire = rnd.Next(1, 9);

                        if (cibleAleatoire >= 1 && cibleAleatoire <= 4)
                        {
                            cibleId = p.groupeAventurier.MembrePlusFort();
                            // MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                        }
                        else if (cibleAleatoire >= 5 && cibleAleatoire <= 8)
                        {
                            int index1 = -1;
                            int index2 = -1;
                            for (var i = 0; i < p.groupeAventurier.Membres.Count(); i++)
                            {
                                if (i != p.groupeAventurier.MembrePlusFort() && index1 == -1)
                                {
                                    index1 = i;
                                }
                                else
                                {
                                    index2 = i;
                                }
                            }

                            if (cibleAleatoire <= 6)
                            {
                                cibleId = index1;
                                // MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                            }
                            else
                            {
                                cibleId = index2;
                                // MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                            }
                        }
                    }
                    else if (p.groupeAventurier.NombreMembreVivant() == 2)
                    {
                        int index = -1;
                        for (var i = 0; i < p.groupeAventurier.Membres.Count(); i++)
                        {
                            if (p.groupeAventurier.Membres[i].Etat != Etat.Mort && i != p.groupeAventurier.MembrePlusFort())
                            {
                                index = i;
                            }
                        }

                        Random rnd = new Random();
                        cibleAleatoire = rnd.Next(1, 4);

                        if (cibleAleatoire >= 1 && cibleAleatoire <= 2)
                        {
                            cibleId = p.groupeAventurier.MembrePlusFort();
                            //MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                        }
                        else if (cibleAleatoire >= 2)
                        {
                            cibleId = index;
                            //  MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                        }
                    }
                    else if (p.groupeAventurier.NombreMembreVivant() == 1)
                    {
                        cibleId = 0;
                        for (var i = 0; i < p.groupeAventurier.Membres.Count(); i++)
                        {
                            if (p.groupeAventurier.Membres[i].Etat != Etat.Mort)
                            {
                                cibleId = i;
                            }
                        }
                        //MessageBox.Show(this.Nom + " attaque l'aventurier #" + (cibleId + 1));
                    }
                    break;
                    #endregion
            }

            return p.groupeAventurier.Membres[cibleId];
        }

        public string Attaquer()
        {
            Aventurier.Aventurier cible = DeterminerCible();
            int chanceAttaque = 5;
            int degatAttaque = 0;
            string strAction = "";

            chanceAttaque += this.Precision - cible.Esquiveactuel - (cible.Bouclier != null ? cible.Bouclier.Esquive : 0);
            chanceAttaque = chanceAttaque > 9 ? 9 : chanceAttaque;
            chanceAttaque = chanceAttaque < 1 ? 1 : chanceAttaque;

            Random rnd = new Random();
            int chiffreAleatoire = rnd.Next(0, 10);

            //MessageBox.Show("Le chiffre aléatoire est de: " + chiffreAleatoire);
            strAction = this.Nom + " à attaqué " + cible.NomAventurier;
            if (chiffreAleatoire < chanceAttaque)
            {
                degatAttaque = this.Force - cible.Defenseactuel - cible.Armure.Defense;
                degatAttaque = degatAttaque < 1 ? 1 : degatAttaque;
                cible.Pvactuel -= degatAttaque;

                strAction += "\r\n" + this.Nom + " à touché la cible et infligé : " + degatAttaque + " points de dégats!";

                if (cible.Pvactuel <= 0)
                {
                    cible.Etat = Etat.Mort;
                    strAction += "\r\n" + cible.NomAventurier + " est mort!";
                }


                //MessageBox.Show(strAction);

            }
            else
            {
                strAction += "\r\n" + this.Nom + " à manqué la cible!";
                //MessageBox.Show(strAction);
            }

            return strAction; //utilisé le return pour faire l'historique si on le désire vraiment
        }

        public string UtiliserCompetence()
        {
            Aventurier.Aventurier cible = DeterminerCible();
            int chanceAttaque = 5;
            int degatAttaque = 0;
            string strAction = "";

            Random rnd = new Random();
            int chiffreAleatoire = rnd.Next(0, 10);

            switch (CompetenceId)
            {
                // Vague de feu du gobelin shaman
                case 1:
                    strAction += this.Nom + " lance une vague de feu à " + cible.NomAventurier;
                    if (chiffreAleatoire > 2)
                    {
                        degatAttaque = 12;
                        cible.Pvactuel -= degatAttaque;

                        strAction += "\r\n" + this.Nom + " à touché la cible et infligé : " + degatAttaque + " points de dégats!";

                        if (cible.Pvactuel <= 0)
                        {
                            cible.Etat = Etat.Mort;
                            strAction += "\r\n" + cible.NomAventurier + " est mort!";
                        }
                    }
                    else
                    {
                        strAction += "\r\n" + this.Nom + " à manqué la cible!";
                    }
                    break;

                case 2: //Coup étourdissant du Roi Homme Crabe

                    strAction += this.Nom + " tente un coup étourdissant sur  " + cible.NomAventurier;

                    chanceAttaque += this.Precision - (cible.Bouclier != null ? cible.Bouclier.Esquive : 0) - cible.Esquiveactuel;
                    chanceAttaque = chanceAttaque > 9 ? 9 : chanceAttaque;
                    chanceAttaque = chanceAttaque < 1 ? 1 : chanceAttaque;

                    if (chiffreAleatoire < chanceAttaque)
                    {
                        degatAttaque = this.Force - cible.Defenseactuel - cible.Armure.Defense - 2;
                        degatAttaque = degatAttaque < 1 ? 1 : degatAttaque;
                        cible.Pvactuel -= degatAttaque;

                        strAction += "\r\n" + this.Nom + " à touché la cible et infligé : " + degatAttaque + " points de dégats!";

                        int chanceEtourdi = rnd.Next(0, 10);
                        chanceEtourdi += (this.Niveau - cible.Niveau);

                        if (cible.Pvactuel <= 0)
                        {
                            cible.Etat = Etat.Mort;
                            strAction += "\r\n" + cible.NomAventurier + " est mort!";
                        }
                        else if (chanceEtourdi > 1)
                        {
                            cible.Etat = Etat.Etourdi;
                            strAction += "\r\n" + cible.NomAventurier + " est étourdi!";
                        }
                        else
                        {
                            strAction += "\r\n" + cible.NomAventurier + " a résister à l'étourdissement!";
                        }
                    }
                    else
                    {
                        strAction += "\r\n" + this.Nom + " à manqué la cible!";
                    }
                    break;
            }
            return strAction;
        }
        #endregion


        public enum StrategieAction
        {
            AttaquePlusFaible,
            AttaquePlusFort,
            AttaqueAleatoire
        };
    }
}
