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

    public partial class MenuJeu : Form
    {
        int selectedAventurier = 0;

        public MenuJeu()
        {
            InitializeComponent();
            AfficherGroupeAventurier();
            AfficherDetailsAventurier(selectedAventurier);
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

        }

        public void AfficherInventaire()
        {
            //Initialisation des details du listview d'inventaire
            listInventaire.Clear();
            listInventaire.View = View.Details;
            listInventaire.Width = 229;
            listInventaire.Columns.Add("Nom de l'item", 175);
            listInventaire.Columns.Add("Nombre", 50);

            var query = p.groupeAventurier.Inventaire.Select(x => x)
                .GroupBy(x => x, (a, b) => new { Nom = a.NomItem, Nb = b.Count() })
                .OrderBy(x => x.Nom);

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

            #region Infos aventurier
            txtNom.Text = p.groupeAventurier.Membres[indexAventurier].NomAventurier;
            txtNiv.Text = p.groupeAventurier.Membres[indexAventurier].Niveau.ToString();
            txtXP.Text = p.groupeAventurier.Membres[indexAventurier].Experience.ToString();
            txtClasse.Text = p.groupeAventurier.Membres[indexAventurier].NomClasse;

            txtEtat.Text = p.groupeAventurier.Membres[indexAventurier].Etat.ToString();
            txtPV.Text = p.groupeAventurier.Membres[indexAventurier].Pvmax.ToString();
            lblEnrgMana.Text = p.groupeAventurier.Membres[indexAventurier].Ressource == Ressource.Mana ? "Mana:" : "Énergie:";
            txtRessource.Text = p.groupeAventurier.Membres[indexAventurier].Ressource == Ressource.Mana ? p.groupeAventurier.Membres[indexAventurier].Manamax.ToString() : p.groupeAventurier.Membres[indexAventurier].Energiemax.ToString();
            txtInitiative.Text = p.groupeAventurier.Membres[indexAventurier].Initiativebase.ToString();

            txtForce.Text = p.groupeAventurier.Membres[indexAventurier].Forceactuel.ToString();
            txtDefense.Text = p.groupeAventurier.Membres[indexAventurier].Defensebase.ToString();
            txtPrecision.Text = p.groupeAventurier.Membres[indexAventurier].Precisionbase.ToString();
            txtEsquive.Text = p.groupeAventurier.Membres[indexAventurier].Esquivebase.ToString();
            #endregion

            #region Statistiques équipement
            AfficherStatsEquipement(indexAventurier);
            #endregion

            #region Picturebox sélectionné
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
            #endregion

            #region Combobox Armes

            cboArme.Items.Clear();

            ComboboxItem cbItemArme;

            foreach (Item item in p.groupeAventurier.Inventaire)
            {
                if (item is Arme)
                {
                    cbItemArme = new ComboboxItem();
                    cbItemArme.Text = item.NomItem;
                    cbItemArme.Value = item.IdItem;
                    switch (p.groupeAventurier.Membres[indexAventurier].ClassId)
                    {
                        case lc.GUERRIER_ID:
                            if (item.UtilisableGuerrier)
                            {
                                if (!cboArme.Items.Contains(cbItemArme))
                                {
                                    cboArme.Items.Add(cbItemArme);
                                }
                            }
                            break;

                        case lc.MAGE_ID:
                            if (item.UtilisableMage)
                            {
                                if (!cboArme.Items.Contains(cbItemArme))
                                {
                                    cboArme.Items.Add(cbItemArme);
                                }
                            }
                            break;

                        case lc.VOLEUR_ID:
                            if (item.UtilisableVoleur)
                            {
                                if (!cboArme.Items.Contains(cbItemArme))
                                {
                                    cboArme.Items.Add(cbItemArme);
                                }
                            }
                            break;

                        case lc.PRETRE_ID:
                            if (item.UtilisablePretre)
                            {
                                if (!cboArme.Items.Contains(cbItemArme))
                                {
                                    cboArme.Items.Add(cbItemArme);
                                }
                            }
                            break;
                    }
                }
            }


            cbItemArme = new ComboboxItem();
            cbItemArme.Text = p.groupeAventurier.Membres[indexAventurier].Arme != null ? p.groupeAventurier.Membres[indexAventurier].Arme.NomItem : "";
            cbItemArme.Value = p.groupeAventurier.Membres[indexAventurier].Arme != null ? p.groupeAventurier.Membres[indexAventurier].Arme.IdItem : -1;
            if (!cboArme.Items.Contains(cbItemArme) && cbItemArme.Value != -1)
            {
                cboArme.Items.Add(cbItemArme);
            }
            cboArme.Text = "";
            cboArme.SelectedItem = cbItemArme;
            
            #endregion

            #region Combobox Armures

            cboArmure.Items.Clear();

            ComboboxItem cbItemArmure;

            foreach (Item item in p.groupeAventurier.Inventaire)
            {
                if (item is Armure)
                {
                    cbItemArmure = new ComboboxItem();
                    cbItemArmure.Text = item.NomItem;
                    cbItemArmure.Value = item.IdItem;
                    switch (p.groupeAventurier.Membres[indexAventurier].ClassId)
                    {
                        case lc.GUERRIER_ID:
                            if (item.UtilisableGuerrier)
                            {
                                if (!cboArmure.Items.Contains(cbItemArmure))
                                {
                                    cboArmure.Items.Add(cbItemArmure);
                                }
                            }
                            break;

                        case lc.MAGE_ID:
                            if (item.UtilisableMage)
                            {
                                if (!cboArmure.Items.Contains(cbItemArmure))
                                {
                                    cboArmure.Items.Add(cbItemArmure);
                                }
                            }
                            break;

                        case lc.VOLEUR_ID:
                            if (item.UtilisableVoleur)
                            {
                                if (!cboArmure.Items.Contains(cbItemArmure))
                                {
                                    cboArmure.Items.Add(cbItemArmure);
                                }
                            }
                            break;

                        case lc.PRETRE_ID:
                            if (item.UtilisablePretre)
                            {
                                if (!cboArmure.Items.Contains(cbItemArmure))
                                {
                                    cboArmure.Items.Add(cbItemArmure);
                                }
                            }
                            break;
                    }
                }
            }
            
            cbItemArmure = new ComboboxItem();
            cbItemArmure.Text = p.groupeAventurier.Membres[indexAventurier].Armure != null ? p.groupeAventurier.Membres[indexAventurier].Armure.NomItem : "";
            cbItemArmure.Value = p.groupeAventurier.Membres[indexAventurier].Armure != null ? p.groupeAventurier.Membres[indexAventurier].Armure.IdItem : -1;

            if (!cboArmure.Items.Contains(cbItemArmure) && cbItemArme.Value != -1)
            {
                cboArmure.Items.Add(cbItemArmure);
            }
            cboArmure.Text = "";
            cboArmure.SelectedItem = cbItemArmure;

            #endregion

            #region Combobox Boucliers

            cboBouclier.Items.Clear();

            ComboboxItem cbItemBouclier;

            foreach (Item item in p.groupeAventurier.Inventaire)
            {
                if (item is Bouclier)
                {
                    cbItemBouclier = new ComboboxItem();
                    cbItemBouclier.Text = item.NomItem;
                    cbItemBouclier.Value = item.IdItem;
                    switch (p.groupeAventurier.Membres[indexAventurier].ClassId)
                    {
                        case lc.GUERRIER_ID:
                            if (item.UtilisableGuerrier)
                            {
                                if (!cboBouclier.Items.Contains(cbItemBouclier))
                                {
                                    cboBouclier.Items.Add(cbItemBouclier);
                                }
                            }
                            break;

                        case lc.MAGE_ID:
                            if (item.UtilisableMage)
                            {
                                if (!cboBouclier.Items.Contains(cbItemBouclier))
                                {
                                    cboBouclier.Items.Add(cbItemBouclier);
                                }
                            }
                            break;

                        case lc.VOLEUR_ID:
                            if (item.UtilisableVoleur)
                            {
                                if (!cboBouclier.Items.Contains(cbItemBouclier))
                                {
                                    cboBouclier.Items.Add(cbItemBouclier);
                                }
                            }
                            break;

                        case lc.PRETRE_ID:
                            if (item.UtilisablePretre)
                            {
                                if (!cboBouclier.Items.Contains(cbItemBouclier))
                                {
                                    cboBouclier.Items.Add(cbItemBouclier);
                                }
                            }
                            break;
                    }
                }
            }

            cbItemBouclier = new ComboboxItem();
            cbItemBouclier.Text = p.groupeAventurier.Membres[indexAventurier].Bouclier != null ? p.groupeAventurier.Membres[indexAventurier].Bouclier.NomItem : "";
            cbItemBouclier.Value = p.groupeAventurier.Membres[indexAventurier].Bouclier != null ? p.groupeAventurier.Membres[indexAventurier].Bouclier.IdItem : -1;

            if (!cboBouclier.Items.Contains(cbItemBouclier) && cbItemBouclier.Value != -1)
            {
                cboBouclier.Items.Add(cbItemBouclier);
            }
            cboBouclier.Text = "";
            cboBouclier.SelectedItem = cbItemBouclier;

            #endregion

        }

        private void AfficherStatsEquipement(int indexAventurier)
        {
            txtForceArme.Text = p.groupeAventurier.Membres[indexAventurier].Arme != null ? p.groupeAventurier.Membres[indexAventurier].Arme.Force.ToString() : "0";
            txtDefenseArmure.Text = p.groupeAventurier.Membres[indexAventurier].Armure != null ? p.groupeAventurier.Membres[indexAventurier].Armure.Defense.ToString() : "0";
            txtPrecisionArme.Text = p.groupeAventurier.Membres[indexAventurier].Arme != null ? p.groupeAventurier.Membres[indexAventurier].Arme.Precision.ToString() : "0";
            txtEsquiveBouclier.Text = p.groupeAventurier.Membres[indexAventurier].Bouclier != null ? p.groupeAventurier.Membres[indexAventurier].Bouclier.Esquive.ToString() : "0";
        }

        private void btnAventure_Click(object sender, EventArgs e)
        {
            Hide();
            FenetreAventure choixAventure = new FenetreAventure();
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
            selectedAventurier = 0;
            AfficherDetailsAventurier(selectedAventurier);
        }

        private void pboxAventurier2_Click(object sender, EventArgs e)
        {
            selectedAventurier = 1;
            AfficherDetailsAventurier(selectedAventurier);
        }

        private void pboxAventurier3_Click(object sender, EventArgs e)
        {
            selectedAventurier = 2;
            AfficherDetailsAventurier(selectedAventurier);
        }
        
        private void cboArme_SelectedIndexChanged(object sender, EventArgs e)
        {
            Arme ancienArme = p.groupeAventurier.Membres[selectedAventurier].Arme; // On met l'ancien arme dans une variable temporaire
            var comboboxItem = cboArme.SelectedItem as ComboboxItem;
            if (comboboxItem != null)
            {
                Arme newArme = li.ListeArmes[comboboxItem.Value];
                if (ancienArme != null && ancienArme.IdItem != newArme.IdItem)
                {
                    p.groupeAventurier.Membres[selectedAventurier].Arme = newArme; //On assigne la nouvelle arme au personnage
                    p.groupeAventurier.AjouterItem(ancienArme);//On ajoute l'ancienne arme à l'inventaire
                    p.groupeAventurier.RetirerItem(newArme); //On retire la nouvelle arme de l'inventaire

                    if (newArme.DeuxMain == true)
                    {
                        if (cboBouclier.SelectedIndex != -1)
                        {
                            cboBouclier.SelectedIndex = -1;
                            Bouclier ancienBouclier = p.groupeAventurier.Membres[selectedAventurier].Bouclier;
                            p.groupeAventurier.Membres[selectedAventurier].Bouclier = null; //Unequip le bouclier
                            p.groupeAventurier.AjouterItem(ancienBouclier);//On ajoute l'ancienne armure à l'inventaire
                        }
                    }
                }
                else if (ancienArme == null)
                {
                    p.groupeAventurier.Membres[selectedAventurier].Arme = newArme; //On assigne la nouvelle Bouclier au personnage
                    p.groupeAventurier.RetirerItem(newArme); //On retire la nouvelle Bouclier de l'inventaire
          
                    if (newArme.DeuxMain == true)
                    {
                        if (cboBouclier.SelectedIndex != -1)
                        {
                            cboBouclier.SelectedIndex = -1;
                            Bouclier ancienBouclier = p.groupeAventurier.Membres[selectedAventurier].Bouclier;
                            p.groupeAventurier.Membres[selectedAventurier].Bouclier = null; //Unequip le bouclier
                            p.groupeAventurier.AjouterItem(ancienBouclier);//On ajoute l'ancienne armure à l'inventaire
                         }
                    }
                }   
            }


            AfficherInventaire();
            AfficherStatsEquipement(selectedAventurier);
        }

        private void cboArmure_SelectedIndexChanged(object sender, EventArgs e)
        {
            Armure ancienArmure = p.groupeAventurier.Membres[selectedAventurier].Armure; // On met l'ancien armure dans une variable temporaire
            var comboboxItem = cboArmure.SelectedItem as ComboboxItem;
            if (comboboxItem != null)
            {
                Armure newArmure = li.ListeArmures[comboboxItem.Value];
                if (ancienArmure != null && ancienArmure.IdItem != newArmure.IdItem)
                {
                    p.groupeAventurier.Membres[selectedAventurier].Armure = newArmure; //On assigne la nouvelle armure au personnage
                    p.groupeAventurier.AjouterItem(ancienArmure);//On ajoute l'ancienne armure à l'inventaire
                    p.groupeAventurier.RetirerItem(newArmure); //On retire la nouvelle armure de l'inventaire
                }
            }

            AfficherInventaire();
            AfficherStatsEquipement(selectedAventurier);
        }

        private void cboBouclier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bouclier ancienBouclier = p.groupeAventurier.Membres[selectedAventurier].Bouclier; // On met l'ancien Bouclier dans une variable temporaire                                                                                 //
            var comboboxItem = cboBouclier.SelectedItem as ComboboxItem;
            if (comboboxItem != null)
            {
                Bouclier newBouclier = li.ListeBoucliers[comboboxItem.Value];
                if (ancienBouclier != null && ancienBouclier.IdItem != newBouclier.IdItem)
                {
                    p.groupeAventurier.Membres[selectedAventurier].Bouclier = newBouclier; //On assigne la nouvelle Bouclier au personnage
                    p.groupeAventurier.AjouterItem(ancienBouclier);//On ajoute l'ancienne Bouclier à l'inventaire
                    p.groupeAventurier.RetirerItem(newBouclier); //On retire la nouvelle Bouclier de l'inventaire

                    Arme ancienArme = p.groupeAventurier.Membres[selectedAventurier].Arme;
                    if (ancienArme.DeuxMain == true)
                    {
                        if (cboArme.SelectedIndex != -1)
                        {
                            cboArme.SelectedIndex = -1;
                            p.groupeAventurier.Membres[selectedAventurier].Arme = null; //Unequip le bouclier
                            p.groupeAventurier.AjouterItem(ancienArme);//On ajoute l'ancienne armure à l'inventaire
                        }
                    }
                }
                else if (ancienBouclier == null)
                {
                    p.groupeAventurier.Membres[selectedAventurier].Bouclier = newBouclier; //On assigne la nouvelle Bouclier au personnage
                    p.groupeAventurier.RetirerItem(newBouclier); //On retire la nouvelle Bouclier de l'inventaire
                    
                    Arme ancienArme = p.groupeAventurier.Membres[selectedAventurier].Arme;
                    if (ancienArme.DeuxMain == true)
                    {
                        if (cboArme.SelectedIndex != -1)
                        {
                            cboArme.SelectedIndex = -1;
                            p.groupeAventurier.Membres[selectedAventurier].Arme = null; //Unequip le bouclier
                            p.groupeAventurier.AjouterItem(ancienArme);//On ajoute l'ancienne armure à l'inventaire
                        }
                    }

                }
            }

            AfficherInventaire();
            AfficherStatsEquipement(selectedAventurier);
        }

        private void btnMaison_Click(object sender, EventArgs e)
        {
            Hide();
            Maison maison = new Maison();
            maison.ShowDialog();
        }
    }

    public class ComboboxItem :IEquatable<ComboboxItem>
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public bool Equals(ComboboxItem other)
        {
            return (this.ToString() == other.ToString());
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return base.Equals(obj);

            if (obj is ComboboxItem)
                return this.Equals((ComboboxItem)obj);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
