using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Demo.BL.Helper;

namespace Demo.Controllers
{
    public class MailController : Controller
    {
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(string Title , string Msg)
        {

            TempData["Message"] = MailSender.Mail(Title, Msg);

            return View();
        }
    }
}
