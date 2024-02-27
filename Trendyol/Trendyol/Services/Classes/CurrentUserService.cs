using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;

namespace Trendyol.Services.Classes;

public class CurrentUserService : INotifyPropertyChanged
{
    private string _id;
    private string _login;
    private string _email;
    private string _password;


    public event PropertyChangedEventHandler PropertyChanged;

    public string Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged(nameof(Login));
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void UpdateUserData(User user)
    {
        Id = user.Id;
        Login = user.Username;
        Email = user.Email;   
        Password = user.Password;
    }
}
