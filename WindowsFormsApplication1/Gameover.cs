using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JRPG
{
    using p = Program;
    public partial class Gameover : Form
    {
        public Gameover()
        {
            InitializeComponent();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Hide();
            MenuPrincipal menuMain = new MenuPrincipal();
            menuMain.ShowDialog();
        }

        private void Gameover_Load(object sender, EventArgs e)
        {
            p.groupeAventurier = new Classes.Groupe();
            Classes.Ennemi.ListeEnnemi.CreerEnnemis();
            Classes.Aventure.ListeAventure.creerAventures();
        }
    }
}
