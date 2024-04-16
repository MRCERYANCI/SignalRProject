using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalREntityLayer.Entities;
using SignalRWebUı.Dtos.IdentityDtos;
using SignalRWebUı.Models;

namespace SignalRWebUı.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public static int DogrulamaKodu = 0;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDtos loginDtos)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDtos.UserName, loginDtos.Password, true, true);
            if (result.Succeeded)
            {

                Random random = new Random();
                DogrulamaKodu = random.Next(0, 999999);

                var values = await _userManager.FindByNameAsync(loginDtos.UserName);
                if (values != null)
                {
                    string Giris_Yapılan_Adres = $"{loginDtos.Mahalle} {loginDtos.Cadde}, {loginDtos.PostaKodu} {loginDtos.Sehir} {loginDtos.Ilce}, {loginDtos.Ulke}";

                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Çokkeçeci Yazılım", "cokkececibbva@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", values.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Actionable emails e.g. reset password</title>\r\n    <style>\r\n        * {\r\n            margin: 0;\r\n            padding: 0;\r\n            font-family: \"Helvetica Neue\", \"Helvetica\", Helvetica, Arial, sans-serif;\r\n            box-sizing: border-box;\r\n            font-size: 14px;\r\n        }\r\n\r\n        img {\r\n            max-width: 100%;\r\n        }\r\n\r\n        body {\r\n            -webkit-font-smoothing: antialiased;\r\n            -webkit-text-size-adjust: none;\r\n            width: 100% !important;\r\n            height: 100%;\r\n            line-height: 1.6;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        body {\r\n            background-color: #f6f6f6;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            /* makes it centered */\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .header {\r\n            width: 100%;\r\n            margin-bottom: 20px;\r\n        }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer a {\r\n                color: #999;\r\n            }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n\r\n        h1, h2, h3 {\r\n            font-family: \"Helvetica Neue\", Helvetica, Arial, \"Lucida Grande\", sans-serif;\r\n            color: #000;\r\n            margin: 40px 0 0;\r\n            line-height: 1.2;\r\n            font-weight: 400;\r\n        }\r\n\r\n        h1 {\r\n            font-size: 32px;\r\n            font-weight: 500;\r\n        }\r\n\r\n        h2 {\r\n            font-size: 24px;\r\n        }\r\n\r\n        h3 {\r\n            font-size: 18px;\r\n        }\r\n\r\n        h4 {\r\n            font-size: 14px;\r\n            font-weight: 600;\r\n        }\r\n\r\n        p, ul, ol {\r\n            margin-bottom: 10px;\r\n            font-weight: normal;\r\n        }\r\n\r\n            p li, ul li, ol li {\r\n                margin-left: 5px;\r\n                list-style-position: inside;\r\n            }\r\n\r\n        a {\r\n            color: #1ab394;\r\n            text-decoration: underline;\r\n        }\r\n\r\n        .btn-primary {\r\n            text-decoration: none;\r\n            color: #FFF;\r\n            background-color: #1ab394;\r\n            border: solid #1ab394;\r\n            border-width: 5px 10px;\r\n            line-height: 2;\r\n            font-weight: bold;\r\n            text-align: center;\r\n            cursor: pointer;\r\n            display: inline-block;\r\n            border-radius: 5px;\r\n            text-transform: capitalize;\r\n        }\r\n\r\n\r\n        .last {\r\n            margin-bottom: 0;\r\n        }\r\n\r\n        .first {\r\n            margin-top: 0;\r\n        }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n\r\n        .alignright {\r\n            text-align: right;\r\n        }\r\n\r\n        .alignleft {\r\n            text-align: left;\r\n        }\r\n\r\n        .clear {\r\n            clear: both;\r\n        }\r\n\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert a {\r\n                color: #fff;\r\n                text-decoration: none;\r\n                font-weight: 500;\r\n                font-size: 16px;\r\n            }\r\n\r\n            .alert.alert-warning {\r\n                background: #f8ac59;\r\n            }\r\n\r\n            .alert.alert-bad {\r\n                background: #ed5565;\r\n            }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .invoice {\r\n            margin: 40px auto;\r\n            text-align: left;\r\n            width: 80%;\r\n        }\r\n\r\n            .invoice td {\r\n                padding: 5px 0;\r\n            }\r\n\r\n            .invoice .invoice-items {\r\n                width: 100%;\r\n            }\r\n\r\n                .invoice .invoice-items td {\r\n                    border-top: #eee 1px solid;\r\n                }\r\n\r\n                .invoice .invoice-items .total td {\r\n                    border-top: 2px solid #333;\r\n                    border-bottom: 2px solid #333;\r\n                    font-weight: 700;\r\n                }\r\n\r\n        @media only screen and (max-width: 640px) {\r\n            h1, h2, h3, h4 {\r\n                font-weight: 600 !important;\r\n                margin: 20px 0 5px !important;\r\n            }\r\n\r\n            h1 {\r\n                font-size: 22px !important;\r\n            }\r\n\r\n            h2 {\r\n                font-size: 18px !important;\r\n            }\r\n\r\n            h3 {\r\n                font-size: 16px !important;\r\n            }\r\n\r\n            .container {\r\n                width: 100% !important;\r\n            }\r\n\r\n            .content, .content-wrap {\r\n                padding: 10px !important;\r\n            }\r\n\r\n            .invoice {\r\n                width: 100% !important;\r\n            }\r\n        }\r\n    </style>\r\n\r\n</head>\r\n\r\n<body>\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td>\r\n                                            <img class=\"img-fluid\" src=\"https://r.resimlink.com/hlr1_P.jpg\" />\r\n                                        </td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            <h3>Doğrulama Kodu:  " + DogrulamaKodu.ToString() + "</h3>\r\n                                        </td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Hesabına giriş talebi talebi aldık. Bu işlemi sen gerçekleştirmediysen www.cokkececiyazilim.com.tr den bizimle iletişime geçebilirsin veya +90 533 038 08 30 7/24 İletişim merkezimizi arayarak hesabınızı koruma altına alabilirsiniz. <br> <br> Giriş Yapılan Adres: "+Giris_Yapılan_Adres+"\r\n                                        </td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Çokkeçeci Yazılım Sizin Kullanıcı Adı ve Şifrenizi Talep Etmez\r\n                                        </td>\r\n                                    </tr>\r\n                                  \r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Çokkeçeci Yazılım 2023 | Tüm Hakları Saklıdır </td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n";

                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Doğrulama Kodu İsteği";
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("cokkececibbva@gmail.com", "fhbwiirrctprzmbu");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);
                }

                return RedirectToAction("OtpVerification");
            }
            return View();
        }

        [HttpGet]
        public IActionResult OtpVerification()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OtpVerification(int Number1, int Number2, int Number3, int Number4, int Number5, int Number6)
        {
            string OtpVerification = Number1.ToString() + Number2.ToString() + Number3.ToString() + Number4.ToString() + Number5.ToString() + Number6.ToString();
            if (OtpVerification != null)
            {
                if (OtpVerification == DogrulamaKodu.ToString())
                {
                    OtpNotificationSecurity otpNotificationSecurity = new OtpNotificationSecurity();
                    otpNotificationSecurity.OtpStatus = true;
                    return RedirectToAction("Index", "ProgressBar");
                }
            }

            return View();
        }

    }
}
