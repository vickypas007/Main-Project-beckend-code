// using Microsoft.Extensions.Configuration;
// using QuickPickWebApi.Core;
// using QuickPickWebApi.Core.Infrastructure;
// using QuickPickWebApi.Core.Models;
// using QuickPickWebApi.ViewModel;
// using System.Linq;
// 	namespace QuickPickWebApi.Services.Products
// {
//     public class ProductService : IProductServices
//     {
// 			  DatabaseContext DbContext { get; }
//         IConfiguration configuration { get; }

//         public ProductService(DatabaseContext dbContext, IConfiguration Configuration)
//         {
//             DbContext= dbContext;
//             configuration = Configuration;
//         }

//         private UnitOfWork<DatabaseContext> unitOfWork;

//         public UnitOfWork<DatabaseContext> UnitOfWork
//         {
//             get
//             {
//                 if (unitOfWork == null)
//                 {
//                     unitOfWork = new UnitOfWork<DatabaseContext>(DbContext);
//                 }
//                 return unitOfWork;
//             }
//         }
// 	public ProductDetailsViewModel ProductDetails(int productId){
// 					ProductDetailsViewModel productDetails = new ProductDetailsViewModel();
// 					var productRepos = UnitOfWork.GetRepository<Product>();
// 				  var	product = productRepos.Get(predicate: x=> x.Id == productId).ToList();
					
// 			for(var i=0;i<product.Count;i++){
// 				if(product[i].Id != 0){
//           productDetails.Id = product[i].Id;
// 				  productDetails.Product_Name = product[i].Product_Name; 
// 					productDetails.Product_Color= product[i].Product_Color;
// 				}
// 			}
	
// 					return productDetails;
// 				}
// 		}

//     }