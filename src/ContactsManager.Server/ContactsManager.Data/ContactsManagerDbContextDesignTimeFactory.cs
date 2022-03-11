using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ContactsManager.Data
{
    public class ContactsManagerDbContextDesignTimeFactory : IDesignTimeDbContextFactory<ContactsManagerDbContext>
    {
        public ContactsManagerDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("datasettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ContactsManagerDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ContactsManagerDbContext(builder.Options);
        }
    }
}
