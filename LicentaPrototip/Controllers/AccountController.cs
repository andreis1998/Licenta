using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LicentaPrototip.Models;
using LicentaPrototip.Context;
using LicentaPrototip.SqlViews;
using System.Text;

namespace LicentaPrototip.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AppDbContext db = new AppDbContext();

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var hashedPassword = HashPassword(model.Password);
            var account = db.Accounts.FirstOrDefault(x => x.Email == model.Email && x.Password == hashedPassword);
            if (account != null)
            {
                Session["Name"] = account.Surname;
                if (account.IsAdultAccount)
                {
                    Session["Adult"] = bool.TrueString;
                }
                else
                {
                    Session["Adult"] = bool.FalseString;
                }

                if (account.IsAdmin)
                {
                    Session["admin"] = bool.TrueString;
                }
                else
                {
                    Session["admin"] = bool.FalseString;
                }
                return View("../Home/MyHouse");
            }

            ModelState.AddModelError("", "Parolă sau email greșit.");
            return View(model);
        }
      
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(new Accounts
                {
                    AccountId = Guid.NewGuid(),
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    IsAdmin = false,
                    IsAdultAccount = model.IsAdultAccount,
                    Password = HashPassword(model.Password)
                });

                db.SaveChanges();

                return View("../Home/MyHouse");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private string HashPassword(string plainPassword)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder(64);
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));

            foreach (byte Byte in crypto)
            {
                hash.Append(Byte.ToString("x2"));
            }

            return hash.ToString();
        }
        
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            Session["Name"] = null;
            Session["Adult"] = null;
            return RedirectToAction("Index", "Home");
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}