using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Demo.BL.Helper
{
    public static class MailSender
    {
        public static string Mail(string Title , string Message)
        {
            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {

                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("as8338873@gmail.com", "A@123321A@");
                    smtp.Send("as8338873@gmail.com", "elgendya160@gmail.com", Title, Message);
                }

                return "Mail Sent";

            }
            catch (Exception ex)
            {
                return "Mail Faild";
            }

        }
    }
}
