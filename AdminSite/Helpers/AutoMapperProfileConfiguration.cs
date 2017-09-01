using System;
using AdminSite.Models;
using AutoMapper;
using EntityModel.Entity;

namespace AdminSite.Helpers
{
    public class AutoMapperProfileConfiguration : Profile
    {
		public AutoMapperProfileConfiguration() : this("AdminSite")
		{
		
        }

		protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
		{
            CreateMap<CategoryModel, Category>().ReverseMap();
		}
    }
}
