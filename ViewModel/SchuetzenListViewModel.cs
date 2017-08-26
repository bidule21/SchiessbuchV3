using System.Linq;

namespace ViewModel
{
    using Model;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Windows.Input;
    using ViewModel;
    using ViewModelBase;

    public class SchuetzenListViewModel : ViewModel
    {
        public SchuetzeList sl = new SchuetzeList();
        private ObservableCollection<SchuetzeViewModel> schuetzen;
        private ICommand addSchuetzenCommand;
        private ICommand saveSchuetzenCommand;

        public SchuetzenListViewModel()
        {
            schuetzen = new ObservableCollection<SchuetzeViewModel>(sl.Schuetzen.Select(p => new SchuetzeViewModel(p)));
            schuetzen.CollectionChanged += Schuetzen_CollectionChanged;
        }

        public ICommand AddSchuetzenCommand
        {
            get
            {
                if (addSchuetzenCommand == null)
                {
                    addSchuetzenCommand = new RelayCommand(p => ExecuteAddSchuetzenCommand());
                }
                return addSchuetzenCommand;
            }
        }
        public ICommand SaveSchuetzenCommand
        {
            get
            {
                if (saveSchuetzenCommand == null)
                {
                    saveSchuetzenCommand = new RelayCommand(p => ExecuteSaveSchuetzenCommand());
                }
                return saveSchuetzenCommand;
            }
        }

        public ObservableCollection<SchuetzeViewModel> Schuetzen
        {
            get
            {
                return schuetzen;
            }
            set
            {
                if (Schuetzen != value)
                {
                    schuetzen = value;
                    this.OnPropertyChanged("Schuetzen");
                }
            }
        }

        private void ExecuteAddSchuetzenCommand() => Schuetzen.Add(new SchuetzeViewModel(new Model.Schuetze()));
        private void ExecuteSaveSchuetzenCommand()
        {
            List<Schuetze> s = new List<Schuetze>();
            foreach(Schuetze e in sl.Schuetzen)
            {
                s.Add(e);
            }
            FileOperations.Save<Model.Schuetze>(ref s, "Schuetze");
        }

        void Schuetzen_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (SchuetzeViewModel vm in e.NewItems)
                {
                    sl.Schuetzen.Add(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (SchuetzeViewModel vm in e.OldItems)
                {
                    sl.Schuetzen.Remove(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                sl.Schuetzen.Clear();
            }
        }
    }
}
