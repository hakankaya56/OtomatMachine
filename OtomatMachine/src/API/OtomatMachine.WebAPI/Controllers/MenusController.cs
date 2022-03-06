using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtomatMachine.Application.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtomatMachine.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetMenus")]
        public async Task<IActionResult> GetMenus()
        {
            var menus = await _menuService.Menus();
            return Ok(menus);
        }
    }
}
