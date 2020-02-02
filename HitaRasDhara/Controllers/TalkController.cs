using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using HitaRasDhara.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using QRCoder;
using Image = iTextSharp.text.Image;

namespace HitaRasDhara.Controllers
{
    public class TalkController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Register", "Talk");
        }

        public ActionResult Register()
        {
            var viewModel = new UserResponse5Aug();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(UserResponse5Aug input)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            try
            {
                var userDetails = _dbContext.UserResponse5Aug.Find(input.Phone);
                if (userDetails == null)
                {
                    input.SeatStatus = "Registered";
                    input.TimeStamp = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                        TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                    _dbContext.UserResponse5Aug.Add(input);
                    _dbContext.SaveChanges();
                    var UpdatedUserDetails = _dbContext.UserResponse5Aug.Find(input.Phone);
                    string smsData = string.Format(_dbContext.SmsContent.Find("RegisteredSuccessfully").Value,
                        input.Name, getVisualRegistrationId(UpdatedUserDetails.RegistrationID), input.YearOfBirth);
                    bool smsSent = sendSMS(input.Phone, smsData);
                    return PrintPDF(input.Phone);
                }
                if (userDetails.SeatStatus.Equals("Cancelled"))
                {
                    userDetails.City = input.City;
                    userDetails.YearOfBirth = input.YearOfBirth;
                    userDetails.Name = input.Name;
                    userDetails.SeatStatus = "Registered";
                    userDetails.TimeStamp = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                        TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                    userDetails.Question = input.Question;
                    userDetails.Email = input.Email;
                    _dbContext.SaveChanges();
                    string smsData = string.Format(_dbContext.SmsContent.Find("RegisteredSuccessfully").Value,
                        input.Name, getVisualRegistrationId(userDetails.RegistrationID), input.YearOfBirth);
                    bool smsSent = sendSMS(input.Phone, smsData);
                    return PrintPDF(input.Phone);
                }

                byte[] content = { 1, 2 };
                return File(content, "text/html");
            }
            catch (Exception ex)
            {
                byte[] content = { 3 };
                return File(content, "text/html");
            }
        }

        public ActionResult Reprint()
        {
            var viewModel = new MobileVerificationViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Reprint(MobileVerificationViewModel input)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var userDetails = _dbContext.UserResponse5Aug.Find(input.Phone);
            if (userDetails == null || !userDetails.SeatStatus.Equals("Registered"))
            {
                byte[] content = { 7 };
                return File(content, "text/html");
            }
            return PrintPDF(input.Phone);//9 - success
        }

        public string GenerateOtp(int otpLength)
        {
            string sOTP = string.Empty;
            string sTempChars = string.Empty;
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            Random rand = new Random();
            for (int i = 0; i < otpLength; i++)
            {
                int p = rand.Next(0, saAllowedCharacters.Length);
                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
                sOTP += sTempChars;
            }
            return sOTP;
        }

        [HttpPost]
        public ActionResult PrintPDF(string phone)
        {
            byte[] doc = GeneratePDF(phone);
            return File(doc, "application/pdf", phone + ".pdf");
        }

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }

        //[HttpPost]
        public byte[] GeneratePDF(string mobile)
        {
            try
            {
                ApplicationDbContext _dbContext = new ApplicationDbContext();
                UserResponse5Aug UserDetails = _dbContext.UserResponse5Aug.Find(mobile);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    #region documentDefinitionStart
                    var pgSize = new iTextSharp.text.Rectangle(560, 1090);
                    Document pdfDoc = new Document(pgSize, 0f, 0f, 0f, 0f);
                    Response.ContentType = "application/pdf";
                    var writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    var baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 24, iTextSharp.text.Font.NORMAL);
                    Response.AddHeader("content-disposition", "attachment;filename="+ UserDetails?.Name +".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    #endregion

                    #region BgImageStarts
                    string imageFilePath = Server.MapPath("~") + "/EntryPassBg.jpg";
                    Image bgImage = Image.GetInstance(imageFilePath);
                    bgImage.Alignment = Image.UNDERLYING;
                    #endregion

                    #region QrCodeStarts
                    var qrCodeImage = Image.GetInstance(GenerateQrCode(UserDetails.Phone));
                    qrCodeImage.ScaleAbsoluteWidth(250);
                    qrCodeImage.ScaleAbsoluteHeight(250);
                    qrCodeImage.Alignment = Element.ALIGN_CENTER;
                    qrCodeImage.SetAbsolutePosition(float.Parse(_dbContext.SmsContent.Find("qrCodeXCoordinate").Value), float.Parse(_dbContext.SmsContent.Find("qrCodeYCoordinate").Value));
                    #endregion

                    #region build
                    pdfDoc.Open();
                    pdfDoc.NewPage();
                    pdfDoc.Add(bgImage);
                    for (int i = 0; i < Convert.ToInt32(_dbContext.SmsContent.Find("LineGapAbove").Value); i++)
                    {
                        pdfDoc.Add(new Paragraph("\n"));
                    }
                    pdfDoc.Add(new Paragraph(UserDetails.Name + " - " + UserDetails.YearOfBirth, font)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    for (int i = 0; i < Convert.ToInt32(_dbContext.SmsContent.Find("LineGapBottom").Value); i++)
                    {
                        pdfDoc.Add(new Paragraph("\n"));

                    }
                    pdfDoc.Add(new Paragraph(getVisualRegistrationId(UserDetails.RegistrationID), font)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    pdfDoc.Add(qrCodeImage);
                    pdfDoc.Close();
                    //Finalize the contents of the stream into an array
                    var bytes = memoryStream.ToArray();
                    #endregion

                    #region email

                    MailMessage msg = new MailMessage();
                    msg.To.Add(new MailAddress(UserDetails.Email));
                    msg.From = new MailAddress("info@hitaambrish.com", "Hita Ambrish");
                    msg.Subject = "Registration Confirmation - " + UserDetails.Name;
                    msg.Body = string.Format(_dbContext.SmsContent.Find("EmailContent").Value, UserDetails.Name);
                    msg.IsBodyHtml = true;
                    msg.Attachments.Add(new Attachment(new MemoryStream(bytes), UserDetails.Name + ".pdf"));

                    SmtpClient client = new SmtpClient
                    {
                        Credentials = new NetworkCredential("info@hitaambrish.com", "Sushant@123"),
                        Port = 25,
                        Host = "relay-hosting.secureserver.net"
                    };
                    client.Send(msg);
                    #endregion

                    Response.Write(pdfDoc);
                    Response.End();
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private byte[] GenerateQrCode(string userRegistrationId)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(_dbContext.SmsContent.Find("QrCodePrefix")?.Value + userRegistrationId, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return BitmapToBytes(qrCode.GetGraphic(20));
        }

        public ActionResult CancelRegistration()
        {
            var viewModel = new MobileVerificationViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CancelRegistration(MobileVerificationViewModel input)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var userDetails = _dbContext.UserResponse5Aug.Find(input.Phone);
            if (userDetails == null)
            {
                return Json(new { Code = 11 }, JsonRequestBehavior.AllowGet); //No seat registered.
            }
            if (userDetails.SeatStatus.Equals("Cancelled"))
            {
                return Json(new { Code = 12 }, JsonRequestBehavior.AllowGet); //registration already cancelled.
            }
            userDetails.SeatStatus = "Cancelled";
            _dbContext.SaveChanges();
            string smsContent = string.Format(_dbContext.SmsContent.Find("Cancelled").Value, userDetails.Name);
            bool smsSent = sendSMS(input.Phone, smsContent);
            return Json(new { Code = 13 }, JsonRequestBehavior.AllowGet);//Seat successfully cancelled.
        }

        public ActionResult EventFeedback()
        {
            var viewModel = new EventFeedbackViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EventFeedback(EventFeedbackViewModel input)
        {
            try
            {
                ApplicationDbContext _dbContext = new ApplicationDbContext();
                var userDetails = _dbContext.UserResponse5Aug.Find(input.Phone);
                if (userDetails == null)
                {
                    return Json(new { Code = 11 }, JsonRequestBehavior.AllowGet); //No seat registered.
                }
                if (userDetails.SeatStatus.Equals("Cancelled"))
                {
                    return Json(new { Code = 12 }, JsonRequestBehavior.AllowGet); //registration already cancelled.
                }

                var isFeedbackFirstTime = _dbContext.Feedback5August.Find(input.Phone) == null;
                if (isFeedbackFirstTime)
                {
                    _dbContext.Feedback5August.Add(input);
                    _dbContext.SaveChanges();
                    string smsContent = string.Format(_dbContext.SmsContent.Find("Feedback").Value, userDetails.Name);
                    bool smsSent = sendSMS(input.Phone, smsContent);
                    return Json(new { Code = 14 }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { Code = 15 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new { Code = 3 }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Questions()
        {
            var viewModel = new QuestionsViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Questions(QuestionsViewModel input)
        {
            try
            {
                ApplicationDbContext _dbContext = new ApplicationDbContext();
                _dbContext.EventQuestionsForm.Add(input);
                _dbContext.SaveChanges();
                return Json(new { Code = 28 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new { Code = 3 }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult SemiFilledForm(UserResponse5Aug input)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var OTP = GenerateOtp(int.Parse(_dbContext.SmsContent.Find("OtpLength").Value));
            string smsTemplate = _dbContext.SmsContent.Find("OTP")?.Value;
            string smsContent = string.Format(smsTemplate, OTP);
            bool smsSent = sendSMS(input.Phone, smsContent);
            return Json(smsSent ? new { OTPCode = OTP } : new { OTPCode = "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SemiFilledForm2(MobileVerificationViewModel input)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var OTP = GenerateOtp(int.Parse(_dbContext.SmsContent.Find("OtpLength").Value));
            string smsTemplate = _dbContext.SmsContent.Find("OTP")?.Value;
            string smsContent = string.Format(smsTemplate, OTP);
            bool smsSent = sendSMS(input.Phone, smsContent);
            return Json(smsSent ? new { OTPCode = OTP } : new { OTPCode = "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SemiFilledForm3(EventFeedbackViewModel input)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var OTP = GenerateOtp(int.Parse(_dbContext.SmsContent.Find("OtpLength").Value));
            string smsTemplate = _dbContext.SmsContent.Find("OTP")?.Value;
            string smsContent = string.Format(smsTemplate, OTP);
            bool smsSent = sendSMS(input.Phone, smsContent);
            return Json(smsSent ? new { OTPCode = OTP } : new { OTPCode = "" }, JsonRequestBehavior.AllowGet);
        }

        public bool sendSMS(string mobile, string sms)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            string URL = _dbContext.SmsContent.Find("smsApiEndpoint").Value;
            var urlToHit = string.Format(URL, mobile, sms);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(urlToHit).Result;  // Blocking call!  
            return response.IsSuccessStatusCode;
        }

        public string getVisualRegistrationId(int id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var prefix = "";
            prefix = dbContext.SmsContent.Find("RegistrationTemplate")?.Value;
            string decimatedId = String.Format("{0:D4}", id);
            return prefix + decimatedId;
        }

        [HttpPost]
        public ActionResult AllowEntry(string Mobile)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var userDetails = _dbContext.UserResponse5Aug.Find(Mobile) ;
            if (userDetails == null)
            {
                return Json(new { Code = 11 }, JsonRequestBehavior.AllowGet); //No seat registered.
            }
            if (userDetails.SeatStatus.Equals("Cancelled"))
            {
                return Json(new { Code = 12 }, JsonRequestBehavior.AllowGet); //registration already cancelled.
            }
            if (userDetails.SeatStatus.Equals("Entered"))
            {
                return Json(new { Code = 17 }, JsonRequestBehavior.AllowGet); //registration already allowed entry.
            }
            userDetails.SeatStatus = "Entered";
            _dbContext.SaveChanges();
            string smsContent = string.Format(_dbContext.SmsContent.Find("EntrySms").Value, userDetails.Name);
            bool smsSent = sendSMS(Mobile, smsContent);
            return Json(new { Code = 18 }, JsonRequestBehavior.AllowGet);//Listener successfully entered.
        }


        [HttpPost]
        public ActionResult AllowEntryFromQR(string mobile)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var userDetails = _dbContext.UserResponse5Aug.Find(mobile);
            if (userDetails == null)
            {
                return Json(new { Code = "11qr" }, JsonRequestBehavior.AllowGet); //No seat registered.
            }
            if (userDetails.SeatStatus.Equals("Cancelled"))
            {
                return Json(new { Code = "12qr" }, JsonRequestBehavior.AllowGet); //registration already cancelled.
            }
            if (userDetails.SeatStatus.Equals("Entered"))
            {
                return Json(new { Code = "17qr" }, JsonRequestBehavior.AllowGet); //registration already allowed entry.
            }
            userDetails.SeatStatus = "Entered";
            _dbContext.SaveChanges();
            string smsContent = string.Format(_dbContext.SmsContent.Find("EntrySms").Value, userDetails.Name);
            bool smsSent = sendSMS(userDetails.Phone, smsContent);
            return Json(new { Code = "18qr" }, JsonRequestBehavior.AllowGet);//Listener successfully entered.
        }

    }

    public class AllowEntryViewModel
    {
        public string Mobile { get; set; }
    }
}
