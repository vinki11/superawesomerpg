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
            txtNom1.Visible = false;
            lblLvl1.Visible = false;
            txtLvl1.Visible = false;
            lblXP1.Visible = false;
            txtXP1.Visible = false;
            txtNom2.Visible = false;
            lblLvl2.Visible = false;
            txtLvl2.Visible = false;
            lblXP2.Visible = false;
            txtXP2.Visible = false;
            txtNom3.Visible = false;
            lblLvl3.Visible = false;
            txtLvl3.Visible = false;
            lblXP3.Visible = false;
            txtXP3.Visible = false;

            if (Program.groupeAventurier.Membres.Count >= 1)
            {
                txtNom1.Visible = true;
                lblLvl2.Visible = true;
                txtLvl1.Visible = true;
                lblXP1.Visible = true;
                txtXP1.Visible = true;
                txtNom1.Text = Program.groupeAventurier.Membres[0].NomAventurier;
                txtLvl1.Text = Program.groupeAventurier.Membres[0].Niveau.ToString();
                txtXP1.Text = Program.groupeAventurier.Membres[0].Experience.ToString();
            }

            if (Program.groupeAventurier.Membres.Count >= 2)
            {
                txtNom2.Visible = true;
                lblLvl2.Visible = true;
                txtLvl2.Visible = true;
                lblXP2.Visible = true;
                txtXP2.Visible = true;
                txtNom2.Text = Program.groupeAventurier.Membres[1].NomAventurier;
                txtLvl2.Text = Program.groupeAventurier.Membres[1].Niveau.ToString();
                txtXP2.Text = Program.groupeAventurier.Membres[1].Experience.ToString();
            }

            if (Program.groupeAventurier.Membres.Count >= 3)
            {
                txtNom3.Visible = true;
                lblLvl3.Visible = true;
                txtLvl3.Visible = true;
                lblXP3.Visible = true;
                txtXP3.Visible = true;
                txtNom3.Text = Program.groupeAventurier.Membres[2].NomAventurier;
                txtLvl3.Text = Program.groupeAventurier.Membres[2].Niveau.ToString();
                txtXP3.Text = Program.groupeAventurier.Membres[2].Experience.ToString();
            }
}

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
