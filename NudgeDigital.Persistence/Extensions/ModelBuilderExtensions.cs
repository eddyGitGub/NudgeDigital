using Microsoft.EntityFrameworkCore;
using NudgeDigital.Domain.Entities;


namespace NudgeDigital.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Laptop>().HasData(new Laptop
            //{
            //    Id = 1,
            //    Name = "Dell",
            //    Price = 349.87M,
            //    Description = "Dell"
            //},
            //new Laptop
            //{
            //    Id = 2,
            //    Name = "Toshiba",
            //    Price = 345.67M,
            //    Description = "Toshiba"
            //},
            //new Laptop
            //{
            //    Id = 3,
            //    Name = "HP",
            //    Price = 456.76M,
            //    Description = "HP"
            //}
            //);
            modelBuilder.Entity<Component>().HasData(
               new Component
               {
                   Id = 1,
                   Name = "Ram",

               },
                new Component
                {
                    Id = 2,
                    Name = "HDD"
                },
                 new Component
                 {
                     Id = 3,
                     Name = "Color"
                 }
               );

            modelBuilder.Entity<Configuration>().HasData(
                new Configuration
            {
                Id = 1,
                ComponentType = "Ram 8GB",
                Price = 45.67M,
                ComponentId= 1,


            }, new Configuration
            {
                Id = 2,
                ComponentType = "Ram 16GB",
                Price = 87.88M,
                ComponentId = 1


            }, new Configuration
            {
                Id = 3,
                ComponentType = "HDD 500 GB",
                Price = 123.34M,
                ComponentId= 2


            }, new Configuration
            {
                Id = 4,
                ComponentType = "HDD 1 TB",
                Price = 200.00M,
                ComponentId = 2


            });
           

        }
    }
}
