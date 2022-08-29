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
        public void DeleteCategory_NotFoundResult()
        {

            var dbName = nameof(ProductTypesApiTests.GetCategoryByID_NotFoundResult);
            var logger = Mock.Of<ILogger<ProductTypesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new ProductTypesController(dbContext, logger);
            int findCategoryID = 900;

            IActionResult actionresultDelete = controller.DeleteProductType(findCategoryID).Result;

            Assert.IsType<NotFoundResult>(actionresultDelete);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.NotFound; //404
            var actualStatusCode = (actionresultDelete as NotFoundResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void DeleteCategory_BadRequestResult()
        {


            var dbName = nameof(ProductTypesApiTests.GetCategoryByID_NotFoundResult);
            var logger = Mock.Of<ILogger<ProductTypesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new ProductTypesController(dbContext, logger);
            int? findCategoryID = null;

            IActionResult actionresultDelete = controller.DeleteProductType(findCategoryID).Result;

            Assert.IsType<BadRequestResult>(actionresultDelete);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.BadRequest; //400
            var actualStatusCode = (actionresultDelete as BadRequestResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void DeleteCategory_OkResult()
        {
            //saves category to database
            var dbName = nameof(ProductTypesApiTests.GetCategoryByID_NotFoundResult);
            //Create the mocked logger that is injected into Categories Controller
            var logger = Mock.Of<ILogger<ProductTypesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            //invoke controller call
            var controller = new ProductTypesController(dbContext, logger);
            int findCategoryID = 1;

            IActionResult actionresultDelete = controller.DeleteProductType(findCategoryID).Result;

            Assert.IsType<OkObjectResult>(actionresultDelete);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK; //400
            var actualStatusCode = (actionresultDelete as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }
    }
}
