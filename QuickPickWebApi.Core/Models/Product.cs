using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuickPickWebApi.Core.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Model { get; set; }
        public string Product_Price { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public bool Product_Available { get; set; }
        public string Product_Description { get; set; }
        public string Product_Color { get; set; }
        public string Product_Size { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
