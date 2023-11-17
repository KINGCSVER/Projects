using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MyMonefy.Services.Classes;
using MyMonefy.Services.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMonefy.ViewModels;

public class CalculatorViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    public StringBuilder Expression = new();
    public string _expressionText;

    public string ExpressionText
    {
        get => _expressionText;
        set
        {
            Set(ref _expressionText, value);
        }
    }

    public CalculatorViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
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
            if (Expression.Length > 0)
            {

                ExpressionText = new System.Data.DataTable().Compute(Expression.ToString(), null).ToString();
                Expression.Clear();
                Expression.Append(ExpressionText);
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
}


