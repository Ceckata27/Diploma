using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using GameCatalogue.Model;

namespace GameCatalogue.App_Db_Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options)
          : base(options)
        {

        }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
