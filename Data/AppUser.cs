using Microsoft.AspNetCore.Identity;

namespace Vend.Data
{
    public class AppUser : IdentityUser
    {
        
        public int? TenantId { get; set; }
    }
}