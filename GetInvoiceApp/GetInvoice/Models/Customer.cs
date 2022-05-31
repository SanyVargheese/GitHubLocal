using System;

namespace GetInvoice.Models
{
    public class Customer
    {

        public int CustomerId { get; set; }


        public string Salutation { get; set; } 

        public string Initials { get; set; } 
        public string FirstName { get; set; }

        public string FirstNameAscii { get; set; }
        public string FirstNameCountryRank { get; set; }
        public string FirstNameCountryFrequency { get; set; }

        public string LastNameAscii { get; set; }
        public string LastNameCountryRank { get; set; }
        public string LastNameCountryFrequency { get; set; }
        public string CountryCodeAlpha { get; set; }



        public string LastName { get; set; } 
        public string Gender { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string CountryName { get; set; } 
        public string CountryCode { get; set; } 
        public string PrimaryLanguage { get; set; } 
        public string PrimaryLanguageCode { get; set; } 
        public double Balance { get; set; } 
        public string PhoneNumber { get; set; }

        public string Currency { get; set; }


    }
}
