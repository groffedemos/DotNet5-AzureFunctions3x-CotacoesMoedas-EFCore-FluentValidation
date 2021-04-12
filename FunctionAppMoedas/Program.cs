using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FunctionAppMoedas.Data;

namespace FunctionAppMoedas
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services => {
                    services.AddDbContext<MoedasContext>(
                        options => options.UseSqlServer(
                            Environment.GetEnvironmentVariable("BaseServerlessMoedas")));
                    //services.AddEntityFrameworkSqlServer()
                    //    .AddDbContext<MoedasContext>(
                    //        options => options.UseSqlServer(
                    //            Environment.GetEnvironmentVariable("BaseServerlessMoedas")));
                })
                .Build();

            host.Run();
        }
    }
}