﻿using GalaSoft.MvvmLight.Command;
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


    private string usernameTextBox;
    private string passwordTextBox;

    public string TextBox1
    {
        get => usernameTextBox;
        set
        {
            if (usernameTextBox != value)
            {
                usernameTextBox = value;
                RaisePropertyChanged(nameof(TextBox1));
            }
        }
    }
    public string TextBox2
    {
        get => passwordTextBox;
        set
        {
            if (passwordTextBox != value)
            {
                passwordTextBox = value;
                RaisePropertyChanged(nameof(TextBox2));
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
                if (_superAdminService.SuperAdminLogin(TextBox1, TextBox2))
                {
                    navigationService.NavigateTo<SuperAdminViewModel>();
                }
                else if (_adminService.AdminLogin(TextBox1, TextBox2))
                {
                    navigationService.NavigateTo<AdminViewModel>();
                }
                else if (_userService.UserLogin(TextBox1, TextBox2))
                {
                    var user = _userService.LoginGet(TextBox1);
                    _currentUserService.UpdateUserData(user);
                    TextBox1 = "";
                    TextBox2 = "";
                    navigationService.NavigateTo<MainViewModel>();
                }
                else
                {
                    MessageBox.Show("Wrong password");
                    TextBox2 = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            TextBox1 = "";
            TextBox2 = "";

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
