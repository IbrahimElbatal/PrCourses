namespace PragimCourses.Models
{
    public class ShippingInfo
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string ZipCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ApplicationUser User { get; set; }

    }
}