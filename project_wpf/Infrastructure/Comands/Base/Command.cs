﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace project_wpf.Infrastructure.Comands.Base
{
    public abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value; 
        }
        public abstract bool CanExecute(object parametr);
        public abstract void Execute(object parametr);
    }
}
