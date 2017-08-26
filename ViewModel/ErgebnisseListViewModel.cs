using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    using Model;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Windows.Input;
    using ViewModel;
    using ViewModelBase;

    public class ErgebnisseListViewModel : ViewModel
    {
        public ErgebnissList el = new ErgebnissList();
        private ObservableCollection<ErgebnissViewModel> ergebnisse;

        public ObservableCollection<ErgebnissViewModel> Ergebnisse
        {
            get
            {
                return ergebnisse;
            }
            set
            {
                if (Ergebnisse != value)
                {
                    ergebnisse = value;
                    this.OnPropertyChanged("Ergebnisse");
                }
            }
        }

        private ICommand addErgebnisseCommand;
        public ICommand AddErgebnisseCommand
        {
            get
            {
                if (addErgebnisseCommand == null)
                {
                    addErgebnisseCommand = new RelayCommand(p => ExecuteAddErgebnisseCommand());
                }
                return addErgebnisseCommand;
            }
        }

        private void ExecuteAddErgebnisseCommand() => Ergebnisse.Add(new ErgebnissViewModel(new Model.Ergebniss()));

        public ErgebnisseListViewModel() {
            ergebnisse = new ObservableCollection<ErgebnissViewModel>(el.Ergebnisse.Select(p => new ErgebnissViewModel(p)));
            ergebnisse.CollectionChanged += Ergebnisse_CollectionChanged;
        }

        void Ergebnisse_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ErgebnissViewModel vm in e.NewItems)
                {
                    el.Ergebnisse.Add(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (ErgebnissViewModel vm in e.OldItems)
                {
                    el.Ergebnisse.Remove(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                el.Ergebnisse.Clear();
            }
        }
    }
}
