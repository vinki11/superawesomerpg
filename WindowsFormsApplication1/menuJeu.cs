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

            /*listInventaire.Items.Add("Nom Item");
            foreach (var item in p.groupeAventurier.Inventaire)
            {
                listInventaire.Items[0].SubItems.Add(item.NomItem);
            }*/
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

    }
}
