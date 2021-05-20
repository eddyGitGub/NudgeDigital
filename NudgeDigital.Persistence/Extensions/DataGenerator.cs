﻿using NudgeDigital.Domain.Entities;
using System.Linq;

namespace NudgeDigital.Persistence.Extensions
{
    public class DataGenerator
    {
        public static void Initialize(NudgeDigitalDbContext context)
        {
            // Look for any board games.
            if (!context.Components.Any())
            {
                context.Components.AddRange(
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
             });

            }

            if (!context.Configurations.Any())
            {
                context.Configurations.AddRange(
                     new Configuration
                     {
                         Id = 1,
                         ComponentType = "Ram 8GB",
                         Price = 45.67M,
                         ComponentId = 1,


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
                         ComponentId = 2


                     }, new Configuration
                     {
                         Id = 4,
                         ComponentType = "HDD 1 TB",
                         Price = 200.00M,
                         ComponentId = 2


                     }
                    );

            }

            if (!context.Brands.Any())
            {
                context.Brands.AddRange(
                     new Brand
                     {
                         Id=1,
                        Name = "Dell",
                        Price= 349.87M



                     }, new Brand
                     {
                         Id=2,
                         Name= "Toshiba",
                         Price = 345.67M


                     }, new Brand
                     {
                         Id=3,
                         Name = "HP",
                         Price = 456.76M



                     }, 
                     new Brand
                     {
                         Id=4,
                        Name="Apple",
                        Price= 649.87M



                     }
                    );

            }


            context.SaveChanges();
        }
    }
}
