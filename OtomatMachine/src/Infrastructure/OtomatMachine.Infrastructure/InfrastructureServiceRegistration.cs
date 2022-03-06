using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OtomatMachine.Domain.Entites;
using OtomatMachine.Domain.Repositories.Abstract;
using OtomatMachine.Domain.Repositories.Base;
using OtomatMachine.Infrastructure.DataContext;
using OtomatMachine.Infrastructure.Repositories.Base;
using OtomatMachine.Infrastructure.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OtomatMachineContext>(options => options.UseSqlServer(configuration.GetConnectionString("OtomatMachineConnectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDrinkRepository, DrinkRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            return services;
        }
    }
}
