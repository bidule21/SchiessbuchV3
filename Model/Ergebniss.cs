using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Ergebniss : IEquatable<Ergebniss>
    {
        public Ergebniss()
        {
        }

        public string Datum { get; set; }
        public string Ringe { get; set; }
        public string Diziplin { get; set; }
        public string Schuetzen { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Ergebniss);
        }

        public bool Equals(Ergebniss other)
        {
            return other != null &&
                   Datum == other.Datum &&
                   Ringe == other.Ringe &&
                   Diziplin == other.Diziplin &&
                   Schuetzen == other.Schuetzen;
        }

        public override int GetHashCode()
        {
            var hashCode = -526768314;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Datum);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ringe);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Diziplin);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Schuetzen);
            return hashCode;
        }
    }
}
