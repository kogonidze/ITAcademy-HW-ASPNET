using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using AutoMapper;
using EducationalCenter.SL;
using Microsoft.EntityFrameworkCore;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF;
using EducationalCenter.BLL.Mappings;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.DataAccess.EF.Interfaces;
using EducationalCenter.DataAccess.EF.Repositories;
using EducationalCenter.BLL.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EducationalCenter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<EducationalCenterContext>
                (options => options.UseSqlServer("Server=localhost;Database=EducationalCenterDb;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddEntityFrameworkStores<EducationalCenterContext>()
                .AddDefaultTokenProviders();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = new Mapper(config);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentGroupService, StudentGroupService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentGroupRepository, StudentGroupRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            CreateRoles(serviceProvider).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "admin", "manager", "student" };

            foreach (var rolename in roles)
            {
                await roleManager.CreateAsync(new IdentityRole()
                {
                    Name = rolename,
                    NormalizedName = rolename.ToUpper()
                });
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var adminUser = await userManager.FindByEmailAsync(Configuration["AdminUserEmail"]);

            if (adminUser != null)
            {
                await userManager.AddToRoleAsync(adminUser, "admin");
            }

            var managerUser = await userManager.FindByEmailAsync(Configuration["ManagerUserEmail"]);

            if (managerUser != null)
            {
                await userManager.AddToRoleAsync(managerUser, "manager");
            }
        }
    }
}
