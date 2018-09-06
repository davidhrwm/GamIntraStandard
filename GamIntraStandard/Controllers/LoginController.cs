using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Clases;
using GamIntraStandard.Common;
using System.Web.Security;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Net;


namespace GamIntraStandard.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _login;

        public LoginController() : this(new CLogin()){ }

        internal LoginController(ILogin login)
        {
            _login = login;

        }

        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }


        // GET: Login
        public ActionResult Index()
        {          
            return View();
        }


        public ActionResult LoginUser(User user)
        {
           var result = _login.VerifyLogin(user.UserId, user.Password);

            if (result == true)
            {
                var identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, user.UserId),
                        },
                        DefaultAuthenticationTypes.ApplicationCookie,
                        ClaimTypes.Name, ClaimTypes.Role);

                identity.AddClaim(new Claim(ClaimTypes.Role, "guest"));

                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, identity);


                _login.SetCookie(user.UserId);

                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Index");                  
        }
    }
}