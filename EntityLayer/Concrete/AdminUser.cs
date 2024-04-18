using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AdminUser : IdentityUser<int>
    {
        public string FullName { get; set; }
    }
}
