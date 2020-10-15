using QuickPickWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickPickWebApi.Services.Authentication
{
   public interface IAuthServices
    {
        SignupResponceViewModel UserSignup(SignupViewModel signupViewModel);
				ProductDetailsViewModel ProductDetails(int productId);
				ProductDetailsViewModel AddProduct(ProductDetailsViewModel productDetailsViewModel);

    }
}
