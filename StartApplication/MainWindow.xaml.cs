using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StartApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel.SchuetzenListViewModel viewModel1 = new ViewModel.SchuetzenListViewModel();
        ViewModel.ErgebnisseListViewModel viewModel2 = new ViewModel.ErgebnisseListViewModel();
        public MainWindow()
        {
            InitializeComponent();
            SetupBindings();
        }

        private void SetupBindings() {
            
            schuetzenListView.DataContext = viewModel1;
            ergebnisseListView.DataContext = viewModel2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            List<Model.Schuetze> s = new List<Model.Schuetze>();
            List<Model.Ergebniss> t = new List<Model.Ergebniss>();
            foreach(Model.Schuetze a in viewModel1.sl.Schuetzen)
                s.Add(a);
            foreach (Model.Ergebniss b in viewModel2.el.Ergebnisse)
                t.Add(b);
            Model.FileOperations.Save<Model.Schuetze>(ref s, "Schuetze");
            Model.FileOperations.Save<Model.Ergebniss>(ref t, "Ergebniss");
        }
    }
}
