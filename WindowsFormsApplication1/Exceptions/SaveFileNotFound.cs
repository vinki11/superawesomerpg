using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Exceptions
{
    class SaveFileNotFound :  Exception
    {
        public override string Message
        {
            get
            {
                return "Aucune partie sauvegardée présente.";
            }
        }
    }
}
