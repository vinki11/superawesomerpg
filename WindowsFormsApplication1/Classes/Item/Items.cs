using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Classes.Item
{
    abstract class Items
    {
        protected string nomItem;
        //protected Categorie categorieItem; //C'est tu vrm valable d'avoir l'attribut et l'enum ou je suis mieu avoir simplement l'heritage
        protected int prixReVente;
    }

    /*enum Categorie
    {
        Arme,
        Armure,
        Bouclier,
        Consommable
    }*/
}
