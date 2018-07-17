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
                    input.TimeStamp = DateTime.Now;
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
                ApplicationDbContext _dbContext = new ApplicationDbContext();
                UserResponse5Aug UserDetails = _dbContext.UserResponse5Aug.Find(mobile);
                using (MemoryStream memoryStream = new MemoryStream())
                {

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
                    jpgUpper.ScaleAbsoluteHeight(PageSize.A4.Height/3);
                    #endregion

                    #region TextStarts

                    PdfPTable table = new PdfPTable(2);
                    table.DefaultCell.FixedHeight = 25f;
                    table.DefaultCell.Padding = 5f;
                    table.AddCell("Name");
                    table.AddCell(UserDetails.Name);
                    table.AddCell("Date Of Birth");
                    table.AddCell(UserDetails.DateOfBirth.ToString("dd/MM/yyyy"));
                    table.AddCell("City");
                    table.AddCell(UserDetails.City);
                    table.AddCell("Contact No.");
                    table.AddCell(UserDetails.Phone);
                    table.AddCell("Registration Time");
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

                    #endregion




                    ////Create a single column table
                    //var t = new PdfPTable(1);

                    ////Tell it to fill the page horizontally
                    //t.WidthPercentage = 100;

                    ////Create a single cell
                    //var c = new PdfPCell();

                    ////Tell the cell to vertically align in the middle
                    //c.VerticalAlignment = Element.ALIGN_MIDDLE;

                    ////Tell the cell to fill the page vertically
                    //c.MinimumHeight = pdfDoc.PageSize.Height - (pdfDoc.BottomMargin + pdfDoc.TopMargin);

                    ////Create a test paragraph
                    //var p = new Paragraph("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam iaculis sem diam, quis accumsan ipsum venenatis ac. Pellentesque nec gravida tortor. Suspendisse dapibus quis quam sed sollicitudin.");

                    ////Add it a couple of times
                    //c.AddElement(p);
                    //c.AddElement(p);

                    ////Add the cell to the paragraph
                    //t.AddCell(c);

                    ////Add the table to the document
                    //pdfDoc.Add(t);

                    pdfDoc.Close();

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