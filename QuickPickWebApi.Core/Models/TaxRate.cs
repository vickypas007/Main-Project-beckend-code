
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuickPickWebApi.Core.Models
{
   public class TaxRate
    {
        [Key]
        public int Id { get; set; }

        public float TaxPrice { get; set; }
        public string TaxDescription { get; set; }

        public bool isActive { get; set; }
    }
}
