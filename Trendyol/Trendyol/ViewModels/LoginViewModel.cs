using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Context;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;
using System.Windows;

namespace Trendyol.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;
    private readonly TrendyolDbContext _trendyoulDB;
    private readonly SuperAdminService _superAdminService;
    private readonly AdminService _adminService;
    private readonly UserService _userService;
    private readonly CurrentUserService _currentUserService;


    private string _username;
    private string _password;

    public string Username
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }
    }
    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }
    }
    public LoginViewModel(IMessenger messenger, IDataService dataService, INavigationService navigation, TrendyolDbContext trendyoulDB, CurrentUserService currentUserService)
    {
        navigationService = navigation;
        _dataService = dataService;
        _messenger = messenger;
        _trendyoulDB = trendyoulDB;
        _superAdminService = new SuperAdminService(_trendyoulDB);
        _userService = new UserService(_trendyoulDB);
        _adminService = new AdminService(_trendyoulDB);
        _currentUserService = currentUserService;
    }
    public RelayCommand DoRegistration
    {
        get => new(() =>
        {
            navigationService.NavigateTo<RegistrationViewModel>();
        });
    }

    public RelayCommand CompleteLogin
    {
        get => new(() =>
        {

            try
            {
                if (_superAdminService.SuperAdminLogin(Username, Password))
                {
                    navigationService.NavigateTo<SuperAdminViewModel>();
                }
                else if (_adminService.AdminLogin(Username, Password))
                {
                    navigationService.NavigateTo<AdminViewModel>();
                }
                else if (_userService.UserLogin(Username, Password))
                {
                    var user = _userService.LoginGet(Username);
                    _currentUserService.UpdateUserData(user);
                    Username = "";
                    Password = "";
                    navigationService.NavigateTo<MainViewModel>();
                }
                else
                {
                    MessageBox.Show("Wrong password");
                    Password = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            Username = "";
            Password = "";

        });
    }

    public RelayCommand ForgotPassword
    {
        get => new(() =>
        {
            navigationService.NavigateTo<ForgotPasswordViewModel>();
        });
    }
}
