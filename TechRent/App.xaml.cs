using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using TechRent.Entities;
using TechRent.Extensions;
using TechRent.Features;
using TechRent.Features.DeleteItem;
using TechRent.Features.Navigation;
using TechRent.Features.UpdateItem;
using TechRent.Shared.DatabaseContext;
using TechRent.Shared.Queries;
using TechRent.Shared.ViewModels;

namespace TechRent
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddDbContext()
                .ConfigureServices(InitServices)
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            using (var scope = _host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContextFactory = services.GetRequiredService<ItemDbContextFactory>();
                using (var context = dbContextFactory.Create())
                {
                    context.Database.Migrate();
                }

                var mainWindow = services.GetRequiredService<MainWindow>();
                mainWindow.Show();
            }

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }

        private void InitServices(IServiceCollection services)
        {
            services.AddSingleton<FetchAllItems>();
            services.AddSingleton<CreateItemCommand>();
            services.AddSingleton<UpdateItemCommand>();
            services.AddSingleton<DbContextDeleteItem>();

            services.AddScoped<ItemProxy>(p =>
                new ItemProxy(
                    p.GetRequiredService<FetchAllItems>(),
                    p.GetRequiredService<CreateItemCommand>(),
                    p.GetRequiredService<UpdateItemCommand>(),
                    p.GetRequiredService<DbContextDeleteItem>()
                )
            );

            services.AddScoped<SelectedItemProxy>(sp =>
                new SelectedItemProxy(
                    sp.GetRequiredService<ItemProxy>()
                )
            );

            services.AddSingleton(new DialogNavigationProxy());
            services.AddScoped<InventoryViewModel>(CreateInventoryViewModel);
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainWindow>((services) => new MainWindow()
            {
                DataContext = services.GetRequiredService<MainWindowViewModel>()
            });
        }

        private InventoryViewModel CreateInventoryViewModel(IServiceProvider services)
        {
            return InventoryViewModel.LoadViewModel(
                services.GetRequiredService<ItemProxy>(),
                services.GetRequiredService<SelectedItemProxy>(),
                services.GetRequiredService<DialogNavigationProxy>());
        }
    }
}
