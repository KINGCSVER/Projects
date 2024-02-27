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

public class ForgotPasswordViewModel : ViewModelBase
{
    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;
    private readonly ForgotPasswordService _forgotPasswordService;

    TrendyolDbContext _trendyoulDb = new TrendyolDbContext();

    private string usernameTextBox;
    private string newPasswordTextBox;
    private string confirmNewPasswordTextBox;

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
        get => newPasswordTextBox;
        set
        {
            if (newPasswordTextBox != value)
            {
                newPasswordTextBox = value;
                RaisePropertyChanged(nameof(TextBox2));
            }
        }
    }
    public string TextBox3
    {
        get => confirmNewPasswordTextBox;
        set
        {
            if (confirmNewPasswordTextBox != value)
            {
                confirmNewPasswordTextBox = value;
                RaisePropertyChanged(nameof(TextBox3));
            }
        }
    }

    public ForgotPasswordViewModel(IMessenger messenger, IDataService dataService, INavigationService navigation)
    {
        navigationService = navigation;
        _dataService = dataService;
        _messenger = messenger;
        _forgotPasswordService = new ForgotPasswordService(_trendyoulDb);
    }
    public RelayCommand BackToLogin
    {
        get => new(() =>
        {
            navigationService.NavigateTo<LoginViewModel>();
        });
    }

    string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+\\|[\]{};:'"",.<>/?]).{8,20}$";


    public RelayCommand ResetPassword
    {
        get => new(() =>
        {
            try
            {
                if (!_trendyoulDb.User.Any(u => u.Username == TextBox1 && u.Email == TextBox2))
                {
                    MessageBox.Show("User not found");
                    return;
                }
                else if (TextBox3 != TextBox2)
                {
                    MessageBox.Show("Password mismatch!");
                    TextBox2 = "";
                    TextBox3 = "";
                    return;
                }
                else
                {
                    _forgotPasswordService.ForgotPassword(TextBox1, TextBox2, TextBox3);
                    _trendyoulDb.SaveChanges();
                    MessageBox.Show("Password upgrated succestful");
                    TextBox1 = "";
                    TextBox2 = "";
                    TextBox3 = "";
                    navigationService.NavigateTo<LoginViewModel>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });
    }
}