using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuickPickWebApi.Core.Models
{
   public class ShopCategory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        [ForeignKey("ShopId")]
        public int ShopId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

    }
}
