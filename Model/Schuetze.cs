using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Schuetze : IEquatable<Schuetze>
    {
        public Schuetze()
        {
        }

        public string VName { get; set; }
        public string NName { get; set; }
        public string SchiessNr { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Schuetze);
        }

        public bool Equals(Schuetze other)
        {
            return other != null &&
                   VName == other.VName &&
                   NName == other.NName &&
                   SchiessNr == other.SchiessNr &&
                   Email == other.Email;
        }

        public override int GetHashCode()
        {
            var hashCode = 1235980748;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SchiessNr);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            return hashCode;
        }
    }
}
