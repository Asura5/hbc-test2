using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HBC.Controllers
{
    public class AddressController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IGetAddressRecords _addressService;
        private readonly IValidatePostcodes _postcodeValidator;

        public AddressController(ILogger logger, IGetAddressRecords addressService, IValidatePostcodes postcodeValidator )
        {
            _logger = logger;
            _addressService = addressService;
            _postcodeValidator = postcodeValidator;
        }

        [HttpGet]
        public IEnumerable<Address> GetAddresses(string postCode)
        {
            var validationResult = _postcodeValidator.CheckPostcode(postCode);

            if (!validationResult)
            {
                _logger.LogWarning($"Postcode {postCode} is invalid");
                BadRequest();
            }
            
            //...
            var postcodes = _addressService.SearchAddresses(postCode);


            return new List<Address>();
        }
    }
}
