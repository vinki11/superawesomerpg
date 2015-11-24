using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Ennemi;

namespace JRPG.Classes.Aventurier
{
    class Aventuriers
    {
        protected int experience;
        protected int niveau;
        protected string nomAventurier;
        protected string nomClasse; //Static ds la classe
        protected Ressource ressource; //Static ds la classe
        protected Etat etat;
        protected int pvbase;
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

        protected string mainprincipale; //Classe arme au lieu de string 
        protected string mainsecondaire; //Classe bouclier ou offhand
        protected string armure; // Classe armure   

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
