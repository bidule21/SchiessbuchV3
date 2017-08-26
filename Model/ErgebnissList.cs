using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ErgebnissList
    {
        public IList<Ergebniss> Ergebnisse { get; private set; }

        public ErgebnissList()
        {
            Ergebnisse = new List<Ergebniss>();
            List<Ergebniss> s = new List<Ergebniss>();
            FileOperations.Open<Ergebniss>(ref s, "Ergebniss");
            Ergebnisse = s;
        }
    }
}
