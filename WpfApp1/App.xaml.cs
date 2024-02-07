
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfApp1.Mvvm.ViewModels;

namespace WpfApp1;


public partial class App : Application
{
    private IHost builder;

    public App()
    {
        builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
        {
            services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\my-projects\Crud_Database\Infrastructure\Data\CODE_FIRST_database.mdf;Integrated Security=True;Connect Timeout=30"));

            services.AddSingleton<CustomerRepository>();
            services.AddSingleton<AdressRepository>();
            services.AddSingleton<RoleRepository>();

            services.AddSingleton<CustomerService>();
            services.AddSingleton<AdressService>();
            services.AddSingleton<RoleService>();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();


        }).Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        builder.Start();

        var mainConsole = builder.Services.GetRequiredService<MainWindow>();
        mainConsole.Show();
    }
}
