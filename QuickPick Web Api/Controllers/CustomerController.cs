using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickPickWebApi.Core;
using QuickPickWebApi.Services.Authentication;
using QuickPickWebApi.ViewModel;

namespace QuickPick_Web_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{

		IAuthServices AuthServices { get; }

		DatabaseContext DbContext { get; }

		//ILogger Logger { get; }

		public CustomerController(IAuthServices authServices, DatabaseContext context)
		{
			AuthServices = authServices;
			DbContext = context;
		}

		private UnitOfWork<DatabaseContext> unitOfWork;
		/// <summary>
		/// UnitOfWork
		/// </summary>
		public UnitOfWork<DatabaseContext> UnitOfWork
		{
			get
			{
				if (unitOfWork == null)
				{
					unitOfWork = new UnitOfWork<DatabaseContext>(DbContext);
				}
				return unitOfWork;
			}
		}

		[HttpPost("signup")]
		public SignupResponceViewModel Register([FromBody] SignupViewModel signupView)
		{
			return AuthServices.UserSignup(signupView);
		}

		[HttpGet]

		public string Get()
		{
			return "one Api";
		}

	[HttpGet]
		[Route("getProductDetails")]
		public ProductDetailsViewModel Register([FromQuery] int productId)
		{
			return AuthServices.ProductDetails(productId);
		}

			[HttpPost("postProductDetails")]
		public ProductDetailsViewModel Register([FromBody] ProductDetailsViewModel postProductDetails)
		{
			return AuthServices.AddProduct(postProductDetails);
		}

	}
}