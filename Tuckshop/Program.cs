using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Writers;
using Tuckshop.Areas.Identity.Data;
namespace Tuckshop
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);


            var connectionString = builder.Configuration.GetConnectionString("TuckshopContextConnection") ?? throw new InvalidOperationException("Connection string 'TuckshopContextConnection' not found.");

       builder.Services.AddDbContext<TuckshopContext>(options =>
        options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<TuckshopUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TuckshopContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            
            using (var scope = app.Services.CreateScope()) 
            {
                var roleManager = 
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //creating roles
                var roles = new[] { "Admin", "Teacher", "Student" };

                foreach (var role in roles) 
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));

                }
            }

            using (var scope = app.Services.CreateScope())
            {
                //assigning roles 
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<TuckshopUser>>();

                string FirstName = "Administrtor";
                string LastName = "Member";
                string email = "admin@tuckshop.com";
                string password = "Admin1234&";
                
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new TuckshopUser();
                    user.Firstname = FirstName;
                    user.LastName = LastName;
                    user.UserName = email;
                    user.Email = email;


                    await userManager.CreateAsync(user, password);

                   await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<TuckshopUser>>();

                string FirstName = "Teacher";
                string LastName = "member";
                string email = "teacher@tuckshop.com";
                string password = "Test1234,";

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new TuckshopUser();
                    user.Firstname = FirstName;
                    user.LastName = LastName;
                    user.UserName = email;
                    user.Email = email;


                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Teacher");
                }
            }


            app.Run();
        }
       

    }
    
}
