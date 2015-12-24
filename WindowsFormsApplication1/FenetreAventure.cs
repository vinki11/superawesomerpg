using System;
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
        
        private void cboChoisirAventure_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInformationsAventure.Text = la.ListeAventures[(cboChoisirAventure.SelectedItem as ComboboxItem).Value].DescriptionAventure != null ? la.ListeAventures[(cboChoisirAventure.SelectedItem as ComboboxItem).Value].DescriptionAventure : ""; 
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
                if ((cboChoisirAventure.SelectedItem as ComboboxItem).Value == la.TEMPLE_MAL_ID)
                {
                    MessageBox.Show("Pour pouvoir profiter de cette aventure vous devez acheter le DLC d'une valeur de 1.99$. Rendez vous sur le site web du jeu pour plus de détails.", "Vous ne possédez pas cette aventure");
                }
                else
                {
                    Hide();
                    Combat newCombat = new Combat((cboChoisirAventure.SelectedItem as ComboboxItem).Value, 1);
                    newCombat.ShowDialog();
                }
            }
        }

    }
}
