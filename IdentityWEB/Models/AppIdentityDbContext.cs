using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityWEB.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        //IdentityDbContext ten miras alıyoruz. hangi sısnıfı kullanıtyoruz AppUser

        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> option) : base(option)
        {

        }
    }
}
