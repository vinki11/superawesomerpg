using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Classes;

namespace JRPG.Classes.Aventure
{
    class Aventure
    {
        #region Attributs

        public int IdAventure { get; set; }
        public string NomAventure { get; set; }
        public string DescriptionAventure { get; set; }
        public List<GroupeEnnemi> ListeGroupeEnnemis { get; set; }
        public int NiveauAventure { get; set; }
        public int NiveauRequis { get; set; }

        #endregion

        #region Constructeur

        public Aventure(int pAventureId, string pNomAventure, string pDescriptionAventure, int pNiveauAventure, int pNiveauRequis)
        {
            IdAventure = pAventureId;
            NomAventure = pNomAventure;
            DescriptionAventure = pDescriptionAventure;
            ListeGroupeEnnemis = new List<GroupeEnnemi>();
            NiveauAventure = pNiveauAventure;
            NiveauRequis = pNiveauRequis;

        }

        #endregion

        #region Fonctions

        public void AjouterGroupeEnnemis(GroupeEnnemi groupe)
        {
            this.ListeGroupeEnnemis.Add(groupe);
        }
        #endregion

    }
}
