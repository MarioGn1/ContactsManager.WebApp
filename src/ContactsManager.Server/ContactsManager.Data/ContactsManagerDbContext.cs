using ContactsManager.Data.Configurations;
using ContactsManager.Data.Models;
using ContactsManager.Domain.AggregateModel.ContactsAggregate;
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

        public DbSet<Book> Books { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookEntityTypeConfiguration());
            builder.ApplyConfiguration(new ContactEntityTypeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
