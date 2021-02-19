using System.Collections.Generic;
using HBC.Controllers;
using HBC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace HBC.Tests
{
    [TestClass]
    public class AddressControllerTests
    {
        private AddressController _sut;
        private Mock<IGetAddressRecords> _addressServiceMock;
        private Mock<ILogger> _mockLogger;
        private Mock<IValidatePostcodes> _postcodeValidatorMock;

        private string _postcode;
        private IEnumerable<Address> _result;

        [TestInitialize]
        public void SetupTest()
        {
            _addressServiceMock = new Mock<IGetAddressRecords>();
            _mockLogger = new Mock<ILogger>();
            _postcodeValidatorMock = new Mock<IValidatePostcodes>();

            _sut = new AddressController(_mockLogger.Object, _addressServiceMock.Object, _postcodeValidatorMock.Object);
        }

        [TestMethod]
        public void ShouldReturnBadRequest_ForInvalidPostcode()
        {
            given_an_invalid_postpost();
            when_the_endpoint_is_called();
            then_the_endpoint_should_return_bad_request();
        }

        private void then_the_endpoint_should_return_bad_request()
        {
            var wrappedResult = _result as StatusCodeResult;
            Assert.AreEqual(400, wrappedResult.StatusCode);
        }

        private void when_the_endpoint_is_called()
        {
            
            _result = _sut.GetAddresses(_postcode);
        }

        private void given_an_invalid_postpost()
        {
            _postcode = "XXXXXX";
        }
    }
}
