﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUı.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUı.Controllers
{
    [AllowAnonymous]
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBokkATable(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
            var jsonData = JsonConvert.SerializeObject(createBookingDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
            var responseMessage = await client.PostAsync("https://localhost:7121/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Çokkeçeci Yazılım", "cokkececibbva@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", createBookingDto.Mail);

                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n\t<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\">\r\n  \t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0;\">\r\n \t<meta name=\"format-detection\" content=\"telephone=no\"/>\r\n\r\n\t<!-- Responsive Mobile-First Email Template by Konstantin Savchenko, 2015.\r\n\thttps://github.com/konsav/email-templates/  -->\r\n\r\n\t<style>\r\n/* Reset styles */ \r\nbody { margin: 0; padding: 0; min-width: 100%; width: 100% !important; height: 100% !important;}\r\nbody, table, td, div, p, a { -webkit-font-smoothing: antialiased; text-size-adjust: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; line-height: 100%; }\r\ntable, td { mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-collapse: collapse !important; border-spacing: 0; }\r\nimg { border: 0; line-height: 100%; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; }\r\n#outlook a { padding: 0; }\r\n.ReadMsgBody { width: 100%; } .ExternalClass { width: 100%; }\r\n.ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div { line-height: 100%; }\r\n\r\n/* Rounded corners for advanced mail clients only */ \r\n@media all and (min-width: 560px) {\r\n\t.container { border-radius: 8px; -webkit-border-radius: 8px; -moz-border-radius: 8px; -khtml-border-radius: 8px;}\r\n}\r\n\r\n/* Set color for auto links (addresses, dates, etc.) */ \r\na, a:hover {\r\n\tcolor: #127DB3;\r\n}\r\n.footer a, .footer a:hover {\r\n\tcolor: #999999;\r\n}\r\n\r\n \t</style>\r\n\r\n\t<!-- MESSAGE SUBJECT -->\r\n\t<title>Get this responsive email template</title>\r\n\r\n</head>\r\n\r\n<!-- BODY -->\r\n<!-- Set message background color (twice) and text color (twice) -->\r\n<body topmargin=\"0\" rightmargin=\"0\" bottommargin=\"0\" leftmargin=\"0\" marginwidth=\"0\" marginheight=\"0\" width=\"100%\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%; height: 100%; -webkit-font-smoothing: antialiased; text-size-adjust: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; line-height: 100%;\r\n\tbackground-color: #F0F0F0;\r\n\tcolor: #000000;\"\r\n\tbgcolor=\"#F0F0F0\"\r\n\ttext=\"#000000\">\r\n\r\n<!-- SECTION / BACKGROUND -->\r\n<!-- Set message background color one again -->\r\n<table width=\"100%\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; width: 100%;\" class=\"background\"><tr><td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;\"\r\n\tbgcolor=\"#F0F0F0\">\r\n\r\n<!-- WRAPPER -->\r\n<!-- Set wrapper width (twice) -->\r\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\"\r\n\twidth=\"560\" style=\"border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit;\r\n\tmax-width: 560px;\" class=\"wrapper\">\r\n\r\n\t<tr>\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;\r\n\t\t\tpadding-top: 20px;\r\n\t\t\tpadding-bottom: 20px;\">\r\n\r\n\t\t\t<!-- PREHEADER -->\r\n\t\t\t<!-- Set text color to background color -->\r\n\t\t\t<div style=\"display: none; visibility: hidden; overflow: hidden; opacity: 0; font-size: 1px; line-height: 1px; height: 0; max-height: 0; max-width: 0;\r\n\t\t\tcolor: #F0F0F0;\" class=\"preheader\">\r\n\t\t\t\tAvailable on&nbsp;GitHub and&nbsp;CodePen. Highly compatible. Designer friendly. More than 50%&nbsp;of&nbsp;total email opens occurred on&nbsp;a&nbsp;mobile device&nbsp;— a&nbsp;mobile-friendly design is&nbsp;a&nbsp;must for&nbsp;email campaigns.</div>\r\n\r\n\t\t\t<!-- LOGO -->\r\n\t\t\t<!-- Image text color should be opposite to background color. Set your url, image src, alt and title. Alt text should fit the image size. Real image size should be x2. URL format: http://domain.com/?utm_source={{Campaign-Source}}&utm_medium=email&utm_content=logo&utm_campaign={{Campaign-Name}} -->\r\n\t\t\t<a target=\"_blank\" style=\"text-decoration: none;\"\r\n\t\t\t\thref=\"https://github.com/konsav/email-templates/\"><img border=\"0\" vspace=\"0\" hspace=\"0\"\r\n\t\t\t\tsrc=\"https://raw.githubusercontent.com/konsav/email-templates/master/images/logo-black.png\"\r\n\t\t\t\twidth=\"100\" height=\"30\"\r\n\t\t\t\talt=\"Logo\" title=\"Logo\" style=\"\r\n\t\t\t\tcolor: #000000;\r\n\t\t\t\tfont-size: 10px; margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;\" /></a>\r\n\r\n\t\t</td>\r\n\t</tr>\r\n\r\n<!-- End of WRAPPER -->\r\n</table>\r\n\r\n<!-- WRAPPER / CONTEINER -->\r\n<!-- Set conteiner background color -->\r\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\"\r\n\tbgcolor=\"#FFFFFF\"\r\n\twidth=\"560\" style=\"border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit;\r\n\tmax-width: 560px;\" class=\"container\">\r\n\r\n\t<!-- HEADER -->\r\n\t<!-- Set text color and font family (\"sans-serif\" or \"Georgia, serif\") -->\r\n\t<tr>\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 24px; font-weight: bold; line-height: 130%;\r\n\t\t\tpadding-top: 25px;\r\n\t\t\tcolor: #000000;\r\n\t\t\tfont-family: sans-serif;\" class=\"header\">\r\n\t\t\t  Rezervasyonunuz Başarıyla Alınmıştır\r\n\t\t</td>\r\n\t</tr>\r\n\t\r\n\t<!-- SUBHEADER -->\r\n\t<!-- Set text color and font family (\"sans-serif\" or \"Georgia, serif\") -->\r\n\t<tr>\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-bottom: 3px; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 18px; font-weight: 300; line-height: 150%;\r\n\t\t\tpadding-top: 5px;\r\n\t\t\tcolor: #000000;\r\n\t\t\tfont-family: sans-serif;\" class=\"subheader\">\r\n\t\t\tSayın "+createBookingDto.Name+"&nbsp;Rezervasyonunuz&nbsp;Alınmıştır\r\n\t\t</td>\r\n\t</tr>\r\n\r\n\t<!-- HERO IMAGE -->\r\n\t<!-- Image text color should be opposite to background color. Set your url, image src, alt and title. Alt text should fit the image size. Real image size should be x2 (wrapper x2). Do not set height for flexible images (including \"auto\"). URL format: http://domain.com/?utm_source={{Campaign-Source}}&utm_medium=email&utm_content={{Ìmage-Name}}&utm_campaign={{Campaign-Name}} -->\r\n\t<tr>\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;\r\n\t\t\tpadding-top: 20px;\" class=\"hero\"><a target=\"_blank\" style=\"text-decoration: none;\"\r\n\t\t\thref=\"https://github.com/konsav/email-templates/\"><img border=\"0\" vspace=\"0\" hspace=\"0\"\r\n\t\t\tsrc=\"https://r.resimlink.com/w8urq.jpg\"\r\n\t\t\talt=\"Please enable images to view this content\" title=\"Hero Image\"\r\n\t\t\twidth=\"560\" style=\"\r\n\t\t\twidth: 100%;\r\n\t\t\tmax-width: 560px;\r\n\t\t\tcolor: #000000; font-size: 13px; margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;\"/></a></td>\r\n\t</tr>\r\n\r\n\t<!-- PARAGRAPH -->\r\n\t<!-- Set text color and font family (\"sans-serif\" or \"Georgia, serif\"). Duplicate all text styles in links, including line-height -->\r\n\t<tr>\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 17px; font-weight: 400; line-height: 160%;\r\n\t\t\tpadding-top: 25px;\r\n\t\t\tcolor: #000000;\r\n\t\t\tfont-family: sans-serif;\" class=\"paragraph\">\r\n\t\t\tSayın "+createBookingDto.Name+", "+ createBookingDto.Date.ToString("dd MMMM dddd")+ " Günü Saat "+ createBookingDto.Date.ToString("HH:mm")+ " için " + createBookingDto.PersonCount+" Kişilik Rezervasyonunuz Başarıyla Kayıt Yapılmıştır. Çokkeçeci Chef  ekibi olarak, sizi ağırlamaktan ve özel bir deneyim sunmaktan mutluluk duyacağız.\r\n\r\n\t\t\tLütfen rezervasyonunuzun zamanında yapılmasına özen gösteriniz. Eğer herhangi bir nedenle rezervasyonunuzu değiştirmeniz veya iptal etmeniz gerekiyorsa, lütfen en kısa sürede bizimle iletişime geçiniz.\r\n\t\t\tHerhangi bir sorunuz veya özel isteğiniz varsa, bize 0533 038 08 30 veya cokkececiyazilim@gmail.com üzerinden ulaşabilirsiniz.\r\n\t\t</td>\r\n\t</tr>\r\n\r\n\t<!-- BUTTON -->\r\n\t<!-- Set button background color at TD, link/text color at A and TD, font family (\"sans-serif\" or \"Georgia, serif\") at TD. For verification codes add \"letter-spacing: 5px;\". Link format: http://domain.com/?utm_source={{Campaign-Source}}&utm_medium=email&utm_content={{Button-Name}}&utm_campaign={{Campaign-Name}} -->\r\n\t<tr>\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;\r\n\t\t\tpadding-top: 25px;\r\n\t\t\tpadding-bottom: 5px;\" class=\"button\"><a\r\n\t\t\thref=\"https://github.com/konsav/email-templates/\" target=\"_blank\" style=\"text-decoration: underline;\">\r\n\t\t\t\t<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"max-width: 240px; min-width: 120px; border-collapse: collapse; border-spacing: 0; padding: 0;\"><tr><td align=\"center\" valign=\"middle\" style=\"padding: 12px 24px; margin: 0; text-decoration: underline; border-collapse: collapse; border-spacing: 0; border-radius: 4px; -webkit-border-radius: 4px; -moz-border-radius: 4px; -khtml-border-radius: 4px;\"\r\n\t\t\t\t\tbgcolor=\"#E9703E\"><a target=\"_blank\" style=\"text-decoration: underline;\r\n\t\t\t\t\tcolor: #FFFFFF; font-family: sans-serif; font-size: 17px; font-weight: 400; line-height: 120%;\"\r\n\t\t\t\t\thref=\"https://localhost:7229/Default/Index\">\r\n\t\t\t\t\t\tMenüye Dön\r\n\t\t\t\t\t</a>\r\n\t\t\t</td></tr></table></a>\r\n\t\t</td>\r\n\t</tr>\r\n\r\n\t<!-- LINE -->\r\n\t<!-- Set line color -->\r\n\t<tr>\t\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;\r\n\t\t\tpadding-top: 25px;\" class=\"line\"><hr\r\n\t\t\tcolor=\"#E0E0E0\" align=\"center\" width=\"100%\" size=\"1\" noshade style=\"margin: 0; padding: 0;\" />\r\n\t\t</td>\r\n\t</tr>\r\n\r\n\t<!-- LIST -->\r\n\t<tr>\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%;\" class=\"list-item\"><table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"width: inherit; margin: 0; padding: 0; border-collapse: collapse; border-spacing: 0;\">\r\n\t\t\t\r\n\t\t\t<!-- LIST ITEM -->\r\n\t\t\t<tr>\r\n\r\n\t\t\t\t<!-- LIST ITEM IMAGE -->\r\n\t\t\t\t<!-- Image text color should be opposite to background color. Set your url, image src, alt and title. Alt text should fit the image size. Real image size should be x2 -->\r\n\t\t\t\t<td align=\"left\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0;\r\n\t\t\t\t\tpadding-top: 30px;\r\n\t\t\t\t\tpadding-right: 20px;\"><img\r\n\t\t\t\tborder=\"0\" vspace=\"0\" hspace=\"0\" style=\"padding: 0; margin: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;\r\n\t\t\t\t\tcolor: #000000;\"\r\n\t\t\t\t\tsrc=\"https://raw.githubusercontent.com/konsav/email-templates/master/images/list-item.png\"\r\n\t\t\t\t\talt=\"H\" title=\"Highly compatible\"\r\n\t\t\t\t\twidth=\"50\" height=\"50\"></td>\r\n\r\n\t\t\t\t<!-- LIST ITEM TEXT -->\r\n\t\t\t\t<!-- Set text color and font family (\"sans-serif\" or \"Georgia, serif\"). Duplicate all text styles in links, including line-height -->\r\n\t\t\t\t<td align=\"left\" valign=\"top\" style=\"font-size: 17px; font-weight: 400; line-height: 160%; border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;\r\n\t\t\t\t\tpadding-top: 25px;\r\n\t\t\t\t\tcolor: #000000;\r\n\t\t\t\t\tfont-family: sans-serif;\" class=\"paragraph\">\r\n\t\t\t\t\t\t<b style=\"color: #333333;\">Highly compatible</b><br/>\r\n\t\t\t\t\t\tTested on the most popular email clients for web, desktop and mobile. Checklist included.\r\n\t\t\t\t</td>\r\n\r\n\t\t\t</tr>\r\n\r\n\t\t\t<!-- LIST ITEM -->\r\n\t\t\t<tr>\r\n\r\n\t\t\t\t<!-- LIST ITEM IMAGE -->\r\n\t\t\t\t<!-- Image text color should be opposite to background color. Set your url, image src, alt and title. Alt text should fit the image size. Real image size should be x2 -->\r\n\t\t\t\t<td align=\"left\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0;\r\n\t\t\t\t\tpadding-top: 30px;\r\n\t\t\t\t\tpadding-right: 20px;\"><img\r\n\t\t\t\tborder=\"0\" vspace=\"0\" hspace=\"0\" style=\"padding: 0; margin: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;\r\n\t\t\t\t\tcolor: #000000;\"\r\n\t\t\t\t\tsrc=\"https://raw.githubusercontent.com/konsav/email-templates/master/images/list-item.png\"\r\n\t\t\t\t\talt=\"D\" title=\"Designer friendly\"\r\n\t\t\t\t\twidth=\"50\" height=\"50\"></td>\r\n\r\n\t\t\t\t<!-- LIST ITEM TEXT -->\r\n\t\t\t\t<!-- Set text color and font family (\"sans-serif\" or \"Georgia, serif\"). Duplicate all text styles in links, including line-height -->\r\n\t\t\t\t<td align=\"left\" valign=\"top\" style=\"font-size: 17px; font-weight: 400; line-height: 160%; border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0;\r\n\t\t\t\t\tpadding-top: 25px;\r\n\t\t\t\t\tcolor: #000000;\r\n\t\t\t\t\tfont-family: sans-serif;\" class=\"paragraph\">\r\n\t\t\t\t\t\t<b style=\"color: #333333;\">Designer friendly</b><br/>\r\n\t\t\t\t\t\tSketch app resource file and a&nbsp;bunch of&nbsp;social media icons are&nbsp;also included in&nbsp;GitHub repository.\r\n\t\t\t\t</td>\r\n\r\n\t\t\t</tr>\r\n\r\n\t\t</table></td>\r\n\t</tr>\r\n\r\n\t<!-- LINE -->\r\n\t<!-- Set line color -->\r\n\t<tr>\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;\r\n\t\t\tpadding-top: 25px;\" class=\"line\"><hr\r\n\t\t\tcolor=\"#E0E0E0\" align=\"center\" width=\"100%\" size=\"1\" noshade style=\"margin: 0; padding: 0;\" />\r\n\t\t</td>\r\n\t</tr>\r\n\r\n\t<!-- PARAGRAPH -->\r\n\t<!-- Set text color and font family (\"sans-serif\" or \"Georgia, serif\"). Duplicate all text styles in links, including line-height -->\r\n\t<tr>\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 17px; font-weight: 400; line-height: 160%;\r\n\t\t\tpadding-top: 20px;\r\n\t\t\tpadding-bottom: 25px;\r\n\t\t\tcolor: #000000;\r\n\t\t\tfont-family: sans-serif;\" class=\"paragraph\">\r\n\t\t\t\tBir Sorunuz mu&nbsp;var? <a href=\"mailto:cokkececiyazilim@gmail.com\" target=\"_blank\" style=\"color: #127DB3; font-family: sans-serif; font-size: 17px; font-weight: 400; line-height: 160%;\">cokkececiyazilim@gmail.com</a>\r\n\t\t</td>\r\n\t</tr>\r\n\r\n<!-- End of WRAPPER -->\r\n</table>\r\n\r\n<!-- WRAPPER -->\r\n<!-- Set wrapper width (twice) -->\r\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\"\r\n\twidth=\"560\" style=\"border-collapse: collapse; border-spacing: 0; padding: 0; width: inherit;\r\n\tmax-width: 560px;\" class=\"wrapper\">\r\n\r\n\t<!-- SOCIAL NETWORKS -->\r\n\t<!-- Image text color should be opposite to background color. Set your url, image src, alt and title. Alt text should fit the image size. Real image size should be x2 -->\r\n\t<tr>\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%;\r\n\t\t\tpadding-top: 25px;\" class=\"social-icons\"><table\r\n\t\t\twidth=\"256\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"border-collapse: collapse; border-spacing: 0; padding: 0;\">\r\n\t\t\t<tr>\r\n\r\n\t\t\t\t<!-- ICON 1 -->\r\n\t\t\t\t<td align=\"center\" valign=\"middle\" style=\"margin: 0; padding: 0; padding-left: 10px; padding-right: 10px; border-collapse: collapse; border-spacing: 0;\"><a target=\"_blank\"\r\n\t\t\t\t\thref=\"https://raw.githubusercontent.com/konsav/email-templates/\"\r\n\t\t\t\tstyle=\"text-decoration: none;\"><img border=\"0\" vspace=\"0\" hspace=\"0\" style=\"padding: 0; margin: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: inline-block;\r\n\t\t\t\t\tcolor: #000000;\"\r\n\t\t\t\t\talt=\"F\" title=\"Facebook\"\r\n\t\t\t\t\twidth=\"44\" height=\"44\"\r\n\t\t\t\t\tsrc=\"https://raw.githubusercontent.com/konsav/email-templates/master/images/social-icons/facebook.png\"></a></td>\r\n\r\n\t\t\t\t<!-- ICON 2 -->\r\n\t\t\t\t<td align=\"center\" valign=\"middle\" style=\"margin: 0; padding: 0; padding-left: 10px; padding-right: 10px; border-collapse: collapse; border-spacing: 0;\"><a target=\"_blank\"\r\n\t\t\t\t\thref=\"https://raw.githubusercontent.com/konsav/email-templates/\"\r\n\t\t\t\tstyle=\"text-decoration: none;\"><img border=\"0\" vspace=\"0\" hspace=\"0\" style=\"padding: 0; margin: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: inline-block;\r\n\t\t\t\t\tcolor: #000000;\"\r\n\t\t\t\t\talt=\"T\" title=\"Twitter\"\r\n\t\t\t\t\twidth=\"44\" height=\"44\"\r\n\t\t\t\t\tsrc=\"https://raw.githubusercontent.com/konsav/email-templates/master/images/social-icons/twitter.png\"></a></td>\t\t\t\t\r\n\r\n\t\t\t\t<!-- ICON 3 -->\r\n\t\t\t\t<td align=\"center\" valign=\"middle\" style=\"margin: 0; padding: 0; padding-left: 10px; padding-right: 10px; border-collapse: collapse; border-spacing: 0;\"><a target=\"_blank\"\r\n\t\t\t\t\thref=\"https://raw.githubusercontent.com/konsav/email-templates/\"\r\n\t\t\t\tstyle=\"text-decoration: none;\"><img border=\"0\" vspace=\"0\" hspace=\"0\" style=\"padding: 0; margin: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: inline-block;\r\n\t\t\t\t\tcolor: #000000;\"\r\n\t\t\t\t\talt=\"G\" title=\"Google Plus\"\r\n\t\t\t\t\twidth=\"44\" height=\"44\"\r\n\t\t\t\t\tsrc=\"https://raw.githubusercontent.com/konsav/email-templates/master/images/social-icons/googleplus.png\"></a></td>\t\t\r\n\r\n\t\t\t\t<!-- ICON 4 -->\r\n\t\t\t\t<td align=\"center\" valign=\"middle\" style=\"margin: 0; padding: 0; padding-left: 10px; padding-right: 10px; border-collapse: collapse; border-spacing: 0;\"><a target=\"_blank\"\r\n\t\t\t\t\thref=\"https://raw.githubusercontent.com/konsav/email-templates/\"\r\n\t\t\t\tstyle=\"text-decoration: none;\"><img border=\"0\" vspace=\"0\" hspace=\"0\" style=\"padding: 0; margin: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: inline-block;\r\n\t\t\t\t\tcolor: #000000;\"\r\n\t\t\t\t\talt=\"I\" title=\"Instagram\"\r\n\t\t\t\t\twidth=\"44\" height=\"44\"\r\n\t\t\t\t\tsrc=\"https://raw.githubusercontent.com/konsav/email-templates/master/images/social-icons/instagram.png\"></a></td>\r\n\r\n\t\t\t</tr>\r\n\t\t\t</table>\r\n\t\t</td>\r\n\t</tr>\r\n\r\n\t<!-- FOOTER -->\r\n\t<!-- Set text color and font family (\"sans-serif\" or \"Georgia, serif\"). Duplicate all text styles in links, including line-height -->\r\n\t<tr>\r\n\t\t<td align=\"center\" valign=\"top\" style=\"border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 6.25%; padding-right: 6.25%; width: 87.5%; font-size: 13px; font-weight: 400; line-height: 150%;\r\n\t\t\tpadding-top: 20px;\r\n\t\t\tpadding-bottom: 20px;\r\n\t\t\tcolor: #999999;\r\n\t\t\tfont-family: sans-serif;\" class=\"footer\">\r\n\r\n\t\t\tBu e-posta şablonu size dünyayı daha iyi bir yer haline getirmek istediğimiz için gönderildi. Abonelik ayarlarınızı istediğiniz zaman değiştirebilirsiniz.\r\n\r\n\t\t\t<!-- ANALYTICS -->\r\n\t\t\t<!-- http://www.google-analytics.com/collect?v=1&tid={{UA-Tracking-ID}}&cid={{Client-ID}}&t=event&ec=email&ea=open&cs={{Campaign-Source}}&cm=email&cn={{Campaign-Name}} -->\r\n\t\t\t<img width=\"1\" height=\"1\" border=\"0\" vspace=\"0\" hspace=\"0\" style=\"margin: 0; padding: 0; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; border: none; display: block;\"\r\n\t\t\t\t src=\"https://raw.githubusercontent.com/konsav/email-templates/master/images/tracker.png\" />\r\n\r\n\t\t</td>\r\n\t</tr>\r\n\r\n<!-- End of WRAPPER -->\r\n</table>\r\n\r\n<!-- End of SECTION / BACKGROUND -->\r\n</td></tr></table>\r\n\r\n</body>\r\n</html>";

                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = "Rezervasyonuz İçin Teşekkür Ederiz";
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("cokkececibbva@gmail.com", "fhbwiirrctprzmbu");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);


                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
