using Demo.BL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }


        public IActionResult Index()
        {
            var data = roleManager.Roles;
            return View(data);
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var data = new IdentityRole()
                    {
                        Name = model.RoleName,
                        NormalizedName = model.RoleName.ToUpper()
                    };

                    var result = await roleManager.CreateAsync(data);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

                return View(model);

            }
            catch (Exception ex)
            {
                return View(model);
            }


        }
    }
}
