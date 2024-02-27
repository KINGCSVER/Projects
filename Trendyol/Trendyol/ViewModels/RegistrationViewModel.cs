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

    private string usernameTextBox;
    private string emailTextBox;
    private string passwordTextBox;
    private string confirmPasswordTextBox;
    private string secetWordTextBox;

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
        get => emailTextBox;
        set
        {
            if (emailTextBox != value)
            {
                emailTextBox = value;
                RaisePropertyChanged(nameof(TextBox2));
            }
        }
    }

    public string TextBox3
    {
        get => passwordTextBox;
        set
        {
            if (passwordTextBox != value)
            {
                passwordTextBox = value;
                RaisePropertyChanged(nameof(TextBox3));
            }
        }
    }

    public string TextBox4
    {
        get => confirmPasswordTextBox;
        set
        {
            if (confirmPasswordTextBox != value)
            {
                confirmPasswordTextBox = value;
                RaisePropertyChanged(nameof(TextBox4));
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
            TextBox1 = String.Empty;
            TextBox2 = String.Empty;
            TextBox3 = String.Empty;
            TextBox4 = String.Empty;
            navigationService.NavigateTo<LoginViewModel>();
        });
    }

    public RelayCommand CompleteRegistration
    {
        get => new(() =>
        {
            try
            {
                if (_context.User.Any(u => u.Username == TextBox1 || u.Email == TextBox2))
                {
                    MessageBox.Show("This user is already exist");
                    return;
                }
                else if (TextBox4 != TextBox3)
                {
                    MessageBox.Show("Passwords aren't same");
                    return;
                }
                else
                {
                    var newuser = _userService.RegisterUser(TextBox1, TextBox2, TextBox3);
                    _context.User.Add(newuser);
                    _context.SaveChanges();
                    MessageBox.Show("Suceestful register");
                    TextBox1 = "";
                    TextBox2 = "";
                    TextBox3 = "";
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

        var userNameCheck = _context.User.FirstOrDefault(u => u.Username == TextBox1);
        var emailCheck = _context.User.FirstOrDefault(u => u.Email == TextBox2);

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