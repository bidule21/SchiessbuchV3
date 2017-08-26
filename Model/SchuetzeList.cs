using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SchuetzeList
    {
        public IList<Schuetze> Schuetzen { get; private set; }

        public SchuetzeList()
        {
            Schuetzen = new List<Schuetze>();
            List<Schuetze> s = new List<Schuetze>();
            FileOperations.Open<Schuetze>(ref s, "Schuetze");
            Schuetzen = s;
        }

        
    }
}
