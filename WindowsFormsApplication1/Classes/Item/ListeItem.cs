using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes;
using JRPG.Classes.Aventurier;
using JRPG.Classes.Ennemi;
using JRPG.Classes.Item;

namespace JRPG
{
    public class ListeItem
    {
        //Liste d'éléments
        public static readonly List<Arme> ListeArmes = new List<Arme>();
        public static readonly List<Bouclier> ListeBoucliers = new List<Bouclier>();
        public static readonly List<Armure> ListeArmures = new List<Armure>();
        public static readonly List<Consommable> ListeConsommables = new List<Consommable>();

        //Constante Armes
        public const int DAGUE_BRONZE_ID = 0;
        public const int EPEE_BRONZE_ID = 1;
        public const int BATON_ID = 2;
        public const int BATARDE_BRONZE_ID = 3;

        //Constante Armure
        public const int ARMURE_CUIR_ID = 0;
        public const int ARMURE_BRONZE_ID = 1;
        public const int ROBE_ID = 2;

        //Constante Bouclier
        public const int BOUCLIER_BOIS_ID = 0;
        public const int ECU_ACIER_ID = 1;

        //Constante Consommable
        public const int POTION_VIE_MINEURE_ID = 0;
        public const int POTION_MANA_MINEURE_ID = 1;
        public const int POTION_ENERGIE_MINEURE_ID = 2;
        public const int FLASQUE_RAVIGORANTE_ID = 3;

        static ListeItem()
         {
             creerItems();
         }

        public static void creerItems()
        {
            //Armes
            ListeArmes.Add(new Arme(DAGUE_BRONZE_ID, "Dague de bronze", 10, 5, 10, pUtilisableGuerrier:true, pUtilisableVoleur:true));
            ListeArmes.Add(new Arme(EPEE_BRONZE_ID, "Épée de bronze", 10, 10, 0, pUtilisableGuerrier:true));
            ListeArmes.Add(new Arme(BATON_ID, "Baton", 5, 2, 0, true, true, true, true,true));
            ListeArmes.Add(new Arme(BATARDE_BRONZE_ID, "Épée batarde de bronze", 15, 15, 0, true, pUtilisableGuerrier:true));

            //Armure
            ListeArmures.Add(new Armure(ARMURE_CUIR_ID, "Armure de cuir", 10, 4,  pUtilisableGuerrier:true, pUtilisableVoleur:true));
            ListeArmures.Add(new Armure(ARMURE_BRONZE_ID, "Armure de bronze", 20, 6, pUtilisableGuerrier:true));
            ListeArmures.Add(new Armure(ROBE_ID, "Robe", 5, 2, true, true, true, true));

            //Bouclier
            ListeBoucliers.Add(new Bouclier(BOUCLIER_BOIS_ID, "Bouclier en bois", 10, 5, pUtilisableGuerrier:true));
            ListeBoucliers.Add(new Bouclier(ECU_ACIER_ID, "Écu en acier", 15, 8, pUtilisableGuerrier:true));

            //
            ListeConsommables.Add(new Consommable(POTION_VIE_MINEURE_ID, "Potion de vie mineure", 2, 25));
            ListeConsommables.Add(new Consommable(POTION_MANA_MINEURE_ID, "Potion de mana mineure", 2, pMana:50, pUtilisableGuerrier:false, pUtilisableVoleur:false));
            ListeConsommables.Add(new Consommable(POTION_ENERGIE_MINEURE_ID, "Potion d'énergie mineure", 2, pEnergie:30, pUtilisableMage:false, pUtilisablePretre:false));
            ListeConsommables.Add(new Consommable(FLASQUE_RAVIGORANTE_ID, "Flasque ravigorante", 5,25,40,25));


        }
        
        


    }
}
