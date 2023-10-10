using System.Net;
using System.Net.Mail;

namespace NetCoreHtmlEmailSend.Models.EmailService
{
	public class EmailServices: IEmailServices
	{
		public async Task SendEmailAsync(string email,string subject,string message)
		{
			try
			{
				//string Address = "";// Email Adresiniz // onur@anatoliahosting.com
				//string Password = ""; // E Mail Şifreniz // şifre işte
				//string FromAdressTitle = ""; // Mail Başlığınız // Merhaba la
				//string BodyContent = message;
				//string server = ""; //mail.domainadiniz.com

                string Address = "onur@anatoliahosting.com";
                string Password = "3KVtzR9H***";
                string FromAdressTitle = "Abone ol";
                string BodyContent = message;
                string server = "mail.anatoliahosting.com";

                int port = 587;
				MailMessage mailMessage = new MailMessage();
				SmtpClient smtpClient = new SmtpClient();
				smtpClient.Credentials = new NetworkCredential(Address, Password);
				smtpClient.Port = port;
				smtpClient.Host = server;
				smtpClient.EnableSsl = false;
				mailMessage.IsBodyHtml = true;
				mailMessage.From = new MailAddress(Address);
				mailMessage.To.Add(email);
				mailMessage.Subject = FromAdressTitle;
				mailMessage.Body = BodyContent;
				smtpClient.Send(mailMessage);
			}
			catch (Exception ex)
			{

				throw ex;
			}


		}

		
	}
}
