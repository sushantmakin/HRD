﻿using System;
using System.IO;
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

namespace HitaRasDhara.Controllers
{
    public class TalkController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Register","Talk");
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
                        input.Name, getVisualRegistrationId(UpdatedUserDetails.RegistrationID),input.YearOfBirth);
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

        //[HttpPost]
        public byte[] GeneratePDF(string mobile)
        {
            try
            {
                ApplicationDbContext _dbContext = new ApplicationDbContext();
                UserResponse5Aug UserDetails = _dbContext.UserResponse5Aug.Find(mobile);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    //We'll dump our PDF into these when done
                    Byte[] bytes;

                    #region documentDefinitionStart
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    Response.ContentType = "application/pdf";
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    Response.AddHeader("content-disposition", "attachment;filename=test.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    #endregion

                    #region ImageHeaderStart
                    string imageFilePath = Server.MapPath("~") + "/form-bg-Upper.jpg";
                    Image jpgUpper = Image.GetInstance(imageFilePath);
                    jpgUpper.ScaleAbsoluteWidth(PageSize.A4.Width);
                    jpgUpper.ScaleAbsoluteHeight(PageSize.A4.Height / 3);
                    #endregion

                    #region TextStarts

                    PdfPTable table = new PdfPTable(2);
                    table.DefaultCell.FixedHeight = 25f;
                    table.DefaultCell.Padding = 5f;
                    table.AddCell("Registration Number");
                    table.AddCell(getVisualRegistrationId(UserDetails.RegistrationID));
                    table.AddCell("Name");
                    table.AddCell(UserDetails.Name);
                    table.AddCell("Year Of Birth");
                    table.AddCell(UserDetails.YearOfBirth);
                    table.AddCell("City");
                    table.AddCell(UserDetails.City);
                    table.AddCell("Contact No.");
                    table.AddCell(UserDetails.Phone);
                    table.AddCell("Registration Date & Time");
                    table.AddCell(UserDetails.TimeStamp.ToString());

                    #endregion

                    #region ImageLowerStart
                    string imageFilePathLower = Server.MapPath("~") + "/form-bg-Lower.jpg";
                    Image jpgLower = Image.GetInstance(imageFilePathLower);
                    jpgLower.ScaleAbsoluteWidth(PageSize.A4.Width);
                    jpgLower.ScaleAbsoluteHeight(PageSize.A4.Height / 3);
                    jpgLower.Alignment = Image.UNDERLYING;
                    #endregion

                    #region build
                    pdfDoc.Open();
                    pdfDoc.NewPage();
                    pdfDoc.Add(jpgUpper);
                    pdfDoc.Add(table);
                    pdfDoc.Add(jpgLower);
                    pdfDoc.Close();
                    //Finalize the contents of the stream into an array
                    bytes = memoryStream.ToArray();
                    #endregion

                    #region email
                    MailMessage msg = new MailMessage();
                    msg.To.Add(new MailAddress(UserDetails.Email));
                    msg.From = new MailAddress("info@hitaambrish.com", "Hita Ambrish");
                    msg.Subject = "Registration Confirmation - " + UserDetails.Name;
                    msg.Body = "<p>Dear " + UserDetails.Name + " ,</p> <p>Thank you for your interest in 'Think HIGHER, Drill DEEPER, Be STRONGER' - A talk by Hita Ambrish Ji designed especially for the youth.</p> <p> Your registration is <u>confirmed</u> and your entry pass is attached with this email.</p> <p> Please note that entry would only be allowed only on presenting this entry pass along with a valid government-issued ID-Card. It is our kind request that you strictly adhere to the instructions mentioned in the entry pass, to ensure your entry in the auditorium.</p><p> Thanks <br/> Team Hita Ras Dhara </p> ";
                    msg.IsBodyHtml = true;
                    msg.Attachments.Add(new Attachment(new MemoryStream(bytes), UserDetails.Name + ".pdf"));

                    SmtpClient client = new SmtpClient();
                    client.Credentials = new NetworkCredential("info@hitaambrish.com", "Sushant@123");
                    client.Port = 25;
                    client.Host = "relay-hosting.secureserver.net";
                    client.Send(msg);
                    #endregion

                    Response.Write(pdfDoc);
                    Response.End();
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

        [HttpPost]
        public JsonResult SemiFilledForm3(EventFeedbackViewModel input)
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
                "http://sms.wishsolution.com/Api.aspx?usr=HITRASAPI&pwd=india123&smstype=TextSMS&to={0}&msg={1}&rout=Transactional&from=HITRAS";
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
            string decimatedId =String.Format("{0:D4}", id);
            return prefix + decimatedId;
        }

        [HttpPost]
        public ActionResult AllowEntry(string Mobile)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            var userDetails = _dbContext.UserResponse5Aug.Find(Mobile);
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

    }

    public class AllowEntryViewModel
    {
        public string Mobile { get; set; }
    }
}
