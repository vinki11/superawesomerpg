using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes.Ennemi;
using JRPG.Classes.Item;

namespace JRPG.Classes.Ennemi
{
    using li = ListeItem;
    class ListeEnnemi
    {
        //Liste des ennemis
        public static readonly List<Ennemi> ListeEnnemis = new List<Ennemi>();
        static List<Item.Item> listeLoot;
        static List<int> listeProbLoot;

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
            CreerEnnemis();
        }

        //Créer la liste des "modèles" d'ennemis
        public static void CreerEnnemis()
        {   //                                                              Lvl, PV, In, Pr, Es, F, D, Xp, Or
            ListeEnnemis.Clear();

            //Voleur gobelin
            listeLoot = new List<Item.Item>();
            listeLoot.Add(null);
            listeLoot.Add(li.ListeArmes[li.DAGUE_BRONZE_ID]);
            listeLoot.Add(li.ListeConsommables[li.POTION_VIE_MINEURE_ID]);
            listeProbLoot = new List<int>();
            listeProbLoot.Add(87);
            listeProbLoot.Add(5);
            listeProbLoot.Add(8);
            ListeEnnemis.Add(new Ennemi(GOBELIN_VOLEUR_ID, "Voleur gobelin", 1, 40, 12, 12, 10, 12, 10, 100, 5, Properties.Resources.spectre, Ennemi.StrategieAction.AttaquePlusFaible,listeLoot,listeProbLoot));

            //Archer gobelin
            listeLoot = new List<Item.Item>();
            listeLoot.Add(null);
            listeLoot.Add(li.ListeArmures[li.ARMURE_CUIR_ID]);
            listeLoot.Add(li.ListeConsommables[li.POTION_VIE_MINEURE_ID]);
            listeProbLoot = new List<int>();
            listeProbLoot.Add(85);
            listeProbLoot.Add(5);
            listeProbLoot.Add(10);
            ListeEnnemis.Add(new Ennemi(GOBELIN_ARCHER_ID, "Archer gobelin", 1, 35, 10, 15, 9, 14, 10, 100, 5, Properties.Resources.spectre, Ennemi.StrategieAction.AttaquePlusFaible, listeLoot, listeProbLoot));

            //Shaman Gobelin
            listeLoot = new List<Item.Item>();
            listeLoot.Add(li.ListeArmures[li.ARMURE_BRONZE_ID]);
            listeLoot.Add(li.ListeArmes[li.EPEE_BRONZE_ID]);
            listeLoot.Add(li.ListeArmes[li.DAGUE_BRONZE_ID]);
            listeLoot.Add(li.ListeBoucliers[li.ECU_ACIER_ID]);
            listeProbLoot = new List<int>();
            listeProbLoot.Add(30);
            listeProbLoot.Add(30);
            listeProbLoot.Add(15);
            listeProbLoot.Add(25);
            ListeEnnemis.Add(new Ennemi(GOBELIN_SHAMAN_ID, "Shaman gobelin", 2, 50, 12, 12, 9, 16, 12, 150, 15, Properties.Resources.spectre, Ennemi.StrategieAction.AttaquePlusFort, listeLoot, listeProbLoot,1,40));

            //Loup
            listeLoot = new List<Item.Item>();
            listeLoot.Add(null);
            listeProbLoot = new List<int>();
            listeProbLoot.Add(100);
            ListeEnnemis.Add(new Ennemi(LOUP_ID, "Loup", 1, 40, 18, 9, 14, 16, 10, 100, 0, Properties.Resources.spectre, Ennemi.StrategieAction.AttaqueAleatoire, listeLoot, listeProbLoot));

            //Crabe Géant
            listeLoot = new List<Item.Item>();
            listeLoot.Add(null);
            listeProbLoot = new List<int>();
            listeProbLoot.Add(100);
            ListeEnnemis.Add(new Ennemi(CRABE_GEANT_ID, "Crabe géant", 1, 50, 6, 8, 8, 17, 14, 100, 0, Properties.Resources.spectre, Ennemi.StrategieAction.AttaqueAleatoire, listeLoot, listeProbLoot));

            //Homme-Crabe
            listeLoot = new List<Item.Item>();
            listeLoot.Add(null);
            listeLoot.Add(li.ListeBoucliers[li.BOUCLIER_BOIS_ID]);
            listeLoot.Add(li.ListeArmes[li.DAGUE_BRONZE_ID]);
            listeLoot.Add(li.ListeConsommables[li.POTION_VIE_MINEURE_ID]);
            listeProbLoot = new List<int>();
            listeProbLoot.Add(80);
            listeProbLoot.Add(4);
            listeProbLoot.Add(6);
            listeProbLoot.Add(10);
            ListeEnnemis.Add(new Ennemi(HOMME_CRABE_GUERRIER_ID, "Homme-crabe", 1, 40, 10, 10, 10, 14, 10, 100, 5, Properties.Resources.spectre, Ennemi.StrategieAction.AttaquePlusFort, listeLoot, listeProbLoot));

            //Roi Homme-Crabe
            listeLoot = new List<Item.Item>();
            listeLoot.Add(li.ListeBoucliers[li.BOUCLIER_BOIS_ID]);
            listeLoot.Add(li.ListeArmes[li.BATARDE_BRONZE_ID]);
            listeLoot.Add(li.ListeArmures[li.ARMURE_BRONZE_ID]);
            listeProbLoot = new List<int>();
            listeProbLoot.Add(15);
            listeProbLoot.Add(35);
            listeProbLoot.Add(40);
            ListeEnnemis.Add(new Ennemi(HOMME_CRABE_ROI_ID, "Roi homme-crabe", 2, 60, 14, 14, 12, 17, 14, 200, 15, Properties.Resources.spectre, Ennemi.StrategieAction.AttaquePlusFort, listeLoot, listeProbLoot, 2, 35));
        }
    }
}
