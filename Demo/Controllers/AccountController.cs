using AutoMapper;
using Demo.BL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public AccountController(UserManager<IdentityUser> userManager 
            , SignInManager<IdentityUser> signInManager 
            , IMapper _mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            mapper = _mapper;
        }


        #region Registration

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    //var user = mapper.Map<IdentityUser>(model);

                    var user = new IdentityUser()
                    {
                        UserName = model.Email ,
                        Email = model.Email
                        
                    };

                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
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

        #endregion

        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {

                   var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Password Or Email");
                    }

                }

                return View(model);

            }
            catch (Exception ex)
            {
                return View(model);
            }
        }


        #endregion

        #region Sign Out

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        #endregion

        #region Forget Password

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);

                        var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                        
                        //MailSender.Mail("Password Reset", passwordResetLink);

                        //logger.Log(LogLevel.Warning, passwordResetLink);

                        using(var stream = new StreamWriter(@"D:\MyFiles\Token.txt"))
                        {
                           await  stream.WriteLineAsync(passwordResetLink);
                        }


                        return RedirectToAction("ConfirmForgetPassword");
                    }

                    return RedirectToAction("ConfirmForgetPassword");


                }


            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpGet]
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }

        #endregion

        #region Reset Password


        [HttpGet]
        public IActionResult ResetPassword(ResetPasswordVM model)
        {
            if(model.Email is null || model.Token is null)
            {
                ModelState.AddModelError("", "Invalid Token and Email");
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ActionName("ResetPassword")]
        public async Task<IActionResult> ResetPasswordPost(ResetPasswordVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("ConfirmResetPassword");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }

                    return RedirectToAction("ConfirmResetPassword");

                }


            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpGet]
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }

        #endregion












    }
}
