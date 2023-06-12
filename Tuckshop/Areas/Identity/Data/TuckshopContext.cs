using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tuckshop.Areas.Identity.Data;
using Tuckshop.Models;

namespace Tuckshop.Areas.Identity.Data;

public class TuckshopContext : IdentityDbContext<TuckshopUser>
{
    public TuckshopContext(DbContextOptions<TuckshopContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Tuckshop.Models.Order>? Order { get; set; }

    public DbSet<Tuckshop.Models.Food>? Food { get; set; }

    public DbSet<Tuckshop.Models.Student>? Student { get; set; }

    public DbSet<Tuckshop.Models.Payment>? Payment { get; set; }
}
