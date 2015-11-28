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

    public partial class MenuJeu : Form
    {
        public MenuJeu()
        {
            InitializeComponent();
            AfficherGroupeAventurier();
            AfficherDetailsAventurier(0);
        }

        private void CacherGroupeAventurier()
        {
            for (var i = 1; i < 4; i++)
            {
                this.Controls.Find("txtNom" + i, true)[0].Visible = false;
                this.Controls.Find("lblLvl" + i, true)[0].Visible = false;
                this.Controls.Find("txtLvl" + i, true)[0].Visible = false;
                this.Controls.Find("lblXP" + i, true)[0].Visible = false;
                this.Controls.Find("txtXP" + i, true)[0].Visible = false;
            }
        }
            
        private void AfficherAventurier(Aventurier aventurier, Int32 i)
        {
            this.Controls.Find("txtNom" + i, true)[0].Visible = true;
            this.Controls.Find("lblLvl" + i, true)[0].Visible = true;
            this.Controls.Find("txtLvl" + i, true)[0].Visible = true;
            this.Controls.Find("lblXP" + i, true)[0].Visible = true;
            this.Controls.Find("txtXP" + i, true)[0].Visible = true;

            this.Controls.Find("txtNom" + i, true)[0].Text = aventurier.NomAventurier;
            this.Controls.Find("txtLvl" + i, true)[0].Text = aventurier.Niveau.ToString();
            this.Controls.Find("txtXP" + i, true)[0].Text = aventurier.Experience.ToString();

            PictureBox pBox = (PictureBox) this.Controls.Find("pboxAventurier" + i, true)[0];
            pBox.Image = aventurier.Imageclasse;
            PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxSelectedAventurier" + i, true)[0];
            pBoxSelected.Image = aventurier.Imageclasse;
        }

        private void AfficherGroupeAventurier()
        { 
            CacherGroupeAventurier();
            this.txtPiecesOr.Text = p.groupeAventurier.NbPiecesOr.ToString();

            var i = 1;
            foreach (var aventurier in p.groupeAventurier.Membres)
            {
                AfficherAventurier(aventurier, i);
                i++;
            }

            listInventaire.View = View.Details;
            listInventaire.Width = 229;
            listInventaire.Columns.Add("Nom de l'item", 175);
            listInventaire.Columns.Add("Nombre",50);

            var query = p.groupeAventurier.Inventaire.Select(x => x)
                .GroupBy(x => x, (a, b) => new { Nom = a.NomItem, Nb = b.Count() });

            var j = 0;
            foreach (var item in query)
            {
                listInventaire.Items.Add(item.Nom);
                listInventaire.Items[j].SubItems.Add(item.Nb.ToString());
                j++;
            }
        }

        private void AfficherDetailsAventurier(int indexAventurier)
        {
            txtNom.Text = p.groupeAventurier.Membres[indexAventurier].NomAventurier;
            txtNiv.Text = p.groupeAventurier.Membres[indexAventurier].Niveau.ToString();
            txtXP.Text = p.groupeAventurier.Membres[indexAventurier].Experience.ToString();
            txtClasse.Text = p.groupeAventurier.Membres[indexAventurier].NomClasse;

            txtEtat.Text = p.groupeAventurier.Membres[indexAventurier].Etat.ToString();
            txtPV.Text = p.groupeAventurier.Membres[indexAventurier].Pvmax.ToString();
            lblEnrgMana.Text = p.groupeAventurier.Membres[indexAventurier].Ressource == Ressource.Mana ? "Mana:" : "Énergie:";
            txtRessource.Text = p.groupeAventurier.Membres[indexAventurier].Ressource == Ressource.Mana ? p.groupeAventurier.Membres[indexAventurier].Manamax.ToString() : p.groupeAventurier.Membres[indexAventurier].Energiemax.ToString();
            txtInitiative.Text = p.groupeAventurier.Membres[indexAventurier].Initiativebase.ToString();

            txtForce.Text = p.groupeAventurier.Membres[indexAventurier].Forcebase.ToString();
            txtDefense.Text = p.groupeAventurier.Membres[indexAventurier].Defensebase.ToString();
            txtPrecision.Text = p.groupeAventurier.Membres[indexAventurier].Precisionbase.ToString();
            txtEsquive.Text = p.groupeAventurier.Membres[indexAventurier].Esquivebase.ToString();

            for (var i = 1; i < 4;i++)
            {
                PictureBox pBoxNotSelected = (PictureBox)this.Controls.Find("pboxAventurier" + i, true)[0];
                pBoxNotSelected.Visible = true;
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxSelectedAventurier" + i, true)[0];
                pBoxSelected.Visible = false;
            }

            PictureBox pBoxShow = (PictureBox)this.Controls.Find("pboxSelectedAventurier" + (indexAventurier+1), true)[0];
            pBoxShow.Visible = true;
            PictureBox pBoxHide = (PictureBox)this.Controls.Find("pboxAventurier" + (indexAventurier + 1), true)[0];
            pBoxHide.Visible = false;
            //Faire les armes ensuite (avec la gestion d'equipement ?
        }

        private void btnAventure_Click(object sender, EventArgs e)
        {
            Hide();
            Aventure choixAventure = new Aventure();
            choixAventure.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pboxSelectedAventurier1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        private void pboxSelectedAventurier2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        private void pboxSelectedAventurier3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        private void pboxAventurier1_Click(object sender, EventArgs e)
        {
            AfficherDetailsAventurier(0);
        }

        private void pboxAventurier2_Click(object sender, EventArgs e)
        {
            AfficherDetailsAventurier(1);
        }

        private void pboxAventurier3_Click(object sender, EventArgs e)
        {
            AfficherDetailsAventurier(2);
        }
    }
}
