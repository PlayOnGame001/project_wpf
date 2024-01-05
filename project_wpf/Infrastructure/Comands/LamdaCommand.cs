﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_wpf.Infrastructure.Comands.Base;

namespace project_wpf.Infrastructure.Comands
{
    internal class LamdaCommand : Commands
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public  LamdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }
    }
}
