﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Item;
using JRPG.Classes.Aventurier;

namespace JRPG.Classes
{
    [Serializable]
    class Groupe
    {
        #region Attributs
        public List<Aventurier.Aventurier> Membres { get; private set; }
        public int NbPiecesOr { get; set; }
        public List<Item.Item> Inventaire { get; private set; }
        #endregion

        #region Constructeurs
        public Groupe()
        {
            Membres = new List<Aventurier.Aventurier>();
            NbPiecesOr = 50;
            Inventaire = new List<Item.Item>();
        }
        #endregion

        #region Fonctions
        public void AjouterAventurier(Aventurier.Aventurier nouveauAventurier)
        {
            if (Membres.Count() < 3)
            {
                Membres.Add(nouveauAventurier);
            }
        }

        public void RetirerAventurier(int indexAventurier)
        {
            if (Membres.Count() > 0)
                Membres.RemoveAt(indexAventurier);

        }

        public void AjouterItem(Item.Item nouvelItem)
        {
            Inventaire.Add(nouvelItem);
        }

        public void RetirerItem(Item.Item ancienItem)
        {
            Inventaire.Remove(ancienItem);
        }

        public void UtiliserItem()
        {

        }

        public int PlusHautNiveau()
        {
            int niveaumax = 0;
            foreach (Aventurier.Aventurier aventurier in this.Membres)
            {
                if (aventurier.Niveau > niveaumax)
                {
                    niveaumax = aventurier.Niveau;
                }
            }

            return niveaumax;
        }

        public int NombreMembreVivant()
        {
            int nbVivant = 0;
            foreach (Aventurier.Aventurier aventurier in this.Membres)
            {
                if (aventurier.Etat != Etat.Mort)
                {
                    nbVivant++;
                }
            }
            return nbVivant;
        }

        public List<Aventurier.Aventurier> RetournerMembreMort()
        {
            List<Aventurier.Aventurier> listeMort = new List<Aventurier.Aventurier>();
            for(int i = 0; i < this.Membres.Count(); i++)
            {
                if (this.Membres[i].Etat == Etat.Mort)
                {
                    listeMort.Add(this.Membres[i]);
                }
            }
            return listeMort;
        }

        public List<int> RetournerIdMembreMort()
        {
            List<int> listeId = new List<int>();
            for (int i = 0; i < this.Membres.Count(); i++)
            {
                if (this.Membres[i].Etat == Etat.Mort)
                {
                    listeId.Add(i);
                }
            }
            return listeId;
        }

        public int MembrePlusFort()
        {
            int indexMembre = 0;
            int maxPv = 1;
            int currentIndex = 0;
            foreach (Aventurier.Aventurier aventurier in this.Membres)
            {
                if (aventurier.Etat != Etat.Mort)
                {
                    if (aventurier.Pvmax > maxPv)
                    {
                        indexMembre = currentIndex;
                        maxPv = aventurier.Pvmax;
                    }
                    currentIndex++;
                }
            }

            return indexMembre;
        }


        public int MembrePlusFaible()
        {
            int indexMembre = 0;
            int minPv = 999999999;
            int currentIndex = 0;
            foreach (Aventurier.Aventurier aventurier in this.Membres)
            {
                if (aventurier.Etat != Etat.Mort)
                {
                    if (aventurier.Pvmax < minPv)
                    {
                        indexMembre = currentIndex;
                        minPv = aventurier.Pvmax;
                    }
                }
                currentIndex++;
            }

            return indexMembre;
        }
        
        public void AjouterExperience(int xp)
        {
            
            foreach (Aventurier.Aventurier aventurier in this.Membres)
            {
                if (aventurier.Etat != Etat.Mort)
                {
                    aventurier.Experience += xp;
                    aventurier.VerifSiMonterNiveau();
                }
            }
            
        }

        public void StatParDefaut(bool finAventure)
        {
            foreach (Aventurier.Aventurier aventurier in Membres)
            {
                if (finAventure)
                {
                    aventurier.Pvactuel = aventurier.Pvmax;
                    aventurier.Manaactuel = aventurier.Manamax;
                    aventurier.Energieactuel = aventurier.Energiemax;
                }

                aventurier.Precisionactuel = aventurier.Precisionbase;
                aventurier.Esquiveactuel = aventurier.Esquivebase;
                aventurier.Forceactuel = aventurier.Forcebase;
                aventurier.Defenseactuel = aventurier.Defensebase;
                aventurier.EsquiveBuff = false;
                aventurier.PrecisionBuff = false;
                aventurier.ForceBuff = false;
                aventurier.DefenseBuff = false;

                if (aventurier.Etat == Etat.Etourdi)
                {
                    aventurier.Etat = Etat.Normal;
                }
            }
        }

        public void ModifApresCombat()
        {
            foreach (Aventurier.Aventurier aventurier in Membres)
            {
                this.StatParDefaut(false);

                if (aventurier.Ressource == Ressource.Energie)
                {
                    aventurier.Energieactuel = aventurier.Energiemax;
                }
                else
                {
                    aventurier.Manaactuel += 50;
                    aventurier.Manaactuel = aventurier.Manaactuel > aventurier.Manamax ? aventurier.Manamax : aventurier.Manaactuel;
                }

            }
        }
        #endregion

    }
}
