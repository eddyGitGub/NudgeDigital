using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NudgeDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NudgeDigital.Application.Contracts.Persistence
{
    public interface INudgeDigitalDbContext
    {
       public DbSet<Brand> Brands { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<LaptopConfiguration> LaptopConfigurations { get; set; }
        public DbSet<ShoppingBasket> Carts { get; set; }

        

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
