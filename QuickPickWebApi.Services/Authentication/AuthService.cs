using Microsoft.Extensions.Configuration;
using QuickPickWebApi.Core;
using QuickPickWebApi.Core.Infrastructure;
using QuickPickWebApi.Core.Models;
using QuickPickWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace QuickPickWebApi.Services.Authentication
{
    public class AuthService : IAuthServices
    {
        DatabaseContext DbContext { get; }
        IConfiguration configuration { get; }

        public AuthService(DatabaseContext dbContext, IConfiguration Configuration)
        {
            DbContext= dbContext;
            configuration = Configuration;
        }

        private UnitOfWork<DatabaseContext> unitOfWork;

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

        public SignupResponceViewModel UserSignup(SignupViewModel signupViewModel)
        {
            SignupResponceViewModel response = new SignupResponceViewModel();
            var CustomerRepos = UnitOfWork.GetRepository<Customer>();

            var isEmailAlreadyExists = CustomerRepos.Get(predicate: x => x.EmailId == signupViewModel.EmailId);

            if (isEmailAlreadyExists.Count() != 0)
            {
                response.ErrorMessage = "EmailId Already Exist";
                return response;
            }
            else
            {
                try
                {
                    var customer = new Customer
                    {
                        EmailId = signupViewModel.EmailId,
                        Password = signupViewModel.Password,
                        FirstName = signupViewModel.FirstName,
                        MiddleName = signupViewModel.MiddleName,
                        LastName = signupViewModel.LastName,
                        ContactNo = signupViewModel.ContactNo,
                        Gender = signupViewModel.Gender,
                        Address1 = signupViewModel.Address1,
                        Address2 = signupViewModel.Address2,
                        Address3 = signupViewModel.Address3,
                        City = signupViewModel.City,
                        PinCode = signupViewModel.PinCode,
                        State = signupViewModel.State,
                        Country = signupViewModel.Country,
                        TimeCreated = DateTime.Now,
                        IsActive = true,
                    };
                    CustomerRepos.Add(customer);
                    UnitOfWork.SaveChanges();

                    response.id = customer.Id;
                    response.EmailId = customer.EmailId;
                    response.FirstName = customer.FirstName;
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    var StackTrack = e.InnerException.StackTrace;
                    UnitOfWork.RollBack();
                }

                return response;
            }
            
            
        
        }
public ProductDetailsViewModel ProductDetails(int productId){
					ProductDetailsViewModel productDetails = new ProductDetailsViewModel();
					var productRepos = UnitOfWork.GetRepository<Product>();
				  var	product = productRepos.Get(predicate: x=> x.Id == productId).ToList();
					
			for(var i=0;i<product.Count;i++){
				if(product[i].Id != 0){
          productDetails.Id = product[i].Id;
				  productDetails.Product_Name = product[i].Product_Name; 
					productDetails.Product_Color= product[i].Product_Color;
				}
			}
	
					return productDetails;
				}
		}
		}