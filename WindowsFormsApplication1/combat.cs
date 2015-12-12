﻿using System;
using System.Collections;
using System.Collections.Generic;
//using System.Timers;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes.Aventure;
using JRPG.Classes.Ennemi;
using JRPG.Classes.Item;
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

        //private static Timer timerEnnemi;
        //private static System.Timers.Timer timerEnnemi;

        List<Personnage> lstPersonnages = new List<Personnage>();

        Personnage persoActif;
        public Combat(int aventureId, int etapeId)
        {
            ListeEnnemi.CreerEnnemis();
            la.creerAventures();
            InitializeComponent();
            idAventure = aventureId;
            etapeAventure = etapeId;
            indexEtape = etapeAventure - 1;
            nbEtapesAventure = la.ListeAventures[aventureId].ListeGroupeEnnemis.Count();

            //Stack stackInitiative = new Stack();

        }

        private void Combat_Load(object sender, EventArgs e)
        {
            //Tempo tests
            //p.groupeAventurier.Membres.RemoveAt(2);
            //p.groupeAventurier.Membres.RemoveAt(1);
            //p.groupeAventurier.Membres[0].Etat = Etat.Mort;
            //p.groupeAventurier.Membres[2].Energieactuel = 15;

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

            pboxSort1.Image = p.groupeAventurier.Membres[persoActif.idPerso].ImageCompetenceA;
            pboxSort2.Image = p.groupeAventurier.Membres[persoActif.idPerso].ImageCompetenceB;
            pboxSort3.Image = p.groupeAventurier.Membres[persoActif.idPerso].ImageCompetenceC;

            lblManaSort1.Text = p.groupeAventurier.Membres[persoActif.idPerso].CoutCompetenceA.ToString();
            lblManaSort2.Text = p.groupeAventurier.Membres[persoActif.idPerso].CoutCompetenceB.ToString();
            lblManaSort3.Text = p.groupeAventurier.Membres[persoActif.idPerso].CoutCompetenceC.ToString();
            lblManaSort1.ForeColor = p.groupeAventurier.Membres[persoActif.idPerso].Ressource == Ressource.Mana ? Color.Blue : Color.Brown;
            lblManaSort2.ForeColor = p.groupeAventurier.Membres[persoActif.idPerso].Ressource == Ressource.Mana ? Color.Blue : Color.Brown;
            lblManaSort3.ForeColor = p.groupeAventurier.Membres[persoActif.idPerso].Ressource == Ressource.Mana ? Color.Blue : Color.Brown;
            lblSort1.Text = p.groupeAventurier.Membres[persoActif.idPerso].NomCompetenceA;
            lblSort2.Text = p.groupeAventurier.Membres[persoActif.idPerso].NomCompetenceB;
            lblSort3.Text = p.groupeAventurier.Membres[persoActif.idPerso].NomCompetenceC;

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
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxAventurierSelected" + (persoActif.idPerso + 1), true)[0];
                pBoxSelected.Visible = true;

                if (p.groupeAventurier.Membres[persoActif.idPerso].Etat == Etat.Etourdi)
                {
                    AjouterTexteHistorique(p.groupeAventurier.Membres[persoActif.idPerso].NomAventurier + " est étourdi et ne peut pas agir!");
                    //MessageBox.Show(p.groupeAventurier.Membres[persoActif.idPerso].NomAventurier + " est étourdi et ne peut pas agir!");
                    p.groupeAventurier.Membres[persoActif.idPerso].Etat = Etat.Normal;
                    ProchainTour();
                }
            }
            else
            {
                PictureBox pBox = (PictureBox)this.Controls.Find("pboxEnnemi" + (persoActif.idPerso + 1), true)[0];
                pBox.Visible = false;
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxEnnemiSelected" + (persoActif.idPerso + 1), true)[0];
                pBoxSelected.Visible = true;

                if (la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[persoActif.idPerso].Etat == Etat.Etourdi)
                {
                    AjouterTexteHistorique(la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[persoActif.idPerso].Nom + " est étourdi et ne peut pas agir!");
                    //MessageBox.Show(la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[persoActif.idPerso].Nom + " est étourdi et ne peut pas agir!");
                    la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[persoActif.idPerso].Etat = Etat.Normal;
                    ProchainTour();
                }
                else
                {
                        AgirMonstre();
                        /*
                    timerEnnemi.Tick += new EventHandler(EventTimer);

                    timerEnnemi.Interval = 2000;
                    timerEnnemi.Start();*/
                }

            }

        }

       /* private static void EventTimer(Object myObject,
                                            EventArgs myEventArgs)
        {
            timerEnnemi.Stop();
        }*/

        private void CalculerInitiative()
        {

            int indAventurier = 0;
            foreach (Aventurier aventurier in p.groupeAventurier.Membres)
            {
                if (aventurier.Etat != Etat.Mort)
                {
                    Personnage perso = new Personnage();
                    perso.nomPerso = aventurier.NomAventurier;
                    perso.initiative = aventurier.Initiativeactuel;
                    perso.typePerso = TypePersonnage.AVENTURIER;
                    perso.idPerso = indAventurier;
                    lstPersonnages.Add(perso);
                }
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
            for (int i = 0; i < lstPersonnages.Count(); i++)
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
            /*
            //Cacher les éléments d'attaque spécial
            for (var i = 1; i < 4; i++)
            {
                this.Controls.Find("lblManaSort" + i, true)[0].Visible = false;
            }
            */
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
            for (var i = 1; i < (nbEnnemis + 1); i++)
            {
                this.Controls.Find("lblNomEnnemi" + i, true)[0].Visible = true;
                this.Controls.Find("lblPVEnnemi" + i, true)[0].Visible = true;
                this.Controls.Find("lblMaxPvEnnemi" + i, true)[0].Visible = true;

                this.Controls.Find("lblNomEnnemi" + i, true)[0].Text = la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[(i - 1)].Nom;
                this.Controls.Find("lblPVEnnemi" + i, true)[0].Text = la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[(i - 1)].PvActuel > 0 ? la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[(i - 1)].PvActuel .ToString() : "0";
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
                this.Controls.Find("lblPVAventurier" + i, true)[0].Text = p.groupeAventurier.Membres[(i - 1)].Pvactuel > 0 ? p.groupeAventurier.Membres[(i - 1)].Pvactuel.ToString() : "0";
                this.Controls.Find("lblMaxPvAventurier" + i, true)[0].Text = "/  " + p.groupeAventurier.Membres[(i - 1)].Pvmax.ToString();
                this.Controls.Find("lblMaxPvAventurier" + i, true)[0].Left = this.Controls.Find("lblPVAventurier" + i, true)[0].Right;
                this.Controls.Find("lblRessource" + i, true)[0].Text = p.groupeAventurier.Membres[(i - 1)].Ressource == Ressource.Mana ? p.groupeAventurier.Membres[(i - 1)].Manaactuel.ToString() : p.groupeAventurier.Membres[(i - 1)].Energieactuel.ToString();

                this.Controls.Find("lblPVAventurier" + i, true)[0].ForeColor = Color.Red;
                this.Controls.Find("lblMaxPvAventurier" + i, true)[0].ForeColor = Color.Red;
                this.Controls.Find("lblRessource" + i, true)[0].ForeColor = p.groupeAventurier.Membres[(i - 1)].Ressource == Ressource.Mana ? Color.Blue : Color.Brown;


                PictureBox pBox = (PictureBox)this.Controls.Find("pboxAventurier" + i, true)[0];
                PictureBox pBoxSelected = (PictureBox)this.Controls.Find("pboxAventurierSelected" + i, true)[0];
                pBox.Visible = true;
                pBox.Image = p.groupeAventurier.Membres[(i - 1)].Imageclasse;
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

            if (p.groupeAventurier.NombreMembreVivant() == 0)
            {
                Hide();
                Gameover gameover = new Gameover();
                gameover.ShowDialog(); 
            }
            else if (la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].NombreEnnemiVivant() == 0)
            {
                string strRewards = "";
                int nbOr;
                int nbXp;
                List<Item> loot = new List<Item>();

                nbOr = la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].TotalPieces;
                nbXp = la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].TotalXp;

                la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].CalculerItems();
                loot = la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeItem;

                p.groupeAventurier.AjouterExperience(nbXp);

                strRewards += "Le groupe a récolté " + nbXp.ToString() + " points d'expériences.";

                p.groupeAventurier.NbPiecesOr += nbOr;
                strRewards += "\r\nIls ont ramassé " + nbOr.ToString() + " pièces d'ors.";

                int indLoot = 0;
                //bool noItem = true;
                foreach (Item item in loot)
                {
                    if (loot[indLoot] != null)
                    {
                        strRewards += "\r\nIls ont trouvé un(e) " + loot[indLoot].NomItem + "!";
                        //noItem = false;
                        p.groupeAventurier.Inventaire.Add(item);
                    }
                    //MessageBox.Show(loot[indLoot] != null ? loot[indLoot].NomItem : "Aucun item");
                    indLoot++;
                }

                MessageBox.Show(strRewards);

                if (etapeAventure == nbEtapesAventure)
                {
                    MessageBox.Show("Bravo vous avez completé l'aventure " + lblNomAventure.Text +"!" );
                    p.groupeAventurier.StatParDefaut();
                    Hide();
                    MenuJeu menujeu = new MenuJeu();
                    menujeu.ShowDialog();
                }
                else
                {
                    p.groupeAventurier.ModifApresCombat();
                    Hide();
                    Combat newCombat = new Combat(idAventure, etapeAventure+1);
                    newCombat.ShowDialog();
                }
                
            }
            else
            {
                NouveauTour();
            }

        }

        private void AgirMonstre()
        {
            // Vérif si ya un compétence spécial et si il peut l'utilisé
            /*
                code here ou plutot dans Agir de ennemi
            */
            AjouterTexteHistorique(la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[persoActif.idPerso].Agir());

            AfficherInfosEnnemies(la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi.Count());
            AfficherInfosAventuriers(p.groupeAventurier.Membres.Count());

            RetirerMortInitiative();

            ProchainTour();
            //MessageBox.Show("C'est le tour de " + la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[persoActif.idPerso].Nom + " et il a la stratégie " + la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[persoActif.idPerso].Strategie.ToString());
        }

        private void btnFinTour_Click(object sender, EventArgs e)
        {
            if (persoActif.typePerso == TypePersonnage.ENNEMI)
            {
                ProchainTour();
            }
            else
            {
                cibleId = (cboChoisirCible.SelectedItem as ComboboxItem).Value;
                //MessageBox.Show("Vous attaquer la cible : " + la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[(cibleId)].Nom);
                if (typeAction == "Attaque")
                {
                    LancerAttaque(p.groupeAventurier.Membres[persoActif.idPerso], la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[cibleId]);
                }
                else if(typeAction == "Ennemi simple")
                {
                    LancerCompetence(1,p.groupeAventurier.Membres[persoActif.idPerso], la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[cibleId]);
                }

                ProchainTour();
            }
        }

        private void pboxAttaquer_Click(object sender, EventArgs e)
        {
            pboxAction.Image = pboxAttaquer.Image;
            lblNomAction.Text = "Attaque";

            ComboboxItem cbCible;

            cboChoisirCible.Items.Clear();
            for (var i = 0; i < la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi.Count(); i++)
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
            AjouterTexteHistorique(aventurier.Attaquer(cible));
            //this.Controls.Find("lblPVEnnemi" + (cibleId + 1), true)[0].Text = cible.PvActuel > 0 ? cible.PvActuel.ToString() : "0";
            AfficherInfosEnnemies(la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi.Count());
            AfficherInfosAventuriers(p.groupeAventurier.Membres.Count());

            RetirerMortInitiative();
        }

        private void LancerCompetence(int idCompetence, Aventurier aventurier, Ennemi cible)
        {
            switch (idCompetence)
            {
                case 1:
                    AjouterTexteHistorique(aventurier.UtiliserCompetenceA(cible));
                    break;

                case 2:

                    break;

                case 3:

                    break;
            }

            //this.Controls.Find("lblPVEnnemi" + (cibleId + 1), true)[0].Text = cible.PvActuel > 0 ? cible.PvActuel.ToString() : "0";
            AfficherInfosEnnemies(la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi.Count());
            AfficherInfosAventuriers(p.groupeAventurier.Membres.Count());
            RetirerMortInitiative();

        }

        private void UtiliserCompetence(int idCompetence)
        {
            ComboboxItem cbCible;
            cboChoisirCible.Items.Clear();

            if (idCompetence == 1)
            {

                if (p.groupeAventurier.Membres[persoActif.idPerso].CoutCompetenceA <= (p.groupeAventurier.Membres[persoActif.idPerso].Ressource == Ressource.Mana ? p.groupeAventurier.Membres[persoActif.idPerso].Manaactuel : p.groupeAventurier.Membres[persoActif.idPerso].Energieactuel))
                {
                    PictureBox pBox = (PictureBox)this.Controls.Find("pboxSort" + idCompetence, true)[0];
                    pboxAction.Image = pBox.Image;
                    lblNomAction.Text = this.Controls.Find("lblSort" + idCompetence, true)[0].Text;


                    switch (p.groupeAventurier.Membres[persoActif.idPerso].CibleCompetenceA)
                    {
                        case Cible.Enemy:
                            {
                                for (var i = 0; i < la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi.Count(); i++)
                                {
                                    if (la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[i].Etat != Etat.Mort)
                                    {
                                        cbCible = new ComboboxItem();
                                        cbCible.Text = la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[i].Nom;
                                        cbCible.Value = i;
                                        cboChoisirCible.Items.Add(cbCible);
                                    }
                                }
                                typeAction = "Ennemi simple";
                                break;
                            }
                    }

                    btnFinTour.Enabled = true;
                    cboChoisirCible.SelectedItem = cboChoisirCible.Items[0];
                }
                else
                {
                    string strRessource = "";

                    strRessource = p.groupeAventurier.Membres[persoActif.idPerso].Ressource == Ressource.Mana ? "de mana" : "d'énergie";

                    MessageBox.Show(p.groupeAventurier.Membres[persoActif.idPerso].NomAventurier + " n'a pas assez " + strRessource + " pour effectuer cet action");
                }
                
            }
        }

        private void RetirerMortInitiative()
        {
            List<Personnage> lstTempo = new List<Personnage>();

            foreach (Personnage perso in lstPersonnages)
            {
                lstTempo.Add(perso);
            }

            foreach (Personnage perso in lstTempo)
            {
                if (perso.typePerso == TypePersonnage.AVENTURIER)
                {
                    if (p.groupeAventurier.Membres[perso.idPerso].Etat == Etat.Mort)
                    {
                        lstPersonnages.Remove(perso);
                    }
                }

                if (perso.typePerso == TypePersonnage.ENNEMI)
                {
                    if (la.ListeAventures[idAventure].ListeGroupeEnnemis[indexEtape].ListeEnnemi[perso.idPerso].Etat == Etat.Mort)
                    {
                        lstPersonnages.Remove(perso);
                    }
                }
            }
        }

        private void AjouterTexteHistorique(string strMessage)
        {
            rtbHistoriqueActions.Text = rtbHistoriqueActions.Text.Insert(0, strMessage+ "__________________________________________________\r\n\n");
        }

        private void pboxSort1_Click(object sender, EventArgs e)
        {
            UtiliserCompetence(1);
        }
    }
}
