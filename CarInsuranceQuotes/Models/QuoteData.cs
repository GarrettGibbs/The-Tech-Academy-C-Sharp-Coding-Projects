using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceQuotes.Models
{
    public class QuoteData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public bool HasHadDui { get; set; }
        public int SpeedingTickets { get; set; }
        public bool FullCoverage { get; set; }
        public bool Gender { get; set; }
    }
}