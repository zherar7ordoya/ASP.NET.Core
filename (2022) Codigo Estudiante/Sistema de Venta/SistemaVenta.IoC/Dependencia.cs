using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.DAL.Implementacion;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.BLL.Implementacion;

namespace SistemaVenta.IoC;

public static class Dependencia
{
    public static async Task InyectarDependenciaAsync(this IServiceCollection services)
    {
        var vaultName = "zherar7ordoya";
        var vaultUri = $"https://{vaultName}.vault.azure.net/";
        var secretClient = new SecretClient(new Uri(vaultUri), new DefaultAzureCredential());

        KeyVaultSecret kvSecret = await secretClient.GetSecretAsync("ConnectionStringDBVENTA");
        string connectionString = kvSecret.Value;

        services.AddDbContext<DBVENTAContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}


//// Configuración de las dependencias del repositorio
//services.AddScoped<IProductoRepository, ProductoRepository>();
//services.AddScoped<ICategoriaRepository, CategoriaRepository>();
//services.AddScoped<IClienteRepository, ClienteRepository>();
//services.AddScoped<IVentaRepository, VentaRepository>();
//// Configuración de las dependencias del servicio
//services.AddScoped<IProductoService, ProductoService>();
//services.AddScoped<ICategoriaService, CategoriaService>();
//services.AddScoped<IClienteService, ClienteService>();
//services.AddScoped<IVentaService, VentaService>();