using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_wpf.ViewModels.Base;

namespace project_wpf.Models
{
    internal class Field : ViewModel
    {
        private string state = "";
        public string State
        {
            get => state;
            set => Set(ref state, value);
        }
        public int I { get; set; }
        public int J { get; set; }

    }
}
