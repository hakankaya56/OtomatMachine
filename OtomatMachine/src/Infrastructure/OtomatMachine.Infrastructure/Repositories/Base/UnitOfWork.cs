using OtomatMachine.Domain.Repositories.Base;
using OtomatMachine.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OtomatMachineContext _otomatMachineContext;

        public UnitOfWork(OtomatMachineContext otomatMachineContext)
        {
            _otomatMachineContext = otomatMachineContext;
        }

        public void Begin()
        {
            _otomatMachineContext.Database.BeginTransaction();
        }

        public void Commit()
        {
           _otomatMachineContext.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _otomatMachineContext.Database.RollbackTransaction();
        }
    }
}
