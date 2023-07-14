using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<TuckshopUser>
    {
        public void Configure(EntityTypeBuilder<TuckshopUser> builder)
        { 
            builder.Property(u => u.Firstname).HasMaxLength(200);
            builder.Property(u => u.LastName).HasMaxLength(200);
        }
    }
    public DbSet<Tuckshop.Models.Request>? Request { get; set; }

    public DbSet<Tuckshop.Models.Food>? Food { get; set; }

    public DbSet<Tuckshop.Models.Student>? Student { get; set; }

    public DbSet<Tuckshop.Models.Payment>? Payment { get; set; }
}
