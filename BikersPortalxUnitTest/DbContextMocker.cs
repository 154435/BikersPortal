using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using BikersPortal.Data;
using BikersPortal.Models;

namespace BikersPortalxUnitTest
{
    public static class DbContextMocker
    {
        public static ApplicationDbContext GetApplicationDbContext(string databasename)
        {
            // Create a fresh service provider for the InMemory Database instance.
            var serviceProvider = new ServiceCollection()
                                  .AddEntityFrameworkInMemoryDatabase()
                                  .BuildServiceProvider();

            // Create a new options instance,
            // telling the context to use InMemory database and the new service provider.
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databasename)
                            .UseInternalServiceProvider(serviceProvider)
                            .Options;

            // Create the instance of the DbContext (would be an InMemory database)
            // NOTE: It will use the Scema as defined in the Data and Models folders
            var dbContext = new ApplicationDbContext(options);

            // Add entities to the inmemory database
            dbContext.SeedData();

            return dbContext;
        }
        internal static readonly ProductType[] TestData_Categories
            = {
                new ProductType
                {
                    ProductTypeId = 1,
                    ProductTypes = "First Category",
              
                },
                new ProductType
                {

                    ProductTypeId = 2,
                    ProductTypes = "Second Category",
                  
                },
                new ProductType
                {

                    ProductTypeId = 3,
                    ProductTypes = "Third Category",
                    
                }
            };

        private static void SeedData(this ApplicationDbContext context)
        {
            context.ProductTypes.AddRange(TestData_Categories);

            context.SaveChanges();
        }
    }
}
