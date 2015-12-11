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

namespace JRPG
{
    using p = Program;
    using li = ListeItem;

    public partial class Maison : Form
    {
        public Maison()
        {
            InitializeComponent();
        }

        private void btnRetourVillage_Click(object sender, EventArgs e)
        {
            Hide();
            MenuJeu createJeu = new MenuJeu();
            createJeu.ShowDialog();
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        { 
            List<Object> save = new List<object>();
            save.Add(p.groupeAventurier);
            save.Add(p.Boutique);

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("sauvegardePartie.bin",
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, save);
            stream.Close();

            MessageBox.Show("Partie sauvegarder avec succès.");
        }

        private void btnCharger_Click(object sender, EventArgs e)
        {
            if (File.Exists("sauvegardePartie.bin"))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("sauvegardePartie.bin",
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read);
                List<Object> save = (List<object>) formatter.Deserialize(stream);
                p.groupeAventurier = (Groupe)save[0];
                p.Boutique = (List<Item>) save[1];
                stream.Close();

                ReloadInventaire();

                MessageBox.Show("Partie chargée.");
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
