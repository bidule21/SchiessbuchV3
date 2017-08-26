using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    using ViewModelBase;
    using Model;

    public class SchuetzeViewModel : ViewModel<Schuetze>
    {
        public SchuetzeViewModel(Schuetze model)
            : base(model)
        {
        }

        public string VName
        {
            get { return Model.VName; }
            set
            {
                if (VName != value)
                {
                    Model.VName = value;
                    this.OnPropertyChanged("VName");
                }
            }
        }
        public string NName
        {
            get { return Model.NName; }
            set
            {
                if (NName != value)
                {
                    Model.NName = value;
                    this.OnPropertyChanged("NName");
                }
            }
        }
        public string Email
        {
            get { return Model.Email; }
            set
            {
                if (Email != value)
                {
                    Model.Email = value;
                    this.OnPropertyChanged("Email");
                }
            }
        }
        public string SchiessNr
        {
            get { return Model.SchiessNr; }
            set
            {
                if (SchiessNr != value)
                {
                    Model.SchiessNr = value;
                    this.OnPropertyChanged("SchiessNr");
                }
            }
        }
    }
}

