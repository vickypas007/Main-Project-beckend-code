using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using QuickPickWebApi.Core;
using QuickPickWebApi.Core.Models;
using QuickPickWebApi.Services.Product;
using QuickPickWebApi.Services.ProductServices;
using QuickPickWebApi.ViewModel;
using System.Net;

namespace QuickPick_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService ProductService { get; }
        DatabaseContext DbContext { get; }
        HttpRequestMessage request = new HttpRequestMessage();
        public  ProductController(IProductService productService, DatabaseContext context)
        {
            DbContext = context;
            ProductService = productService;
        }


        [HttpPost("addlocation")]
        public IActionResult addlocation(Location location)
        {
            var locData = ProductService.AddLocation(location);
            return Ok(locData);
        }


        [HttpPost("createshop")]
        public IActionResult CreateShop(Shop shop)
        {
           var shopData= ProductService.CreateShop(shop);
            return Ok(shopData);
        }

        [HttpPost("addcategory")]
        public IActionResult addCategory(Category category)
        {
            var Catdata= ProductService.AddCategory(category);
            return Ok(Catdata);
        }

        [HttpPut("editcategory")]
        public bool EditCategory(Category category)
        {
            return ProductService.EditCategory(category); 
        }

        [HttpDelete("deletecategory")]
        public bool DeleteCategory(int id)
        {

            return ProductService.DeleteCategory(id);
        }

        [HttpPost("addproduct")]
        public IActionResult addProduct(Products product)
        {
            var productData = ProductService.addProduct(product);
            return Ok(productData);
        }

        [HttpPost("addorderstatus")]
        public IActionResult addorderstatus(OrderStatus orderStatus)
        {
            var orderstatus = ProductService.addOrderStatus(orderStatus);
            return Ok(orderstatus);
        }

        //-------------------------------------- Get Method ---------------------------------------------------
        [HttpGet("getlocation")]
        public List<Location> GetLocation()
        {
            var getLocation = ProductService.GetLocation();
            return getLocation;
        }

        [HttpDelete("deletelocation")]
        public bool DeleteLocation(int id)
        {
           
             return ProductService.DeleteLocation(id);
        }

        [HttpGet("getshop")]
        public List<ShopViewModel> GetShops(HubViewModel viewModel)
        {
            var getData = ProductService.GetShops(viewModel);
            return (getData);
        }

        [HttpGet("getcategory")]
        public List<Category> GetCategory()
        {
            var getCat = ProductService.GetCategory();
            return getCat;
        }

    }
}