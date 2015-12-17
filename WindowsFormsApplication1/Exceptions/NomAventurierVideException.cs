using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Exceptions
{
    class NomAventurierVideException : Exception
    {
        public override string Message
        {
            get
            {
                return "Vous devez saisir un nom de personnage!";
            }
        }
    }
}
