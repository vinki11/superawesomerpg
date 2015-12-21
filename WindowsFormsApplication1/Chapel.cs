using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes.Aventurier;

namespace JRPG
{
    using p = Program;
    public partial class Chapel : Form
    {
        int prix = 0;
        public Chapel()
        {
            InitializeComponent();
        }

        private void Chapel_Load(object sender, EventArgs e)
        {
            AfficherPieces();
            AucunMembreSelectionner();
            LoadMembreMort();
        }

        private void AfficherPieces()
        {
            txtPiecesOr.Text = p.groupeAventurier.NbPiecesOr.ToString();
        }

        private void AucunMembreSelectionner()
        {
            btnRes.Enabled = false;
            lblPieces.Visible = false;
            lblPrixRes.Visible = false;
            txtPrix.Visible = false;
        }

        private void MembreSelectionner()
        {
            btnRes.Enabled = true;
            lblPieces.Visible = true;
            lblPrixRes.Visible = true;
            txtPrix.Visible = true;
            prix = p.groupeAventurier.Membres[(cboMembreMort.SelectedItem as ComboboxItem).Value].Niveau * 10;

            txtPrix.Text = prix.ToString();


        }

        private void LoadMembreMort()
        {
            ComboboxItem cbAventurier;

            List<int> listeIdMembreMort = p.groupeAventurier.RetournerIdMembreMort();
            
            for(int i = 0; i < p.groupeAventurier.RetournerMembreMort().Count(); i++)
            {
                cbAventurier = new ComboboxItem();
                cbAventurier.Text = p.groupeAventurier.Membres[listeIdMembreMort[i]].NomAventurier;
                cbAventurier.Value = listeIdMembreMort[i];

                cboMembreMort.Items.Add(cbAventurier);
            }
        }

        private void ClearCboMort()
        {
            cboMembreMort.Items.Clear();
            cboMembreMort.SelectedItem = null;
            cboMembreMort.Text = "";
        }

        private void ResMembre()
        {
            if (prix <= p.groupeAventurier.NbPiecesOr)
            {
                p.groupeAventurier.Membres[(cboMembreMort.SelectedItem as ComboboxItem).Value].Etat = Etat.Normal;
                p.groupeAventurier.NbPiecesOr -= prix;
                AfficherPieces();
            }
            else
            {
                throw new Exception("Vous n'avez pas assez de pièces pour réssuciter cet aventurier.");
            }
        }

        private void cboMembreMort_SelectedIndexChanged(object sender, EventArgs e)
        {
            MembreSelectionner();
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            try
            {
                ResMembre();
                ClearCboMort();
                LoadMembreMort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Action invalide");
            }
            
        }
        
        private void btnRetour_Click(object sender, EventArgs e)
        {
            Hide();
            MenuJeu menujeu = new MenuJeu();
            menujeu.ShowDialog();
        }
    }
}
