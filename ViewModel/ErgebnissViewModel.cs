using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    using ViewModelBase;
    using Model;

    public class ErgebnissViewModel : ViewModel<Ergebniss>
    {
        public ErgebnissViewModel(Ergebniss model)
            : base(model)
        {
        }

        public string Datum {
            get { return Model.Datum; }
            set{
                if(Datum != value) {
                    Model.Datum = value;
                    this.OnPropertyChanged("Datum");
                }
            }
        }
        public string Ringe
        {
            get { return Model.Ringe; }
            set
            {
                if (Ringe != value)
                {
                    Model.Ringe = value;
                    this.OnPropertyChanged("Ringe");
                }
            }
        }
        public string Diziplin
        {
            get { return Model.Diziplin; }
            set
            {
                if (Diziplin != value)
                {
                    Model.Diziplin = value;
                    this.OnPropertyChanged("Diziplin");
                }
            }
        }
        public string Schuetze
        {
            get { return Model.Schuetzen; }
            set
            {
                if (Schuetze != value)
                {
                    Model.Schuetzen = value;
                    this.OnPropertyChanged("Schuetze");
                }
            }
        }
    }
}
