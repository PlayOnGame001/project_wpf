﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using System.ComponentModel;

namespace project_wpf.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            var handlers = PropertyChanged;
            if (handlers is null) return;

            var invocation_list = handlers.GetInvocationList();

            var arg = new PropertyChangedEventArgs(PropertyName);
            foreach (var action in invocation_list) 
                if (action.Target is DispatcherObject disp_object)
                    disp_object.Dispatcher.Invoke(action, this, arg);
                else 
                    action.DynamicInvoke(this, arg);
        }
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
