using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PragimCourses.Models;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PragimCourses.Controllers.Api
{
    public class AuthonticateController : ApiController
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        private readonly ApplicationDbContext _context;

        public AuthonticateController()
        {
            _context = new ApplicationDbContext();
        }
        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => _userManager = value;
        }
        public ApplicationSignInManager SignInManager
        {
            get => _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            set => _signInManager = value;
        }

        [HttpPost]
        public IHttpActionResult Login(LoginViewModel model)
        {
            var userName =
                 UserManager.FindByEmail(model.Email)?.UserName == null ?
                    UserManager.FindByName(model.Email).UserName :
                    UserManager.FindByEmail(model.Email).UserName;

            var result = SignInManager
                .PasswordSignIn(userName, model.Password,
                    false, shouldLockout: false);

            var response = _context.Users.Where(u => u.UserName == userName || u.Email == userName)
                 .Include(u => u.BillingInfo)
                 .Include(u => u.ShippingInfo)
                 .SingleOrDefault();

            var data = new CheckoutDto()
            {
                Billing = new BillingInfo()
                {
                    Address1 = response.BillingInfo.Address1,
                    Address2 = response.BillingInfo.Address2,
                    Company = response.BillingInfo.Company,
                    City = response.BillingInfo.City,
                    Country = response.BillingInfo.Country,
                    ZipCode = response.BillingInfo.ZipCode
                },
                Shipping = new ShippingInfo()
                {
                    Address1 = response.ShippingInfo.Address1,
                    Address2 = response.ShippingInfo.Address2,
                    Company = response.ShippingInfo.Company,
                    City = response.ShippingInfo.City,
                    Country = response.ShippingInfo.Country,
                    ZipCode = response.ShippingInfo.ZipCode
                },
                User = new ApplicationUser()
                {
                    FirstName = response.FirstName,
                    LastName = response.LastName,
                    UserName = response.UserName,
                    Email = response.Email
                }
            };
            return Ok(data);
        }
    }
}
