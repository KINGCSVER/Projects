using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Context;
using Trendyol.Models;
using Trendyol.Services.Interfaces;
using System.Windows;
using Trendyol.Services.Classes;

namespace Trendyol.ViewModels;

public class StoreViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly TrendyolDbContext _context;
    private ObservableCollection<Product> _products;
    private Product _selectedProduct;
    private readonly CurrentUserService _currentUserService;
    private int _count;
    private string _product;

    public ObservableCollection<Product> Product
    {
        get => _products;
        set => Set(ref _products, value);
    }

    public int Count
    {
        get => _count;
        set => Set(ref _count, value);
    }

    public Product SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            if (Set(ref _selectedProduct, value))
            {
                Messenger.Default.Send(value.Name, "SelectedProductName");
            }
        }
    }

    public StoreViewModel(INavigationService navigationService, TrendyolDbContext context)
    {
        _navigationService = navigationService;
        _context = context;
        Product = new ObservableCollection<Product>(_context.Products);
        MessengerInstance.Register<Product>(this, "SelectedProductName", SetSelectedProductName);
    }

    private void SetSelectedProductName(Product selectedProduct)
    {
        SelectedProduct = selectedProduct;
    }

    public RelayCommand Exit
    {
        get => new(
            () =>
            {
                _navigationService.NavigateTo<MainViewModel>();
            });
    }

    public RelayCommand AddOrder
    {
        get => new(
            () =>
            {
                try
                {
                    string currentId = _currentUserService.Id;

                    if (_selectedProduct != null)
                    {
                        Messenger.Default.Send(SelectedProduct, "SelectedProductForOrder");

                        var wareHouseProduct = _context.Stock.FirstOrDefault(p => p.ProductId == _selectedProduct.Id);

                        if (wareHouseProduct != null)
                        {
                            if (wareHouseProduct.ProductCount < Count)
                            {
                                MessageBox.Show("This product is no longer in stock.");
                                _navigationService.NavigateTo<StoreViewModel>();

                                return;
                            }
                            else if (Count == 0)
                            {
                                MessageBox.Show("Input product count", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }

                        if (_selectedProduct.Count == 0)
                        {
                            _context.Products.Remove(_selectedProduct);
                            _context.SaveChanges();
                        }

                        Order order = new Order
                        {
                            UserId = currentId,
                            Product = _selectedProduct.Name,
                            ProductsCount = Count,
                            ProductId = _selectedProduct.Id,
                            Status = 1,
                            Created = DateTime.Now,
                        };

                        _context.Order.Add(order);
                        _context.SaveChanges();

                        var user = _context.User.FirstOrDefault(u => u.Id == _currentUserService.Id);
                        _context.SaveChanges();

                        wareHouseProduct.ProductCount -= Count;
                        _context.SaveChanges();

                        _selectedProduct.Count -= Count;
                        _context.SaveChanges();

                        MessageBox.Show("Successful order", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        Count = 0;

                        _navigationService.NavigateTo<MainViewModel>();
                    }
                    else
                    {
                        MessageBox.Show("Somthing wrong. Failed");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            });
    }
}