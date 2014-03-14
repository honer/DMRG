using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
/// <summary>
/// MyMail 的摘要描述
/// </summary>
public static class MyMail
{
    public static string SendEMail(string subject, string body,string[] toAddress)
    {
        try
        {
            //create the mail message
            MailMessage mail = new MailMessage();

            //set the addresses
            mail.From = new MailAddress("m9890301@webmail.stut.edu.tw", "DMRG 聯絡我們 信件");

            foreach (string email in toAddress)
            {
                mail.To.Add(email);
            }

    		//set the content
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;

            //send the message
            SmtpClient smtp = new SmtpClient("webmail.stut.edu.tw", 25);
            smtp.Credentials = new System.Net.NetworkCredential("m9890301", "ten1104");
            smtp.EnableSsl = false;
            smtp.Send(mail);

            return "success";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }
}
