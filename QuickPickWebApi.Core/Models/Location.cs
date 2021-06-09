using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace QuickPickWebApi.Core.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public double lati { get; set; }
        public double longi { get; set; }
        // public string  AreaName { get; set; }
        public int pincode { get; set; }
        public string locality { get; set; }
        public string subAdministrativeArea { get; set; }
        public string administrativeArea { get; set; }

    }
}
