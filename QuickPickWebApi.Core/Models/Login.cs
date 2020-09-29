using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuickPickWebApi.Core.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        public string Password { get; set; }

        [ForeignKey("CustomerId")]
        public int UserId { get; set; }
        public string Jwt { get; set; }
        public DateTime ValidUpto { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime TimeCreated { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime TimeModified { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
