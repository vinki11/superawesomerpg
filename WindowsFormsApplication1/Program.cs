using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes;
using JRPG.Classes.Aventurier;
using JRPG.Classes.Item;

namespace JRPG
{
    static class Program
    {
        public static Groupe groupeAventurier = new Groupe();
        public static List<Item> Boutique = new List<Item>();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MenuPrincipal menuPrinc = new MenuPrincipal();
            Application.Run(menuPrinc);

            /*Combat fenCombat = new Combat();
            Application.Run(fenCombat);*/
        }
    }
}
