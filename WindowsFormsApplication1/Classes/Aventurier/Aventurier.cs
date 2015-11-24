using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Ennemi;
using JRPG.Classes.Item;

namespace JRPG.Classes.Aventurier
{
    abstract class Aventuriers
    {
        #region Attributs
        protected int experience;
        protected int niveau;
        protected string nomAventurier;
        protected string nomClasse;
        protected Ressource ressource;
        protected Etat etat;
        protected int pvbase; //Inutile juste max ?
        protected int pvmax;
        protected int pvactuel;
        protected int manabase; //inutile juste max ?
        protected int manamax;
        protected int manaactuel;
        protected int energiemax;
        protected int energiebase; //inutile juste max ?
        protected int energieactuel;
        protected int initiativebase;
        protected int initiativeactuel;
        protected int precisionbase;
        protected int precisionactuel;
        protected int esquivebase;
        protected int esquiveactuel;
        protected int forcebase;
        protected int forceactuel;
        protected int defensebase;
        protected int defenseactuel;



        //Verifier si je devrais pas mettre le reste dans un autre classe

        protected Arme arme;
        protected Bouclier bouclier;
        protected Armure armure; // Classe armure   

        #endregion

        #region Accesseurs et mutateurs
        public int Experience
        {
            get { return this.experience; }
            set { this.experience = value; }
        }

        public int Niveau
        {
            get { return this.niveau; }
            set { this.niveau = value; }
        }

        public string NomAventurier
        {
            get { return this.nomAventurier; }
            set { this.nomAventurier = value; }
        }

        public string NomClasse
        {
            get { return this.nomClasse; }
        }

        public Ressource Ressource
        {
            get { return this.ressource; }
        }

        public Etat Etat
        {
            get { return this.etat; }
            set { this.etat = value; }
        }

        public int Pvbase
        {
            get { return this.pvbase; }
            set { this.pvbase = value; }
        }

        public int Pvmax
        {
            get { return this.pvmax; }
            set { this.pvmax = value; }
        }

        public int Pvactuel
        {
            get { return this.pvactuel; }
            set { this.pvactuel = value; }
        }

        public int Manabase
        {
            get { return this.manabase; }
            set { this.manabase = value; }
        }

        public int Manamax
        {
            get { return this.manamax; }
            set { this.manamax = value; }
        }

        public int Manaactuel
        {
            get { return this.manaactuel; }
            set { this.manaactuel = value; }
        }

        public int Energiemax
        {
            get { return this.energiemax; }
            set { this.energiemax = value; }
        }

        public int Energiebase
        {
            get { return this.energiebase; }
            set { this.energiebase = value; }
        }

        public int Energieactuel
        {
            get { return this.energieactuel; }
            set { this.energieactuel = value; }
        }

        public int Initiativebase
        {
            get { return this.initiativebase; }
            set { this.initiativebase = value; }
        }

        public int Initiativeactuel
        {
            get { return this.initiativeactuel; }
            set { this.initiativeactuel = value; }
        }

        public int Precisionbase
        {
            get { return this.precisionbase; }
            set { this.precisionbase = value; }
        }

        public int Precisionactuel
        {
            get { return this.precisionactuel; }
            set { this.precisionactuel = value; }
        }

        public int Esquivebase
        {
            get { return this.esquivebase; }
            set { this.esquivebase = value; }
        }

        public int Esquiveactuel
        {
            get { return this.esquiveactuel; }
            set { this.esquiveactuel = value; }
        }

        public int Forcebase
        {
            get { return this.forcebase; }
            set { this.forcebase = value; }
        }

        public int Forceactuel
        {
            get { return this.forceactuel; }
            set { this.forceactuel = value; }
        }

        public int Defensebase
        {
            get { return this.defensebase; }
            set { this.defensebase = value; }
        }

        public int Defenseactuel
        {
            get { return this.defenseactuel; }
            set { this.defenseactuel = value; }
        }
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
