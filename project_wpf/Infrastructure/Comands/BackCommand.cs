using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using project_wpf.Infrastructure.Comands.Base;
using project_wpf.Models;
using project_wpf.ViewModels;

namespace project_wpf.Infrastructure.Comands
{
    internal class BackCommand :  Command
    {
        private const int WIN_LENGTH = 5;
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parametr)
        {
            object[] parametrs = parametr as object[];
            Field field = parametrs[0] as Field;
            MainWindowViewModels mwvm = parametrs[1] as MainWindowViewModels;
            MainWindow mainWindow = parametrs[2] as MainWindow;
            if (field == null || field .State != "")
            {
                return;
            }
        }
    }
}
