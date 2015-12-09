using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes;
using JRPG.Classes.Ennemi;

namespace JRPG.Classes.Aventure
{
    using le = ListeEnnemi;
    class ListeAventure
    {
        //Liste des aventures
        public static readonly List<Aventure> ListeAventures = new List<Aventure>();

        //Id des aventures
        public const int VILLAGE_GOBELINS_ID = 0;
        public const int LA_PLAGE_ID = 1;

        static ListeAventure()
        {
            creerAventures();
        }

        //Créer la liste des aventures
        public static void creerAventures()
        {
            GroupeEnnemi groupe1;
            GroupeEnnemi groupe2;
            GroupeEnnemi groupe3;

            Ennemi.Ennemi ennemi1;
            Ennemi.Ennemi ennemi2;
            Ennemi.Ennemi ennemi3;
            Ennemi.Ennemi boss;

            #region Aventure 0 Village des gobelins
            //Créer la premiere Aventure Le village des gobelins
            ListeAventures.Add(new Aventure(VILLAGE_GOBELINS_ID, "Le village des gobelins", "Une petite tribu de gobelins attaque les caravanes marchandes se rendant au village. Leur repère a été trouvé. Vous devez aller éliminer la menace!", 1, 1));

            //Combat #1 
            groupe1 = new GroupeEnnemi();
            ennemi1 = new Ennemi.Ennemi(le.ListeEnnemis[le.GOBELIN_VOLEUR_ID]);
            ennemi1.Nom = ennemi1.Nom + " 1";
            ennemi2 = new Ennemi.Ennemi(le.ListeEnnemis[le.GOBELIN_VOLEUR_ID]);
            ennemi2.Nom = ennemi2.Nom + " 2";
            groupe1.AjouterEnnemi(ennemi1);
            groupe1.AjouterEnnemi(ennemi2);
            ListeAventures[VILLAGE_GOBELINS_ID].AjouterGroupeEnnemis(groupe1);

            //Combat #2 
            groupe2 = new GroupeEnnemi();
            ennemi1 = new Ennemi.Ennemi(le.ListeEnnemis[le.GOBELIN_ARCHER_ID]);
            ennemi1.Nom = ennemi1.Nom + " 1";
            ennemi2 = new Ennemi.Ennemi(le.ListeEnnemis[le.GOBELIN_ARCHER_ID]);
            ennemi2.Nom = ennemi2.Nom + " 2";
            groupe2.AjouterEnnemi(ennemi1);
            groupe2.AjouterEnnemi(ennemi2);
            ListeAventures[VILLAGE_GOBELINS_ID].AjouterGroupeEnnemis(groupe2);

            //Combat #3 
            groupe3 = new GroupeEnnemi();
            ennemi1 = new Ennemi.Ennemi(le.ListeEnnemis[le.LOUP_ID]);
            ennemi1.Nom = ennemi1.Nom + " 1";
            ennemi2 = new Ennemi.Ennemi(le.ListeEnnemis[le.LOUP_ID]);
            ennemi2.Nom = ennemi2.Nom + " 2";
            boss = new Ennemi.Ennemi(le.ListeEnnemis[le.GOBELIN_SHAMAN_ID]);
            groupe3.AjouterEnnemi(ennemi1);
            groupe3.AjouterEnnemi(ennemi2);
            groupe3.AjouterEnnemi(boss);
            ListeAventures[VILLAGE_GOBELINS_ID].AjouterGroupeEnnemis(groupe3);

            #endregion

            #region Aventure 1 La plage
            //Créer la seconde Aventure La plage
            ListeAventures.Add(new Aventure(LA_PLAGE_ID, "La plage", "Une petite balade sur la plage, il ne peut rien arrivé de bien dangereux ?", 1, 1));

            //Combat #1 
            groupe1 = new GroupeEnnemi();
            ennemi1 = new Ennemi.Ennemi(le.ListeEnnemis[le.CRABE_GEANT_ID]);
            ennemi1.Nom = ennemi1.Nom + " 1";
            ennemi2 = new Ennemi.Ennemi(le.ListeEnnemis[le.CRABE_GEANT_ID]);
            ennemi2.Nom = ennemi2.Nom + " 2";
            groupe1.AjouterEnnemi(ennemi1);
            groupe1.AjouterEnnemi(ennemi2);
            ListeAventures[LA_PLAGE_ID].AjouterGroupeEnnemis(groupe1);

            //Combat #2 
            groupe2 = new GroupeEnnemi();
            ennemi1 = new Ennemi.Ennemi(le.ListeEnnemis[le.HOMME_CRABE_GUERRIER_ID]);
            ennemi1.Nom = ennemi1.Nom + " 1";
            ennemi2 = new Ennemi.Ennemi(le.ListeEnnemis[le.HOMME_CRABE_GUERRIER_ID]);
            ennemi2.Nom = ennemi2.Nom + " 2";
            ennemi3 = new Ennemi.Ennemi(le.ListeEnnemis[le.CRABE_GEANT_ID]);
            groupe2.AjouterEnnemi(ennemi1);
            groupe2.AjouterEnnemi(ennemi2);
            groupe2.AjouterEnnemi(ennemi3);
            ListeAventures[LA_PLAGE_ID].AjouterGroupeEnnemis(groupe2);

            //Combat #3 
            groupe3 = new GroupeEnnemi();
            ennemi1 = new Ennemi.Ennemi(le.ListeEnnemis[le.HOMME_CRABE_GUERRIER_ID]);
            ennemi1.Nom = ennemi1.Nom + " 1";
            ennemi2 = new Ennemi.Ennemi(le.ListeEnnemis[le.HOMME_CRABE_GUERRIER_ID]);
            ennemi2.Nom = ennemi2.Nom + " 2";
            boss = new Ennemi.Ennemi(le.ListeEnnemis[le.HOMME_CRABE_ROI_ID]);
            groupe3.AjouterEnnemi(ennemi1);
            groupe3.AjouterEnnemi(boss);
            groupe3.AjouterEnnemi(ennemi2);
            ListeAventures[LA_PLAGE_ID].AjouterGroupeEnnemis(groupe3);

            #endregion
            
        }

    }
}
