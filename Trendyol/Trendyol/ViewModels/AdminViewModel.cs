using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Context;
using Trendyol.Models;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;
using System.Windows;

namespace Trendyol.ViewModels;

public class AdminViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly TrendyolDbContext _context;
    private readonly CurrentUserService _currentUserService;
    private ObservableCollection<Order> _order;
    private Order _selectedOrder;

    public ObservableCollection<Order> Order
    {
        get => _order;
        set => Set(ref _order, value);
    }

    public Order SelectedOrder
    {
        get => _selectedOrder;
        set => Set(ref _selectedOrder, value);
    }

    public AdminViewModel(INavigationService navigationService, TrendyolDbContext context, CurrentUserService currentUserService)
    {
        _navigationService = navigationService;
        _context = context;
        _currentUserService = currentUserService;
        Order = new ObservableCollection<Order>(_context.Order.ToList());
    }

    public RelayCommand Add
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<AddProductViewModel>();
        });
    }
    public RelayCommand ChangeStatus
    {
        get => new(() => 
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        });    
    }
    public RelayCommand Quit
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<LoginViewModel>();
        });
    }
}