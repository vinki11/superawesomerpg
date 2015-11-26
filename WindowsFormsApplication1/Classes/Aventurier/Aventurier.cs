using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Ennemi;
using JRPG.Classes.Item;
using System.Drawing;

namespace JRPG.Classes.Aventurier
{
    abstract class Aventurier
    {
        #region Attributs

        //Verifier si je devrais pas mettre le reste dans un autre classe

        protected Arme arme;
        protected Bouclier bouclier;
        protected Armure armure; // Classe armure   

        #endregion

        #region Accesseurs et mutateurs
        public int Experience { get; set; }

        public int Niveau { get; set; }

        public string NomAventurier { get; set; }

        public string NomClasse { get; protected set; }

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

        public Bitmap Imageclasse { get; set; }

        #endregion

        #region Fonctions
        public void Attaquer(Ennemis cible)
        {
        }
        
        public void UtiliserCompetenceA()
        {

        }

        public void UtiliserCompetenceB()
        {

        }

        public void UtiliserCompetenceC()
        {

        }

        public void MonterNiveauExperience()
        {

        }

        public void VerifSiMonterNiveau()
        {

        }

        public void UtiliserItem() //consumable genre potion de vie ou mana
        {

        }
        #endregion
    }

    enum Etat
    {
        Normal,
        Etourdi,
        Mort
    };

    enum Ressource
    {
        Mana,
        Energie
    };
   
     
}
