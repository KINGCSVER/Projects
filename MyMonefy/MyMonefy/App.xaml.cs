using MyMonefy.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleInjector;
using GalaSoft.MvvmLight;

namespace MyMonefy
{
    public partial class App : Application
    {
        public static SimpleInjector.Container Container { get; set; } = new();

        public void Register()
        {

            Container.RegisterSingleton<MainViewModel>();


            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            var window = new MainView();

            window.DataContext = Container.GetInstance<MainViewModel>();

            window.ShowDialog();
        }

    }
}

