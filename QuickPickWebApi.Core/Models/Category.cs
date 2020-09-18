using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickPickWebApi.Core.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Category_Name { get; set; }

        [ForeignKey("Shop")]
        public int ShopId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

    }
}
