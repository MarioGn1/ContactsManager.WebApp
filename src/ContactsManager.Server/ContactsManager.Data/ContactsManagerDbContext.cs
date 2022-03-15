using ContactsManager.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Data
{
    public class ContactsManagerDbContext : IdentityDbContext<AppUser>
    {
        public ContactsManagerDbContext(DbContextOptions<ContactsManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
