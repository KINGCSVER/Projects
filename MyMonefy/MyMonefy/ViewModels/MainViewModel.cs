using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MyMonefy.Messages;
using MyMonefy.Models;
using MyMonefy.Services.Classes;
using MyMonefy.Services.Interfaces;
using MyMonefy.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyMonefy.ViewModels;

public class MainViewModel : ViewModelBase
{

    public IMessenger _messenger;
    public INavigationService _navigationService;
    private ViewModelBase _currentView;
    public string _visibility;
    public event PropertyChangedEventHandler PropertyChanged;
  


    public string Visibility {
        get => _visibility;
        set
        {
            Set(ref _visibility, value);
        }
    }
    public ViewModelBase CurrentView
    {
        get => _currentView;
        set
        {
            Set(ref _currentView, value);
        }
    }

    public MainViewModel(IMessenger messenger)
    {
        _messenger = messenger;
        CurrentView = App.Container.GetInstance<DataViewModel>();

        _messenger.Register<NavigationMessage>(this, message =>
        {
            CurrentView = message.ViewModelType;

            if (CurrentView == App.Container.GetInstance<CalculatorViewModel>())
            {
                Visibility = "Hidden";
            }
            else
            {
                Visibility = "Visible";
            }
        });
    }


}
