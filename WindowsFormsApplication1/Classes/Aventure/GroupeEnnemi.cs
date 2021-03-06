﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Aventurier;
using JRPG.Classes.Ennemi;
using JRPG.Classes.Item;

namespace JRPG.Classes
{
    class GroupeEnnemi
    {
        #region Attributs
        public List<Ennemi.Ennemi> ListeEnnemi { get; set; }
        public int TotalPieces { get; set; }
        public int TotalXp { get; set; }
        public List<Item.Item> ListeItem { get; set; }
        #endregion

        #region Constructeurs

        public GroupeEnnemi()
        {
            ListeEnnemi = new List<Ennemi.Ennemi>();
            TotalPieces = 0;
            TotalXp = 0;
            ListeItem = new List<Item.Item>();
        }
        #endregion

        #region Fonctions

        public void AjouterEnnemi(Ennemi.Ennemi groupe)
        {
            this.ListeEnnemi.Add(groupe);
            CalculerPiecesEtXp();
        }

        private void CalculerPiecesEtXp()
        {
            int totalPiece = 0;
            int totalXp = 0;

            foreach (var ennemi in ListeEnnemi)
            {
                totalPiece += ennemi.Pieces;
                totalXp += ennemi.Gainxp;
            }

            this.TotalPieces = totalPiece;
            this.TotalXp = totalXp;
        }

        public void CalculerItems()
        {
            for (var j = 0; j < ListeEnnemi.Count(); j++)
            {
                Random rnd = new Random();
                int lootAleatoire = rnd.Next(1, 101);
                int previousProb = 0;


                for (var i = 0; i < ListeEnnemi[j].Items.Count(); i++)
                {
                    if (lootAleatoire <= ListeEnnemi[j].ProbItems[i]+ previousProb)
                    {
                        this.ListeItem.Add(ListeEnnemi[j].Items[i]);
                        break;
                    }
                    else
                    {
                        previousProb += ListeEnnemi[j].ProbItems[i];
                    }
                }
            }
        }

        public int NombreEnnemiVivant()
        {
            int nbVivant = 0;
            foreach (Ennemi.Ennemi ennemi in this.ListeEnnemi)
            {
                if (ennemi.Etat != Etat.Mort)
                {
                    nbVivant++;
                }
            }
            return nbVivant;
        }

        #endregion

    }
}

