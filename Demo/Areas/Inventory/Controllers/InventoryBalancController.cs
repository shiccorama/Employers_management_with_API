using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Areas.Inventory.Controllers
{

    [Area("Inventory")]
    public class InventoryBalancController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
