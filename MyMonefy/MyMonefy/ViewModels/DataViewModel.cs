using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MyMonefy.Models;
using MyMonefy.Services.Classes;
using MyMonefy.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyMonefy.ViewModels;

public class DataViewModel : ViewModelBase
{
    public ICommand Category_Click { get; private set; }
    public DateTime _currentDate = DateTime.Today;
    public string SelectedCategory;
    public ObservableCollection<Date> dates = new ObservableCollection<Date>();
    public Date balance;
    private readonly INavigationService _navigationService;
    public RelayCommand SaveDate_Click;

    public DataViewModel(INavigationService navigationService)
    {
        Category_Click= new RelayCommand<string>(ButtonClick);

        /*SaveDate_Click = new RelayCommand(ExecuteSaveDateCommand);*/

        _navigationService = navigationService;
    }
    public void ButtonClick(string categoryName)
    {
            SelectedCategory = categoryName;

            _navigationService.NavigateTo<CalculatorViewModel>();
    }

/*    public RelayCommand ShowBalance
    {
        get => new(() =>
        {
            TextBlock.


        }
        );
    }*/
    public DateTime CurrentDate
    {        
        get => _currentDate;
        set
        {
            Set(ref _currentDate, value);
        }
    }

    

}
