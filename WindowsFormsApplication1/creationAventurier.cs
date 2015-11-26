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
    using p = Program;
    using li = ListeItem;

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

            rboGuerrier.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rboMage.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rboVoleur.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rboPretre.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);

            //Par défaut on est sur le guerrier
            txtArme.Text = li.ListeArmes[li.EPEE_BRONZE_ID].NomItem;
            txtArmure.Text = li.ListeArmures[li.ARMURE_BRONZE_ID].NomItem;
            txtBouclier.Text = "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        protected void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                if (rboGuerrier.Checked)
                {
                    txtArme.Text = li.ListeArmes[li.EPEE_BRONZE_ID].NomItem;
                    txtArmure.Text = li.ListeArmures[li.ARMURE_BRONZE_ID].NomItem;
                }
                else if (rboMage.Checked)
                {
                    txtArme.Text = li.ListeArmes[li.BATON_ID].NomItem;
                    txtArmure.Text = li.ListeArmures[li.ROBE_ID].NomItem;
                }
                else if (rboVoleur.Checked)
                {
                    txtArme.Text = li.ListeArmes[li.DAGUE_BRONZE_ID].NomItem;
                    txtArmure.Text = li.ListeArmures[li.ARMURE_CUIR_ID].NomItem;
                }
                else if (rboPretre.Checked)
                {
                    txtArme.Text = li.ListeArmes[li.BATON_ID].NomItem;
                    txtArmure.Text = li.ListeArmures[li.ROBE_ID].NomItem;
                }
            }
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
            p.groupeAventurier.AjouterAventurier(premierAventurier);

            Hide();
            MenuJeu menuJeu = new MenuJeu();
            menuJeu.ShowDialog();

        }
    }
}
