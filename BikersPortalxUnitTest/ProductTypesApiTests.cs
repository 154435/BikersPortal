using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace BikersPortalxUnitTest
{
    public partial class ProductTypesApiTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public ProductTypesApiTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
    }
}
