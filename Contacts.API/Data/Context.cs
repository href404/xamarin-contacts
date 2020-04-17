using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}