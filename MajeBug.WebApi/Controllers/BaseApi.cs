using MajeBug.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace MajeBug.WebApi.Controllers
{
    public class BaseApi : ApiController
    {

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager { get {
                _userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                return _userManager;
            } }

        public ApplicationUser CurrentUser { get
            {
                //get user session
                var claims = User as ClaimsPrincipal;
                var claimsThatContentsTheId = claims.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier);
                if (claimsThatContentsTheId.Count() > 0)
                {
                    var userId = claimsThatContentsTheId.SingleOrDefault().Value;
                    //query in UserManager
                    var user = UserManager.FindById(userId);
                    return user;
                }
                return null;
            }
        }

        public string CurrentUserId { get
            {
                return CurrentUser != null ? CurrentUser.Id : null;
            }
        }
    }
}