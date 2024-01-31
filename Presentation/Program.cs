using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation;



var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\my-projects\Crud_Database\Infrastructure\Data\CODE_FIRST_database.mdf;Integrated Security=True;Connect Timeout=30"));
    services.AddDbContext<DataContext2>(y => y.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\my-projects\Crud_Database\Infrastructure\Data\SoftwareProductCatalog.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<AdressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<RoleRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<ChampionRepository>();
    services.AddScoped<TeamRepository>();
    services.AddScoped<LeagueRepository>();
    services.AddScoped<SizeRepository>();
    services.AddScoped<SoftwareProductRepository>();


    services.AddScoped<AdressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<RoleService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<ProductService>();
    services.AddScoped<ChampionService>();
    services.AddScoped<TeamService>();
    services.AddScoped<LeagueService>();
    services.AddScoped<SizeService>();
    services.AddScoped<SoftwareProductService>();

    services.AddScoped<MainMenu_UI>();


}).Build();

var mainMenu_UI = builder.Services.GetRequiredService<MainMenu_UI>();
//mainMenu_UI.CreateChampion_UI();
//mainMenu_UI.GetChampions_UI();
//mainMenu_UI.UpdateChampion_UI();
//mainMenu_UI.DeleteChampion_UI();
mainMenu_UI.Main_Menu_App_UI();
