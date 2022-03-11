using ContactsManager.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsManager.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<ContactsManagerDbContext>();

            //var userManager = scopedServices.ServiceProvider.GetService<UserManager<AppUser>>();

            //var roleManager = scopedServices.ServiceProvider.GetService<RoleManager<IdentityRole>>();

            data.Database.Migrate();

            return app;
        }        
    }
}
