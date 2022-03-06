using OtomatMachine.Domain.DTOs.Menus;
using OtomatMachine.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Application.Abstarct
{
    public interface IMenuService
    {
        Task<Result<MenuDtoForList>> Menus();
    }
}
