using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MyMonefy.ViewModels;

class MainViewModel : ViewModelBase
{
    public  ViewModelBase CurrentView { get; set; }

    public MainViewModel()
    {
        CurrentView = App.Container.GetInstance<CalculatorViewModel>();
    }
}
