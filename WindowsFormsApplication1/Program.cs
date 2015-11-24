using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes;
using JRPG.Classes.Aventurier;

namespace JRPG
{
    static class Program
    {
        public static Groupe groupeAventurier = new Groupe();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MenuPrincipal menuPrinc = new MenuPrincipal();
            Application.Run(menuPrinc);
        }
    }
}
