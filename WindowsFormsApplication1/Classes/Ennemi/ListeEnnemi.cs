using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Ennemi;

namespace JRPG.Classes.Ennemi
{
    class ListeEnnemi
    {
        //Liste des ennemis
        public static readonly List<Ennemi> ListeEnnemis = new List<Ennemi>();

        //Id des ennemis
        public const int GOBELIN_VOLEUR_ID = 0;
        public const int GOBELIN_ARCHER_ID = 1;
        public const int GOBELIN_SHAMAN_ID = 2;
        public const int LOUP_ID = 3;
        public const int CRABE_GEANT_ID = 4;
        public const int HOMME_CRABE_GUERRIER_ID = 5;
        public const int HOMME_CRABE_ROI_ID = 6;

        static ListeEnnemi()
        {
            creerEnnemis();
        }

        //Créer la liste des "modèles" d'ennemis
        public static void creerEnnemis()
        {   //                                                              Lvl, PV, In, Pr, Es, F, D, Xp, Or
            ListeEnnemis.Add(new Ennemi(GOBELIN_VOLEUR_ID, "Voleur gobelin", 1, 40, 12, 12, 12, 8, 10, 100, 5));
            ListeEnnemis.Add(new Ennemi(GOBELIN_ARCHER_ID, "Archer gobelin", 1, 35, 10, 15, 10, 10, 10, 100, 5));
            ListeEnnemis.Add(new Ennemi(GOBELIN_SHAMAN_ID, "Shaman gobelin", 2, 50, 12, 12, 10, 12, 12, 150, 15));
            ListeEnnemis.Add(new Ennemi(LOUP_ID, "Loup", 1, 40, 18, 10, 15, 12, 10, 100, 0));
            ListeEnnemis.Add(new Ennemi(CRABE_GEANT_ID, "Crabe géant", 1, 50, 6, 8, 8, 14, 15, 100, 0));
            ListeEnnemis.Add(new Ennemi(HOMME_CRABE_GUERRIER_ID, "Guerrier homme-crabe", 1, 40, 10, 10, 10, 10, 10, 100, 5));
            ListeEnnemis.Add(new Ennemi(HOMME_CRABE_ROI_ID, "Roi homme-crabe", 2, 60, 14, 14, 14, 14, 14, 150, 15));
        }
    }
}
