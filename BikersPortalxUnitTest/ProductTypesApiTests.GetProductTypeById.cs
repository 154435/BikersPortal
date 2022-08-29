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
using System.Linq;

namespace BikersPortalxUnitTest
{
    public partial class ProductTypesApiTests
    {
        [Fact]
        public void GetCategoryByID_NotFoundResult()
        {
            var dbName = nameof(ProductTypesApiTests.GetCategoryByID_NotFoundResult);
            var logger = Mock.Of<ILogger<ProductTypesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new ProductTypesController(dbContext, logger);
            int findCategoryID = 900;

            IActionResult actionresult = controller.GetProductTypes(findCategoryID).Result;

            Assert.IsType<NotFoundResult>(actionresult);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.NotFound; //404
            var actualStatusCode = (actionresult as NotFoundResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategoryByID_BadFoundResult()
        {
            var dbName = nameof(ProductTypesApiTests.GetCategoryByID_BadFoundResult);
            var logger = Mock.Of<ILogger<ProductTypesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new ProductTypesController(dbContext, logger);
            int? findCategoryID = null;

            IActionResult actionresult = controller.GetProductTypes(findCategoryID).Result;

            Assert.IsType<BadRequestResult>(actionresult);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.BadRequest; //404
            var actualStatusCode = (actionresult as BadRequestResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategoryById_OkResult()
        {

            var dbName = nameof(ProductTypesApiTests.GetCategoryById_OkResult);
            var logger = Mock.Of<ILogger<ProductTypesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new ProductTypesController(dbContext, logger);
            int findCategoryID = 1;

            IActionResult actionresult = controller.GetProductTypes(findCategoryID).Result;

            Assert.IsType<OkObjectResult>(actionresult);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK; //200
            var actualStatusCode = (actionresult as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategoryById_CorrectResult()
        {

            var dbName = nameof(ProductTypesApiTests.GetCategoryById_CorrectResult);
            var logger = Mock.Of<ILogger<ProductTypesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new ProductTypesController(dbContext, logger);
            int findCategoryID = 2;

            ProductType expectedCategory = DbContextMocker.TestData_Categories
                                            .SingleOrDefault(c => c.ProductTypeId == findCategoryID);



            IActionResult actionresult = controller.GetProductTypes(findCategoryID).Result;

            OkObjectResult result = actionresult.Should().BeOfType<OkObjectResult>().Subject;

            Assert.IsType<ProductType>(result.Value);

            ProductType pc = result.Value.Should().BeAssignableTo<ProductType>().Subject;//actual category
            _outputHelper.WriteLine($"Found: Category Id : {pc.ProductTypeId}, Category Name : {pc.ProductTypes}");

            Assert.NotNull(pc);



            Assert.Equal<int>(expected: expectedCategory.ProductTypeId, actual: pc.ProductTypeId);


            Assert.Equal(expected: expectedCategory.ProductTypes, actual: pc.ProductTypes);


           


        }


    }
}
