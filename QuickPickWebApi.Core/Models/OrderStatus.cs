using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace QuickPickWebApi.Core.Models
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }

        public string OrderStatus_Desc { get; set; }
        public bool IsActive { get; set; }
    }
}
