using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Messages;
using Trendyol.Models;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels;

public class AccountInfoViewModel : ViewModelBase
{
    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;
    private readonly CurrentUserService _currentUserService;
    private readonly User user = new();

    private string _username;
    private string _email;
    private string _password;

    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    public User _currentUser = new();
    public User CurentUser
    {
        get => _currentUser;
        set
        {
            Set(ref _currentUser, value);
        }
    }

    public AccountInfoViewModel(IMessenger messenger, IDataService dataService, INavigationService navigation, CurrentUserService currentUserService)
    {
        navigationService = navigation;
        _dataService = dataService;
        _messenger = messenger;
        _currentUserService = currentUserService;
        _currentUserService.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(CurrentUserService.Email))
            {
                Email = _currentUserService.Email;
            }
            else if (args.PropertyName == nameof(CurrentUserService.Login))
            {
                Username = _currentUserService.Login;
            }
            else if (args.PropertyName == nameof(CurrentUserService.Password))
            {
                Password = _currentUserService.Password;
            }
        };

        _currentUserService.UpdateUserData(user);

        _messenger.Register<DataMessage>(this, message =>
        {
            if (message.Data as User != null)
            {
                CurentUser = message.Data as User;

            }
        });
    }

    public RelayCommand Back
    {
        get => new(
            () =>
            {
                navigationService.NavigateTo<MainViewModel>();
            });
    }
}