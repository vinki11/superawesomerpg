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
using JRPG.Classes.Item;

namespace JRPG
{
    using p = Program;
    using lc = ListeClasse;
    using li = ListeItem;

    public partial class Taverne : Form
    {
        int selectedAventurier = 0;
        

        public Taverne()
        {
            InitializeComponent();
            AfficherGroupeAventurier();
            SelectionnerAventurier(selectedAventurier);

            btnRetirer1.Visible = true;
            btnRetirer2.Visible = false;
            btnRetirer3.Visible = false;
        }

        private void SelectionnerAventurier(int indexAventurier)
        {
            switch (indexAventurier)
            {   case 0:
                    btnRetirer1.Visible = true;
                    btnRetirer2.Visible = false;
                    btnRetirer3.Visible = false;
                    break;
                case 1:
                    btnRetirer1.Visible = false;
                    btnRetirer2.Visible = true;
                    btnRetirer3.Visible = false;
                    ;
                    break;
                case 2:
                    btnRetirer1.Visible = false;
                    btnRetirer2.Visible = false;
                    btnRetirer3.Visible = true;
                    break;
            } 
            
            #region Picturebox sélectionné
            for (var i = 1; i < 4; i++)
            {
                PictureBox pBoxNotSelected = (PictureBox)this.Controls.Find("pboxAventurier" + i, true)[0];
                pBoxNotSelected.Visible = true;
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxSelectedAventurier" + i, true)[0];
                pBoxSelected.Visible = false;
            }

            PictureBox pBoxShow = (PictureBox)this.Controls.Find("pboxSelectedAventurier" + (indexAventurier + 1), true)[0];
            pBoxShow.Visible = true;
            PictureBox pBoxHide = (PictureBox)this.Controls.Find("pboxAventurier" + (indexAventurier + 1), true)[0];
            pBoxHide.Visible = false;
            #endregion
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

            PictureBox pBox = (PictureBox)this.Controls.Find("pboxAventurier" + i, false)[0];
            pBox.Image = aventurier.Imageclasse;
            PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxSelectedAventurier" + i, false)[0];
            pBoxSelected.Image = aventurier.Imageclasse;
            
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
            selectedAventurier = 0;
            SelectionnerAventurier(selectedAventurier);
        }

        private void pboxAventurier2_Click(object sender, EventArgs e)
        {
            selectedAventurier = 1;
            SelectionnerAventurier(selectedAventurier);
        }

        private void pboxAventurier3_Click(object sender, EventArgs e)
        {
            selectedAventurier = 2;
            SelectionnerAventurier(selectedAventurier);
        }

        private void btnRetirer1_Click(object sender, EventArgs e)
        {
            if (p.groupeAventurier.Membres.Count == 1)
            {
                MessageBox.Show("Votre groupe doit contenir AU MOINS 1 aventurier!");
            }
            else
            {
                p.groupeAventurier.RetirerAventurier(0);
                Hide();
                Taverne taverneRefresh = new Taverne();
                taverneRefresh.ShowDialog();
            }
        }

        private void btnRetirer2_Click(object sender, EventArgs e)
        {
            p.groupeAventurier.RetirerAventurier(1);
            Hide();
            Taverne taverneRefresh = new Taverne();
            taverneRefresh.ShowDialog();
        }

        private void btnRetirer3_Click(object sender, EventArgs e)
        {
            p.groupeAventurier.RetirerAventurier(2);
            Hide();
            Taverne taverneRefresh = new Taverne();
            taverneRefresh.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p.groupeAventurier.NbPiecesOr < 20)
            {
                MessageBox.Show("Vous n'avez pas assez de pièces d'or.");
            }
            else if (p.groupeAventurier.Membres.Count == 3)
            {
                MessageBox.Show("Votre groupe d'aventurier est complet. Vous devez retirer un aventurier si vous désirez en obtenir un autre.");
            }

            else
            {

                Hide();
                CreationAventurierTaverne taverneAventurier = new CreationAventurierTaverne();
                taverneAventurier.ShowDialog();
            }

        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            Hide();
            MenuJeu menuJ = new MenuJeu();
            menuJ.ShowDialog();
        }

        private void Taverne_Load(object sender, EventArgs e)
        {

        }
    }
}
