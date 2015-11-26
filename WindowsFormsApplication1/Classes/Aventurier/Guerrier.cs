﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Aventurier;
using JRPG.Classes.Item;
using System.Drawing;

namespace JRPG.Classes.Aventurier
{
    using li = ListeItem;
    //Classe d'aventurier qui a une bonne attaque et defense(hp) de base. Utilise de l'energie
    public class Guerrier : Aventuriers
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
            this.Defenseactuel = Defensebase = 15;
            this.NomClasse = "Guérrier";
            this.Ressource = Ressource.Energie;
            this.Imageclasse = Properties.Resources.guerrier;
            this.Arme = li.ListeArmes[li.EPEE_BRONZE_ID];
            this.Armure = li.ListeArmures[li.ARMURE_BRONZE_ID];

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
