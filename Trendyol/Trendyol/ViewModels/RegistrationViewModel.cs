using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Context;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;

namespace Trendyol.ViewModels;

public class RegistrationViewModel : ViewModelBase
{
    private readonly INavigationService navigationService;
    private readonly TrendyolDbContext _context;
    private readonly IDataService _dataService;
    private readonly UserService _userService;

    private string _username;
    private string _email;
    private string _password;
    private string _confirmPassword;

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

    public string Email
    {
        get => _email;
        set
        {
            if (_email != value)
            {
                _email = value;
                RaisePropertyChanged(nameof(Email));
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

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            if (_confirmPassword != value)
            {
                _confirmPassword = value;
                RaisePropertyChanged(nameof(ConfirmPassword));
            }
        }
    }

    public RegistrationViewModel(INavigationService navigation, TrendyolDbContext context, IDataService dataService)
    {
        navigationService = navigation;
        _context = context;
        _dataService = dataService;
        _userService = new UserService(_context);
    }

    public RelayCommand BackToLogin
    {
        get => new(() =>
        {
            Username = String.Empty;
            Email = String.Empty;
            Password = String.Empty;
            ConfirmPassword = String.Empty;
            navigationService.NavigateTo<LoginViewModel>();
        });
    }

    public RelayCommand CompleteRegistration
    {
        get => new(() =>
        {
            try
            {
                if (_context.User.Any(u => u.Username == Username || u.Email == Email))
                {
                    MessageBox.Show("This user is already exist");
                    return;
                }
                else if (ConfirmPassword != Password)
                {
                    MessageBox.Show("Passwords aren't same");
                    return;
                }
                else
                {
                    var newuser = _userService.RegisterUser(Username, Email, Password);
                    _context.User.Add(newuser);
                    _context.SaveChanges();
                    MessageBox.Show("Suceestful register");
                    Username = "";
                    Email = "";
                    Password = "";
                    navigationService.NavigateTo<LoginViewModel>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        });
    }

    public bool ValidateUserData(string t1, string t2, string t3, string t4, string t5)
    {
        string usernameRegex = @"^(?=[a-zA-Z0-9_]{3,16}$)(?![_0-9])[a-zA-Z0-9_]+$";
        string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+\\|[\]{};:'"",.<>/?]).{8,20}$";
        string emailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        var userNameCheck = _context.User.FirstOrDefault(u => u.Username == Username);
        var emailCheck = _context.User.FirstOrDefault(u => u.Email == Email);

        if (userNameCheck != null && emailCheck != null)
        {
            if (t1 == userNameCheck.Username)
            {
                MessageBox.Show("A user with the same Username already exists.");
                return false;
            }
            if (t2 == emailCheck.Email)
            {
                MessageBox.Show("A user with the same Email already exists.");
            }
        }

        return true;
    }
}