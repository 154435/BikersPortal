using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using BikersPortal.Controllers;
using BikersPortal.Models;
using Xunit;
using Xunit.Abstractions;


namespace BikersPortalxUnitTest
{
    public partial class ProductTypesApiTests
    {
        [Fact]
        public void GetCategories_OkResult()
        {
            var dbName = nameof(ProductTypesApiTests.GetCategories_OkResult);
            var logger = Mock.Of<ILogger<ProductTypesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new ProductTypesController(dbContext, logger);

            IActionResult actionresult = controller.GetProductTypes().Result;

            Assert.IsType<OkObjectResult>(actionresult);

            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
            var actualStatusCode = (actionresult as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategories_CheckCorrectResult()
        {
            var dbName = nameof(ProductTypesApiTests.GetCategories_CheckCorrectResult);
            var logger = Mock.Of<ILogger<ProductTypesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new ProductTypesController(dbContext, logger);

            IActionResult actionresult = controller.GetProductTypes().Result;

            Assert.IsType<OkObjectResult>(actionresult);

            var okResult = actionresult.Should().BeOfType<OkObjectResult>().Subject;

            Assert.IsAssignableFrom<List<ProductType>>(okResult.Value); //error can be found

            var categories = okResult.Value.Should().BeAssignableTo<List<ProductType>>().Subject;

            Assert.NotNull(categories);

            Assert.Equal(expected: DbContextMocker.TestData_Categories.Length,
                        actual: categories.Count);


            int ndx = 0;
            foreach (ProductType productTypes in DbContextMocker.TestData_Categories)
            {
                Assert.Equal<int>(expected: productTypes.ProductTypeId,
                    actual: categories[ndx].ProductTypeId);

                Assert.Equal(expected: productTypes.ProductTypes,
                    actual: categories[ndx].ProductTypes);

                _outputHelper.WriteLine($"Row # {ndx} Result {productTypes.ProductTypes}");
                ndx++;
            }
        }
    }
}
