﻿namespace NetCoreHtmlEmailSend.Models.EmailService
{
	public interface IEmailServices
	{
		Task SendEmailAsync(string email, string subject, string message);
	}
}
