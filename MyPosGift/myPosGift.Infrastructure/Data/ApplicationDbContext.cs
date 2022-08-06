using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myPosGift.Infrastructure.Data.DateModels;

namespace myPosGift.Infrastructure.Data
{
    public class ApplicationDbContext :IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }


    }
}
