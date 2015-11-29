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
using JRPG.Classes.Aventurier;

namespace JRPG
{
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
                Program.groupeAventurier = (Groupe) formatter.Deserialize(stream);
                stream.Close();

                Hide();
                MenuJeu menuJeu = new MenuJeu();
                menuJeu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Aucune partie sauvegardée présente.");
            }
        }
    }
}
