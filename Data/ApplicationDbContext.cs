using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using muzey.Models;

namespace muzey.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<UsersDB> UsersDB {  get; set; }
        public DbSet<Yslygi> Yslygi { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
