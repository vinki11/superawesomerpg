using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JRPG.Classes.Ennemi;
using System.Threading.Tasks;

namespace JRPG.Interfaces
{
    interface IAttaquerEnnemi
    {
        string Attaquer(Ennemi cible);
    }
}
