using GalaSoft.MvvmLight;
using MyMonefy.Services.Classes;
using MyMonefy.Services.Interfaces;

namespace MyMonefy.ViewModels;

public class DataViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    public DataViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public ButtonCommand Category_Click
    {
        get => new(
        () =>
        {
            _navigationService.NavigateTo<CalculatorViewModel>();
        });
    }
}
