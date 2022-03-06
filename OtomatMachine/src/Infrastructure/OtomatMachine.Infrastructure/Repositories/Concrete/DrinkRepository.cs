using OtomatMachine.Domain.Entites;
using OtomatMachine.Domain.Repositories.Abstract;
using OtomatMachine.Infrastructure.DataContext;
using OtomatMachine.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Infrastructure.Repositories.Concrete
{
   public class DrinkRepository:RepositoryBase<Drink>,IDrinkRepository
    {
        public DrinkRepository(OtomatMachineContext otomatMachineContext):base(otomatMachineContext)
        {

        }
    }
}
