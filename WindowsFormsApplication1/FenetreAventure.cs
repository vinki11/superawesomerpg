﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes.Aventure;

namespace JRPG
{
    using p = Program;
    using la = ListeAventure;
    public partial class FenetreAventure : Form
    {
        public FenetreAventure()
        {
            InitializeComponent();
        }

        private void Aventure_Load(object sender, EventArgs e)
        {
            cboChoisirAventure.Items.Clear();
            ComboboxItem cbAventure;
            int niveauGroupe = p.groupeAventurier.PlusHautNiveau();

            foreach (Aventure aventure in la.ListeAventures)
            {
                if (niveauGroupe >= aventure.NiveauRequis)
                {
                    cbAventure = new ComboboxItem();
                    cbAventure.Text = aventure.NomAventure + " (" + aventure.NiveauAventure + ")";
                    cbAventure.Value = aventure.IdAventure;
                    cboChoisirAventure.Items.Add(cbAventure);
                }
            }
        }

        private void btnRetourVillage_Click(object sender, EventArgs e)
        {
            Hide();
            MenuJeu createJeu = new MenuJeu();
            createJeu.ShowDialog();
        }

        private void btnAventure_Click(object sender, EventArgs e)
        {
            if (cboChoisirAventure.SelectedItem == null)
            {
                MessageBox.Show("Vous devez sélectionner une aventure!", "Aventure non valide");
            }
            else
            {
                //MessageBox.Show("Id de l'aventure choisi : " + (cboChoisirAventure.SelectedItem as ComboboxItem).Value);
            }
        }
    }
}