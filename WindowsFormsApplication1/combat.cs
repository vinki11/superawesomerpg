using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes.Aventure;
using JRPG.Classes.Ennemi;
using JRPG.Classes.Aventurier;

namespace JRPG
{
    using p = Program;
    using la = ListeAventure;

    public partial class Combat : Form
    {
        int idAventure;
        int etapeAventure;
        int indexEtape;
        int nbEtapesAventure;

        string typeAction;
        int cibleId;

        List<Personnage> lstPersonnages = new List<Personnage>();

        Personnage persoActif;
        public Combat(int aventureId, int etapeId)
        {
            InitializeComponent();
            idAventure = aventureId;
            etapeAventure = etapeId;
            indexEtape = etapeAventure - 1;
            nbEtapesAventure = la.ListeAventures[aventureId].ListeGroupeEnnemis.Count();

            //Stack stackInitiative = new Stack();
        }

        private void Combat_Load(object sender, EventArgs e)
        {
            AfficherElements();
            CalculerInitiative();
            NouveauTour();
        }

        struct Personnage
        {
            public TypePersonnage typePerso;
            public int initiative;
            public int idPerso;
            public string nomPerso;
        }

        enum TypePersonnage
        {
            AVENTURIER,
            ENNEMI
        }
        private void NouveauTour()
        {
            pboxAction.Image = null;
            lblNomAction.Text = "Choississez un action";
            btnFinTour.Enabled = false;

            //Gestion de la bordure selected

            //Pbox des ennemis
            for (var i = 1; i <= la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi.Count(); i++)
            {
                PictureBox pBox = (PictureBox)this.Controls.Find("pboxEnnemi" + i, true)[0];
                pBox.Visible = true;
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxEnnemiSelected" + i, true)[0];
                pBoxSelected.Visible = false;

            }

            //Pbox des aventuriers
            for (var i = 1; i <= p.groupeAventurier.Membres.Count(); i++)
            {
                PictureBox pBox = (PictureBox)this.Controls.Find("pboxAventurier" + i, true)[0];
                pBox.Visible = true;
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxAventurierSelected" + i, true)[0];
                pBoxSelected.Visible = false;
            }

            if (persoActif.typePerso == TypePersonnage.AVENTURIER)
            {
                PictureBox pBox = (PictureBox)this.Controls.Find("pboxAventurier" + (persoActif.idPerso + 1), true)[0];
                pBox.Visible = false;
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxAventurierSelected" + (persoActif.idPerso+1), true)[0];
                pBoxSelected.Visible = true;
            }
            else
            {
                PictureBox pBox = (PictureBox)this.Controls.Find("pboxEnnemi" + (persoActif.idPerso + 1), true)[0];
                pBox.Visible = false;
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxEnnemiSelected" + (persoActif.idPerso + 1), true)[0];
                pBoxSelected.Visible = true;
            }
        }

        private void CalculerInitiative()
        {

            int indAventurier = 0;
            foreach(Aventurier aventurier in p.groupeAventurier.Membres)
            {
                Personnage perso = new Personnage();
                perso.nomPerso = aventurier.NomAventurier;
                perso.initiative = aventurier.Initiativeactuel;
                perso.typePerso = TypePersonnage.AVENTURIER;
                perso.idPerso = indAventurier;
                lstPersonnages.Add(perso);
                indAventurier++;
            }

            int indEnnemi = 0;
            foreach (Ennemi ennemi in la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi)
            {
                Personnage perso = new Personnage();
                perso.nomPerso = ennemi.Nom;
                perso.initiative = ennemi.Initiative;
                perso.typePerso = TypePersonnage.ENNEMI;
                perso.idPerso = indEnnemi;
                lstPersonnages.Add(perso);
                indEnnemi++;
            }

            lstPersonnages = lstPersonnages.OrderByDescending(o => o.initiative).ToList();


            listviewListeInitiative.Clear();
            listviewListeInitiative.View = View.List;
            for (int i = 0;i < lstPersonnages.Count(); i++)
            {
                listviewListeInitiative.Items.Add(lstPersonnages[i].nomPerso + " :" + lstPersonnages[i].initiative);
                //MessageBox.Show(lstPersonnages[i].nomPerso + " : " + lstPersonnages[i].initiative.ToString());
            }

            persoActif = lstPersonnages.First();
        }

