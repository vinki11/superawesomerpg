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
    public partial class MenuJeu : Form
    {
        public MenuJeu()
        {
            InitializeComponent();
            afficherGroupeAventurier();
           

        }

        private void afficherGroupeAventurier()
        {
           txtNom1.Text = Program.groupeAventurier.Membres[0].NomAventurier;
           txtLvl1.Text = Program.groupeAventurier.Membres[0].Niveau.ToString();
           txtXP1.Text = Program.groupeAventurier.Membres[0].Experience.ToString();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
