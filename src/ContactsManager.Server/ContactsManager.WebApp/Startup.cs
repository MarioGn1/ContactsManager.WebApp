using ContactsManager.Application.Commands;
using ContactsManager.Application.Commands.AddContact;
using ContactsManager.Application.Commands.DeleteContact;
using ContactsManager.Application.Commands.UpdateContact;
using ContactsManager.Application.Interfaces.Commands;
using ContactsManager.Application.Interfaces.Queries;
using ContactsManager.Application.Queries;
using ContactsManager.Application.Queries.GetById;
using ContactsManager.Application.Queries.GetByName;
using ContactsManager.Data;
using ContactsManager.Data.Models;
using ContactsManager.WebApp.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContactsManager.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<ContactsManagerDbContext>(options => options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<AppUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ContactsManagerDbContext>();

            services
                .AddDatabaseDeveloperPageExceptionFilter();

            services
                .AddCors()
                .AddJwtAuthentication(Configuration)
                .AddControllers();

            //Add Commnad Handlers
            services
                .AddScoped<ICommandHandler<AddContactCommand>, AddContactCommandHandler>()
                .AddScoped<ICommandHandler<DeleteContactCommand>, DeleteContactCommandHandler>()
                .AddScoped<ICommandHandler<UpdateContactCommand>, UpdateContactCommandHandler>();


            //Add Query Handlers
            services
                .AddScoped<IQueryHandler<GetByNameQuery>, GetByNameQueryHandler>()
                .AddScoped<ISingleResultQueryHandler<GetByIdQuery>, GetByIdQueryHandler>();

            //Add Dispatchers
            services
                .AddScoped<ICommandDispatcher, CommandDispatcher>()
                .AddScoped<IQueryDispatcher, QueryDispatcher>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
