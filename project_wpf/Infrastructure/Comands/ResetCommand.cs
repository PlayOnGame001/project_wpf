using project_wpf.Infrastructure.Comands.Base;
using project_wpf.ViewModels;

namespace project_wpf.Infrastructure.Comands
{
    public class ResetCommand : Command 
    {
        public override bool CanExecute(object parametr)
        {
            return true;
        }
        public override void Execute(object parametr)
        {
            object[] parametrs = parametr as object[];
            MainWindowViewModels mwvm = parametrs[0] as MainWindowViewModels;
            MainWindow mainWindow = parametrs[1]  as MainWindow;

            ResetGame(mwvm, mainWindow);
        }
        internal void ResetGame(MainWindowViewModels mwvm, MainWindow mainWindow)
        {
            mwvm.ResetF();
            mwvm.Game.Move = "x";
            mainWindow.Control.ItemsSource = mwvm.F;
        }
    }
}
