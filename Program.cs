using System;
using System.Threading;
using System.Threading.Tasks;
using EasyGas.Data;
using EasyGas.Interfaces;
using EasyGas.Repositorio;
using EasyGas.Service;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace EasyGas
{
    public class Program
    {
        [STAThread] 
        public static void Main(string[] args)
        {
            // 1. Sobe o servidor web local (ASP.NET Core / Kestrel) em uma thread separada
            Task.Run(() =>
            {
                var builder = WebApplication.CreateBuilder(args);

                
                builder.WebHost.UseUrls("http://127.0.0.1:5001");

                
                builder.Services.AddControllersWithViews();
                
                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(
                        builder.Configuration.GetConnectionString("DefaultConnection")
                    )
                );
                
                builder.Services.AddScoped<IClientesService, ClientesService>();
                builder.Services.AddScoped<IOrdemServicoService, OrdemServicoService>();
                builder.Services.AddScoped<IColaboradoresService, ColaboradoresService>();
                builder.Services.AddScoped<IFaturamentoService, FaturamentoService>();
                builder.Services.AddScoped<IAnexoOsService, AnexoOsService>();
                builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                
                var app = builder.Build();

                app.UseStaticFiles();
                app.UseRouting();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            });

            
            Thread.Sleep(500);
            var appWpf = new System.Windows.Application();
            appWpf.Run(new MainWindow());
        }
    }
}