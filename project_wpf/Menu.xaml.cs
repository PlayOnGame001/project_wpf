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

namespace project_wpf
{
    public partial class Menu : Window
    {
        public static MainWindow Window;
        public static Menu MenuWindow;
        public Menu()
        {
            InitializeComponent();
        }

        private void But1_Click(object sender, RoutedEventArgs e)
        {
           /* MainWindow window = new MainWindow();
            window.Show();*/ 
            /* Но так не правильно (но можно) это по сути бесконечное открытие окна*/
            if (Window == null)
            {
                Window = new MainWindow();
                Window.Show();
            }
            else
            {
                Window.Activate();
            }
        }

        private void But2_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"Dictionary/Eng.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void But3_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"Dictionary/Rus.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
