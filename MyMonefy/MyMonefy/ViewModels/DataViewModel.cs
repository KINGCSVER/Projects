using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using MyMonefy.Models;
using MyMonefy.Services.Classes;
using MyMonefy.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyMonefy.ViewModels;

public class DataViewModel : ViewModelBase
{
    public ICommand Category_Click { get; private set; }
    private readonly INavigationService _navigationService;
    private readonly IMessenger _messengerService;

    public string SelectedCategory;
    public ObservableCollection<Date> dates = new ObservableCollection<Date>();

    public PieChart _pieChart = new();
    public string Color;
    public string Icon;

    public DateTime _currentDate = DateTime.Today;
    public Date SelectedDate;

    public string _balance;

    public string Balance
    {
        get => _balance;
        set
        {
            Set(ref _balance, value);
        }
    }

    public PieChart PieChart
    {
        get => _pieChart;
        set
        {
            Set(ref _pieChart, value);
        }
    }
    public DataViewModel(INavigationService navigationService, IMessenger messengerService)
    {
        Category_Click = new RelayCommand<Button>(ButtonClick);

        if (dates.Count == 0)
        {
            Date newDate = new Date(_currentDate);
            dates.Add(newDate);
        }

        _navigationService = navigationService;
        _messengerService = messengerService;
    }
    public void ButtonClick(Button category)
    {

        var button = category.Content as PackIcon;

        Color = button.Foreground.ToString();
        Icon = button.Kind.ToString();

        SelectedCategory = category.Name;

        _navigationService.NavigateTo<CalculatorViewModel>();
    }
    public DateTime CurrentDate
    {
        get => _currentDate;
        set
        {

            Set(ref _currentDate, value);
            if (dates.Count != 0)
            {
                foreach (var _date in dates)
                {
                    if (_date.date == _currentDate)
                    {                        
                        return;
                    }
                }
                Date newDate = new Date(_currentDate);
                dates.Add(newDate);
            }
            else
            {
                Date newDate = new Date(_currentDate);
                dates.Add(newDate);
            }
        }
    }
}
