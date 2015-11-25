using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes;
using JRPG.Classes.Aventurier;

namespace JRPG
{
    public partial class CreationAventurier : Form
    {

        public CreationAventurier()
        {
            InitializeComponent();
            rboGuerrier.Checked = true;

            //Les images pour les classes
            pboxGuerrier.Image = Properties.Resources.guerrier;
            pboxMage.Image = Properties.Resources.mage;
            pboxPretre.Image = Properties.Resources.pretre;
            pboxVoleur.Image = Properties.Resources.voleur;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAccepter_Click(object sender, EventArgs e)
        {
            Aventuriers premierAventurier;

            if (rboGuerrier.Checked)
            {
                premierAventurier = new Guerrier(tboxNomPerso.Text,0,1);
            }
            else if (rboMage.Checked)
            {
                premierAventurier = new Mage(tboxNomPerso.Text, 0, 1);
            }
            else if (rboVoleur.Checked)
            {
                premierAventurier = new Voleur(tboxNomPerso.Text, 0, 1);
            }
            else if (rboPretre.Checked)
            {
                premierAventurier = new Pretre(tboxNomPerso.Text, 0, 1);
            }
            else //pas bin propre a revalidé
            {
                premierAventurier = new Guerrier(tboxNomPerso.Text, 0, 1);
            }
            Program.groupeAventurier.AjouterAventurier(premierAventurier);

            Hide();
            MenuJeu menuJeu = new MenuJeu();
            menuJeu.ShowDialog();

        }

    }
}
