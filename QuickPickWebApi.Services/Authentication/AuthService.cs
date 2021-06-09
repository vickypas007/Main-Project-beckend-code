using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
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
using System.Threading.Tasks;

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

        //public SignupResponceViewModel UserSignup(SignupViewModel signupViewModel)
        //{
        //    SignupResponceViewModel response = new SignupResponceViewModel();
        //    var CustomerRepos = UnitOfWork.GetRepository<Customer>();

        //    var isEmailAlreadyExists = CustomerRepos.Get(predicate: x => x.EmailId == signupViewModel.EmailId);

        //    if (isEmailAlreadyExists.Count() != 0)
        //    {
        //        response.ErrorMessage = "EmailId Already Exist";
        //        return response;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            var customer = new Customer
        //            {
        //                EmailId = signupViewModel.EmailId,
        //                Password = signupViewModel.Password,
        //                FirstName = signupViewModel.FirstName,
        //                MiddleName = signupViewModel.MiddleName,
        //                LastName = signupViewModel.LastName,
        //                ContactNo = signupViewModel.ContactNo,
        //                Gender = signupViewModel.Gender,
        //                Address1 = signupViewModel.Address1,
        //                Address2 = signupViewModel.Address2,
        //                Address3 = signupViewModel.Address3,
        //                City = signupViewModel.City,
        //                PinCode = signupViewModel.PinCode,
        //                State = signupViewModel.State,
        //                Country = signupViewModel.Country,
        //                TimeCreated = DateTime.Now,
        //                IsActive = true,
        //            };
        //            CustomerRepos.Add(customer);
        //            UnitOfWork.SaveChanges();

        //            response.id = customer.Id;
        //            response.EmailId = customer.EmailId;
        //            response.FirstName = customer.FirstName;
        //        }
        //        catch (Exception e)
        //        {
        //            var msg = e.Message;
        //            var StackTrack = e.InnerException.StackTrace;
        //            UnitOfWork.RollBack();
        //        }

        //        return response;
        //    }



        //}

        public async Task<Customer> Register(Customer user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.TimeCreated = DateTime.Now;
            user.IsActive = true;
            await DbContext.Customers.AddAsync(user);
            UnitOfWork.SaveChanges();
            if(user.EmailId != "" || user.EmailId != null)
            {

            }
            UnitOfWork.Commit();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<Customer> Login(string username, string password)
        {
            var user = await DbContext.Customers.FirstOrDefaultAsync(x => x.EmailId == username ||  x.ContactNo == username);
            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return  user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public async Task<bool> UserExists(string username)
        {
            if (await DbContext.Customers.AnyAsync(x => x.EmailId == username || x.ContactNo == username))
            {
                return true;
            }
            return false;
        }
    }
}
