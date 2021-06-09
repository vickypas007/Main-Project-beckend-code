using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace QuickPickWebApi.Core.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        public string Shop_Name {get; set;}
        public string Shop_Address {get; set;}
        public string Shop_Area {get; set;}
        public string District {get; set;}
        public string State {get; set;}
        public string Shop_Image {get; set;}

        public float Shop_lat { get; set; }
        public float Shop_long { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("CityHubId")]
        public int CityHubId { get; set; }

        //[ForeignKey("LocationId")]
        //public int LocationId { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("CityHubId")]
        public CityHub cityHub  { get; set; }
        //[ForeignKey("LocationId")]
        //public Location Location { get; set; }
    }
}