        private void CacherElements()
        {
            //Cacher les éléments des ennemis
            for (var i = 1; i < 7; i++)
            {
                this.Controls.Find("lblNomEnnemi" + i, true)[0].Visible = false;
                this.Controls.Find("lblPVEnnemi" + i, true)[0].Visible = false;
                this.Controls.Find("lblMaxPvEnnemi" + i, true)[0].Visible = false;
                PictureBox pBox = (PictureBox)this.Controls.Find("pboxEnnemi" + i, true)[0];
                pBox.Visible = false;
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxEnnemiSelected" + i, true)[0];
                pBoxSelected.Visible = false;

            }

            //Cacher les éléments des aventuriers
            for (var i = 1; i < 4; i++)
            {
                this.Controls.Find("lblNomAventurier" + i, true)[0].Visible = false;
                this.Controls.Find("lblPVAventurier" + i, true)[0].Visible = false;
                this.Controls.Find("lblMaxPvAventurier" + i, true)[0].Visible = false;
                this.Controls.Find("lblRessource" + i, true)[0].Visible = false;
                PictureBox pBox = (PictureBox)this.Controls.Find("pboxAventurier" + i, true)[0];
                pBox.Visible = false;
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxAventurierSelected" + i, true)[0];
                pBoxSelected.Visible = false;
            }

            //Cacher les éléments d'attaque spécial
            for (var i = 1; i < 4; i++)
            {
                this.Controls.Find("lblManaSort" + i, true)[0].Visible = false;
            }
        }

        private void AfficherElements()
        {
            AfficherInfoAventure();
            CacherElements();
            AfficherInfosEnnemies(la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi.Count());
            AfficherInfosAventuriers(p.groupeAventurier.Membres.Count());
        }

        private void AfficherInfosEnnemies(int nbEnnemis)
        {
            for (var i = 1; i < (nbEnnemis+1); i++)
            {
                this.Controls.Find("lblNomEnnemi" + i, true)[0].Visible = true;
                this.Controls.Find("lblPVEnnemi" + i, true)[0].Visible = true;
                this.Controls.Find("lblMaxPvEnnemi" + i, true)[0].Visible = true;

                this.Controls.Find("lblNomEnnemi" + i, true)[0].Text = la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[(i - 1)].Nom;
                this.Controls.Find("lblPVEnnemi" + i, true)[0].Text = la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[(i - 1)].PvActuel.ToString();
                this.Controls.Find("lblMaxPvEnnemi" + i, true)[0].Text = "/  " + la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[(i - 1)].PvMax.ToString();
                this.Controls.Find("lblMaxPvEnnemi" + i, true)[0].Left = this.Controls.Find("lblPVEnnemi" + i, true)[0].Right;

                this.Controls.Find("lblPVEnnemi" + i, true)[0].ForeColor = Color.Red;
                this.Controls.Find("lblMaxPvEnnemi" + i, true)[0].ForeColor = Color.Red;


                PictureBox pBox = (PictureBox)this.Controls.Find("pboxEnnemi" + i, true)[0];
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxEnnemiSelected" + i, true)[0];
                pBox.Visible = true;
                pBox.Image = la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[(i - 1)].ImageEnnemi;
                pBoxSelected.Image = la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[(i - 1)].ImageEnnemi;
            }
        }

        private void AfficherInfosAventuriers(int nbAventuriers)
        {
            for (var i = 1; i < (nbAventuriers + 1); i++)
            {
                this.Controls.Find("lblNomAventurier" + i, true)[0].Visible = true;
                this.Controls.Find("lblPVAventurier" + i, true)[0].Visible = true;
                this.Controls.Find("lblMaxPvAventurier" + i, true)[0].Visible = true;
                this.Controls.Find("lblRessource" + i, true)[0].Visible = true;

                this.Controls.Find("lblNomAventurier" + i, true)[0].Text = p.groupeAventurier.Membres[(i - 1)].NomAventurier;
                this.Controls.Find("lblPVAventurier" + i, true)[0].Text = p.groupeAventurier.Membres[(i - 1)].Pvactuel.ToString();
                this.Controls.Find("lblMaxPvAventurier" + i, true)[0].Text = "/  " + p.groupeAventurier.Membres[(i - 1)].Pvmax.ToString();
                this.Controls.Find("lblMaxPvAventurier" + i, true)[0].Left = this.Controls.Find("lblPVAventurier" + i, true)[0].Right;
                this.Controls.Find("lblRessource" + i, true)[0].Text = p.groupeAventurier.Membres[(i - 1)].Ressource == Ressource.Mana ? p.groupeAventurier.Membres[(i - 1)].Manaactuel.ToString() : p.groupeAventurier.Membres[(i - 1)].Energieactuel.ToString();

                this.Controls.Find("lblPVAventurier" + i, true)[0].ForeColor = Color.Red;
                this.Controls.Find("lblMaxPvAventurier" + i, true)[0].ForeColor = Color.Red;
                this.Controls.Find("lblRessource" + i, true)[0].ForeColor = p.groupeAventurier.Membres[(i - 1)].Ressource == Ressource.Mana ? Color.Blue : Color.Brown;


                PictureBox pBox = (PictureBox)this.Controls.Find("pboxAventurier" + i, true)[0];
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxAventurierSelected" + i, true)[0];
                pBox.Visible = true;
                pBox.Image = p.groupeAventurier.Membres[(i-1)].Imageclasse;
                pBoxSelected.Image = p.groupeAventurier.Membres[(i - 1)].Imageclasse;
            }
        }

