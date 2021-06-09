using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuickPickWebApi.Core.Models
{
   public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

    }
}
