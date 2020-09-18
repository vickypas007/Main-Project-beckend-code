using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuickPickWebApi.Core.Models
{
   public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        [ForeignKey("InvoiceStatusCodeId")]
        public int InvoiceStatusCodeId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string InvoiceDetal { get; set; }
        public bool IsActive { get; set; }


        [ForeignKey("OrderId")]
        public Orders Orders { get; set; }
        
        [ForeignKey("InvoiceStatusCodeId")]
        public InvoiceStatusCode InvoiceStatusCode { get; set; }

    }
}
