using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vend.Data
{
    public class IdContext(DbContextOptions<IdContext> options) : IdentityDbContext<AppUser>(options)
    {
    }

}
