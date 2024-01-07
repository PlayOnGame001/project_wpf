using System.Collections.ObjectModel;
using System.Linq;
using System.Data;
using System.Windows;
using project_wpf.ViewModels.Base;
using project_wpf.Models;

namespace project_wpf.ViewModels
{
    internal class MainWindowViewModels : ViewModel
    {
        private Game game;
        public Game Game
        {
            get => game;
            set => Set(ref game, value);
        }
        public MainWindowViewModels()
        {
            game = new Game();
            Size = "15";
        }
        ObservableCollection<ObservableCollection<Field>> f = new();
        public ObservableCollection<ObservableCollection<Field>> F
        {
            get => f;
            set => Set(ref f, value);
        }
        DataTable field;
        public DataTable Field
        {
            get => field;
            set => Set(ref field, value);   
        }
    }
}
