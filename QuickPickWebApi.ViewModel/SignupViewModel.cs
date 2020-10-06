using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuickPickWebApi.ViewModel
{
    public class SignupViewModel
    {
        public int id { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PinCode { get; set; }
    }
    public class SignupResponceViewModel
    {
        public int id { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PinCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
