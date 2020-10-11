// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Arch.EntityFrameworkCore.UnitOfWork;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using QuickPickWebApi.Core;
// using QuickPickWebApi.Services.Authentication;
// using QuickPickWebApi.Services.Products;
// using QuickPickWebApi.ViewModel;

// namespace QuickPick_Web_Api.Controllers
// {
// 	[Route("api/")]
// 	[ApiController]
// 	public class ProductController : ControllerBase
// 	{

// 		IProductServices ProductServices { get; }
// 		DatabaseContext DbContext { get; }

// 		//ILogger Logger { get; }

// 		public ProductController(IProductServices productServices, DatabaseContext context)
// 		{
// 			ProductServices = productServices;
// 			DbContext = context;
// 		}

// 		private UnitOfWork<DatabaseContext> unitOfWork;
// 		/// <summary>
// 		/// UnitOfWork
// 		/// </summary>
// 		public UnitOfWork<DatabaseContext> UnitOfWork
// 		{
// 			get
// 			{
// 				if (unitOfWork == null)
// 				{
// 					unitOfWork = new UnitOfWork<DatabaseContext>(DbContext);
// 				}
// 				return unitOfWork;
// 			}
// 		}

// 		[HttpGet]
// 		[Route("productDetails")]
// 		public ProductDetailsViewModel Register([FromQuery] int productId)
// 		{
// 			return ProductServices.ProductDetails(productId);
// 		}
// 	}
// }
