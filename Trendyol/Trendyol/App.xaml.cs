using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using System.Configuration;
using System.Data;
using System.Windows;
using Trendyol.Context;
using Trendyol.Services.Classes;
using Trendyol.Services.Interfaces;
using Trendyol.ViewModels;
using Trendyol.Views;

namespace Trendyol;


public partial class App : Application
{
    public static Container Container { get; set; } = new();
    public static MainView window = new();


    public void Register()
    {
        Container.RegisterSingleton<LoginViewModel>();
        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<RegistrationViewModel>();
        Container.RegisterSingleton<AccountInfoViewModel>();
        Container.RegisterSingleton<ForgotPasswordViewModel>();
        Container.RegisterSingleton<StoreViewModel>();
        Container.RegisterSingleton<SuperAdminViewModel>();
        Container.RegisterSingleton<AdminViewModel>();
        Container.RegisterSingleton<CreateUserViewModel>();
        Container.RegisterSingleton<CreateAdminViewModel>();
        Container.RegisterSingleton<AddProductViewModel>();

        Container.RegisterSingleton<INavigationService, NavigationService>();
        Container.RegisterSingleton<IMessenger, Messenger>();
        Container.RegisterSingleton<IDataService, DataService>();
        Container.RegisterSingleton<TrendyolDbContext>();
        Container.RegisterSingleton<CurrentUserService>();

        Container.Verify();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        Register();

        window.DataContext = Container.GetInstance<MainViewModel>();

        window.ShowDialog();
    }
}
