using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MyMonefy.Services.Classes;
using MyMonefy.Services.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using static System.Net.Mime.MediaTypeNames;

namespace MyMonefy.ViewModels;

public class CalculatorViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    public StringBuilder Expression = new();
    public string _expressionText;
    public DateTime _currentDate = DateTime.Today;
    DataViewModel _dataViewModel { get; set; }
    

    public string ExpressionText
    {
        get => _expressionText;
        set
        {
            Set(ref _expressionText, value);
        }
    }

    public CalculatorViewModel(INavigationService navigationService, DataViewModel dataViewModel)
    {
        _navigationService = navigationService;
        _dataViewModel =  dataViewModel;
    }

    public static double Evaluate(StringBuilder expression, string expressionText)
    {
        if (expression.Length > 0)
        {

            expressionText = new System.Data.DataTable().Compute(expression.ToString(), null).ToString();
            expression.Clear();
            expression.Append(expressionText);
        }
        return double.Parse(expression.ToString());
    }

    public RelayCommand<string> Calculator_Click
    {
        get => new((operation) =>
        {
            if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
            {
                ExpressionText += operation;
            }
            else
            {
                ExpressionText = "";               
            }

            Expression.Append(operation);
        });
    }
    public RelayCommand Equal_Click
    {
        get => new(
        () =>
        {
            double tmp = Evaluate(Expression, ExpressionText);
            if (tmp < 0)
            {
                ExpressionText = "0";
            }
            else
            {
                ExpressionText = tmp.ToString();
            }
        });
    }

    public ButtonCommand Back_Click
    {
        get => new(
        () =>
        {
            _navigationService.NavigateTo<DataViewModel>();
        });
    }

    public RelayCommand Backspace_Click
    {
        get => new(() =>
        {
            if (Expression.Length > 0)
            {
                Expression.Remove(Expression.Length - 1, 1);
            }

            if (!string.IsNullOrEmpty(ExpressionText))
            {
                ExpressionText = ExpressionText.Substring(0, ExpressionText.Length - 1);
            }
        });
    }
    public RelayCommand Add_Click
    {
        get => new(() =>
        {
            foreach (var item in _dataViewModel.dates)
            {
                if (item.date == _currentDate)
                {
                    foreach (var j in item.Categories)
                    {
                        if (j.Name == _dataViewModel.SelectedCategory)
                        {
                            j.Costs += Evaluate(Expression, ExpressionText);
                        }
                    }
                }
            }
            
            _navigationService.NavigateTo<DataViewModel>();
        });
    }
    public DateTime CurrentDate
    {
        get => _currentDate;
        set
        {
            Set(ref _currentDate, value);
        }
    }
}