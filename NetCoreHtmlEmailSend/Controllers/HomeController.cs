using Microsoft.AspNetCore.Mvc;
using NetCoreHtmlEmailSend.Models;
using NetCoreHtmlEmailSend.Models.EmailService;
using System.Diagnostics;

namespace NetCoreHtmlEmailSend.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
		private readonly IEmailServices _emailServices;	

		public HomeController(ILogger<HomeController> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, IEmailServices emailServices)
		{
			_logger = logger;
			_environment = environment;
			_emailServices = emailServices;
		}

		public IActionResult Index()
		{
            ViewModels models = new ViewModels();

            return View(models);
		}
		[HttpPost]
        public IActionResult Index(ViewModels model)
        {
			var text = "Hoşgeldinizz";
			var webroot = _environment.WebRootPath;
			var pathFile = _environment.WebRootPath
				+ Path.DirectorySeparatorChar.ToString()
				+ "Templates"
				+ Path.DirectorySeparatorChar.ToString()
				+ "EmailTemplate"
				+ Path.DirectorySeparatorChar.ToString()
				+ "welcome.html";

			StreamReader str=new StreamReader(pathFile);
			string mailtext = str.ReadToEnd();
			mailtext=mailtext.Replace("{", "{{").Replace("}", "}}"); // Çok Önemli 
			mailtext = mailtext.Replace("[hosgelsiniz]", text);
            mailtext = mailtext.Replace("[mailadres]", model.formshtml.Email);
			string meBody = string.Format(mailtext);


			_emailServices.SendEmailAsync(model.formshtml.Email,"Abone Olun Lütfen", meBody);


            return View(model);
        }

        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}