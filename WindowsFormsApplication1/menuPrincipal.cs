using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPG.Classes;
using JRPG.Classes.Item;
using JRPG.Classes.Aventurier;

namespace JRPG
{
    using p = Program;
    using li = ListeItem;
    public partial class MenuPrincipal : Form
    {
        

        public MenuPrincipal()
        {
            InitializeComponent();

        }

        private void btnNouvellePartie_Click(object sender, EventArgs e)
        {
            Hide();
            CreationAventurier creatAventurier = new CreationAventurier();
            creatAventurier.ShowDialog();
          

        }

        private void btnChargerPartie_Click(object sender, EventArgs e)
        {
            if (File.Exists("sauvegardePartie.bin"))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("sauvegardePartie.bin",
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read);
                p.groupeAventurier = (Groupe) formatter.Deserialize(stream);
                stream.Close();

                ReloadInventaire();
                Hide();
                MenuJeu menuJeu = new MenuJeu();
                menuJeu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Aucune partie sauvegardée présente.");
            }
        }

        private void ReloadInventaire()
        {
            //Quand on load une partie on doit recréer les items avec les items de l'instance courante du jeu sinon on a un bug
            List<Item> tempoInventaire = new List<Item>(p.groupeAventurier.Inventaire);

            p.groupeAventurier.Inventaire.Clear();

            //Items de l'inventaire
            foreach (var inventaireItem in tempoInventaire)
            {
                if (inventaireItem is Arme)
                {
                    p.groupeAventurier.AjouterItem(li.ListeArmes[inventaireItem.IdItem]);
                }

                if (inventaireItem is Armure)
                {
                    p.groupeAventurier.AjouterItem(li.ListeArmures[inventaireItem.IdItem]);
                }

                if (inventaireItem is Bouclier)
                {
                    p.groupeAventurier.AjouterItem(li.ListeBoucliers[inventaireItem.IdItem]);
                }

                if (inventaireItem is Consommable)
                {
                    p.groupeAventurier.AjouterItem(li.ListeConsommables[inventaireItem.IdItem]);
                }
            }

            //Items équipés
            foreach (var aventurier in p.groupeAventurier.Membres)
            {
                if (aventurier.Arme != null)
                {
                    var idArme = aventurier.Arme.IdItem;
                    aventurier.Arme = li.ListeArmes[idArme];
                }

                if (aventurier.Bouclier != null)
                {
                    var idBouclier = aventurier.Bouclier.IdItem;
                    aventurier.Bouclier = li.ListeBoucliers[idBouclier];
                }

                if (aventurier.Armure != null)
                {
                    var idArmure = aventurier.Armure.IdItem;
                    aventurier.Armure = li.ListeArmures[idArmure];
                }
            }
        }
    }
}
