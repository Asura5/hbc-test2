using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBC.Controllers;

namespace HBC.Services
{
    public interface IGetAddressRecords
    {
        public List<Address> SearchAddresses(string validatedPostcode);
    }

    public class AddressService : IGetAddressRecords
    {
        public List<Address> SearchAddresses(string validatedPostcode)
        {
            return new List<Address>();
        }
    }


}
