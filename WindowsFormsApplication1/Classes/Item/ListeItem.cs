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

        //Constante Armes
        public const int DAGUE_BRONZE_ID = 0;
        public const int EPEE_BRONZE_ID = 1;
        public const int BATON_ID = 2;


        //Constante Armure
        public const int ARMURE_CUIR_ID = 0;
        public const int ARMURE_BRONZE_ID = 1;
        public const int ROBE_ID = 2;


        static ListeItem()
         {
             creerItems();
         }

        public static void creerItems()
        {
            //Armes
            ListeArmes.Add(new Arme(DAGUE_BRONZE_ID, "Dague de bronze", 10, 5, 10, true, false, false, true));
            ListeArmes.Add(new Arme(EPEE_BRONZE_ID, "Épée de bronze", 10, 10, 0, true, false, false, true));
            ListeArmes.Add(new Arme(BATON_ID, "Baton", 5, 2, 0, true, true, true, true));

            //Armure
            ListeArmures.Add(new Armure(ARMURE_CUIR_ID, "Armure de cuir", 10, 5,  true, false, false, true));
            ListeArmures.Add(new Armure(ARMURE_BRONZE_ID, "Armure de bronze", 20, 10, true, false, false, false));
            ListeArmures.Add(new Armure(ROBE_ID, "Robe", 5, 2,  true, true, true, true));

        }
        
        


    }
}
