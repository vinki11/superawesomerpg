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
    public class World
    {
        //Liste d'éléments
        public static readonly List<Items> ListeItems = new List<Items>();

        //Constante Armes
        public const int DAGUE_BRONZE_ID = 1;
        public const int EPEE_BRONZE_ID = 2;
        public const int BATON_ID = 3;

        Arme dagueBronze = new Arme(DAGUE_BRONZE_ID, "Dague de bronze", 10, 5, 10, true, true, false, true);
        Arme epeeBronze = new Arme(EPEE_BRONZE_ID, "Épée de bronze", 10, 10, 0, true, false, false, true);
        Arme baton = new Arme(BATON_ID, "Baton", 5, 5, 0, true, true, true, true);

        /* static World()
         {
             creerItems();
         }*/

        public static void creerItems()
        {
            Arme dagueBronze = new Arme(DAGUE_BRONZE_ID, "Dague de bronze", 10, 5, 10, true, true, false, true);
            Arme epeeBronze = new Arme(EPEE_BRONZE_ID, "Épée de bronze", 10, 10, 0, true, false, false, true);
            Arme baton = new Arme(BATON_ID, "Baton", 5, 5, 0, true, true, true, true);
            /*
            ListeItems.Add(new Arme(DAGUE_BRONZE_ID, "Dague de bronze", 10, 5, 10, true, true, false, true));
            ListeItems.Add(new Arme(EPEE_BRONZE_ID, "Épée de bronze", 10, 10, 0, true, false, false, true));
            ListeItems.Add(new Arme(BATON_ID, "Baton", 5, 5, 0, true, true, true, true));
            */
        }
        
        


    }
}
