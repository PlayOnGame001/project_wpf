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
    class BackCommand :  Command
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
            if (field == null || field.State != "")
            {
                return;
            }
            field.State = mwvm.Game.Move;
            foreach (var collection in mwvm.F)
            {
                foreach (var item in collection)
                {
                    if (item.I == field.I && item.J == field.J)
                    {
                        item.State = field.State;
                    }
                }
            }
            mwvm.Game.Move = mwvm.Game.Move == "X" ? "0" : "X";
            CheckWin(field.State, mwvm, mainWindow);
        }
        private void CheckWin(string state, MainWindowViewModels mwwm, MainWindow mainWindow)
        {
            if (CheckForWinner(mwwm.F))
            {
                MessageBox.Show($"{state} Win! Champion!");

                var resetCommand = new ResetCommand();
                resetCommand.ResetGame(mwwm, mainWindow);
            }
        }
        static bool CheckForWinner(ObservableCollection<ObservableCollection<Field>> f)
        {
            for (int i=0; i < f.Count; i++) //проверка по горизонтали 
            {   
                for (int j=0; j <= f.Count - WIN_LENGTH; j++)
                {
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        var actual = f.FirstOrDefault(x => x.Any(y => y.I == i))?.FirstOrDefault(x => x.J == j);

                        var next = f.FirstOrDefault(x => x.Any(y => y.I == i))?.FirstOrDefault(x => x.J == j + k);

                        if (next.State != actual.State || actual.State == "")
                        {
                            isWin = false;  
                            break;
                        }
                    }
                    if (isWin) return true;
                }
            }
            for (int i = 0; i <= f.Count - WIN_LENGTH; i++) // по вертикали 
            {
                for (int j = 0; j < f.Count; j++)
                {
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        var actual = f.FirstOrDefault(x => x.Any(y => y.I == i))?.FirstOrDefault(x => x.J == j);

                        var next = f.FirstOrDefault(x => x.Any(y => y.I == i + k))?.FirstOrDefault(x => x.J == j );

                        if (next.State != actual.State || actual.State == "")
                        {
                            isWin = false;
                            break;
                        }
                    }
                    if (isWin) return true;
                }
            }
            for (int i = 0; i <= f.Count - WIN_LENGTH; i++)//диагональ с лева на право
            {
                for (int j = 0; j <= f.Count - WIN_LENGTH; j++)
                {
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        var actual = f.FirstOrDefault(x => x.Any(y => y.I == i))?.FirstOrDefault(x => x.J == j);

                        var next = f.FirstOrDefault(x => x.Any(y => y.I == i + k))?.FirstOrDefault(x => x.J == j + k);

                        if (next.State != actual.State || actual.State == "")
                        {
                            isWin = false;
                            break;
                        }
                    }
                    if (isWin) return true;
                }
            }
            for (int i = 0; i <= f.Count - WIN_LENGTH; i++)//диагонали право на лево
            {
                for (int j = WIN_LENGTH - 1; j < f.Count; j++)
                {
                    bool isWin = true;
                    for (int k = 0; k < WIN_LENGTH; k++)
                    {
                        var actual = f.FirstOrDefault(x => x.Any(y => y.I == i))?.FirstOrDefault(x => x.J == j);
                        var next = f.FirstOrDefault(x => x.Any(y => y.I == i))?.FirstOrDefault(x => x.J == j + k);

                        if (next.State != actual.State || actual.State == "")
                        {
                            isWin = false;
                            break;
                        }
                    }
                    if (isWin) return true;
                }
            }
            return false;
        }
    }
}
