using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using XAMLBasicAppDemo.ViewModels;
using XAMLBasicAppDemo.Views;

namespace XAMLBasicAppDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var studentDetails = new StudentDetails();
            var studentsViewModel = new StudentDetailsViewModel();
            studentDetails.DataContext = studentsViewModel;
            studentDetails.Show();
        }
    }
}
