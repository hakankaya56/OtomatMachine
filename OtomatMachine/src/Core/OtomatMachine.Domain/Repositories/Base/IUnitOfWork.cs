using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.Repositories.Base
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void RollBack();
    }
}
