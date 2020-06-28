using PragimCourses.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace PragimCourses.Controllers.Api
{
    public class CheckoutController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CheckoutController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Checkout(CheckoutDto dto)
        {
            var user = _context.Users
                .Include(u => u.BillingInfo)
                .Include(u => u.ShippingInfo)
                .FirstOrDefault(u => u.Email.ToLower() == dto.User.Email.ToLower()
                                     || u.UserName.ToLower() == dto.User.UserName);


            if (user != null)
            {
                if (string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.LastName))
                {
                    user.FirstName = dto.User.FirstName;
                    user.LastName = dto.User.LastName;
                }
                dto.User = user;
            }

            if (string.IsNullOrEmpty(dto.Shipping.Address1))
            {
                dto.Shipping = new ShippingInfo()
                {
                    Address1 = dto.Billing.Address1,
                    Address2 = dto.Billing.Address2,
                    Company = dto.Billing.Company,
                    City = dto.Billing.City,
                    Country = dto.Billing.Country,
                    ZipCode = dto.Billing.ZipCode,
                    User = dto.User
                };
            }

            if (user != null && user.BillingInfo != null)
            {

                user.BillingInfo.Address1 = dto.Billing.Address1;
                user.BillingInfo.Address2 = dto.Billing.Address2;
                user.BillingInfo.City = dto.Billing.City;
                user.BillingInfo.Country = dto.Billing.Country;
                user.BillingInfo.Company = dto.Billing.Company;
                user.BillingInfo.ZipCode = dto.Billing.ZipCode;

                user.ShippingInfo.Address1 = dto.Shipping.Address1;
                user.ShippingInfo.Address2 = dto.Shipping.Address2;
                user.ShippingInfo.City = dto.Shipping.City;
                user.ShippingInfo.Country = dto.Shipping.Country;
                user.ShippingInfo.Company = dto.Shipping.Company;
                user.ShippingInfo.ZipCode = dto.Shipping.ZipCode;

            }
            else
            {
                dto.Billing.User = dto.User;
                _context.BillingInfos.Add(dto.Billing);

                _context.ShippingInfos.Add(dto.Shipping);
            }
            _context.SaveChanges();

            var data = new CheckoutDto()
            {
                Billing = new BillingInfo()
                {
                    Address1 = dto.Billing.Address1,
                    Address2 = dto.Billing.Address2,
                    Company = dto.Billing.Company,
                    City = dto.Billing.City,
                    Country = dto.Billing.Country,
                    ZipCode = dto.Billing.ZipCode
                },
                Shipping = new ShippingInfo()
                {
                    Address1 = dto.Shipping.Address1,
                    Address2 = dto.Shipping.Address2,
                    Company = dto.Shipping.Company,
                    City = dto.Shipping.City,
                    Country = dto.Shipping.Country,
                    ZipCode = dto.Shipping.ZipCode
                },
                User = new ApplicationUser()
                {
                    FirstName = dto.User.FirstName,
                    LastName = dto.User.LastName,
                    UserName = dto.User.UserName,
                    Email = dto.User.Email
                }
            };

            return Ok(data);
        }
    }

    public class CheckoutDto
    {
        public BillingInfo Billing { get; set; }
        public ShippingInfo Shipping { get; set; }
        public ApplicationUser User { get; set; }
    }
}
