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


   
    public DbSet<Tuckshop.Models.Request>? Request { get; set; }

    public DbSet<Tuckshop.Models.Food>? Food { get; set; }

    public DbSet<Tuckshop.Models.Student>? Student { get; set; }

   


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Student>().HasData(
            new Student() { StudentID=1 , FirstName = "Josef", LastName = "Fatu", Homeroom = "EKO" },
            new Student() { StudentID = 2, FirstName = "Rynal", LastName = "Chand", Homeroom = "DYL" },
            new Student() { StudentID = 3, FirstName = "Sujal", LastName = "Chand", Homeroom = "EKR" },
            new Student() { StudentID=4, FirstName="Muhammad", LastName="Sherry", Homeroom="STP"}
            
            );

       


        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<TuckshopUser>
    {
        public void Configure(EntityTypeBuilder<TuckshopUser> builder)
        {
            builder.Property(u => u.Firstname).HasMaxLength(200);
            builder.Property(u => u.LastName).HasMaxLength(200);
        }
    }
}


