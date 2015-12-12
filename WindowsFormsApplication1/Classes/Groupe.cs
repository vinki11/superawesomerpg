using System;
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
        public List<Aventurier.Aventurier> Membres { get; set; }
        public int NbPiecesOr { get; set; }
        public List<Item.Item> Inventaire { get; set; }
        #endregion

        #region Constructeurs
        public Groupe()
        {
            Membres = new List<Aventurier.Aventurier>();
            NbPiecesOr = 20;
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

        public void RetirerAventurier()
        {

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

        public void StatParDefaut()
        {
            foreach (Aventurier.Aventurier aventurier in Membres)
            {
                aventurier.Pvactuel = aventurier.Pvmax;
                aventurier.Manaactuel = aventurier.Manamax;
                aventurier.Energieactuel = aventurier.Energiemax;
                aventurier.Precisionactuel = aventurier.Precisionbase;
                aventurier.Esquiveactuel = aventurier.Esquivebase;
                aventurier.Forceactuel = aventurier.Forcebase;
                aventurier.Defenseactuel = aventurier.Defensebase;
            }
        }
        #endregion

    }
}