        private void AfficherInfoAventure()
        {
            lblNomAventure.Text = la.ListeAventures[idAventure].NomAventure;
            lblEtapeAventure.Text = etapeAventure + "/" + nbEtapesAventure;

        }

        #region paint des borders des picturebox

        private void pboxEnnemiSelected1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        private void pboxEnnemiSelected2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        private void pboxEnnemiSelected3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        private void pboxEnnemiSelected4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        private void pboxEnnemiSelected5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        private void pboxEnnemiSelected6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        private void pboxAventurierSelected3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        private void pboxAventurierSelected2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        private void pboxAventurierSelected1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkOrange, ButtonBorderStyle.Solid);
        }

        #endregion

        private void ProchainTour()
        {
            Personnage tempo;

            tempo = lstPersonnages.First();
            lstPersonnages.Remove(lstPersonnages.First());
            lstPersonnages.Add(tempo);

            listviewListeInitiative.Clear();
            listviewListeInitiative.View = View.List;
            for (int i = 0; i < lstPersonnages.Count(); i++)
            {
                listviewListeInitiative.Items.Add(lstPersonnages[i].nomPerso + " :" + lstPersonnages[i].initiative);
                //MessageBox.Show(lstPersonnages[i].nomPerso + " : " + lstPersonnages[i].initiative.ToString());
            }

            cboChoisirCible.Items.Clear();
            cboChoisirCible.SelectedItem = null;
            cboChoisirCible.Text = "";

            persoActif = lstPersonnages.First();
            NouveauTour();

        }

        private void btnFinTour_Click(object sender, EventArgs e)
        {
            if (persoActif.typePerso == TypePersonnage.ENNEMI)
            {
                ProchainTour();
                //NouveauTour();
            }
            else
            {
                cibleId = (cboChoisirCible.SelectedItem as ComboboxItem).Value;
                //MessageBox.Show("Vous attaquer la cible : " + la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[(cibleId)].Nom);
                if (typeAction == "Attaque")
                {   
                    LancerAttaque(p.groupeAventurier.Membres[persoActif.idPerso], la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[cibleId]);
                }

                ProchainTour();
            }
        }

        private void pboxAttaquer_Click(object sender, EventArgs e)
        {
            pboxAction.Image = pboxAttaquer.Image;
            lblNomAction.Text = "Attaque";

            ComboboxItem cbCible;

            for (var i = 0; i < la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi.Count(); i++ )
            {
                if (la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[i].Etat != Etat.Mort)
                {
                    cbCible = new ComboboxItem();
                    cbCible.Text = la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[i].Nom;
                    cbCible.Value = i;
                    cboChoisirCible.Items.Add(cbCible);
                }
            }

            btnFinTour.Enabled = true;
            cboChoisirCible.SelectedItem = cboChoisirCible.Items[0];
            typeAction = "Attaque";

        }

        private void LancerAttaque(Aventurier aventurier, Ennemi cible)
        {
            aventurier.Attaquer(cible);
            this.Controls.Find("lblPVEnnemi" + (cibleId + 1), true)[0].Text = cible.PvActuel > 0 ? cible.PvActuel.ToString() : "0";
            if (cible.PvActuel <= 0)
            {
                Personnage tempo = new Personnage();
                foreach (Personnage perso in lstPersonnages)
                {
                    if (perso.typePerso == TypePersonnage.ENNEMI && perso.idPerso == cibleId)
                    {
                        tempo = perso;
                    }
                }
                lstPersonnages.Remove(tempo);
            }
        }
    }
}
