using AutoMapper;
using QuickPickWebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickPickWebApi.ViewModel
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, SignupViewModel>().ReverseMap();
          
        }
    }
}
