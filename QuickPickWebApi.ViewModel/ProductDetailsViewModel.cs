namespace QuickPickWebApi.ViewModel
{
	 public class ProductDetailsViewModel
    {
			   public int Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Model { get; set; }
      
        public string Product_Available { get; set; }
        public string Product_Description { get; set; }
        public string Product_Color { get; set; }
        public string Product_Size { get; set; }
        public string isActive { get; set; } 
		}
}