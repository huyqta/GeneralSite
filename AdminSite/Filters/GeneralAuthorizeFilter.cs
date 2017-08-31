using System;
using EntityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminSite.Filters
{
    public class GeneralAuthorizeAttribute : ActionFilterAttribute
    {
		private readonly GeneralContext _context;

		public GeneralAuthorizeAttribute(GeneralContext context)
		{
            //GeneralContextFactory.Create(Configuration.GetConnectionString("DefaultConnection"));
			_context = context;
		}


        public bool CustomAuthorize(HttpContext httpContext)
        {
            if (!string.IsNullOrEmpty(httpContext.Session.GetString(Helpers.AuthenticationHelper.SessionLogin)))
            {
                return false;
            }
            else{
                return true;
            }
        }
    }
}
