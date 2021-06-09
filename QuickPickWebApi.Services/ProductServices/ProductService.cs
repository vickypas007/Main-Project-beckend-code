using AutoMapper.QueryableExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using QuickPickWebApi.Core;
using QuickPickWebApi.Core.Infrastructure;
using QuickPickWebApi.Core.Models;
using QuickPickWebApi.Services.ProductServices;
using QuickPickWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;

namespace QuickPickWebApi.Services.Product
{
    public class ProductService : IProductService
    {
       
        DatabaseContext _context { get; }
        private IConfiguration _config;
        public ProductService(DatabaseContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        private UnitOfWork<DatabaseContext> unitOfWork;

        public UnitOfWork<DatabaseContext> UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    unitOfWork = new UnitOfWork<DatabaseContext>(_context);
                }
                return unitOfWork;
            }
        }

        //Add Location
        public Location AddLocation(Location location)
        {
            var locationRepos = UnitOfWork.GetRepository<Location>();
            try
            {
                var loc = new Location
                {
                    lati = location.lati,
                    longi = location.longi,
                    locality = location.locality,
                    pincode = location.pincode,
                    administrativeArea = location.administrativeArea,
                    subAdministrativeArea = location.subAdministrativeArea,
                    
                };
                locationRepos.Add(loc);
                unitOfWork.SaveChanges();
                location.Id = loc.Id;
                
            }
            catch (Exception e)
            {
                var msg = e.Message;
                var StackTrack = e.InnerException.StackTrace;
                unitOfWork.RollBack();
            }
            return location;
        }
        // create Category
        public Category AddCategory(Category category)
        {
            try
            {
                var catgoryRepo = UnitOfWork.GetRepository<Category>();
                var cat = new Category
                {
                    Category_Name = category.Category_Name,
                    Description = category.Description,
                    IsActive = true,
                };
                catgoryRepo.Add(cat);
                unitOfWork.SaveChanges();

                category.Id = cat.Id;
                category.IsActive = cat.IsActive;
            }
            catch (Exception e)
            {
                var msg = e.Message;
                var StackTrack = e.InnerException.StackTrace;
                unitOfWork.RollBack();
            }
            return category;
        }

        //CreateShop
        public Shop CreateShop(Shop shopView)
        {
            var imagePath = _config.GetValue<string>("Path:ImagePath");
            var shopRepos = UnitOfWork.GetRepository<Shop>();
            try
            {
                var shop = new Shop
                {
                    Shop_Name = shopView.Shop_Name,
                    //Location = shopView.Location,
                    //LocationId = shopView.LocationId,
                    Shop_Address = shopView.Shop_Address,
                    Shop_Area = shopView.Shop_Area,
                    District = shopView.District,
                    State = shopView.State,
                    Shop_Image = imagePath + shopView.Shop_Image,
                    CategoryId = shopView.CategoryId,
                    IsActive = true
                };
                shopRepos.Add(shop);
                unitOfWork.SaveChanges();
                shopView.Id = shop.Id;
                shopView.IsActive = shop.IsActive;
            }
            catch (Exception e)
            {
                var msg = e.Message;
                var StackTrack = e.InnerException.StackTrace;
                unitOfWork.RollBack();

            }

            return shopView;
        }

        //addProduct
        public Products addProduct(Products product)
        {
            var productRepos = UnitOfWork.GetRepository<Products>();
            try
            {
                var imagePath = _config.GetValue<string>("Path:ImagePath");
                var prod = new Products
                {
                    Product_Name = product.Product_Name,
                    Product_Description = product.Product_Description,
                    Product_Price = product.Product_Price,
                    Product_Model = product.Product_Model,
                    Product_Available = product.Product_Available,
                    Product_Color = product.Product_Color,
                    Product_Size = product.Product_Size,
                    ProductAvlCount = product.ProductAvlCount,
                    ShopId = product.ShopId,
                    TaxRateId = product.TaxRateId,
                    Product_Image = imagePath + product.Product_Image,
                    IsActive = true
                };
                productRepos.Add(prod);
                unitOfWork.SaveChanges();
                product.Id = prod.Id;
                product.IsActive = prod.IsActive;
            }
            catch (Exception e)
            {
                var msg = e.Message;
                var StackTrack = e.InnerException.StackTrace;
                unitOfWork.RollBack();

            }
            return product;
        }

        //add OrderStatus

        public OrderStatus addOrderStatus(OrderStatus orderStatus)
        {
            var OrderStatusRepos = UnitOfWork.GetRepository<OrderStatus>();
            try
            {
                var orderStatus1 = new OrderStatus
                {
                    OrderStatus_Desc = orderStatus.OrderStatus_Desc,
                    IsActive = true
                };
                OrderStatusRepos.Add(orderStatus1);
                unitOfWork.SaveChanges();
                orderStatus.Id = orderStatus1.Id;
                orderStatus.OrderStatus_Desc = orderStatus1.OrderStatus_Desc;
            }
            catch (Exception e)
            {
                var msg = e.Message;
                var StackTrack = e.InnerException.StackTrace;
                unitOfWork.RollBack();
            }
            return orderStatus;
        }


        //GetProduct
        public List<ShopViewModel> GetShops(HubViewModel viewModel)
        {
             
            ShopViewModel shopViewModel = new ShopViewModel();
            List<ShopViewModel> shopList = new List<ShopViewModel>();

            var shopRepos = UnitOfWork.GetRepository<Shop>();
            var cityHubRepos = UnitOfWork.GetRepository<CityHub>();

            var hubid = cityHubRepos.Get(predicate: x => x.HubName == viewModel.locality && x.CityName == viewModel.cityNane)
                .Select(x => x.Id).FirstOrDefault();

            if(hubid > 0)
            {
                var shopData = shopRepos.Get(predicate: x => x.CityHubId == hubid).ToList();

                foreach (var shop in shopData)
                {
                    shopViewModel.Shop_Name = shop.Shop_Name;
                    shopViewModel.Shop_Area = shop.Shop_Area;
                    shopViewModel.ShopId = shop.Id;
                    shopViewModel.Shop_Address = shop.Shop_Address;
                    shopViewModel.Shop_Image = shop.Shop_Image;
                    shopViewModel.State = shop.State;
                    shopViewModel.City = shop.District;
                    shopViewModel.Shop_lat = shop.Shop_lat;
                    shopViewModel.Shop_long = shop.Shop_long;
                    shopViewModel.CategoryId = shop.CategoryId;
                    shopViewModel.CityHubId = shop.CityHubId;
                    shopViewModel.IsActive = shop.IsActive;

                    shopList.Add(shopViewModel);
                }
            
            }
            else
            {
               
                var localityName = new MySqlParameter("@localityName", viewModel.locality);
                var cityName = new MySqlParameter("@cityName", viewModel.cityNane);
                var locality = viewModel.locality;
                var result =  cityHubRepos.FromSql("CALL ShopSearch(@localityName,@cityName)", parameters: new[] { localityName, cityName })
              .ToList();
                

              //  .FromSqlRaw("CALL InsertDepartments(@DName,@DLoc)", parameters: new[] { deptName, deptLoc })
              //.ToList();
                if (result.Count > 0)
                {
                    var shopData1 = shopRepos.Get(predicate: x => x.CityHubId == result[0].Id).ToList();

                    foreach (var shop in shopData1)
                    {
                        shopViewModel.Shop_Name = shop.Shop_Name;
                        shopViewModel.Shop_Area = shop.Shop_Area;
                        shopViewModel.ShopId = shop.Id;
                        shopViewModel.Shop_Address = shop.Shop_Address;
                        shopViewModel.Shop_Image = shop.Shop_Image;
                        shopViewModel.State = shop.State;
                        shopViewModel.City = shop.District;
                        shopViewModel.Shop_lat = shop.Shop_lat;
                        shopViewModel.Shop_long = shop.Shop_long;
                        shopViewModel.CategoryId = shop.CategoryId;
                        shopViewModel.CityHubId = shop.CityHubId;
                        shopViewModel.IsActive = shop.IsActive;

                        shopList.Add(shopViewModel);
                    }
                    return shopList;
                }
                else
                {
                    return null;
                }

            }


            return shopList;

        }

        public List<Location> GetLocation()
        {
            var locationRepos = UnitOfWork.GetRepository<Location>();
            var getdata = locationRepos.GetAllList();
            return getdata;


        }
        public bool DeleteLocation(int id)
        {
            try
            {
                var locRepos = UnitOfWork.GetRepository<Location>();
                var tempData = locRepos.Get(predicate: x => x.Id == id).ToList();
                if(tempData.Count > 0)
                {
                    locRepos.Delete(tempData);
                    unitOfWork.SaveChanges();
                   
                }
                else
                {
                    return false;
                }
                
            }
            catch(Exception e)
            {
                var msg = e.Message;
                var StackTrack = e.InnerException.StackTrace;
                unitOfWork.RollBack();
                return false;
            }

            return true;

        }
        public List<Category> GetCategory()
        {
            var categoryRepos = UnitOfWork.GetRepository<Category>();
            var getCatdat = categoryRepos.GetAllList();
            return getCatdat;

        }

        public bool EditCategory(Category category)
        {
            try
            {
                var catRepos = UnitOfWork.GetRepository<Category>();
                var catList = catRepos.Get(predicate: x => x.Id == category.Id && x.IsActive).FirstOrDefault();

                if (catList != null)
                {
                    catList.Category_Name = category.Category_Name;
                    catList.Description = category.Description;
                    catList.IsActive = true;

                    catRepos.Update(catList);
                    unitOfWork.SaveChanges();
                }
                else
                    return false;
                

            }catch(Exception e)
            {
                var msg = e.Message;
                var StackTrack = e.InnerException.StackTrace;
                unitOfWork.RollBack();
                return false;
            }

            return true;
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                var catRepos = UnitOfWork.GetRepository<Category>();
                var tempData = catRepos.Get(predicate: x => x.Id == id).ToList();
                if (tempData.Count > 0)
                {
                    catRepos.Delete(tempData);
                    unitOfWork.SaveChanges();

                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                var msg = e.Message;
                var StackTrack = e.InnerException.StackTrace;
                unitOfWork.RollBack();
                return false;
            }

            return true;

        }

        
    }
}
