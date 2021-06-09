using QuickPickWebApi.Core.Models;
using QuickPickWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace QuickPickWebApi.Services.ProductServices

{
    public interface IProductService
    {
        public Location AddLocation(Location location);
        public Shop CreateShop(Shop shopView);
        public Category AddCategory(Category category);
        public Products addProduct(Products product);
        public OrderStatus addOrderStatus(OrderStatus orderStatus);

        public List<ShopViewModel> GetShops(HubViewModel viewModel);
        public List<Category> GetCategory();

        public bool EditCategory(Category category);
        public List<Location> GetLocation();

        public bool DeleteLocation(int id);
        public bool DeleteCategory(int id);
    }
}
