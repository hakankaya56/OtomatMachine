using Microsoft.Extensions.DependencyInjection;
using OtomatMachine.Application.Abstarct;
using OtomatMachine.Application.Concrete;
using OtomatMachine.Application.Mapper;
using OtomatMachine.Domain.Repositories.Abstract;
using OtomatMachine.Domain.Repositories.Base;
using OtomatMachine.Infrastructure.Repositories.Base;
using OtomatMachine.Infrastructure.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IDrinkService, DrinkManager>();
            services.AddScoped<IFoodService, FoodManager>();
            services.AddScoped<IMenuService, MenuManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();

            return services;
        }
    }
}
