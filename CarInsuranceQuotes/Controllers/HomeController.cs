using CarInsuranceQuotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceQuotes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayQuote()
        {
            return View();
        }

        public ActionResult Admin()
        {
            using (CarInsuranceQuoteEntities3 db = new CarInsuranceQuoteEntities3())
            {
                var quotes = db.Quotes;
                var displayQuotes = new List<Quote>();
                foreach (var quote in quotes)
                {
                    var displayQuote = new Quote();
                    displayQuote.Id = quote.Id;
                    displayQuote.FirstName = quote.FirstName;
                    displayQuote.LastName = quote.LastName;
                    displayQuote.EmailAddress = quote.EmailAddress;
                    displayQuote.MonthlyRateAmount = quote.MonthlyRateAmount;
                    displayQuotes.Add(displayQuote);
                }
                return View(displayQuotes);
            }
        }

        [HttpPost]
        public ActionResult GetQuote(QuoteData data)
        {
            int monthlyRate = 50;
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(data.DateOfBirth.ToString("yyyyMMdd"));
            int age = (now - dob) / 10000;
            if (age < 25 && age > 17) { monthlyRate += 25; };
            if (age < 18) { monthlyRate += 100; };
            if (age > 100) { monthlyRate += 25; };
            if (data.Gender == true && age < 26) { monthlyRate += 50; };
            if (data.CarYear < 2000) { monthlyRate += 25; };
            if (data.CarYear > 2015) { monthlyRate += 25; };
            if (data.CarMake.ToLower() == "porsche") { monthlyRate += 25; };
            if (data.CarMake.ToLower() == "porsche" && data.CarModel.ToLower() == "911 carrera") { monthlyRate += 25; };
            monthlyRate = monthlyRate + (data.SpeedingTickets * 10);
            if (data.HasHadDui == true) { monthlyRate = Convert.ToInt32(Convert.ToDouble(monthlyRate) * 1.25); };
            if (data.FullCoverage == true) { monthlyRate = Convert.ToInt32(Convert.ToDouble(monthlyRate) * 1.5); };

            using (CarInsuranceQuoteEntities3 db = new CarInsuranceQuoteEntities3())
            {
                Quote quote = new Quote();
                quote.FirstName = data.FirstName;
                quote.LastName = data.LastName;
                quote.EmailAddress = data.EmailAddress;
                quote.MonthlyRateAmount = monthlyRate;

                db.Quotes.Add(quote);
                db.SaveChanges();
            }
            return View("DisplayQuote", monthlyRate);
        }
    }
}