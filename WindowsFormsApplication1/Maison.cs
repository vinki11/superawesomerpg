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

namespace JRPG
{
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
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("sauvegardePartie.bin",
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Program.groupeAventurier);
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
                Program.groupeAventurier = (Groupe)formatter.Deserialize(stream);
                stream.Close();

                MessageBox.Show("Partie chargée.");
            }
            else
            {
                MessageBox.Show("Aucune partie sauvegardée présente.");
            }
        }
    }
}
