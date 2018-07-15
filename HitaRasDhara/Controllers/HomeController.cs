using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using HitaRasDhara.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace HitaRasDhara.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new UserResponse5Aug();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(UserResponse5Aug input)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                var userDetails = _dbContext.UserResponse5Aug.Find(input.Phone);
                if (userDetails == null)
                {
                    input.SeatStatus = "Registered";
                    _dbContext.UserResponse5Aug.Add(input);
                    _dbContext.SaveChanges();
                    string smsData = string.Format(_dbContext.SmsContent.Find("RegisteredSuccessfully").Value,
                        input.Name);
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

        [HttpPost]
        public byte[] GeneratePDF(string mobile)
        {
            try
            {
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    document.Open();

                    Chunk chunk = new Chunk("This is from chunk." + mobile);
                    document.Add(chunk);

                    Phrase phrase = new Phrase("This is from Phrase.");
                    document.Add(phrase);

                    Paragraph para = new Paragraph("This is from paragraph.");
                    document.Add(para);

                    string text = @"you are successfully created PDF file.";
                    Paragraph paragraph = new Paragraph();
                    paragraph.SpacingBefore = 10;
                    paragraph.SpacingAfter = 10;
                    paragraph.Alignment = Element.ALIGN_LEFT;
                    paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
                    paragraph.Add(text);
                    document.Add(paragraph);
                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";

                    string pdfName = "User";
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

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


        [HttpPost]
        public JsonResult SemiFilledForm(UserResponse5Aug input)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var OTP = GenerateOtp(4);
            string smsTemplate = _dbContext.SmsContent.Find("OTP")?.Value;
            string smsContent = string.Format(smsTemplate, OTP);
            bool smsSent = sendSMS(input.Phone, smsContent);
            return Json(smsSent ? new { OTPCode = OTP } : new { OTPCode = "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SemiFilledForm2(MobileVerificationViewModel input)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var OTP = GenerateOtp(4);
            string smsTemplate = _dbContext.SmsContent.Find("OTP")?.Value;
            string smsContent = string.Format(smsTemplate, OTP);
            bool smsSent = sendSMS(input.Phone, smsContent);
            return Json(smsSent ? new { OTPCode = OTP } : new { OTPCode = "" }, JsonRequestBehavior.AllowGet);
        }

        public bool sendSMS(string mobile, string sms)
        {
            string URL =
                "http://sms.wishsolution.com/Api.aspx?usr=HITRAS&pwd=india123&smstype=TextSMS&to={0}&msg={1}&rout=Transactional&from=HITRAS";
            var urlToHit = string.Format(URL, mobile, sms);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(urlToHit).Result;  // Blocking call!  
            return response.IsSuccessStatusCode;
        }

    }
}