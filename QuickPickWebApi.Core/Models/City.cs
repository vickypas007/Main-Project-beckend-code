using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuickPickWebApi.Core.Models
{
    public class City
    {
        public int Id { get; set; }

        public string CityName { get; set; }
        public string StateName { get; set; }

        [ForeignKey("StateId")]
        public int StateId { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

    }
}
