﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes;
using JRPG.Classes.Aventurier;

namespace JRPG
{
    using p = Program;
    using li = ListeItem;
    using lc = ListeClasse;

    public partial class CreationAventurier : Form
    {
        bool nomValide = false;

        public CreationAventurier()
        {
            InitializeComponent();
            rboGuerrier.Checked = true;

            //Les images pour les classes
            pboxGuerrier.Image = Properties.Resources.guerrier;
            pboxMage.Image = Properties.Resources.mage;
            pboxPretre.Image = Properties.Resources.pretre;
            pboxVoleur.Image = Properties.Resources.voleur;

            rboGuerrier.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);
            rboMage.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);
            rboVoleur.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);
            rboPretre.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);

            //Par défaut on est sur le guerrier
            AfficherInfosClasse(lc.GUERRIER_ID);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        protected void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            int selectedClass = 0;
            if (sender is RadioButton)
            {
                if (rboGuerrier.Checked)
                {
                    selectedClass = lc.GUERRIER_ID;
                }
                else if (rboMage.Checked)
                {
                    selectedClass = lc.MAGE_ID;
                }
                else if (rboVoleur.Checked)
                {
                    selectedClass = lc.VOLEUR_ID;
                }
                else if (rboPretre.Checked)
                {
                    selectedClass = lc.PRETRE_ID;
                }

                AfficherInfosClasse(selectedClass);
            }
        }

        private void AfficherInfosClasse(int classId)
        {
            //On instancie un objet pour aller y chercher ses attributs par défaut
            Aventurier aventurierTempo = new Guerrier("", 0, 0);
            switch (classId)
            {
                case lc.GUERRIER_ID:
                    aventurierTempo = new Guerrier("",0,0);
                    break;

                case lc.MAGE_ID:
                    aventurierTempo = new Mage("", 0, 0);
                    break;

                case lc.VOLEUR_ID:
                    aventurierTempo = new Voleur("", 0, 0);
                    break;

                case lc.PRETRE_ID:
                    aventurierTempo = new Pretre("", 0, 0);
                    break;
            }

            txtClasse.Text = aventurierTempo.NomClasse;
            txtPV.Text = aventurierTempo.Pvmax.ToString();
            txtRessource.Text = aventurierTempo.Ressource == Ressource.Mana ? aventurierTempo.Manamax.ToString() : aventurierTempo.Energiemax.ToString();
            txtInitiative.Text = aventurierTempo.Initiativebase.ToString();

            txtForce.Text = aventurierTempo.Forcebase.ToString();
            txtDefense.Text = aventurierTempo.Defensebase.ToString();
            txtPrecision.Text = aventurierTempo.Precisionbase.ToString();
            txtEsquive.Text = aventurierTempo.Esquivebase.ToString();

            txtArme.Text = aventurierTempo.Arme != null ? aventurierTempo.Arme.NomItem : "";
            txtArmure.Text = aventurierTempo.Armure != null ? aventurierTempo.Armure.NomItem : "";
            txtBouclier.Text = aventurierTempo.Bouclier != null ? aventurierTempo.Bouclier.NomItem : "";

        }

        //Fonction qui valide si le nom du personnage est valide
        private void ValiderNom(string nom)
        {
            if (string.IsNullOrEmpty(nom))
            {
                MessageBox.Show("Vous devez saisir un nom de personnage!", "Nom du personnage invalide");
            }
            else if (!nom.All(char.IsLetter))
            {
                MessageBox.Show("Votre nom de personnage doit contenir seulement des lettres!", "Nom du personnage invalide");
            }
            else
            {
                nomValide = true;
            }
        }

        private void btnAccepter_Click(object sender, EventArgs e)
        {
            ValiderNom(txtNomPerso.Text);


            if (nomValide)
            {
                Aventurier premierAventurier;
                premierAventurier = new Guerrier(txtNomPerso.Text, 0, 1); // Par défaut un guerrier

                if (rboGuerrier.Checked)
                {
                    premierAventurier = new Guerrier(txtNomPerso.Text, 0, 1);
                }
                else if (rboMage.Checked)
                {
                    premierAventurier = new Mage(txtNomPerso.Text, 0, 1);
                }
                else if (rboVoleur.Checked)
                {
                    premierAventurier = new Voleur(txtNomPerso.Text, 0, 1);
                }
                else if (rboPretre.Checked)
                {
                    premierAventurier = new Pretre(txtNomPerso.Text, 0, 1);
                }
                    
               
                p.groupeAventurier.AjouterAventurier(premierAventurier);

                Hide();
                MenuJeu menuJeu = new MenuJeu();
                menuJeu.ShowDialog();
            }
            else
            {
                txtNomPerso.Focus();
            }
            

        }
    }
}
