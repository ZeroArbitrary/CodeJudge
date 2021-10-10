using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using JudgeCore;
namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Context Context { get; set;}
        protected override void OnStartup(StartupEventArgs e)
        {
            Context = JudgeCore.StartUp.StartUpProgram(new Utilities.UserInfo()
            {   Name = "DefaultUserName",
                UniversityID = 1111111111
            }) ;
            new MainWindow();
        }
    }
}
