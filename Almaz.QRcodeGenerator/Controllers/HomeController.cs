using Almaz.QRcodeGenerator.Models;
using Almaz.QRcodeGenerator.QRcodeGenerator;
using Almaz.QRcodeGenerator.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics; 

namespace Almaz.QRcodeGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQRcodeGenerator qRcodeGenerator;

        public HomeController(ILogger<HomeController> logger, IQRcodeGenerator qRcodeGenerator)
        {
            _logger = logger;
            this.qRcodeGenerator = qRcodeGenerator;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest();
            }
            byte[] QRCodeByte = qRcodeGenerator.GenerateQRCode(text);
            string QRCodeImageBase64 = $"data:image/png;base64,{Convert.ToBase64String(QRCodeByte)}";

            GenerateQRcodeViewModel model = new GenerateQRcodeViewModel();
            model.QRcodeImageUrl = QRCodeImageBase64;

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