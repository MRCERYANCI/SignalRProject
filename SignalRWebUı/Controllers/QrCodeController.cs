using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUı.Controllers
{
    public class QrCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squardCode = createQRCode.CreateQrCode(Value,QRCodeGenerator.ECCLevel.H);
                using(Bitmap image = squardCode.GetGraphic(10))
                {
                    image.Save(memoryStream,ImageFormat.Png); //Resmi Kaydetmesini Söylüyoruz
                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }  //Burda QRcodun çizimini gerçekleştircez
            }
            return View();
        }
    }
}
