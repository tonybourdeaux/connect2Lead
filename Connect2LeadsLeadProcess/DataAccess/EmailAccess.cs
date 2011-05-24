using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace Connect2LeadsLeadProcess.DataAccess
{
    public class EmailAccess
    {


        public string sendMail(string fromName, string toName, string theSMTPServer, string SMTPUserName, string SMTPPassword,string theSubject, string theMessage, bool useSSL,Int16 portNumber=25){
         try
            {
                MailMessage mm = new MailMessage(fromName, toName);
                mm.Subject = theSubject;
                mm.Body = theMessage;
                SmtpClient smtp = new SmtpClient(theSMTPServer, portNumber);//587 for gmail
                NetworkCredential myCred = new NetworkCredential(SMTPUserName, SMTPPassword);
                smtp.Credentials = myCred;
                if (useSSL == true) {smtp.EnableSsl = true; }//use true for gmail
                smtp.Send(mm);
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
                
            }





        }
        public string sendMailMessage(string theSubject, string theMessage)
        {


            try
            {
                MailMessage mm = new MailMessage("tony@intelecenter.com", "tony@bourdeaux.com");
                mm.Subject = theSubject;
                mm.Body = theMessage;
                //string sendto = "leads@atlanticcoastmedia.com";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                //SmtpClient smtp = new SmtpClient("mail.acmgit.com");
                smtp.EnableSsl = true;
                NetworkCredential myCred = new NetworkCredential("tony@intelecenter.com", "a8866478");
                //NetworkCredential myCred = new NetworkCredential("ACMG\tbourdeaux", "user001");
                smtp.Credentials = myCred;
                //mm.From = new MailAddress(sendto);
                smtp.Send(mm);
                return "message sent";
            }
            catch (Exception ex)
            {

                return (ex.Message);
            }


        }
    }
}