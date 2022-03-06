using Microsoft.EntityFrameworkCore;
using OtomatMachine.Domain.Entites;
using OtomatMachine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Infrastructure.DataContext
{
   public class OtomatMachineContext:DbContext
    {
        public OtomatMachineContext(DbContextOptions<OtomatMachineContext> options):base(options)
        {

        }
        public  DbSet<Drink> Drinks { get; set; }
        public  DbSet<Food> Foods { get; set; }
        public  DbSet<Order> Orders { get; set; }
        public  DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
