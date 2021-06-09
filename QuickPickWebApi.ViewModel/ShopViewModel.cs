using QuickPickWebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickPickWebApi.ViewModel
{
   public class ShopViewModel
    {
        public int ShopId { get; set; }
        public string Shop_Name { get; set; }
        public string Shop_Address { get; set; }
        public string Shop_Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Shop_Image { get; set; }
        public float Shop_lat { get; set; }
        public float Shop_long { get; set; }
        public int CityHubId { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }

    public class CategoriesResponceMOdel
    {
        public string Category_Name { get; set; }
        public int ShopId { get; set; }
    }

    public class ProductViewModel
    {
        public string Product_Name { get; set; }
        public string Product_Model { get; set; }
        public string Product_Price { get; set; } 
        public bool Product_Available { get; set; }
        public string Product_Description { get; set; }
        public string Product_Color { get; set; }
        public string Product_Size { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class HubViewModel
    {
        public string locality { get; set; }
        public string cityNane { get; set; }

    }
}
