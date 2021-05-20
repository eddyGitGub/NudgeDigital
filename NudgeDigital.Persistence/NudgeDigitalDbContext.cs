using Microsoft.EntityFrameworkCore;
using NudgeDigital.Application.Contracts.Persistence;
using NudgeDigital.Domain.Common;
using NudgeDigital.Domain.Entities;
using NudgeDigital.Persistence.Configurations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NudgeDigital.Persistence
{
    public class NudgeDigitalDbContext : DbContext, INudgeDigitalDbContext
    {
        public NudgeDigitalDbContext(DbContextOptions <NudgeDigitalDbContext> options) : base(options)
        { }
        
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<LaptopConfiguration> LaptopConfigurations { get; set; }
        public DbSet<ShoppingBasket> Carts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            //Decimal Column
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal)))
            {
                property.SetColumnType("decimal(12, 2)");
            }
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NudgeDigitalDbContext).Assembly);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BrandConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConfigurationConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingBasketConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComponentConfig).Assembly);
           
            // modelBuilder.Seed();





        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
