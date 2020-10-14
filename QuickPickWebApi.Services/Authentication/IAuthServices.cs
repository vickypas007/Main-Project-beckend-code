using QuickPickWebApi.Core.Models;
using QuickPickWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuickPickWebApi.Services.Authentication
{
   public interface IAuthServices
    {
        //SignupResponceViewModel UserSignup(SignupViewModel signupViewModel);
        Task<Customer> Register(Customer user, string password);
        Task<Customer> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
