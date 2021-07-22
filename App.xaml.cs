using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BeFit
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>

    public partial class App : Application
    {
        
        public static void BeFitWindow(Model.Model model)
        {
            var loginregisterwindow = Current.MainWindow;
            var befitwindow = new View.BeFitWindow(model);
            befitwindow.Show();
            Current.MainWindow = befitwindow;
            loginregisterwindow.Close();

        }

        public static void LogOut()
        {
            var oldwindow = Current.MainWindow;
            var loginwindow = new View.MainLoginRegisterWindow(); ;
            loginwindow.Show();
            Current.MainWindow = loginwindow;
            oldwindow.Close();

        }

    }
}
