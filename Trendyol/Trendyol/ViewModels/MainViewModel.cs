using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Messages;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _currentView;
    private readonly IMessenger _messenger;
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;
    public string _visibility;

    public string Visibility
    {
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


    public MainViewModel(IMessenger messenger, INavigationService navigationService)
    {
        _messenger = messenger;
        _navigationService = navigationService;
        CurrentView = App.Container.GetInstance<LoginViewModel>();


        _messenger.Register<NavigationMessage>(this, message =>
        {
            CurrentView = message.ViewModelType;
            if (CurrentView != App.Container.GetInstance<MainViewModel>())
            {
                Visibility = "Hidden";
            }
            else
            {
                Visibility = "Visible";
            }
        });
    }

    public RelayCommand GoToAccountInfo
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<AccountInfoViewModel>();
        });
    }

    public RelayCommand Store
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<StoreViewModel>();
        });
    }

    public RelayCommand Quit
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<LoginViewModel>();
        });
    }
}
