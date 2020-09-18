using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace QuickPickWebApi.Core.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        public string Shop_Name {get; set;}
        public bool IsActive { get; set; }
    }
}
