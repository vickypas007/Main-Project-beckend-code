using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuickPickWebApi.Core.Models
{
    public class InvoiceStatusCode
    {
        [Key]
        public int Id { get; set; }

        public string InvoiceStaus_Desc { get; set; }
        public bool IsActive { get; set; }
    }
}
