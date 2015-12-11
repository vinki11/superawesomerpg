using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes.Item;

namespace JRPG
{
    using p = Program;

    public partial class Boutique : Form
    {
        public Boutique()
        {
            InitializeComponent();

            UpdatePieceOr();
            AfficherInventaire();
            AfficherBoutique();
        }

        private void btnVillage_Click(object sender, EventArgs e)
        {
            Hide();
            MenuJeu createJeu = new MenuJeu();
            createJeu.ShowDialog();
        }

        public void UpdatePieceOr()
        {
            this.txtPiecesOr.Text = p.groupeAventurier.NbPiecesOr.ToString();
        }

        public void AfficherInventaire()
        {
            //Initialisation des details du listview d'inventaire
            lvInventaire.Clear();
            lvInventaire.View = View.Details;
            lvInventaire.Width = 290;
            lvInventaire.Columns.Add("Nom de l'item", 175);
            lvInventaire.Columns.Add("Nombre", 50);
            lvInventaire.Columns.Add("Prix unit.", 60);

            var query = p.groupeAventurier.Inventaire.Select(x => x)
                .GroupBy(x => x, (a, b) => new { Nom = a.NomItem, item = a, Nb = b.Count() })
                .OrderBy(x => x.Nom);

            var j = 0;
            foreach (var item in query)
            {
                lvInventaire.Items.Add(item.Nom);
                lvInventaire.Items[j].Tag = item.item;
                lvInventaire.Items[j].SubItems.Add(item.Nb.ToString());
                lvInventaire.Items[j].SubItems.Add(item.item.PrixRevente.ToString());
                j++;
            }
        }

        public void AfficherBoutique()
        {
            lvBoutique.Clear();
            lvBoutique.View = View.Details;
            lvBoutique.Width = 290;
            lvBoutique.Columns.Add("Nom de l'item", 175);
            lvBoutique.Columns.Add("Nombre", 50);
            lvBoutique.Columns.Add("Prix unit.", 60);

            var query = p.Boutique.Select(x => x)
                .GroupBy(x => x, (a, b) => new { Nom = a.NomItem, item = a, Nb = b.Count() })
                .OrderBy(x => x.Nom);

            var j = 0;
            foreach (var item in query)
            {
                lvBoutique.Items.Add(item.Nom);
                lvBoutique.Items[j].Tag = item.item;
                lvBoutique.Items[j].SubItems.Add(item.Nb.ToString());
                lvBoutique.Items[j].SubItems.Add(Math.Ceiling(item.item.PrixRevente*1.5).ToString());
                j++;
            }
        }

        private void btnVente_Click(object sender, EventArgs e)
        {
            if (lvInventaire.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = lvInventaire.SelectedItems[0];
                Item item = (Item)lvItem.Tag;
                p.groupeAventurier.RetirerItem(item);
                p.groupeAventurier.NbPiecesOr += item.PrixRevente;

                p.Boutique.Add(item);

                UpdatePieceOr();
                AfficherInventaire();
                AfficherBoutique();
            }
        }

        private void btnAcheter_Click(object sender, EventArgs e)
        {
            if (lvBoutique.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = lvBoutique.SelectedItems[0];
                Item item = (Item)lvItem.Tag;
                int prix = (int)Math.Ceiling(item.PrixRevente*1.5);

                if (p.groupeAventurier.NbPiecesOr >= prix)
                {
                    p.groupeAventurier.AjouterItem(item);
                    p.groupeAventurier.NbPiecesOr -= prix;

                    p.Boutique.Remove(item);
                }
                else
                {
                    MessageBox.Show("Fonds insuffisants");
                }
                UpdatePieceOr();
                AfficherInventaire();
                AfficherBoutique();
            }
        }
    }
}
